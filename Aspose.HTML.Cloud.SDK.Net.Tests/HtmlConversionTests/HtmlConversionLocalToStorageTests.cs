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
    public class HtmlConversionLocalToStorageTests 
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public HtmlConversionLocalToStorageTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionLocalToStorageTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_PDF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(new PDFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Html");

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
        public void ConvertFromLocalFileToStorage_PDF_WithParams()
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
                .FromLocalFile(@"Input\html_file.html")
                .To(pdfOpts)
                .SaveToStorageDirectory("/TestResult/Html/WithParams");

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
        public void ConvertFromLocalFileToStorage_XPS()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(new XPSConversionOptions())
                .SaveToStorageDirectory("/TestResult/Html");

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
        public void ConvertFromLocalFileToStorage_XPS_WithParams()
        {
            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(xpsOpts)
                .SaveToStorageDirectory("/TestResult/Html/WithParams");

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
        public void ConvertFromLocalFileToStorage_JPG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(new JPEGConversionOptions())
                .SaveToStorageDirectory("/TestResult/Html");

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
        public void ConvertFromLocalFileToStorage_JPG_WithParams()
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
                .FromLocalFile(@"Input\html_file.html")
                .To(jpgOpts)
                .SaveToStorageDirectory("/TestResult/Html/WithParams");

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
        public void ConvertFromLocalFileToStorage_PNG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(new PNGConversionOptions())
                .SaveToStorageDirectory("/TestResult/Html");

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
        public void ConvertFromLocalFileToStorage_PNG_WithParams()
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
                .FromLocalFile(@"Input\html_file.html")
                .To(pngOpts)
                .SaveToStorageDirectory("/TestResult/Html/WithParams");

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
        public void ConvertFromLocalFileToStorage_BMP()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(new BMPConversionOptions())
                .SaveToStorageDirectory("/TestResult/Html");

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
        public void ConvertFromLocalFileToStorage_BMP_WithParams()
        {
            ConversionOptions bmpOpts = new BMPConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(bmpOpts)
                .SaveToStorageDirectory("/TestResult/Html/WithParams");

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
        public void ConvertFromLocalFileToStorage_GIF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(new GIFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Html");

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
        public void ConvertFromLocalFileToStorage_GIF_WithParams()
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
                .FromLocalFile(@"Input\html_file.html")
                .To(gifOpts)
                .SaveToStorageDirectory("/TestResult/Html/WithParams");

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
        public void ConvertFromLocalFileToStorage_TIFF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(new TIFFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Html");

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
        public void ConvertFromLocalFileToStorage_TIFF_WithParams()
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
                .FromLocalFile(@"Input\html_file.html")
                .To(tiffOpts)
                .SaveToStorageDirectory("/TestResult/Html/WithParams");

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
        public void ConvertFromLocalFileToStorage_DOC()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(new DOCConversionOptions())
                .SaveToStorageDirectory("/TestResult/Html");

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
        public void ConvertFromLocalFileToStorage_DOC_WithParams()
        {
            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(docOpts)
                .SaveToStorageDirectory("/TestResult/Html/WithParams");

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
        public void ConvertFromLocalFileToStorage_MD()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(new MarkdownConversionOptions())
                .SaveToStorageDirectory("/TestResult/Html");

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
        public void ConvertFromLocalFileToStorage_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(mdOpts)
                .SaveToStorageDirectory("/TestResult/Html/WithParams");

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
        public void ConvertFromLocalFileToStorage_MHTML()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\html_file.html")
                .To(new MHTMLConversionOptions())
                .SaveToStorageDirectory("/TestResult/Html");

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
