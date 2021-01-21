using System;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class ConfigureApiConnector : IClassFixture<BaseTest>
    {
        private readonly HttpClient httpClient;

        public ConfigureApiConnector(BaseTest fixture)
        {
            httpClient = fixture.CreateClient();
        }

        [Fact]
        public void ConfigureViaObjectStyleTest()
        {
            var cfg = new Configuration()
            {
                ClientId = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                ClientSecret = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Timeout = TimeSpan.FromMinutes(10),
                HttpClient = httpClient
            };
            using (var api = new HtmlApi(cfg))
            {
                // 
            }
        }

        [Fact]
        public void ConfigureByUsingChainBuilderStyleTest()
        {

            var cfg = Configuration.New()
                .WithClientId("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")
                .WithClientSecret("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX")
                .WithTimeout(TimeSpan.FromMinutes(10));
                //.WithHttpClient(httpClient);

            using (var api = new HtmlApi(cfg))
            {
                // 
            }
        }

        [Fact]
        public void ConfigureByUsingBuilderStyleTest()
        {

            using (var api = new HtmlApi(_ => _
                .WithClientId("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")
                .WithClientSecret("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX")
                .WithTimeout(TimeSpan.FromMinutes(10))))
            //.WithHttpClient(httpClient)))
            {
                // 
            }
        }
    }
}