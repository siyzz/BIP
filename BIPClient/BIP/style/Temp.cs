using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace com.ccf.bip.frame.style
{
    /// <summary>
    /// 存放全局变量
    /// </summary>
    public class Temp
    {
        static string path = Application.StartupPath + "\\Skin\\Skin.ini";
        static INIClass cs = new INIClass(path);
        public static string Color = cs.IniReadValue("BaseColor", "Color");
        public static string Image = cs.IniReadValue("Image", "value");
        public static string Opacity = cs.IniReadValue("Opacity", "value");
        public static string Open = cs.IniReadValue("Opacity", "open");
       // public static string WindowType = cs.IniReadValue("Windows", "type");
        public static string WindowType = "main";
    }
}

