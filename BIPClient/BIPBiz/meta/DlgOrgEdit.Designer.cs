namespace com.ccf.bip.biz.meta
{
    partial class DlgOrgEdit
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.txtOrgName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrgCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOrgType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOrgLeader = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnOK = new Infragistics.Win.Misc.UltraButton();
            this.lblMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrgType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrgLeader)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOrgName
            // 
            this.txtOrgName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgName.Location = new System.Drawing.Point(302, 24);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Size = new System.Drawing.Size(103, 21);
            this.txtOrgName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(234, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "组织名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOrgCode
            // 
            this.txtOrgCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgCode.Location = new System.Drawing.Point(94, 24);
            this.txtOrgCode.Name = "txtOrgCode";
            this.txtOrgCode.Size = new System.Drawing.Size(103, 21);
            this.txtOrgCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "组织编码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbOrgType
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            appearance1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmbOrgType.Appearance = appearance1;
            this.cmbOrgType.AutoSize = false;
            this.cmbOrgType.BackColor = System.Drawing.Color.White;
            this.cmbOrgType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbOrgType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbOrgType.Location = new System.Drawing.Point(94, 64);
            this.cmbOrgType.Name = "cmbOrgType";
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmbOrgType.NullTextAppearance = appearance3;
            this.cmbOrgType.Size = new System.Drawing.Size(103, 21);
            this.cmbOrgType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(26, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "组织类型";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbOrgLeader
            // 
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmbOrgLeader.Appearance = appearance2;
            this.cmbOrgLeader.AutoSize = false;
            this.cmbOrgLeader.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbOrgLeader.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbOrgLeader.Location = new System.Drawing.Point(302, 63);
            this.cmbOrgLeader.Name = "cmbOrgLeader";
            this.cmbOrgLeader.Size = new System.Drawing.Size(103, 21);
            this.cmbOrgLeader.TabIndex = 4;
            this.cmbOrgLeader.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(234, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "负责人";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(322, 104);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(120, 21);
            this.txtPhone.TabIndex = 18;
            this.txtPhone.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(254, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "电话号码";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Location = new System.Drawing.Point(94, 104);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(311, 21);
            this.txtRemark.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(26, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "备注";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.Location = new System.Drawing.Point(330, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOK.Location = new System.Drawing.Point(247, 167);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(92, 141);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(182, 23);
            this.lblMsg.TabIndex = 23;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DlgOrgEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(444, 212);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbOrgLeader);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbOrgType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOrgName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrgCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 240);
            this.Name = "DlgOrgEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "组织机构编辑";
            this.Load += new System.EventHandler(this.FormOrgEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrgType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrgLeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOrgName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrgCode;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOrgType;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOrgLeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.Misc.UltraButton btnCancel;
        private Infragistics.Win.Misc.UltraButton btnOK;
        private System.Windows.Forms.Label lblMsg;
    }
}