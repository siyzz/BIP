namespace com.ccf.bip.biz.sys
{
    partial class DlgProgramUpload
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
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Table1", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FILENAME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("STATUS");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgProgramUpload));
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroButtonUpload = new MetroFramework.Controls.MetroButton();
            this.metroButtonClose = new MetroFramework.Controls.MetroButton();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "文件名";
            this.dataColumn1.ColumnName = "FILENAME";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "状态";
            this.dataColumn2.ColumnName = "STATUS";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.ultraGrid1);
            this.metroPanel1.Controls.Add(this.metroButtonUpload);
            this.metroPanel1.Controls.Add(this.metroButtonClose);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 40);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(526, 290);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroButtonUpload
            // 
            this.metroButtonUpload.Location = new System.Drawing.Point(343, 256);
            this.metroButtonUpload.Name = "metroButtonUpload";
            this.metroButtonUpload.Size = new System.Drawing.Size(75, 23);
            this.metroButtonUpload.TabIndex = 60;
            this.metroButtonUpload.Text = "开始上传";
            this.metroButtonUpload.UseSelectable = true;
            this.metroButtonUpload.Click += new System.EventHandler(this.metroButtonUpload_Click);
            // 
            // metroButtonClose
            // 
            this.metroButtonClose.Location = new System.Drawing.Point(437, 256);
            this.metroButtonClose.Name = "metroButtonClose";
            this.metroButtonClose.Size = new System.Drawing.Size(75, 23);
            this.metroButtonClose.TabIndex = 61;
            this.metroButtonClose.Text = "关闭";
            this.metroButtonClose.UseSelectable = true;
            this.metroButtonClose.Click += new System.EventHandler(this.metroButtonClose_Click);
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DataSource = this.dataSet1;
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance10.TextVAlignAsString = "Middle";
            this.ultraGrid1.DisplayLayout.Appearance = appearance10;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(426, 0);
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(97, 0);
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout;
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.WindowsVista;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance18;
            this.ultraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            appearance19.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance19.ForeColor = System.Drawing.SystemColors.ControlText;
            appearance19.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance19;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsVista;
            this.ultraGrid1.DisplayLayout.Override.MinRowHeight = 21;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(255)))), ((int)(((byte)(229)))));
            this.ultraGrid1.DisplayLayout.Override.RowAlternateAppearance = appearance20;
            appearance21.BorderColor = System.Drawing.Color.DarkGray;
            appearance21.TextVAlignAsString = "Middle";
            this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance21;
            this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance22.BackColor = System.Drawing.Color.LightSkyBlue;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ultraGrid1.DisplayLayout.Override.SpecialRowSeparatorAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.LightYellow;
            appearance24.ForeColor = System.Drawing.Color.Blue;
            this.ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
            this.ultraGrid1.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            this.ultraGrid1.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ultraGrid1.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(526, 250);
            this.ultraGrid1.TabIndex = 62;
            // 
            // DlgProgramUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(206)))), ((int)(((byte)(228)))));
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.BackImagePadding = new System.Windows.Forms.Padding(3, 7, 0, 0);
            this.BackMaxSize = 16;
            this.ClientSize = new System.Drawing.Size(566, 350);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(566, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(566, 350);
            this.Name = "DlgProgramUpload";
            this.Padding = new System.Windows.Forms.Padding(20, 40, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "   文件上传";
            this.Load += new System.EventHandler(this.DlgProgramUpload_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgProgramUpload_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton metroButtonUpload;
        private MetroFramework.Controls.MetroButton metroButtonClose;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;


    }
}