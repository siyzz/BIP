using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.ccf.bip.biz.system.authorization.mapper;

namespace com.ccf.bip.frame
{
    public class OpenFormEventArgs : EventArgs
    {
        public OpenFormEventArgs(SysFunction function)
            : base()
        {
            this.fucntion = function;
        }

        private SysFunction fucntion;

        public SysFunction Fucntion
        {
            get { return fucntion; }
            set { fucntion = value; }
        }
    }
}
