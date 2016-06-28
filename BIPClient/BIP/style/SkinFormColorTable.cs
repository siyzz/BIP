using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace com.ccf.bip.frame.style
{
    public class SkinFormColorTable
    {
        /// <summary>
        /// 标题栏
        /// </summary>
        //private static readonly Color _captionActive =
        //    Color.FromArgb(255, 208, 150);
        //private static readonly Color _captionDeactive = 
        //    Color.FromArgb(255, 209, 255);
        //private static readonly Color _captionText =
        //    Color.FromArgb(40, 111, 152);
        //private static readonly Color _border = 
        //    Color.FromArgb(55, 126, 168);
        //private static readonly Color _innerBorder =
        //    Color.FromArgb(200, 250, 250, 250);
        //private static readonly Color _back = 
        //    Color.FromArgb(128, 208, 255);
        //private static readonly Color _controlBoxActive =
        //    Color.FromArgb(51, 153, 204);
        //private static readonly Color _controlBoxActive =
        //  Color.Transparent;
        //private static readonly Color _controlBoxDeactive =
        //    Color.FromArgb(88, 172, 218);
        //private static readonly Color _controlBoxHover =
        //    Color.FromArgb(37, 114, 151);
        //private static readonly Color _controlBoxPressed =
        //   Color.FromArgb(27, 84, 111);
        //private static readonly Color _controlCloseBoxHover =
        //    Color.FromArgb(213, 66, 22);
        //private static readonly Color _controlCloseBoxPressed =
        //    Color.FromArgb(171, 53, 17);
        //private static readonly Color _controlBoxInnerBorder =
        //    Color.FromArgb(128, 250, 250, 250);
       
        /// <summary>
        /// 标题栏
        /// </summary>
        //static string  path = Application.StartupPath + "/TextFile1.ini";
        //static INIClass cs = new INIClass(path);
        //Color cr1 = System.Drawing.ColorTranslator.FromHtml(cs.IniReadValue("BaseColor", "Color"));
        
        Color cr1 = System.Drawing.ColorTranslator.FromHtml(Temp.Color);
      //  private static readonly Color _captionActive =
         //Color.FromArgb(255, 255, 255);
     // static Color cr= System.Drawing.ColorTranslator.FromHtml(cs.IniReadValue("BaseColor", "Color"));
       // private static readonly Color _captionActive = cr;
       // private static readonly Color _captionDeactive =
          //  Color.FromArgb(255, 255, 255);
       
      // private static readonly Color _captionDeactive = cr;
         
        /// <summary>
        /// 标题名称字体颜色
        /// </summary>
        private static readonly Color _captionText =
            Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 边框颜色
        /// </summary>
        private static readonly Color _border =
            Color.FromArgb(0, 0,0);
        /// <summary>
        /// 边框内的颜色
        /// </summary>
        private static readonly Color _innerBorder =
            Color.FromArgb(0, 0, 0, 0);
        /// <summary>
        /// 界面背景颜色
        /// </summary>
        private static readonly Color _back =
            Color.FromArgb(140, 136, 255);
       /// <summary>
       /// 活动窗口的颜色
       /// </summary>
        private static readonly Color _controlBoxActive =
         Color.FromArgb(0,Color.Transparent);
        private static readonly Color _controlBoxDeactive =
            Color.FromArgb(0, 0, 0);
       /// <summary>
       /// 最大化最小化鼠标移动过去的颜色
       /// </summary>
        private static readonly Color _controlBoxHover =
            Color.FromArgb(50,Color.Transparent);
       /// <summary>
       /// 控制按钮按下时的颜色
       /// </summary>
        private static readonly Color _controlBoxPressed =
           Color.FromArgb(100, 100, 100);
       /// <summary>
       /// 关闭窗口鼠标移动过去的颜色
       /// </summary>
        private static readonly Color _controlCloseBoxHover =
           
          Color.FromArgb(141,30, 37);
       /// <summary>
       /// 当前窗口的标题栏背景色
       /// </summary>
        private static readonly Color _controlCloseBoxPressed =
            Color.FromArgb(128, 128, 255);
        
        private static readonly Color _controlBoxInnerBorder =
            Color.FromArgb(100,Color.Transparent);

        //public virtual Color CaptionActive
        //{
        //    get { return _captionActive; }
        //}

        //public virtual Color CaptionDeactive
        //{
        //    get { return _captionDeactive; }
        //}

        //public virtual Color CaptionText
        //{
        //    get { return _captionText; }
        //}

        //public virtual Color Border
        //{
        //    get { return _border; }
        //}

        //public virtual Color InnerBorder
        //{
        //    get { return _innerBorder; }
        //}

        //public virtual Color Back
        //{
        //    get { return _back; }
        //}

        //public virtual Color ControlBoxActive
        //{
        //    get { return _controlBoxActive; }
        //}

        //public virtual Color ControlBoxDeactive
        //{
        //    get { return _controlBoxDeactive; }
        //}

        //public virtual Color ControlBoxHover
        //{
        //    get { return _controlBoxHover; }
        //}

        //public virtual Color ControlBoxPressed
        //{
        //    get { return _controlBoxPressed; }
        //}

        //public virtual Color ControlCloseBoxHover
        //{
        //    get { return _controlCloseBoxHover; }
        //}

        //public virtual Color ControlCloseBoxPressed
        //{
        //    get { return _controlCloseBoxPressed; }
        //}

        //public virtual Color ControlBoxInnerBorder
        //{
        //    get { return _controlBoxInnerBorder; }
        //}

        public virtual Color CaptionActive
        {
            get { return cr1; }
        }

        public virtual Color CaptionDeactive
        {
            get { return cr1; }
        }

        public virtual Color CaptionText
        {
            get { return _captionText; }
        }

        public virtual Color Border
        {
            get { return _border; }
        }

        public virtual Color InnerBorder
        {
            get { return _innerBorder; }
        }

        public virtual Color Back
        {
            get { return cr1; }
        }

        public virtual Color ControlBoxActive
        {
            get { return _controlBoxActive; }
        }

        public virtual Color ControlBoxDeactive
        {
            get { return ControlBoxActive; }
        }

        public virtual Color ControlBoxHover
        {
            get { return _controlBoxHover; }
        }
      
        public virtual Color ControlBoxPressed
        {
            get { return ControlBoxActive; }
        }

        public virtual Color ControlCloseBoxHover
        {
            get { return _controlCloseBoxHover; }
        }

        public virtual Color ControlCloseBoxPressed
        {
            get { return _controlCloseBoxHover; }
        }
        /// <summary>
        /// 控制区边框颜色
        /// </summary>
        public virtual Color ControlBoxInnerBorder
        {
            get { return _controlBoxInnerBorder; }
        }
    }
}
