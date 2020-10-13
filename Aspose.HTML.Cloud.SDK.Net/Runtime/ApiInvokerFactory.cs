using Aspose.HTML.Cloud.Sdk.Runtime.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Aspose.HTML.Cloud.Sdk.Runtime
{
    internal class ApiInvokerFactory
    {
        private IAuthenticator Authenticator { get; set; }
        private Configuration Configuration { get; set; }

        private HttpClient HttpClient { get; set; }

        public ApiInvokerFactory(IAuthenticator auth, Configuration configuration)
        {
            Configuration = configuration;
            Authenticator = auth;
            HttpClient = configuration.HttpClient ?? new HttpClient();
        }

        public ApiInvokerFactory(IAuthenticator auth, HttpClient client)
        {
            Authenticator = auth;
            HttpClient = client;
        }

        public ApiInvoker<TResult> GetInvoker<TResult>()
        {
            return ApiInvoker<TResult>.New(Authenticator, HttpClient, Configuration.BaseUrl);
            //return ApiInvoker<TResult>.New(Configuration, Authenticator);
        }
    }
}
