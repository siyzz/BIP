using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using com.ccf.bip.framework.core;
using com.ccf.bip.framework.form;
using com.ccf.bip.framework.util;
using com.ccf.bip.biz.system.user.mapper;

namespace com.ccf.bip.frame
{
    public partial class FormLogin : BipForm
    {
        private Thread _loginThread;
        private bool _isLogining = false;
        private delegate void LoginDelegate(SysUser user);
        private delegate void ErrorDelegate(string msg);

        public FormLogin()
        {
            InitializeComponent();
            PaintWindow();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {            
            ReadConfig();

            OpenDevolopMode();
        }

        private void OpenDevolopMode()
        {
            this.txtAccount.Text = "admin";
            this.txtPassword.Text = "1";
            ThreadLogin();
        }

        private void PaintWindow()
        {
            this.BackgroundImage = Image.FromFile(Globals.AppPath+"\\resource\\image\\loginBackground.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.btnLogin.Image = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\loginBackground.jpg", 0, 0, 65, 38, 104, 184);
            this.btnCancel.Image = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\loginBackground.jpg", 0, 0, 65, 38, 179, 184);
        }

        private void ReadConfig()
        {
            List<ServerInfo> list = BipConfig.Load<ServerInfo>(Globals.ServerConfigName);
            ServerInfo defaultServer = list.Find(s => s.Id == 0);
            Globals.ServerList = list;
            this.Action = new BipAction();
            Action.Url = defaultServer.Url;
        }

        private void Login()
        {
            if (!_isLogining)
            {
                _isLogining = true;
                SysUser user = null;

                try
                {
                    SysUser loginUser = new SysUser();
                    loginUser.UserAccount = txtAccount.Text.Trim();
                    loginUser.UserPassword = txtPassword.Text.Trim();
                    user = this.FindOne<SysUser>("com.ccf.bip.biz.system.user.service.UserService", "login", new object[] { loginUser });
                    //Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    ErrorDelegate errDeg = new ErrorDelegate(OnError);
                    this.Invoke(errDeg, ex.Message);
                }
                LoginDelegate deg = new LoginDelegate(CompleteLogin);
                this.Invoke(deg, user);
            }
        }

        private void OnError(string msg)
        {
            //MessageBox.Show(msg);
            lblMsg.Text = msg;
        }

        private void CompleteLogin(SysUser user)
        {
            if (user != null)
            {
                User = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            timerProgress.Stop();
            progressBarLogin.Value = 0;
            _isLogining = false;
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = sender as System.Windows.Forms.Timer;
            this.progressBarLogin.Value++;
            if (this.progressBarLogin.Value == progressBarLogin.Maximum)
            {
                this.progressBarLogin.Value = 0;
                timer.Stop();
                if (_loginThread != null)
                {
                    _loginThread.Abort();
                    _isLogining = false;
                }
            }
        }

        #region 登录按钮效果控制
        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            picBox.Image = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\loginBackground.jpg", 0, 0, 65, 38, 180, 185);
        }

        private void btnCancel_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            picBox.Image = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\loginBackground.jpg", 0, 0, 65, 38, 178, 183);
        }

        private void btnCancel_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            picBox.Image = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\loginBackground.jpg", 0, 0, 65, 38, 180, 185);
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            picBox.Image = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\loginBackground.jpg", 0, 0, 65, 38, 179, 184);
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            picBox.Image = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\loginBackground.jpg", 0, 0, 65, 38, 105, 185);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            picBox.Image = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\loginBackground.jpg", 0, 0, 65, 38, 104, 184);
        }

        private void btnLogin_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            picBox.Image = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\loginBackground.jpg", 0, 0, 65, 38, 103, 183);
        }

        private void btnLogin_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            picBox.Image = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\loginBackground.jpg", 0, 0, 65, 38, 105, 185);
        }
        #endregion

        private void ThreadLogin()
        {
            if (!_isLogining)
            {
                lblMsg.Text = "";
                timerProgress.Start();
                _loginThread = new Thread(new ThreadStart(Login));
                _loginThread.Start();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ThreadLogin();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThreadLogin();
            }
        }
               
    }
}
