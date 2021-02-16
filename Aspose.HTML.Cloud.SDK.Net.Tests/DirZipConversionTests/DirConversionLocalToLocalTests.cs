
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
    public class DirConversionLocalToLocalTests 
    {
        string CliendId { get; set; }
        string ClientSecret { get; set; }

        public DirConversionLocalToLocalTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionLocalToLocalTests>().Build();

            CliendId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if(Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_PDF()
        {
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new PDFConversionOptions())
                .SaveToLocalDirectory(@"Output\Dir");

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
        public void ConvertFromLocalDirToLocal_PDF_WithParams()
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
                .SaveToLocalDirectory(@"Output\Dir\WithParams");

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
        public void ConvertFromLocalDirToLocal_XPS()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new XPSConversionOptions())
                .SaveToLocalDirectory(@"Output\Dir");

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
        public void ConvertFromLocalDirToLocal_XPS_WithParams()
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
                .SaveToLocalDirectory(@"Output\Dir\WithParams");

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
        public void ConvertFromLocalDirToLocal_JPG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new JPEGConversionOptions())
                .SaveToLocalDirectory(@"Output\Dir");

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
        public void ConvertFromLocalDirToLocal_JPG_WithParams()
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
                .SaveToLocalDirectory(@"Output\Dir\WithParams");

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
        public void ConvertFromLocalDirToLocal_PNG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new PNGConversionOptions())
                .SaveToLocalDirectory(@"Output\Dir");

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
        public void ConvertFromLocalDirToLocal_PNG_WithParams()
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
                .SaveToLocalDirectory(@"Output\Dir\WithParams");

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
        public void ConvertFromLocalDirToLocal_BMP()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new BMPConversionOptions())
                .SaveToLocalDirectory(@"Output\Dir");

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
        public void ConvertFromLocalDirToLocal_BMP_WithParams()
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
                .SaveToLocalDirectory(@"Output\Dir\WithParams");

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
        public void ConvertFromLocalDirToLocal_GIF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new GIFConversionOptions())
                .SaveToLocalDirectory(@"Output\Dir");

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
        public void ConvertFromLocalDirToLocal_GIF_WithParams()
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
                .SaveToLocalDirectory(@"Output\Dir\WithParams");

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
        public void ConvertFromLocalDirToLocal_TIFF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new TIFFConversionOptions())
                .SaveToLocalDirectory(@"Output\Dir");

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
        public void ConvertFromLocalDirToLocal_TIFF_WithParams()
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
                .SaveToLocalDirectory(@"Output\Dir\WithParams");

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
        public void ConvertFromLocalDirToLocal_DOC()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new DOCConversionOptions())
                .SaveToLocalDirectory(@"Output\Dir");

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
        public void ConvertFromLocalDirToLocal_DOC_WithParams()
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
                .SaveToLocalDirectory(@"Output\Dir\WithParams");

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
        public void ConvertFromLocalDirToLocal_MD()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new MarkdownConversionOptions())
                .SaveToLocalDirectory(@"Output\Dir");

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
        public void ConvertFromLocalDirToLocal_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(mdOpts)
                .SaveToLocalDirectory(@"Output\Dir\WithParams");

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
        public void ConvertFromLocalDirToLocal_MHTML()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(@"Input\DirectoryTests\HtmlSite2", "index.html")
                .To(new MHTMLConversionOptions())
                .SaveToLocalDirectory(@"Output\Dir");

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
