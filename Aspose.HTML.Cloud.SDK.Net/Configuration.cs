// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="Configuration.cs">
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
using System.Net.Http;

namespace Aspose.HTML.Cloud.Sdk
{
    public class Configuration 
    {
        public const string CONF_AUTHURL = "AuthUrl";
        public const string CONF_APIBASEURL = "ApiBaseUrl";
        public const string CONF_APPSID = "AppSid";
        public const string CONF_APPKEY = "AppKey";
        public const string CONF_TIMEOUT = "Timeout";

        public const string CONF_CLIENTID = "client_id";
        public const string CONF_CLIENTSECRET = "client_secret";

#if PRODUCTION
        public const string DEF_AUTH_URL = "https://api.aspose.cloud/connect/token";
        public const string DEF_API_URL = "https://api.aspose.cloud/v4.0/html";
#else
        public const string DEF_AUTH_URL = "https://api-qa.aspose.cloud/connect/token";

#if DEBUG
        public const string DEF_API_URL = "http://localhost:5000/v4.0/html";
#else
        public const string DEF_API_URL = "https://api-qa.aspose.cloud/v4.0/html";
#endif

#endif

        public static string[] ConfigParams = { 
            CONF_AUTHURL, 
            CONF_APIBASEURL, 
            CONF_APPSID, 
            CONF_APPKEY, 
            CONF_TIMEOUT,
            CONF_CLIENTID,
            CONF_CLIENTSECRET
        };
        public string BaseUrl { get; set; } = "/v4.0/html/";

        public string AuthUrl { get; set; } = DEF_AUTH_URL;
        public string AppKey { get; set; }
        public string AppSid { get; set; }
        public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(1);

        public HttpClient HttpClient { get; set; } = new HttpClient();

        internal string ExternalAuthToken { get; private set; }

        public bool UseExternalAuthentication { get; private set; } = false;

        internal static readonly Configuration Default = new Configuration();

        public static Configuration New()
        {
            return new Configuration();
        }

        public static Configuration NewDefault()
        {
            return new Configuration() {
                AuthUrl = DEF_AUTH_URL,
                BaseUrl = DEF_API_URL
            };
        }

#region REM - reserved for future implementation
        //public static Configuration GetFromAppConfig()
        //{
        //    // TODO:
        //    return NewDefault();
        //}

        //public static Configuration GetFromEnvironment()
        //{
        //    //Dictionary<string, string> dictEnv = new Dictionary<string, string>(Environment.GetEnvironmentVariables(), );
        //    //dictEnv.Select()
        //    //.
        //    var args = Environment.GetCommandLineArgs();

        //    // TODO:
        //    return NewDefault();
        //}
#endregion

        public Configuration WithAppKey(string appKey)
        {
            this.AppKey = appKey;
            return this;
        }

        public Configuration WithAppSid(string appSid)
        {
            this.AppSid = appSid;
            return this;
        }

        public Configuration WithTimeout(TimeSpan timeout)
        {
            this.Timeout = timeout;
            return this;
        }

        //internal Configuration WithHttpClient(HttpClient httpClient)
        //{
        //    this.HttpClient = httpClient;
        //    return this;
        //}

        public Configuration WithExternalAuthentication(string token)
        {
            UseExternalAuthentication = !string.IsNullOrEmpty(token);
            ExternalAuthToken = token;
            return this;
        }

        private const string ISO8601_DATETIME_FORMAT = "o";

        private static string _dateTimeFormat = ISO8601_DATETIME_FORMAT;

        /// <summary>
        /// Gets or sets the the date time format used when serializing in the ApiClient
        /// By default, it's set to ISO 8601 - "o", for others see:
        /// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        /// and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        /// No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        internal static String DateTimeFormat
        {
            get
            {
                return _dateTimeFormat;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }


        public class ConfigurationBuilder
        {
            private Configuration configuration;
            internal ConfigurationBuilder(Action<Configuration.ConfigurationBuilder> func)
            {
                configuration = new Configuration();
                func(this);
            }
            public ConfigurationBuilder WithBaseUrl(string url)
            {
                configuration.BaseUrl = url;
                return this;
            }

            public ConfigurationBuilder WithAuthUrl(string url)
            {
                configuration.AuthUrl = url ?? DEF_AUTH_URL;
                return this;
            }

            public ConfigurationBuilder WithAppKey(string appKey)
            {
                configuration.AppKey = appKey;
                return this;
            }

            public ConfigurationBuilder WithAppSid(string appSid)
            {
                configuration.AppSid = appSid;
                return this;
            }

            public ConfigurationBuilder WithTimeout(TimeSpan timeout)
            {
                configuration.Timeout = timeout;
                return this;
            }

            public ConfigurationBuilder WithHttpClient(HttpClient httpClient)
            {
                configuration.HttpClient = httpClient;
                return this;
            }

            public ConfigurationBuilder WithExternalAuthentication(string token)
            {
                configuration.WithExternalAuthentication(token);
                return this;
            }

            internal Configuration Build()
            {
                return configuration;
            }
        }
    }

    
}