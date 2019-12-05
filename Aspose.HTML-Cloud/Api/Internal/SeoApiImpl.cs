// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="SeoApiImpl.cs">
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
using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.Html.Cloud.Sdk.Api.Internal
{
    internal class SeoApiImpl : ApiImplBase, ISeoApi
    {
        public SeoApiImpl(ApiClient apiClient) : base(apiClient)
        {
        }

        #region ISeoApi interface implementation

        public StreamResponse GetWebPageSEOWarnings(string sourceUrl)
        {
            var methodName = "GetWebPageSEOWarnings";
            if (sourceUrl == null) throw new ApiException(400, $"Missing required parameter 'sourceUrl' when calling {methodName}");

            var path = $"/html/seo";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (sourceUrl != null) queryParams.Add("addr", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        #endregion
    }
}
