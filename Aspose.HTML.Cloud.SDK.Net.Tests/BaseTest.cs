using System;
using System.Net.Http;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class BaseTest
    {
        private const string QA_APPSID = "html.cloud";
        private const string QA_APPKEY = "html.cloud";
        //protected const string QA_APPSID = "80e32ca5-a828-46a4-9d54-7199dfd3764a";
        //protected const string QA_APPKEY = "60487a72d6325241191177e37ae52146";

        private const string QA_AUTH_URL = "https://api-qa.aspose.cloud/connect/token";

        private const string QA_API_URL = "https://api-qa.aspose.cloud/v4.0/html";
        private const string LOCAL_BASE_URL = "http://localhost:5000/v4.0/html";
        private const string LOCAL_DOCKER_BASE_URL = "http://localhost:47976/v4.0/html";
        //private const string LOCAL_DOCKER_BASE_URL = "http://localhost:63427/v4.0/html";
        public BaseTest()
        {
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(LOCAL_DOCKER_BASE_URL);

            return client;
        }

        public string AppSid { get; set; } = QA_APPSID;
        public string AppKey { get; set; } = QA_APPKEY;

        public string AuthServiceUrl { get; set; } = QA_AUTH_URL;

        public string ApiServiceBaseUrl { get; set; } = LOCAL_DOCKER_BASE_URL;
    }
}
