using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using com.ccf.bip.framework.core;

namespace com.ccf.bip.frame.style
{
    public class SkinFormProfessionalRenderer : SkinFormRenderer
    {
        private SkinFormColorTable _colorTable;

        public SkinFormProfessionalRenderer()
            : base()
        {
        }

        public SkinFormProfessionalRenderer(SkinFormColorTable colortable)
            : base()
        {
            _colorTable = colortable;
        }

        public SkinFormColorTable ColorTable
        {
            get 
            {
                if (_colorTable == null)
                {
                    _colorTable = new SkinFormColorTable();
                }
                return _colorTable;
            }
        }

        public override Region CreateRegion(SkinForm form)
        {
            Rectangle rect = new Rectangle(Point.Empty, form.Size);

            using (GraphicsPath path = GraphicsPathHelper.CreatePath(
                rect,
                form.Radius,
                form.RoundStyle,
                false))
            {
                return new Region(path);
            }
        }
        /// <summary>
        /// 窗体的背景颜色
        /// </summary>
        /// <param name="form"></param>
        public override void InitSkinForm(SkinForm form)
        {
            //form.BackColor = Color.LightBlue;// ColorTable.Back;
        }
        //绘制标题栏(包括标题栏图片，标题栏文字,标题栏背景色)
        protected override void OnRenderSkinFormCaption(
            SkinFormCaptionRenderEventArgs e)
        {
            Graphics g = e.Graphics;//新建一个画刷
            Rectangle rect = e.ClipRectangle;//矩形
            SkinForm form = e.SkinForm;
            Rectangle iconRect = form.IconRect;//标题栏图标位置宽度
            Rectangle textRect = Rectangle.Empty;

            bool closeBox = form.ControlBox;//标题栏关闭按钮
            bool minimizeBox = form.ControlBox && form.MinimizeBox;//最大化最小化按钮
            bool maximizeBox = form.ControlBox && form.MaximizeBox;

            int textWidthDec = 0;
            if (closeBox)
            {
                textWidthDec += form.CloseBoxSize.Width + form.ControlBoxOffset.X;
            }

            if (maximizeBox)
            {
                textWidthDec += form.MaximizeBoxSize.Width + form.ControlBoxSpace;
            }

            if (minimizeBox)
            {
                textWidthDec += form.MinimizeBoxSize.Width + form.ControlBoxSpace;
            }

            textRect = new Rectangle(
                iconRect.Right + 3,
                form.BorderWidth,
                rect.Width - iconRect.Right - textWidthDec - 6,
                rect.Height - form.BorderWidth);

            using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
            {
               
                
                //DrawCaptionBackground(//重绘标题栏背景颜色，暂时过滤掉标题栏背景颜色，用图片作为整体的背景，当需要时放开即可
                //    g,
                //    rect,
                //    e.Active);
                //绘制标题图片
                if (form.ShowIcon && form.Icon != null)
                {
                    DrawIcon(g, iconRect, form.Icon);
                }
                //绘制文字
                if (!string.IsNullOrEmpty(form.Text))
                {
                    DrawCaptionText(
                        g,
                        textRect,
                        form.Text,
                        form.CaptionFont);
                }
            }
            //实时监控背景颜色的改变
            InitSkinForm(e.SkinForm);
           
            //监控透明度的变化
            double value = 100;
            if (Temp.Open == "True")
            {
                value = double.Parse(Temp.Opacity);
                e.SkinForm.Opacity = (100 - value) / 100.0;
            }
            else
            {
                e.SkinForm.Opacity = 1;
            }
           
           
        }
        /// <summary>
        /// 绘制边框颜色
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderSkinFormBorder(
            SkinFormBorderRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
            {
                DrawBorder(
                    g,
                    e.ClipRectangle,
                   e.SkinForm.RoundStyle,
                   // RoundStyle.None,
                    e.SkinForm.Radius);
            }
        }

