using System;
using System.Net.Http;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class BaseTest
    {
        private const string PROD_CLIENTID = "6ce9b6d0-5135-4547-bafb-176e44c8d630";   // put here your client ID
        private const string PROD_SECRET = "35d7f7eeca6901e8833dff150455f0f6";        // put here your client secret
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
