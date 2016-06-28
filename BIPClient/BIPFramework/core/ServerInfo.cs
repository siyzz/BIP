using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace com.ccf.bip.framework.core
{
    public class ServerInfo
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string mode;
        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
    }
}
