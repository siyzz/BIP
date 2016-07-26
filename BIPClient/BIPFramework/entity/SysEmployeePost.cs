using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.biz.system.authorization.mapper
{
    [Serializable]
    public class SysEmployeePost
    {
        private string employeePostId;

        public string EmployeePostId
        {
            get { return employeePostId; }
            set { employeePostId = value; }
        }

        private string employeeId;

        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        private string postId;

        public string PostId
        {
            get { return postId; }
            set { postId = value; }
        }
    }
}
