using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.frame.style;
using com.ccf.bip.framework.form;
using MetroFramework.Controls;
using Infragistics.Win.UltraWinEditors;
using System.Collections;
using com.ccf.bip.biz.system.user.mapper;
using com.ccf.bip.framework.util;
using com.ccf.bip.framework.core;
using MetroFramework;
using System.Text.RegularExpressions;
using com.ccf.bip.framework.form.control;
using com.ccf.bip.biz.system.authorization.mapper;
using com.ccf.bip.biz.system.monitor.mapper;

namespace com.ccf.bip.frame
{
    public partial class DlgSettings : BipMetroForm
    {
        private MetroLabel previousActiveLabel;
        private Hashtable settings;
        private SysUser user;
        public SysUser User
        {
            get { return user; }
            set { user = value; }
        }

        private int activeIndex = 0;
        public int ActiveIndex
        {
            get { return activeIndex; }
            set { activeIndex = value; }
        }


        public DlgSettings()
        {
            InitializeComponent();
        }

        private void metroLabel_Click(object sender, EventArgs e)
        {
            MetroPanel activePanel = null;
            MetroLabel lbl = sender as MetroLabel;
            if (lbl != previousActiveLabel)
            {
                previousActiveLabel.BackColor = Color.FromArgb(171, 206, 228);
                lbl.BackColor = Color.FromArgb(255, 255, 255);
                switch (lbl.Name)
                {
                    case "metroLabel1":
                        activePanel = metroPanelBase;
                        break;
                    case "metroLabel2":
                        activePanel = metroPanelServer;
                        break;
                    case "metroLabel3":
                        activePanel = metroPanelHotKey;
                        break;
                    case "metroLabel4":
                        activePanel = metroPanelAccount;
                        break;
                    case "metroLabel5":
                        activePanel = metroPanelOther;
                        break;
                }
                if (activePanel != null)
                {
                    activePanel.BringToFront();
                }
                previousActiveLabel = lbl;
            }
        }

        #region FormLoad
        private void DlgSettings_Load(object sender, EventArgs e)
        {
            previousActiveLabel = metroLabel1;
            metroPanelBase.BringToFront();

            settings = BipConfig.LoadObject<Hashtable>(Globals.SettingConfigName);

            ParseSettings();

            MetroLabel lbl = null;
            switch (activeIndex)
            {
                case 1:
                    lbl = metroLabel2;
                    break;
                case 2:
                    lbl = metroLabel3;
                    break;
                case 3:
                    lbl = metroLabel4;
                    break;
                case 4:
                    lbl = metroLabel5;
                    break;
                default:
                    lbl = metroLabel1;
                    break;
            }
            metroLabel_Click(lbl,new EventArgs());
        }

