using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.core;
using com.ccf.bip.framework.form;
using com.ccf.bip.framework.util;
using com.ccf.bip.frame.style;
using com.ccf.bip.biz.system.authorization.mapper;
using com.ccf.bip.framework.form.helper;
using System.Reflection;
using Infragistics.Win.UltraWinStatusBar;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using com.ccf.bip.biz.system.monitor.mapper;
using MetroFramework.Forms;
using System.Collections;
using System.Threading;
using MetroFramework;

namespace com.ccf.bip.frame
{
    public partial class FormFrame : BipMetroForm
    {
        private Thread _initThread;
        private delegate void InitDelegate();
        private ServerStatus _serverStatus = new ServerStatus();//存储主服务器连接状态

        public FormFrame()
        {
            if (!Login(false))
            {
                this.Dispose(true);
                return;
            }
            InitializeComponent();            
        }             

        private bool Login(bool lockSystem)
        {
            bool ret = false;
            FormLogin login = new FormLogin();
            login.LockSystem = lockSystem;
            DialogResult dialogResult = login.ShowDialog(this);
            switch (dialogResult)
            {
                case DialogResult.OK:
                    ret = true;
                    this.User = login.User;
                    this.Action = login.Action;
                    break;
                case DialogResult.Abort:
                    this.Dispose(true);
                    break;
            }
            return ret;
        }

        private void FormFrame_Load(object sender, EventArgs e)
        {
            //使用线程加载界面
            _initThread = new Thread(new ThreadStart(ThreadInit));
            _initThread.Start();

            //登录成功表示主服务器连接良好
            _serverStatus.AllGood();
            timerFrame.Start();
        }

        private void ThreadInit()
        {
            InitDelegate dlg = new InitDelegate(InitForm);
            BeginInvoke(dlg);
        }

        private void InitForm()
        {
            //显示导航界面
            FormWelcome form = new FormWelcome();
            form.MdiParent = this;
            form.Text = "首页";
            BipStyleBuilder.SetFormStyle(form);
            form.Show();
            ultraTabbedMdiManager1.TabFromForm(form).Settings.TabCloseAction = Infragistics.Win.UltraWinTabbedMdi.MdiTabCloseAction.None;//不允许关闭首页
            ultraTabbedMdiManager1.TabFromForm(form).Settings.CloseButtonVisibility = Infragistics.Win.UltraWinTabs.TabCloseButtonVisibility.Never;//首页Tab Header不显示关闭按钮

            LoadMainMemu();
            //加载快捷键
            Hashtable settings = BipConfig.LoadObject<Hashtable>(Globals.SettingConfigName);
            Globals.HotkeyList = JSONUtil.Parse<List<Hashtable>>(settings["hotkey"].ToString());
            Hashtable ht = Globals.HotkeyList.Find(h=>h["key"].ToString() == "relogin");
            if(ht != null)
            {
                char[] keys = ht["value"].ToString().ToCharArray();
                string reloginHk = (keys[0] == '1' ? "Ctrl+" : "") + (keys[1] == '1' ? "Shift+" : "") + (keys[2] == '1' ? "Alt+" : "") +keys[3].ToString();
                tsmiRelogin.Text += "               " + reloginHk;
            }            
        }

        private void FormFrame_Shown(object sender, EventArgs e)
        {
            
        }

