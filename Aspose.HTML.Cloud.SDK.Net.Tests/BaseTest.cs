using System;
using System.Net.Http;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class BaseTest
    {
        private const string QA_APPSID = "html.cloud";
        private const string QA_APPKEY = "html.cloud";


        private const string QA_AUTH_URL = "https://api-qa.aspose.cloud/connect/token";
        private const string QA_API_URL = "https://api-qa.aspose.cloud/v4.0/html";

        private const string PROD_APPSID = "xxxxxxxxxxxx";   // put here your own app sid
        private const string PROD_APPKEY = "xxxxxxxxxxxx";   // put here your own app key
        private const string PROD_AUTH_URL = "https://api.aspose.cloud/connect/token";
        private const string PROD_API_URL = "https://api.aspose.cloud/v4.0/html";

        public BaseTest()
        {
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(QA_API_URL);

            return client;
        }

        public string AppSid { get; set; } = QA_APPSID;
        public string AppKey { get; set; } = QA_APPKEY;

        public string AuthServiceUrl { get; set; } = QA_AUTH_URL;

        public string ApiServiceBaseUrl { get; set; } = QA_API_URL;
    }
}
