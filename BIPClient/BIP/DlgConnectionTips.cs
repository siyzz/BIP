using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.form;
using com.ccf.bip.framework.form.control;
using System.Threading;
using com.ccf.bip.framework.util;
using System.Text.RegularExpressions;
using com.ccf.bip.biz.system.monitor.mapper;

namespace com.ccf.bip.frame
{
    public partial class DlgConnectionTips : BipForm
    {
        private delegate void InspectDelegate();
        private Thread thread;

        public DlgConnectionTips()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                if (!DesignMode)
                {
                    cp.ClassStyle |= 0x20000;
                }

                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rect = this.ClientRectangle;
            rect.Inflate(-1, -1);
            Brush brush = new SolidBrush(Color.FromArgb(0x88,Color.LightGray));
            e.Graphics.DrawRectangle(new Pen(brush, 2), rect);
        }

        private void DlgConnectionTips_Load(object sender, EventArgs e)
        {
            this.Padding = new Padding(2);
            BipRow row = new BipRow();
            row.IsHeader = true;
            row.Add(new BipCell() { Text = "系统名称", Width = 100 });
            row.Add(new BipCell() { Text = "服务器" });
            row.Add(new BipCell() { Text = "应用服务" });
            row.Add(new BipCell() { Text = "数据库" });
            bipTableView1.AddRow(row);

            //row = new BipRow();
            //row.Height = 30;
            //row.Add(new BipCell() { Text = "BIP平台", Width = 100 });
            //row.Add(new BipCell() { Text = "正常",ForeColor = Color.Green });
            //row.Add(new BipCell() { Text = "正常" });
            //row.Add(new BipCell() { Text = "正常" });
            //bipTableView1.AddRow(row);

            //row = new BipRow();
            //row.Height = 30;

            //row.Add(new BipCell() { Text = "产销系统", Width = 100 });
            //row.Add(new BipCell() { Text = "正常", Width = 80 });
            //row.Add(new BipCell() { Text = "正常", Width = 80 });
            //row.Add(new BipCell() { Text = "正常", Width = 80 });
            //bipTableView1.AddRow(row);

            //row = new BipRow();
            //row.Height = 30;

            //row.Add(new BipCell() { Text = "机加MES系统", Width = 100 });
            //row.Add(new BipCell() { Text = "正常", Width = 80 });
            //row.Add(new BipCell() { Text = "正常", Width = 80 });
            //row.Add(new BipCell() { Text = "正常", Width = 80 });
            //bipTableView1.AddRow(row);
        }

        private void DlgConnectionTips_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                thread = new Thread(new ThreadStart(ThreadRun));
                thread.Start();
            }
            else
            {
                if (thread != null && thread.ThreadState == ThreadState.Running)
                {
                    thread.Abort();
                }
                bipTableView1.Clear();
            }
        }

        public void ThreadRun()
        {
            InspectDelegate inspect = new InspectDelegate(InspectServer);
            Invoke(inspect);
        }

        public void InspectServer()
        {
            BipRow row = new BipRow();
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
            if(!string.IsNullOrEmpty(match.Value))
            {
                if (NetworkUtil.Ping(match.Value))
                {
                    row.Cells[1].Text = "正常";
                    row.Cells[1].ForeColor = Color.Green;

                    ServerStatus status = this.FindOne<ServerStatus>(Globals.SERVERINFO_SERVICE_NAME, "getServerStatus", new object[0]);
                }
                else
                {
                    row.Cells[1].Text = "断开";
                    row.Cells[1].ForeColor = Color.Red;
                }
            }
            else
            {
                row.Cells[1].Text = "IP错误";
                row.Cells[1].ForeColor = Color.Red;
            }
        }
    }
}
