using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.ccf.bip.biz.system.update.mapper;

namespace com.ccf.bip.udp
{
    public class FileVersionCompare : IEqualityComparer<FileVersion>
    {
        #region IEqualityComparer<FileVersion> 成员

        public bool Equals(FileVersion x, FileVersion y)
        {
            return x.Directory == y.Directory && x.Name == y.Name && (x.Version == y.Version || x.Version > y.Version);
        }

        public int GetHashCode(FileVersion fileVersion)
        {
            return fileVersion != null ? fileVersion.ToString().GetHashCode() : 0;
        }

        #endregion
    }
}
