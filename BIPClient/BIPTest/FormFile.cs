using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.form;
using com.ccf.bip.framework.core;
using System.Collections;
using com.ccf.bip.framework.server.file;
using com.ccf.bip.framework.util;

namespace BIPTest
{
    public partial class FormFile : BipForm
    {
        public FormFile()
        {
            InitializeComponent();
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string[] fileNames = openFileDialog1.FileNames;
                int index = 0;
                foreach (string fileName in fileNames)
                {
                    ListViewItem item = new ListViewItem();
                    item.Name = String.Format("ListViewItem{0}", index++);
                    item.Text = fileName;
                    listView1.Items.Add(item);
                }
            }
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ultraTextEditor2.Text.Trim()) || listView1.Items.Count == 0)
                return;
            List<FileInfo> fileInfoList = new List<FileInfo>();
            foreach (ListViewItem item in listView1.Items)
            {
                FileInfo fileInfo = new FileInfo();
                fileInfo.Directory = ultraTextEditor2.Text.Trim();
                fileInfo.Name = item.Text.Substring(item.Text.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1);
                fileInfo.Content = FileUtil.FileToArray(item.Text);
                fileInfoList.Add(fileInfo);
            }

            this.Update(Globals.FILETRANSFER_SERVICE_NAME, "upload", new object[] { fileInfoList });
            listView1.Items.Clear();
        }

        private void FormFile_Load(object sender, EventArgs e)
        {
            
        }

        private void ultraTextEditor4_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                ultraTextEditor4.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ultraTextEditor3.Text.Trim()) || String.IsNullOrEmpty(ultraTextEditor4.Text.Trim()))
                return;
            List<FileInfo> fileInfoList = this.FindList<FileInfo>(Globals.FILETRANSFER_SERVICE_NAME, "download", new object[] { ultraTextEditor3.Text.Trim() });
            foreach (FileInfo fileInfo in fileInfoList)
            {
                System.IO.FileStream stream = new System.IO.FileStream(ultraTextEditor4.Text.Trim() + System.IO.Path.DirectorySeparatorChar + fileInfo.Name, System.IO.FileMode.OpenOrCreate);
                stream.Write(fileInfo.Content, 0, fileInfo.Content.Length);
                stream.Close();
            }
        }
    }
}
