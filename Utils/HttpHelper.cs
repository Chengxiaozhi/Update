using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace MyUpdate.Utils
{
    public class HttpHelper
    {
        public static void DownLoadFile(string url,string fileName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            //if (!response.ContentType.ToLower().StartsWith("text/"))
            //{
                byte[] buffer = new byte[1024];
                Stream outStream = CreateFile(fileName);
                Stream inStream = response.GetResponseStream();

                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        outStream.Write(buffer, 0, l);
                }
                while (l > 0);

                outStream.Close();
                inStream.Close();
            //}

        }

        private static FileStream  CreateFile(string fileName)
        {
            string filePath = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            return File.Create(fileName);
        }
    }
}
