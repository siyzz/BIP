using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace com.ccf.bip.frame.style
{
   public class INIClass
    {
        public string inipath;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public INIClass(string INIPath)
        {
            inipath = INIPath;
        }

        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.inipath);
        }
       public INIClass()
       { }
        /// <summary>
        /// 读出INI文件
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
            return temp.ToString();
        }

        ///// <summary>
        ///// 验证文件是否存在
        ///// </summary>
        ///// <returns>布尔值</returns>
        //public bool ExistINIFile()
        //{
        //    return File.Exists(inipath);
        //}
        /// <summary>
        /// 位图的亮度调节
        /// </summary>
        /// <param name="b"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        //public static Bitmap KiLighten(Bitmap b, int degree)
        //{
        //    if (b == null)
        //    {
        //        return null;
        //    }
        //    if (degree < -255) degree = -255;
        //    if (degree > 255) degree = 255;
        //    try
        //    {
        //        int width = b.Width;
        //        int height = b.Height;
        //        int pix = 0;
        //        BitmapData data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        //        unsafe
        //        {
        //            byte* p = (byte*)data.Scan0;
        //            int offset = data.Stride - width * 3;
        //            for (int y = 0; y < height; y++)
        //            {
        //                for (int x = 0; x < width; x++)
        //                {
        //                    // 处理指定位置像素的亮度
        //                    for (int i = 0; i < 3; i++)
        //                    {
        //                        pix = p[i] + degree;
        //                        if (degree < 0) p[i] = (byte)Math.Max(0, pix);
        //                        if (degree > 0) p[i] = (byte)Math.Min(255, pix);
        //                    } // i

        //                    p += 3;
        //                } // x
        //                p += offset;
        //            } // y
        //        }
        //        b.UnlockBits(data);
        //        return b;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
       public static Bitmap KiLighten(Bitmap b, int degree,int pegree)
       {
           if (b == null)
           {
               return null;
           }
           if (degree < -255) degree = -255;
           if (degree > 255) degree = 255;
           if (pegree < -100) pegree = -100;
           if (pegree > 100) pegree = 100;
           try
           {
               int width = b.Width;
               int height = b.Height;
               int pix = 0;
               double pixel = 0;
               double contrast = (100.0 + pegree) / 100.0;
               contrast *= contrast;
               BitmapData data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            
               unsafe
               {
                   byte* p = (byte*)data.Scan0;
                   int offset = data.Stride - width * 3;
                   for (int y = 0; y < height; y++)
                   {
                       for (int x = 0; x < width; x++)
                       {
  
                           
                           for (int i = 0; i < 3; i++)
                           {
                                //处理指定位置像素的亮度
                               pix = p[i] + degree;
                               if (degree < 0) p[i] = (byte)Math.Max(0, pix);
                               if (degree > 0) p[i] = (byte)Math.Min(255, pix);
                               //处理指定位置像素的对比度

                               pixel = ((p[i] / 255.0 - 0.5) * contrast + 0.5) * 255;
                               if (pixel < 0) pixel = 0;
                               if (pixel > 255) pixel = 255;
                               p[i] = (byte)pixel;

                               //处理图像渐变效果
                            
                           } // i
                          
                           p += 3;
                       } // x
                       p += offset;
                   } // y
               }
               b.UnlockBits(data);
               return b;
           }
           catch
           {
               return null;
           }
       }

             
       public static Bitmap Danhua(Bitmap bt) 
       {
           Bitmap bt1 = bt;
           float r, g, b, k = 0;
           Color temp = new Color();

           for (int i = 0; i < bt.Height; i++)
           {
               int count = 0;
               for (int j = 0; j < bt.Width; j++)
               {
                   r = bt.GetPixel(j, i).R + k;
                   g = bt.GetPixel(j, i).G + k;
                   b = bt.GetPixel(j, i).B + k;
                   if (r > 255)
                   {
                       r = 255;

                   }
                   if (g > 255)
                   {
                       g = 255;

                   }
                   if (b > 255)
                   {
                       b = 255;

                   }
                   if (r == 255 && b == 255 && g == 255)
                   {
                       count++;
                   }
                   temp = Color.FromArgb(255,Convert.ToInt32(r),Convert.ToInt32(g),Convert.ToInt32(b));
                   bt1.SetPixel(j, i, temp);
               }
                   k += 0.3f;
               if (count > bt.Width - 1)
               {
                   Graphics gs = Graphics.FromImage(bt1);
                   Brush bs = new SolidBrush(Color.White);
                   gs.FillRectangle(bs, 0, i + 1, bt1.Width, bt1.Height - i - 1);
                   break;
               }
           }
           return bt1;
       }

        //public static Bitmap KiContrast(Bitmap b, int pegree)
        //{
        //    if (b == null)
        //    {
        //        return null;
        //    }
        //    if (pegree < -100) pegree = -100;
        //    if (pegree > 100) pegree = 100;
        //    try
        //    {
        //        double pixel = 0;
        //        double contrast = (100.0 + pegree) / 100.0;
        //        contrast *= contrast;
        //        int width = b.Width;
        //        int height = b.Height;
        //        BitmapData data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        //        unsafe
        //        {
        //            byte* p = (byte*)data.Scan0;
        //            int offset = data.Stride - width * 3;
        //            for (int y = 0; y < height; y++)
        //            {
        //                for (int x = 0; x < width; x++)
        //                {
        //                    // 处理指定位置像素的对比度
        //                    for (int i = 0; i < 3; i++)
        //                    {
        //                        pixel = ((p[i] / 255.0 - 0.5) * contrast + 0.5) * 255;
        //                        if (pixel < 0) pixel = 0;
        //                        if (pixel > 255) pixel = 255;
        //                        p[i] = (byte)pixel;
        //                    } // i
        //                    p += 3;
        //                } // x
        //                p += offset;
        //            } // y
        //        }
        //        b.UnlockBits(data);
        //        return b;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //} 

      /// <summary>
      /// 以流的形式打开图片
      /// </summary>
      /// <param name="path"></param>
      /// <returns></returns>
       public static  Bitmap GetImage(string path) 
       { 
           FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read); 
           Image org=Image.FromStream(fs);
           Bitmap result = new Bitmap(org);
           org.Dispose();
           if (fs != null)
           {
               fs.Dispose();
           }
           return result; 
       }

    }
}
