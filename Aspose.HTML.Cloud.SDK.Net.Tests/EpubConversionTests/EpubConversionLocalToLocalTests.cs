using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class EpubConversionLocalToLocalTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public EpubConversionLocalToLocalTests(BaseTest fixture)
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
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromLocalFile(sourceFile)
                .To(new PDFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PDF_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions opts = new PDFConversionOptions()
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
                .To(opts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_XPS()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new XPSConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_XPS_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions opts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(opts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_JPG()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new JPEGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_JPG_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions opts = new JPEGConversionOptions()
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
                .To(opts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PNG()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new PNGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PNG_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions opts = new PNGConversionOptions()
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
                .To(opts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_BMP()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new BMPConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_BMP_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions opts = new BMPConversionOptions()
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
                .To(opts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_GIF()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new GIFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_GIF_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions opts = new GIFConversionOptions()
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
                .To(opts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_TIFF()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new TIFFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_TIFF_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions opts = new TIFFConversionOptions()
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
                .To(opts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_DOC()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new DOCConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_DOC_WithParams()
        {
            string sourceFile = TestHelper.srcDir + "example.epub";
            string destFolder = Path.Combine(TestHelper.dstDir, "Epub", "WithParams");

            ConversionOptions opts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(opts)
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