       //绘制背景颜色
        protected override void OnRenderSkinFormBackground(
            SkinFormBackgroundRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.ClipRectangle;
            SkinForm form = e.SkinForm;
            using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
            {
                //g.FillRectangle(Brushes.LightBlue, rect);
                //e.SkinForm.BackgroundImageLayout = ImageLayout.Stretch;

                //string imagei = Temp.Image;
                //Bitmap bt;
                //if (Temp.Image == "")
                //{
                //    bt = new Bitmap(Resource1.background);// new Bitmap(Image.FromFile(Globals.AppPath + "\\resource\\image\\background.jpg"));
                //}
                //else
                //{
                //    bt = new Bitmap(INIClass.GetImage(imagei), rect.Width, rect.Height);
                //}
              
                //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                ////using (Brush brush = new  TextureBrush(Image.FromFile(imagei)))
                //using (Brush brush = new TextureBrush(bt))
                //{
                //    rect.X -= 1;
                //    rect.Y -= 1;
                //    rect.Width += 1;
                //    rect.Height += 1;
                //    using (GraphicsPath path = GraphicsPathHelper.CreatePath(
                //       rect, form.Radius, form.RoundStyle, false))
                //    {
                //        g.FillPath(brush, path);
                //    }
                //}
            }
           // InitSkinForm(e.SkinForm);
        }
        /// <summary>
        /// 绘制控制按钮
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderSkinFormControlBox(
            SkinFormControlBoxRenderEventArgs e)
        {
             SkinForm form = e.Form;
             Graphics g = e.Graphics;
             Rectangle rect = e.ClipRectangle;
             ControlBoxState state = e.ControlBoxtate;
             bool active = e.Active;

             bool minimizeBox = form.ControlBox && form.MinimizeBox;
             bool maximizeBox = form.ControlBox && form.MaximizeBox;

            switch (e.ControlBoxStyle)
            {
                case ControlBoxStyle.Close:
                    RenderSkinFormCloseBoxInternal(
                           g,
                           rect,
                           state,
                           active,
                           minimizeBox,
                           maximizeBox);
                    break;
                case ControlBoxStyle.Maximize:
                    RenderSkinFormMaximizeBoxInternal(
                        g,
                        rect,
                        state,
                        active,
                        minimizeBox,
                        form.WindowState == FormWindowState.Maximized);
                    break;
                case ControlBoxStyle.Minimize:
                    RenderSkinFormMinimizeBoxInternal(
                       g,
                       rect,
                       state,
                       active);
                    break;
            }
        }

        #region Draw Methods
        //绘制标题栏背景颜色
        private void DrawCaptionBackground(
            Graphics g, Rectangle captionRect, bool active)
        {

            Color baseColor = active ?
                ColorTable.CaptionActive : ColorTable.CaptionDeactive;

            RenderHelper.RenderBackgroundInternal(
                g,
                captionRect,
                baseColor,
                ColorTable.Border,
                ColorTable.InnerBorder,
                RoundStyle.None,
                0,
                .25f,
                false,
                false,
                LinearGradientMode.Vertical);
        }
        //绘制标题图片
        private void DrawIcon(
            Graphics g, Rectangle iconRect, Icon icon)
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
           //调用Form的方法
            g.DrawIcon(
                icon,
                iconRect);
        }

      



        private void DrawCaptionText(
            Graphics g, Rectangle textRect, string text, Font font)
        {
            TextRenderer.DrawText(
                g,
                text,
                font,
                textRect,
                ColorTable.CaptionText,
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.Left |
                TextFormatFlags.SingleLine |
                TextFormatFlags.WordEllipsis);
        }
        /// <summary>
        /// 绘制边框颜色
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="roundStyle"></param>
        /// <param name="radius"></param>
        private void DrawBorder(
            Graphics g, Rectangle rect,RoundStyle roundStyle, int radius)
        {
           //  绘制边框时的位置
            //rect.X -= 10;
            //rect.Y -= 10;
            rect.Width -= 1;
            rect.Height -= 1;
            using (GraphicsPath path = GraphicsPathHelper.CreatePath(
                rect, radius, roundStyle, false))
            {
                using (Pen pen = new Pen(Color.LightGray, 1))//Color.LightBlue,2
                {
                    g.DrawPath(pen, path);
                }
            }
           /// 放在边框里又一层的颜色
            //rect.Inflate(-1, -1);
            //using (GraphicsPath path = GraphicsPathHelper.CreatePath(
            //    rect, radius, roundStyle, false))
            //{
            //    using (Pen pen = new Pen(ColorTable.InnerBorder))
            //    {
            //        g.DrawPath(pen, path);
            //    }
            //}
        }

