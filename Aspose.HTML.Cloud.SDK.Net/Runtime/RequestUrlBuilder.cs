// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="RequestUrlBuilder.cs">
//   Copyright (c) 2022 Aspose.HTML Cloud
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

using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Aspose.HTML.Cloud.Sdk.Runtime
{
    internal class RequestUrlBuilder
    {
        private readonly Dictionary<string, string> queryParams = new Dictionary<string, string>();


        private string UrlPath { get; set; }

        private RequestUrlBuilder()
        {
        }

        internal static RequestUrlBuilder GetBuilder(string urlPath)
        {
            return new RequestUrlBuilder { UrlPath = urlPath };
        }

        internal RequestUrlBuilder WithPath(string path)
        {
            return WithParameter("path", path, true);
        }

        internal RequestUrlBuilder WithStorageName(string storageName)
        {
            return WithParameter("storageName", storageName, true);
        }

        internal RequestUrlBuilder WithSourcePath(string srcPath)
        {
            return WithParameter("srcPath", srcPath, true);
        }

        internal RequestUrlBuilder WithDestinationPath(string destPath)
        {
            return WithParameter("destPath", destPath, true);
        }

        internal RequestUrlBuilder WithSourceStorage(string srcStorageName)
        {
            return WithParameter("srcStorageName", srcStorageName, true);
        }

        internal RequestUrlBuilder WithDestinationStorage(string destStorageName)
        {
            return WithParameter("destStorageName", destStorageName, true);
        }

        internal RequestUrlBuilder WithParameter(string paramName, string paramValue, bool urlEncode = false)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                return this;
            } 

            var value = !urlEncode ? paramValue : WebUtility.UrlEncode(paramValue);
            if (queryParams.ContainsKey(paramName))
            {
                queryParams[paramName] = value;
            }
            else
            {
                queryParams.Add(paramName, value);
            }

            return this;
        }

        internal string Build()
        {
            var sb = new StringBuilder();
            sb.Append(UrlPath);

            if (queryParams.Count > 0)
            {
                var i = 0;
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
