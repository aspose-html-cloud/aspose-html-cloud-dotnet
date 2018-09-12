// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="NativeApiClient.cs">
//   Copyright (c) 2018 Aspose.HTML for Cloud
// </copyright>
// <summary>
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Http;
using System.Net.Http.Headers;
using Com.Aspose.Html.NativeClient.Authentication;

namespace Com.Aspose.Html.NativeClient
{
    /// <summary>
    /// Quick workaround to encapsulate PUT calls - instead of RestSharp.Net2
    /// </summary>
    [Obsolete]
    public class ApiClient
    {
        public string AppKey { get; protected set; }
        public string AppSid { get; protected set; }
        public string BasePath { get; set; }
        //public string Version { get; protected set; }
        //public bool Debug { get; protected set; }

        public TimeSpan Timeout { get; set; }

        private IAuthenticator Authenticator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="appSid"></param>
        /// <param name="basePath"></param>
        /// <param name="auth"></param>
        public ApiClient(string appKey, string appSid, string basePath = "http://api.aspose.cloud/v1.1",
            IAuthenticator auth = null)
        {
            AppKey = appKey;
            AppSid = appSid;
            BasePath = basePath;
            //Version = version;
            //Debug = debug;
            Timeout = new TimeSpan(0, 5, 0);

            Authenticator = auth ?? new OAuth2(appSid, appKey, basePath);
        }

        public HttpResponseMessage CallGet(string methodPath, IDictionary<string, string> parameters)
        {
            string requestUrl = formatQuery(methodPath, parameters);
            HttpClient client = new HttpClient() { Timeout = this.Timeout };
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestUrl),
                Method = HttpMethod.Get
            };

            HttpResponseMessage response = null;
            int retries = 2;
            while (retries-- > 0)
            {
                if (Authenticator.Authenticate(request))
                {
                    Task task = client.SendAsync(request)
                        .ContinueWith((tsk) => { response = tsk.Result; }
                    );
                    task.Wait();
                    
                    if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized
                        || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        Authenticator.RetryAuthentication();
                    }
                    break;
                }
            }
            return response;
        }

        //public HttpResponseMessage CallPut(string methodPath, IDictionary<string, string> parameters)
        //{
        //    string requestUrl = formatQuery(methodPath, parameters);
        //    return CallPutWithRequestContent(requestUrl);
        //}

        //public HttpResponseMessage CallPutWithRequestContent(string methodPath, HttpContent content, IDictionary<string, string> parameters)
        //{
        //    string requestUrl = formatQuery(methodPath, parameters);
        //    return CallPutWithRequestContent(requestUrl, content);
        //}

        //public HttpResponseMessage CallPutWithRequestContent(string requestUrl, HttpContent content = null)
        //{
        //    HttpClient client = new HttpClient();
        //    string signedUrl = SignUrl(requestUrl);
        //    HttpResponseMessage response = client.PutAsync(signedUrl, content).Result;
        //    return response;
        //}

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

        #region REM - obsolete authentication method
        //private string SignUrl(string url)
        //{
        //    url = url.Trim('?');

        //    var uri = new Uri(url);
        //    url = string.Format("{0}{1}appsid={2}",
        //        url,
        //        string.IsNullOrEmpty(uri.Query) ? '?' : '&',
        //        AppSid);

        //    var signature = GetSignature(url, AppKey);

        //    var result = string.Format("{0}&signature={1}", url, signature);
        //    return result;
        //}

        //private string GetSignature(string url, string key)
        //{
        //    var encoding = new ASCIIEncoding();
        //    // converting key to bytes will throw an exception, need to replace '-' and '_' characters first.
        //    var usablePrivateKey = key.Replace("-", "+").Replace("_", "/");
        //    var privateKeyBytes = Convert.FromBase64String(usablePrivateKey);

        //    var uri = new Uri(url);
        //    var encodedPathAndQueryBytes = encoding.GetBytes(uri.LocalPath + uri.Query);

        //    // compute the hash
        //    var algorithm = new HMACSHA1(privateKeyBytes);
        //    var hash = algorithm.ComputeHash(encodedPathAndQueryBytes);

        //    // convert the bytes to string and make url-safe by replacing '+' and '/' characters
        //    var result = Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");
        //    return result;
        //}
        #endregion
    }
}
