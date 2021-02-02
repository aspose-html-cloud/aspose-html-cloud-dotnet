using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class HtmlConversionStorageToStorageTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public HtmlConversionStorageToStorageTests(BaseTest fixture)
        {
            api = new HtmlApi(cb => cb
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));

            var remoteFile = api.Storage.UploadFile(
                TestHelper.srcDir + "html_file.html",
                "/html_file.html", null, IO.NameCollisionOption.ReplaceExisting);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PDF()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromStorageFile(sourceFile)
                .To(new PDFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PDF_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html/WithParams";

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
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_XPS()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new XPSConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_XPS_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html/WithParams";

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
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_JPG()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new JPEGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_JPG_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html/WithParams";

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
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PNG()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new PNGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PNG_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html/WithParams";

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
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_BMP()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new BMPConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_BMP_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html/WithParams";

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
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_GIF()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new GIFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_GIF_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html/WithParams";

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
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_TIFF()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new TIFFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_TIFF_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html/WithParams";

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
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_DOC()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html";

            // Convert to single or multiple files with default options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new DOCConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_DOC_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html/WithParams";

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
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_MD()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new MarkdownConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_MD_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html/WithParams";

            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(mdOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_MHTML()
        {
            string sourceFile = "/html_file.html";
            string destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new MHTMLConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

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
