using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.biz.metadata.employee.mapper
{
    [Serializable]
    public class SysEmployee
    {
        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

        private string employeeId;

        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        private string employeeCode;

        public string EmployeeCode
        {
            get { return employeeCode; }
            set { employeeCode = value; }
        }

        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        private string organizationId;

        public string OrganizationId
        {
            get { return organizationId; }
            set { organizationId = value; }
        }

        private string organizationName;

        public string OrganizationName
        {
            get { return organizationName; }
            set { organizationName = value; }
        }

        private string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private short age;

        public short Age
        {
            get { return age; }
            set { age = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string ip;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private byte[] photo;

        public byte[] Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        private string posts;

        public string Posts
        {
            get { return posts; }
            set { posts = value; }
        }
    }
}
