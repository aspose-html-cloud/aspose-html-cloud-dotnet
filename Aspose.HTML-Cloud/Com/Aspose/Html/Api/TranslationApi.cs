// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="TranslationApi.cs">
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
using Com.Aspose.Html.Client;
using Com.Aspose.Html.NativeClient;
using Com.Aspose.Html.Api.Interfaces;

namespace Com.Aspose.Html.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TranslationApi : ApiBase, ITranslationApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlDocumentTranslationApi"/> class.
        /// </summary>
		/// <param name="apiKey">The api key.</param>
		/// <param name="apiSid">The api sid.</param>
        /// <param name="basePath">The base path.</param>
        public TranslationApi(String apiKey, String apiSid, String basePath)
            : base (apiKey, apiSid, basePath)
        {
        }

        /// <summary>
        /// Translate the HTML document specified by the name from default or specified storage. 
        /// </summary>
        /// <param name="name">Document name.</param>
        /// <param name="srcLang">Source language.</param>
        /// <param name="resLang">Result language.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>Stream | Stream of resulting document.</returns>
        public Stream GetTranslateDocument (string name, string srcLang, string resLang, string folder = null, string storage = null)
        {
            var methodName = "GetTranslateDocument";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetTranslateDocument");
            
            // verify the required parameter 'srcLang' is set
            if (srcLang == null) throw new ApiException(400, "Missing required parameter 'srcLang' when calling GetTranslateDocument");
            
            // verify the required parameter 'resLang' is set
            if (resLang == null) throw new ApiException(400, "Missing required parameter 'resLang' when calling GetTranslateDocument");
            
    
            var path = "/html/{name}/translate/{srcLang}/{resLang}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));
            path = path.Replace("{" + "srcLang" + "}", ApiClientUtils.ParameterToString(srcLang));
            path = path.Replace("{" + "resLang" + "}", ApiClientUtils.ParameterToString(resLang));
    
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
        /// Translate the HTML document specified by its URL. 
        /// </summary>
        /// <param name="sourceUrl">Source document URL.</param>
        /// <param name="srcLang">Source language.</param>
        /// <param name="resLang">Result language.</param>
        /// <returns>Stream | Stream of resulting document.</returns>   
        public Stream GetTranslateDocumentByUrl (string sourceUrl, string srcLang, string resLang)
        {
            var methodName = "GetTranslateDocumentByUrl";
            // verify the required parameter 'sourceUrl' is set
            if (sourceUrl == null) throw new ApiException(400, "Missing required parameter 'sourceUrl' when calling GetTranslateDocumentByUrl");
            
            // verify the required parameter 'srcLang' is set
            if (srcLang == null) throw new ApiException(400, "Missing required parameter 'srcLang' when calling GetTranslateDocumentByUrl");
            
            // verify the required parameter 'resLang' is set
            if (resLang == null) throw new ApiException(400, "Missing required parameter 'resLang' when calling GetTranslateDocumentByUrl");
            
            var path = "/html/translate/{srcLang}/{resLang}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "srcLang" + "}", ApiClientUtils.ParameterToString(srcLang));
            path = path.Replace("{" + "resLang" + "}", ApiClientUtils.ParameterToString(resLang));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

             if (sourceUrl != null) queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        #region REM
        ///// <summary>
        ///// Return the list of language pairs supported by the translator.  
        ///// </summary>
        ///// <returns>System.IO.Stream</returns>            
        //public System.IO.Stream HtmlDocumentTranslationGetTranslationSupportedLanguagePairs ()
        //{
        //    var path = "/html/translate/langpairs";
        //    path = path.Replace("{format}", "json");

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();
        //    var formParams = new Dictionary<String, String>();
        //    var fileParams = new Dictionary<String, FileParameter>();
        //    String postBody = null;


        //    // authentication setting, if any
        //    String[] authSettings = new String[] {  };

        //    // make the HTTP request
        //    IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

        //    if (((int)response.StatusCode) >= 400)
        //        throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentTranslationGetTranslationSupportedLanguagePairs: " + response.Content, response.Content);
        //    else if (((int)response.StatusCode) == 0)
        //        throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentTranslationGetTranslationSupportedLanguagePairs: " + response.ErrorMessage, response.ErrorMessage);

        //    return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        //}
        #endregion

        #region REM
        ///// <summary>
        ///// Translate the HTML document specified by the name from default or specified storage. 
        ///// </summary>
        ///// <param name="name">Document name.</param> 
        ///// <param name="srcLang">Source language.</param> 
        ///// <param name="resLang">Result language.</param> 
        ///// <param name="storage">The document storage.</param> 
        ///// <param name="folder">The document folder.</param> 
        ///// <returns>System.IO.Stream</returns>            
        //public NativeRestResponse PutTranslateDocument (string name, string srcLang, string resLang, string folder = null, string storage = null)
        //{

        //    // verify the required parameter 'name' is set
        //    if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling PutTranslateDocument");

        //    // verify the required parameter 'srcLang' is set
        //    if (srcLang == null) throw new ApiException(400, "Missing required parameter 'srcLang' when calling PutTranslateDocument");

        //    // verify the required parameter 'resLang' is set
        //    if (resLang == null) throw new ApiException(400, "Missing required parameter 'resLang' when calling PutTranslateDocument");


        //    var path = "/html/{name}/translate/{srcLang}/{resLang}";
        //    path = path.Replace("{format}", "json");
        //    path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));
        //    path = path.Replace("{" + "srcLang" + "}", ApiClientUtils.ParameterToString(srcLang));
        //    path = path.Replace("{" + "resLang" + "}", ApiClientUtils.ParameterToString(resLang));

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();

        //    if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
        //    if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter

        //    // authentication setting, if any
        //    String[] authSettings = new String[] {  };

        //    // make the HTTP request
        //    //IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

        //    HttpResponseMessage resp = NativeApiClient.CallPut(path, queryParams);

        //    if (((int)resp.StatusCode) >= 400)
        //        throw new ApiException ((int)resp.StatusCode,
        //            "Error calling PutTranslateDocument: " + resp.ReasonPhrase, resp.ReasonPhrase);
        //    else if (((int)resp.StatusCode) == 0)
        //        throw new ApiException ((int)resp.StatusCode,
        //            "Error calling PutTranslateDocument: " + resp.ReasonPhrase, resp.ReasonPhrase);

        //    NativeRestResponse response = new NativeRestResponse()
        //    {
        //        StatusCode = resp.StatusCode,
        //        ContentType = NativeRestResponse.RespContentType.FileName,
        //        MimeType = (name.EndsWith(".zip") ? "application/zip"
        //                    : (name.EndsWith(".html") ? "text/html" : ""))
        //    };

        //    var hdrs = resp.Headers;
        //    if(hdrs.Contains("X_ResultFileName"))
        //    {
        //        IEnumerator<string> en = hdrs.GetValues("X_ResultFileName").GetEnumerator();
        //        if(en.MoveNext())
        //        {
        //            var fileName = en.Current;
        //            response.Content = "storage";
        //            response.ContentName = fileName;
        //        }
        //    }
        //    return response;
        //    //return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        //}

        ///// <summary>
        ///// Translate the HTML document specified by its URL. 
        ///// </summary>
        ///// <param name="sourceUrl">Source document URL.</param> 
        ///// <param name="srcLang">Source language.</param> 
        ///// <param name="resLang">Result language.</param> 
        ///// <param name="folder">The result document folder</param> 
        ///// <param name="storage">The result document storage</param> 
        ///// <returns>System.IO.Stream</returns>            
        //public NativeRestResponse PutTranslateDocumentByUrl (string sourceUrl, string srcLang, string resLang, string folder = null, string storage = null)
        //{

        //    // verify the required parameter 'sourceUrl' is set
        //    if (sourceUrl == null) throw new ApiException(400, "Missing required parameter 'sourceUrl' when calling PutTranslateDocumentByUrl");

        //    // verify the required parameter 'srcLang' is set
        //    if (srcLang == null) throw new ApiException(400, "Missing required parameter 'srcLang' when calling PutTranslateDocumentByUrl");

        //    // verify the required parameter 'resLang' is set
        //    if (resLang == null) throw new ApiException(400, "Missing required parameter 'resLang' when calling PutTranslateDocumentByUrl");


        //    var path = "/html/translate/{srcLang}/{resLang}";
        //    path = path.Replace("{format}", "json");
        //    path = path.Replace("{" + "srcLang" + "}", ApiClientUtils.ParameterToString(srcLang));
        //    path = path.Replace("{" + "resLang" + "}", ApiClientUtils.ParameterToString(resLang));

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();
        //    var formParams = new Dictionary<String, String>();
        //    var fileParams = new Dictionary<String, FileParameter>();
        //    String postBody = null;

        //    if (sourceUrl != null)
        //    {
        //        var paramSrcUrl = ApiClientUtils.ParameterToString(sourceUrl);
        //        if (Uri.IsWellFormedUriString(paramSrcUrl, UriKind.Absolute))
        //        {
        //            queryParams.Add("sourceUrl", paramSrcUrl);
        //            //queryParams.Add("sourceUrl", HttpUtility.UrlEncode(paramSrcUrl)); // query parameter
        //        }
        //        else
        //            throw new ArgumentException("Malformed URL passed as sourceUrl parameter");
        //    }
        //    if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
        //    if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

        //    // authentication setting, if any
        //    String[] authSettings = new String[] {  };

        //    HttpResponseMessage resp = NativeApiClient.CallPut(path, queryParams);

        //    if (((int)resp.StatusCode) >= 400)
        //        throw new ApiException((int)resp.StatusCode,
        //            "Error calling PutTranslateDocumentByUrl: " + resp.ReasonPhrase, resp.ReasonPhrase);
        //    else if (((int)resp.StatusCode) == 0)
        //        throw new ApiException((int)resp.StatusCode,
        //            "Error calling PutTranslateDocumentByUrl: " + resp.ReasonPhrase, resp.ReasonPhrase);

        //    NativeRestResponse response = new NativeRestResponse()
        //    {
        //        StatusCode = resp.StatusCode,
        //        ContentType = NativeRestResponse.RespContentType.FileName,
        //        MimeType = "application/zip"

        //    };

        //    var hdrs = resp.Headers;
        //    if (hdrs.Contains("X_ResultFileName"))
        //    {
        //        IEnumerator<string> en = hdrs.GetValues("X_ResultFileName").GetEnumerator();
        //        if (en.MoveNext())
        //        {
        //            var fileName = en.Current;
        //            response.Content = "storage";
        //            response.ContentName = fileName;
        //        }
        //    }
        //    return response;
        //    //// make the HTTP request
        //    //IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

        //    //if (((int)response.StatusCode) >= 400)
        //    //    throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentTranslationPutTranslateDocumentByUrl: " + response.Content, response.Content);
        //    //else if (((int)response.StatusCode) == 0)
        //    //    throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentTranslationPutTranslateDocumentByUrl: " + response.ErrorMessage, response.ErrorMessage);

        //    //return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        //}
        #endregion
    }
}
