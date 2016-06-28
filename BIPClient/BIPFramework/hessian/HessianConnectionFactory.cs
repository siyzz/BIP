using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.ccf.bip.framework.core;

namespace com.ccf.bip.framework.hessian
{
    public class HessianConnectionFactory
    {        
        public static HessianConnection createHessianConnection(string url)
        {
            HessianConnection connection = new HessianConnection(url);
            return connection;
        }
    }
}
