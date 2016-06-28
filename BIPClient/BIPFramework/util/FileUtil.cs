using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace com.ccf.bip.framework.util
{
    class FileUtil
    {
        public static string ReadTextFile(string fileName)
        {
            return File.ReadAllText(fileName,Encoding.UTF8);
        }

        public static void WriteTextFile(String fileName, String text)
        {
            File.WriteAllText(fileName, text, Encoding.UTF8);
        }

        public static Stream GetStream(string fileName)
        {
            return File.Open(fileName, FileMode.OpenOrCreate);
        }        
    }
}
