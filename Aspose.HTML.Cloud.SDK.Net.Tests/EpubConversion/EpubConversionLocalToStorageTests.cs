using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class EpubConversionLocalToStorageTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private readonly HttpClient client;
        private HtmlApi api;
        private string sourceFile = TestHelper.srcDir + "epub_file.epub";
        private string destFolder = "LocalFileToStorage";
        private string destWithParamFolder = "LocalFileToStorageWithParam";


        public EpubConversionLocalToStorageTests(BaseTest fixture)
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
        public void ConvertFromLocalFileToStorage_PDF()
        {
            // Convert to single file
            ConverterBuilder convHtmlPdf = new ConverterBuilder()                   
                .fromLocalFile(sourceFile)
                .to(new PDFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPdf); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact(Skip = "Out of memory")]
        public void ConvertFromLocalFileToStorage_PDF_WithParams()
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
                .fromLocalFile(sourceFile)
                .to(pdfOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPdf);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_XPS()
        {
            // Convert to single file
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .fromLocalFile(sourceFile)
                .to(new XPSConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlXps); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact(Skip = "Out of memory")]
        public void ConvertFromLocalFileToStorage_XPS_WithParams()
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
                .fromLocalFile(sourceFile)
                .to(xpsOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlXps);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_JPG()
        {
            // Convert to single file
            ConverterBuilder convHtmlJpg = new ConverterBuilder()
                .fromLocalFile(sourceFile)
                .to(new JPEGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlJpg); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact(Skip = "Out of memory")]
        public void ConvertFromLocalFileToStorage_JPG_WithParams()
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
                .fromLocalFile(sourceFile)
                .to(jpgOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlJpg);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_PNG()
        {
            // Convert to single file
            ConverterBuilder convHtmlPng = new ConverterBuilder()
                .fromLocalFile(sourceFile)
                .to(new PNGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPng); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact(Skip = "Out of memory")]
        public void ConvertFromLocalFileToStorage_PNG_WithParams()
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
                .fromLocalFile(sourceFile)
                .to(pngOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPng);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_BMP()
        {
            // Convert to single file
            ConverterBuilder convHtmlBmp = new ConverterBuilder()
                .fromLocalFile(sourceFile)
                .to(new BMPConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlBmp); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact(Skip = "Out of memory")]
        public void ConvertFromLocalFileToStorage_BMP_WithParams()
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
                .fromLocalFile(sourceFile)
                .to(bmpOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlBmp);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_GIF()
        {
            // Convert to single file
            ConverterBuilder convHtmlGif = new ConverterBuilder()
                .fromLocalFile(sourceFile)
                .to(new GIFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlGif); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact(Skip = "Out of memory")]
        public void ConvertFromLocalFileToStorage_GIF_WithParams()
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
                .fromLocalFile(sourceFile)
                .to(gifOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlGif);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_TIFF()
        {
            // Convert to single file
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .fromLocalFile(sourceFile)
                .to(new TIFFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlTiff); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact(Skip = "Out of memory")]
        public void ConvertFromLocalFileToStorage_TIFF_WithParams()
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
                .fromLocalFile(sourceFile)
                .to(tiffOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlTiff);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        public void Dispose()
        {
            api.Dispose();
        }
    }
}
