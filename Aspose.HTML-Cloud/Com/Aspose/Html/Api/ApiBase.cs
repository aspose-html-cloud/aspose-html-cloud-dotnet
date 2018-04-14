// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiBase.cs">
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
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Com.Aspose.Html.Client;
using Com.Aspose.Html.NativeClient;

namespace Com.Aspose.Html.Api
{
    public abstract class ApiBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="apiSid"></param>
        /// <param name="basePath"></param>
        public ApiBase(String apiKey, String apiSid, String basePath)
        {
            this.ApiClient = new ApiClient(apiKey, apiSid, basePath);
            this.NativeApiClient = new NativeApiClient(apiKey, apiSid, basePath);
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Gets or sets the API client for PUTs - workaround
        /// </summary>
        public NativeApiClient NativeApiClient { get; set; }


        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.NativeApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.NativeApiClient.BasePath;
        }

        protected NativeRestResponse CallGetApi_i(string path, Dictionary<string, string> queryParams, string methodName = "<unknown>")
        {
            HttpResponseMessage resp = NativeApiClient.CallGet(path, queryParams);

            if (((int)resp.StatusCode) >= 400)
                throw new ApiException((int)resp.StatusCode,
                    string.Format("Error calling {0}: {1}", methodName, resp.ReasonPhrase), resp.ReasonPhrase);
            else if (((int)resp.StatusCode) == 0)
                throw new ApiException((int)resp.StatusCode,
                   string.Format("Error calling {0}: {1}", methodName, resp.ReasonPhrase), resp.ReasonPhrase);

            NativeRestResponse response = new NativeRestResponse()
            {
                StatusCode = resp.StatusCode,
                ContentType = NativeRestResponse.RespContentType.Stream,
                MimeType = resp.Content.Headers.ContentType.ToString(),
                ContentName = resp.Content.Headers.ContentDisposition.FileName,
                Content = resp.Content.ReadAsStreamAsync().Result
            };

            return response;
        }

        protected Stream CallGetApi(string path, Dictionary<string, string> queryParams, string methodName = "<unknown>")
        {
            HttpResponseMessage resp = NativeApiClient.CallGet(path, queryParams);

            if (((int)resp.StatusCode) >= 400)
                throw new ApiException((int)resp.StatusCode,
                    string.Format("Error calling {0}: {1}", methodName, resp.ReasonPhrase), resp.ReasonPhrase);
            else if (((int)resp.StatusCode) == 0)
                throw new ApiException((int)resp.StatusCode,
                   string.Format("Error calling {0}: {1}", methodName, resp.ReasonPhrase), resp.ReasonPhrase);

            string outDir = String.IsNullOrEmpty(Configuration.TempFolderPath)
                     ? Path.GetTempPath()
                     : Configuration.TempFolderPath;

            string outPath = Path.Combine(outDir, resp.Content.Headers.ContentDisposition.FileName);
            Stream outStream = File.OpenWrite(outPath);

            Task task = resp.Content.ReadAsStreamAsync()
                .ContinueWith((tsk) => {
                    var contentStream = tsk.Result;
                    contentStream.CopyTo(outStream);
                    outStream.Flush();
                });
            task.Wait();
            return outStream;
        }

    }
}
