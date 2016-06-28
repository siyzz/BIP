using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.ccf.bip.framework.form.control
{
    public partial class ImageViewer : Form
    {
        private string _imageFileName;
        private Image _img;
        private int _thumbType = 0;//0不缩，1按宽缩，2按高缩
        private int zoom = 0;

        public ImageViewer(string imageFileName)
        {
            _imageFileName = imageFileName;
            InitializeComponent();
        }

        private void DlgImageCut_Load(object sender, EventArgs e)
        {
            _img = Image.FromFile(_imageFileName);
            //pictureBox1.Size = _img.Size;
            pictureBox1.Image = _img;
            ////计算宽高比
            double imgRate = (double)_img.Width / _img.Height;
            double winRate = (double)panel1.Width / panel1.Height;

            if (imgRate > winRate)
            {
                pictureBox1.Size = new Size(panel1.Width, _img.Height * panel1.Width / _img.Width);
                pictureBox1.Top = (panel1.Height - pictureBox1.Height) / 2;
            }
            else
            {
                pictureBox1.Size = new Size(_img.Width*panel1.Height/_img.Height, panel1.Height);
                pictureBox1.Left = (panel1.Width - pictureBox1.Width) / 2;
            }

            //判断是否需要显示缩略图
            _thumbType = (imgRate > winRate && _img.Width > pictureBox1.Width) ? 1 : ((imgRate < winRate && _img.Height > pictureBox1.Height) ? 2 : 0);
            //switch (_thumbType)
            //{
            //    case 1:
            //        pictureBox1.Image = new Bitmap(_imageFileName).GetThumbnailImage(pictureBox1.Width, _img.Height * pictureBox1.Width / _img.Width, new System.Drawing.Image.GetThumbnailImageAbort(delegate { return false; }), IntPtr.Zero);
            //        break;
            //    case 2:
            //        pictureBox1.Image = new Bitmap(_imageFileName).GetThumbnailImage(_img.Width * pictureBox1.Height/_img.Height, pictureBox1.Height, new System.Drawing.Image.GetThumbnailImageAbort(delegate { return false; }), IntPtr.Zero);
            //        break;
            //    default:
            //        pictureBox1.Image = _img;
            //        break;
            //}

            this.Focus();
            this.MouseWheel +=new MouseEventHandler(DlgImageCut_MouseWheel);
        }

        void DlgImageCut_MouseWheel(object sender, MouseEventArgs e)
        {
            int origWidht = pictureBox1.Width,origHeight = pictureBox1.Height;
            int zoomWidth = 0,zoomHeight = 0;
            int left = 0, top = 0;
            if (e.Delta > 0)//放大
            {
                if (pictureBox1.Width > _img.Width*5 || pictureBox1.Height > _img.Width*5)
                    return;
                if (pictureBox1.Width > panel1.Width || pictureBox1.Height > panel1.Height)
                    pictureBox1.Cursor = Cursors.Hand;
                zoomWidth = (int)(pictureBox1.Width * 1.1);
                zoomHeight = (int)(pictureBox1.Height * 1.1);
                pictureBox1.Size = new Size(zoomWidth, zoomHeight);
                                
                pictureBox1.Left = pictureBox1.Left + (origWidht - zoomWidth) / 2;
                pictureBox1.Top = pictureBox1.Top + (origHeight - zoomHeight) / 2;
            }
            else //缩小
            {
                if (pictureBox1.Width <= panel1.Width && pictureBox1.Height <= panel1.Height)
                {
                    pictureBox1.Cursor = Cursors.Default;
                    return;
                }
                
                zoomWidth = (int)(pictureBox1.Width / 1.1);
                zoomHeight = (int)(pictureBox1.Height / 1.1);
                if (zoomWidth < panel1.Width && zoomHeight < panel1.Height)
                {
                    if (zoomWidth / zoomHeight > panel1.Width / panel1.Height)
                    {
                        zoomHeight = zoomHeight * panel1.Width / zoomWidth;
                        zoomWidth = panel1.Width;                        
                    }
                    else
                    {
                        zoomWidth = zoomWidth * panel1.Height / zoomHeight;
                        zoomHeight = panel1.Height;                        
                    }
                }
                pictureBox1.Size = new Size(zoomWidth,zoomHeight);
                //调整位置
                if (zoomWidth / zoomHeight > panel1.Width / panel1.Height)
                {
                    pictureBox1.Left = pictureBox1.Left < 0 ? pictureBox1.Left + (origWidht - zoomWidth) / 2 : 0;
                    pictureBox1.Top = pictureBox1.Top + (origHeight - zoomHeight) / 2;
                }
                else
                {                    
                    if (pictureBox1.Left < 0)
                    {
                        left = pictureBox1.Left + (origWidht - zoomWidth) / 2;
                        if (left + pictureBox1.Width <= panel1.Width)
                        {
                            left = panel1.Width - pictureBox1.Width;
                        }
                    }
                    else
                    {
                        left = (panel1.Width - pictureBox1.Width) / 2;
                        if (left + pictureBox1.Width > panel1.Width)
                        {
                            left = 0;
                        }
                    }
                    if (pictureBox1.Top < 0)
                    {
                        top = pictureBox1.Top + (origHeight - zoomHeight) / 2;
                        if (top + pictureBox1.Height <= panel1.Height)
                        {
                            top = panel1.Height - pictureBox1.Height;
                        }
                    }
                    pictureBox1.Left = left;
                    pictureBox1.Top = top;
                }
            }
        }

        private void DlgImageCut_MouseEnter(object sender, EventArgs e)
        {
            if (!this.Focused)
            {
                this.Focus();
            }
        }

        bool canMove = false;
        int origX = 0, origY = 0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            canMove = true;
            origX = e.X;
            origY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            canMove = false;
            origX = 0;
            origY = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (canMove)
            {
                int relaX = e.X - origX;
                int relaY = e.Y - origY;

                if (pictureBox1.Left + pictureBox1.Width > panel1.Width && relaX < 0 || pictureBox1.Left < 0 && relaX > 0)
                {
                    int tmp = pictureBox1.Left + relaX;
                    tmp = relaX > 0 && tmp > 0 ? 0 : (relaX < 0 && tmp < panel1.Width - pictureBox1.Width ? panel1.Width - pictureBox1.Width : tmp);
                    pictureBox1.Left = tmp;
                }
                if (pictureBox1.Top + pictureBox1.Height > panel1.Height && relaY < 0 || pictureBox1.Top < 0 && relaY > 0)
                {
                    int tmp = pictureBox1.Top + relaY;
                    tmp = relaY > 0 && tmp > 0 ? 0 : (relaY < 0 && tmp < panel1.Height - pictureBox1.Height ? panel1.Height - pictureBox1.Height : tmp);
                    pictureBox1.Top = tmp;
                }

                //this.Text = (pictureBox1.Left + pictureBox1.Width) + "|" + relaX + "+" + (panel1.Width - pictureBox1.Left);
            }
        }
    }
}
