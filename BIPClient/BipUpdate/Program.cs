using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace com.ccf.bip.udp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process curProcess = Process.GetCurrentProcess();
            bool createdNew = true;//false已启动，true未启动
            System.Threading.Mutex mutex = new System.Threading.Mutex(true
                                                                    , curProcess.ProcessName
                                                                    , out createdNew);
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormUpdate());
            }
            else
            {
                Process[] processes = Process.GetProcessesByName(curProcess.ProcessName);
                if (processes != null)
                {
                    foreach (Process p in processes)
                    {
                        if (p.Id != curProcess.Id)
                        {
                            IntPtr wnd = GetWnd(p.Id,"FormUpdate","自动更新");
                            //MessageBox.Show(p.Id + "," + p.ProcessName+","+wnd);
                            SwitchToThisWindow(wnd, true);
                            break;
                        }
                    }
                }
            }
        }

        static IntPtr GetWnd(Int32 pID, String className, String text)
        {
            IntPtr h = GetTopWindow(IntPtr.Zero);
            while (h != IntPtr.Zero)
            {
                UInt32 newID;
                GetWindowThreadProcessId(h, out newID);
                if (newID == pID)
                {
                    StringBuilder sbClassName = new StringBuilder(256);
                    StringBuilder sbText = new StringBuilder(256);

                    GetClassName(h, sbClassName, 256);
                    GetWindowText(h, sbText, 256);
                        //sbClassName.ToString().IndexOf(className, StringComparison.CurrentCultureIgnoreCase)
                    if (1 >= 0 &&
                        sbText.ToString().IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        break;
                    }
                }

                h = GetWindow(h, GW_HWNDNEXT);
            }

            return h;
        }

        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        [DllImport("user32.dll")]
        static extern IntPtr GetTopWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern Int32 GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll")]
        static extern IntPtr GetWindow(IntPtr hWnd, UInt32 uCmd);
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        private static readonly UInt32 GW_HWNDNEXT = 2;
    }
}
