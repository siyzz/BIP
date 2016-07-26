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
using com.ccf.bip.framework.form.helper;
using com.ccf.bip.framework.core;
using Infragistics.Win.UltraWinTree;
using com.ccf.bip.biz.system.authorization.mapper;
using Infragistics.Win.UltraWinGrid;
using com.ccf.bip.biz.metadata.employee.mapper;
using System.Collections;
using MetroFramework;

namespace com.ccf.bip.biz.sys
{
    public partial class FormPost : BipForm
    {
        public FormPost()
        {
            InitializeComponent();
        }

        public override void ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Refresh":
                    Refresh();
                    break;
                case "Add":
                    Add();
                    break;
                case "Update":
                    Update();
                    break;
                case "Delete":
                    Delete();
                    break;
            }
        }

        private new void Refresh()
        {
            IEnumerable<SysOrganization> enums = this.Find<SysOrganization>(Globals.ORGANIZATION_SERVICE_NAME, "findAll", new object[0]);
            List<SysOrganization> orgList = new List<SysOrganization>();
            orgList.AddRange(enums);
            UltraTreeHelper.FillData(orgList, this.ultraTree1, null, true);
        }

        private void Add()
        {
            UltraTreeNode node = ultraTree1.ActiveNode;
            if(node == null)
            {
                MetroMessageBox.Show(this,"请选择需要新增岗位的组织机构！");
                return;
            }
            SysPost post = new SysPost();
            post.PostOrgId = (node.Tag as SysOrganization).OrganizationId;
            DlgPostEdit dlg = new DlgPostEdit(post, EditType.Add, this.Action);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                QueryPost(post.PostOrgId);
            }
        }

        private new void Update()
        {
            UltraGridRow row = ultraGrid1.ActiveRow;
            if (row == null)
            {
                MetroMessageBox.Show(this,"请选择需要修改的岗位！");
                return;
            }
            SysPost post = row.ListObject as SysPost;
            string orgId = post.PostOrgId;
            DlgPostEdit dlg = new DlgPostEdit(post, EditType.Update, this.Action);
            if (dlg.ShowDialog(this) == DialogResult.OK)
                QueryPost(orgId);
        }

        private void Delete()
        {
            UltraGridRow row = ultraGrid1.ActiveRow;
            if (row == null)
            {
                MetroMessageBox.Show(this,"请选择需要修改的岗位！");
                return;
            }
            SysPost post = row.ListObject as SysPost;
            string orgId = post.PostOrgId;
            if (MetroMessageBox.Show(this,"是否确定删除岗位" + post.PostName + "？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Update(Globals.POST_SERVICE_NAME, "delete", new object[] { post.PostId });
                QueryPost(orgId);
            }
        }

        private void FormPost_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void ultraTree1_AfterActivate(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            UltraTree tree = sender as UltraTree;
            if (tree.ActiveNode != null)
            {
                QueryPost((tree.ActiveNode.Tag as SysOrganization).OrganizationId);
            }
        }

        private void QueryPost(string organizationId)
        {
            this.sysPostBindingSource.DataSource = this.FindList<SysPost>(Globals.POST_SERVICE_NAME, "findByOrganizationId", new object[] { organizationId });
        }

        private void ultraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (this.ToolbarButtonList.Find(o => o.Key.Equals("Update")) != null)
            {
                Update();
            }
        }

        private void ultraGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            string postId = ((sender as UltraGrid).ActiveRow.ListObject as SysPost).PostId;
            dataTable1.Clear();
            dataTable1.Merge(this.FindDataTable(Globals.EMPLOYEE_SERVICE_NAME, "findByPostId", new object[] { postId }));
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Add":
                    if (ultraGrid1.ActiveRow != null)
                    {
                        DlgPostEmployeeAdd dlg = new DlgPostEmployeeAdd(this.Action);
                        dlg.Post = ultraGrid1.ActiveRow.ListObject as SysPost;
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            ultraGrid1_AfterRowActivate(ultraGrid1, new EventArgs());
                        }
                    }
                    break;
                case "Remove":
                    if(ultraGrid1.ActiveRow != null)
                    {
                        ultraGrid2.UpdateData();
                        string postId = (ultraGrid1.ActiveRow.ListObject as SysPost).PostId;
                        ArrayList list = new ArrayList();
                        foreach(UltraGridRow row in ultraGrid2.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["CHK"].Value))
                            {
                                SysEmployeePost sep = new SysEmployeePost();
                                sep.PostId = postId;
                                sep.EmployeeId = row.Cells["EMPLOYEE_ID"].Value.ToString();
                                list.Add(sep);
                            }
                        }
                        if (list.Count > 0)
                        {
                            this.Update(Globals.POST_SERVICE_NAME, "removeEmployees", new object[] { list });
                            ultraGrid1_AfterRowActivate(ultraGrid1, new EventArgs());
                        }
                    }
                    break;
            }
        }
    }
}
