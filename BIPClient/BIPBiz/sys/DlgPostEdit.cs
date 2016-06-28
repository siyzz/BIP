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
using com.ccf.bip.framework.core;
using com.ccf.bip.biz.metadata.org.mapper;

namespace com.ccf.bip.biz.sys
{
    public partial class DlgPostEdit : BipForm
    {
        private SysPost _post;
        public SysPost Post
        {
            get { return _post; }
            set { _post = value; }
        }

        private EditType type;
        public EditType Type
        {
            get { return type; }
            set { type = value; }
        }

        public DlgPostEdit(SysPost post,EditType type)
        {
            InitializeComponent();
            this._post = post;
            this.type = type;
        }

        public DlgPostEdit(SysPost post, EditType type, BipAction action) : this(post,type)
        {
            this.Action = action;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            SysPost post = null;
            switch (type)
            {
                case EditType.Add:
                    post = new SysPost();
                    post.PostId = BipGuid.Guid;
                    post.PostName = txtPostName.Text.Trim();
                    post.PostCode = txtPostCode.Text.Trim();
                    post.PostLevel = cmbPostLevel.Text;
                    post.PostType = cmbPostType.Text;
                    post.Remark = txtRemark.Text;
                    post.PostOrgId = cbtOrg.Value;
                    post.RoleId = cbtRole.Value;
                    this.Update(Globals.POST_SERVICE_NAME, "add", new object[] { post });
                    break;
                case EditType.Update:
                    post = _post;
                    post.PostName = txtPostName.Text.Trim();
                    post.PostCode = txtPostCode.Text.Trim();
                    post.PostLevel = cmbPostLevel.Text;
                    post.PostType = cmbPostType.Text;
                    post.Remark = txtRemark.Text;
                    post.PostOrgId = cbtOrg.Value;
                    post.RoleId = cbtRole.Value;
                    this.Update(Globals.POST_SERVICE_NAME, "update", new object[] { post });
                    break;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateInput()
        {
            bool ret = false;
            if (String.IsNullOrEmpty(txtPostCode.Text.Trim()))
            {
                lblMsg.Text = "岗位编码不能为空！";
            }
            else if (String.IsNullOrEmpty(txtPostName.Text.Trim()))
            {
                lblMsg.Text = "岗位名称不能为空！";
            }
            else if (String.IsNullOrEmpty(cbtRole.Value))
            {
                lblMsg.Text = "请选择角色！";
            }
            else if (String.IsNullOrEmpty(cbtOrg.Value))
            {
                lblMsg.Text = "请选择所在组织！";
            }
            else
            {
                lblMsg.Text = "";
                ret = true;
            }
            return ret;
        }

        private void DlgPostEdit_Load(object sender, EventArgs e)
        {
            InitControl();
            if (_post != null)
            {
                switch (type)
                {
                    case EditType.Add:
                        this.cbtOrg.Value = _post.PostOrgId;
                        this.cbtOrg.Enabled = false;
                        break;
                    case EditType.Update:
                        this.txtPostCode.Text = _post.PostCode;
                        this.txtPostName.Text = _post.PostName;
                        this.txtRemark.Text = _post.Remark;
                        this.cmbPostLevel.Text = _post.PostLevel;
                        this.cmbPostType.Text = _post.PostType;
                        this.cbtOrg.Value = _post.PostOrgId;
                        this.cbtRole.Value = _post.RoleId;
                        break;
                }
            }
        }

        private void InitControl()
        {
            List<SysOrganization> orgList = this.FindList<SysOrganization>(Globals.ORGANIZATION_SERVICE_NAME, "findAll", new object[0]);
            FillData(orgList, cbtOrg.Nodes);
            List<SysRole> roleList = this.FindList<SysRole>(Globals.ROLE_SERVICE_NAME, "findAll", new object[0]);
            FillData(roleList, cbtRole.Nodes);
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

        private void FillData(List<SysRole> list, TreeNodeCollection nodes)
        {
            TreeNode node = null;
            nodes.Clear();

            //获取角色根节点
            List<SysRole> roleList = list.FindAll(r => string.IsNullOrEmpty(r.ParentId));
            foreach (SysRole role in roleList)
            {
                node = new TreeNode();
                node.Name = role.RoleId;
                node.Text = role.RoleName;
                nodes.Add(node);

                FillData(list, node);
            }
        }

        private void FillData(List<SysRole> list, TreeNode node)
        {
            TreeNode subNode = null;
            List<SysRole> roleList = list.FindAll(r => !string.IsNullOrEmpty(r.ParentId) && r.ParentId.Equals(node.Name));
            foreach (SysRole role in roleList)
            {
                subNode = new TreeNode();
                subNode.Name = role.RoleId;
                subNode.Text = role.RoleName;
                node.Nodes.Add(subNode);

                FillData(list, subNode);
            }
        }
    }
}
