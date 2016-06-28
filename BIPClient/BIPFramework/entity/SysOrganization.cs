using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.biz.metadata.org.mapper
{
    [Serializable]
    public class SysOrganization
    {
        private string organizationId;

        public string OrganizationId
        {
            get { return organizationId; }
            set { organizationId = value; }
        }

        private string parentId;

        public string ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        private string organizationCode;

        public string OrganizationCode
        {
            get { return organizationCode; }
            set { organizationCode = value; }
        }

        private string organizationName;

        public string OrganizationName
        {
            get { return organizationName; }
            set { organizationName = value; }
        }

        private string organizationLevel;

        public string OrganizationLevel
        {
            get { return organizationLevel; }
            set { organizationLevel = value; }
        }

        private string organizationType;

        public string OrganizationType
        {
            get { return organizationType; }
            set { organizationType = value; }
        }

        private string organizationTypeDesc;

        public string OrganizationTypeDesc
        {
            get { return organizationTypeDesc; }
            set { organizationTypeDesc = value; }
        }

        private string organizationLeader;

        public string OrganizationLeader
        {
            get { return organizationLeader; }
            set { organizationLeader = value; }
        }

        private string organizationLeaderName;

        public string OrganizationLeaderName
        {
            get { return organizationLeaderName; }
            set { organizationLeaderName = value; }
        }

        private string organizationPhone;

        public string OrganizationPhone
        {
            get { return organizationPhone; }
            set { organizationPhone = value; }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
