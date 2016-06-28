using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTree;
using com.ccf.bip.biz.system.authorization.mapper;
using com.ccf.bip.framework.util;

namespace com.ccf.bip.frame
{
    public delegate void FormOpenningEventHandler(object sender, OpenFormEventArgs e);

    public class BipMainMenuTree : UltraTree
    {
        public event FormOpenningEventHandler OnBipFormOpenning = null;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.DisplayStyle = UltraTreeDisplayStyle.WindowsVista;
            this.Override.SelectionType = SelectType.Single;
            this.HideExpansionIndicators = HideExpansionIndicators.Never;
        }

        public new SysFunction Tag { get; set; }

        private List<SysFunction> dataSource;

        public new List<SysFunction> DataSource
        {
            get 
            {
                return dataSource;
            }
            set
            {
                dataSource = value;
                this.Nodes.Clear();
                FillData(dataSource, this);
            }
        }

        private void FillData(List<SysFunction> list, BipMainMenuTree tree)
        {
            UltraTreeNode node = null;
            TreeNodesCollection nodes = tree.Nodes;
            //获取根节点（代表系统）
            List<SysFunction> sysFunctions = list.FindAll(f => string.IsNullOrEmpty(f.ParentId));
            foreach (SysFunction sysFun in sysFunctions)
            {
                node = new UltraTreeNode();
                node.Key = sysFun.FunctionId;
                node.Text = sysFun.FunctionName;
                node.Tag = sysFun;
                node.LeftImages.Add(ResourceImg.home);
                nodes.Add(node);

                FillData(list, node);
            }
        }

        private void FillData(List<SysFunction> list, UltraTreeNode node)
        {
            UltraTreeNode subNode = null;
            List<SysFunction> funs = list.FindAll(f => f.ParentId != null && f.ParentId.Equals(node.Key));
            foreach (SysFunction fun in funs)
            {
                subNode = new UltraTreeNode();
                subNode.Key = fun.FunctionId;
                subNode.Text = fun.FunctionName;
                subNode.Tag = fun;
                if (fun.FunctionType.Equals("1014"))//功能界面
                {
                    subNode.LeftImages.Add(ResourceImg.form);
                }
                else
                {
                    subNode.LeftImages.Add(ResourceImg.directory);
                }
                node.Nodes.Add(subNode);

                FillData(list, subNode);
            }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (this.SelectedNodes.Count != 0)
            {
                UltraTreeNode node = this.SelectedNodes[0];
                SysFunction tag = node.Tag as SysFunction;
                if (tag.FunctionType.Equals("1014"))
                {
                    //MessageBox.Show(tag.Url);
                    if(OnBipFormOpenning != null)
                    {
                        OnBipFormOpenning(this, new OpenFormEventArgs(tag));    
                    }
                }
            }
        }
    }
}
