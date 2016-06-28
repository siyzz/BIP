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

namespace com.ccf.bip.frame
{
    public partial class FormFrame : SkinForm
    {
        private ServerStatus _serverStatus = new ServerStatus();//存储主服务器连接状态
        private DlgConnectionTips _dlgConnectionTips = new DlgConnectionTips();

        public FormFrame()
        {
            if (!Login())
            {
                this.Dispose();
                return;
            }            
            InitializeComponent();            
        }             

        private bool Login()
        {
            bool ret = false;
            FormLogin login = new FormLogin();
            if (login.ShowDialog(this) == DialogResult.OK)
            {
                ret = true;
                this.User = login.User;
                this.Action = login.Action;
            }
            return ret;
        }

        private void FormFrame_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = ImageUtil.GetPart(Globals.AppPath + "\\resource\\image\\company.jpg", 0, 0, 80, 80, 0, -13);
            IntPtr hicon = bitmap.GetHicon();
            Icon ico = Icon.FromHandle(hicon);
            this.Icon = ico;

            LoadMainMemu();
            //显示导航界面
            FormWelcome form = new FormWelcome();
            form.MdiParent = this;
            form.Text = "首页";
            BipStyleBuilder.SetFormStyle(form);
            form.Show();
            ultraTabbedMdiManager1.TabFromForm(form).Settings.TabCloseAction = Infragistics.Win.UltraWinTabbedMdi.MdiTabCloseAction.None;

            //登录成功表示主服务器连接良好
            _serverStatus.AllGood();
            timerNetwork.Start();

            _dlgConnectionTips.Deactivate += new EventHandler(_dlgConnectionTips_Deactivate);
            _dlgConnectionTips.Action = this.Action;
        }

        private void LoadMainMemu()
        {
            //获取功能菜单数据
            IEnumerable<SysFunction> functions = this.Find<SysFunction>("com.ccf.bip.biz.system.authorization.service.FunctionService", "findFunctionListByUser", new object[] { User });
            List<SysFunction> list = new List<SysFunction>();
            list.AddRange(functions);
            //绑定到左侧菜单树，从根目录开始绑定
            mainMenuTree.DataSource = list;
            //绑定上方功能菜单
            BandMainMemu(ultraToolbarsManager1, list);
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
                    pmt.Settings.IconAreaAppearance.BackColor = Color.LightBlue;
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
                    subPmt.Settings.IconAreaAppearance.BackColor = Color.LightBlue;
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

        private void OnCustomMenuItemClose(object sender, EventArgs e)
        {
            Infragistics.Win.IGControls.IGMenuItem mi = sender as Infragistics.Win.IGControls.IGMenuItem;
            Infragistics.Win.UltraWinTabbedMdi.MdiTab tab = mi.Tag as Infragistics.Win.UltraWinTabbedMdi.MdiTab;
            tab.Close();
        }

        private void mainMenuTree_OnBipFormOpenning(object sender, OpenFormEventArgs e)
        {
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
                        return;
                    }
                }
            }
            Assembly bipFormAssembly = Assembly.Load(function.Assemblyname);
            Type type = bipFormAssembly.GetType(function.Url);

            if (type.IsSubclassOf(typeof(BipForm)))
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
            }
        }

        private void FormFrame_IconClick(object sender, EventArgs e)
        {
            this.contextMenuStripStart.Show(this,this.Left+10, this.Top+20);
        }

        private void ultraToolbarsManager1_PropertyChanged(object sender, Infragistics.Win.PropertyChangedEventArgs e)
        {
            if (ultraToolbarsManager1.Ribbon.IsMinimized)
            {
                this.panel1.Height = 21;
            }
            else
            {
                this.panel1.Height = 120;
            }
        }

        private void ultraStatusBar1_PanelClick(object sender, Infragistics.Win.UltraWinStatusBar.PanelClickEventArgs e)
        {
            switch (e.Panel.Key)
            {
                case "ConnectionStatus":
                    if (!_dlgConnectionTips.Visible)
                        _dlgConnectionTips.Show();
                    _dlgConnectionTips.Location = new Point(Cursor.Position.X + 5, Cursor.Position.Y - (_dlgConnectionTips.Height + 5));
                    _dlgConnectionTips.BringToFront();
                    _dlgConnectionTips.Focus();
                    break;
            }            
        }
        
        void _dlgConnectionTips_Deactivate(object sender, EventArgs e)
        {
            UltraStatusPanel sPanel = this.ultraStatusBar1.Panels["ConnectionStatus"];
            Rectangle rect = ultraStatusBar1.ClientRectangle;
            rect = new Rectangle(rect.X, rect.Y, sPanel.Width, rect.Height);
            if (!ultraStatusBar1.RectangleToScreen(rect).Contains(Cursor.Position))
                _dlgConnectionTips.Hide();
            else
                _dlgConnectionTips.Activate();
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
            form.Toolbar.Appearance.BackColor = Color.LightBlue;
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

            //使用快捷键
            form.KeyPreview = true;
            form.KeyDown += new KeyEventHandler(form_KeyDown);

            ((System.ComponentModel.ISupportInitialize)(form.Toolbar)).EndInit();


        }

        void form_KeyDown(object sender, KeyEventArgs e)
        {
            BipForm form = sender as BipForm;
            if (e.Alt && e.KeyCode > Keys.D0 && e.KeyCode < Keys.A)
            {
                int index = (int)e.KeyCode - 49;
                if (index < form.ToolbarButtonList.Count)
                {
                    form.ToolClick(form.Toolbar,new ToolClickEventArgs(form.Toolbar.Tools[index],new ListToolItem(form.ToolbarButtonList[index].Key)));
                }
            }
        }
        #endregion

        private void timerNetwork_Tick(object sender, EventArgs e)
        {
            ServerStatus status = null;
            try
            {
                status = this.FindOne<ServerStatus>(Globals.SERVERINFO_SERVICE_NAME, "getServerStatus", new object[0]);
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
}
