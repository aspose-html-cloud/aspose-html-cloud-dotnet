using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.ApiParameters;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Linq;


namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class UrlConversionSpecial_ToStorageTests
    {

        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public UrlConversionSpecial_ToStorageTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionStorageToStorageTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                System.IO.Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void ConvertFromUrlToStorage_PDF()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertUrl(
                    url: @"https://stallman.org/articles/anonymous-payments-thru-phones.html",
                    options: new PDFConversionOptions(),
                    outputPath: new RemoteDirectoryParameter("/TestResult/Url/Spec"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToStorage_PDF_1()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertUrl(
                    url: @"https://stallman.org/articles/anonymous-payments-thru-phones.html",
                    options: new PDFConversionOptions(),
                    outputPath: "/TestResult/Url/Spec2");
                // string outputPath is treated as default remote storage path

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToStorage_JPEG()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertUrl(
                    url: @"https://stallman.org/articles/anonymous-payments-thru-phones.html",
                    options: new JPEGConversionOptions(),
                    outputPath: new RemoteDirectoryParameter("/TestResult/Url/Spec"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToStorage_JPEG_1()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertUrl(
                    url: @"https://stallman.org/articles/anonymous-payments-thru-phones.html",
                    options: new JPEGConversionOptions(),
                    outputPath: "/TestResult/Url/Spec2");
                // string outputPath is treated as default remote storage path

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

    }
}
