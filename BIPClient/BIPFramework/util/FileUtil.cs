using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace com.ccf.bip.framework.util
{
    public class FileUtil
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

        /// 将文件转换为二进制数组 
        /// </summary> 
        /// <param name="fileName">文件路径</param> 
        /// <returns></returns> 
        public static byte[] FileToArray(string fileName)
        {
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, System.Convert.ToInt32(stream.Length));
                    stream.Flush();
                    stream.Close();

                    return buffer;
                }
                else
                {
                    return new byte[0];
                }
            }
            catch (Exception exp)
            {
                return new byte[0];
            }
        }
    }
}
