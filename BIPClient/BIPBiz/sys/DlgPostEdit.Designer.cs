namespace com.ccf.bip.biz.sys
{
    partial class DlgPostEdit
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPostName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPostLevel = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbtOrg = new com.ccf.bip.framework.form.control.ComboBoxTree();
            this.cbtRole = new com.ccf.bip.framework.form.control.ComboBoxTree();
            this.lblMsg = new System.Windows.Forms.Label();
            this.metroButtonOK = new MetroFramework.Controls.MetroButton();
            this.metroButtonCancel = new MetroFramework.Controls.MetroButton();
            this.cmbPostType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPostLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPostType)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(17, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "岗位类型";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPostCode
            // 
            this.txtPostCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPostCode.Location = new System.Drawing.Point(85, 20);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(103, 21);
            this.txtPostCode.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 23;
            this.label1.Text = "岗位编码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPostName
            // 
            this.txtPostName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPostName.Location = new System.Drawing.Point(312, 19);
            this.txtPostName.Name = "txtPostName";
            this.txtPostName.Size = new System.Drawing.Size(103, 21);
            this.txtPostName.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(244, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 29;
            this.label2.Text = "岗位名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPostLevel
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            appearance2.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmbPostLevel.Appearance = appearance2;
            this.cmbPostLevel.AutoSize = false;
            this.cmbPostLevel.BackColor = System.Drawing.Color.White;
            this.cmbPostLevel.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbPostLevel.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbPostLevel.Location = new System.Drawing.Point(312, 57);
            this.cmbPostLevel.Name = "cmbPostLevel";
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmbPostLevel.NullTextAppearance = appearance4;
            this.cmbPostLevel.Size = new System.Drawing.Size(103, 21);
            this.cmbPostLevel.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(244, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 31;
            this.label4.Text = "岗位级别";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(17, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 33;
            this.label5.Text = "所属组织";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(244, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 19);
            this.label6.TabIndex = 35;
            this.label6.Text = "角色";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Location = new System.Drawing.Point(85, 127);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(330, 21);
            this.txtRemark.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(17, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 37;
            this.label7.Text = "备注";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbtOrg
            // 
            this.cbtOrg.AbsoluteChildrenSelectableOnly = true;
            this.cbtOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbtOrg.BranchSeparator = ".";
            this.cbtOrg.Imagelist = null;
            this.cbtOrg.Location = new System.Drawing.Point(85, 90);
            this.cbtOrg.Name = "cbtOrg";
            this.cbtOrg.Size = new System.Drawing.Size(103, 22);
            this.cbtOrg.TabIndex = 39;
            this.cbtOrg.Value = "";
            // 
            // cbtRole
            // 
            this.cbtRole.AbsoluteChildrenSelectableOnly = true;
            this.cbtRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbtRole.BranchSeparator = ".";
            this.cbtRole.Imagelist = null;
            this.cbtRole.Location = new System.Drawing.Point(312, 90);
            this.cbtRole.Name = "cbtRole";
            this.cbtRole.Size = new System.Drawing.Size(103, 22);
            this.cbtRole.TabIndex = 40;
            this.cbtRole.Value = "";
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(17, 167);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(200, 23);
            this.lblMsg.TabIndex = 41;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroButtonOK
            // 
            this.metroButtonOK.Location = new System.Drawing.Point(246, 167);
            this.metroButtonOK.Name = "metroButtonOK";
            this.metroButtonOK.Size = new System.Drawing.Size(75, 23);
            this.metroButtonOK.TabIndex = 42;
            this.metroButtonOK.Text = "确定";
            this.metroButtonOK.UseSelectable = true;
            this.metroButtonOK.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButtonCancel
            // 
            this.metroButtonCancel.Location = new System.Drawing.Point(340, 167);
            this.metroButtonCancel.Name = "metroButtonCancel";
            this.metroButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.metroButtonCancel.TabIndex = 43;
            this.metroButtonCancel.Text = "取消";
            this.metroButtonCancel.UseSelectable = true;
            this.metroButtonCancel.Click += new System.EventHandler(this.metroButtonCancel_Click);
            // 
            // cmbPostType
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            appearance1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmbPostType.Appearance = appearance1;
            this.cmbPostType.AutoSize = false;
            this.cmbPostType.BackColor = System.Drawing.Color.White;
            this.cmbPostType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cmbPostType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbPostType.Location = new System.Drawing.Point(85, 57);
            this.cmbPostType.Name = "cmbPostType";
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmbPostType.NullTextAppearance = appearance3;
            this.cmbPostType.Size = new System.Drawing.Size(103, 21);
            this.cmbPostType.TabIndex = 44;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.cmbPostType);
            this.metroPanel1.Controls.Add(this.lblMsg);
            this.metroPanel1.Controls.Add(this.metroButtonCancel);
            this.metroPanel1.Controls.Add(this.metroButtonOK);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.txtPostCode);
            this.metroPanel1.Controls.Add(this.label3);
            this.metroPanel1.Controls.Add(this.label2);
            this.metroPanel1.Controls.Add(this.cbtRole);
            this.metroPanel1.Controls.Add(this.txtPostName);
            this.metroPanel1.Controls.Add(this.cbtOrg);
            this.metroPanel1.Controls.Add(this.label4);
            this.metroPanel1.Controls.Add(this.txtRemark);
            this.metroPanel1.Controls.Add(this.cmbPostLevel);
            this.metroPanel1.Controls.Add(this.label7);
            this.metroPanel1.Controls.Add(this.label5);
            this.metroPanel1.Controls.Add(this.label6);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(440, 200);
            this.metroPanel1.TabIndex = 45;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // DlgPostEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(206)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(480, 280);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 280);
            this.Name = "DlgPostEdit";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "岗位信息编辑";
            this.Load += new System.EventHandler(this.DlgPostEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPostLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPostType)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPostName;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPostLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label7;
        private com.ccf.bip.framework.form.control.ComboBoxTree cbtOrg;
        private com.ccf.bip.framework.form.control.ComboBoxTree cbtRole;
        private System.Windows.Forms.Label lblMsg;
        private MetroFramework.Controls.MetroButton metroButtonOK;
        private MetroFramework.Controls.MetroButton metroButtonCancel;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPostType;
        private MetroFramework.Controls.MetroPanel metroPanel1;
    }
}