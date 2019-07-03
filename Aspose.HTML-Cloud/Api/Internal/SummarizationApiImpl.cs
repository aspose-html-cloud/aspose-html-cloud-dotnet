// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="SummarizationApi.cs">
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
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;


namespace Aspose.Html.Cloud.Sdk.Api.Internal
{
    internal class SummarizationApiImpl : ApiImplBase, ISummarizationApi
    {
        #region Constructor
        internal SummarizationApiImpl(ApiClient apiClient) : base(apiClient)
        {
        }
        #endregion

        #region ISummarizationApi interface implementation
        public StreamResponse GetDetectHtmlKeywords(string name, string folder = null, string storage = null)
        {
            var methodName = "GetDetectHtmlKeywords";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetDetectHtmlKeywords");

            var path = "/html/{name}/summ/keywords";
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        public StreamResponse GetDetectHtmlKeywordsByUrl(string sourceUrl)
        {
            var methodName = "GetDetectHtmlKeywordsByUrl";

            // verify the required parameter 'sourceUrl' is set
            if (sourceUrl == null) throw new ApiException(400, "Missing required parameter 'sourceUrl' when calling GetTranslateDocumentByUrl");

            var path = "/html/summ/keywords";

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (sourceUrl != null) queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter
            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }
        #endregion

    }
}
