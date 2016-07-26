using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIPTest
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormFile form = new FormFile();
            form.Action = new com.ccf.bip.framework.core.BipAction("http://127.0.0.1:8082/BIP");
            form.ShowDialog(this);
        }
    }
}
