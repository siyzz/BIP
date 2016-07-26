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
using com.ccf.bip.framework.core;
using com.ccf.bip.framework.form.helper;
using com.ccf.bip.biz.system.authorization.mapper;
using Infragistics.Win.UltraWinTree;
using System.Collections;
using Infragistics.Win.UltraWinGrid;

namespace com.ccf.bip.biz.sys
{
    public partial class DlgPostEmployeeAdd : BipMetroForm
    {
        private SysPost post = null;
        public SysPost Post
        {
            get { return post; }
            set { post = value; }
        }

        public DlgPostEmployeeAdd(BipAction action)
        {
            this.Action = action;
            InitializeComponent();
        }

        private void DlgPostEmployeeAdd_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            if (post != null)
            {
                this.Text += "   [岗位:" + post.PostName +"]";
            }

            List<SysOrganization> orgList = this.FindList<SysOrganization>(Globals.ORGANIZATION_SERVICE_NAME, "findAll", new object[0]);
            UltraTreeHelper.FillData(orgList, this.ultraTree1, null, true);
        }

        private void ultraTree1_AfterActivate(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            UltraTreeNode node = ultraTree1.ActiveNode;
            if(node != null)
            {
                this.dataTable1.Clear();
                dataTable1.Merge(this.FindDataTable(Globals.EMPLOYEE_SERVICE_NAME,"recursiveSingleFindByOrgId",new object[]{node.Key}));
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (ultraGrid1.ActiveRow != null && dataTable2.Select("EMPLOYEE_ID='" + ultraGrid1.ActiveRow.Cells["EMPLOYEE_ID"].Value.ToString()+"'").Length <= 0)
            {
                dataTable2.Rows.Add(dataTable1.Rows[ultraGrid1.ActiveRow.Index].ItemArray);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (ultraGrid2.ActiveRow != null)
            {
                dataTable2.Rows.RemoveAt(ultraGrid2.ActiveRow.Index);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (ultraGrid2.Rows.Count == 0)
            {
                return;
            }
            ArrayList list = new ArrayList();
            foreach (UltraGridRow row in ultraGrid2.Rows)
            {
                SysEmployeePost sep = new SysEmployeePost();
                sep.EmployeePostId = BipGuid.Guid;
                sep.EmployeeId = row.Cells["EMPLOYEE_ID"].Value.ToString();
                sep.PostId = post.PostId;
                list.Add(sep);
            }
            this.Update(Globals.POST_SERVICE_NAME, "addEmployees", new object[] { list });
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
