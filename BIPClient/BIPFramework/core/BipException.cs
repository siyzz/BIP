using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.framework.core
{
    public class BipException : Exception
    {
        private int code;

        public int Code
        {
          get { return code; }
          set { code = value; }
        }

        public BipException()
            : base()
        {
        }

        public BipException(string message)
            : base(message)
        {
        }

        public BipException(int code, string message)
            : base(message)
        {
            this.code = code;
        }
    }
}
