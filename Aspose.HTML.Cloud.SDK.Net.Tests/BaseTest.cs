using System;
using System.IO;
using System.Net.Http;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class BaseTest  /*<TStartup> : WebApplicationFactory<TStartup> where TStartup : class*/
    {
        private const string QA_APPSID = "html.cloud";
        private const string QA_APPKEY = "html.cloud";

        private const string QA_AUTH_URL = "https://api-qa.aspose.cloud/connect/token";
        private const string LOCAL_BASE_URL = "https://localhost:5001/v4.0/html";

        public BaseTest()
        {
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();

            return client;
        }

        public string AppSid { get; set; } = QA_APPSID;
        public string AppKey { get; set; } = QA_APPKEY;

        public string AuthServiceUrl { get; set; } = QA_AUTH_URL;

        public string ApiServiceBaseUrl { get; set; } = LOCAL_BASE_URL;


        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        //{
        //    builder.ConfigureTestServices(services =>
        //    {
        //        // Dynabic.Billing.Services.Abstractions.IUsageProcessor
        //        // get clientIP, in test => throw errors

        //        // Or send Header
        //        //_client.DefaultRequestHeaders
        //        //    .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //_client.DefaultRequestHeaders.TryAddWithoutValidation("X-Forwarded-For", "localhost");
        //        var descriptor = services.SingleOrDefault(s =>
        //           s.ServiceType.Name == "IUsageProcessor");

        //        Mock<IUsageProcessor> mockClient = new Mock<IUsageProcessor>();

        //        bool result = services.Remove(descriptor);
        //        services.AddSingleton(typeof(IUsageProcessor), mockClient.Object);
        //    });
        //}
    }
}
