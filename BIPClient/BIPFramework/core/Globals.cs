using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace com.ccf.bip.framework.core
{
    public class Globals
    {
        private static string _appPath = Environment.CurrentDirectory;
        private static string _configPath = _appPath + "\\conf";
        private static string _serverConfigName = "server.bip";
        private static List<ServerInfo> _serverList = new List<ServerInfo>();

        public static string AppPath
        {
            get { return _appPath; }
        }

        public static string ConfigPath
        {
            get { return _configPath; }
        }

        public static string ServerConfigName
        {
            get { return Globals._serverConfigName; }
        }

        public static List<ServerInfo> ServerList
        {
            get { return Globals._serverList; }
            set { Globals._serverList = value; }
        }

        public const string ORGANIZATION_SERVICE_NAME = "com.ccf.bip.biz.metadata.org.service.OrganizationService";
        public const string FUNCTION_SERVICE_NAME = "com.ccf.bip.biz.system.authorization.service.FunctionService";
        public const string EMPLOYEE_SERVICE_NAME = "com.ccf.bip.biz.metadata.employee.service.EmployeeService";
        public const string ROLE_SERVICE_NAME = "com.ccf.bip.biz.system.authorization.service.RoleService";
        public const string POST_SERVICE_NAME = "com.ccf.bip.biz.system.authorization.service.PostService";
        public const string SERVERINFO_SERVICE_NAME = "com.ccf.bip.biz.system.monitor.service.ServerInfoService";
    }
}
