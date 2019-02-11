// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ConversionApi.cs">
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
    public class ConversionApi : ApiBase, IConversionApi
    {
        private static Dictionary<string, Tuple<string, string>> s_mimeTypes = new Dictionary<string, Tuple<string, string>>();

        static ConversionApi()
        {
            s_mimeTypes.Add("pdf", new Tuple<string, string>("application/pdf", "pdf"));
            s_mimeTypes.Add("xps", new Tuple<string, string>("application/vnd.ms-xpsdocument", "xps"));
            s_mimeTypes.Add("jpeg", new Tuple<string, string>("image/jpeg", "jpg"));
            s_mimeTypes.Add("bmp", new Tuple<string, string>("image/bmp", "bmp"));
            s_mimeTypes.Add("png", new Tuple<string, string>("image/png", "png"));
            s_mimeTypes.Add("tiff", new Tuple<string, string>("image/tiff", "tif"));
            s_mimeTypes.Add("md", new Tuple<string, string>("", "md"));
            s_mimeTypes.Add("mhtml", new Tuple<string, string>("", "mht"));
        }

        private string GetMimeType(string format)
        {
            if (s_mimeTypes.ContainsKey(format.ToLowerInvariant()))
                return s_mimeTypes[format.ToLowerInvariant()].Item1;
            else
                return null;
        }

        private string GetExtension(string format)
        {
            if (s_mimeTypes.ContainsKey(format.ToLowerInvariant()))
                return s_mimeTypes[format.ToLowerInvariant()].Item2;
            else
                return null;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionApi"/> class.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="apiSid">The api sid.</param>
        /// <param name="basePath">The base path.</param>
        public ConversionApi(String apiKey, String apiSid, String basePath)
            : base(apiKey, apiSid, basePath)
        {
        }

        #region REM
        ///// <summary>
        ///// Convert the HTML document to the specified image format. 
        ///// </summary>
        ///// <param name="format">Output image format.</param> 
        ///// <param name="outPath">The path to resulting file; by default, exported document is returned in the HTTP response content stream.</param> 
        ///// <param name="width">Resulting image width. </param> 
        ///// <param name="height">Resulting image height. </param> 
        ///// <param name="leftMargin">Left image margin.</param> 
        ///// <param name="rightMargin">Right image margin.</param> 
        ///// <param name="topMargin">Top image margin.</param> 
        ///// <param name="bottomMargin">Bottom image margin.</param> 
        ///// <param name="xResolution">Horizontal image resolution; 96 ppi by default.</param> 
        ///// <param name="yResolution">Vertical image resolution; 96 ppi by default.</param> 
        ///// <param name="storage">The document storage.</param> 
        ///// <returns>System.IO.Stream</returns>            
        //public NativeRestResponse PutConvertDocumentToImage (
        //    Stream inStream, string format, string outPath = null,
        //    int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, 
        //    int? topMargin = null, int? bottomMargin = null, int? xResolution = null, int? yResolution = null, 
        //    string storage = null)
        //{
        //    // verify the required parameter 'inStream' is set
        //    if (inStream == null) throw new ApiException(400, "Missing required parameter 'inStream' when calling PutConvertDocumentToImage");
        //    // verify the required parameter 'format' is set
        //    if (format == null) throw new ApiException(400, "Missing required parameter 'format' when calling PutConvertDocumentToImage");

        //    var path = "/html/convert/image/{format}";
        //    //path = path.Replace("{format}", format);
        //    path = path.Replace("{" + "format" + "}", ApiClientUtils.ParameterToString(format));

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();
        //    var formParams = new Dictionary<String, String>();
        //    var fileParams = new Dictionary<String, FileParameter>();
        //    String postBody = null;

        //    HttpContent content = new StreamContent(inStream);

        //    if (outPath != null) queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // query parameter
        //     if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
        //     if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
        //     if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
        //     if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
        //     if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
        //     if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
        //     if (xResolution != null) queryParams.Add("xResolution", ApiClientUtils.ParameterToString(xResolution)); // query parameter
        //     if (yResolution != null) queryParams.Add("yResolution", ApiClientUtils.ParameterToString(yResolution)); // query parameter
        //     if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

        //    // authentication setting, if any
        //    String[] authSettings = new String[] {  };

        //    // make the HTTP request
        //    //IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        //    //if (((int)response.StatusCode) >= 400)
        //    //    throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentConversionPutConvertDocumentToImage: " + response.Content, response.Content);
        //    //else if (((int)response.StatusCode) == 0)
        //    //    throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentConversionPutConvertDocumentToImage: " + response.ErrorMessage, response.ErrorMessage);

        //    HttpResponseMessage resp = NativeApiClient.CallPutWithRequestContent(path, content, queryParams);

        //    if (((int)resp.StatusCode) >= 400)
        //        throw new ApiException((int)resp.StatusCode,
        //            "Error calling PutConvertDocumentToImage: " + resp.ReasonPhrase, resp.ReasonPhrase);
        //    else if (((int)resp.StatusCode) == 0)
        //        throw new ApiException((int)resp.StatusCode,
        //            "Error calling PutConvertDocumentToImage: " + resp.ReasonPhrase, resp.ReasonPhrase);

        //    NativeRestResponse response = new NativeRestResponse()
        //    {
        //        StatusCode = resp.StatusCode,
        //        ContentType = (outPath == null)
        //            ? NativeRestResponse.RespContentType.Stream 
        //            : NativeRestResponse.RespContentType.FileName,
        //        MimeType = GetMimeType(format)
        //    };

        //    if (resp.Content != null
        //        && resp.Content.Headers.ContentLength > 0)
        //    {
        //        response.Content = resp.Content.ReadAsStreamAsync().Result;
        //        if (resp.Content.Headers.ContentDisposition != null)
        //        {
        //            response.ContentName = resp.Content.Headers.ContentDisposition.FileName;
        //        }
        //        else
        //        {
        //            response.ContentName = Path.GetFileName(outPath);
        //        }
        //    }
        //    else
        //    {
        //        response.Content = "storage";
        //        var hdrs = resp.Headers;
        //        if (hdrs.Contains("X_ResultFileName"))
        //        {
        //            IEnumerator<string> en = hdrs.GetValues("X_ResultFileName").GetEnumerator();
        //            if (en.MoveNext())
        //            {
        //                var fileName = en.Current;
        //                response.ContentName = fileName;
        //            }
        //        }
        //        else
        //        {
        //            response.ContentName = Path.GetFileName(outPath);
        //        }
        //    }

        //    return response;
        //    //return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        //}

        ///// <summary>
        ///// Convert the HTML document to PDF. 
        ///// </summary>
        ///// <param name="outPath">The path to resulting file; by default, exported document is returned in the HTTP response content stream.</param> 
        ///// <param name="width">The page width of the resulting document. </param> 
        ///// <param name="height">The page height of the resulting document. </param> 
        ///// <param name="leftMargin">The left margin of the resulting document page.</param> 
        ///// <param name="rightMargin">The right margin of the resulting document page.</param> 
        ///// <param name="topMargin">The top margin of the resulting document page.</param> 
        ///// <param name="bottomMargin">The bottom margin of the resulting document page.</param> 
        ///// <param name="storage">The document storage. </param> 
        ///// <returns>System.IO.Stream</returns>            
        //public NativeRestResponse PutConvertDocumentToPdf (
        //    Stream inStream, string outPath = null,
        //    int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
        //    int? topMargin = null, int? bottomMargin = null, string storage = null)
        //{
        //    // verify the required parameter 'inStream' is set
        //    if (inStream == null) throw new ApiException(400, "Missing required parameter 'inStream' when calling PutConvertDocumentToPdf");

        //    var path = "/html/convert/pdf";
        //    path = path.Replace("{format}", "json");

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();
        //    var formParams = new Dictionary<String, String>();
        //    var fileParams = new Dictionary<String, FileParameter>();
        //    String postBody = null;

        //    HttpContent content = new StreamContent(inStream);

        //    if (outPath != null) queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // query parameter
        //     if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
        //     if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
        //     if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
        //     if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
        //     if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
        //     if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
        //     if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

        //    // authentication setting, if any
        //    String[] authSettings = new String[] {  };

        //    //// make the HTTP request
        //    //IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        //    //if (((int)response.StatusCode) >= 400)
        //    //    throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentConversionPutConvertDocumentToPdf: " + response.Content, response.Content);
        //    //else if (((int)response.StatusCode) == 0)
        //    //    throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentConversionPutConvertDocumentToPdf: " + response.ErrorMessage, response.ErrorMessage);

        //    HttpResponseMessage resp = NativeApiClient.CallPutWithRequestContent(path, content, queryParams);

        //    if (((int)resp.StatusCode) >= 400)
        //        throw new ApiException((int)resp.StatusCode,
        //            "Error calling PutConvertDocumentToPdf: " + resp.ReasonPhrase, resp.ReasonPhrase);
        //    else if (((int)resp.StatusCode) == 0)
        //        throw new ApiException((int)resp.StatusCode,
        //            "Error calling PutConvertDocumentToPdf: " + resp.ReasonPhrase, resp.ReasonPhrase);

        //    NativeRestResponse response = new NativeRestResponse()
        //    {
        //        StatusCode = resp.StatusCode,
        //        ContentType = (outPath == null)
        //            ? NativeRestResponse.RespContentType.Stream
        //            : NativeRestResponse.RespContentType.FileName,
        //        MimeType = GetMimeType("pdf")
        //    };

        //    if (resp.Content != null 
        //        && resp.Content.Headers.ContentLength > 0)
        //    {
        //        response.Content = resp.Content.ReadAsStreamAsync().Result;
        //        if (resp.Content.Headers.ContentDisposition != null)
        //        {
        //            response.ContentName = resp.Content.Headers.ContentDisposition.FileName;
        //        }
        //        else
        //        {
        //            response.ContentName = Path.GetFileName(outPath);
        //        }
        //    }
        //    else
        //    {
        //        response.Content = "storage";
        //        var hdrs = resp.Headers;
        //        if (hdrs.Contains("X_ResultFileName"))
        //        {
        //            IEnumerator<string> en = hdrs.GetValues("X_ResultFileName").GetEnumerator();
        //            if (en.MoveNext())
        //            {
        //                var fileName = en.Current;
        //                response.ContentName = fileName;
        //            }
        //        }
        //        else
        //        {
        //            response.ContentName = Path.GetFileName(outPath);
        //        }
        //    }

        //    return response;

        //    // return (System.IO.Stream)ApiClient.Deserialize(response, typeof(System.IO.Stream));
        //    // return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        //}

        ///// <summary>
        ///// Convert the HTML document to XPS. 
        ///// </summary>
        ///// <param name="outPath">The path to resulting file; by default, exported document is returned in the HTTP response content stream.</param> 
        ///// <param name="width">The page width of the resulting document. </param> 
        ///// <param name="height">The page height of the resulting document. </param> 
        ///// <param name="leftMargin">The left margin of the resulting document page.</param> 
        ///// <param name="rightMargin">The right margin of the resulting document page.</param> 
        ///// <param name="topMargin">The top margin of the resulting document page.</param> 
        ///// <param name="bottomMargin">The bottom margin of the resulting document page.</param> 
        ///// <param name="storage">The document storage. </param> 
        ///// <returns>System.IO.Stream</returns>            
        //public NativeRestResponse PutConvertDocumentToXps (
        //    Stream inStream, string outPath = null, 
        //    int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
        //    int? topMargin = null, int? bottomMargin = null, 
        //    string storage = null)
        //{
        //    // verify the required parameter 'inStream' is set
        //    if (inStream == null) throw new ApiException(400, "Missing required parameter 'inStream' when calling PutConvertDocumentToXps");

        //    var path = "/html/convert/xps";
        //    path = path.Replace("{format}", "json");

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();
        //    var formParams = new Dictionary<String, String>();
        //    var fileParams = new Dictionary<String, FileParameter>();
        //    String postBody = null;

        //    HttpContent content = new StreamContent(inStream);

        //    if (outPath != null) queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // query parameter
        //    if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
        //    if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
        //    if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
        //    if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
        //    if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
        //    if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
        //    if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

        //    // authentication setting, if any
        //    String[] authSettings = new String[] {  };

        //    // make the HTTP request
        //    //IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings); 
        //    //if (((int)response.StatusCode) >= 400)
        //    //    throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentConversionPutConvertDocumentToXps: " + response.Content, response.Content);
        //    //else if (((int)response.StatusCode) == 0)
        //    //    throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentConversionPutConvertDocumentToXps: " + response.ErrorMessage, response.ErrorMessage);

        //    HttpResponseMessage resp = NativeApiClient.CallPutWithRequestContent(path, content, queryParams);

        //    if (((int)resp.StatusCode) >= 400)
        //        throw new ApiException((int)resp.StatusCode,
        //            "Error calling PutConvertDocumentToXps: " + resp.ReasonPhrase, resp.ReasonPhrase);
        //    else if (((int)resp.StatusCode) == 0)
        //        throw new ApiException((int)resp.StatusCode,
        //            "Error calling PutConvertDocumentToXps: " + resp.ReasonPhrase, resp.ReasonPhrase);

        //    NativeRestResponse response = new NativeRestResponse()
        //    {
        //        StatusCode = resp.StatusCode,
        //        ContentType = (outPath == null)
        //            ? NativeRestResponse.RespContentType.Stream
        //            : NativeRestResponse.RespContentType.FileName,
        //        MimeType = GetMimeType("xps")
        //    };

        //    if (resp.Content != null
        //       && resp.Content.Headers.ContentLength > 0)
        //    {
        //        response.Content = resp.Content.ReadAsStreamAsync().Result;
        //        if (resp.Content.Headers.ContentDisposition != null)
        //        {
        //            response.ContentName = resp.Content.Headers.ContentDisposition.FileName;
        //        }
        //        else
        //        {
        //            response.ContentName = Path.GetFileName(outPath);
        //        }
        //    }
        //    else
        //    {
        //        response.Content = "storage";
        //        var hdrs = resp.Headers;
        //        if (hdrs.Contains("X_ResultFileName"))
        //        {
        //            IEnumerator<string> en = hdrs.GetValues("X_ResultFileName").GetEnumerator();
        //            if (en.MoveNext())
        //            {
        //                var fileName = en.Current;
        //                response.ContentName = fileName;
        //            }
        //        }
        //        else
        //        {
        //            response.ContentName = Path.GetFileName(outPath);
        //        }
        //    }

        //    return response;

        //    //return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        //}

        #endregion
        /// <summary>
        /// Convert the HTML document to the specified image format. 
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="outFormat">Output image format.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream | Stream of the resulting image.</returns>
        public AsposeStreamResponse GetConvertDocumentToImage(string name, string outFormat, 
            int? width = default(int?), int? height = default(int?), int? leftMargin = default(int?), int? rightMargin = default(int?), 
            int? topMargin = default(int?), int? bottomMargin = default(int?), int? resolution = default(int?), 
            string folder = null, string storage = null)
        {
            var methodName = "GetConvertDocumentToImage";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");
            // verify the required parameter 'outFormat' is set
            if (outFormat == null) throw new ApiException(400, $"Missing required parameter 'outFormat' when calling {methodName}");

            var path = "/html/{name}/convert/image/{outFormat}";
            //path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));
            path = path.Replace("{" + "outFormat" + "}", ApiClientUtils.ParameterToString(outFormat));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
            if (resolution != null) queryParams.Add("resolution", ApiClientUtils.ParameterToString(resolution)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };
            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to the specified image format by URL. 
        /// </summary>
        /// <param name="sourceUrl">The source document URL.</param>
        /// <param name="outFormat">Output image format.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <returns>System.IO.Stream | Stream of the resulting image.</returns>
        public AsposeStreamResponse GetConvertDocumentToImageByUrl(string sourceUrl, string outFormat, 
            int? width = default(int?), int? height = default(int?), int? leftMargin = default(int?), int? rightMargin = default(int?), 
            int? topMargin = default(int?), int? bottomMargin = default(int?), int? resolution = default(int?))
        {
            var methodName = "GetConvertDocumentToImageByUrl";
            // verify the required parameter 'sourceUrl' is set
            if (sourceUrl == null) throw new ApiException(400, "Missing required parameter 'sourceUrl' when calling GetConvertDocumentToImageByUrl");
            // verify the required parameter 'outFormat' is set
            if (outFormat == null) throw new ApiException(400, "Missing required parameter 'outFormat' when calling GetConvertDocumentToImageByUrl");

            var path = "/html/convert/image/{outFormat}";
            //path = path.Replace("{format}", "json");
            path = path.Replace("{" + "outFormat" + "}", ApiClientUtils.ParameterToString(outFormat));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
 
            queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
            if (resolution != null) queryParams.Add("resolution", ApiClientUtils.ParameterToString(resolution)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to PDF. 
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream | Stream of the resulting PDF document.</returns>
        public AsposeStreamResponse GetConvertDocumentToPdf(string name, 
            int? width = default(int?), int? height = default(int?), int? leftMargin = default(int?), int? rightMargin = default(int?), 
            int? topMargin = default(int?), int? bottomMargin = default(int?), 
            string folder = null, string storage = null)
        {
            var methodName = "GetConvertDocumentToPdf";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetConvertDocumentToPdf");

            var path = "/html/{name}/convert/pdf";
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to PDF by URL. 
        /// </summary>
        /// <param name="sourceUrl">The source page URL.</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top image document page.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <returns>System.IO.Stream | Stream of the resulting PDF document.</returns>
        public AsposeStreamResponse GetConvertDocumentToPdfByUrl(string sourceUrl, 
            int? width = default(int?), int? height = default(int?), int? leftMargin = default(int?), int? rightMargin = default(int?), 
            int? topMargin = default(int?), int? bottomMargin = default(int?))
        {
            var methodName = "GetConvertDocumentToPdfByUrl";
            // verify the required parameter 'sourceUrl' is set
            if (sourceUrl == null) throw new ApiException(400, "Missing required parameter 'sourceUrl' when calling GetConvertDocumentToPdfByUrl");

            var path = "/html/convert/pdf";
 
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
       
            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to XPS. 
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top image document page.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream | Stream of the resulting XPS document.</returns>
        public AsposeStreamResponse GetConvertDocumentToXps(string name, 
            int? width = default(int?), int? height = default(int?), int? leftMargin = default(int?), int? rightMargin = default(int?), 
            int? topMargin = default(int?), int? bottomMargin = default(int?), string folder = null, string storage = null)
        {
            var methodName = "GetConvertDocumentToXps";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetConvertDocumentToXps");

            var path = "/html/{name}/convert/xps";
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
 
            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to XPS by URL. 
        /// </summary>
        /// <param name="sourceUrl">The source page URL.</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <returns>System.IO.Stream | Stream of the resulting XPS document.</returns>
        public AsposeStreamResponse GetConvertDocumentToXpsByUrl(string sourceUrl, 
            int? width = default(int?), int? height = default(int?), int? leftMargin = default(int?), int? rightMargin = default(int?), 
            int? topMargin = default(int?), int? bottomMargin = default(int?))
        {
            var methodName = "GetConvertDocumentToXpsByUrl";
            // verify the required parameter 'sourceUrl' is set
            if (sourceUrl == null) throw new ApiException(400, "Missing required parameter 'sourceUrl' when calling GetConvertDocumentToXpsByUrl");

            var path = "/html/convert/xps";

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to the specified image format and save to storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outFormat">Output image format</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns></returns>
        public AsposeResponse PutConvertDocumentToImage(string name, string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string folder = null, string storage = null)
        {
            var methodName = "PutConvertDocumentToImage";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");
            // verify the required parameter 'outFormat' is set
            if (outFormat == null) throw new ApiException(400, $"Missing required parameter 'outFormat' when calling {methodName}");
            // verify the required parameter 'outFormat' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/{name}/convert/image/{outFormat}";
            //path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));
            path = path.Replace("{" + "outFormat" + "}", ApiClientUtils.ParameterToString(outFormat));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // required query parameter

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
            if (resolution != null) queryParams.Add("resolution", ApiClientUtils.ParameterToString(resolution)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(path, queryParams, null, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document stream to the specified image format and save to storage.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outFormat">Output image format</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="storage">Resulting image storage</param>
        /// <returns></returns>
        public AsposeResponse PutConvertDocumentToImage(Stream inStream, string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null)
        {
            var methodName = "PutConvertDocumentToImage";

            if (inStream == null) throw new ApiException(400, $"Missing required parameter 'inStream' when calling {methodName}");
            // verify the required parameter 'outFormat' is set
            if (outFormat == null) throw new ApiException(400, $"Missing required parameter 'outFormat' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/convert/image/{outFormat}";
            //path = path.Replace("{format}", "json");
            path = path.Replace("{" + "outFormat" + "}", ApiClientUtils.ParameterToString(outFormat));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // required query parameter

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
            if (resolution != null) queryParams.Add("resolution", ApiClientUtils.ParameterToString(resolution)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };
            var response = CallPutApi(path, queryParams, inStream, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to PDF and save to storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.pdf</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns></returns>
        public AsposeResponse PutConvertDocumentToPdf(string name, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
        {
            var methodName = "PutConvertDocumentToPdf";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/{name}/convert/pdf";
            //path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // required query parameter

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(path, queryParams, null, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document stream to PDF and save to storage.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.pdf</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="storage">Resulting document storage</param>
        /// <returns></returns>
        public AsposeResponse PutConvertDocumentToPdf(Stream inStream, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            var methodName = "PutConvertDocumentToPdf";
            if (inStream == null) throw new ApiException(400, $"Missing required parameter 'inStream' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/convert/pdf";
            //path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // required query parameter

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };
            var response = CallPutApi(path, queryParams, inStream, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to XPS and save to storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.xps</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns></returns>
        public AsposeResponse PutConvertDocumentToXps(string name, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
        {
            var methodName = "PutConvertDocumentToXps";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/{name}/convert/xps";
            //path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // required query parameter

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(path, queryParams, null, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document stream to XPS and save to storage.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.xps</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="storage">Resulting document storage</param>
        /// <returns></returns>
        public AsposeResponse PutConvertDocumentToXps(Stream inStream, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            var methodName = "PutConvertDocumentToXps";
            if (inStream == null) throw new ApiException(400, $"Missing required parameter 'inStream' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/convert/xps";
            //path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("outPath", ApiClientUtils.ParameterToString(outPath)); // required query parameter

            if (width != null) queryParams.Add("width", ApiClientUtils.ParameterToString(width)); // query parameter
            if (height != null) queryParams.Add("height", ApiClientUtils.ParameterToString(height)); // query parameter
            if (leftMargin != null) queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(leftMargin)); // query parameter
            if (rightMargin != null) queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(rightMargin)); // query parameter
            if (topMargin != null) queryParams.Add("topMargin", ApiClientUtils.ParameterToString(topMargin)); // query parameter
            if (bottomMargin != null) queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(bottomMargin)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };
            var response = CallPutApi(path, queryParams, inStream, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to Markdown.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="useGit">Use Git flavor of Markdown.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source document storage</param>
        /// <returns>AsposeStreamResponse | Stream of the resulting Markdown document.</returns>
        public AsposeStreamResponse GetConvertDocumentToMarkdown(string name, bool? useGit = default(bool), string folder = null, string storage = null)
        {
            var methodName = "GetConvertDocumentToMarkdown";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");

            var path = "/html/{name}/convert/md";
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (useGit != null) queryParams.Add("useGit", ApiClientUtils.ParameterToString(useGit)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };
            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to MHTML by URL.
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <returns>AsposeStreamResponse | Stream of the resulting MHTML document.</returns>
        public AsposeStreamResponse GetConvertDocumentToMHTMLByUrl(string sourceUrl)
        {
            var methodName = "GetConvertDocumentToMHTMLByUrl";
            // verify the required parameter 'name' is set
            if (sourceUrl == null) throw new ApiException(400, $"Missing required parameter 'sourceUrl' when calling {methodName}");

            var path = "/html/convert/mhtml";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (sourceUrl != null) queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(sourceUrl)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };
            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        /// <summary>
        /// Convert the HTML document to Markdown and save to storage
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.md</param>
        /// <param name="useGit">Use Git flavor of Markdown.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PutConvertDocumentToMarkdown(string name, string outPath, bool? useGit = false, string folder = null, string storage = null)
        {
            var methodName = "PutConvertDocumentToMarkdown";
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");

            var path = "/html/{name}/convert/md";
            path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (useGit != null) queryParams.Add("useGit", ApiClientUtils.ParameterToString(useGit)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(path, queryParams, null, methodName);
            return response;
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Convert the HTML document stream to Markdown and save to storage.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.md</param>
        /// <param name="useGit">Use Git flavor of Markdown</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PutConvertDocumentToMarkdown(Stream inStream, string outPath, bool? useGit = false, string storage = null)
        {
            var methodName = "PutConvertDocumentToMarkdown";
            // verify the required parameter 'name' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/convert/md";
            //path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (useGit != null) queryParams.Add("useGit", ApiClientUtils.ParameterToString(useGit)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(path, queryParams, inStream, methodName);
            return response;
        }

        #region excluded API wrappers
        //public AsposeStreamResponse GetConvertDocumentToMHTML(string name, 
        //    int? maxDepth = null, ResourceHandling? javaScript = null, UrlRestriction? urlRestrict = null, ResourceHandling? defaults = null, 
        //    string folder = null, string storage = null)
        //{
        //    var methodName = "GetConvertDocumentToMHTML";
        //    // verify the required parameter 'name' is set
        //    if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");

        //    var path = "/html/{name}/convert/mhtml";
        //    path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();

        //    if (maxDepth != null) queryParams.Add("maxDepth", ApiClientUtils.ParameterToString(maxDepth)); // query parameter
        //    if (javaScript != null) queryParams.Add("javaScript", ApiClientUtils.ParameterToString(javaScript)); // query parameter
        //    if (urlRestrict != null) queryParams.Add("urlRestrict", ApiClientUtils.ParameterToString(urlRestrict)); // query parameter
        //    if (defaults != null) queryParams.Add("defaults", ApiClientUtils.ParameterToString(defaults)); // query parameter

        //    if (folder != null) queryParams.Add("folder", ApiClientUtils.ParameterToString(folder)); // query parameter
        //    if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

        //    // authentication setting, if any
        //    String[] authSettings = new String[] { };
        //    var response = CallGetApi(path, queryParams, methodName);
        //    return response;
        //}
        //public AsposeResponse PutConvertDocumentToMHTML(string name, string outPath,
        //    int? maxDepth = null, ResourceHandling? javaScript = null, UrlRestriction? urlRestrict = null, ResourceHandling? defaults = null, 
        //    string folder = null, string storage = null)
        //{
        //    var methodName = "PutConvertDocumentToMHTML";
        //    // verify the required parameter 'name' is set
        //    if (name == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");

        //    var path = "/html/{name}/convert/mhtml";
        //    path = path.Replace("{" + "name" + "}", ApiClientUtils.ParameterToString(name));

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();

        //    if (maxDepth != null) queryParams.Add("maxDepth", ApiClientUtils.ParameterToString(maxDepth)); // query parameter
        //    if (javaScript != null) queryParams.Add("javaScript", ApiClientUtils.ParameterToString(javaScript)); // query parameter
        //    if (urlRestrict != null) queryParams.Add("urlRestrict", ApiClientUtils.ParameterToString(urlRestrict)); // query parameter
        //    if (defaults != null) queryParams.Add("defaults", ApiClientUtils.ParameterToString(defaults)); // query parameter

        //    // authentication setting, if any
        //    String[] authSettings = new String[] { };

        //    var response = CallPutApi(path, queryParams, null, methodName);
        //    return response;
        //}

        //public AsposeResponse PutConvertDocumentToMHTML(Stream inStream, string outPath,
        //    int? maxDepth = null, ResourceHandling? javaScript = null, UrlRestriction? urlRestrict = null, ResourceHandling? defaults = null)
        //{
        //    var methodName = "PutConvertDocumentToMHTML";
        //    // verify the required parameter 'name' is set
        //    if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

        //    var path = "/html/convert/mhtml";

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();

        //    if (maxDepth != null) queryParams.Add("maxDepth", ApiClientUtils.ParameterToString(maxDepth)); // query parameter
        //    if (javaScript != null) queryParams.Add("javaScript", ApiClientUtils.ParameterToString(javaScript)); // query parameter
        //    if (urlRestrict != null) queryParams.Add("urlRestrict", ApiClientUtils.ParameterToString(urlRestrict)); // query parameter
        //    if (defaults != null) queryParams.Add("defaults", ApiClientUtils.ParameterToString(defaults)); // query parameter
        //    // authentication setting, if any
        //    String[] authSettings = new String[] { };

        //    var response = CallPutApi(path, queryParams, inStream, methodName);
        //    return response;
        //}
        #endregion
    }
}
