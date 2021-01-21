using System;
using System.Net.Http;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class BaseTest
    {
        private const string PROD_CLIENTID = "xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";   // put here your client ID
        private const string PROD_SECRET =   "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";        // put here your client secret
        private const string PROD_AUTH_URL = "https://api.aspose.cloud/connect/token";
        private const string PROD_API_URL = "https://api.aspose.cloud/v4.0/html";


        public BaseTest()
        {
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(PROD_API_URL);

            return client;
        }

        public string ClientId { get; set; } = PROD_CLIENTID;
        public string ClientSecret { get; set; } = PROD_SECRET;

        public string AuthServiceUrl { get; set; } = PROD_AUTH_URL;

        public string ApiServiceBaseUrl { get; set; } = PROD_API_URL;
    }
}
