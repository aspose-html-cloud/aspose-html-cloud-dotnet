
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
    public class DirConversionLocalToStorageTests 
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public DirConversionLocalToStorageTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionLocalToLocalTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_PDF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new PDFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Dir");

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
        public void ConvertFromLocalDirToStorage_PDF_WithParams()
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
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(pdfOpts)
                .SaveToStorageDirectory("/TestResult/Dir/WithParams");

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
        public void ConvertFromLocalDirToStorage_XPS()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new XPSConversionOptions())
                .SaveToStorageDirectory("/TestResult/Dir");

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
        public void ConvertFromLocalDirToStorage_XPS_WithParams()
        {
            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(xpsOpts)
                .SaveToStorageDirectory("/TestResult/Dir/WithParams");

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
        public void ConvertFromLocalDirToStorage_JPG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new JPEGConversionOptions())
                .SaveToStorageDirectory("/TestResult/Dir");

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
        public void ConvertFromLocalDirToStorage_JPG_WithParams()
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
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(jpgOpts)
                .SaveToStorageDirectory("/TestResult/Dir/WithParams");

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
        public void ConvertFromLocalDirToStorage_PNG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new PNGConversionOptions())
                .SaveToStorageDirectory("/TestResult/Dir");

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
        public void ConvertFromLocalDirToStorage_PNG_WithParams()
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
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(pngOpts)
                .SaveToStorageDirectory("/TestResult/Dir/WithParams");

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
        public void ConvertFromLocalDirToStorage_BMP()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new BMPConversionOptions())
                .SaveToStorageDirectory("/TestResult/Dir");

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
        public void ConvertFromLocalDirToStorage_BMP_WithParams()
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
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(bmpOpts)
                .SaveToStorageDirectory("/TestResult/Dir/WithParams");

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
        public void ConvertFromLocalDirToStorage_GIF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new GIFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Dir");

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
        public void ConvertFromLocalDirToStorage_GIF_WithParams()
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
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(gifOpts)
                .SaveToStorageDirectory("/TestResult/Dir/WithParams");

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
        public void ConvertFromLocalDirToStorage_TIFF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new TIFFConversionOptions())
                .SaveToStorageDirectory("/TestResult/Dir");

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
        public void ConvertFromLocalDirToStorage_TIFF_WithParams()
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
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(tiffOpts)
                .SaveToStorageDirectory("/TestResult/Dir/WithParams");

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
        public void ConvertFromLocalDirToStorage_DOC()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new DOCConversionOptions())
                .SaveToStorageDirectory("/TestResult/Dir");

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
        public void ConvertFromLocalDirToStorage_DOC_WithParams()
        {
            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(docOpts)
                .SaveToStorageDirectory("/TestResult/Dir/WithParams");

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
        public void ConvertFromLocalDirToStorage_MD()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new MarkdownConversionOptions())
                .SaveToStorageDirectory("/TestResult/Dir");

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
        public void ConvertFromLocalDirToStorage_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(mdOpts)
                .SaveToStorageDirectory("/TestResult/Dir/WithParams");

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
        public void ConvertFromLocalDirToStorage_MHTML()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new MHTMLConversionOptions())
                .SaveToStorageDirectory("/TestResult/Dir");

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
