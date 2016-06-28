using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.form;
using System.Reflection;

namespace com.ccf.bip.biz.sys
{
    public partial class DlgBipFormPicker : BipForm
    {
        private string _dllFileName;
        private Module[] _modules;
        public string BipFormName { get; set; }

        public DlgBipFormPicker(string dllFileName)
        {
            _dllFileName = dllFileName;
            InitializeComponent();
        }

        private void DlgBipFormPicker_Load(object sender, EventArgs e)
        {
            Assembly ass = Assembly.LoadFrom(_dllFileName);
            if (ass != null)
            {
                _modules = ass.GetModules(false);
                foreach (Module module in _modules)
                {
                    cmbModule.Items.Add(module.Name);
                }
                cmbModule.SelectedIndex = 0;
            }
        }

        private void cmbModule_ValueChanged(object sender, EventArgs e)
        {
            Type[] types = _modules[cmbModule.SelectedIndex].GetTypes();
            listBox1.Items.Clear();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(BipForm)))
                    listBox1.Items.Add(type.FullName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                BipFormName = listBox1.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择一个功能！");
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if ((sender as ListBox).SelectedIndex >= 0)
            {
                btnOK_Click(null, new EventArgs());
            }
        }
    }
}
