﻿using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class HtmlConversionStorageToLocalTests 
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public HtmlConversionStorageToLocalTests()
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
                    @"Input\html_file.html",
                    "/html_file.html", null, 
                    IO.NameCollisionOption.ReplaceExisting);
            }
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_PDF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(new PDFConversionOptions())
                .SaveToLocalDirectory(@"Output\Html");

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
        public void ConvertFromStorageFileToLocal_PDF_WithParams()
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
                .FromStorageFile("/html_file.html")
                .To(pdfOpts)
                .SaveToLocalDirectory(@"Output\Html\WithParams");

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
        public void ConvertFromStorageFileToLocal_XPS()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(new XPSConversionOptions())
                .SaveToLocalDirectory(@"Output\Html");

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
        public void ConvertFromStorageFileToLocal_XPS_WithParams()
        {
            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(xpsOpts)
                .SaveToLocalDirectory(@"Output\Html\WithParams");

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
        public void ConvertFromStorageFileToLocal_JPG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(new JPEGConversionOptions())
                .SaveToLocalDirectory(@"Output\Html");

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
        public void ConvertFromStorageFileToLocal_JPG_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.DstDir, "Html", "WithParams");

            ConversionOptions jpgOpts = new JPEGConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(jpgOpts)
                .SaveToLocalDirectory(@"Output\Html\WithParams");

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
        public void ConvertFromStorageFileToLocal_PNG()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(new PNGConversionOptions())
                .SaveToLocalDirectory(@"Output\Html");

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
        public void ConvertFromStorageFileToLocal_PNG_WithParams()
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
                .FromStorageFile("/html_file.html")
                .To(pngOpts)
                .SaveToLocalDirectory(@"Output\Html\WithParams");

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
        public void ConvertFromStorageFileToLocal_BMP()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(new BMPConversionOptions())
                .SaveToLocalDirectory(@"Output\Html");

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
        public void ConvertFromStorageFileToLocal_BMP_WithParams()
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
                .FromStorageFile("/html_file.html")
                .To(bmpOpts)
                .SaveToLocalDirectory(@"Output\Html\WithParams");

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
        public void ConvertFromStorageFileToLocal_GIF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(new GIFConversionOptions())
                .SaveToLocalDirectory(@"Output\Html");

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
        public void ConvertFromStorageFileToLocal_GIF_WithParams()
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
                .FromStorageFile("/html_file.html")
                .To(gifOpts)
                .SaveToLocalDirectory(@"Output\Html\WithParams");

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
        public void ConvertFromStorageFileToLocal_TIFF()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(new TIFFConversionOptions())
                .SaveToLocalDirectory(@"Output\Html");

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
        public void ConvertFromStorageFileToLocal_TIFF_WithParams()
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
                .FromStorageFile("/html_file.html")
                .To(tiffOpts)
                .SaveToLocalDirectory(@"Output\Html\WithParams");

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
        public void ConvertFromStorageFileToLocal_DOC()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(new DOCConversionOptions())
                .SaveToLocalDirectory(@"Output\Html");

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
        public void ConvertFromStorageFileToLocal_DOC_WithParams()
        {
            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(docOpts)
                .SaveToLocalDirectory(@"Output\Html\WithParams");

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
        public void ConvertFromStorageFileToLocal_MD()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(new MarkdownConversionOptions())
                .SaveToLocalDirectory(@"Output\Html");

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
        public void ConvertFromStorageFileToLocal_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(mdOpts)
                .SaveToLocalDirectory(@"Output\Html\WithParams");

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
        public void ConvertFromStorageFileToLocal_MHTML()
        {
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile("/html_file.html")
                .To(new MHTMLConversionOptions())
                .SaveToLocalDirectory(@"Output\Html");

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
