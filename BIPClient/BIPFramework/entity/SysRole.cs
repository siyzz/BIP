using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.biz.system.authorization.mapper
{
    [Serializable]
    public class SysRole
    {
        private String roleId;

        public String RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        private String roleName;

        public String RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }

        private String parentId;

        public String ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        private String roleType;

        public String RoleType
        {
            get { return roleType; }
            set { roleType = value; }
        }

        private String remark;

        public String Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
