using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.biz.system.authorization.mapper
{
    [Serializable]
    public class SysPost
    {
        private string postId;

        public string PostId
        {
            get { return postId; }
            set { postId = value; }
        }

        private string postCode;

        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }

        private string postName;

        public string PostName
        {
            get { return postName; }
            set { postName = value; }
        }

        private string postType;

        public string PostType
        {
            get { return postType; }
            set { postType = value; }
        }

        private string postLevel;

        public string PostLevel
        {
            get { return postLevel; }
            set { postLevel = value; }
        }

        private string postOrgId;

        public string PostOrgId
        {
            get { return postOrgId; }
            set { postOrgId = value; }
        }

        private string postOrgName;

        public string PostOrgName
        {
            get { return postOrgName; }
            set { postOrgName = value; }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private string roleId;

        public string RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        private string roleName;

        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
    }
}
