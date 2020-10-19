
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class DirConversionLocalToLocalTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private readonly HttpClient client;
        private HtmlApi api;
        private string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
        private string destFolder = Path.Combine(TestHelper.dstDir, "LocalDirToLocal");
        private string destWithParamFolder = Path.Combine(TestHelper.dstDir, "LocalDirToLocalWithParam");

        public DirConversionLocalToLocalTests(BaseTest fixture)
        {
            client = fixture.CreateClient();
            api = new HtmlApi(cb => cb
                .WithHttpClient(client)
                .WithAppSid(fixture.AppSid)
                .WithAppKey(fixture.AppKey)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_PDF()
        {
            // Convert to single file
            ConverterBuilder convHtmlPdf = new ConverterBuilder()                   
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new PDFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlPdf); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
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

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlPdf = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(pdfOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPdf);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_XPS()
        {
            // Convert to single file
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new XPSConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlXps); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
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

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(xpsOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlXps);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_JPG()
        {
            // Convert to single file
            ConverterBuilder convHtmlJpg = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new JPEGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlJpg); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
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

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlJpg = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(jpgOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlJpg);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_PNG()
        {
            // Convert to single file
            ConverterBuilder convHtmlPng = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new PNGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlPng); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
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

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlPng = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(pngOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPng);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_BMP()
        {
            // Convert to single file
            ConverterBuilder convHtmlBmp = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new BMPConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlBmp); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
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

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlBmp = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(bmpOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlBmp);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_GIF()
        {
            // Convert to single file
            ConverterBuilder convHtmlGif = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new GIFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlGif); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
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

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlGif = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(gifOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlGif);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_TIFF()
        {
            // Convert to single file
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new TIFFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlTiff); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
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

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(tiffOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlTiff);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_MD()
        {
            // Convert to single file
            ConverterBuilder convHtmlMD = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new MarkdownConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlMD); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlMD = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(mdOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlMD);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_MHTML()
        {
            // Convert to single file
            ConverterBuilder convHtmlMHTML = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new MHTMLConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlMHTML); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        public void Dispose()
        {
            api.Dispose();
        }
    }
}
