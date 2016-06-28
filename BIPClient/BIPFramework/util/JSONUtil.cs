using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace com.ccf.bip.framework.util
{
    public class JSONUtil
    {
        public static T Parse<T>(string json)
        {
            return (T)JsonConvert.DeserializeObject<T>(json);
        }

        public static List<T> ParseList<T>(string json)
        {
            return (List<T>)JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
