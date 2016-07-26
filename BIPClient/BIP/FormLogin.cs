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
using System.Threading;
using com.ccf.bip.biz.system.user.mapper;
using com.ccf.bip.framework.util;

namespace com.ccf.bip.frame
{
    public partial class FormLogin : BipMetroForm
    {
        private Thread _loginThread;
        private bool _isLogining = false;
        private delegate void LoginDelegate(SysUser user);
        private delegate void ErrorDelegate(string msg);
        private bool lockSystem = false;//是否锁定系统
        public bool LockSystem
        {
            get { return lockSystem; }
            set { lockSystem = value; }
        }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void ThreadLogin()
        {
            if (!_isLogining)
            {
                pictureBox1.Enabled = false;
                lblMsg.Text = "";
                _loginThread = new Thread(new ThreadStart(Login));
                _loginThread.Start();
            }
        }

        private bool ValidLogin()
        {
            bool result = true;

            if (String.IsNullOrEmpty(txtAccount.Text.Trim()))
            {
                lblMsg.Text = "请输入帐号！";
                txtAccount.Focus();
                result = false;
            }
            else if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                lblMsg.Text = "请输入密码！";
                txtPassword.Focus();
                result = false;
            }

            return result;
        }

        private void FormLogin2_Load(object sender, EventArgs e)
        {
            ReadConfig();
        }

        private void ReadConfig()
        {
            List<ServerConfig> list = BipConfig.Load<ServerConfig>(Globals.ServerConfigName);
            ServerConfig defaultServer = list.Find(s => s.Id == 0);
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
                    List<Object> list = this.FindList<Object>("com.ccf.bip.biz.system.user.service.UserService", "login", new object[] { loginUser });
                    user = list[0] as SysUser;
                    Globals.Tocken = list[1].ToString();
                    //Thread.Sleep(3000);
                    LoginDelegate deg = new LoginDelegate(CompleteLogin);
                    this.Invoke(deg, user);
                }
                catch (Exception ex)
                {
                    ErrorDelegate errDeg = new ErrorDelegate(OnError);
                    this.Invoke(errDeg, ex.Message);
                }                
            }
        }

        private void OnError(string msg)
        {
            //MessageBox.Show(msg);
            lblMsg.Text = msg;
            _isLogining = false;
            pictureBox1.Enabled = true;
        }

        private void CompleteLogin(SysUser user)
        {
            if (user != null)
            {
                User = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            _isLogining = false;
            pictureBox1.Enabled = true;
        }

        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtPassword.Focus();
                    break;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if(ValidLogin())
                        ThreadLogin();
                    break;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ValidLogin())
            {
                ThreadLogin();
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("./resource/image/btn2.png");
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Image.FromFile("./resource/image/btn1.png");
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("./resource/image/btn1.png");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Image.FromFile("./resource/image/btn2.png");
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK && lockSystem)
            {
                DialogResult = DialogResult.Abort;
            }
        }
    }
}
