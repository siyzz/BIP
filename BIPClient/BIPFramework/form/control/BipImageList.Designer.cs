namespace com.ccf.bip.framework.form.control
{
    partial class BipImageList
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("Choose");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTextEditor1
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ultraTextEditor1.Appearance = appearance1;
            this.ultraTextEditor1.AutoSize = false;
            this.ultraTextEditor1.BackColor = System.Drawing.Color.White;
            appearance2.ForeColor = System.Drawing.Color.Black;
            editorButton1.Appearance = appearance2;
            editorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            editorButton1.Key = "Choose";
            editorButton1.Text = "选择";
            this.ultraTextEditor1.ButtonsRight.Add(editorButton1);
            this.ultraTextEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraTextEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTextEditor1.Location = new System.Drawing.Point(0, 0);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.ReadOnly = true;
            this.ultraTextEditor1.Size = new System.Drawing.Size(224, 23);
            this.ultraTextEditor1.TabIndex = 0;
            this.ultraTextEditor1.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.ultraTextEditor1_EditorButtonClick);
            // 
            // BipImageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ultraTextEditor1);
            this.Name = "BipImageList";
            this.Size = new System.Drawing.Size(224, 23);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
    }
}
