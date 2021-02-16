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
    public class EpubConversionLocalToLocalTests 
    {
        string CliendId { get; set; }
        string ClientSecret { get; set; }

        public EpubConversionLocalToLocalTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionLocalToLocalTests>().Build();

            CliendId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PDF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\example.epub")
                .To(new PDFConversionOptions())
                .SaveToLocalDirectory(@"Output\Epub");

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
        public void ConvertFromLocalFileToLocal_PDF_WithParams()
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
                .FromLocalFile(@"Input\example.epub")
                .To(pdfOpts)
                .SaveToLocalDirectory(@"Output\Epub\WithParams");

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
        public void ConvertFromLocalFileToLocal_XPS()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\example.epub")
                .To(new XPSConversionOptions())
                .SaveToLocalDirectory(@"Output\Epub");

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
        public void ConvertFromLocalFileToLocal_XPS_WithParams()
        {
            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\example.epub")
                .To(xpsOpts)
                .SaveToLocalDirectory(@"Output\Epub\WithParams");

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
        public void ConvertFromLocalFileToLocal_JPG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\example.epub")
                .To(new JPEGConversionOptions())
                .SaveToLocalDirectory(@"Output\Epub");

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
        public void ConvertFromLocalFileToLocal_JPG_WithParams()
        {
            ConversionOptions jpegOpts = new JPEGConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
               .FromLocalFile(@"Input\example.epub")
               .To(jpegOpts)
               .SaveToLocalDirectory(@"Output\Epub\WithParams");

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
        public void ConvertFromLocalFileToLocal_PNG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\example.epub")
                .To(new PNGConversionOptions())
                .SaveToLocalDirectory(@"Output\Epub");

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
        public void ConvertFromLocalFileToLocal_PNG_WithParams()
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
               .FromLocalFile(@"Input\example.epub")
               .To(pngOpts)
               .SaveToLocalDirectory(@"Output\Epub\WithParams");

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
        public void ConvertFromLocalFileToLocal_BMP()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\example.epub")
                .To(new BMPConversionOptions())
                .SaveToLocalDirectory(@"Output\Epub");

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
        public void ConvertFromLocalFileToLocal_BMP_WithParams()
        {
            string sourceFile = TestHelper.SrcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.DstDir, "Epub", "WithParams");

            ConversionOptions bmpOpts = new BMPConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
               .FromLocalFile(@"Input\example.epub")
               .To(bmpOpts)
               .SaveToLocalDirectory(@"Output\Epub\WithParams");

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
        public void ConvertFromLocalFileToLocal_GIF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\example.epub")
                .To(new GIFConversionOptions())
                .SaveToLocalDirectory(@"Output\Epub");

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
        public void ConvertFromLocalFileToLocal_GIF_WithParams()
        {
            string sourceFile = TestHelper.SrcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.DstDir, "Epub", "WithParams");

            ConversionOptions gifOpts = new GIFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
               .FromLocalFile(@"Input\example.epub")
               .To(gifOpts)
               .SaveToLocalDirectory(@"Output\Epub\WithParams");

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
        public void ConvertFromLocalFileToLocal_TIFF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\example.epub")
                .To(new TIFFConversionOptions())
                .SaveToLocalDirectory(@"Output\Epub");

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
        public void ConvertFromLocalFileToLocal_TIFF_WithParams()
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
               .FromLocalFile(@"Input\example.epub")
               .To(tiffOpts)
               .SaveToLocalDirectory(@"Output\Epub\WithParams");

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
        public void ConvertFromLocalFileToLocal_DOC()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(@"Input\example.epub")
                .To(new DOCConversionOptions())
                .SaveToLocalDirectory(@"Output\Epub");

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
        public void ConvertFromLocalFileToLocal_DOC_WithParams()
        {
            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
               .FromLocalFile(@"Input\example.epub")
               .To(docOpts)
               .SaveToLocalDirectory(@"Output\Epub\WithParams");

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
