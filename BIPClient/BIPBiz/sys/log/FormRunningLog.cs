using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.form;
using com.ccf.bip.framework.core;
using Infragistics.Win.UltraWinTabControl;
using System.Threading;
using System.IO;

namespace com.ccf.bip.biz.sys.log
{
    public partial class FormRunningLog : BipForm
    {
        private delegate void AppendTextDlg(String text, Color color);
        private bool isLoading = false;

        public FormRunningLog()
        {
            InitializeComponent();
        }

        private void FormRunningLog_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> fileNameList = this.FindList<string>(Globals.LOG_SERVICE_NAME, "findRunningLogNameList", new object[0]);
            foreach (string fileName in fileNameList)
            {
                listBox1.Items.Add(fileName);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && !isLoading)
            {
                textBox1.Text = "";
                //richTextBox1.Text = "";
                string fileName = listBox1.SelectedItem.ToString();
                ultraGroupBox2.Text = fileName;
                //Thread thread = new Thread(new ParameterizedThreadStart(ShowText));
                byte[] fileContent = this.FindOne<byte[]>(Globals.LOG_SERVICE_NAME, "findRunningLogContent", new object[] { fileName });
                textBox1.Text = Encoding.UTF8.GetString(fileContent);
                //thread.Start(fileContent);
            }
        }

        public void ShowText(object obj)
        {
            isLoading = true;
            AppendTextDlg dlg = new AppendTextDlg(AppendText);
            string text = Encoding.UTF8.GetString(obj as byte[]);
            string[] strs = text.Split("\n".ToCharArray());
            Color color = Color.Black;
            foreach (string str in strs)
            {
                if (str.StartsWith("[INFO]"))
                {
                    color = Color.Black;
                }
                else if (str.StartsWith("[WARN]"))
                {
                    color = Color.Yellow;
                }
                else if (str.StartsWith("[ERROR]"))
                {
                    color = Color.Red;
                }
                Invoke(dlg, str, color);
            }
            
            isLoading = false;
        }

        public void AppendText(string text, Color color)
        {
            //richTextBox1.AppendText(text);
            //richTextBox1.Select(richTextBox1.Text.LastIndexOf('\n') - (text.Length-1), text.Length);
            //richTextBox1.SelectionColor = color;
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Find":
                    string str = textBox2.Text.Trim();
                    FindStr(str);
                    break;
            }
        }

        private void FindStr(string str)
        {
            int start = textBox1.SelectionStart + textBox1.SelectionLength;
            string all = textBox1.Text;
            int index = all.IndexOf(str, start);
            if (index >= 0)
            {
                textBox1.Select(index, str.Length);
                textBox1.ScrollToCaret();
            }
        }
    }
}
