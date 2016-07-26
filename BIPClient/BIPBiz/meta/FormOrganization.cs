using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.form;
using com.ccf.bip.biz.metadata.org.mapper;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using com.ccf.bip.framework.core;
using com.ccf.bip.framework.server;
using com.ccf.bip.biz.metadata.dictionary.mapper;
using com.ccf.bip.biz.metadata.employee.mapper;
using com.ccf.bip.framework.form.helper;
using MetroFramework;

namespace com.ccf.bip.biz.meta
{
    /// <summary>
    /// 组织结构管理
    /// </summary>
    public partial class FormOrganization : BipForm
    {
        private string activeOrganizationId = "";

        public FormOrganization()
        {
            InitializeComponent();
        }

        private void FormOrganization_Load(object sender, EventArgs e)
        {
            InitContorlData();
            Refresh();
        }

        private void InitContorlData()
        {
        }

        public override void ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Refresh":
                    Refresh();
                    break;
                case "Add":
                    break;
                case "Update":
                    break;
                case "Delete":
                    break;
            }
        }

        private new void Refresh()
        {
            IEnumerable<SysOrganization> enums = this.Find<SysOrganization>(Globals.ORGANIZATION_SERVICE_NAME, "findAll", new object[0]);
            List<SysOrganization> orgList = new List<SysOrganization>();
            orgList.AddRange(enums);
            UltraTreeHelper.FillData(orgList, this.ultraTree1,null,true);
        }

        private void QueryEmployees(string orgId)
        {
            IEnumerable<SysEmployee> employees = this.Find<SysEmployee>(Globals.EMPLOYEE_SERVICE_NAME, "recursiveFindByOrgId", new object[]{orgId});
            List<SysEmployee> employeeList = new List<SysEmployee>();
            employeeList.AddRange(employees);
            sysEmployeeBindingSource.DataSource = employeeList;
        }

        private void toolStripMenuItemAddRoot_Click(object sender, EventArgs e)
        {
            DlgOrgEdit form = new DlgOrgEdit(null, EditType.AddRoot,this.Action);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                SysOrganization newOrg = form.Organization;
                UltraTreeNode node = new UltraTreeNode();
                node.Key = newOrg.OrganizationId;
                node.Text = GetOrgTreeNodeText(newOrg);
                node.LeftImages.Add(GetImage(newOrg.OrganizationType));
                node.Tag = newOrg;
                ultraTree1.Nodes.Add(node);
            }
        }

        private void toolStripMenuItemAddSub_Click(object sender, EventArgs e)
        {
            UltraTreeNode node = ultraTree1.ActiveNode;
            if (node != null)
            {
                SysOrganization org = node.Tag as SysOrganization;
                DlgOrgEdit form = new DlgOrgEdit(org, EditType.AddChild, this.Action);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SysOrganization newOrg = form.Organization;
                    UltraTreeNode subNode = new UltraTreeNode();
                    subNode.Key = newOrg.OrganizationId;
                    subNode.Text = GetOrgTreeNodeText(newOrg);
                    subNode.Tag = newOrg;
                    subNode.LeftImages.Add(GetImage(newOrg.OrganizationType));
                    node.Nodes.Add(subNode);
                }
            }
        }

        private void toolStripMenuItemUpdate_Click(object sender, EventArgs e)
        {
            UltraTreeNode node = ultraTree1.ActiveNode;
            if (node != null)
            {
                SysOrganization org = node.Tag as SysOrganization;
                DlgOrgEdit form = new DlgOrgEdit(org, EditType.Update, this.Action);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SysOrganization newOrg = form.Organization;
                    node.Text = newOrg.OrganizationName;
                    node.Tag = newOrg;
                }
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            UltraTreeNode node = ultraTree1.ActiveNode;
            if (node != null)
            {
                if (node.Nodes.Count > 0)
                {
                    MetroMessageBox.Show(this,"请先删除下级组织！");
                    return;
                }
                SysOrganization org = node.Tag as SysOrganization;
                if (MetroMessageBox.Show(this,"是否确定删除该组织？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Update(Globals.ORGANIZATION_SERVICE_NAME, "delete", new object[] { org.OrganizationId });
                }
            }
        }

        private Image GetImage(string orgType)
        {
            string path = "\\resource\\image\\mainMenu\\";
            switch (orgType)
            {
                case "1001":
                    path += "group.png";
                    break;
                case "1002":
                    path += "company.png";
                    break;
                case "1003":
                    path += "department.png";
                    break;
                case "1004":
                    path += "section.png";
                    break;
                default:
                    path += "directory.png";
                    break;
            }
            return Image.FromFile(Globals.AppPath + path);
        }

        private string GetOrgTreeNodeText(SysOrganization org)
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(org.OrganizationCode))
            {
                sb.Append("[");
                sb.Append(org.OrganizationCode);
                sb.Append("]");
            }
            sb.Append(org.OrganizationName);

            return sb.ToString();
        }

        private void ultraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SysEmployee employee = e.Row.ListObject as SysEmployee;
            DlgEmployeeEdit dlg = new DlgEmployeeEdit(employee, EditType.Update, this.Action);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                QueryEmployees(activeOrganizationId);
            }
        }

        private void ultraTree1_AfterSelect(object sender, SelectEventArgs e)
        {
            UltraTree tree = sender as UltraTree;
            if (tree.SelectedNodes.Count > 0)
            {
                UltraTreeNode node = (sender as UltraTree).SelectedNodes[0];
                activeOrganizationId = node.Key;
                QueryEmployees(activeOrganizationId);
            }
        }

        private void ultraTree1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {
                SysEmployee employee = ultraGrid1.ActiveRow.ListObject as SysEmployee;
                DlgEmployeeEdit dlg = new DlgEmployeeEdit(employee, EditType.Update, this.Action);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    QueryEmployees(activeOrganizationId);
                }
            }
        }

        /// <summary>
        /// 新增员工信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(activeOrganizationId))
            {
                DlgEmployeeEdit dlg = new DlgEmployeeEdit(null, EditType.Add, this.Action);
                dlg.OrganizationId = activeOrganizationId;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    QueryEmployees(activeOrganizationId);
                }
            }
        }

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ultraGrid1.UpdateData();
            List<String> employeeIdList = new List<string>();
            foreach (UltraGridRow row in ultraGrid1.Rows)
            {
                SysEmployee employee = row.ListObject as SysEmployee;
                if (employee.IsChecked)
                {
                    employeeIdList.Add(employee.EmployeeId);
                }
            }
            if (employeeIdList.Count > 0)
            {
                this.Update(Globals.EMPLOYEE_SERVICE_NAME, "delete", new object[] { employeeIdList.ToArray()});
                QueryEmployees(activeOrganizationId);
            }
        }
    }
}
