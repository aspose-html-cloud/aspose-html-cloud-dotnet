// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiClient.cs">
//   Copyright (c) 2019 Aspose.HTML Cloud
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
//using Com.Aspose.Html.NativeClient.Authentication;
using Aspose.Html.Cloud.Sdk.Client.Authentication;

namespace Aspose.Html.Cloud.Sdk.Client
{
    /// <summary>
    /// Quick workaround to encapsulate PUT calls - instead of RestSharp.Net2
    /// </summary>
    internal class ApiClient
    {
        public string AppKey { get; protected set; }
        public string AppSid { get; protected set; }
        public string BasePath { get; set; }
        //public string Version { get; protected set; }
        //public bool Debug { get; protected set; }
        public string BaseAuthPath { get; set; }

        public TimeSpan Timeout { get; set; }

        private IAuthenticator Authenticator { get; set; }

        protected const string PAR_FILENAME_I = "__filename__";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appSid">Application SID</param>
        /// <param name="appKey">Application key</param>
        /// <param name="basePath">REST API service path</param>
        /// <param name="auth"></param>
        public ApiClient(string appSid, string appKey, 
            string basePath = "http://api.aspose.cloud/v3.0",
            IAuthenticator auth = null)
        {
            AppKey = appKey;
            AppSid = appSid;
            BasePath = basePath;
            //Version = version;
            //Debug = debug;
            Timeout = new TimeSpan(0, 5, 0);

            Authenticator = auth ?? new JwtAuth(appSid, appKey, basePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSid"></param>
        /// <param name="appKey"></param>
        /// <param name="basePath"></param>
        /// <param name="authPath"></param>
        /// <param name="auth"></param>
        public ApiClient(string appSid, string appKey, 
            string basePath = "http://api.aspose.cloud/v3.0",
            string authPath = "http://api.aspose.cloud/v3.0",
            IAuthenticator auth = null)
        {
            AppKey = appKey;
            AppSid = appSid;
            BasePath = basePath;
            BaseAuthPath = authPath;
            //Version = version;
            //Debug = debug;
            Timeout = new TimeSpan(0, 5, 0);

            Authenticator = auth ?? new JwtAuth(appSid, appKey, authPath);
        }

        public ApiClient(JwtToken authToken, string basePath = "http://api.aspose.cloud/v3.0")
        {
            BasePath = basePath;
            Timeout = new TimeSpan(0, 5, 0);
            Authenticator = new JwtAuth(authToken);
        }

        public ApiClient(string authToken, string basePath = "https://api.aspose.cloud/v3.0")
        {
            BasePath = basePath;
            Timeout = new TimeSpan(0, 5, 0);
            Authenticator = new JwtAuth(authToken);
        }

        public HttpResponseMessage CallGet(string methodPath, IDictionary<string, string> parameters)
        {
            string requestUrl = formatQuery(methodPath, parameters);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestUrl),
                Method = HttpMethod.Get
            };

            return authorizeAndCallRequest(request);
        }

        public HttpResponseMessage CallPut(string methodPath, IDictionary<string, string> parameters, string body = null)
        {
            string requestUrl = formatQuery(methodPath, parameters);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestUrl),
                Method = HttpMethod.Put
            };
            if(body != null)
            {
                request.Content = new StringContent(body);
            }
            return authorizeAndCallRequest(request);
        }

        public HttpResponseMessage CallPut(string methodPath, IDictionary<string, string> parameters, IDictionary<string, string> headerParams = null, Stream bodyStream = null)
        {
            string requestUrl = formatQuery(methodPath, parameters);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestUrl),
                Method = HttpMethod.Put
            };

            if(headerParams != null)
            {
                //request.Headers.
            }
            if(bodyStream != null)
            {
                var content = new StreamContent(bodyStream);
                if (headerParams != null)
                {
                    if (headerParams.ContainsKey("Content-Type"))
                        content.Headers.ContentType = new MediaTypeHeaderValue(headerParams["Content-Type"]);
                    if (headerParams.ContainsKey("Content-Length"))
                        content.Headers.ContentLength = long.Parse(headerParams["Content-Length"]);
                }
                request.Content = content;
            }
            return authorizeAndCallRequest(request);
        }

        public HttpResponseMessage CallPost(
            string methodPath, 
            IDictionary<string, string> parameters, 
            IDictionary<string, string> headerParams = null, 
            Stream bodyStream = null,
            string bodyFileName = null)
        {
            string requestUrl = formatQuery(methodPath, parameters);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestUrl),
                Method = HttpMethod.Post
            };

            if (bodyStream != null)
            {
                var multipartContent = new MultipartFormDataContent();
                var fileContent = new StreamContent(bodyStream);
                if (headerParams != null)
                {
                    if (headerParams.ContainsKey("Content-Type"))
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(headerParams["Content-Type"]);
                    if (headerParams.ContainsKey("Content-Length"))
                        fileContent.Headers.ContentLength = long.Parse(headerParams["Content-Length"]);
                }
                multipartContent.Add(fileContent, "File", bodyFileName);
                request.Content = multipartContent;
            }
            if (headerParams != null)
            {

            }
            return authorizeAndCallRequest(request);
        }

        public HttpResponseMessage CallDelete(string methodPath, IDictionary<string, string> parameters)
        {
            string requestUrl = formatQuery(methodPath, parameters);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestUrl),
                Method = HttpMethod.Delete
            };
            return authorizeAndCallRequest(request);
        }

        private string formatQuery(string methodPath, IDictionary<string, string> parameters)
        {
            StringBuilder sb = new StringBuilder();
            if (Uri.IsWellFormedUriString(BasePath, UriKind.Absolute))
            {
                sb.Append(BasePath);
                //if (!BasePath.EndsWith("/"))
                //    sb.Append("/");
                sb.Append(methodPath);
                int idx = 0;
                foreach (var key in parameters.Keys.Where(k => k != PAR_FILENAME_I))
                {
                    string val = parameters[key];
                    sb.Append(string.Format("{0}{1}={2}", (idx++ == 0) ? "?" : "&", key, val));
                }
            }
            else
                throw new ArgumentException("Malformed BasePath has been specified");

            return sb.ToString();
        }

        private HttpResponseMessage authorizeAndCallRequest(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            using (HttpClient client = new HttpClient() { Timeout = this.Timeout })
            {
                int retries = 2;
                bool authRes = false;
                while (retries-- > 0)
                {
                    if (authRes = Authenticator.Authenticate(request))
                    {
                        Task task = client.SendAsync(request)
                            .ContinueWith((tsk) => { response = tsk.Result; }
                        );
                        task.Wait();

                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized
                            || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                        {
                            if (!Authenticator.UseExternalAuthentication)
                            {
                                Authenticator.RetryAuthentication();
                                continue;
                            }
                        }
                        break;
                    }
                }
                if (!authRes && Authenticator.UseExternalAuthentication)
                {
                    if (Authenticator.AuthError != null)
                        throw Authenticator.AuthError;

                    throw new SdkAuthException(SdkAuthException.Reason.Common, $"Authentication error: unknown");
                }
            }
            return response;
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
