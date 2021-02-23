using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.ApiParameters;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Linq;


namespace Aspose.HTML.Cloud.Sdk.Tests.MarkdownConversionTests
{
    public class MarkdownConversionSpecial_LocalToLocal
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public MarkdownConversionSpecial_LocalToLocal()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionLocalToLocalTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }


        [Fact]
        public void ConvertFromLocalFileToLocal_PDF()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\testpage1.md",
                    options: new PDFConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Md\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_XPS()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\testpage1.md",
                    options: new PDFConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Md\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_DOC()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\testpage1.md",
                    options: new DOCConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Md\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_JPEG()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\testpage1.md",
                    options: new JPEGConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Md\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PNG()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\testpage1.md",
                    options: new PNGConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Md\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_BMP()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\testpage1.md",
                    options: new BMPConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Md\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_GIF()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\testpage1.md",
                    options: new GIFConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Md\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_TIFF()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\testpage1.md",
                    options: new TIFFConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Md\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }
    }
}
