using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.Net.Http;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.IO;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class EpubConversionStorageToStorageTests 
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public EpubConversionStorageToStorageTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionStorageToLocalTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");

            using (var api = new HtmlApi(ClientId, ClientSecret))
            {
                var remoteFile = api.Storage.UploadFile(
                    @"Input\example.epub",
                    "/example.epub", null,
                    IO.NameCollisionOption.ReplaceExisting);
            }
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PDF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(new PDFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Epub");

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
        public void ConvertFromStorageFileToStorage_PDF_WithParams()
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
                .FromStorageFile("/example.epub")
                .To(pdfOpts)
                .SaveToStorageDirectory("/TestResult/Epub/WithParams");

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
        public void ConvertFromStorageFileToStorage_XPS()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(new XPSConversionOptions())
                .SaveToStorageDirectory("/TestResult/Epub");

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
        public void ConvertFromStorageFileToStorage_XPS_WithParams()
        {
            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(xpsOpts)
                .SaveToStorageDirectory("/TestResult/Epub/WithParams");

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
        public void ConvertFromStorageFileToStorage_JPG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(new JPEGConversionOptions())
                .SaveToStorageDirectory("/TestResult/Epub");

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
        public void ConvertFromStorageFileToStorage_JPG_WithParams()
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
                .FromStorageFile("/example.epub")
                .To(jpgOpts)
                .SaveToStorageDirectory("/TestResult/Epub/WithParams");

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
        public void ConvertFromStorageFileToStorage_PNG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(new PNGConversionOptions())
                .SaveToStorageDirectory("/TestResult/Epub");

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
        public void ConvertFromStorageFileToStorage_PNG_WithParams()
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
                .FromStorageFile("/example.epub")
                .To(pngOpts)
                .SaveToStorageDirectory("/TestResult/Epub/WithParams");

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
        public void ConvertFromStorageFileToStorage_BMP()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(new BMPConversionOptions())
                .SaveToStorageDirectory("/TestResult/Epub");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                ConversionResult result = api.Convert(builder);

                Assert.True(result.Status == "success");
                Assert.True(result.Files.Any());
            }
        }

        [Fact/*(Skip = "Out of memory")*/]
        public void ConvertFromStorageFileToStorage_BMP_WithParams()
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
                .FromStorageFile("/example.epub")
                .To(bmpOpts)
                .SaveToStorageDirectory("/TestResult/Epub/WithParams");

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
        public void ConvertFromStorageFileToStorage_GIF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(new GIFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Epub");

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
        public void ConvertFromStorageFileToStorage_GIF_WithParams()
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
                .FromStorageFile("/example.epub")
                .To(gifOpts)
                .SaveToStorageDirectory("/TestResult/Epub/WithParams");

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
        public void ConvertFromStorageFileToStorage_TIFF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(new TIFFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Epub");

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
        public void ConvertFromStorageFileToStorage_TIFF_WithParams()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            ConversionOptions tiffOpts = new TIFFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(tiffOpts)
                .SaveToStorageDirectory("/TestResult/Epub/WithParams");

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
        public void ConvertFromStorageFileToStorage_DOC()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(new DOCConversionOptions())
                .SaveToStorageDirectory("/TestResult/Epub");

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
        public void ConvertFromStorageFileToStorage_DOC_WithParams()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/example.epub")
                .To(docOpts)
                .SaveToStorageDirectory("/TestResult/Epub/WithParams");

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
