using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.form;
using com.ccf.bip.biz.system.authorization.mapper;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using com.ccf.bip.framework.core;
using System.Collections;
using System.IO;
using com.ccf.bip.framework.form.helper;
using MetroFramework;

namespace com.ccf.bip.biz.sys
{
    public partial class FormFunction : BipForm
    {
        public FormFunction()
        {
            InitializeComponent();
        }

        public override void ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Refresh":
                    Refresh();
                    break;
                case "Add":
                    Add();
                    break;
                case "Update":
                    Update();
                    break;
                case "Delete":
                    Delete();
                    break;
            }
        }

        private void FormFunction_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private new void Refresh()
        {
            //获取功能菜单数据
            IEnumerable<SysFunction> functions = this.Find<SysFunction>(Globals.FUNCTION_SERVICE_NAME, "findFunctionListByUser", new object[] { User });
            List<SysFunction> list = new List<SysFunction>();
            list.AddRange(functions);
            //绑定到左侧菜单树，从根目录开始绑定
            ultraTree1.Nodes.Clear();
            UltraTreeHelper.FillData(list, ultraTree1,null);
            //清空所有文本框
            ultraTabControl1.Tabs[0].Selected = true;
            lblSubSystemPos.Text = "";
            txtSystemId.Text = "";
            txtSystemKey.Text = "";
            txtSystemName.Text = "";
            txtSystemUrl.Text = "";
            bilSystemIcon.Text = "";

            lblSubSystemPos.Text = "";
            lblModulePos.Text = "";
            txtSubSysId.Text = "";
            txtSubSysKey.Text = "";
            txtSubSysName.Text = "";
            bilSubSysIcon.Text = "";
            
            lblSubSystemPos.Text = "";
            lblModulePos.Text = "";
            lblFormPos.Text = "";
            txtModuleId.Text = "";
            txtModuleKey.Text = "";
            txtModuleName.Text = "";
            bilModuleIcon.Text = "";
            
            lblModulePos.Text = "";
            lblFormPos.Text = "";
            txtFormId.Text = "";
            txtFormCaption.Text = "";
            txtFormCustom.Text = "";
            txtFormUrl.Text = "";
            uteFormAssembly.Text = "";
            bilFormIcon.Text = "";
            ucbFormType.Value = 1;
            uceFormHotkey.Checked = false;
            uceFormToolbar.Checked = false;
            sysFunctionBindingSource.Clear();
        }

        private void Add()
        {
            SysFunction fun = new SysFunction();
            switch (ultraTabControl1.SelectedTab.Index)
            {
                case 0:
                    if(ValidateSystem())
                    {                     
                        fun.FunctionId = BipGuid.Guid;
                        fun.FunctionName = txtSystemName.Text.Trim();
                        fun.FunctionType = "1011";
                        fun.Image = bilSystemIcon.Text.Trim();
                        fun.Key = txtSystemKey.Text.Trim();
                        fun.Seq = (short)ultraTree1.Nodes.Count;
                        fun.Url = txtSystemUrl.Text.Trim();
                    }
                    break;
                case 1:
                    if (ValidateSubSystem())
                    {
                        if (ultraTree1.ActiveNode == null || !(ultraTree1.ActiveNode.Tag as SysFunction).FunctionType.Equals("1011"))
                        {
                            MetroMessageBox.Show(this,"请在功能菜单树选择需要配置的系统！");
                            return;
                        }
                        fun.FunctionId = BipGuid.Guid;
                        fun.FunctionName = txtSubSysName.Text.Trim();
                        fun.FunctionType = "1012";
                        fun.Image = bilSubSysIcon.Text.Trim();
                        fun.Key = txtSubSysKey.Text.Trim();
                        fun.Seq = (short)(ultraTree1.ActiveNode.Nodes.Count+1);
                        fun.ParentId = ultraTree1.ActiveNode.Key;
                    }
                    break;
                case 2:
                    if (ValidateModule())
                    {
                        if (ultraTree1.ActiveNode == null || !(ultraTree1.ActiveNode.Tag as SysFunction).FunctionType.Equals("1012"))
                        {
                            MetroMessageBox.Show(this,"请在功能菜单树选择需要配置的子系统！");
                            return;
                        }
                        fun.FunctionId = BipGuid.Guid;
                        fun.FunctionName = txtModuleName.Text.Trim();
                        fun.FunctionType = "1013";
                        fun.Image = bilModuleIcon.Text.Trim();
                        fun.Key = txtModuleKey.Text.Trim();
                        fun.Seq = (short)(ultraTree1.ActiveNode.Nodes.Count + 1);
                        fun.ParentId = ultraTree1.ActiveNode.Key;
                    }
                    break;
                case 3:
                    if (ValidateForm())
                    {
                        if (ultraTree1.ActiveNode == null || !(ultraTree1.ActiveNode.Tag as SysFunction).FunctionType.Equals("1013"))
                        {
                            MetroMessageBox.Show(this,"请在功能菜单树选择需要配置的模块！");
                            return;
                        }
                        fun.FunctionId = BipGuid.Guid;
                        fun.FunctionName = txtFormCaption.Text.Trim();
                        fun.FunctionType = "1014";
                        fun.Image = bilFormIcon.Text.Trim();
                        //fun.Key = txtFormKey.Text.Trim();
                        fun.Seq = (short)(ultraTree1.ActiveNode.Nodes.Count + 1);
                        fun.ParentId = ultraTree1.ActiveNode.Key;
                        fun.ShowToolBar = uceFormToolbar.Checked;
                        fun.UseHotKey = uceFormHotkey.Checked;
                        fun.Tag = txtFormCustom.Text.Trim();
                        fun.Assemblyname = uteFormAssembly.Text.Trim();
                        fun.Url = txtFormUrl.Text.Trim();
                        fun.FormType = ucbFormType.Value.ToString();
                        //添加按钮
                        if (ultraGrid1.Rows.Count > 0)
                        {
                            fun.ButtonList = new ArrayList();
                            foreach (UltraGridRow row in ultraGrid1.Rows)
                            {
                                SysFunction btn = new SysFunction();
                                btn.FunctionId = BipGuid.Guid;
                                btn.FunctionName = row.Cells["FunctionName"].Text;
                                btn.FunctionType = "1015";
                                btn.Image = row.Cells["Image"].Text;
                                btn.Key = row.Cells["Key"].Text;
                                btn.ParentId = fun.FunctionId;
                                btn.Seq = (short)(row.Index + 1);
                                fun.ButtonList.Add(btn);
                            }
                        }
                    }
                    break;
                default:
                    fun = null;
                    break;
            }
            if (fun != null)
            {
                this.Update(Globals.FUNCTION_SERVICE_NAME, "add", new object[] { fun });
                Refresh();
                UltraTreeNode node = this.ultraTree1.GetNodeByKey(fun.FunctionId);
                ultraTree1.ActiveNode = node;
                ExpandParents(node);
            }
        }

        private new void Update()
        {
            SysFunction fun = new SysFunction();
            switch (ultraTabControl1.SelectedTab.Index)
            {
                case 0:
                    if (ValidateSystem())
                    {
                        if (ultraTree1.ActiveNode == null || !(ultraTree1.ActiveNode.Tag as SysFunction).FunctionType.Equals("1011"))
                        {
                            MetroMessageBox.Show(this,"请在功能菜单树选择需要修改的系统！");
                            return;
                        }
                        fun = ultraTree1.ActiveNode.Tag as SysFunction;
                        fun.FunctionName = txtSystemName.Text.Trim();
                        fun.Image = bilSystemIcon.Text.Trim();
                        fun.Key = txtSystemKey.Text.Trim();
                        fun.Url = txtSystemUrl.Text.Trim();
                    }
                    break;
                case 1:
                    if (ValidateSubSystem())
                    {
                        if (ultraTree1.ActiveNode == null || !(ultraTree1.ActiveNode.Tag as SysFunction).FunctionType.Equals("1012"))
                        {
                            MetroMessageBox.Show(this,"请在功能菜单树选择需要修改的子系统！");
                            return;
                        }
                        fun = ultraTree1.ActiveNode.Tag as SysFunction;
                        fun.FunctionName = txtSubSysName.Text.Trim();
                        fun.Image = bilSubSysIcon.Text.Trim();
                        fun.Key = txtSubSysKey.Text.Trim();
                    }
                    break;
                case 2:
                    if (ValidateModule())
                    {
                        if (ultraTree1.ActiveNode == null || !(ultraTree1.ActiveNode.Tag as SysFunction).FunctionType.Equals("1013"))
                        {
                            MetroMessageBox.Show(this,"请在功能菜单树选择需要修改的模块！");
                            return;
                        }
                        fun = ultraTree1.ActiveNode.Tag as SysFunction;
                        fun.FunctionName = txtModuleName.Text.Trim();
                        fun.Image = bilModuleIcon.Text.Trim();
                        fun.Key = txtModuleKey.Text.Trim();
                    }
                    break;
                case 3:
                    if (ValidateForm())
                    {
                        if (ultraTree1.ActiveNode == null || !(ultraTree1.ActiveNode.Tag as SysFunction).FunctionType.Equals("1014"))
                        {
                            MetroMessageBox.Show(this,"请在功能菜单树选择需要修改的界面！");
                            return;
                        }
                        fun = ultraTree1.ActiveNode.Tag as SysFunction;
                        fun.FunctionName = txtFormCaption.Text.Trim();
                        fun.Image = bilFormIcon.Text.Trim();
                        fun.Assemblyname = uteFormAssembly.Text.Trim();
                        fun.Url = txtFormUrl.Text.Trim();
                        fun.Tag = txtFormCustom.Text.Trim();
                        fun.ShowToolBar = uceFormToolbar.Checked;
                        fun.UseHotKey = uceFormHotkey.Checked;
                        fun.ButtonList = new ArrayList();
                        foreach (UltraGridRow row in ultraGrid1.Rows)
                        {
                            SysFunction btn = row.ListObject as SysFunction;
                            btn.Seq = (short)(row.Index+1);
                            if (String.IsNullOrEmpty(btn.FunctionId))
                            {
                                btn.FunctionId = BipGuid.Guid;
                                btn.FunctionType = "1015";
                            }
                            fun.ButtonList.Add(btn);
                        }
                    }
                    break;
                default:
                    fun = null;
                    break;
            }
            if (fun != null)
            {
                this.Update(Globals.FUNCTION_SERVICE_NAME, "update", new object[] { fun });
                Refresh();
                UltraTreeNode node = this.ultraTree1.GetNodeByKey(fun.FunctionId);
                ultraTree1.ActiveNode = node;
                ExpandParents(node);
            }
        }

        private void Delete()
        {
            if (ultraTree1.ActiveNode != null)
            {
                string functionId = ultraTree1.ActiveNode.Key;
                if (ultraTree1.ActiveNode.Nodes.Count > 0)
                {
                    MetroMessageBox.Show(this,"请先删除下级菜单！");
                    return;
                }

                if (MetroMessageBox.Show(this,"是否确认删除" + ultraTree1.ActiveNode.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Update(Globals.FUNCTION_SERVICE_NAME, "delete", new object[] { functionId });
                    UltraTreeNode pNode = ultraTree1.ActiveNode.Parent;
                    Refresh();
                    if (pNode != null)
                    {
                        Refresh();
                        UltraTreeNode node = this.ultraTree1.GetNodeByKey(pNode.Key);
                        ultraTree1.ActiveNode = node;
                        ExpandParents(node);
                    }
                }
            }
        }

        /// <summary>
        /// 校验系统标签页内容输入
        /// </summary>
        /// <returns></returns>
        private bool ValidateSystem()
        {
            bool ret = false;
            if(String.IsNullOrEmpty(txtSystemName.Text.Trim()))
            {
                MetroMessageBox.Show(this,"请输入系统名称！");
            }
            else if(String.IsNullOrEmpty(txtSystemUrl.Text.Trim()))
            {
                MetroMessageBox.Show(this,"请输入系统服务地址！");
            }
            else if (String.IsNullOrEmpty(txtSystemKey.Text.Trim()))
            {
                MetroMessageBox.Show(this,"请输入系统关键字！");
            }
            else
            {
                ret = true;
            }

            return ret;
        }

        private bool ValidateSubSystem()
        {
            bool ret = false;
            if (String.IsNullOrEmpty(txtSubSysName.Text.Trim()))
            {
                MetroMessageBox.Show(this,"请输入系统名称！");
            }
            else if (String.IsNullOrEmpty(txtSubSysKey.Text.Trim()))
            {
                MetroMessageBox.Show(this,"请输入系统关键字！");
            }
            else
            {
                ret = true;
            }
            return ret;
        }

        private bool ValidateModule()
        {
            bool ret = false;
            if (String.IsNullOrEmpty(txtModuleName.Text.Trim()))
            {
                MetroMessageBox.Show(this,"请输入模块名称！");
            }
            else if (String.IsNullOrEmpty(txtModuleKey.Text.Trim()))
            {
                MetroMessageBox.Show(this,"请输入模块关键字！");
            }
            else
            {
                ret = true;
            }
            return ret;
        }

        private bool ValidateForm()
        {
            bool ret = false;
            if (ucbFormType.SelectedIndex < 0)
            {
                MetroMessageBox.Show(this,"请选择界面类型！");
            }
            else if (String.IsNullOrEmpty(uteFormAssembly.Text.Trim()))
            {
                MetroMessageBox.Show(this,"请选择界面所属程序集！");
            }
            else if(String.IsNullOrEmpty(txtFormUrl.Text.Trim()))
            {
                MetroMessageBox.Show(this,"请选择界面引用！");
            }
            else if (String.IsNullOrEmpty(txtFormCaption.Text.Trim()))
            {
                MetroMessageBox.Show(this,"请输入界面标题！");
            }
            else
            {
                ret = true;
            }
            return ret;
        }

        private bool ValidateButton()
        {
            bool ret = true;
            UltraGridRow row = this.ultraGridRowEditTemplate1.Row;
            string key = row.Cells["Key"].Text;
            string caption = row.Cells["FunctionName"].Text;
            string image = row.Cells["Image"].Text;

            if (String.IsNullOrEmpty(key))
            {
                ret = false;
                MetroMessageBox.Show(this,"请输入按钮KEY值！");
            }
            else if (String.IsNullOrEmpty(caption))
            {
                ret = false;
                MetroMessageBox.Show(this,"请输入按钮名称！");
            }
            else
            {
                foreach (UltraGridRow r in ultraGrid1.Rows)
                {
                    if (r.Cells["Key"].Value.ToString().Equals(key) && String.IsNullOrEmpty(r.Cells["FunctionId"].Text) && r.Index != 0)
                    {
                        ret = false;
                        MetroMessageBox.Show(this,"同一界面的按钮不能输入重复的KEY值！");
                        break;
                    }
                }

            }
            return ret;
        }

        private void ExpandParents(UltraTreeNode node)
        {
            UltraTreeNode parent = node.Parent;
            while (parent != null)
            {
                parent.Expanded = true;
                parent = parent.Parent;
            }
        }

        private void ultraTree1_AfterActivate(object sender, NodeEventArgs e)
        {
            UltraTree tree = sender as UltraTree;
            if (tree.ActiveNode != null)
            {
                FunctionNodeClick(tree.ActiveNode);
            }
        }

        private string AppendTreeText(UltraTreeNode node,NodeTextAppendType type)
        {
            List<string> list = new List<string>();
            UltraTreeNode tmpNode = null;
            switch (type)
            {
                case NodeTextAppendType.Parent:
                    if (node.Parent != null)
                        tmpNode = node.Parent.Parent;
                    break;
                case NodeTextAppendType.Current:
                    tmpNode = node.Parent;
                    break;
                case NodeTextAppendType.Child:
                    tmpNode = node;
                    break;
            }
            if(tmpNode != null)
            {
                do
                {
                    list.Insert(0, tmpNode.Text);
                }
                while ((tmpNode = tmpNode.Parent) != null);
            }

            return string.Join("→", list.ToArray());
        }

        private void FunctionNodeClick(UltraTreeNode node)
        {
            SysFunction fun = node.Tag as SysFunction;
            switch (fun.FunctionType)
            {
                case "1011":
                    ultraTabControl1.Tabs[0].Selected = true;
                    lblSubSystemPos.Text = AppendTreeText(node,NodeTextAppendType.Child);
                    txtSystemId.Text = fun.FunctionId;
                    txtSystemKey.Text = fun.Key;
                    txtSystemName.Text = fun.FunctionName;
                    txtSystemUrl.Text = fun.Url;
                    bilSystemIcon.Text = !string.IsNullOrEmpty(fun.Image) ? fun.Image : "";
                    break;
                case "1012":
                    ultraTabControl1.Tabs[1].Selected = true;
                    lblSubSystemPos.Text = AppendTreeText(node, NodeTextAppendType.Current);
                    lblModulePos.Text = AppendTreeText(node,NodeTextAppendType.Child);
                    txtSubSysId.Text = fun.FunctionId;
                    txtSubSysKey.Text = fun.Key;
                    txtSubSysName.Text = fun.FunctionName;
                    bilSubSysIcon.Text = fun.Image;
                    break;
                case "1013":
                    ultraTabControl1.Tabs[2].Selected = true;
                    lblSubSystemPos.Text = AppendTreeText(node, NodeTextAppendType.Parent);
                    lblModulePos.Text = AppendTreeText(node, NodeTextAppendType.Current);
                    lblFormPos.Text = AppendTreeText(node, NodeTextAppendType.Child);
                    txtModuleId.Text = fun.FunctionId;
                    txtModuleKey.Text = fun.Key;
                    txtModuleName.Text = fun.FunctionName;
                    bilModuleIcon.Text = fun.Image;
                    break;
                case "1014":
                    ultraTabControl1.Tabs[3].Selected = true;
                    lblModulePos.Text = AppendTreeText(node, NodeTextAppendType.Parent);
                    lblFormPos.Text = AppendTreeText(node, NodeTextAppendType.Current);
                    txtFormId.Text = fun.FunctionId;
                    txtFormCaption.Text = fun.FunctionName;
                    txtFormCustom.Text = fun.Tag;
                    txtFormUrl.Text = fun.Url;
                    uteFormAssembly.Text = fun.Assemblyname;
                    bilFormIcon.Text = fun.Image;
                    ucbFormType.Value = fun.FormType;
                    uceFormHotkey.Checked = fun.UseHotKey;
                    uceFormToolbar.Checked = fun.ShowToolBar;
                    BandButtonGrid(fun.FunctionId);
                    break;
            }
        }

        private void BandButtonGrid(string formId)
        {
            List<SysFunction> buttonList = new List<SysFunction>();
            buttonList.AddRange(this.Find<SysFunction>(Globals.FUNCTION_SERVICE_NAME, "findButtonList", new object[] { formId }));
            sysFunctionBindingSource.DataSource = buttonList;
        }

        private void btnTemplateOk_Click(object sender, EventArgs e)
        {
            // This code was automatically generated by the RowEditTemplate Wizard
            // 
            // Close the template and save any pending changes.
            if (ValidateButton())
            {
                if (ugcpKey.Enabled)
                {
                    UltraGridRow row = this.ultraGridRowEditTemplate1.Row;
                    SysFunction btn = new SysFunction();
                    btn.Key = row.Cells["Key"].Value.ToString();
                    btn.FunctionName = row.Cells["FunctionName"].Value.ToString();
                    btn.Image = row.Cells["Image"].Value != null ? row.Cells["Image"].Value.ToString() : "";
                    sysFunctionBindingSource.Add(btn);                    
                }
                this.ultraGridRowEditTemplate1.Close(!ugcpKey.Enabled);
            }
        }

        private void btnTemplateCancel_Click(object sender, EventArgs e)
        {
            // This code was automatically generated by the RowEditTemplate Wizard
            // 
            // Close the template and discard any pending changes.
            this.ultraGridRowEditTemplate1.Close(false);

        }

        private void btnTemplateDel_Click(object sender, EventArgs e)
        {
            ultraGridRowEditTemplate1.Row.Delete(false);
        }

        private void ultraGridRowEditTemplate1_RowChanged(object sender, RowEditTemplateRowChangedEventArgs e)
        {
            if (this.ultraGridRowEditTemplate1.Row != null)
            {
                string key = ultraGridRowEditTemplate1.Row.Cells["Key"].Text;
                this.ugcpKey.Enabled = String.IsNullOrEmpty(key);
                this.metroButtonDel.Visible = !String.IsNullOrEmpty(key);

                this.pictureBox1.Image = !String.IsNullOrEmpty(this.ugcpImage.Text) ? Image.FromFile("./resource/image/button/" + this.ugcpImage.Text + ".png") : null;
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Globals.AppPath + "\\resource\\image\\button";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string fullName = openFileDialog1.FileName;
                if (fullName.Substring(0, fullName.LastIndexOf(Path.DirectorySeparatorChar)).Equals(openFileDialog1.InitialDirectory))
                {
                    this.pictureBox1.Image = Image.FromFile(fullName);
                    this.ultraGridRowEditTemplate1.Row.Cells["Image"].Value = openFileDialog1.SafeFileName.Substring(0, openFileDialog1.SafeFileName.LastIndexOf('.'));
                }
                else
                {
                    MetroMessageBox.Show(this,"只能选择默认路径下的图片！");
                }
            }           
        }

        private void uteFormAssembly_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            switch (e.Button.Key)
            {
                case "Choose":
                    openFileDialogAssembly.InitialDirectory = Globals.AppPath;
                    if (openFileDialogAssembly.ShowDialog(this) == DialogResult.OK)
                    {
                        string fullName = openFileDialogAssembly.FileName;
                        if (fullName.Substring(0, fullName.LastIndexOf(Path.DirectorySeparatorChar)).Equals(openFileDialogAssembly.InitialDirectory))
                        {
                            DlgBipFormPicker dlg = new DlgBipFormPicker(fullName);
                            if (dlg.ShowDialog(this) == DialogResult.OK)
                            {
                                string fileName = openFileDialogAssembly.SafeFileName;
                                uteFormAssembly.Text = fileName.Substring(0, fileName.LastIndexOf('.'));
                                txtFormUrl.Text = dlg.BipFormName;
                            }                            
                        }
                        else
                        {
                            MetroMessageBox.Show(this,"只能选择默认路径下的动态链接库文件！");
                        }
                    }
                    break;
            }
        }
    }

    enum NodeTextAppendType
    {
        Parent,
        Current,
        Child
    }
}
