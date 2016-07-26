using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.form;
using com.ccf.bip.biz.system.update.mapper;
using com.ccf.bip.framework.core;
using Infragistics.Win.UltraWinTree;
using System.IO;

namespace com.ccf.bip.biz.sys
{
    public partial class FormUpload : BipForm
    {
        private List<FileVersion> fileVersionList = new List<FileVersion>();

        public FormUpload()
        {
            InitializeComponent();
        }

        private void FormUpload_Load(object sender, EventArgs e)
        {
            fileVersionList = this.FindList<FileVersion>(Globals.PROGRAM_UPDATE_SERVICE_NAME, "findFileVersionList", new object[0]);
            BuildTree(fileVersionList);
        }

        public override void ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Refresh":
                    fileVersionList = this.FindList<FileVersion>(Globals.PROGRAM_UPDATE_SERVICE_NAME, "findFileVersionList", new object[0]);
                    BuildTree(fileVersionList);
                    break;
                case "Upload":
                    ShowUploadDialog();
                    break;
            }
        }

        private void BuildTree(List<FileVersion> list)
        {
            ultraTree1.Nodes.Clear();
            List<string> pathList = new List<string>();
            //获取去重后的路径
            foreach (FileVersion fileVersion in list)
            {
                if (!pathList.Contains(fileVersion.Directory))
                {
                    pathList.Add(fileVersion.Directory);
                }
            }

            UltraTreeNode root = new UltraTreeNode();
            root.Key = "Root";
            root.Text = "/(根目录)";
            root.LeftImages.Add(Image.FromFile("./resource/image/mainMenu/home.png"));
            root.Expanded = true;
            ultraTree1.Nodes.Add(root);
            if (pathList.Count > 0)
            {
                pathList.Sort();                
                List<List<string>> pathRect = new List<List<string>>(); 
                foreach (string path in pathList)
                {
                    if (!String.IsNullOrEmpty(path))
                    {
                        pathRect.Add(new List<string>(path.Split('/')));
                    }
                }
                foreach (List<string> tmpList in pathRect)
                {
                    List<string> tmpPath = new List<string>();
                    foreach (string tmpStr in tmpList)
                    {   
                        UltraTreeNode parent = ultraTree1.GetNodeByKey(tmpPath.Count == 0 ? "Root" : String.Join("/", tmpPath.ToArray()));
                        if (parent != null)
                        {
                            tmpPath.Add(tmpStr);
                            if (ultraTree1.GetNodeByKey(String.Join("/", tmpPath.ToArray())) == null)
                            {
                                UltraTreeNode node = new UltraTreeNode();
                                node.Key = String.Join("/", tmpPath.ToArray());
                                node.Text = tmpStr;
                                node.LeftImages.Add(Image.FromFile("./resource/image/mainMenu/directory.png"));
                                node.Expanded = true;
                                parent.Nodes.Add(node);
                            }
                        }
                        
                    }
                }                
            }
            ultraTree1.ActiveNode = root;
        }

        private void ultraTree1_AfterActivate(object sender, NodeEventArgs e)
        {
            string key = e.TreeNode.Key;
            if (key.Equals("Root"))
            {
                fileVersionBindingSource.DataSource = fileVersionList;
            }
            else
            {
                fileVersionBindingSource.DataSource = fileVersionList.FindAll(f => !String.IsNullOrEmpty(f.Directory) && f.Directory.Contains(key));
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowUploadDialog();
        }

        private void ShowUploadDialog()
        {
            UltraTreeNode node = ultraTree1.ActiveNode;
            if (node != null)
            {
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    string[] fileNames = openFileDialog1.FileNames;
                    DlgProgramUpload dlg = new DlgProgramUpload();
                    dlg.Action = this.Action;
                    dlg.FileNames = fileNames;
                    dlg.UploadDirectory = node.Key;
                    dlg.ShowDialog(this);
                    //刷新上传后文件显示
                    fileVersionList = this.FindList<FileVersion>(Globals.PROGRAM_UPDATE_SERVICE_NAME, "findFileVersionList", new object[0]);
                    BuildTree(fileVersionList);
                    ultraTree1.ActiveNode = ultraTree1.GetNodeByKey(node.Key);
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UltraTreeNode node = ultraTree1.ActiveNode;
            if (node != null)
            {
                UltraTreeNode newNode = new UltraTreeNode();
                string parentKey = node.Key.Equals("Root") ? "" : (node.Key + "/");
                int i = 0;
                string text = "newFolder";
                string key = parentKey + text;
                UltraTreeNode findNode = ultraTree1.GetNodeByKey(key);
                do
                {
                    if (findNode == null)
                    {
                        break;
                    }
                    text = "newFolder" + (++i).ToString();
                    key = node.Key + text;
                    findNode = ultraTree1.GetNodeByKey(key);
                }
                while (true);
                newNode.Key = key;
                newNode.Text = text;
                newNode.Expanded = true;
                newNode.LeftImages.Add(Image.FromFile("./resource/image/mainMenu/directory.png"));
                newNode.Override.LabelEdit = Infragistics.Win.DefaultableBoolean.True;
                node.Nodes.Add(newNode);

                ultraTree1.ActiveNode = newNode;
                newNode.BeginEdit();
            }
        }

        private void ultraTree1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                UltraTreeNode node = ultraTree1.GetNodeFromPoint(e.X, e.Y);
                if (node != null)
                {
                    ultraTree1.ActiveNode = node;
                }
            }
        }

        private void ultraTree1_AfterLabelEdit(object sender, NodeEventArgs e)
        {
            UltraTreeNode parent = e.TreeNode.Parent;
            if (parent != null)
            {
                string key = (parent.Key.Equals("Root") ? "" : (parent.Key + "/")) + e.TreeNode.Text;
                e.TreeNode.Key = key;
            }
        }        
    }
}