        private void LoadMainMemu()
        {
            //获取功能菜单数据
            try
            {
                IEnumerable<SysFunction> functions = this.Find<SysFunction>("com.ccf.bip.biz.system.authorization.service.FunctionService", "findFunctionListByUser", new object[] { User });
                List<SysFunction> list = new List<SysFunction>();
                list.AddRange(functions);
                //绑定到左侧菜单树，从根目录开始绑定
                mainMenuTree.DataSource = list;
                //绑定上方功能菜单
                BandMainMemu(ultraToolbarsManager1, list);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 绑定上方功能菜单数据，从子系统开始绑定
        /// </summary>
        /// <param name="toolbar"></param>
        /// <param name="list"></param>
        private void BandMainMemu(UltraToolbarsManager toolbar,List<SysFunction> list)
        {
            if (toolbar.Tools.Count > 0)
            {
                toolbar.Toolbars[0].Tools.Clear();
                toolbar.Tools.Clear();
                //使菜单栏居右
                LabelTool labelTool = new LabelTool("blankTool");
                labelTool.SharedProps.Spring = true;
                toolbar.Tools.Add(labelTool);
                toolbar.Toolbars[0].Tools.AddTool("blankTool");

                //子系统
                List<SysFunction> subSystemList = list.FindAll(f=>f.FunctionType.Equals("1012"));
                foreach (SysFunction subSystem in subSystemList)
                {
                    PopupMenuTool pmt = new PopupMenuTool(subSystem.FunctionId);
                    pmt.SharedProps.Caption = PadPopupMenuToolCaption(subSystem.FunctionName);
                    pmt.DropDownArrowStyle = DropDownArrowStyle.None;
                    pmt.Tag = subSystem;
                    pmt.Settings.IconAreaAppearance.BackColor = Color.FromArgb(171, 206, 228);
                    //pmt.CustomizedDisplayStyle = ToolDisplayStyle.ImageAndText;
                    //pmt.CustomizedImage = Image.FromFile("./resource/image/mainMenu/directory.png");
                    toolbar.Tools.Add(pmt);
                    toolbar.Toolbars[0].Tools.AddTool(subSystem.FunctionId);
                    BandMainMenuSubNode(toolbar, pmt, list);
                }
            }
        }

        private string PadPopupMenuToolCaption(string str)
        {
            if (str.Length < 10)
            {
                int len = str.Length;
                str = str.PadLeft((int)Math.Floor((10D - len) / 2) + str.Length);
                str = str.PadRight((10 - len) / 2 + str.Length);
            }
            return str;
        }

        /// <summary>
        /// 绑定上方功能菜单子系统以下节点
        /// </summary>
        /// <param name="toolbar"></param>
        /// <param name="pmt"></param>
        /// <param name="list"></param>
        private void BandMainMenuSubNode(UltraToolbarsManager toolbar, PopupMenuTool pmt, List<SysFunction> list)
        {
            List<SysFunction> subList = list.FindAll(f => !string.IsNullOrEmpty(f.ParentId) && f.ParentId.Equals(pmt.Key));//根据上级节点获取子节点数据
            foreach (SysFunction subNode in subList)
            {
                if (subNode.FunctionType.Equals("1014"))
                {
                    ButtonTool bt = new ButtonTool(subNode.FunctionId);
                    bt.SharedProps.Caption = subNode.FunctionName;
                    bt.Tag = subNode;
                    if (!string.IsNullOrEmpty(subNode.Image))
                    {
                        bt.CustomizedDisplayStyle = ToolDisplayStyle.ImageAndText;
                        bt.CustomizedImage = Image.FromFile("./resource/image/mainMenu/" + subNode.Image + ".png");
                    }
                    
                    toolbar.Tools.Add(bt);
                    pmt.Tools.AddTool(subNode.FunctionId);
                }
                else
                {
                    PopupMenuTool subPmt = new PopupMenuTool(subNode.FunctionId);
                    subPmt.SharedProps.Caption = subNode.FunctionName;
                    subPmt.DropDownArrowStyle = DropDownArrowStyle.None;
                    subPmt.Tag = subNode;
                    subPmt.Settings.IconAreaAppearance.BackColor = Color.FromArgb(171, 206, 228);
                    if (!string.IsNullOrEmpty(subNode.Image))
                    {
                        subPmt.CustomizedDisplayStyle = ToolDisplayStyle.ImageAndText;
                        subPmt.CustomizedImage = Image.FromFile("./resource/image/mainMenu/" + subNode.Image + ".png");
                    }
                    toolbar.Tools.Add(subPmt);
                    pmt.Tools.AddTool(subNode.FunctionId);                    
                    BandMainMenuSubNode(toolbar, subPmt, list);
                }
            }
        }

        private void ultraTabbedMdiManager1_InitializeContextMenu(object sender, Infragistics.Win.UltraWinTabbedMdi.MdiTabContextMenuEventArgs e)
        {
            if (e.ContextMenuType == Infragistics.Win.UltraWinTabbedMdi.MdiTabContextMenu.Default)
            {
                e.ContextMenu.MenuItems.Clear();
                Infragistics.Win.IGControls.IGMenuItem item1 = new Infragistics.Win.IGControls.IGMenuItem("关闭");
                item1.Tag = e.Tab;
                item1.Click += new EventHandler(OnCustomMenuItemClose);
                e.ContextMenu.MenuItems.Add(item1);
            } 
        }

        private void ultraTabbedMdiManager1_TabActivated(object sender, Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs e)
        {
            if(e.Tab.Form.GetType().IsSubclassOf(typeof(BipForm)))
            {
                BipForm form = e.Tab.Form as BipForm;
                List<string> pathList = new List<string>();
                UltraTreeNode pathNode = mainMenuTree.GetNodeByKey(form.Id);
                while (pathNode != null)
                {
                    pathList.Add((pathNode.Tag as SysFunction).FunctionName);
                    pathNode = pathNode.Parent;
                }
                pathList.Reverse();
                ultraStatusBar1.Panels["FormPath"].Text = String.Join("\\", pathList.ToArray());
            }
        }  

        private void OnCustomMenuItemClose(object sender, EventArgs e)
        {
            Infragistics.Win.IGControls.IGMenuItem mi = sender as Infragistics.Win.IGControls.IGMenuItem;
            Infragistics.Win.UltraWinTabbedMdi.MdiTab tab = mi.Tag as Infragistics.Win.UltraWinTabbedMdi.MdiTab;
            tab.Close();
        }

        /// <summary>
        /// 打开业务功能界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainMenuTree_OnBipFormOpenning(object sender, OpenFormEventArgs e)
        {
            bool isOpenBipForm = false;
            SysFunction function = e.Fucntion;

            string formId;
            foreach (Form mdiChild in this.MdiChildren)
            {
                if (mdiChild.GetType().IsSubclassOf(typeof(BipForm)))
                {
                    formId = (mdiChild as BipForm).Id;
                    if (formId.Equals(function.FunctionId))
                    {
                        mdiChild.Activate();
                        isOpenBipForm = true;
                        break;
                    }
                }
            }
            Assembly bipFormAssembly = Assembly.Load(function.Assemblyname);
            Type type = bipFormAssembly.GetType(function.Url);

            if (!isOpenBipForm && type.IsSubclassOf(typeof(BipForm)))
            {
                BipForm form = Activator.CreateInstance(type, true) as BipForm;
                form.MdiParent = this;
                form.Id = function.FunctionId;
                form.Text = function.FunctionName;
                form.User = this.User;
                form.CustomInformation = function.Tag;
                //从树菜单根节点系统获取服务端URL
                UltraTreeNode node = mainMenuTree.GetNodeByKey(function.FunctionId);
                while (node.Parent != null)
                {
                    node = node.Parent;
                }
                string url = (node.Tag as SysFunction).Url;
                //未配置系统后台服务Url则使用平台默认URL
                if (String.IsNullOrEmpty(url))
                {
                    url = Globals.ServerList.Find(s => s.Id == 0).Url;
                }
                form.Action = new BipAction(url); 
                //ultraTabbedMdiManager1.TabFromForm(form).Settings.TabCloseAction = Infragistics.Win.UltraWinTabbedMdi.MdiTabCloseAction.None;//不允许关闭界面
                BipStyleBuilder.SetFormStyle(form);//设置样式
                //设置界面toolbar及功能按钮
                List<SysFunction> buttonList = new List<SysFunction>();
                buttonList.AddRange(this.Find<SysFunction>("com.ccf.bip.biz.system.authorization.service.FunctionService","findButtonList",new object[]{form.Id}));
                GenerateUltraToolBar(form,buttonList);                
                form.Show();
                isOpenBipForm = true;

                //使用快捷键
                if (function.UseHotKey)
                {
                    form.KeyPreview = true;
                    form.KeyDown += new KeyEventHandler(form_KeyDown);
                }
            }

            if (isOpenBipForm)
            {
                //记录界面打开记录
                //读取本地配置文件
                Hashtable htSettings = BipConfig.LoadObject<Hashtable>("setting.bip");
                string baseSettinStr = htSettings["base"].ToString();
                Hashtable htBase = JSONUtil.Parse<Hashtable>(baseSettinStr);
                bool hisFlag = htBase["hisFlag"].ToString().Equals("1");
                Decimal hisNum = Convert.ToDecimal(htBase["hisNum"].ToString());
                List<Hashtable> listHis = JSONUtil.Parse<List<Hashtable>>(htBase["history"].ToString());
                if (hisFlag)
                {
                    if (listHis == null)
                        listHis = new List<Hashtable>();

                    Hashtable swapHt = null;
                    foreach(Hashtable h in listHis)
                    {
                        if (h["formId"].ToString().Equals(function.FunctionId))
                        {
                            swapHt = h;
                            break;
                        }
                    }
                    if (swapHt != null)
                    {
                        listHis.Remove(swapHt);
                        listHis.Insert(0, swapHt);
                    }
                    else
                    {
                        Hashtable ht = new Hashtable();
                        ht["formId"] = function.FunctionId;
                        ht["formName"] = function.FunctionName;
                        listHis.Insert(0, ht);                                                
                    }
                    while (listHis.Count > hisNum)
                    {
                        listHis.RemoveAt(listHis.Count - 1);
                    }
                    htBase["history"] = JSONUtil.ToJson(listHis);
                    htSettings["base"] = JSONUtil.ToJson(htBase);
                    BipConfig.StoreObject("setting.bip", htSettings);
                }
            }
        }

        void form_KeyDown(object sender, KeyEventArgs e)
        {
            string keys = (e.Control ? "1" : "0") + (e.Shift ? "1" : "0") + (e.Alt ? "1" : "0") + Convert.ToChar(e.KeyCode).ToString().ToUpper();
            Hashtable ht = Globals.HotkeyList.Find(h => h["value"].ToString() == keys && h["key"].ToString().StartsWith("fun"));
            if (ht != null)
            {
                int btnIdx = int.Parse(ht["key"].ToString().Replace("fun", ""))-1;
                BipForm form = sender as BipForm;
                if (btnIdx < form.ToolbarButtonList.Count)
                {
                    form.ToolClick(form.Toolbar, new ToolClickEventArgs(form.Toolbar.Tools[btnIdx], new ListToolItem(form.ToolbarButtonList[btnIdx].Key)));
                }
            }
        }

        /// <summary>
        /// 显示左上角弹出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFrame_IconClick(object sender, EventArgs e)
        {
            this.contextMenuStripStart.Show(this,10, 20);
            Hashtable htSettings = BipConfig.LoadObject<Hashtable>("setting.bip");
            Hashtable htBase = JSONUtil.Parse<Hashtable>(htSettings["base"].ToString());
            List<Hashtable> listHis = JSONUtil.Parse<List<Hashtable>>(htBase["history"].ToString());
            tsmiHistory.DropDown = null;
            contextMenuStripHis.Items.Clear();
            if(listHis != null && listHis.Count > 0)
            {                
                ToolStripItem[] items = new ToolStripItem[listHis.Count];
                int i = 0;
                foreach (Hashtable ht in listHis)
                {
                    items[i] = new ToolStripMenuItem();
                    items[i].Name = ht["formId"].ToString();
                    items[i].Text = ht["formName"].ToString();
                    items[i].BackColor = Color.FromArgb(171, 206, 228);
                    items[i].Click += new EventHandler(FormFrameHis_Click);
                    i++;
                }
                contextMenuStripHis.Items.AddRange(items);
                tsmiHistory.DropDown = contextMenuStripHis;
            }
        }

        void FormFrameHis_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            UltraTreeNode node = mainMenuTree.GetNodeByKey(item.Name);
            if (node != null)
            {
                mainMenuTree_OnBipFormOpenning(sender, new OpenFormEventArgs(node.Tag as SysFunction));
            }
        }

        private void ultraStatusBar1_PanelClick(object sender, Infragistics.Win.UltraWinStatusBar.PanelClickEventArgs e)
        {
            switch (e.Panel.Key)
            {
                case "ConnectionStatus":
                    break;
                case "SupportInfo":

                    break;
            }            
        }

        private void ultraStatusBar1_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            if (e.Element is PanelUIElement)
            {
                PanelUIElement ele = e.Element as PanelUIElement;
                if (ele.Panel.Key.Equals("SupportInfo"))
                {
                    ele.Panel.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
                }
            }
        }

