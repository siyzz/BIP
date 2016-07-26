using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace com.ccf.bip.framework.server.file
{
    [Serializable]
    public class FileInfo
    {
        public string FullName
        {
            get { return directory + (directory.EndsWith(Path.DirectorySeparatorChar.ToString()) ? "" : Path.DirectorySeparatorChar.ToString()) + name; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string directory;

        public string Directory
        {
            get { return directory; }
            set { directory = value; }
        }
        private byte[] content;

        public byte[] Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
