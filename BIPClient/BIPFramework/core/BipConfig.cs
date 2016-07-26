using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using com.ccf.bip.framework.util;

namespace com.ccf.bip.framework.core
{
    public class BipConfig
    {
        public static List<T> Load<T>(string configName)
        {
            string json = FileUtil.ReadTextFile(Globals.ConfigPath + "\\" + configName);
            return JSONUtil.ParseList<T>(json);
        }

        public static void Store(string configName,List<object> configList)
        {
            string json = JSONUtil.ToJson(configList);
            FileUtil.WriteTextFile(Globals.ConfigPath + "\\" + configName, json);
        }

        public static T LoadObject<T>(string configName)
        {
            string json = FileUtil.ReadTextFile(Globals.ConfigPath + "\\" + configName);
            return JSONUtil.Parse<T>(json);
        }

        public static void StoreObject(string configName, object config)
        {
            string json = JSONUtil.ToJson(config);
            FileUtil.WriteTextFile(Globals.ConfigPath + "\\" + configName, json);
        }
    }
}
