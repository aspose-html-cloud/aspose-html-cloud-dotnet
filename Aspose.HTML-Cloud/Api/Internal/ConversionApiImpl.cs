﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ConversionApiImpl.cs">
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

namespace Aspose.Html.Cloud.Sdk.Api.Internal
{
    internal class ConversionApiImpl : ApiImplBase, IConversionApi
    {
        #region Constructor
        public ConversionApiImpl(ApiClient apiClient) : base(apiClient)
        {
        }
        #endregion

        #region IConversionApi interface implementation 
        public AsposeStreamResponse GetConvertDocumentToImage(string name, string outFormat, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string folder = null, string storage = null)
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

        public AsposeStreamResponse GetConvertDocumentToImageByUrl(string sourceUrl, string outFormat, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null)
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

        public AsposeStreamResponse GetConvertDocumentToMarkdown(string name, bool? useGit = null, string folder = null, string storage = null)
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

        public AsposeStreamResponse GetConvertDocumentToPdf(string name, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
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

        public AsposeStreamResponse GetConvertDocumentToPdfByUrl(string sourceUrl, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null)
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

        public AsposeStreamResponse GetConvertDocumentToXps(string name, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
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

        public AsposeStreamResponse GetConvertDocumentToXpsByUrl(string sourceUrl, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null)
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

        public AsposeResponse PostConvertDocumentToImage(Stream inStream, string dataType, string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null)
        {
            var methodName = "PostConvertDocumentToImage";

            if (inStream == null) throw new ApiException(400, $"Missing required parameter 'inStream' when calling {methodName}");
            // verify the required parameter 'dataType' is set
            if (dataType == null) throw new ApiException(400, $"Missing required parameter 'dataType' when calling {methodName}");
            // verify the required parameter 'outFormat' is set
            if (outFormat == null) throw new ApiException(400, $"Missing required parameter 'outFormat' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/convert/image/{outFormat}";
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

            headerParams.Add("Content-Type", "multipart/form-data");
            headerParams.Add("Content-Length", inStream.Length.ToString());
            // authentication setting, if any
            String[] authSettings = new String[] { };
            var response = CallPostApi(path, queryParams, headerParams, inStream, methodName);
            return response;
        }

        public AsposeResponse PostConvertDocumentToMarkdown(Stream inStream, string dataType, string outPath, bool? useGit = false, string storage = null)
        {
            var methodName = "PostConvertDocumentToMarkdown";
            // verify the required parameter 'dataType' is set
            if (dataType == null) throw new ApiException(400, $"Missing required parameter 'dataType' when calling {methodName}");
            // verify the required parameter 'name' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/convert/md";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (useGit != null) queryParams.Add("useGit", ApiClientUtils.ParameterToString(useGit)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            headerParams.Add("Content-Type", "multipart/form-data");
            headerParams.Add("Content-Length", inStream.Length.ToString());
            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPostApi(path, queryParams, headerParams, inStream, methodName);
            return response;
        }
        
        public AsposeResponse PostConvertDocumentToPdf(Stream inStream, string dataType, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            var methodName = "PostConvertDocumentToPdf";
            if (inStream == null) throw new ApiException(400, $"Missing required parameter 'inStream' when calling {methodName}");
            // verify the required parameter 'dataType' is set
            if (dataType == null) throw new ApiException(400, $"Missing required parameter 'dataType' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/convert/pdf";
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

            headerParams.Add("Content-Type", Utils.MimeHelper.);
            headerParams.Add("Content-Length", inStream.Length.ToString());
            // authentication setting, if any
            String[] authSettings = new String[] { };
            var response = CallPostApi(path, queryParams, headerParams, inStream, methodName);
            return response;
        }

        public AsposeResponse PostConvertDocumentToXps(Stream inStream, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            var methodName = "PostConvertDocumentToXps";
            if (inStream == null) throw new ApiException(400, $"Missing required parameter 'inStream' when calling {methodName}");
            // verify the required parameter 'outPath' is set
            if (outPath == null) throw new ApiException(400, $"Missing required parameter 'outPath' when calling {methodName}");

            var path = "/html/convert/xps";
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

            headerParams.Add("Content-Type", "multipart/form-data");
            headerParams.Add("Content-Length", inStream.Length.ToString());
            // authentication setting, if any
            String[] authSettings = new String[] { };
            var response = CallPostApi(path, queryParams, headerParams, inStream, methodName);
            return response;
        }

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

            var response = CallPutApi(path, queryParams, null, null, methodName);
            return response;
        }

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

            var response = CallPutApi(path, queryParams, null, null, methodName);
            return response;
            throw new NotImplementedException();
        }

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

            var response = CallPutApi(path, queryParams, null, null, methodName);
            return response;
        }

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

            var response = CallPutApi(path, queryParams, null, null, methodName);
            return response;
        }
        #endregion
    }
}