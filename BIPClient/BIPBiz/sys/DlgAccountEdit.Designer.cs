namespace com.ccf.bip.biz.sys
{
    partial class DlgAccountEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.metroButtonCancel = new MetroFramework.Controls.MetroButton();
            this.metroButtonOK = new MetroFramework.Controls.MetroButton();
            this.是否启用 = new System.Windows.Forms.Label();
            this.metroToggleValid = new MetroFramework.Controls.MetroToggle();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.lblMsg);
            this.metroPanel1.Controls.Add(this.metroButtonCancel);
            this.metroPanel1.Controls.Add(this.metroButtonOK);
            this.metroPanel1.Controls.Add(this.是否启用);
            this.metroPanel1.Controls.Add(this.metroToggleValid);
            this.metroPanel1.Controls.Add(this.label3);
            this.metroPanel1.Controls.Add(this.txtUserPassword);
            this.metroPanel1.Controls.Add(this.label2);
            this.metroPanel1.Controls.Add(this.txtUserAccount);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.txtEmployeeName);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(330, 241);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(35, 163);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(200, 23);
            this.lblMsg.TabIndex = 46;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroButtonCancel
            // 
            this.metroButtonCancel.Location = new System.Drawing.Point(240, 202);
            this.metroButtonCancel.Name = "metroButtonCancel";
            this.metroButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.metroButtonCancel.TabIndex = 45;
            this.metroButtonCancel.Text = "取消";
            this.metroButtonCancel.UseSelectable = true;
            this.metroButtonCancel.Click += new System.EventHandler(this.metroButtonCancel_Click);
            // 
            // metroButtonOK
            // 
            this.metroButtonOK.Location = new System.Drawing.Point(146, 202);
            this.metroButtonOK.Name = "metroButtonOK";
            this.metroButtonOK.Size = new System.Drawing.Size(75, 23);
            this.metroButtonOK.TabIndex = 44;
            this.metroButtonOK.Text = "确定";
            this.metroButtonOK.UseSelectable = true;
            this.metroButtonOK.Click += new System.EventHandler(this.metroButtonOK_Click);
            // 
            // 是否启用
            // 
            this.是否启用.BackColor = System.Drawing.Color.Transparent;
            this.是否启用.Location = new System.Drawing.Point(35, 132);
            this.是否启用.Name = "是否启用";
            this.是否启用.Size = new System.Drawing.Size(62, 19);
            this.是否启用.TabIndex = 32;
            this.是否启用.Text = "是否启用";
            this.是否启用.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroToggleValid
            // 
            this.metroToggleValid.AutoSize = true;
            this.metroToggleValid.Location = new System.Drawing.Point(103, 132);
            this.metroToggleValid.Name = "metroToggleValid";
            this.metroToggleValid.Size = new System.Drawing.Size(80, 16);
            this.metroToggleValid.TabIndex = 31;
            this.metroToggleValid.Text = "Off";
            this.metroToggleValid.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(35, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 29;
            this.label3.Text = "密码";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserPassword.Location = new System.Drawing.Point(103, 94);
            this.txtUserPassword.MaxLength = 20;
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(159, 21);
            this.txtUserPassword.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(35, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "帐号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserAccount
            // 
            this.txtUserAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserAccount.Location = new System.Drawing.Point(103, 56);
            this.txtUserAccount.MaxLength = 20;
            this.txtUserAccount.Name = "txtUserAccount";
            this.txtUserAccount.Size = new System.Drawing.Size(159, 21);
            this.txtUserAccount.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(35, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "姓名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Location = new System.Drawing.Point(103, 18);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(159, 21);
            this.txtEmployeeName.TabIndex = 26;
            // 
            // DlgAccountEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(206)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(370, 321);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 321);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(370, 321);
            this.Name = "DlgAccountEdit";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "帐号设置";
            this.Load += new System.EventHandler(this.DlgAccountEdit_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label 是否启用;
        private MetroFramework.Controls.MetroToggle metroToggleValid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserAccount;
        private MetroFramework.Controls.MetroButton metroButtonCancel;
        private MetroFramework.Controls.MetroButton metroButtonOK;
        private System.Windows.Forms.Label lblMsg;
    }
}