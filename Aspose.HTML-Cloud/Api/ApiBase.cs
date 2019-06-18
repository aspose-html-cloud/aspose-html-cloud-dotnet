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
//using Com.Aspose.Html.Client;
//using Com.Aspose.Html.NativeClient;

using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.Html.Cloud.Sdk.Api
{
    /// <summary>
    /// Base abstract class for REST API wrapper classes.
    /// </summary>
    public abstract class ApiBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        internal ApiBase(String appSid, String appKey, String basePath)
        {
            this.ApiClient = new ApiClient(appSid, appKey, basePath, basePath);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="authPath">Authorization service URL</param>
        internal ApiBase(String appSid, String appKey, String basePath, String authPath)
        {
            this.ApiClient = new ApiClient(appSid, appKey, basePath, authPath);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="timeout">Service connection timeout</param>
        internal ApiBase(String appSid, String appKey, String basePath, TimeSpan timeout)
            : this(appSid, appKey, basePath)
        {
            this.ApiClient.Timeout = timeout;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="authPath">Authorization service URL</param>
        /// <param name="timeout">Service connection timeout</param>
        internal ApiBase(String appSid, String appKey, String basePath, String authPath, TimeSpan timeout)
            : this(appSid, appKey, basePath, authPath)
        {
            this.ApiClient.Timeout = timeout;
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
