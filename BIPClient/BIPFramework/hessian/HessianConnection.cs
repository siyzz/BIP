using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hessiancsharp.client;

namespace com.ccf.bip.framework.hessian
{
    public class HessianConnection
    {
        private string url = "";
        private CHessianProxyFactory factory;

        public HessianConnection(string url)
        {
            factory = new CHessianProxyFactory();
            this.url = url;
        }

        public IHessianController CreateHessianController()
        {
            return (IHessianController)factory.Create(typeof(IHessianController), url);
        }
    }
}
