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
    public class ZipConversionLocalToStorageTests
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public ZipConversionLocalToStorageTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionLocalToLocalTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PDF()
        {
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(new PDFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Zip");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }
    

        [Fact]
        public void ConvertFromLocalZipToStorage_PDF_WithParams()
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
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(pdfOpts)
                .SaveToStorageDirectory("/TestResult/Zip/WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_XPS()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(new XPSConversionOptions())
                .SaveToStorageDirectory("/TestResult/Zip");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_XPS_WithParams()
        {
            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(xpsOpts)
                .SaveToStorageDirectory("/TestResult/Zip/WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_JPG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(new JPEGConversionOptions())
                .SaveToStorageDirectory("/TestResult/Zip");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_JPG_WithParams()
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
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(jpgOpts)
                .SaveToStorageDirectory("/TestResult/Zip/WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PNG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(new PNGConversionOptions())
                .SaveToStorageDirectory("/TestResult/Zip");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PNG_WithParams()
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
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(pngOpts)
                .SaveToStorageDirectory("/TestResult/Zip/WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_BMP()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(new BMPConversionOptions())
                .SaveToStorageDirectory("/TestResult/Zip");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_BMP_WithParams()
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
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(bmpOpts)
                .SaveToStorageDirectory("/TestResult/Zip/WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_GIF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(new GIFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Zip");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_GIF_WithParams()
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
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(gifOpts)
                .SaveToStorageDirectory("/TestResult/Zip/WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_TIFF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(new TIFFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Zip");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_TIFF_WithParams()
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
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(tiffOpts)
                .SaveToStorageDirectory("/TestResult/Zip/WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_DOC()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(new DOCConversionOptions())
                .SaveToStorageDirectory("/TestResult/Zip");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_DOC_WithParams()
        {
            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(docOpts)
                .SaveToStorageDirectory("/TestResult/Zip/WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_MD()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(new MarkdownConversionOptions())
                .SaveToStorageDirectory("/TestResult/Zip");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(mdOpts)
                .SaveToStorageDirectory("/TestResult/Zip/WithParams");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_MHTML()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(@"Input\ZipTests\test1.zip", "index.html")
                .To(new MHTMLConversionOptions())
                .SaveToStorageDirectory("/TestResult/Zip");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

    }
}
