// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="OcrApi.cs">
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
using RestSharp;
using Com.Aspose.Html.Client;
using Com.Aspose.Html.NativeClient;
using Com.Aspose.Html.Api.Interfaces;

namespace Com.Aspose.Html.Api
{

    public class OcrApi : ApiBase, IOcrApi
    {

        /// <summary>
        /// Constructor. Initializes a new instance of the <see cref="ConversionApi"/> class.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="apiSid">The api sid.</param>
        /// <param name="basePath">The base path.</param>
        public OcrApi(String apiKey, String apiSid, String basePath)
            : base(apiKey, apiSid, basePath)
        {
        }
 
        #region IOcrApi implementation

        public Stream GetRecognizeAndImportToHtml(string name, string engineLang = "en", string folder = null, string storage = null)
        {
            var methodName = "GetRecognizeAndImportToHtml";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetRecognizeAndImportToHtml");

            var path = "/html/{name}/ocr/import";
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

            if (string.IsNullOrEmpty(engineLang)) engineLang = "en";

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams);
            return response;
        }

        public Stream GetRecognizeAndTranslateToHtml(string name, string srcLang, string resLang, string folder = null, string storage = null)
        {
            var methodName = "GetRecognizeAndTranslateToHtml";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetRecognizeAndTranslateToHtml");
            // verify the required parameter 'srcLang' is set
            if (srcLang == null) throw new ApiException(400, "Missing required parameter 'srcLang' when calling GetRecognizeAndTranslateToHtml");

            // verify the required parameter 'resLang' is set
            if (resLang == null) throw new ApiException(400, "Missing required parameter 'resLang' when calling GetRecognizeAndTranslateToHtml");

            var path = "/html/{name}/ocr/translate/{srcLang}/{resLang}";
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));
            path = path.Replace("{" + "srcLang" + "}", ApiClientUtils.ParameterToString(srcLang));
            path = path.Replace("{" + "resLang" + "}", ApiClientUtils.ParameterToString(resLang));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams);
            return response;
        }

        #endregion
    }
}
