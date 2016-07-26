namespace BIPTest
{
    partial class FormFile
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraTextEditor2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraTextEditor3 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraTextEditor4 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor4)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.listView1);
            this.ultraGroupBox1.Controls.Add(this.ultraButton3);
            this.ultraGroupBox1.Controls.Add(this.ultraButton1);
            this.ultraGroupBox1.Controls.Add(this.ultraTextEditor2);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel2);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(26, 19);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(299, 337);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.Text = "上传";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(100, 63);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(179, 165);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // ultraButton3
            // 
            this.ultraButton3.Location = new System.Drawing.Point(65, 63);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(20, 23);
            this.ultraButton3.TabIndex = 5;
            this.ultraButton3.Text = "+";
            this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(100, 297);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 4;
            this.ultraButton1.Text = "上传";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraTextEditor2
            // 
            this.ultraTextEditor2.Location = new System.Drawing.Point(100, 26);
            this.ultraTextEditor2.Name = "ultraTextEditor2";
            this.ultraTextEditor2.Size = new System.Drawing.Size(179, 21);
            this.ultraTextEditor2.TabIndex = 3;
            // 
            // ultraLabel2
            // 
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance6;
            this.ultraLabel2.Location = new System.Drawing.Point(6, 25);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(88, 23);
            this.ultraLabel2.TabIndex = 2;
            this.ultraLabel2.Text = "远程存储目录";
            // 
            // ultraLabel1
            // 
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 63);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(77, 23);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "选择文件";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.ultraButton2);
            this.ultraGroupBox2.Controls.Add(this.ultraTextEditor3);
            this.ultraGroupBox2.Controls.Add(this.ultraTextEditor4);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox2.Location = new System.Drawing.Point(331, 19);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(302, 337);
            this.ultraGroupBox2.TabIndex = 1;
            this.ultraGroupBox2.Text = "下载";
            // 
            // ultraButton2
            // 
            this.ultraButton2.Location = new System.Drawing.Point(126, 297);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(75, 23);
            this.ultraButton2.TabIndex = 9;
            this.ultraButton2.Text = "下载";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraTextEditor3
            // 
            this.ultraTextEditor3.Location = new System.Drawing.Point(100, 27);
            this.ultraTextEditor3.Name = "ultraTextEditor3";
            this.ultraTextEditor3.Size = new System.Drawing.Size(169, 21);
            this.ultraTextEditor3.TabIndex = 8;
            // 
            // ultraTextEditor4
            // 
            editorButton1.Text = "...";
            this.ultraTextEditor4.ButtonsRight.Add(editorButton1);
            this.ultraTextEditor4.Location = new System.Drawing.Point(100, 61);
            this.ultraTextEditor4.Name = "ultraTextEditor4";
            this.ultraTextEditor4.Size = new System.Drawing.Size(169, 21);
            this.ultraTextEditor4.TabIndex = 5;
            this.ultraTextEditor4.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.ultraTextEditor4_EditorButtonClick);
            // 
            // ultraLabel3
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance1;
            this.ultraLabel3.Location = new System.Drawing.Point(17, 63);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(77, 23);
            this.ultraLabel3.TabIndex = 7;
            this.ultraLabel3.Text = "存储目录";
            // 
            // ultraLabel4
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance2;
            this.ultraLabel4.Location = new System.Drawing.Point(17, 25);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(77, 23);
            this.ultraLabel4.TabIndex = 6;
            this.ultraLabel4.Text = "远程文件";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // FormFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 392);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "FormFile";
            this.Text = "FormFile";
            this.Load += new System.EventHandler(this.FormFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor2;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Infragistics.Win.Misc.UltraButton ultraButton3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}