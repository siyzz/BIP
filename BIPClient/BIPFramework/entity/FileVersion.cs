using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace com.ccf.bip.biz.system.update.mapper
{
    [Serializable]
    public class FileVersion
    {
        private string directory;

        public string Directory
        {
            get { return directory; }
            set { directory = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int version;

        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        private DateTime updateTime;

        public DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }

        public string GetFullName()
        {
            return directory + (String.IsNullOrEmpty(directory) || directory.EndsWith(Path.DirectorySeparatorChar.ToString()) ? "" : Path.DirectorySeparatorChar.ToString()) + name;
        }
    }    
}
