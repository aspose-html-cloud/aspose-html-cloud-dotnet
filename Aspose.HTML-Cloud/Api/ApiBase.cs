// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiBase.cs">
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
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.Html.Cloud.Sdk.Api
{
    /// <summary>
    /// Base abstract class for REST API wrapper classes.
    /// </summary>
    public abstract class ApiBase
    {
        const string DefaultApiVersion = "3.0";

        /// <summary>
        /// Constructor. Initalizes a new instance ApiBase class with specified user credentials (application SID and application key),
        /// and REST API service URL; by default, authentication service URL is the same.        
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        protected internal ApiBase(String appSid, String appKey, String basePath)
            : this(appSid, appKey, basePath, basePath)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of ApiBase class with specified user credentials (application SID and application key),
        /// REST API service URL and authentication service URL.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="authPath">Authorization service URL</param>
        protected internal ApiBase(String appSid, String appKey, String basePath, String authPath)
        {
            if (!ApiClientUtils.UrlContainsVersion(basePath))
            {
                var baseUrl = $"{basePath}/v{DefaultApiVersion}";
                basePath = baseUrl;
            }
            this.ApiClient = new ApiClient(appSid, appKey, basePath, authPath);
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of ApiBase class with specified user credentials (application SID and application key),
        /// REST API service URL and service connection timeout; by default, authentication service URL is the same.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="timeout">Service connection timeout</param>
        protected internal ApiBase(String appSid, String appKey, String basePath, TimeSpan timeout)
            : this(appSid, appKey, basePath)
        {
            this.ApiClient.Timeout = timeout;
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of HtmlApi class with specified user credentials (application SID and application key),
        /// REST API service URL, authentication service URL and service connection timeout.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="authPath">Authorization service URL</param>
        /// <param name="timeout">Service connection timeout</param>
        protected internal ApiBase(String appSid, String appKey, String basePath, String authPath, TimeSpan timeout)
            : this(appSid, appKey, basePath, authPath)
        {
            this.ApiClient.Timeout = timeout;
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of ApiBase class with Configuration object.
        /// </summary>
        /// <param name="config"></param>
        protected internal ApiBase(Configuration config)
        {
            if (!ApiClientUtils.UrlContainsVersion(config.ApiBaseUrl))
            {
                var baseUrl = config.ApiBaseUrl + "/v" + config.ApiVersion;
                config.ApiBaseUrl = baseUrl;
            }

            this.ApiClient = new ApiClient(
                config.AppSid, config.AppKey, config.ApiBaseUrl, config.AuthUrl);
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of ApiBase class inheriting ApiClient object
        /// of existing ApiBase instance, so authorization data become common for both.
        /// </summary>
        /// <param name="apiInstance"></param>
        protected internal ApiBase(ApiBase apiInstance)
        {
            this.ApiClient = apiInstance.ApiClient;
        }

        /// <summary>
        /// Gets or sets the API client
        /// </summary>
        internal ApiClient ApiClient { get; set; }


        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

    }
}
