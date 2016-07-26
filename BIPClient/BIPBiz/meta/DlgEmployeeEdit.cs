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
using com.ccf.bip.biz.metadata.dictionary.mapper;
using com.ccf.bip.framework.server;
using com.ccf.bip.biz.metadata.employee.mapper;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using com.ccf.bip.framework.util;
using com.ccf.bip.biz.metadata.org.mapper;
using MetroFramework.Forms;

namespace com.ccf.bip.biz.meta
{
    public partial class DlgEmployeeEdit : BipMetroForm
    {
        private SysEmployee _employee;

        public SysEmployee Employee
        {
          get { return _employee; }
          set { _employee = value; }
        }

        private string _organizationId;

        public string OrganizationId
        {
            get { return _organizationId; }
            set { _organizationId = value; }
        }

        private EditType _type;
        internal EditType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public DlgEmployeeEdit(SysEmployee employee,EditType type)
        {
            _type = type;
            _employee = employee;
            InitializeComponent();
        }

        public DlgEmployeeEdit(SysEmployee employee, EditType type, BipAction action)
            : this(employee,type)
        {
            this.Action = action;
        }

        private void FormEmployeeEdit_Load(object sender, EventArgs e)
        {
            InitControl();

            if (_employee != null && _type == EditType.Update)
            {
                //窗体编辑控件赋值
                txtEmployeeAddress.Text = Employee.Address;
                txtEmployeeCode.Text = Employee.EmployeeCode;
                txtEmployeeIp.Text = Employee.Ip;
                txtEmployeeMail.Text = Employee.Email;
                txtEmployeeName.Text = Employee.EmployeeName;
                txtEmployeePhone.Text = Employee.Phone;
                txtEmployeeRemark.Text = Employee.Remark;
                uneEmployeeAge.Value = Employee.Age;
                cbtEmployeeOrg.Text = Employee.OrganizationName;
                uosEmployeeSex.Value = Employee.Sex.Equals("男") ? 1 : 0;
                if (Employee.Photo != null && Employee.Photo.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(Employee.Photo);
                    picEmployeePhoto.Image = Image.FromStream(ms);
                }
            }

            if (_type == EditType.Add)
            {
                cbtEmployeeOrg.Value = this.OrganizationId;
                cbtEmployeeOrg.Enabled = false;
            }
        }

        private void InitControl()
        {
            IEnumerable<SysOrganization> enums = this.Find<SysOrganization>(Globals.ORGANIZATION_SERVICE_NAME, "findAll", new object[0]);
            List<SysOrganization> orgList = new List<SysOrganization>();
            orgList.AddRange(enums);
            FillData(orgList,cbtEmployeeOrg.Nodes);
        }

        private void FillData(List<SysOrganization> list, TreeNodeCollection nodes)
        {
            TreeNode node = null;
            nodes.Clear();

            //获取最高组织节点
            List<SysOrganization> orgList = list.FindAll(o => string.IsNullOrEmpty(o.ParentId));
            foreach (SysOrganization org in orgList)
            {
                node = new TreeNode();
                node.Name = org.OrganizationId;
                node.Text = org.OrganizationName;
                nodes.Add(node);

                FillData(list, node);
            }
        }

        private void FillData(List<SysOrganization> list, TreeNode node)
        {
            TreeNode subNode = null;
            List<SysOrganization> orgList = list.FindAll(o => !string.IsNullOrEmpty(o.ParentId) && o.ParentId.Equals(node.Name));
            foreach (SysOrganization org in orgList)
            {
                subNode = new TreeNode();
                subNode.Name = org.OrganizationId;
                subNode.Text = org.OrganizationName;
                node.Nodes.Add(subNode);

                FillData(list, subNode);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            SysEmployee employee = null;
            switch (_type)
            {
                case EditType.Add:
                    employee = new SysEmployee();
                    employee.EmployeeId = BipGuid.Guid;
                    employee.EmployeeCode = txtEmployeeCode.Text.Trim();
                    employee.EmployeeName = txtEmployeeName.Text.Trim();
                    employee.Sex = uosEmployeeSex.CheckedItem.DataValue.ToString();
                    employee.Age = short.Parse(uneEmployeeAge.Value.ToString());
                    employee.Email = txtEmployeeMail.Text.Trim();
                    employee.Ip = txtEmployeeIp.Text.Trim();
                    employee.Phone = txtEmployeePhone.Text.Trim();
                    employee.Address = txtEmployeeAddress.Text.Trim();
                    employee.Remark = txtEmployeeRemark.Text.Trim();
                    employee.OrganizationId = this.OrganizationId;
                    if (picEmployeePhoto.Image != null)
                    {
                        employee.Photo = ImageUtil.ImageToBytes(picEmployeePhoto.Image);
                    }
                    this.Update(Globals.EMPLOYEE_SERVICE_NAME, "add", new object[] { employee });
                    break;
                case EditType.Update:
                    employee = _employee;
                    employee.EmployeeCode = txtEmployeeCode.Text.Trim();
                    employee.EmployeeName = txtEmployeeName.Text.Trim();
                    employee.Sex = uosEmployeeSex.CheckedItem.DataValue.ToString();
                    employee.Age = short.Parse(uneEmployeeAge.Value.ToString());
                    employee.Email = txtEmployeeMail.Text.Trim();
                    employee.Ip = txtEmployeeIp.Text.Trim();
                    employee.Phone = txtEmployeePhone.Text.Trim();
                    employee.Address = txtEmployeeAddress.Text.Trim();
                    employee.Remark = txtEmployeeRemark.Text.Trim();
                    if (!String.IsNullOrEmpty(cbtEmployeeOrg.Value))
                    {
                        employee.OrganizationId = cbtEmployeeOrg.Value;
                    }
                    if (picEmployeePhoto.Image != null)
                    {
                        employee.Photo = ImageUtil.ImageToBytes(picEmployeePhoto.Image);
                    }
                    this.Update(Globals.EMPLOYEE_SERVICE_NAME, "update", new object[] { employee });
                    break;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            bool ret = false;
            if (String.IsNullOrEmpty(txtEmployeeCode.Text.Trim()))
            {
                lblMsg.Text = "员工编号不能为空！";
            }
            else if (String.IsNullOrEmpty(txtEmployeeName.Text.Trim()))
            {
                lblMsg.Text = "组织类型不能为空！";
            }
            else if (!String.IsNullOrEmpty(txtEmployeeMail.Text.Trim()) && !Regex.IsMatch(txtEmployeeMail.Text.Trim(),"^(\\w)+(\\.\\w+)*@(\\w)+((\\.\\w+)+)$"))
            {
                lblMsg.Text = "邮箱格式不正确！";
            }
            else if(!String.IsNullOrEmpty(txtEmployeeIp.Text.Trim()) && !Regex.IsMatch(txtEmployeeIp.Text.Trim(),"^((25[0-5]|2[0-4]\\d|[01]?\\d\\d?)($|(?!\\.$)\\.)){4}$"))
            {
                lblMsg.Text = "IP地址格式不正确！";
            }
            else
            {
                lblMsg.Text = "";
                ret = true;
            }
            return ret;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.picEmployeePhoto.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
