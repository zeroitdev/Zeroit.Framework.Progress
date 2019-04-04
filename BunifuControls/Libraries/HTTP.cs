using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace Zeroit.Framework.Progress.CustomControls
{
    [DebuggerStepThrough]
    internal class HTTP
    {
        public string URL = "";

        public string Responce = "";

        public Exception LastError = new Exception();

        public HTTP(string Url)
        {
            this.URL = Url;
        }

        public bool executesend(string data)
        {
            bool flag;
            try
            {
                HttpWebRequest length = (HttpWebRequest)WebRequest.Create(this.URL);
                length.Method = "POST";
                byte[] bytes = Encoding.ASCII.GetBytes(data);
                length.ContentType = "application/x-www-form-urlencoded";
                length.ContentLength = (long)((int)bytes.Length);
                Stream requestStream = length.GetRequestStream();
                requestStream.Write(bytes, 0, (int)bytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)length.GetResponse();
                response.GetResponseStream();
                this.Responce = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                flag = true;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.Responce = "";
                this.LastError = exception;
                flag = false;
            }
            return flag;
        }
    }
}
