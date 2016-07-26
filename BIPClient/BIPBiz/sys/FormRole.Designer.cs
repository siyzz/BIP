namespace com.ccf.bip.biz.sys
{
    partial class FormRole
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override2 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override3 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRole));
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraTreeRole = new Infragistics.Win.UltraWinTree.UltraTree();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAddSub = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraGroupbox4 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraTreeAuthor = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraTreeFunction = new Infragistics.Win.UltraWinTree.UltraTree();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTreeRole)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupbox4)).BeginInit();
            this.ultraGroupbox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTreeAuthor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTreeFunction)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraTreeRole);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(236, 510);
            this.ultraGroupBox1.TabIndex = 1;
            this.ultraGroupBox1.Text = "角色列表";
            // 
            // ultraTreeRole
            // 
            this.ultraTreeRole.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraTreeRole.ContextMenuStrip = this.contextMenuStrip1;
            this.ultraTreeRole.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.WindowsVista;
            this.ultraTreeRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTreeRole.HideExpansionIndicators = Infragistics.Win.UltraWinTree.HideExpansionIndicators.Never;
            this.ultraTreeRole.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraTreeRole.Location = new System.Drawing.Point(3, 18);
            this.ultraTreeRole.Name = "ultraTreeRole";
            this.ultraTreeRole.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            appearance1.BackColor = System.Drawing.Color.LightBlue;
            _override1.ActiveNodeAppearance = appearance1;
            this.ultraTreeRole.Override = _override1;
            this.ultraTreeRole.Size = new System.Drawing.Size(230, 489);
            this.ultraTreeRole.TabIndex = 0;
            this.ultraTreeRole.AfterActivate += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.ultraTreeRole_AfterActivate);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddRoot,
            this.toolStripSeparator1,
            this.toolStripMenuItemAddSub,
            this.toolStripMenuItemUpdate,
            this.toolStripMenuItemDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 98);
            // 
            // toolStripMenuItemAddRoot
            // 
            this.toolStripMenuItemAddRoot.Image = global::com.ccf.bip.biz.ResourceImg.addRoot;
            this.toolStripMenuItemAddRoot.Name = "toolStripMenuItemAddRoot";
            this.toolStripMenuItemAddRoot.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItemAddRoot.Text = "新增角色";
            this.toolStripMenuItemAddRoot.Click += new System.EventHandler(this.toolStripMenuItemAddRoot_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // toolStripMenuItemAddSub
            // 
            this.toolStripMenuItemAddSub.Image = global::com.ccf.bip.biz.ResourceImg.addSub;
            this.toolStripMenuItemAddSub.Name = "toolStripMenuItemAddSub";
            this.toolStripMenuItemAddSub.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItemAddSub.Text = "新增子角色";
            this.toolStripMenuItemAddSub.Click += new System.EventHandler(this.toolStripMenuItemAddSub_Click);
            // 
            // toolStripMenuItemUpdate
            // 
            this.toolStripMenuItemUpdate.Image = global::com.ccf.bip.biz.ResourceImg.edit;
            this.toolStripMenuItemUpdate.Name = "toolStripMenuItemUpdate";
            this.toolStripMenuItemUpdate.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItemUpdate.Text = "修改";
            this.toolStripMenuItemUpdate.Click += new System.EventHandler(this.toolStripMenuItemUpdate_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Image = global::com.ccf.bip.biz.ResourceImg.delete;
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItemDelete.Text = "删除";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.tableLayoutPanel1);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.Location = new System.Drawing.Point(236, 0);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(743, 510);
            this.ultraGroupBox2.TabIndex = 2;
            this.ultraGroupBox2.Text = "功能授权";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ultraGroupbox4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ultraGroupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(737, 489);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ultraGroupbox4
            // 
            this.ultraGroupbox4.Controls.Add(this.ultraTreeAuthor);
            this.ultraGroupbox4.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(206)))), ((int)(((byte)(228)))));
            this.ultraGroupbox4.HeaderAppearance = appearance5;
            this.ultraGroupbox4.Location = new System.Drawing.Point(401, 3);
            this.ultraGroupbox4.Name = "ultraGroupbox4";
            this.ultraGroupbox4.Size = new System.Drawing.Size(333, 483);
            this.ultraGroupbox4.TabIndex = 2;
            this.ultraGroupbox4.Text = "角色功能";
            this.ultraGroupbox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraTreeAuthor
            // 
            this.ultraTreeAuthor.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraTreeAuthor.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.WindowsVista;
            this.ultraTreeAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTreeAuthor.HideExpansionIndicators = Infragistics.Win.UltraWinTree.HideExpansionIndicators.Never;
            this.ultraTreeAuthor.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraTreeAuthor.Location = new System.Drawing.Point(3, 18);
            this.ultraTreeAuthor.Name = "ultraTreeAuthor";
            this.ultraTreeAuthor.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            appearance15.BackColor = System.Drawing.Color.LightBlue;
            _override2.ActiveNodeAppearance = appearance15;
            this.ultraTreeAuthor.Override = _override2;
            this.ultraTreeAuthor.Size = new System.Drawing.Size(327, 462);
            this.ultraTreeAuthor.TabIndex = 2;
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.ultraTreeFunction);
            this.ultraGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(206)))), ((int)(((byte)(228)))));
            this.ultraGroupBox3.HeaderAppearance = appearance4;
            this.ultraGroupBox3.Location = new System.Drawing.Point(3, 3);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(332, 483);
            this.ultraGroupBox3.TabIndex = 0;
            this.ultraGroupBox3.Text = "系统功能";
            this.ultraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraTreeFunction
            // 
            this.ultraTreeFunction.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraTreeFunction.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.WindowsVista;
            this.ultraTreeFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTreeFunction.HideExpansionIndicators = Infragistics.Win.UltraWinTree.HideExpansionIndicators.Never;
            this.ultraTreeFunction.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraTreeFunction.Location = new System.Drawing.Point(3, 18);
            this.ultraTreeFunction.Name = "ultraTreeFunction";
            this.ultraTreeFunction.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            appearance3.BackColor = System.Drawing.Color.LightBlue;
            _override3.ActiveNodeAppearance = appearance3;
            this.ultraTreeFunction.Override = _override3;
            this.ultraTreeFunction.Size = new System.Drawing.Size(326, 462);
            this.ultraTreeFunction.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.metroButton4);
            this.panel1.Controls.Add(this.metroButton3);
            this.panel1.Controls.Add(this.metroButton2);
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(341, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(54, 483);
            this.panel1.TabIndex = 3;
            // 
            // metroButton1
            // 
            this.metroButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroButton1.BackgroundImage")));
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButton1.Location = new System.Drawing.Point(6, 97);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(43, 27);
            this.metroButton1.TabIndex = 7;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroButton2.BackgroundImage")));
            this.metroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButton2.Location = new System.Drawing.Point(6, 173);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(43, 27);
            this.metroButton2.TabIndex = 8;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.button2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroButton3.BackgroundImage")));
            this.metroButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButton3.Location = new System.Drawing.Point(6, 206);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(43, 27);
            this.metroButton3.TabIndex = 9;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.button3_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroButton4.BackgroundImage")));
            this.metroButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroButton4.Location = new System.Drawing.Point(6, 278);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(43, 27);
            this.metroButton4.TabIndex = 10;
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 510);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "FormRole";
            this.Text = "FormRole";
            this.Load += new System.EventHandler(this.FormRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTreeRole)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupbox4)).EndInit();
            this.ultraGroupbox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTreeAuthor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTreeFunction)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinTree.UltraTree ultraTreeRole;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddRoot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddSub;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupbox4;
        private Infragistics.Win.UltraWinTree.UltraTree ultraTreeAuthor;
        private Infragistics.Win.UltraWinTree.UltraTree ultraTreeFunction;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton3;
    }
}