        private void RenderSkinFormMinimizeBoxInternal(
           Graphics g,
           Rectangle rect,
           ControlBoxState state,
           bool active)
        {
            Color baseColor = ColorTable.ControlBoxActive;

            if (state == ControlBoxState.Pressed)
            {
                baseColor = ColorTable.ControlBoxPressed;
            }
            else if (state == ControlBoxState.Hover)
            {
                baseColor = ColorTable.ControlBoxHover;
            }
            else
            {
                baseColor = active ?
                    ColorTable.ControlBoxActive :
                    ColorTable.ControlBoxDeactive;
            }

            RoundStyle roundStyle = RoundStyle.BottomLeft;

            using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
            {
                RenderHelper.RenderBackgroundInternal(
                    g,
                    rect,
                    baseColor,
                    baseColor,
                    ColorTable.ControlBoxInnerBorder,
                    roundStyle,
                    6,
                    .38F,
                    true,
                    false,
                    LinearGradientMode.Vertical);

                using (Pen pen = new Pen(Color.LightBlue))
                {
                    g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
                }

                using (GraphicsPath path = CreateMinimizeFlagPath(rect))
                {
                    g.FillPath(Brushes.White, path);
                    using (Pen pen = new Pen(baseColor))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
        }

        private void RenderSkinFormMaximizeBoxInternal(
            Graphics g,
            Rectangle rect,
            ControlBoxState state,
            bool active,
            bool minimizeBox,
            bool maximize)
        {
            Color baseColor = ColorTable.ControlBoxActive;

            if (state == ControlBoxState.Pressed)
            {
                baseColor = ColorTable.ControlBoxPressed;
            }
            else if (state == ControlBoxState.Hover)
            {
                baseColor = ColorTable.ControlBoxHover;
            }
            else
            {
                baseColor = active ?
                    ColorTable.ControlBoxActive :
                    ColorTable.ControlBoxDeactive;
            }

            RoundStyle roundStyle = minimizeBox ?
                RoundStyle.None : RoundStyle.BottomLeft;

            using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
            {
               
                RenderHelper.RenderBackgroundInternal(
                    g,
                    rect,
                    baseColor,
                    baseColor,
                    ColorTable.ControlBoxInnerBorder,
                    roundStyle,
                    6,
                    .38F,
                    true,
                    false,
                    LinearGradientMode.Vertical);

                using (Pen pen = new Pen(Color.LightBlue))
                {
                    g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
                }

                using (GraphicsPath path = CreateMaximizeFlafPath(rect, maximize))
                {
                    g.FillPath(Brushes.White, path);
                    using (Pen pen = new Pen(baseColor))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
        }
        //绘制关闭按钮
        private void RenderSkinFormCloseBoxInternal(
            Graphics g,
            Rectangle rect,
            ControlBoxState state,
            bool active,
            bool minimizeBox,
            bool maximizeBox)
        {
            Color baseColor = ColorTable.ControlBoxActive;            

            //if (state == ControlBoxState.Pressed)
            //{
            //    baseColor = ColorTable.ControlCloseBoxPressed;
            //}
            //else if (state == ControlBoxState.Hover)
            //{
            //    baseColor = ColorTable.ControlCloseBoxHover;
            //}
            //else
            //{
                baseColor = active ?
                    ColorTable.ControlBoxActive :
                    ColorTable.ControlBoxDeactive;
            //}

            RoundStyle roundStyle = minimizeBox || maximizeBox ?
                RoundStyle.BottomRight : RoundStyle.Bottom;

            using (AntiAliasGraphics antiGraphics = new AntiAliasGraphics(g))
            {
                RenderHelper.RenderBackgroundInternal(
                    g,
                    rect,
                    baseColor,
                    baseColor,
                    ColorTable.ControlBoxInnerBorder,
                    roundStyle,
                    6,
                    .38F,
                    true,
                    false,
                    LinearGradientMode.Vertical);

                using (Pen pen = new Pen(Color.LightBlue))
                {
                    g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
                }
                ///画关闭按钮的X
                using (GraphicsPath path = CreateCloseFlagPath(rect))
                {
                    g.FillPath(state == ControlBoxState.Hover ? Brushes.Tomato :(state == ControlBoxState.Pressed ? Brushes.Red : Brushes.White), path);
                    using (Pen pen = new Pen(baseColor))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
        }

        #endregion

        private GraphicsPath CreateCloseFlagPath(Rectangle rect)
        {
            PointF centerPoint = new PointF(
                rect.X + rect.Width / 2.0f,
                rect.Y + rect.Height / 2.0f);
        

            GraphicsPath path = new GraphicsPath();

            int length = 2;
            path.AddLine(
                centerPoint.X,
                centerPoint.Y - length,
                centerPoint.X - length,
                centerPoint.Y - 2 * length);
            path.AddLine(
                centerPoint.X - length,
                centerPoint.Y - 2 * length,
                centerPoint.X - 3 * length,
                centerPoint.Y - 2 * length);
            path.AddLine(
                centerPoint.X - 3*length,
                centerPoint.Y - 2*length,
                centerPoint.X - length,
                centerPoint.Y);
            path.AddLine(
                centerPoint.X - length,
                centerPoint.Y,
                centerPoint.X - 3*length,
                centerPoint.Y + 2*length);
            path.AddLine(
                centerPoint.X - 3*length,
                centerPoint.Y + 2*length,
                centerPoint.X - length,
                centerPoint.Y + 2*length);
            path.AddLine(
                centerPoint.X - length,
                centerPoint.Y + 2*length,
                centerPoint.X,
                centerPoint.Y + length);
            path.AddLine(
                centerPoint.X,
                centerPoint.Y + length,
                centerPoint.X + length,
                centerPoint.Y + 2*length);
            path.AddLine(
               centerPoint.X + length,
               centerPoint.Y + 2*length,
               centerPoint.X + 3*length,
               centerPoint.Y + 2*length);
            path.AddLine(
              centerPoint.X + 3*length,
              centerPoint.Y + 2*length,
              centerPoint.X + length,
              centerPoint.Y);
            path.AddLine(
             centerPoint.X + length,
             centerPoint.Y,
             centerPoint.X + 3*length,
             centerPoint.Y - 2*length);
            path.AddLine(
             centerPoint.X + 3*length,
             centerPoint.Y - 2*length,
             centerPoint.X + length,
             centerPoint.Y - 2*length);

            path.CloseFigure();
            return path;
        }

        private GraphicsPath CreateMinimizeFlagPath(Rectangle rect)
        {
            PointF centerPoint = new PointF(
                rect.X + rect.Width / 2.0f,
                rect.Y + rect.Height / 2.0f);

            GraphicsPath path = new GraphicsPath();

            path.AddRectangle(new RectangleF(
                centerPoint.X - 6,
                centerPoint.Y + 1,
                12,
                3));
            return path;
        }

        private GraphicsPath CreateMaximizeFlafPath(
            Rectangle rect, bool maximize)
        {
            PointF centerPoint = new PointF(
               rect.X + rect.Width / 2.0f,
               rect.Y + rect.Height / 2.0f);

            GraphicsPath path = new GraphicsPath();

            if (maximize)
            {
                path.AddLine(
                    centerPoint.X - 3,
                    centerPoint.Y - 3,
                    centerPoint.X - 6,
                    centerPoint.Y - 3);
                path.AddLine(
                    centerPoint.X - 6,
                    centerPoint.Y - 3,
                    centerPoint.X - 6,
                    centerPoint.Y + 5);
                path.AddLine(
                    centerPoint.X - 6,
                    centerPoint.Y + 5,
                    centerPoint.X + 3,
                    centerPoint.Y + 5);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y + 5,
                    centerPoint.X + 3,
                    centerPoint.Y + 1);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y + 1,
                    centerPoint.X + 6,
                    centerPoint.Y + 1);
                path.AddLine(
                    centerPoint.X + 6,
                    centerPoint.Y + 1,
                    centerPoint.X + 6,
                    centerPoint.Y - 6);
                path.AddLine(
                    centerPoint.X + 6,
                    centerPoint.Y - 6,
                    centerPoint.X - 3,
                    centerPoint.Y - 6);
                path.CloseFigure();

                path.AddRectangle(new RectangleF(
                    centerPoint.X - 4,
                    centerPoint.Y,
                    5,
                    3));

                path.AddLine(
                    centerPoint.X - 1,
                    centerPoint.Y - 4,
                    centerPoint.X + 4,
                    centerPoint.Y - 4);
                path.AddLine(
                    centerPoint.X + 4,
                    centerPoint.Y - 4,
                    centerPoint.X + 4,
                    centerPoint.Y - 1);
                path.AddLine(
                    centerPoint.X + 4,
                    centerPoint.Y - 1,
                    centerPoint.X + 3,
                    centerPoint.Y - 1);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y - 1,
                    centerPoint.X + 3,
                    centerPoint.Y - 3);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y - 3,
                    centerPoint.X - 1,
                    centerPoint.Y - 3);
                path.CloseFigure();
            }
            else
            {
                path.AddRectangle(new RectangleF(
                    centerPoint.X - 6,
                    centerPoint.Y - 4,
                    12,
                    8));
                path.AddRectangle(new RectangleF(
                    centerPoint.X - 3,
                    centerPoint.Y - 1,
                    6,
                    3));
            }

            return path;
        }
    }
}
