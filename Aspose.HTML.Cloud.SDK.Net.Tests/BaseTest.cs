using System;
using System.Net.Http;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class BaseTest
    {
        private const string QA_APPSID = "html.cloud";
        private const string QA_APPKEY = "html.cloud";

        private const string QA_APPSID_1 = "80e32ca5-a828-46a4-9d54-7199dfd3764a";
        private const string QA_APPKEY_1 = "60487a72d6325241191177e37ae52146";

        private const string QA_AUTH_URL = "https://api-qa.aspose.cloud/connect/token";

        private const string QA_API_URL = "https://api-qa.aspose.cloud/v4.0/html";
        private const string LOCAL_BASE_URL = "http://localhost:5000/v4.0/html";
        private const string LOCAL_DOCKER_BASE_URL = "http://localhost:47976/v4.0/html";
        //private const string LOCAL_DOCKER_BASE_URL = "http://localhost:63427/v4.0/html";

        private const string PROD_APPSID = "6ce9b6d0-5135-4547-bafb-176e44c8d630";
        private const string PROD_APPKEY = "35d7f7eeca6901e8833dff150455f0f6";
        private const string PROD_AUTH_URL = "https://api.aspose.cloud/connect/token";
        private const string PROD_API_URL = "https://api.aspose.cloud/v4.0/html";

        public BaseTest()
        {
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(LOCAL_BASE_URL);

            return client;
        }

        public string AppSid { get; set; } = QA_APPSID_1;
        public string AppKey { get; set; } = QA_APPKEY_1;

        public string AuthServiceUrl { get; set; } = QA_AUTH_URL;

        public string ApiServiceBaseUrl { get; set; } = LOCAL_BASE_URL;
    }
}
