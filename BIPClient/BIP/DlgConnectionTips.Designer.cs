namespace com.ccf.bip.frame
{
    partial class DlgConnectionTips
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
            this.bipTableView1 = new com.ccf.bip.framework.form.control.BipTableView();
            this.SuspendLayout();
            // 
            // bipTableView1
            // 
            this.bipTableView1.ActiveRow = null;
            this.bipTableView1.AutoScroll = true;
            this.bipTableView1.BackColor = System.Drawing.Color.Transparent;
            this.bipTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bipTableView1.Location = new System.Drawing.Point(0, 0);
            this.bipTableView1.Name = "bipTableView1";
            this.bipTableView1.Size = new System.Drawing.Size(360, 241);
            this.bipTableView1.TabIndex = 0;
            // 
            // DlgConnectionTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 241);
            this.Controls.Add(this.bipTableView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DlgConnectionTips";
            this.ShowInTaskbar = false;
            this.Text = "DlgConnectionTips";
            this.Load += new System.EventHandler(this.DlgConnectionTips_Load);
            this.VisibleChanged += new System.EventHandler(this.DlgConnectionTips_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private com.ccf.bip.framework.form.control.BipTableView bipTableView1;

    }
}