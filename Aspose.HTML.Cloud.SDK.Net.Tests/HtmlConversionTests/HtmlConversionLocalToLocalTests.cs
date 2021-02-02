using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class HtmlConversionLocalToLocalTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public HtmlConversionLocalToLocalTests(BaseTest fixture)
        {
            api = new HtmlApi(cb => cb
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PDF()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromLocalFile(sourceFile)
                .To(new PDFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PDF_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_XPS()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new XPSConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_XPS_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_JPG()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new JPEGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_JPG_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PNG()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new PNGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PNG_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_BMP()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new BMPConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_BMP_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_GIF()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new GIFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_GIF_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_TIFF()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new TIFFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_TIFF_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_DOC()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single or multiple files with default options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new DOCConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_DOC_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_MD()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new MarkdownConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_MD_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html", "WithParams");

            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(mdOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_MHTML()
        {
            string sourceFile = TestHelper.srcDir + "html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new MHTMLConversionOptions())
                .SaveToLocal(destFolder);

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
