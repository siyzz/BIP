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

namespace com.ccf.bip.biz.sys
{
    public partial class DlgAccountEdit : BipMetroForm
    {
        private string employeeId;
        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        private string employeeName;
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        private string userAccount;
        public string UserAccount
        {
            get { return userAccount; }
            set { userAccount = value; }
        }
        private string userPassword;
        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }
        private bool userValid;
        public bool UserValid
        {
            get { return userValid; }
            set { userValid = value; }
        }

        public DlgAccountEdit(BipAction action)
        {
            this.Action = action;
            InitializeComponent();
        }

        private void metroButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DlgAccountEdit_Load(object sender, EventArgs e)
        {
            txtEmployeeName.Text = employeeName;
            txtUserAccount.Text = userAccount;
            metroToggleValid.Checked = userValid || String.IsNullOrEmpty(userAccount);
        }

        private bool ValidAccount()
        {
            bool flag = true;
            if (String.IsNullOrEmpty(txtUserAccount.Text.Trim()))
            {
                lblMsg.Text = "帐号不能为空！";
                flag = false;
            }
            else
            {
                lblMsg.Text = "";
            }
            return flag;
        }

        private void metroButtonOK_Click(object sender, EventArgs e)
        {
            if (ValidAccount())
            {
                string[] args = new string[4];
                args[0] = employeeId;
                args[1] = txtUserAccount.Text.Trim();
                args[2] = txtUserPassword.Text.Trim();
                args[3] = metroToggleValid.Checked ? "1" : "0";
                try
                {
                    this.Update(Globals.EMPLOYEE_SERVICE_NAME, "setAccount", new object[] { args });
                    this.Close();
                }
                catch (BipException ex)
                {
                    lblMsg.Text = ex.Message;
                }
            }
        }
    }
}
