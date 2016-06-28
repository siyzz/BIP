using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.framework.core
{
    public class BipGuid
    {
        private const int len = 18;
        private static readonly Crc32 crc = new Crc32();
        private static readonly Random r = new Random();
        public static string GetCRC32(string str)
        {
            crc.Reset();
            crc.Update(System.Text.Encoding.UTF8.GetBytes(str));
            return crc.Value.ToString("X");
        }

        public static string Guid
        {
            get 
            {
                string str = BipGuid.GetCRC32(System.Guid.NewGuid().ToString()) + BipGuid.GetCRC32((DateTime.Now.Ticks - r.Next(99999999)).ToString());
                if (str.Length < len)  //包含长度小于18位的结果，调整到18位。
                    str = str.PadRight(len,'0');
                return str;
            }
        }
    }
}