        private void ParseSettings()
        {
            if (settings != null && settings.Count > 0)
            {
                string baseSettinStr = settings["base"].ToString();
                Hashtable htBase = JSONUtil.Parse<Hashtable>(baseSettinStr);
                metroToggleHisFlag.Checked = htBase["hisFlag"].ToString().Equals("1");
                numericUpDownHisNum.Enabled = metroToggleHisFlag.Checked;
                numericUpDownHisNum.Value = Convert.ToDecimal(htBase["hisNum"].ToString());
                metroButtonClearHis.Enabled = metroToggleHisFlag.Checked && numericUpDownHisNum.Value > 0;
                metroToggleHisFlag.CheckedChanged += new EventHandler(metroToggleHisFlag_CheckedChanged);
                numericUpDownHisNum.ValueChanged +=new EventHandler(numericUpDownHisNum_ValueChanged);

                List<ServerConfig> srvList = BipConfig.Load<ServerConfig>(Globals.ServerConfigName);
                ServerConfig defaultServer = srvList.Find(s => s.Id == 0);
                String[] srvAddrs = defaultServer.Url.Split(new char[] {'/' });
                String[] ip_port = srvAddrs[2].Split(new char[] { ':' });
                String[] ips = ip_port[0].Split(new char[] { '.' });
                ultraTextEditor16.Text = ips[0];
                ultraTextEditor17.Text = ips[1];
                ultraTextEditor18.Text = ips[2];
                ultraTextEditor19.Text = ips[3];
                ultraTextEditor20.Text = ip_port[1];
                ultraTextEditor1.Text = srvAddrs[3];
                metroButtonSrvApply.Enabled = false;

                string hotkeyStr = settings["hotkey"].ToString();
                List<Hashtable> hotkeyList = JSONUtil.Parse<List<Hashtable>>(hotkeyStr);
                
                UltraTextEditor textEditor = null;
                foreach (Hashtable ht in hotkeyList)
                {
                    switch (ht["key"].ToString())
                    {
                        case "relogin":
                            textEditor = uteHkRelogin;
                            break;
                        case "lock":
                            textEditor = uteHkLock;
                            break;
                        case "fun1":
                            textEditor = uteHkFun1;
                            break;
                        case "fun2":
                            textEditor = uteHkFun2;
                            break;
                        case "fun3":
                            textEditor = uteHkFun3;
                            break;
                        case "fun4":
                            textEditor = uteHkFun4;
                            break;
                        case "fun5":
                            textEditor = uteHkFun5;
                            break;
                        case "fun6":
                            textEditor = uteHkFun6;
                            break;
                        case "fun7":
                            textEditor = uteHkFun7;
                            break;
                        case "fun8":
                            textEditor = uteHkFun8;
                            break;
                    }
                    if (textEditor != null)
                    {
                        char[] htValues = ht["value"].ToString().ToCharArray();

                        textEditor.Value = ((htValues[0] == '1') ? "Ctrl + " : "") + ((htValues[1] == '1') ? "Shift + " : "") + ((htValues[2] == '1') ? "Alt + " : "") + htValues[3].ToString().ToUpper();
                    }
                }
                metroButtonHkApply.Enabled = false;


                ultraTextEditor12.Text = user.Employee.EmployeeName;

                //BipRow row = new BipRow();
                //row.IsHeader = true;
                //row.Add(new BipCell() { Text = "系统名称", Width = 100 });
                //row.Add(new BipCell() { Text = "服务器" });
                //row.Add(new BipCell() { Text = "应用服务" });
                //row.Add(new BipCell() { Text = "数据库" });
                //bipTableView1.AddRow(row);
                //bipTableView1.Padding = new Padding(20, 10, 20, 10);
            }
        }
        #endregion

        private void ultraTextEditorHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            string key = Convert.ToChar(e.KeyCode).ToString().ToUpper();
            if (!Regex.IsMatch(key, "[0-9A-Z]{1}"))
            {
                return;
            }
            if (e.Alt || e.Control || e.Shift)
            {
                (sender as UltraTextEditor).Text = (e.Control ? "Ctrl + " : "") + (e.Shift ? "Shift + " : "") + (e.Alt ? "Alt + " : "") + key;
            }
            else
            {
                (sender as UltraTextEditor).Text = "Alt + " + key;
            }
            e.Handled = true;
        }

        private void ultraTextEditorHotKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void metroButtonBaseApply_Click(object sender, EventArgs e)
        {
            Hashtable htBase = JSONUtil.Parse<Hashtable>(settings["base"].ToString());
            htBase["hisFlag"] = metroToggleHisFlag.Checked ? "1" : "0";
            htBase["hisNum"] = numericUpDownHisNum.Value;
            settings["base"] = JSONUtil.ToJson(htBase);
            BipConfig.StoreObject(Globals.SettingConfigName, settings);
            metroButtonBaseApply.Enabled = false;
        }

        private void metroButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButtonClearHis_Click(object sender, EventArgs e)
        {
            Hashtable htBase = JSONUtil.Parse<Hashtable>(settings["base"].ToString());
            htBase["history"] = "";
            settings["base"] = JSONUtil.ToJson(htBase);
            BipConfig.StoreObject(Globals.SettingConfigName, settings);
            metroButtonClearHis.Enabled = false;
            //MetroMessageBox.Show(this,"清空完成！");
        }

