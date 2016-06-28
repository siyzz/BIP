using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.ccf.bip.biz.metadata.employee.mapper;

namespace com.ccf.bip.biz.system.user.mapper
{
    [Serializable]
    public class SysUser
    {
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string userAccount;

        public string UserAccount
        {
            get { return userAccount; }
            set { userAccount = value; }
        }

        private string userPassword;

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }

        private string employeeId;

        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        private string valid;

        public string Valid
        {
            get { return valid; }
            set { valid = value; }
        }

        private string creator;

        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        private DateTime createTime;

        private DateTime lastUpdateTime;

        public DateTime LastUpdateTime
        {
            get { return lastUpdateTime; }
            set { lastUpdateTime = value; }
        }

        private string superAdmin;

        public string SuperAdmin
        {
            get { return superAdmin; }
            set { superAdmin = value; }
        }

        private SysEmployee employee;

        public SysEmployee Employee
        {
            get { return employee; }
            set { employee = value; }
        }
    }
}
