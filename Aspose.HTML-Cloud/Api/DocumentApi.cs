// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="DocumentApi.cs">
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
using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;


namespace Aspose.Html.Cloud.Sdk.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DocumentApi : ApiBase, IDocumentApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlDocumentApi"/> class.
        /// </summary>
		/// <param name="apiKey">The api key.</param>
		/// <param name="apiSid">The api sid.</param>
        /// <param name="basePath">The base path.</param>
        public DocumentApi(String apiKey, String apiSid, String basePath)
            : base(apiKey, apiSid, basePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlDocumentApi"/> class.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="apiSid">The api sid.</param>
        /// <param name="basePath">The base path.</param>
        public DocumentApi(String apiKey, String apiSid, String basePath, TimeSpan timeout)
            : base(apiKey, apiSid, basePath, timeout)
        {
        }

        // AR 28.09.2018 - removed since wrapped API endpoint has been excluded
        ///// <summary>
        ///// Return the HTML document by the name from default or specified storage. 
        ///// </summary>
        ///// <param name="name">The document name.</param>
        ///// <param name="storage">The document folder</param>
        ///// <param name="folder">The document folder.</param>
        ///// <returns>System.IO.Stream | Stream containing the requested document</returns>
        //public Stream GetDocument (string name, string storage, string folder)
        //{
        //    var methodName = "GetDocument";
        //    // verify the required parameter 'name' is set
        //    if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetDocument");


        //    var path = "/html/{name}";
        //    path = path.Replace("{format}", "json");
        //    path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();

        //    if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
        //    if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter

        //    // authentication setting, if any
        //    String[] authSettings = new String[] {  };

        //    var response = CallGetApi(path, queryParams, methodName);
        //    return response;
        //}

        /// <summary>
        /// Return list of HTML fragments matching the specified CSS selector.  
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="selector">CSS selector string.</param>
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>System.IO.Stream | Stream containing the requested fragments</returns>
        public AsposeStreamResponse GetDocumentFragmentByCSSSelector(string name, string selector, string outFormat, string storage, string folder)
        {
            var methodName = "GetDocumentFragmentByCSSSelector";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");

            // verify the required parameter 'xPath' is set
            if (selector == null) throw new ApiException(400, $"Missing required parameter 'selector' when calling {methodName}");

            // verify the required parameter 'outFormat' is set
            if (outFormat == null) throw new ApiException(400, $"Missing required parameter 'outFormat' when calling {methodName}");

            var path = "/html/{name}/fragments/css/{outFormat}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));
            path = path.Replace("{" + "outFormat" + "}", ApiClientUtils.ParameterToString(outFormat));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (selector != null) queryParams.Add("selector", ApiClientUtils.ParameterToString(selector)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }


        /// <summary>
        /// Return list of HTML fragments matching the specified CSS selector by Web page URL.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <param name="selector">CSS selector string.</param>
        /// <returns></returns>
        public AsposeStreamResponse GetDocumentFragmentByCSSSelectorByUrl(string sourceUrl, string selector, string outFormat)
        {
            var methodName = "GetDocumentFragmentByXPathByUrl";
            // verify the required parameter 'sourceUrl' is set
            if (sourceUrl == null) throw new ApiException(400, $"Missing required parameter 'sourceUrl' when calling {methodName}");
            // verify the required parameter 'xPath' is set
            if (selector == null) throw new ApiException(400, $"Missing required parameter 'selector' when calling {methodName}");
            // verify the required parameter 'outFormat' is set
            if (outFormat == null) throw new ApiException(400, $"Missing required parameter 'outFormat' when calling {methodName}");

            var path = "/html/fragments/css/{outFormat}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "outFormat" + "}", ApiClientUtils.ParameterToString(outFormat));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter
            queryParams.Add("selector", ApiClientUtils.ParameterToString(selector));   // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Return list of HTML fragments matching the specified XPath query.  
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="xPath">XPath query string.</param>
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>System.IO.Stream | Stream containing the requested fragments</returns>
        /// 
        public AsposeStreamResponse GetDocumentFragmentByXPath (string name, string xPath, string outFormat, string storage, string folder)
        {
            var methodName = "GetDocumentFragmentByXPath";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetDocumentFragmentByXPath");
            
            // verify the required parameter 'xPath' is set
            if (xPath == null) throw new ApiException(400, "Missing required parameter 'xPath' when calling GetDocumentFragmentByXPath");
            
            // verify the required parameter 'outFormat' is set
            if (outFormat == null) throw new ApiException(400, "Missing required parameter 'outFormat' when calling GetDocumentFragmentByXPath");
            
    
            var path = "/html/{name}/fragments/{outFormat}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));
            path = path.Replace("{" + "outFormat" + "}", ApiClientUtils.ParameterToString(outFormat));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

             if (xPath != null) queryParams.Add("xPath", ApiClientUtils.ParameterToString(xPath)); // query parameter
             if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
             if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Return list of HTML fragments matching the specified XPath query by Web page URL.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <param name="xPath">XPath query string.</param>
        /// <returns></returns>
        public AsposeStreamResponse GetDocumentFragmentByXPathByUrl(string sourceUrl, string xPath, string outFormat)
        {
            var methodName = "GetDocumentFragmentByXPathByUrl";
            // verify the required parameter 'sourceUrl' is set
            if (sourceUrl == null) throw new ApiException(400, $"Missing required parameter 'sourceUrl' when calling {methodName}");
            // verify the required parameter 'xPath' is set
            if (xPath == null) throw new ApiException(400, $"Missing required parameter 'xPath' when calling {methodName}");
            // verify the required parameter 'outFormat' is set
            if (outFormat == null) throw new ApiException(400, $"Missing required parameter 'outFormat' when calling {methodName}");


            var path = "/html/fragments/{outFormat}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "outFormat" + "}", ApiClientUtils.ParameterToString(outFormat));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter
            queryParams.Add("xPath", ApiClientUtils.ParameterToString(xPath));         // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Return all HTML document images packaged as a ZIP archive. 
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>System.IO.Stream | Stream containing the ZIP archive of all images.</returns>
        public AsposeStreamResponse GetDocumentImages (string name, string storage, string folder)
        {
            var methodName = "GetDocumentImages";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetDocumentImages");
    
            var path = "/html/{name}/images/all";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
    
             if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
             if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Return all HTML document images packaged as a ZIP archive by Web page URL.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <returns></returns>
        public AsposeStreamResponse GetDocumentImagesByUrl(string sourceUrl)
        {
            var methodName = "GetDocumentImagesByUrl";
            // verify the required parameter 'name' is set
            if (sourceUrl == null) throw new ApiException(400, $"Missing required parameter 'sourceUrl' when calling {methodName}");

            var path = "/html/images/all";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Download HTML page with linked resources from Web by its URL and return it as a ZIP archive.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <returns></returns>
        public AsposeStreamResponse GetDocumentByUrl(string sourceUrl)
        {
            var methodName = "GetDocumentByUrl";
            // verify the required parameter 'name' is set
            if (sourceUrl == null) throw new ApiException(400, $"Missing required parameter 'sourceUrl' when calling {methodName}");
            var path = "/html/download";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var defTimeout = this.ApiClient.Timeout;
            this.ApiClient.Timeout = new TimeSpan(1, 0, 0); // long timeout for the site download API

            var response = CallGetApi(path, queryParams, methodName);
            this.ApiClient.Timeout = defTimeout;
            return response;
        }
    }
}