        private void metroToggleHisFlag_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownHisNum.Enabled = metroToggleHisFlag.Checked;
            if (!metroButtonBaseApply.Enabled)
                metroButtonBaseApply.Enabled = true;            
        }

        private void numericUpDownHisNum_ValueChanged(object sender, EventArgs e)
        {
            if (!metroButtonBaseApply.Enabled)
                metroButtonBaseApply.Enabled = true;
        }

        private void ultraTextEditorServer_ValueChanged(object sender, EventArgs e)
        {
            if (!metroButtonSrvApply.Enabled)
                metroButtonSrvApply.Enabled = true;
        }

        private void metroButtonSrvApply_Click(object sender, EventArgs e)
        {
            string ip = ultraTextEditor16.Text.Trim() + "." + ultraTextEditor17.Text.Trim() + "." + ultraTextEditor18.Text.Trim() + "." + ultraTextEditor19.Text.Trim();
            if (String.IsNullOrEmpty(ultraTextEditor16.Text.Trim()) || String.IsNullOrEmpty(ultraTextEditor17.Text.Trim()) || String.IsNullOrEmpty(ultraTextEditor18.Text.Trim()) || String.IsNullOrEmpty(ultraTextEditor19.Text.Trim())
                || !StringUtil.MatchIp(ip))
            {
                label1.Text = "IP址址不正确！";
                return;
            }
            int port = 0;
            if (String.IsNullOrEmpty(ultraTextEditor20.Text.Trim()) || !int.TryParse(ultraTextEditor20.Text.Trim(), out port) || port == 0 || port > 65535)
            {
                label1.Text = "端口不正确！";
                return;
            }
            string srvName = ultraTextEditor1.Text.Trim();
            if (String.IsNullOrEmpty(srvName))
            {
                label1.Text = "请输入服务名！";
                return;
            }

            label1.Text = "";
            List<object> srvList = new List<object>();
            ServerConfig sc = new ServerConfig();
            sc.Id = 0;
            sc.Mode = "Hessian";
            sc.Name = "BIP";
            sc.Url = "http://" + ip + ":" + port.ToString() + "/" + srvName;
            srvList.Add(sc);
            BipConfig.Store(Globals.ServerConfigName, srvList);
            metroButtonSrvApply.Enabled = false;
        }

        int loginCount = 0;
        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ultraTextEditor13.Text.Trim()))
            {
                label3.Text = "请输入原密码！";
                ultraTextEditor14.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(ultraTextEditor14.Text.Trim()))
            {
                label3.Text = "请输入新密码！";
                ultraTextEditor15.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(ultraTextEditor15.Text.Trim()))
            {
                label3.Text = "请输入确认密码！";
                ultraTextEditor16.Focus();
                return;
            }
            else if (ultraTextEditor13.Text.Trim().Equals(ultraTextEditor14.Text.Trim()))
            {
                label3.Text = "新密码不能与原密码相同！";
                ultraTextEditor16.Focus();
                return;
            }
            else if (!ultraTextEditor14.Text.Trim().Equals(ultraTextEditor15.Text.Trim()))
            {
                label3.Text = "确认密码与新密码不一致！";
                ultraTextEditor16.Focus();
                return;
            }
            try
            {
                user.UserPassword = ultraTextEditor13.Text.Trim();
                this.Update(Globals.USER_SERVICE_NAME, "changePassword", new object[] { user, ultraTextEditor14.Text.Trim() });
            }
            catch (BipException ex)
            {                
                loginCount++;
                if (loginCount == 5)
                {
                    label3.Text = "尝试次数过多，请稍后再试！";
                    metroButton2.Enabled = false;
                }
                else
                {
                    label3.Text = ex.Message;
                }
                return;
            }
            label3.Text = "";            
            MetroMessageBox.Show(this, "修改成功！", "提示");
        }

        private void uteHk_ValueChanged(object sender, EventArgs e)
        {
            if (!metroButtonHkApply.Enabled)
                metroButtonHkApply.Enabled = true;
        }

        private void metroButtonHkApply_Click(object sender, EventArgs e)
        {
            List<Hashtable> hkList = new List<Hashtable>();
            Hashtable ht = new Hashtable();
            ht.Add("key","relogin");
            ht.Add("value",TranslateHotKey(uteHkRelogin.Text));
            hkList.Add(ht);

            ht = new Hashtable();
            ht.Add("key", "lock");
            ht.Add("value", TranslateHotKey(uteHkLock.Text));
            hkList.Add(ht);

            ht = new Hashtable();
            ht.Add("key", "fun1");
            ht.Add("value", TranslateHotKey(uteHkFun1.Text));
            hkList.Add(ht);

            ht = new Hashtable();
            ht.Add("key", "fun2");
            ht.Add("value", TranslateHotKey(uteHkFun2.Text));
            hkList.Add(ht);

            ht = new Hashtable();
            ht.Add("key", "fun3");
            ht.Add("value", TranslateHotKey(uteHkFun3.Text));
            hkList.Add(ht);

            ht = new Hashtable();
            ht.Add("key", "fun4");
            ht.Add("value", TranslateHotKey(uteHkFun4.Text));
            hkList.Add(ht);

            ht = new Hashtable();
            ht.Add("key", "fun5");
            ht.Add("value", TranslateHotKey(uteHkFun5.Text));
            hkList.Add(ht);

            ht = new Hashtable();
            ht.Add("key", "fun6");
            ht.Add("value", TranslateHotKey(uteHkFun6.Text));
            hkList.Add(ht);

            ht = new Hashtable();
            ht.Add("key", "fun7");
            ht.Add("value", TranslateHotKey(uteHkFun7.Text));
            hkList.Add(ht);

            ht = new Hashtable();
            ht.Add("key", "fun8");
            ht.Add("value", TranslateHotKey(uteHkFun8.Text));
            hkList.Add(ht);

            settings["hotkey"] = JSONUtil.ToJson(hkList);
            BipConfig.StoreObject(Globals.SettingConfigName, settings);
            Globals.HotkeyList = hkList;//快捷键设置更改后立即更新
            metroButtonHkApply.Enabled = false;
        }

        private string TranslateHotKey(string str)
        {
            return (str.Contains("Ctrl") ? "1" : "0") + (str.Contains("Shift") ? "1" : "0") + (str.Contains("Alt") ? "1" : "0") + str.Substring(str.Length - 1);
        }

        private void metroButtonOtherOK_Click(object sender, EventArgs e)
        {
            if (metroButtonOtherApply.Enabled)
            {
                //
                if (metroButtonOtherApply.Enabled)
                {

                }
            }
            this.Close();
        }

        private void metroButtonAccountOK_Click(object sender, EventArgs e)
        {
            if (metroButtonAccountApply.Enabled)
            {
                //
                if (metroButtonAccountApply.Enabled)
                {

                }
            }
            this.Close();
        }

        private void metroButtonHkOK_Click(object sender, EventArgs e)
        {
            if (metroButtonHkApply.Enabled)
            {
                metroButtonHkApply_Click(metroButtonHkApply, e);
                if (metroButtonHkApply.Enabled)
                {
                    return;
                }
            }
            this.Close();
        }

        private void metroButtonSrvOK_Click(object sender, EventArgs e)
        {
            if (metroButtonSrvApply.Enabled)
            {
                metroButtonSrvApply_Click(metroButtonSrvApply, e);
                if (metroButtonSrvApply.Enabled)
                {
                    return;
                }
            }
            this.Close();
        }

        private void metroButtonBaseOK_Click(object sender, EventArgs e)
        {
            if (metroButtonBaseApply.Enabled)
            {
                metroButtonBaseApply_Click(metroButtonBaseApply, e);
                if (metroButtonBaseApply.Enabled)
                {
                    return;
                }
            }
            this.Close();
        }

        #region 网络检测
        public void InspectServer()
        {
            bipTableView1.Clear();

            BipRow row = new BipRow();
            row.IsHeader = true;
            row.Add(new BipCell() { Text = "系统名称", Width = 100 });
            row.Add(new BipCell() { Text = "服务器" });
            row.Add(new BipCell() { Text = "应用服务" });
            row.Add(new BipCell() { Text = "数据库" });
            bipTableView1.AddRow(row);

            row = new BipRow();
            row.Height = 30;
            row.Add(new BipCell() { Text = "BIP平台", Width = 100 });
            row.Add(new BipCell());
            row.Add(new BipCell());
            row.Add(new BipCell());
            bipTableView1.AddRow(row);
            //检查平台运信情况
            string ipPattern = "(\\d+)\\.(\\d+)\\.(\\d+)\\.(\\d+)";
            Regex regex = new Regex(ipPattern);
            Match match = regex.Match(this.Action.Url);
            if (!string.IsNullOrEmpty(match.Value))
            {
                if (NetworkUtil.Ping(match.Value))
                {
                    row.Cells[1].Text = "正常";
                    row.Cells[1].ForeColor = Color.Green;

                    ServerStatus status = null;
                    try
                    {
                        status = this.FindOne<ServerStatus>(Globals.SERVERINFO_SERVICE_NAME, "getServerStatus", new object[0]);
                    }
                    catch (Exception ex)
                    {
                    }
                    row.Cells[2].Text = status != null && status.AppRunning ? "正常" : "断开";
                    row.Cells[2].ForeColor = status != null && status.AppRunning ? Color.Green : Color.Red;
                    row.Cells[3].Text = status != null && status.DatabaseConnecting ? "正常" : "断开";
                    row.Cells[3].ForeColor = status != null && status.DatabaseConnecting ? Color.Green : Color.Red;

                    if (status != null && status.DatabaseConnecting)
                    {
                        List<SysFunction> sysList = this.FindList<SysFunction>(Globals.FUNCTION_SERVICE_NAME, "findSystemList", new object[0]);
                        foreach (SysFunction sys in sysList)
                        {
                            row = new BipRow();
                            row.Add(new BipCell() { Text = sys.FunctionName, Width = 100 });
                            row.Add(new BipCell());
                            row.Add(new BipCell());
                            row.Add(new BipCell());
                            bipTableView1.AddRow(row);
                            match = regex.Match(sys.Url != null ? sys.Url : "");
                            if (!String.IsNullOrEmpty(match.Value))
                            {
                                if (NetworkUtil.Ping(match.Value))
                                {
                                    row.Cells[1].Text = "正常";
                                    row.Cells[1].ForeColor = Color.Green;
                                    try
                                    {
                                        status = this.FindOne<ServerStatus>(new BipAction(sys.Url), Globals.SERVERINFO_SERVICE_NAME, "getServerStatus", new object[0]);
                                    }
                                    catch (Exception ex)
                                    {
                                        status = null;
                                    }
                                    row.Cells[2].Text = status != null && status.AppRunning ? "正常" : "断开";
                                    row.Cells[2].ForeColor = status != null && status.AppRunning ? Color.Green : Color.Red;
                                    row.Cells[3].Text = status != null && status.DatabaseConnecting ? "正常" : "断开";
                                    row.Cells[3].ForeColor = status != null && status.DatabaseConnecting ? Color.Green : Color.Red;
                                }
                                else
                                {
                                    row.Cells[1].Text = "断开";
                                    row.Cells[1].ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                row.Cells[1].Text = "URL错误";
                                row.Cells[1].ForeColor = Color.Red;
                            }
                        }
                    }
                }
                else
                {
                    row.Cells[1].Text = "断开";
                    row.Cells[1].ForeColor = Color.Red;
                }
            }
            else
            {
                row.Cells[1].Text = "URL错误";
                row.Cells[1].ForeColor = Color.Red;
            }
        }

        #endregion

        private void metroButton1_Click(object sender, EventArgs e)
        {
            InspectServer();
        }
    }
}
