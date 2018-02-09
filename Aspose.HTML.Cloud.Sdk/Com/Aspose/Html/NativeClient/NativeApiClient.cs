using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Http;

namespace Com.Aspose.Html.NativeClient
{
    /// <summary>
    /// Quick workaround to encapsulate PUT calls - instead of RestSharp.Net2
    /// </summary>
    public class NativeApiClient
    {
        private string AppKey { get; set; }
        private string AppSid { get; set; }
        private string BasePath { get; set; }

        public NativeApiClient(string appKey, string appSid, string basePath = "http://api.aspose.cloud/v1.1")
        {
            AppKey = appKey;
            AppSid = appSid;
            BasePath = basePath;
        }

        public HttpResponseMessage CallPut(string methodPath, IDictionary<string, string> parameters)
        {
            string requestUrl = formatQuery(methodPath, parameters);
            return CallPutWithRequestContent(requestUrl);
        }

        public HttpResponseMessage CallPutWithRequestContent(string methodPath, HttpContent content, IDictionary<string, string> parameters)
        {
            string requestUrl = formatQuery(methodPath, parameters);
            return CallPutWithRequestContent(requestUrl, content);
        }

        public HttpResponseMessage CallPutWithRequestContent(string requestUrl, HttpContent content = null)
        {
            HttpClient client = new HttpClient();
            string signedUrl = SignUrl(requestUrl);
            HttpResponseMessage response = client.PutAsync(signedUrl, content).Result;
            return response;
        }

        private string formatQuery(string methodPath, IDictionary<string, string> parameters)
        {
            StringBuilder sb = new StringBuilder();
            string res = "";

            if (Uri.IsWellFormedUriString(BasePath, UriKind.Absolute))
            {
                sb.Append(BasePath);
                //if (!BasePath.EndsWith("/"))
                //    sb.Append("/");
                sb.Append(methodPath);
                int idx = 0;
                foreach (var key in parameters.Keys)
                {
                    string val = parameters[key];
                    sb.Append(string.Format("{0}{1}={2}", (idx++ == 0) ? "?" : "&", key, val));
                }
            }
            else
                throw new ArgumentException("Malformed BasePath has been specified");

            return sb.ToString();
        }

        private string SignUrl(string url)
        {
            url = url.Trim('?');

            var uri = new Uri(url);
            url = string.Format("{0}{1}appsid={2}",
                url,
                string.IsNullOrEmpty(uri.Query) ? '?' : '&',
                AppSid);

            var signature = GetSignature(url, AppKey);

            var result = string.Format("{0}&signature={1}", url, signature);
            return result;
        }

        private string GetSignature(string url, string key)
        {
            var encoding = new ASCIIEncoding();
            // converting key to bytes will throw an exception, need to replace '-' and '_' characters first.
            var usablePrivateKey = key.Replace("-", "+").Replace("_", "/");
            var privateKeyBytes = Convert.FromBase64String(usablePrivateKey);

            var uri = new Uri(url);
            var encodedPathAndQueryBytes = encoding.GetBytes(uri.LocalPath + uri.Query);

            // compute the hash
            var algorithm = new HMACSHA1(privateKeyBytes);
            var hash = algorithm.ComputeHash(encodedPathAndQueryBytes);

            // convert the bytes to string and make url-safe by replacing '+' and '/' characters
            var result = Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");
            return result;
        }
    }
}
