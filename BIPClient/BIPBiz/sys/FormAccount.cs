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

namespace com.ccf.bip.biz.sys
{
    /// <summary>
    /// 系统帐号管理
    /// </summary>
    public partial class FormAccount : BipForm
    {
        private string activeOrganizationId = "";

        public FormAccount()
        {
            InitializeComponent();
        }

        private void FormAccount_Load(object sender, EventArgs e)
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
                case "SetAccount":
                    SetAccount(ultraGrid1.ActiveRow);
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
            DataTable dt = this.FindDataTable(Globals.EMPLOYEE_SERVICE_NAME,"findWithAccount",new object[]{orgId});
            this.dataTable1.Clear();
            dataTable1.Merge(dt);
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

        private void SetAccount(UltraGridRow row)
        {
            if (row != null)
            {
                DlgAccountEdit dlg = new DlgAccountEdit(this.Action);
                dlg.EmployeeId = row.Cells["EMPLOYEE_ID"].Value.ToString();
                dlg.EmployeeName = row.Cells["EMPLOYEE_NAME"].Value.ToString();
                dlg.UserAccount = row.Cells["USER_ACCOUNT"].Value.ToString();
                dlg.UserValid = (row.Cells["VALID"].Value != null && row.Cells["VALID"].Value.ToString().Equals("1")) ? true : false;
                dlg.ShowDialog(this);
            }
        }

        private void ultraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            UltraGridRow row = e.Row;
            SetAccount(row);
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
    }
}
