using System;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class ConfigureApiConnector 
    {

        public ConfigureApiConnector()
        {
        }

        [Fact]
        public void ConfigureViaObjectStyleTest()
        {
            var cfg = Configuration.New();
            cfg.ClientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            cfg.ClientId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";
            cfg.Timeout = TimeSpan.FromMinutes(10);

            using (var api = new HtmlApi(cfg))
            {
                // 
            }
        }

        [Fact]
        public void ConfigureByUsingChainBuilderStyleTest()
        {

            var cfg = Configuration.New()
                .WithClientSecret("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")
                .WithClientId("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX")
                .WithTimeout(TimeSpan.FromMinutes(10));

            using (var api = new HtmlApi(cfg))
            {
                // 
            }
        }

        [Fact]
        public void ConfigureByUsingBuilderStyleTest()
        {

            using (var api = new HtmlApi(_ => _
                .WithClientSecret("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")
                .WithClientId("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX")
                .WithTimeout(TimeSpan.FromMinutes(10))))
            {
                // 
            }
        }
    }
}