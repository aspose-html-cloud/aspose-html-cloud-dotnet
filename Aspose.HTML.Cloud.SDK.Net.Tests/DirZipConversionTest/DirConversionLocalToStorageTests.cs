
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class DirConversionLocalToStorageTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private readonly HttpClient client;
        private HtmlApi api;
        private string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
        private string destFolder = "LocalDirToStorage";
        private string destWithParamFolder = "LocalDirToStorageWithParam";

        public DirConversionLocalToStorageTests(BaseTest fixture)
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
        public void ConvertFromLocalDirToStorage_PDF()
        {
            // Convert to single file
            ConverterBuilder convHtmlPdf = new ConverterBuilder()                   
                .fromLocalDirectory(sourceDir, "index.html")
                .to(new PDFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPdf); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_PDF_WithParams()
        {
            ConversionOptions pdfOpts = new PDFConversionOptions()
                .setHeight(800)
                .setWidth(1000)
                .setLeftMargin(10)
                .setRightMargin(10)
                .setBottomMargin(10)
                .setTopMargin(10)
                .setQuality(95);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlPdf = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(pdfOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPdf);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_XPS()
        {
            // Convert to single file
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(new XPSConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlXps); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_XPS_WithParams()
        {
            ConversionOptions xpsOpts = new XPSConversionOptions()
                .setHeight(800)
                .setWidth(1000)
                .setLeftMargin(10)
                .setRightMargin(10)
                .setBottomMargin(10)
                .setTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(xpsOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlXps);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_JPG()
        {
            // Convert to single file
            ConverterBuilder convHtmlJpg = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(new JPEGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlJpg); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_JPG_WithParams()
        {
            ConversionOptions jpgOpts = new JPEGConversionOptions()
                .setHeight(800)
                .setWidth(1000)
                .setLeftMargin(10)
                .setRightMargin(10)
                .setBottomMargin(10)
                .setTopMargin(10)
                .setResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlJpg = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(jpgOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlJpg);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_PNG()
        {
            // Convert to single file
            ConverterBuilder convHtmlPng = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(new PNGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPng); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_PNG_WithParams()
        {
            ConversionOptions pngOpts = new PNGConversionOptions()
                .setHeight(800)
                .setWidth(1000)
                .setLeftMargin(10)
                .setRightMargin(10)
                .setBottomMargin(10)
                .setTopMargin(10)
                .setResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlPng = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(pngOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPng);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_BMP()
        {
            // Convert to single file
            ConverterBuilder convHtmlBmp = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(new BMPConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlBmp); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_BMP_WithParams()
        {
            ConversionOptions bmpOpts = new BMPConversionOptions()
                .setHeight(800)
                .setWidth(1000)
                .setLeftMargin(10)
                .setRightMargin(10)
                .setBottomMargin(10)
                .setTopMargin(10)
                .setResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlBmp = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(bmpOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlBmp);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_GIF()
        {
            // Convert to single file
            ConverterBuilder convHtmlGif = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(new GIFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlGif); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_GIF_WithParams()
        {
            ConversionOptions gifOpts = new GIFConversionOptions()
                .setHeight(800)
                .setWidth(1000)
                .setLeftMargin(10)
                .setRightMargin(10)
                .setBottomMargin(10)
                .setTopMargin(10)
                .setResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlGif = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(gifOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlGif);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_TIFF()
        {
            // Convert to single file
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(new TIFFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlTiff); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_TIFF_WithParams()
        {
            ConversionOptions tiffOpts = new TIFFConversionOptions()
                .setHeight(800)
                .setWidth(1000)
                .setLeftMargin(10)
                .setRightMargin(10)
                .setBottomMargin(10)
                .setTopMargin(10)
                .setResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(tiffOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlTiff);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_MD()
        {
            // Convert to single file
            ConverterBuilder convHtmlMD = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(new MarkdownConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlMD); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .setUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlMD = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(mdOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlMD);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_MHTML()
        {
            // Convert to single file
            ConverterBuilder convHtmlMHTML = new ConverterBuilder()
                .fromLocalDirectory(sourceDir, "index.html")
                .to(new MHTMLConversionOptions())
                .SaveToStorage(destFolder);

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
