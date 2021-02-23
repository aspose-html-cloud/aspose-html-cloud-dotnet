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
    public class XhtmlConversionLocalToLocal
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public XhtmlConversionLocalToLocal()
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
                .FromLocalFile(@"Input\html_example1.xhtml")
                .To(new PDFConversionOptions())
                .SaveToLocalDirectory(@"Output\Xhtml");

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
                .FromLocalFile(@"Input\html_example1.xhtml")
                .To(new XPSConversionOptions())
                .SaveToLocalDirectory(@"Output\Xhtml");

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
                .FromLocalFile(@"Input\html_example1.xhtml")
                .To(new DOCConversionOptions())
                .SaveToLocalDirectory(@"Output\Xhtml");

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
                .FromLocalFile(@"Input\html_example1.xhtml")
                .To(new JPEGConversionOptions())
                .SaveToLocalDirectory(@"Output\Xhtml");

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
                .FromLocalFile(@"Input\html_example1.xhtml")
                .To(new PNGConversionOptions())
                .SaveToLocalDirectory(@"Output\Xhtml");

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
                .FromLocalFile(@"Input\html_example1.xhtml")
                .To(new BMPConversionOptions())
                .SaveToLocalDirectory(@"Output\Xhtml");

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
                .FromLocalFile(@"Input\html_example1.xhtml")
                .To(new GIFConversionOptions())
                .SaveToLocalDirectory(@"Output\Xhtml");

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
                .FromLocalFile(@"Input\html_example1.xhtml")
                .To(new TIFFConversionOptions())
                .SaveToLocalDirectory(@"Output\Xhtml");

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
        public void ConvertFromLocalFileToLocal_MHTML()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_example1.xhtml")
                .To(new MHTMLConversionOptions())
                .SaveToLocalDirectory(@"Output\Xhtml");

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
