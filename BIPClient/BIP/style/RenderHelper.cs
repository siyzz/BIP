using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace com.ccf.bip.frame.style
{
    internal class RenderHelper
    {
        internal static void RenderBackgroundInternal(
            Graphics g,
            Rectangle rect,
            Color baseColor,
            Color borderColor,
            Color innerBorderColor,
            RoundStyle style,
            bool drawBorder,
            bool drawGlass,
            LinearGradientMode mode)
        {
            RenderBackgroundInternal(
                g,
                rect,
                baseColor,
                borderColor,
                innerBorderColor,
                style,
                8,
                drawBorder,
                drawGlass,
                mode);
        }

        internal static void RenderBackgroundInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           Color innerBorderColor,
           RoundStyle style,
           int roundWidth,
           bool drawBorder,
           bool drawGlass,
           LinearGradientMode mode)
        {
            RenderBackgroundInternal(
                 g,
                 rect,
                 baseColor,
                 borderColor,
                 innerBorderColor,
                 style,
                 8,
                 0.45f,
                 drawBorder,
                 drawGlass,
                 mode);
        }
        //绘制颜色的具体方法
        internal static void RenderBackgroundInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           Color innerBorderColor,
           RoundStyle style,
           int roundWidth,
           float basePosition,
           bool drawBorder,
           bool drawGlass,
           LinearGradientMode mode)
        {
           //控制按钮的距离
            //if (drawBorder)
            //{
            //    //rect.Width--;
            //    //rect.Height--;
            //}

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 35, 24, 9);

                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                if (style != RoundStyle.None)
                {
                    //Rectangle rt = rect;
                    //rt.Height -= 1;
                    //rt.X += 1;
                    //rt.Width += 1;
                    using (GraphicsPath path =
                        GraphicsPathHelper.CreatePath(rect, roundWidth+5, style, false))
                    {
                        //填充鼠标划过的颜色
                         g.FillPath(brush, path);
                    }

                    if (baseColor.A > 80)
                    {
                        Rectangle rectTop = rect;

                        if (mode == LinearGradientMode.Vertical)
                        {
                            rectTop.Height = (int)(rectTop.Height * basePosition);
                        }
                        else
                        {
                            rectTop.Width = (int)(rect.Width * basePosition);
                        }
                        using (GraphicsPath pathTop = GraphicsPathHelper.CreatePath(
                            rectTop, roundWidth, RoundStyle.Top, false))
                        {
                            using (SolidBrush brushAlpha =
                                new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                            {
                                g.FillPath(brushAlpha, pathTop);
                            }
                        }
                    }

                    if (drawGlass)
                    {
                        RectangleF glassRect = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            glassRect.Y = rect.Y + rect.Height * basePosition;
                            glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                        }
                        else
                        {
                            glassRect.X = rect.X + rect.Width * basePosition;
                            glassRect.Width = (rect.Width - rect.Width * basePosition) * 2;
                        }
                        ControlPaintEx.DrawGlass(g, glassRect, 170, 0);
                    }

                    if (drawBorder)
                    {
                        //控制按钮划过时的边框

                        //using (GraphicsPath path =
                        //    GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                        //{
                        //    using (Pen pen = new Pen(borderColor))
                        //    {
                        //        g.DrawPath(pen, path);
                        //    }
                        //}
                        //控制按钮的偏移
                        rect.Inflate(0, -1);

                        //  GraphicsPath pathtemp = new GraphicsPath();
                        //g.DrawLine(rect.X, rect.Y, rect.X, rect.Y + rect.Height);
                        //g.DrawLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                        //pathtemp.AddLine(rect.X, rect.Y, rect.X, rect.Y + rect.Height);
                        //pathtemp.AddLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                        using (GraphicsPath path =
                            GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                        {
                            using (Pen pen = new Pen(innerBorderColor))
                            {
                                g.DrawPath(pen, path);
                                //    g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Y + rect.Height);
                                //    g.DrawLine(pen,rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                            }
                        }
                    }
                }
                if(style == RoundStyle.None)
                {
                    g.FillRectangle(brush, rect);
                    if (baseColor.A > 80)
                    {
                        Rectangle rectTop = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            rectTop.Height = (int)(rectTop.Height * basePosition);
                        }
                        else
                        {
                            rectTop.Width = (int)(rect.Width * basePosition);
                        }
                        using (SolidBrush brushAlpha =
                            new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                        {
                            g.FillRectangle(brushAlpha, rectTop);
                        }
                    }

                    if (drawGlass)
                    {
                        RectangleF glassRect = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            glassRect.Y = rect.Y + rect.Height * basePosition;
                            glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                        }
                        else
                        {
                            glassRect.X = rect.X + rect.Width * basePosition;
                            glassRect.Width = (rect.Width - rect.Width * basePosition) * 2;
                        }
                        ControlPaintEx.DrawGlass(g, glassRect, 200, 0);
                    }

                    if (drawBorder)
                    {
                        using (Pen pen = new Pen(borderColor))
                        {
                            g.DrawRectangle(pen, rect);
                        }

                        rect.Inflate(-1, -1);
                        using (Pen pen = new Pen(innerBorderColor))
                        {
                            g.DrawRectangle(pen, rect);
                        }
                        using (GraphicsPath path =
                            GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                        {
                            using (Pen pen = new Pen(borderColor))
                            {
                                g.DrawPath(pen, path);
                            }
                        }
                        ////控制按钮的偏移
                        rect.Inflate(0, -1);

                        using (Pen pen = new Pen(innerBorderColor))
                        {

                            //g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Y + rect.Height);
                            //g.DrawLine(pen, rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                        }

                    }
                }
            }
        }

        private static Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(0, a + a0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(0, r + r0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(0, g + g0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(0, b + b0); }

            return Color.FromArgb(a, r, g, b);
        }
    }
}
