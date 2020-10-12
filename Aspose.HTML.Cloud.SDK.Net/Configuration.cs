using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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

        public string AuthUrl { get; set; }
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
                AuthUrl = "https://api.aspose.cloud/",
                BaseUrl = "https://api.aspose.cloud/v4.0/html"
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

        public Configuration WithHttpClient(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
            return this;
        }

        public Configuration WithExternalAuthentication(string token)
        {
            UseExternalAuthentication = !string.IsNullOrEmpty(token);
            ExternalAuthToken = token;
            return this;
        }

        //public Configuration Clone()
        //{
        //    var builder = new ConfigurationBuilder( _ => _
        //        .WithAppKey(this.AppKey)
        //        .WithAppSid(this.AppSid)
        //        .WithBaseUrl(this.BaseUrl)
        //        .WithTimeout(this.Timeout)
        //        .WithHttpClient( new HttpClient()));
                
        //    var newInst = builder.Build();
        //    newInst.HttpClient.BaseAddress = this.HttpClient.BaseAddress;
        //    //newInst.HttpClient.
        //    return newInst;
        //}

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
        public static String DateTimeFormat
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
                configuration.AuthUrl = url;
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