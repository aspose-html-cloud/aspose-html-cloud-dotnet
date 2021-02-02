using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class EpubConversionStorageToLocalTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public EpubConversionStorageToLocalTests(BaseTest fixture)
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
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromStorageFile(sourceFile)
                .To(new PDFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact/*(Skip = "Out of memory")*/]
        public void ConvertFromStorageFileToStorage_PDF_WithParams()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions pdfOpts = new PDFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetQuality(95);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(pdfOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_XPS()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new XPSConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact/*(Skip = "Out of memory")*/]
        public void ConvertFromStorageFileToStorage_XPS_WithParams()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(xpsOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_JPG()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new JPEGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact/*(Skip = "Out of memory")*/]
        public void ConvertFromStorageFileToStorage_JPG_WithParams()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions jpgOpts = new JPEGConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(jpgOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PNG()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new PNGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PNG_WithParams()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions pngOpts = new PNGConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(pngOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_BMP()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new BMPConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_BMP_WithParams()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions bmpOpts = new BMPConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(bmpOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_GIF()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new GIFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_GIF_WithParams()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions gifOpts = new GIFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(gifOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_TIFF()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new TIFFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_TIFF_WithParams()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions tiffOpts = new TIFFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(tiffOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_DOC()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new DOCConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_DOC_WithParams()
        {
            string sourceFile = "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(docOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

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
