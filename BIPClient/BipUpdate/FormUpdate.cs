using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.form;
using com.ccf.bip.framework.core;
using com.ccf.bip.biz.system.update.mapper;
using com.ccf.bip.framework.util;
using com.ccf.bip.framework.server.file;
using System.IO;
using System.Threading;
using System.Diagnostics;
using MetroFramework;

namespace com.ccf.bip.udp
{
    public partial class FormUpdate : BipMetroForm
    {
        private List<FileVersion> updateVersionList;
        private List<FileVersion> remoteVersionList;
        private delegate void UpdateDelegate();
        private delegate void ShowDelegete(int value);
        private Thread updateThread;
        private bool isUpdating = false;

        public FormUpdate()
        {
            InitializeComponent();
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {            
            ReadConfig();
            //find new version
            updateVersionList = new List<FileVersion>();
            List<FileVersion> localVersionList = null;
            try
            {
                localVersionList = BipConfig.Load<FileVersion>(Globals.FileVersionConfigName);
            }
            catch (Exception ex)
            {

            }
            remoteVersionList = this.FindList<FileVersion>(Globals.PROGRAM_UPDATE_SERVICE_NAME, "findFileVersionList", new object[0]);
            //update program
            if (remoteVersionList != null)
            {
                if (localVersionList == null)
                {
                    localVersionList = new List<FileVersion>();
                }
                //排除文件路径、文件名相同且版本号小于等于当前版本的文件
                updateVersionList.AddRange(remoteVersionList.Except<FileVersion>(localVersionList, new FileVersionCompare()));
            }
            if (updateVersionList.Count > 0)
            {
                //检测主程序是否已经运行
                Process[] processesUI = Process.GetProcessesByName("BIP");
                if (processesUI.Length > 0)
                {
                    if (MetroMessageBox.Show(this, "系统有更新，是否关闭所有客户端进行更新？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (Process process in processesUI)
                        {
                            process.Kill();
                        }
                    }
                    else
                    {
                        RunBip();
                    }
                }                
            }
            else
            {
                RunBip();
            }
            updateThread = new Thread(new ThreadStart(Update));
            updateThread.Start();
        }

        private void ReadConfig()
        {
            List<ServerConfig> list = BipConfig.Load<ServerConfig>(Globals.ServerConfigName);
            ServerConfig defaultServer = list.Find(s => s.Id == 0);
            this.Action = new BipAction();
            Action.Url = defaultServer.Url;
        }

        private new void Update()
        {
            isUpdating = true;
            if (updateVersionList.Count > 0)
            {
                int step = updateVersionList.Count;
                int i = 0;
                foreach (FileVersion fileVersion in updateVersionList)
                {
                    com.ccf.bip.framework.server.file.FileInfo fileInfo = this.FindOne<com.ccf.bip.framework.server.file.FileInfo>(Globals.PROGRAM_UPDATE_SERVICE_NAME, "download", new object[] { fileVersion.GetFullName() });
                    //无法从服务器获取文件时忽略该文件更新，下次重新更新
                    if (fileInfo == null)
                    {
                        FileVersion tempVersion = remoteVersionList.Find(r=>r.GetFullName().Equals(fileVersion.GetFullName()));
                        if(tempVersion != null)
                        {
                            if(tempVersion.Version > 1)
                            {
                                tempVersion.Version = tempVersion.Version - 1;
                            }
                            else
                            {
                                remoteVersionList.Remove(tempVersion);
                            }
                        }
                        continue;
                    }
                    string fullName = Globals.AppPath + Path.DirectorySeparatorChar.ToString() + fileVersion.GetFullName();
                    string fullPath = Globals.AppPath + Path.DirectorySeparatorChar.ToString() + fileVersion.Directory;
                    if (!Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(fullPath);
                    }
                    else
                    {
                        if (File.Exists(fullName))
                        {
                            File.Delete(fullName);
                        }
                    }
                    File.WriteAllBytes(fullName, fileInfo.Content);
                    Invoke(new ShowDelegete(UpdateProgressValue), new object[] { (++i) * 100 / step < 100 ? i * 100 / step : 100 });
                    Thread.Sleep(1000);
                    //progressBar1.Value = (++i) * 100 / step < 100 ? i * 100 / step : 100;
                }
                //update version
                BipConfig.StoreObject(Globals.FileVersionConfigName, remoteVersionList);
            }
            isUpdating = false;
            //run bip
            Invoke(new UpdateDelegate(RunBip));
            
        }

        private void UpdateProgressValue(int value)
        {
            progressBar1.Value = value;
        }

        private void RunBip()
        {
            try
            {
                Process.Start(Globals.AppPath + Path.DirectorySeparatorChar + "BIP.exe");
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
            }
        }

        private void FormUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isUpdating)
                e.Cancel = true;
        }
    }
}
