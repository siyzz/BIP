namespace com.ccf.bip.biz.meta
{
    partial class DlgEmployeeEdit
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmployeeRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnOK = new Infragistics.Win.Misc.UltraButton();
            this.lblMsg = new System.Windows.Forms.Label();
            this.uosEmployeeSex = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uneEmployeeAge = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtEmployeeMail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmployeeIp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmployeePhone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmployeeAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.picEmployeePhoto = new System.Windows.Forms.PictureBox();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbtEmployeeOrg = new com.ccf.bip.framework.form.control.ComboBoxTree();
            ((System.ComponentModel.ISupportInitialize)(this.uosEmployeeSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneEmployeeAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployeePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeName.Location = new System.Drawing.Point(94, 61);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(103, 21);
            this.txtEmployeeName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "姓名：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeCode.Location = new System.Drawing.Point(94, 24);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(103, 21);
            this.txtEmployeeCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "员工编号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(26, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "所属组织：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmployeeRemark
            // 
            this.txtEmployeeRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeRemark.Location = new System.Drawing.Point(91, 283);
            this.txtEmployeeRemark.Name = "txtEmployeeRemark";
            this.txtEmployeeRemark.Size = new System.Drawing.Size(311, 21);
            this.txtEmployeeRemark.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(26, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "备注：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.Location = new System.Drawing.Point(339, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOK.Location = new System.Drawing.Point(256, 351);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确定";
            this.btnOK.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(93, 320);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(182, 23);
            this.lblMsg.TabIndex = 23;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uosEmployeeSex
            // 
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.uosEmployeeSex.Appearance = appearance4;
            this.uosEmployeeSex.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem1.DataValue = "1";
            valueListItem1.DisplayText = "男";
            valueListItem2.DataValue = "0";
            valueListItem2.DisplayText = "女";
            this.uosEmployeeSex.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.uosEmployeeSex.Location = new System.Drawing.Point(94, 135);
            this.uosEmployeeSex.Name = "uosEmployeeSex";
            this.uosEmployeeSex.Size = new System.Drawing.Size(103, 21);
            this.uosEmployeeSex.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(26, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "性别：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(26, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 26;
            this.label5.Text = "年龄：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uneEmployeeAge
            // 
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.uneEmployeeAge.Appearance = appearance5;
            this.uneEmployeeAge.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uneEmployeeAge.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.uneEmployeeAge.Location = new System.Drawing.Point(94, 172);
            this.uneEmployeeAge.MaxValue = 100;
            this.uneEmployeeAge.MinValue = 0;
            this.uneEmployeeAge.Name = "uneEmployeeAge";
            this.uneEmployeeAge.PromptChar = ' ';
            this.uneEmployeeAge.Size = new System.Drawing.Size(103, 19);
            this.uneEmployeeAge.TabIndex = 6;
            // 
            // txtEmployeeMail
            // 
            this.txtEmployeeMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeMail.Location = new System.Drawing.Point(283, 172);
            this.txtEmployeeMail.Name = "txtEmployeeMail";
            this.txtEmployeeMail.Size = new System.Drawing.Size(119, 21);
            this.txtEmployeeMail.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(218, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 19);
            this.label7.TabIndex = 28;
            this.label7.Text = "邮箱：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmployeeIp
            // 
            this.txtEmployeeIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeIp.Location = new System.Drawing.Point(94, 209);
            this.txtEmployeeIp.Name = "txtEmployeeIp";
            this.txtEmployeeIp.Size = new System.Drawing.Size(103, 21);
            this.txtEmployeeIp.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(26, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 19);
            this.label8.TabIndex = 30;
            this.label8.Text = "IP地址：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmployeePhone
            // 
            this.txtEmployeePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeePhone.Location = new System.Drawing.Point(283, 209);
            this.txtEmployeePhone.Name = "txtEmployeePhone";
            this.txtEmployeePhone.Size = new System.Drawing.Size(119, 21);
            this.txtEmployeePhone.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(218, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 19);
            this.label9.TabIndex = 32;
            this.label9.Text = "联系电话：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmployeeAddress
            // 
            this.txtEmployeeAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeAddress.Location = new System.Drawing.Point(93, 246);
            this.txtEmployeeAddress.Name = "txtEmployeeAddress";
            this.txtEmployeeAddress.Size = new System.Drawing.Size(309, 21);
            this.txtEmployeeAddress.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(26, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 19);
            this.label10.TabIndex = 34;
            this.label10.Text = "联系地址：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picEmployeePhoto
            // 
            this.picEmployeePhoto.BackColor = System.Drawing.SystemColors.Control;
            this.picEmployeePhoto.Location = new System.Drawing.Point(252, 12);
            this.picEmployeePhoto.Name = "picEmployeePhoto";
            this.picEmployeePhoto.Size = new System.Drawing.Size(106, 127);
            this.picEmployeePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEmployeePhoto.TabIndex = 36;
            this.picEmployeePhoto.TabStop = false;
            // 
            // ultraButton1
            // 
            this.ultraButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.ultraButton1.Location = new System.Drawing.Point(362, 114);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(40, 25);
            this.ultraButton1.TabIndex = 5;
            this.ultraButton1.Text = "浏览";
            this.ultraButton1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "照片|*.bmp;*.jpg;*.png;*.gif";
            // 
            // cbtEmployeeOrg
            // 
            this.cbtEmployeeOrg.AbsoluteChildrenSelectableOnly = true;
            this.cbtEmployeeOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbtEmployeeOrg.BranchSeparator = ".";
            this.cbtEmployeeOrg.Imagelist = null;
            this.cbtEmployeeOrg.Location = new System.Drawing.Point(94, 98);
            this.cbtEmployeeOrg.Name = "cbtEmployeeOrg";
            this.cbtEmployeeOrg.Size = new System.Drawing.Size(103, 22);
            this.cbtEmployeeOrg.TabIndex = 3;
            this.cbtEmployeeOrg.Value = "";
            // 
            // DlgEmployeeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(444, 392);
            this.Controls.Add(this.cbtEmployeeOrg);
            this.Controls.Add(this.ultraButton1);
            this.Controls.Add(this.picEmployeePhoto);
            this.Controls.Add(this.txtEmployeeAddress);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEmployeePhone);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEmployeeIp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEmployeeMail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.uneEmployeeAge);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uosEmployeeSex);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtEmployeeRemark);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 420);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 420);
            this.Name = "DlgEmployeeEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "员工信息编辑";
            this.Load += new System.EventHandler(this.FormEmployeeEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uosEmployeeSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneEmployeeAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployeePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmployeeRemark;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.Misc.UltraButton btnCancel;
        private Infragistics.Win.Misc.UltraButton btnOK;
        private System.Windows.Forms.Label lblMsg;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet uosEmployeeSex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneEmployeeAge;
        private System.Windows.Forms.TextBox txtEmployeeMail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmployeeIp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmployeePhone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmployeeAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox picEmployeePhoto;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private com.ccf.bip.framework.form.control.ComboBoxTree cbtEmployeeOrg;
    }
}