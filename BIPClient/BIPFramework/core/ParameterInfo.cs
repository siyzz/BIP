using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.framework.core
{
    /// <summary>
    /// 平台服务调用统一参数信息
    /// </summary>
    [Serializable]
    public class ParameterInfo
    {
        private String serviceName;
        /// <summary>
        /// 调用服务名称
        /// </summary>
        public String ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }
        private String functionName;
        /// <summary>
        /// 调用服务方法名称
        /// </summary>
        public String FunctionName
        {
            get { return functionName; }
            set { functionName = value; }
        }
        private Object[] value;
        /// <summary>
        /// 调用服务方法参数
        /// </summary>
        public Object[] Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
