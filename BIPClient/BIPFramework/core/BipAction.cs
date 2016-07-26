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

        /// <summary>
        /// 服务端数据请求(请求默认更新session)
        /// </summary>
        /// <param name="serviceName">服务名(包名+类名)</param>
        /// <param name="methodName">方法名</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public object Excute(string serviceName, string methodName, object[] args)
        {
            return Excute(serviceName, methodName, args, true);
        }

        /// <summary>
        /// 服务端数据请求
        /// </summary>
        /// <param name="serviceName">服务名(包名+类名)</param>
        /// <param name="methodName">方法名</param>
        /// <param name="args">参数</param>
        /// <param name="updateSession">是否更新session</param>
        /// <returns></returns>
        public object Excute(string serviceName, string methodName, object[] args, bool updateSession)
        {
            ParameterInfo param = new ParameterInfo();
            param.ServiceName = serviceName;
            param.FunctionName = methodName;
            param.Value = args;
            param.Tocken = Globals.Tocken;
            param.SessionUpdate = updateSession;
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
