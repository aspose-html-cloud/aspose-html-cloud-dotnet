using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class HtmlConversionStorageToLocalTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private readonly HttpClient client;
        private HtmlApi api;
        private string sourceFile = "/html_file.html";
        private string destFolder = Path.Combine(TestHelper.dstDir, "StorageFileToLocal");
        private string destWithParamFolder = Path.Combine(TestHelper.dstDir, "StorageFileToLocalWithParam");


        public HtmlConversionStorageToLocalTests(BaseTest fixture)
        {
            client = fixture.CreateClient();
            api = new HtmlApi(cb => cb
                .WithHttpClient(client)
                .WithAppSid(fixture.AppSid)
                .WithAppKey(fixture.AppKey)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
            var remoteFile = api.Storage.UploadFile(TestHelper.srcDir + "html_file.html", "/html_file.html");
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_PDF()
        {
            // Convert to single file
            ConverterBuilder convHtmlPdf = new ConverterBuilder()                   
                .fromStorageFile(sourceFile)
                .to(new PDFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlPdf); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_PDF_WithParams()
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
                .fromStorageFile(sourceFile)
                .to(pdfOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPdf);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_XPS()
        {
            // Convert to single file
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .fromStorageFile(sourceFile)
                .to(new XPSConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlXps); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_XPS_WithParams()
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
                .fromStorageFile(sourceFile)
                .to(xpsOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlXps);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_JPG()
        {
            // Convert to single file
            ConverterBuilder convHtmlJpg = new ConverterBuilder()
                .fromStorageFile(sourceFile)
                .to(new JPEGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlJpg); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_JPG_WithParams()
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
                .fromStorageFile(sourceFile)
                .to(jpgOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlJpg);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_PNG()
        {
            // Convert to single file
            ConverterBuilder convHtmlPng = new ConverterBuilder()
                .fromStorageFile(sourceFile)
                .to(new PNGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlPng); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_PNG_WithParams()
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
                .fromStorageFile(sourceFile)
                .to(pngOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPng);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_BMP()
        {
            // Convert to single file
            ConverterBuilder convHtmlBmp = new ConverterBuilder()
                .fromStorageFile(sourceFile)
                .to(new BMPConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlBmp); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_BMP_WithParams()
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
                .fromStorageFile(sourceFile)
                .to(bmpOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlBmp);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_GIF()
        {
            // Convert to single file
            ConverterBuilder convHtmlGif = new ConverterBuilder()
                .fromStorageFile(sourceFile)
                .to(new GIFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlGif); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_GIF_WithParams()
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
                .fromStorageFile(sourceFile)
                .to(gifOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlGif);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_TIFF()
        {
            // Convert to single file
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .fromStorageFile(sourceFile)
                .to(new TIFFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlTiff); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_TIFF_WithParams()
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
                .fromStorageFile(sourceFile)
                .to(tiffOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlTiff);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_MD()
        {
            // Convert to single file
            ConverterBuilder convHtmlMD = new ConverterBuilder()
                .fromStorageFile(sourceFile)
                .to(new MarkdownConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(convHtmlMD); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .setUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlMD = new ConverterBuilder()
                .fromStorageFile(sourceFile)
                .to(mdOpts)
                .SaveToLocal(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlMD);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_MHTML()
        {
            // Convert to single file
            ConverterBuilder convHtmlMHTML = new ConverterBuilder()
                .fromStorageFile(sourceFile)
                .to(new MHTMLConversionOptions())
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
