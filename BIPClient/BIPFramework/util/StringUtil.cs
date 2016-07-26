using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace com.ccf.bip.framework.util
{
    public class StringUtil
    {
        public static bool MatchEmail(string str)
        {
            return Regex.IsMatch(str, "^(\\w)+(\\.\\w+)*@(\\w)+((\\.\\w+)+)$");
        }

        public static bool MatchIp(string str)
        {
            return Regex.IsMatch(str, "^((25[0-5]|2[0-4]\\d|[01]?\\d\\d?)($|(?!\\.$)\\.)){4}$");
        }
    }
}
