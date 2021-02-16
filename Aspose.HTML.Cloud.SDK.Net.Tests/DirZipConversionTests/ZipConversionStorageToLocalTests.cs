
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
    public class ZipConversionStorageToLocalTests 
    {
        string CliendId { get; set; }
        string ClientSecret { get; set; }

        public ZipConversionStorageToLocalTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionLocalToLocalTests>().Build();

            CliendId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");

            using (var api = new HtmlApi(CliendId, ClientSecret))
            {
                var remoteFile = api.Storage.UploadFile(
                    @"Input\ZipTests/test1.zip",
                    "/test1.zip", null,
                    IO.NameCollisionOption.ReplaceExisting);
            }
        }

        [Fact]
        public void ConvertFromStorageZipToLocal_PDF()
        {
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromStorageArchive("/test1.zip", "index.html")
                .To(new PDFConversionOptions())
                .SaveToLocalDirectory(@"Output\Zip");

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
        public void ConvertFromStorageZipToLocal_PDF_WithParams()
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
                .FromStorageArchive("/test1.zip", "index.html")
                .To(pdfOpts)
                .SaveToLocalDirectory(@"Output\Zip\WithParams");

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
        public void ConvertFromStorageZipToLocal_XPS()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(new XPSConversionOptions())
                .SaveToLocalDirectory(@"Output\Zip");

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
        public void ConvertFromStorageZipToLocal_XPS_WithParams()
        {
            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(xpsOpts)
                .SaveToLocalDirectory(@"Output\Zip\WithParams");

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
        public void ConvertFromStorageZipToLocal_JPG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(new JPEGConversionOptions())
                .SaveToLocalDirectory(@"Output\Zip");

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
        public void ConvertFromStorageZipToLocal_JPG_WithParams()
        {
            string sourceArch = "/test1.zip";
            string destFolder = Path.Combine(TestHelper.DstDir, "Zip", "WithParams");

            ConversionOptions jpgOpts = new JPEGConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(jpgOpts)
                .SaveToLocalDirectory(@"Output\Zip\WithParams");

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
        public void ConvertFromStorageZipToLocal_PNG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(new PNGConversionOptions())
                .SaveToLocalDirectory(@"Output\Zip");

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
        public void ConvertFromStorageZipToLocal_PNG_WithParams()
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
                .FromStorageArchive("/test1.zip", "index.html")
                .To(pngOpts)
                .SaveToLocalDirectory(@"Output\Zip\WithParams");

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
        public void ConvertFromStorageZipToLocal_BMP()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(new BMPConversionOptions())
                .SaveToLocalDirectory(@"Output\Zip");

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
        public void ConvertFromStorageZipToLocal_BMP_WithParams()
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
                .FromStorageArchive("/test1.zip", "index.html")
                .To(bmpOpts)
                .SaveToLocalDirectory(@"Output\Zip\WithParams");

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
        public void ConvertFromStorageZipToLocal_GIF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(new GIFConversionOptions())
                .SaveToLocalDirectory(@"Output\Zip");

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
        public void ConvertFromStorageZipToLocal_GIF_WithParams()
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
                .FromStorageArchive("/test1.zip", "index.html")
                .To(gifOpts)
                .SaveToLocalDirectory(@"Output\Zip\WithParams");

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
        public void ConvertFromStorageZipToLocal_TIFF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(new TIFFConversionOptions())
                .SaveToLocalDirectory(@"Output\Zip");

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
        public void ConvertFromStorageZipToLocal_TIFF_WithParams()
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
                .FromStorageArchive("/test1.zip", "index.html")
                .To(tiffOpts)
                .SaveToLocalDirectory(@"Output\Zip\WithParams");

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
        public void ConvertFromStorageZipToLocal_DOC()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(new DOCConversionOptions())
                .SaveToLocalDirectory(@"Output\Zip");

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
        public void ConvertFromStorageZipToLocal_DOC_WithParams()
        {
            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(docOpts)
                .SaveToLocalDirectory(@"Output\Zip\WithParams");

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
        public void ConvertFromStorageZipToLocal_MD()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(new MarkdownConversionOptions())
                .SaveToLocalDirectory(@"Output\Zip");

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
        public void ConvertFromStorageZipToLocal_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(mdOpts)
                .SaveToLocalDirectory(@"Output\Zip\WithParams");

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
        public void ConvertFromStorageZipToLocal_MHTML()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageArchive("/test1.zip", "index.html")
                .To(new MHTMLConversionOptions())
                .SaveToLocalDirectory(@"Output\Zip");

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
