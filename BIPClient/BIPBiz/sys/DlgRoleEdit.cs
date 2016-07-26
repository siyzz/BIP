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
using com.ccf.bip.framework.server;
using com.ccf.bip.biz.system.authorization.mapper;
using MetroFramework.Forms;

namespace com.ccf.bip.biz.sys
{
    public partial class DlgRoleEdit : BipMetroForm
    {
        private const string SERVICE_NAME = "com.ccf.bip.biz.system.authorization.service.RoleService";
        private SysRole _role;
        public SysRole Role
        {
            get { return _role; }
            set { _role = value; }
        }

        private EditType _type;
        internal EditType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public DlgRoleEdit(SysRole role,EditType type)
        {
            _type = type;
            _role = role;
            InitializeComponent();
        }

        public DlgRoleEdit(SysRole role, EditType type, BipAction action)
            : this(role,type)
        {
            this.Action = action;
        }

        private void FormOrgEdit_Load(object sender, EventArgs e)
        {
            if (_role != null && _type == EditType.Update)
            {
                txtRoleName.Text = _role.RoleName;
                txtRemark.Text = _role.Remark;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            SysRole role = null;
            switch (_type)
            {
                case EditType.AddRoot:
                case EditType.AddChild:
                    role = new SysRole();
                    role.RoleId = BipGuid.Guid;
                    role.RoleName = txtRoleName.Text.Trim();
                    role.Remark = txtRemark.Text.Trim();
                    role.ParentId = _role != null ? _role.RoleId : null;
                    this.Update(SERVICE_NAME, "add", new object[] { role });
                    this.Role = role;
                    break;
                case EditType.Update:
                    role = _role;
                    role.RoleName = txtRoleName.Text.Trim();
                    role.Remark = txtRemark.Text.Trim();
                    this.Update(SERVICE_NAME, "update", new object[] { role });
                    break;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            bool ret = false;
            if (String.IsNullOrEmpty(txtRoleName.Text.Trim()))
            {
                lblMsg.Text = "角色名称不能为空！";
            }
            else
            {
                lblMsg.Text = "";
                ret = true;
            }
            return ret;
        }
    }
}
