using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace com.ccf.bip.framework.util
{
    public class NetworkUtil
    {
        /// <summary>
        /// 是否能 Ping 通指定的主机
        /// </summary>
        /// <param name="ip">ip 地址或主机名或域名</param>
        /// <returns>true 通，false 不通</returns>
        public static bool Ping(string ip)
        {
            bool ret = false;
            try
            {
                Ping p = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "Test Data!";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 1000; // Timeout 时间，单位：毫秒
                PingReply reply = p.Send(ip, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                    ret = true;
            }
            catch (Exception ex)
            {
            }
            return ret;
        }
    }
}
