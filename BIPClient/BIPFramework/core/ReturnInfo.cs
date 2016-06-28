using System;

namespace com.ccf.bip.framework.core
{
    /// <summary>
    /// 平台服务调用统一返回信息
    /// </summary>
    [Serializable]
    public class ReturnInfo
    {
        private int code;
        /// <summary>
        /// 错误码 0-正确 <>0错误(错误码未定义)
        /// </summary>
        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        private String message;
        /// <summary>
        /// 错误描述
        /// </summary>
        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        private Object value;
        /// <summary>
        /// 返回值
        /// </summary>
        public Object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
