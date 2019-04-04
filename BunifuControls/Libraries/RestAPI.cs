using System;
using System.IO;
using System.Net;
using System.Text;

namespace Zeroit.Framework.Progress.CustomControls
{

    public static class RestAPI
    {
        public static string DELETE(string url, string jsonContent)
        {
            string str;
            try
            {
                string str1 = "";
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    str1 = webClient.UploadString(url, "DELETE", jsonContent);
                }
                str = str1;
            }
            catch (Exception exception)
            {
                str = string.Concat("{\"error\": \"", exception.Message, "\"  }");
            }
            return str;
        }

        public static string GET(string url)
        {
            string end;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (Stream responseStream = httpWebRequest.GetResponse().GetResponseStream())
                {
                    end = (new StreamReader(responseStream, Encoding.UTF8)).ReadToEnd();
                }
            }
            catch (WebException webException1)
            {
                WebException webException = webException1;
                try
                {
                    using (Stream stream = webException.Response.GetResponseStream())
                    {
                        (new StreamReader(stream, Encoding.GetEncoding("utf-8"))).ReadToEnd();
                    }
                    throw;
                }
                catch (Exception exception)
                {
                    end = string.Concat("{\"error\": \"", exception.Message, "\"  }");
                }
            }
            return end;
        }

        public static string PATCH(string url, string jsonContent)
        {
            string str;
            try
            {
                string str1 = "";
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    str1 = webClient.UploadString(url, "PATCH", jsonContent);
                }
                str = str1;
            }
            catch (Exception exception)
            {
                str = string.Concat("{\"error\": \"", exception.Message, "\"  }");
            }
            return str;
        }

        public static string POST(string url, string jsonContent)
        {
            string str;
            try
            {
                string str1 = "";
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    str1 = webClient.UploadString(url, "POST", jsonContent);
                }
                str = str1;
            }
            catch (Exception exception)
            {
                str = string.Concat("{\"error\": \"", exception.Message, "\"  }");
            }
            return str;
        }
    }

}
