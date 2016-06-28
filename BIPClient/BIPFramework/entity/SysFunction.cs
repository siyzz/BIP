using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.biz.system.authorization.mapper
{
    [Serializable]
    public class SysFunction
    {
        private string functionId;

        public string FunctionId
        {
            get { return functionId; }
            set { functionId = value; }
        }

        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string functionName;

        public string FunctionName
        {
            get { return functionName; }
            set { functionName = value; }
        }

        private string parentId;

        public string ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        private string functionType;

        public string FunctionType
        {
            get { return functionType; }
            set { functionType = value; }
        }

        private string serverName;

        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        private string tag;

        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        private short seq;

        public short Seq
        {
            get { return seq; }
            set { seq = value; }
        }

        private string assemblyname;

        public string Assemblyname
        {
            get { return assemblyname; }
            set { assemblyname = value; }
        }

        private bool showToolBar;

        public bool ShowToolBar
        {
            get { return showToolBar; }
            set { showToolBar = value; }
        }

        private bool useHotKey;

        public bool UseHotKey
        {
            get { return useHotKey; }
            set { useHotKey = value; }
        }

        private string formType;

        public string FormType
        {
            get { return formType; }
            set { formType = value; }
        }

        private ArrayList buttonList;

        public ArrayList ButtonList
        {
            get { return buttonList; }
            set { buttonList = value; }
        }
    }
}
