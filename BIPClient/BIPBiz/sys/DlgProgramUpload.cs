using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.form;
using System.Collections;
using com.ccf.bip.framework.server.file;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using com.ccf.bip.framework.util;
using com.ccf.bip.framework.core;

namespace com.ccf.bip.biz.sys
{
    public partial class DlgProgramUpload : BipMetroForm
    {
        private bool isUploading = false;
        public string[] FileNames = new string[0];
        public string UploadDirectory = "";

        public DlgProgramUpload()
        {
            InitializeComponent();
        }

        private void DlgProgramUpload_Load(object sender, EventArgs e)
        {
            foreach (string fileName in FileNames)
            {
                DataRow row = dataTable1.NewRow();
                row[0] = fileName;
                row[1] = "等待上传";
                dataTable1.Rows.Add(row);
            }
        }

        private void DlgProgramUpload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isUploading)
                e.Cancel = true;
        }

        private void metroButtonUpload_Click(object sender, EventArgs e)
        {
            isUploading = true;
            metroButtonClose.Enabled = false;

            Upload();

            isUploading = false;
            metroButtonClose.Enabled = true;
        }

        private void Upload()
        {
            com.ccf.bip.framework.server.file.FileInfo fileInfo = new com.ccf.bip.framework.server.file.FileInfo();
            fileInfo.Directory = this.UploadDirectory;
            foreach(UltraGridRow row in ultraGrid1.Rows)
            {
                string fullName = row.Cells[0].Value.ToString();
                fileInfo.Name = fullName.Substring(fullName.LastIndexOf(Path.DirectorySeparatorChar)+1);
                fileInfo.Content = FileUtil.FileToArray(fullName);
                row.Cells[1].Value = "正在上传";
                try
                {
                    this.Update(Globals.PROGRAM_UPDATE_SERVICE_NAME, "upload", new object[] { fileInfo });
                    row.Cells[1].Value = "上传成功";
                }
                catch (Exception ex)
                {
                    row.Cells[1].Value = "上传失败";
                }
            }
            metroButtonUpload.Enabled = false;
        }

        private void metroButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
