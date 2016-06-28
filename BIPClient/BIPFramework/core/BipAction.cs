using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.ccf.bip.framework.hessian;

namespace com.ccf.bip.framework.core
{
    public class BipAction
    {
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public BipAction()
        {
        }

        public BipAction(string url)
        {
            this.url = url;
        }

        public object Excute(string serviceName, String methodName, object[] args)
        {
            ParameterInfo param = new ParameterInfo();
            param.ServiceName = serviceName;
            param.FunctionName = methodName;
            param.Value = args;
            ReturnInfo ret = Excute(param);
            if (ret.Code != 0)
            {
                throw new BipException(ret.Code, ret.Message);
            }
            return ret.Value;
        }

        public ReturnInfo Excute(ParameterInfo param)
        {
            return HessianConnectionFactory.createHessianConnection(url + "/hessian/handle.do").CreateHessianController().call(param);
        }
    }    
}
