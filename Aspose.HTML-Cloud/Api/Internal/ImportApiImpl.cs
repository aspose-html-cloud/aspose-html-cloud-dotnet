// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ImportApiImpl.cs">
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
    internal class ImportApiImpl : ApiImplBase, IImportApi
    {
        public ImportApiImpl(ApiClient apiClient) : base(apiClient)
        {
        }

        #region IImportApi interface implementation

        public StreamResponse GetImportMarkdownToHtml(string name, string folder = null, string storage = null)
        {
            var methodName = "GetImportMarkdownToHtml";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");

            var path = $"/html/{name}/import/md";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        public AsposeResponse PutImportMarkdownToHtml(string name, string outPath, string folder = null, string storage = null)
        {
            var methodName = "PutImportMarkdownToHtml";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");

            var path = $"/html/{name}/import/md";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // required query parameter

            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter

            var response = CallPutApi(path, queryParams, headerParams, null, methodName);
            return response;
        }

        public AsposeResponse PostImportMarkdownToHtml(Stream inStream, string outPath, string storage = null)
        {
            var methodName = "PostImportMarkdownToHtml";

            // verify the required parameter 'inStream' is set
            if (inStream == null) throw new ApiException(400, $"Missing required parameter 'inStream' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/import/md";

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // required query parameter

            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            var response = CallPostApi(path, queryParams, headerParams, inStream, methodName);
            return response;
        }

        public AsposeResponse PostImportMarkdownToHtml(string localFilePath, string outPath, string storage = null)
        {
            if (!File.Exists(localFilePath))
                throw new FileNotFoundException($"Source file {localFilePath} not found.");
            using (Stream fstr = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
            {
                return PostImportMarkdownToHtml(fstr, outPath, storage);
            }
        }
        #endregion
    }
}
