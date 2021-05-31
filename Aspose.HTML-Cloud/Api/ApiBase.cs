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
//using System.Configuration;

using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Client.Authentication;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.Html.Cloud.Sdk.Api
{
    /// <summary>
    /// Base abstract class for REST API wrapper classes.
    /// </summary>
    public abstract class ApiBase
    {
        const string DefaultApiBaseUrl = "https://api.aspose.cloud";
        const string DefaultApiVersion = "3.0";

        /// <summary>
        /// Default constructor. Initalizes a new instance of an inherited class trying to get the user credentials
        /// (application SID and application key), REST API service URL and authentication service URL 
        /// from the application configuration file and then, if it don't succeed, from environment variables.
        /// If needed settings were not found both in the config file or in the environment variables, throws an exception. 
        /// </summary>
        protected internal ApiBase()
        {
            var clientId = System.Configuration.ConfigurationManager.AppSettings["clientId"];
            var clientSecret = System.Configuration.ConfigurationManager.AppSettings["clientSecret"];
            var apiBaseUrl = System.Configuration.ConfigurationManager.AppSettings["baseUrl"];
            var authUrl = System.Configuration.ConfigurationManager.AppSettings["authUrl"];

            if (string.IsNullOrEmpty(clientId))
            {
                clientId = Environment.GetEnvironmentVariable("clientId");
                if(string.IsNullOrEmpty(clientId))
                    clientId = Environment.GetEnvironmentVariable("client_id");
                if (string.IsNullOrEmpty(clientId))
                    throw new ArgumentException("\"clientId\" is required and isn't specified.");
            }

            if (string.IsNullOrEmpty(clientSecret))
            {
                clientSecret = Environment.GetEnvironmentVariable("clientSecret");
                if (string.IsNullOrEmpty(clientSecret))
                    clientSecret = Environment.GetEnvironmentVariable("client_secret");
                if (string.IsNullOrEmpty(clientSecret))
                    throw new ArgumentException("\"clientSecret\" is required and isn't specified.");
            }

            if (string.IsNullOrEmpty(apiBaseUrl))
            {
                apiBaseUrl = Environment.GetEnvironmentVariable("baseUrl");
                if (string.IsNullOrEmpty(apiBaseUrl))
                    apiBaseUrl = DefaultApiBaseUrl;
            }

            if (string.IsNullOrEmpty(authUrl))
            {
                authUrl = Environment.GetEnvironmentVariable("authUrl");
                if (string.IsNullOrEmpty(authUrl))
                    authUrl = DefaultApiBaseUrl;
            }

            if (!ApiClientUtils.UrlContainsVersion(apiBaseUrl))
            {
                var baseUrl = apiBaseUrl + "/v" + DefaultApiVersion;
                apiBaseUrl = baseUrl;
            }
            this.ApiClient = new ApiClient(clientId, clientSecret, apiBaseUrl, authUrl);
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of an inherited class as the default constructor does
        /// and sets the service connection timeout.
        /// </summary>
        /// <param name="timeout">Service connection timeout</param>
        protected internal ApiBase(TimeSpan timeout) : this()
        {
            this.ApiClient.Timeout = timeout;
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of an inherited class with specified REST API service URL
        /// and JWT token provided by the calling application 
        /// </summary>
        /// <param name="authToken">Object that contains external JWT token with its generation time and expiration period</param>
        /// <param name="basePath">REST API service URL</param>
        protected internal ApiBase(JwtToken authToken, string basePath = "https://api.aspose.cloud/v3.0")
        {
            this.ApiClient = new ApiClient(authToken, basePath);
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of an inherited class with specified REST API service URL,
        /// JWT token provided by the calling application and the service connection timeout.
        /// </summary>
        /// <param name="authToken">Object that contains external JWT token with its generation time and expiration period</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="timeout">Service connection timeout</param>
        protected internal ApiBase(JwtToken authToken, string basePath, TimeSpan timeout)
            : this(authToken, basePath)
        {
            this.ApiClient.Timeout = timeout;
        }

        /// <summary>
        /// Constructor. Initalizes a new instance ApiBase class with specified user credentials (application SID and application key),
        /// and REST API service URL; by default, authentication service URL is the same.        
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <param name="clientSecret">Client secret</param>
        /// <param name="basePath">REST API service URL</param>
        protected internal ApiBase(String clientId, String clientSecret, String basePath)
            : this(clientId, clientSecret, basePath, basePath)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of ApiBase class with specified user credentials (application SID and application key),
        /// REST API service URL and authentication service URL.
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <param name="clientSecret">Client secret</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="authPath">Authorization service URL</param>
        protected internal ApiBase(String clientId, String clientSecret, String basePath, String authPath)
        {
            if (!ApiClientUtils.UrlContainsVersion(basePath))
            {
                var baseUrl = $"{basePath}/v{DefaultApiVersion}";
                basePath = baseUrl;
            }
            this.ApiClient = new ApiClient(clientId, clientSecret, basePath, authPath);
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of ApiBase class with specified user credentials (application SID and application key),
        /// REST API service URL and service connection timeout; by default, authentication service URL is the same.
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <param name="clientSecret">Client secret</param>>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="timeout">Service connection timeout</param>
        protected internal ApiBase(String clientId, String clientSecret, String basePath, TimeSpan timeout)
            : this(clientId, clientSecret, basePath)
        {
            this.ApiClient.Timeout = timeout;
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of HtmlApi class with specified user credentials (application SID and application key),
        /// REST API service URL, authentication service URL and service connection timeout.
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <param name="clientSecret">Client secret</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="authPath">Authorization service URL</param>
        /// <param name="timeout">Service connection timeout</param>
        protected internal ApiBase(String clientId, String clientSecret, String basePath, String authPath, TimeSpan timeout)
            : this(clientId, clientSecret, basePath, authPath)
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
                config.ClientId, config.ClientSecret, config.ApiBaseUrl, config.AuthUrl);
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
