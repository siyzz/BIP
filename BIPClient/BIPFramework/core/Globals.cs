using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace com.ccf.bip.framework.core
{
    public class Globals
    {
        private static string _appPath = Environment.CurrentDirectory;
        private static string _configPath = _appPath + "\\conf";
        private static string _serverConfigName = "server.bip";
        private static string _settingConfigName = "setting.bip";        
        private static string _fileVersionConfigName = "version.bip";        
        private static List<ServerConfig> _serverList = new List<ServerConfig>();
        private static List<Hashtable> _hotkeyList = new List<Hashtable>(10);
        private static string _tocken = "";

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

        public static string SettingConfigName
        {
            get { return Globals._settingConfigName; }
        }

        public static string FileVersionConfigName
        {
            get { return Globals._fileVersionConfigName; }
        }

        public static List<ServerConfig> ServerList
        {
            get { return Globals._serverList; }
            set { Globals._serverList = value; }
        }

        public static List<Hashtable> HotkeyList
        {
            get { return Globals._hotkeyList; }
            set { Globals._hotkeyList = value; }
        }

        public static string Tocken
        {
            get { return Globals._tocken; }
            set { Globals._tocken = value; }
        }

        public const string ORGANIZATION_SERVICE_NAME = "com.ccf.bip.biz.metadata.org.service.OrganizationService";
        public const string FUNCTION_SERVICE_NAME = "com.ccf.bip.biz.system.authorization.service.FunctionService";
        public const string EMPLOYEE_SERVICE_NAME = "com.ccf.bip.biz.metadata.employee.service.EmployeeService";
        public const string ROLE_SERVICE_NAME = "com.ccf.bip.biz.system.authorization.service.RoleService";
        public const string POST_SERVICE_NAME = "com.ccf.bip.biz.system.authorization.service.PostService";
        public const string SERVERINFO_SERVICE_NAME = "com.ccf.bip.biz.system.monitor.service.ServerInfoService";
        public const string USER_SERVICE_NAME = "com.ccf.bip.biz.system.user.service.UserService";
        public const string FILETRANSFER_SERVICE_NAME = "com.ccf.bip.framework.server.file.NetFileService";
        public const string PROGRAM_UPDATE_SERVICE_NAME = "com.ccf.bip.biz.system.update.service.ProgramUpdateService";
        public const string LOG_SERVICE_NAME = "com.ccf.bip.biz.system.log.service.LogService";
    }
}
