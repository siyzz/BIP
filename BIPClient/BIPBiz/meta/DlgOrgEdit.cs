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
using com.ccf.bip.biz.metadata.dictionary.mapper;
using com.ccf.bip.framework.server;
using MetroFramework.Forms;

namespace com.ccf.bip.biz.meta
{
    public partial class DlgOrgEdit : BipMetroForm
    {
        public const string SERVICE_NAME = "com.ccf.bip.biz.metadata.org.service.OrganizationService";
        private SysOrganization _org;
        public SysOrganization Organization
        {
            get { return _org; }
            set { _org = value; }
        }

        private EditType _type;
        internal EditType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public DlgOrgEdit(SysOrganization organization,EditType type)
        {
            _type = type;
            _org = organization;
            InitializeComponent();
        }

        public DlgOrgEdit(SysOrganization organization,EditType type, BipAction action)
            : this(organization,type)
        {
            this.Action = action;
        }

        private void FormOrgEdit_Load(object sender, EventArgs e)
        {
            InitControl();

            if (_org != null && _type == EditType.Update)
            {
                txtOrgCode.Text = _org.OrganizationCode;
                txtOrgName.Text = _org.OrganizationName;
                //txtPhone.Text = _org.OrganizationPhone;
                txtRemark.Text = _org.Remark;
                //cmbOrgLeader.Value = _org.OrganizationLeader;
                cmbOrgType.Value = _org.OrganizationType;
            }
        }

        private void InitControl()
        {
            List<SysDictionary> dicList = new Dictionary(Action).GetOrganizationType();
            cmbOrgType.Items.Clear();
            foreach (SysDictionary dic in dicList)
            {
                cmbOrgType.Items.Add(dic.DictionaryCode, dic.DictionaryName);
            }

            //if (_org != null)
            //{
                
            //}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            SysOrganization org = null;
            switch (_type)
            {
                case EditType.AddRoot:
                case EditType.AddChild:
                    org = new SysOrganization();
                    org.OrganizationId = BipGuid.Guid;
                    org.OrganizationCode = txtOrgCode.Text.Trim();
                    org.OrganizationName = txtOrgName.Text.Trim();
                    org.OrganizationType = cmbOrgType.Value.ToString();
                    org.Remark = txtRemark.Text.Trim();
                    org.ParentId = _org != null ? _org.OrganizationId : null;
                    this.Update(SERVICE_NAME, "add", new object[] { org });
                    this.Organization = org;
                    break;
                case EditType.Update:
                    org = _org;
                    org.OrganizationCode = txtOrgCode.Text.Trim();
                    org.OrganizationName = txtOrgName.Text.Trim();
                    org.OrganizationType = cmbOrgType.Value.ToString();
                    org.Remark = txtRemark.Text.Trim();
                    this.Update(SERVICE_NAME, "update", new object[] { org });
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
            if (String.IsNullOrEmpty(txtOrgCode.Text.Trim()))
            {
                lblMsg.Text = "组织编码不能为空！";
            }
            else if (cmbOrgType.SelectedIndex < 0)
            {
                lblMsg.Text = "组织类型不能为空！";
            }
            else if (String.IsNullOrEmpty(txtOrgName.Text.Trim()))
            {
                lblMsg.Text = "组织名称不能为空！";
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
