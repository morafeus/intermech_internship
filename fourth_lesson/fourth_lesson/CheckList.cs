
using System;
using System.IO;
using System.Text;

namespace fourth_lesson
{
    public class CheckList
    {
        public string ReadFile(string path)
        {
            string result = String.Empty ;
            using (FileStream fs = new FileStream(path,FileMode.Open, FileAccess.Read))
            {
                var b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                int readLen;
                while ((readLen = fs.Read(b, 0, b.Length)) > 0)
                {
                    result += temp.GetString(b, 0, readLen);
                }
            }
            return result;
        }
    }
}
