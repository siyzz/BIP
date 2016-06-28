using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using com.ccf.bip.framework.form.helper;
using System.IO;
using com.ccf.bip.framework.util;

namespace com.ccf.bip.framework.form.control
{
    public partial class BipImageList : UserControl
    {
        private string imgPath;

        public string ImgPath
        {
            get { return imgPath; }
            set { imgPath = value; }
        }
        public new string Text
        {
            get { return this.ultraTextEditor1.Text; }
            set { this.ultraTextEditor1.Text = value; }
        }

        private UltraGroupBox group;
        private Panel picPanel, btnPanel;
        private Button btnOk, btnCancel;
        private MouseHook mouseHook;

        private PictureBox lastChoosePictureBox = null,picCheck = null;
        private ToolTip toolTip;

        public BipImageList()
        {
            InitializeComponent();
            group = new UltraGroupBox();
            group.Name = "bipImageGroup";
            group.ViewStyle = GroupBoxViewStyle.XP;
            group.Visible = false;
            group.Width = 300;
            group.Height = 200;
            group.BorderStyle = GroupBoxBorderStyle.None;

            picPanel = new Panel();
            picPanel.Dock = DockStyle.Fill;
            picPanel.BackColor = Color.Transparent;
            picPanel.AutoScroll = true;
            picPanel.Click += new EventHandler(picPanel_Click);
            picPanel.MouseWheel += new MouseEventHandler(picPanel_MouseWheel);
            group.Controls.Add(picPanel);

            btnPanel = new Panel();
            btnPanel.Dock = DockStyle.Bottom;
            btnPanel.Height = 40;
            btnPanel.BackColor = Color.Transparent;
            group.Controls.Add(btnPanel);

            btnOk = new Button();
            btnOk.Text = "确定";
            btnOk.Left = 80;
            btnOk.Top = 10;
            btnOk.AutoSize = false;
            btnOk.Size = new Size(50, 25);
            btnOk.Click += new EventHandler(btnOk_Click);
            btnPanel.Controls.Add(btnOk);

            btnCancel = new Button();
            btnCancel.Text = "取消";
            btnCancel.Left = 150;
            btnCancel.Top = 10;
            btnCancel.AutoSize = false;
            btnCancel.Size = new Size(50, 25);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnPanel.Controls.Add(btnCancel);

            toolTip = new ToolTip();
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            if (lastChoosePictureBox != null)
            {
                Text = lastChoosePictureBox.Tag.ToString();
                HideGroup();
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            HideGroup();
        }

        void picPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (picPanel.VerticalScroll.Visible)
            {
                int scrollValue = -e.Delta / 12;
                if (scrollValue > 0)
                {
                    picPanel.VerticalScroll.Value = (picPanel.VerticalScroll.Value + scrollValue) > picPanel.VerticalScroll.Maximum ? picPanel.VerticalScroll.Maximum : (picPanel.VerticalScroll.Value + scrollValue);
                }
                else
                {
                    picPanel.VerticalScroll.Value = (picPanel.VerticalScroll.Value + scrollValue) < picPanel.VerticalScroll.Minimum ? picPanel.VerticalScroll.Minimum : (picPanel.VerticalScroll.Value + scrollValue);
                }

                picPanel.Refresh();
                picPanel.Invalidate();
                picPanel.Update();
            }
        }

        void picPanel_Click(object sender, EventArgs e)
        {
            picPanel.Focus();
        }

        public BipImageList(string imgPath) : this()
        {
            this.imgPath = imgPath;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Control baseControl = ControlHelper.GetBaseControl(this);
            group.Parent = this.FindForm();

            mouseHook = new MouseHook();
            mouseHook.OnMouseActivity += new MouseEventHandler(mouseHook_OnMouseActivity);

            if (!String.IsNullOrEmpty(imgPath) && Directory.Exists(imgPath))
            {
                DirectoryInfo direct = new DirectoryInfo(imgPath);
                FileInfo[] files = direct.GetFiles("*.png");
                int i = 0;
                int x = 0, y = 0;
                foreach (FileInfo file in files)
                {
                    PictureBox pic = new PictureBox();
                    pic.Size = new Size(32, 32);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Image = Image.FromFile(file.FullName);
                    string picName = file.Name.Substring(0, file.Name.LastIndexOf('.'));
                    pic.Name = "bipImaege" + picName;
                    pic.Tag = picName;
                    pic.Cursor = Cursors.Hand;
                    pic.Click += new EventHandler(pic_Click);
                    pic.MouseEnter += new EventHandler(pic_MouseEnter);
                    pic.MouseLeave += new EventHandler(pic_MouseLeave);
                    x = i % 7 * (32+6) + 10;
                    y = i / 7 * (32+6) + 10;
                    pic.Location = new Point(x, y);
                    pic.SendToBack();
                    picPanel.Controls.Add(pic);
                    i++;
                }
            }

            picCheck = new PictureBox();
            picCheck.Size = new Size(12, 12);
            picCheck.Image = ResourceImg.check;
            picCheck.Visible = false;
            picCheck.SizeMode = PictureBoxSizeMode.StretchImage;
            picCheck.BackColor = Color.Transparent;
            picPanel.Controls.Add(picCheck);
        }

        void pic_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(sender as PictureBox);
        }

        void pic_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            toolTip.Show(pic.Tag.ToString(),pic);
        }

        void pic_Click(object sender, EventArgs e)
        {
            if (lastChoosePictureBox != null)
            {
                lastChoosePictureBox.BorderStyle = BorderStyle.None;

            }
            (sender as PictureBox).BorderStyle = BorderStyle.FixedSingle;
            lastChoosePictureBox = sender as PictureBox;
            picCheck.Visible = true;
            picCheck.BringToFront();
            picCheck.Location = new Point(lastChoosePictureBox.Left + 20, lastChoosePictureBox.Top + 20);

            picPanel.Focus();
        }

        void mouseHook_OnMouseActivity(object sender, MouseEventArgs e)
        {
            //ultraTextEditor1.Text = e.Button.ToString() + "-" + e.Clicks.ToString() + "-" + e.Location.ToString();
            if (group.Visible && e.Clicks > 0)
            {
                Point groupPoint = group.PointToScreen(new Point(0,0));
                if (e.X < groupPoint.X || e.Y < groupPoint.Y || e.X > group.Width + groupPoint.X || e.Y > group.Height + groupPoint.Y)
                {
                    HideGroup();
                }
            }
        }

        private void ultraTextEditor1_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (e.Button.Key.Equals("Choose"))
            {
                group.Show();
                mouseHook.Start();
                group.Top = ControlHelper.GetAbsoluteTop(this);
                group.Left = ControlHelper.GetAbsoluteLeft(this) + this.Width;
                group.BringToFront();
            }
        }

        private void HideGroup()
        {
            mouseHook.Stop();
            group.Visible = false;
            if (lastChoosePictureBox != null)
            {
                lastChoosePictureBox.BorderStyle = BorderStyle.None;
            }
            lastChoosePictureBox = null;
            picCheck.Visible = false;
        }
    }
}
