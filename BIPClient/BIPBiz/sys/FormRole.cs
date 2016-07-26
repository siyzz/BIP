using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.form;
using com.ccf.bip.biz.system.authorization.mapper;
using Infragistics.Win.UltraWinTree;
using com.ccf.bip.framework.core;
using com.ccf.bip.framework.form.helper;
using System.Collections;
using MetroFramework;

namespace com.ccf.bip.biz.sys
{
    public partial class FormRole : BipForm
    {
        public FormRole()
        {
            InitializeComponent();
        }

        public override void ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Refresh":
                    QueryRole();
                    QueryFunction();
                    break;
                case "Save":
                    Save();
                    break;
            }
        }

        private void FormRole_Load(object sender, EventArgs e)
        {
            QueryRole();
            QueryFunction();
        }

        private void QueryRole()
        {
            IEnumerable<SysRole> roles = this.Find<SysRole>(Globals.ROLE_SERVICE_NAME, "findAll", new object[0]);
            List<SysRole> roleList = new List<SysRole>();
            roleList.AddRange(roles);
            UltraTreeHelper.FillData(roleList, this.ultraTreeRole);
        }

        private void QueryFunction()
        {
            IEnumerable<SysFunction> funs = this.Find<SysFunction>(Globals.FUNCTION_SERVICE_NAME, "findFunctionList", new object[0]);
            List<SysFunction> funList = new List<SysFunction>();
            funList.AddRange(funs);
            UltraTreeHelper.FillData(funList, this.ultraTreeFunction,null);
        }

        private void Save()
        {
            if (ultraTreeRole.ActiveNode != null && ultraTreeAuthor.Nodes.Count > 0)
            {
                string roleId = (ultraTreeRole.ActiveNode.Tag as SysRole).RoleId;
                ArrayList funList = GetAuthorFunctionList(ultraTreeAuthor);
                this.Update(Globals.ROLE_SERVICE_NAME, "authorize", new object[] { roleId, funList });
                MetroMessageBox.Show(this,"保存成功！");
            }
        }

        private ArrayList GetAuthorFunctionList(UltraTree tree)
        {
            ArrayList funList = new ArrayList();
            short level = 0;
            IList<IEnumerator> nodeList = new List<IEnumerator>();
            nodeList.Add(tree.Nodes.GetEnumerator());
            while (level >= 0)
            {
                IEnumerator enumer = nodeList[level];
                if (enumer.MoveNext())
                {
                    UltraTreeNode node = (UltraTreeNode)enumer.Current;
                    SysFunction fun = new SysFunction();
                    fun.FunctionId = node.Key;
                    fun.FunctionName = node.Text;
                    fun.ParentId = node.Parent != null ? node.Parent.Key : null;
                    fun.Seq = (short)(node.Index + 1);
                    funList.Add(fun);
                    if (node.Nodes.Count > 0)
                    {
                        level++;
                        nodeList.Add(node.Nodes.GetEnumerator());
                    }
                }
                else
                {
                    nodeList.RemoveAt(level);
                    level--;
                }
            }
            return funList;
        }

        private void toolStripMenuItemAddRoot_Click(object sender, EventArgs e)
        {
            DlgRoleEdit dlg = new DlgRoleEdit(null, EditType.AddRoot);
            dlg.Action = this.Action;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                SysRole role = dlg.Role;
                UltraTreeNode node = new UltraTreeNode(role.RoleId);
                node.Text = role.RoleName;
                node.Tag = role;
                ultraTreeRole.Nodes.Add(node);
            }
        }

        private void toolStripMenuItemAddSub_Click(object sender, EventArgs e)
        {
             UltraTreeNode node = ultraTreeRole.ActiveNode;
             if (node != null)
             {
                 SysRole role = node.Tag as SysRole;
                 DlgRoleEdit dlg = new DlgRoleEdit(role, EditType.AddChild,this.Action);
                 if (dlg.ShowDialog(this) == DialogResult.OK)
                 {
                     SysRole cRole = dlg.Role;
                     UltraTreeNode child = new UltraTreeNode(cRole.RoleId);
                     child.Text = cRole.RoleName;
                     child.Tag = cRole;
                     node.Nodes.Add(child);
                 }
             }
        }

        private void toolStripMenuItemUpdate_Click(object sender, EventArgs e)
        {
            UltraTreeNode node = ultraTreeRole.ActiveNode;
            if (node != null)
            {
                SysRole role = node.Tag as SysRole;
                DlgRoleEdit dlg = new DlgRoleEdit(role, EditType.Update, this.Action);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    SysRole newRole = dlg.Role;
                    node.Text = newRole.RoleName;
                    node.Tag = newRole;
                }
            }
        }

        private void ultraTreeRole_AfterActivate(object sender, NodeEventArgs e)
        {
            UltraTreeNode node = (sender as UltraTree).ActiveNode;
            if (node != null)
            {
                string roleId = (node.Tag as SysRole).RoleId;
                QueryAuthor(roleId);
            }
        }

        private void QueryAuthor(string roleId)
        {
            IEnumerable<SysFunction> funs = this.Find<SysFunction>(Globals.ROLE_SERVICE_NAME, "findAuthor", new object[]{roleId});
            List<SysFunction> funList = new List<SysFunction>();
            funList.AddRange(funs);
            UltraTreeHelper.FillData(funList, this.ultraTreeAuthor, "1014");
        }

        private void AppendNodes(UltraTreeNode sourceNode,UltraTree targetTree)
        {
            UltraTreeNode tmp = sourceNode;
            if (sourceNode == null || targetTree.GetNodeByKey(tmp.Key) != null)
                return;
            TreeNodesCollection nodes = targetTree.Nodes;
            Stack<UltraTreeNode> stack = new Stack<UltraTreeNode>();
            if (tmp.Parent == null)
            {
                stack.Push(UltraTreeHelper.SingleClone(tmp));
            }
            else
            {
                bool flag = false;
                //如果选择的节点为界面，自动选择所有按钮
                int index = 0;
                while (tmp != null)
                {
                    UltraTreeNode newNode = UltraTreeHelper.SingleClone(tmp);
                    if (index == 0 && (tmp.Tag as SysFunction).FunctionType.Equals("1014"))
                    {
                        foreach (UltraTreeNode n in tmp.Nodes)
                        {
                            newNode.Nodes.Add(UltraTreeHelper.SingleClone(n));
                        }
                    }
                    stack.Push(newNode);
                    tmp = tmp.Parent;
                    if (tmp != null && targetTree.GetNodeByKey(tmp.Key) != null)
                    {
                        flag = true;
                        break;
                    }
                    index++;
                }
                                
                if (flag)
                {
                    nodes = targetTree.GetNodeByKey(tmp.Key).Nodes;
                }
            }
            UltraTreeNode node = null;
            while (stack.Count > 0)
            {
                node = stack.Pop();
                nodes.Add(node);
                if (node.Parent != null && !(node.Parent.Tag as SysFunction).FunctionType.Equals("1014"))
                    node.Parent.Expanded = true;
                nodes = node.Nodes;
            }
            if (node != null)
                ultraTreeAuthor.ActiveNode = node;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ultraTreeRole.ActiveNode == null)
                return;
            UltraTreeNode lNode = ultraTreeFunction.ActiveNode;
            AppendNodes(lNode, ultraTreeAuthor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UltraTreeNode node = ultraTreeAuthor.ActiveNode;
            if (node != null)
            {
                node.Reposition(node.Parent != null ? node.Parent.Nodes : ultraTreeAuthor.Nodes, (node.Index - 1 > 0 ? node.Index - 1 : 0));
                ultraTreeAuthor.ActiveNode = node;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UltraTreeNode node = ultraTreeAuthor.ActiveNode;
            if (node != null)
            {
                TreeNodesCollection parentNodes = (node.Parent != null ? node.Parent.Nodes : ultraTreeAuthor.Nodes);
                node.Reposition(parentNodes, (node.Index + 1 < parentNodes.Count - 1 ? node.Index + 1 : parentNodes.Count - 1));
                ultraTreeAuthor.ActiveNode = node;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UltraTreeNode node = ultraTreeAuthor.ActiveNode;
            if (node != null)
            {
                (node.Parent != null ? node.Parent.Nodes : ultraTreeAuthor.Nodes).Remove(node);
            }
        }
    }
}
