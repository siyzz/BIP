using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.ccf.bip.framework.form.control
{
    public partial class IconTextBox : UserControl
    {
        private Image image;
        public Image Image
        {
            get { return this.pictureBox1.Image; }
            set { this.pictureBox1.Image = value; }
        }

        private Font font;
        public Font Font
        {
            get { return this.textBox1.Font; }
            set { this.textBox1.Font = value; }
        }

        private string text;
        public string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private char passwordChar;

        public char PasswordChar
        {
            get { return this.textBox1.PasswordChar; }
            set { this.textBox1.PasswordChar = value; }
        }

        public IconTextBox()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            pictureBox1.Width = pictureBox1.Height;
        }

        private void IconTextBox_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Padding = new Padding(5, 5, 5, 5);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }
    }
}
