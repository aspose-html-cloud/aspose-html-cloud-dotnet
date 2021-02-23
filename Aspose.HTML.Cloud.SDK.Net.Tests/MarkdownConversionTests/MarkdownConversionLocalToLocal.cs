using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class MarkdownConversionLocalToLocal
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public MarkdownConversionLocalToLocal()
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
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\testpage1.md")
                .To(new PDFConversionOptions())
                .SaveToLocalDirectory(@"Output\Md");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)              // from user secrets
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_XPS()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\testpage1.md")
                .To(new XPSConversionOptions())
                .SaveToLocalDirectory(@"Output\Md");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)              // from user secrets
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_DOC()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\testpage1.md")
                .To(new XPSConversionOptions())
                .SaveToLocalDirectory(@"Output\Md");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)              // from user secrets
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_JPEG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\testpage1.md")
                .To(new JPEGConversionOptions())
                .SaveToLocalDirectory(@"Output\Md");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)              // from user secrets
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PNG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\testpage1.md")
                .To(new PNGConversionOptions())
                .SaveToLocalDirectory(@"Output\Md");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)              // from user secrets
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_BMP()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\testpage1.md")
                .To(new BMPConversionOptions())
                .SaveToLocalDirectory(@"Output\Md");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)              // from user secrets
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_GIF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\testpage1.md")
                .To(new GIFConversionOptions())
                .SaveToLocalDirectory(@"Output\Md");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)              // from user secrets
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }


        [Fact]
        public void ConvertFromLocalFileToLocal_TIFF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\testpage1.md")
                .To(new TIFFConversionOptions())
                .SaveToLocalDirectory(@"Output\Md");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)              // from user secrets
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

    }
}
