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
using com.ccf.bip.biz.system.authorization.mapper;
using com.ccf.bip.framework.form.helper;
using com.ccf.bip.biz.metadata.org.mapper;
using Infragistics.Win.UltraWinTree;

namespace com.ccf.bip.biz.sys
{
    public partial class FormDataAuthority : BipForm
    {
        public FormDataAuthority()
        {
            InitializeComponent();
        }

        private void FormDataAuthority_Load(object sender, EventArgs e)
        {
            LoadFunctionTree();
            LoadOrgCombo();
        }

        private void LoadFunctionTree()
        {
            List<SysFunction> funList = this.FindList<SysFunction>(Globals.FUNCTION_SERVICE_NAME, "findFunctionListByUser", new object[] { User });
            UltraTreeHelper.FillData(funList, ultraTreeFun, null);
        }

        private void LoadOrgCombo()
        {
            List<SysOrganization> orgList = this.FindList<SysOrganization>(Globals.ORGANIZATION_SERVICE_NAME, "findAll", new object[0]);
            FillData(orgList, cbtOrg.Nodes);
        }

        private void FillData(List<SysOrganization> list, TreeNodeCollection nodes)
        {
            TreeNode node = null;
            nodes.Clear();

            //获取最高组织节点
            List<SysOrganization> orgList = list.FindAll(o => string.IsNullOrEmpty(o.ParentId));
            foreach (SysOrganization org in orgList)
            {
                node = new TreeNode();
                node.Name = org.OrganizationId;
                node.Text = org.OrganizationName;
                nodes.Add(node);

                FillData(list, node);
            }
        }

        private void FillData(List<SysOrganization> list, TreeNode node)
        {
            TreeNode subNode = null;
            List<SysOrganization> orgList = list.FindAll(o => !string.IsNullOrEmpty(o.ParentId) && o.ParentId.Equals(node.Name));
            foreach (SysOrganization org in orgList)
            {
                subNode = new TreeNode();
                subNode.Name = org.OrganizationId;
                subNode.Text = org.OrganizationName;
                node.Nodes.Add(subNode);

                FillData(list, subNode);
            }
        }

        private void ultraTreeFun_AfterActivate(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            UltraTreeNode node = (sender as UltraTree).ActiveNode;
            if (node != null)
            {
                SysFunction fun = node.Tag as SysFunction;
                if (fun.FunctionType.Equals("1014"))
                {
                    QueryDataRight(fun.FunctionId);
                }
            }
        }

        private void QueryDataRight(string formId)
        {
            dataTable2.Clear();
            this.dataTable1.Clear();
            dataTable1.Merge(this.FindDataTable(Globals.POST_SERVICE_NAME, "findPostDataRightByFormId", new object[] { formId }));
            dataTable2.Merge(this.FindDataTable(Globals.POST_SERVICE_NAME, "findEmployeeDataRightByFormId", new object[] { formId }));
        }

        private void ultraGrid1_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            ultraGrid1.UpdateData();
            switch (e.Cell.Column.Key)
            {
                case "FILTERORG":
                    if (Convert.ToBoolean(e.Cell.Value))
                        e.Cell.Row.Cells["FILTERUSER"].Value = "false";
                    break;
                case "FILTERUSER":
                    if (Convert.ToBoolean(e.Cell.Value))
                        e.Cell.Row.Cells["FILTERORG"].Value = "false";
                    break;
            }
        }
    }
}
