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
    public class UrlConversionToLocalTests 
    {
        string CliendId { get; set; }
        string ClientSecret { get; set; }

        public UrlConversionToLocalTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionStorageToStorageTests>().Build();

            CliendId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            System.IO.Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void ConvertFromUrlToLocal_PDF()
        {
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(new PDFConversionOptions())
                .SaveToLocalDirectory(@"Output\Url");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)              
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_PDF_WithParams()
        {
            ConversionOptions pdfOpts = new PDFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetQuality(95);

            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(pdfOpts)
                .SaveToLocalDirectory(@"Output\Url\WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)              
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_XPS()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(new XPSConversionOptions())
                .SaveToLocalDirectory(@"Output\Url");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_XPS_WithParams()
        {
            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(xpsOpts)
                .SaveToLocalDirectory(@"Output\Url\WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_JPG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(new JPEGConversionOptions())
                .SaveToLocalDirectory(@"Output\Url");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_JPG_WithParams()
        {
            ConversionOptions jpgOpts = new JPEGConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(jpgOpts)
                .SaveToLocalDirectory(@"Output\Url\WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_PNG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(new PNGConversionOptions())
                .SaveToLocalDirectory(@"Output\Url");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_PNG_WithParams()
        {
            ConversionOptions pngOpts = new PNGConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(pngOpts)
                .SaveToLocalDirectory(@"Output\Url\WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_BMP()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(new BMPConversionOptions())
                .SaveToLocalDirectory(@"Output\Url");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_BMP_WithParams()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.DstDir, "Url", "WithParams");

            ConversionOptions bmpOpts = new BMPConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(bmpOpts)
                .SaveToLocalDirectory(@"Output\Url\WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_GIF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(new GIFConversionOptions())
                .SaveToLocalDirectory(@"Output\Url");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_GIF_WithParams()
        {
            ConversionOptions gifOpts = new GIFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(gifOpts)
                .SaveToLocalDirectory(@"Output\Url\WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_TIFF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(new TIFFConversionOptions())
                .SaveToLocalDirectory(@"Output\Url");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_TIFF_WithParams()
        {
            ConversionOptions tiffOpts = new TIFFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(tiffOpts)
                .SaveToLocalDirectory(@"Output\Url\WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_MD()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(new MarkdownConversionOptions())
                .SaveToLocalDirectory(@"Output\Url");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(mdOpts)
                .SaveToLocalDirectory(@"Output\Url\WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromUrlToLocal_MHTML()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl("https://stallman.org/articles/anonymous-payments-thru-phones.html")
                .To(new MHTMLConversionOptions())
                .SaveToLocalDirectory(@"Output\Url");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

    }
}
