// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiImplBase.cs">
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
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.Html.Cloud.Sdk.Api.Internal
{
    internal abstract class ApiImplBase
    {
        #region Constructor
        internal ApiImplBase(ApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        #endregion

        #region Properties

        protected const string PAR_FILENAME_I = "__filename__";

        protected ApiClient ApiClient { get; private set; }

        #endregion

        #region Protected methods - HTTP API calls
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="queryParams"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        protected StreamResponse CallGetApi(string path, Dictionary<string, string> queryParams, string methodName = "<unknown>")
        {
            HttpResponseMessage resp = ApiClient.CallGet(path, queryParams);

            if (((int)resp.StatusCode) >= 400)
                throw new ApiException((int)resp.StatusCode,
                    string.Format("Error calling {0}: StatusCode={1} ({2}); {3}",
                    methodName, (int)resp.StatusCode, resp.StatusCode.ToString(), resp.ReasonPhrase), resp.ReasonPhrase);
            else if (((int)resp.StatusCode) == 0)
                throw new ApiException((int)resp.StatusCode,
                   string.Format("Error calling {0}:  StatusCode=0; {1}", methodName, resp.ReasonPhrase), resp.ReasonPhrase);

            var fileName = "";
            if (resp.Content.Headers.ContentDisposition != null
                && resp.Content.Headers.ContentDisposition.FileName != null)
            {
                fileName = resp.Content.Headers.ContentDisposition.FileName;
            }
            Stream outStream = new MemoryStream();
            Task task = resp.Content.ReadAsStreamAsync()
                .ContinueWith((tsk) => {
                    var contentStream = tsk.Result;
                    contentStream.CopyTo(outStream);
                    outStream.Flush();
                    outStream.Position = 0;
                });
            task.Wait();
            StreamResponse response = new StreamResponse()
            {
                Status = resp.StatusCode.ToString(),
                Code = (int)resp.StatusCode,
                ReasonPhrase = resp.ReasonPhrase
            };
            response.ContentStream = outStream;
            response.FileName = fileName;
            return response;
        }

        protected AsposeResponse CallPutApi(string path, Dictionary<string, string> queryParams, Dictionary<string, string> headerParams, Stream bodyStream, string methodName = "<unknown>")
        {
            HttpResponseMessage resp = ApiClient.CallPut(path, queryParams, headerParams, bodyStream);

            if (((int)resp.StatusCode) >= 400)
                throw new ApiException((int)resp.StatusCode,
                    string.Format("Error calling {0}: StatusCode={1} ({2}); {3}",
                    methodName, (int)resp.StatusCode, resp.StatusCode.ToString(), resp.ReasonPhrase), resp.ReasonPhrase);
            else if (((int)resp.StatusCode) == 0)
                throw new ApiException((int)resp.StatusCode,
                   string.Format("Error calling {0}:  StatusCode=0; {1}", methodName, resp.ReasonPhrase), resp.ReasonPhrase);

            var response = new AsposeResponse()
            {
                Code = (int)resp.StatusCode,
                Status = resp.StatusCode.ToString()
            };
            return response;
        }

        protected AsposeResponse CallPostApi(string path, Dictionary<string, string> queryParams, Dictionary<string, string> headerParams, Stream bodyStream, string methodName = "<unknown>")
        {
            string bodyFileName = "";
            if (queryParams.ContainsKey(PAR_FILENAME_I))
                bodyFileName = queryParams[PAR_FILENAME_I];
            else
                bodyFileName = PAR_FILENAME_I;

            HttpResponseMessage resp = ApiClient.CallPost(path, queryParams, headerParams, bodyStream, bodyFileName);
            if (((int)resp.StatusCode) >= 400)
                throw new ApiException((int)resp.StatusCode,
                    string.Format("Error calling {0}: StatusCode={1} ({2}); {3}",
                    methodName, (int)resp.StatusCode, resp.StatusCode.ToString(), resp.ReasonPhrase), resp.ReasonPhrase);
            else if (((int)resp.StatusCode) == 0)
                throw new ApiException((int)resp.StatusCode,
                   string.Format("Error calling {0}:  StatusCode=0; {1}", methodName, resp.ReasonPhrase), resp.ReasonPhrase);

            var response = new AsposeResponse()
            {
                Code = (int)resp.StatusCode,
                Status = resp.StatusCode.ToString()
            };
            return response;
        }

        protected AsposeResponse CallDeleteApi(string path, Dictionary<string, string> queryParams, string methodName = "<unknown>")
        {
            HttpResponseMessage resp = ApiClient.CallDelete(path, queryParams);
            if (((int)resp.StatusCode) >= 400)
                throw new ApiException((int)resp.StatusCode,
                    string.Format("Error calling {0}: StatusCode={1} ({2}); {3}",
                    methodName, (int)resp.StatusCode, resp.StatusCode.ToString(), resp.ReasonPhrase), resp.ReasonPhrase);
            else if (((int)resp.StatusCode) == 0)
                throw new ApiException((int)resp.StatusCode,
                   string.Format("Error calling {0}:  StatusCode=0; {1}", methodName, resp.ReasonPhrase), resp.ReasonPhrase);

            var response = new AsposeResponse()
            {
                Code = (int)resp.StatusCode,
                Status = resp.StatusCode.ToString()
            };
            return response;
        }

        #endregion 

    }
}
