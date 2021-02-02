using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class HtmlConversionLocalToStorageTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public HtmlConversionLocalToStorageTests(BaseTest fixture)
        {
            api = new HtmlApi(cb => cb
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_PDF()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromLocalFile(sourceFile)
                .To(new PDFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_PDF_WithParams()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html/WithParams";

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
                .FromLocalFile(sourceFile)
                .To(pdfOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_XPS()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new XPSConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_XPS_WithParams()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html/WithParams";

            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(xpsOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_JPG()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new JPEGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_JPG_WithParams()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html/WithParams";

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
                .FromLocalFile(sourceFile)
                .To(jpgOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_PNG()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new PNGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_PNG_WithParams()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html/WithParams";

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
                .FromLocalFile(sourceFile)
                .To(pngOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_BMP()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new BMPConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_BMP_WithParams()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html/WithParams";

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
                .FromLocalFile(sourceFile)
                .To(bmpOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_GIF()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new GIFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_GIF_WithParams()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html/WithParams";

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
                .FromLocalFile(sourceFile)
                .To(gifOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_TIFF()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new TIFFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_TIFF_WithParams()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html/WithParams";

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
                .FromLocalFile(sourceFile)
                .To(tiffOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_DOC()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html";

            // Convert to single or multiple files with default options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new DOCConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_DOC_WithParams()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html/WithParams";

            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(docOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_MD()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new MarkdownConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_MD_WithParams()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html/WithParams";

            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(mdOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_MHTML()
        {
            var sourceFile = TestHelper.srcDir + "html_file.html";
            var destFolder = "/TestResult/Html";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
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
