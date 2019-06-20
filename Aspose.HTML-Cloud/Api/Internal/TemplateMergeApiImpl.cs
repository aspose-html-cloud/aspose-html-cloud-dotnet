// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="TemplateMergeApiImpl.cs">
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
using Aspose.Html.Cloud.Sdk.Api.Utils;

namespace Aspose.Html.Cloud.Sdk.Api.Internal
{
    internal class TemplateMergeApiImpl : ApiImplBase, ITemplateMergeApi
    {
        internal TemplateMergeApiImpl(ApiClient apiClient) : base(apiClient)
        {
        }

        public AsposeStreamResponse GetMergeHtmlTemplate(string templateName, string dataPath, string options = null, string folder = null, string storage = null)
        {
            var methodName = "GetMergeHtmlTemplate";
            // verify the required parameter 'name' is set
            if (templateName == null) throw new ApiException(400, $"Missing required parameter 'templateName' when calling {methodName}");
            // verify the required parameter 'outFormat' is set
            if (dataPath == null) throw new ApiException(400, $"Missing required parameter 'dataPath' when calling {methodName}");

            var path = "/html/{templateName}/merge";
            //path = path.Replace("{format}", "json");
            path = path.Replace("{" + "templateName" + "}", ApiClientUtils.ParameterToString(templateName));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("dataPath", ApiClientUtils.ParameterToString(dataPath)); // query parameter
            if (options != null) queryParams.Add("options", ApiClientUtils.ParameterToString(options)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };
            AsposeStreamResponse response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        public AsposeResponse PostMergeHtmlTemplate(string templateName, Stream inStream, string dataType, string outPath, string options = null, string folder = null, string storage = null)
        {
            var methodName = "PostMergeHtmlTemplate";
            // verify the required parameter 'templateName' is set
            if (templateName == null) throw new ApiException(400, $"Missing required parameter 'templateName' when calling {methodName}");
            // verify the required parameter 'dataType' is set
            if (dataType == null) throw new ApiException(400, $"Missing required parameter 'dataType' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");
            // verify the required parameter 'inStream' is set
            if (inStream == null) throw new ApiException(400, $"Missing required parameter 'inStream' when calling {methodName}");

            if (!(dataType.ToLower() == "json" || dataType.ToLower() == "xml"))
                throw new ApiException(400, $"'dataType' parameter: Unsupported data type when calling {methodName}");

            var path = "/html/{templateName}/merge";
            path = path.Replace("{" + "templateName" + "}", ApiClientUtils.ParameterToString(templateName));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // required query parameter

            if (options != null) queryParams.Add("options", ApiClientUtils.ParameterToString(options)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            var contentType = MimeHelper.GetMimeType(dataType);
            headerParams.Add("Content-Type", contentType);
            headerParams.Add("Content-Length", inStream.Length.ToString());
            // authentication setting, if contentType
            String[] authSettings = new String[] { };

            var response = CallPostApi(path, queryParams, headerParams, inStream, methodName);
            return response;
        }
    }
}
