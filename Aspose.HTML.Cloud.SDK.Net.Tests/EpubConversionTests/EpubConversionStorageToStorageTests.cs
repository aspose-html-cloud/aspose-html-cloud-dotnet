using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class EpubConversionStorageToStorageTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public EpubConversionStorageToStorageTests(BaseTest fixture)
        {
            api = new HtmlApi(cb => cb
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));

            var remoteFile = api.Storage.UploadFile(
                TestHelper.srcDir + "example.epub",
                "/example.epub", null, IO.NameCollisionOption.ReplaceExisting);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PDF()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            // Convert to single file
            ConverterBuilder convHtmlPdf = new ConverterBuilder()                   
                .FromStorageFile(sourceFile)
                .To(new PDFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPdf); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PDF_WithParams()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

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
                .FromStorageFile(sourceFile)
                .To(pdfOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPdf);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_XPS()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            // Convert to single file
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new XPSConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlXps); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact/*(Skip = "Out of memory")*/]
        public void ConvertFromStorageFileToStorage_XPS_WithParams()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(xpsOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlXps);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_JPG()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            // Convert to single file
            ConverterBuilder convHtmlJpg = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new JPEGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlJpg); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_JPG_WithParams()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

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
                .FromStorageFile(sourceFile)
                .To(jpgOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlJpg);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PNG()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            // Convert to single file
            ConverterBuilder convHtmlPng = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new PNGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPng); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PNG_WithParams()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

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
                .FromStorageFile(sourceFile)
                .To(pngOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPng);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_BMP()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            // Convert to single file
            ConverterBuilder convHtmlBmp = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new BMPConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlBmp); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact/*(Skip = "Out of memory")*/]
        public void ConvertFromStorageFileToStorage_BMP_WithParams()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

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
                .FromStorageFile(sourceFile)
                .To(bmpOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlBmp);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_GIF()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            // Convert to single file
            ConverterBuilder convHtmlGif = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new GIFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlGif); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_GIF_WithParams()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

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
                .FromStorageFile(sourceFile)
                .To(gifOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlGif);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_TIFF()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            // Convert to single file
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new TIFFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlTiff); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
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

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(tiffOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlTiff);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_DOC()
        {
            string sourceFile = "/example.epub";
            string destFolder = "/TestResult/Epub";

            // Convert to single file
            ConverterBuilder convHtmlDoc = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new DOCConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlDoc); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
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

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlDoc = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(docOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlDoc);

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
