// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="TemplateMergeApi.cs">
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
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Model.Requests;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.Html.Cloud.Sdk.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the HTML conversion API endpoints
    /// </summary>
    public class TemplateMergeApi : ApiBase, ITemplateMergeApi
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="apiSid"></param>
        /// <param name="basePath"></param>
        public TemplateMergeApi(String apiKey, String apiSid, String basePath)
            : base(apiKey, apiSid, basePath)
        {
        }

        /// <summary>
        /// Populate HTML document template with data located as a file in the storage.
        /// </summary>
        /// <param name="templateName">Template document name. Template document is HTML or zipped HTML. Template location is /{folder}/{templateName}.</param>
        /// <param name="dataPath">Data source file path in the storage. Supported data format: XML.</param>
        /// <param name="options">Template merge options: reserved for further implementation.</param>
        /// <param name="folder">The template document folder.</param>
        /// <param name="storage">The template document and data source storage.</param>
        /// <returns>System.IO.Stream | Stream containing the generated document.</returns>
        public Stream GetMergeHtmlTemplate(string templateName, string dataPath, string options = null, string folder = null, string storage = null)
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
            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Populate HTML document template with data from the stream. Result document will be saved to storage.
        /// </summary>
        /// <param name="templateName">Template document name. Template document is HTML or zipped HTML. Template location is /{folder}/{templateName}.</param>
        /// <param name="inStream">Data source stream. Supported data format: XML.</param>
        /// <param name="outPath">Result document path in the storage.</param>
        /// <param name="options">Template merge options: reserved for further implementation.</param>
        /// <param name="folder">The template document folder.</param>
        /// <param name="storage">Optional. The template document and data source storage.</param>
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PutMergeHtmlTemplate(string templateName, Stream inStream, string outPath, string options = null, string folder = null, string storage = null)
        {
            var methodName = "PutMergeHtmlTemplate";
            // verify the required parameter 'templateName' is set
            if (templateName == null) throw new ApiException(400, $"Missing required parameter 'templateName' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");
            // verify the required parameter 'inStream' is set
            if (inStream == null) throw new ApiException(400, $"Missing required parameter 'inStream' when calling {methodName}");

            var path = "/html/{templateName}/merge";
            //path = path.Replace("{format}", "json");
            path = path.Replace("{" + "templateName" + "}", ApiClientUtils.ParameterToString(templateName));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // required query parameter

            if (options != null) queryParams.Add("options", ApiClientUtils.ParameterToString(options)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(path, queryParams, inStream, methodName);
            return response;
        }
    }
}
