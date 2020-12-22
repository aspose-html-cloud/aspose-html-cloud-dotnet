// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="RequestUrlBuilder.cs">
//   Copyright (c) 2020 Aspose.HTML Cloud
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
using System.Text;
using System.Net;

namespace Aspose.HTML.Cloud.Sdk.Runtime
{
    public class RequestUrlBuilder
    {
        private Dictionary<string, string> queryParams = new Dictionary<string, string>();


        private string UrlPath { get; set; }

        RequestUrlBuilder()
        {
        }

        public static RequestUrlBuilder GetBuilder(string urlPath)
        {
            return new RequestUrlBuilder() { UrlPath = urlPath };
        }

        public static RequestUrlBuilder GetBuilder(Uri urlPath)
        {
            return new RequestUrlBuilder() { UrlPath = urlPath.OriginalString };
        }


        public RequestUrlBuilder WithPath(string path)
        {
            return WithParameter("path", path, true);
        }

        public RequestUrlBuilder WithStorageName(string storageName)
        {
            return WithParameter("storageName", storageName, true);
        }

        public RequestUrlBuilder WithSourcePath(string srcPath)
        {
            return WithParameter("srcPath", srcPath, true);
        }

        public RequestUrlBuilder WithDestinationPath(string destPath)
        {
            return WithParameter("destPath", destPath, true);
        }

        public RequestUrlBuilder WithSourceStorage(string srcStorageName)
        {
            return WithParameter("srcStorageName", srcStorageName, true);
        }

        public RequestUrlBuilder WithDestinationStorage(string destStorageName)
        {
            return WithParameter("destStorageName", destStorageName, true);
        }



        public RequestUrlBuilder WithParameter(string paramName, string paramValue, bool urlEncode = false)
        {
            if (string.IsNullOrEmpty(paramValue))
                return this; 

            var value = !urlEncode ? paramValue : WebUtility.UrlEncode(paramValue);
            if (queryParams.ContainsKey(paramName))
                queryParams[paramName] = value;
            else
                queryParams.Add(paramName, value);

            return this;
        }

        public RequestUrlBuilder WithParameter(string paramName, int paramValue)
        {
            return WithParameter(paramName, paramValue.ToString(), false);
        }

        public RequestUrlBuilder WithParameter(string paramName, Guid paramValue, string guidFormat = "D")
        {
            return WithParameter(paramName, paramValue.ToString(guidFormat), false);
        }

        public RequestUrlBuilder WithParameter(string paramName, DateTime paramValue, string timeFormat = "o")
        {
            return WithParameter(paramName, paramValue.ToString(timeFormat), true);
        }

        public string Build()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(UrlPath);

            if (queryParams.Count > 0)
            {
                int i = 0;
                foreach (var key in queryParams.Keys)
                {
                    sb.Append(i++ == 0 ? "?" : "&");
                    sb.Append($"{key}={queryParams[key]}");
                }
            }
            return sb.ToString();
        }


    }
}
