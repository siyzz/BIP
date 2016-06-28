using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.ccf.bip.framework.core;

namespace com.ccf.bip.framework.hessian
{
    public interface IHessianController
    {
        ReturnInfo call(ParameterInfo param);
    }
}