        private void ultraStatusBar1_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            if (e.Element is PanelUIElement)
            {
                PanelUIElement ele = e.Element as PanelUIElement;
                if (ele.Panel.Key.Equals("SupportInfo"))
                {
                    ele.Panel.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;
                }
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        } 

        /// <summary>
        /// 重绘功能菜单树折叠按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraExpandableGroupBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bm = ResourceImg.collapsed;
            if (ultraExpandableGroupBox1 != null && !ultraExpandableGroupBox1.Expanded)
                bm = ResourceImg.expanded;

            Image img = bm.GetThumbnailImage(16, 16, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            e.Graphics.DrawIcon(Icon.FromHandle(new Bitmap(img).GetHicon()),2,8);
        }

        private void ultraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            SysFunction function = e.Tool.ToolbarsManager.Tools[e.Tool.Key].Tag as SysFunction;
            if (function == null)
                return;
            switch (function.FunctionType)
            {
                case "1014":
                    mainMenuTree_OnBipFormOpenning(sender, new OpenFormEventArgs(function));
                    break;
            }
        }

        #region 生成子窗体工具栏
        private void GenerateUltraToolBar(BipForm form, List<SysFunction> list)
        {
            if (list == null || list.Count == 0)
            {
                return;
            }
            Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            form.Toolbar = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(null);
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar = new Infragistics.Win.UltraWinToolbars.UltraToolbar("ultraToolbar1");
            System.Windows.Forms.Panel toolbarPanel = new System.Windows.Forms.Panel();


            ((System.ComponentModel.ISupportInitialize)(form.Toolbar)).BeginInit();

            //
            //ButtonTool
            //
            foreach (SysFunction bfun in list)
            {
                string btnkey = bfun.Key;
                ButtonTool toolItem = new ButtonTool(btnkey);

                toolItem.SharedProps.Caption = bfun.FunctionName;
                //toolItem.SharedProps.Enabled = sb.Enable;
                toolItem.SharedProps.DisplayStyle = ToolDisplayStyle.ImageAndText;
                if (!String.IsNullOrEmpty(bfun.Image) && File.Exists("./resource/image/button/"+bfun.Image+".png"))
                    toolItem.CustomizedImage = Image.FromFile("./resource/image/button/" + bfun.Image + ".png");
                //toolItem.InstanceProps.IsFirstInGroup = true;
                ultraToolbar.Tools.Add(toolItem);
            }

            //
            //UltraToolbar
            //
            ultraToolbar.DockedColumn = 0;
            ultraToolbar.DockedRow = 0;
            ultraToolbar.Text = "ultraToolbar";
            ultraToolbar.Settings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            //ultraToolbar.Settings.Appearance.BackColor = Color.LightBlue;
            //
            //UltraToolbarsManager
            //
            form.Toolbar.ToolClick += new ToolClickEventHandler(form.ToolClick);
            form.Toolbar.ShowQuickCustomizeButton = false;
            //ultraToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] { ultraToolbar1 });
            form.Toolbar.Toolbars.Add(ultraToolbar);
            form.Toolbar.DockWithinContainer = toolbarPanel;
            //form.Toolbar.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
            form.Toolbar.Appearance.BackColor = Color.FromArgb(171, 206, 228);
            form.Toolbar.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            form.Toolbar.LockToolbars = true;
            form.Toolbar.RuntimeCustomizationOptions = RuntimeCustomizationOptions.None;
            // 
            // _FrmBase_Toolbars_Dock_Area_Left
            // 
            _FrmBase_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            _FrmBase_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            _FrmBase_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            _FrmBase_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            _FrmBase_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 25);
            _FrmBase_Toolbars_Dock_Area_Left.Name = "_BipForm_Toolbars_Dock_Area_Left";
            _FrmBase_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 237);
            _FrmBase_Toolbars_Dock_Area_Left.ToolbarsManager = form.Toolbar;
            // 
            // _FrmBase_Toolbars_Dock_Area_Right
            // 
            _FrmBase_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            _FrmBase_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            _FrmBase_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            _FrmBase_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            _FrmBase_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(446, 25);
            _FrmBase_Toolbars_Dock_Area_Right.Name = "_BipForm_Toolbars_Dock_Area_Right";
            _FrmBase_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 237);
            _FrmBase_Toolbars_Dock_Area_Right.ToolbarsManager = form.Toolbar;
            // 
            // _FrmBase_Toolbars_Dock_Area_Top
            // 
            _FrmBase_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            _FrmBase_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            _FrmBase_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            _FrmBase_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            _FrmBase_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            _FrmBase_Toolbars_Dock_Area_Top.Name = "_BipForm_Toolbars_Dock_Area_Top";
            _FrmBase_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(446, 25);
            _FrmBase_Toolbars_Dock_Area_Top.ToolbarsManager = form.Toolbar;
            // 
            // _FrmBase_Toolbars_Dock_Area_Bottom
            // 
            _FrmBase_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            _FrmBase_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            _FrmBase_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            _FrmBase_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            _FrmBase_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 262);
            _FrmBase_Toolbars_Dock_Area_Bottom.Name = "_BipForm_Toolbars_Dock_Area_Bottom";
            _FrmBase_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(446, 0);
            _FrmBase_Toolbars_Dock_Area_Bottom.ToolbarsManager = form.Toolbar;

            // 
            // toolbarPanel
            // 
            toolbarPanel.Controls.Add(_FrmBase_Toolbars_Dock_Area_Left);
            toolbarPanel.Controls.Add(_FrmBase_Toolbars_Dock_Area_Right);
            toolbarPanel.Controls.Add(_FrmBase_Toolbars_Dock_Area_Top);
            toolbarPanel.Controls.Add(_FrmBase_Toolbars_Dock_Area_Bottom);
            toolbarPanel.Cursor = System.Windows.Forms.Cursors.Default;
            toolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            toolbarPanel.Location = new System.Drawing.Point(0, 0);
            toolbarPanel.Name = "toolbarPanel";
            toolbarPanel.Size = new System.Drawing.Size(284, 262);
            toolbarPanel.TabIndex = 0;


            form.Controls.Add(_FrmBase_Toolbars_Dock_Area_Bottom);
            form.Controls.Add(_FrmBase_Toolbars_Dock_Area_Left);
            form.Controls.Add(_FrmBase_Toolbars_Dock_Area_Right);
            form.Controls.Add(_FrmBase_Toolbars_Dock_Area_Top);

            form.ToolbarButtonList = list;            

            ((System.ComponentModel.ISupportInitialize)(form.Toolbar)).EndInit();


        }
        
        #endregion

        long runSeconds = 0;
        private void timerFrame_Tick(object sender, EventArgs e)
        {
            runSeconds++;
            ultraStatusBar1.Panels["Time"].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (runSeconds % 5 == 0)
            {
                ServerStatus status = null;
                try
                {
                    status = this.FindOne<ServerStatus>(Globals.SERVERINFO_SERVICE_NAME, "getServerStatus", new object[0],false);
                }
                catch (Exception ex)
                {
                    status = new ServerStatus();
                }
                if (_serverStatus.AppRunning != status.AppRunning)
                {
                    _serverStatus = status;
                    ultraStatusBar1.Panels["ConnectionStatus"].Appearance.Image = Image.FromFile("./resource/image/icon/" + (_serverStatus.AppRunning ? "connected" : "disconnected") + ".png");
                }
            }
        }

        bool customExit = false;//是否已确认退出系统，为formclosing事件提供判断
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this,"是否确定退出系统？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                customExit = true;
                this.Close();
            }
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            DlgSettings dlg = new DlgSettings();
            dlg.User = this.User;
            dlg.Action = this.Action;
            dlg.ShowDialog(this);
        }

        private void tsmiChangePassword_Click(object sender, EventArgs e)
        {
            DlgSettings dlg = new DlgSettings();
            dlg.ActiveIndex = 3;
            dlg.User = this.User;
            dlg.Action = this.Action;
            dlg.ShowDialog(this);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            FormFrame_IconClick(sender, e);
        }

        private void FormFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!customExit && MetroMessageBox.Show(this, "是否确定退出系统?", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        #region 重新登录
        private void tsmiRelogin_Click(object sender, EventArgs e)
        {
            Relogin(false);
        }

        public void Relogin(bool lockSystem)
        {
            if (Login(lockSystem))
            {
                //关闭已打开界面
                foreach (Form form in this.MdiChildren)
                {
                    if (form.Name == "FormWelcome")
                        continue;
                    form.Close();
                }
                //重新加载新用户菜单
                LoadMainMemu();
            }
        }
        #endregion

        private void FormFrame_KeyDown(object sender, KeyEventArgs e)
        {
            Hashtable ht = Globals.HotkeyList.Find(h => h["key"].ToString() == "relogin");
            if (ht != null)
            {
                char[] keys = ht["value"].ToString().ToCharArray();
                if (!(keys[0] == '1' ^ e.Control) && !(keys[1] == '1' ^ e.Shift) && !(keys[2] == '1' ^ e.Alt) && (Keys)Enum.Parse(typeof(Keys), keys[3].ToString()) == e.KeyCode)
                {
                    tsmiRelogin_Click(null, new EventArgs());
                }
            }
        }
    }
}
