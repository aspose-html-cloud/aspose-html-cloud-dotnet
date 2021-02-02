using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class ZipConversionLocalToStorageTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public ZipConversionLocalToStorageTests(BaseTest fixture)
        {
            api = new HtmlApi(cb => cb
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PDF()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromLocalArchive(sourceArch, "index.html")
                .To(new PDFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); 

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PDF_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip/WithParams";

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
                .FromLocalArchive(sourceArch, "index.html")
                .To(pdfOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_XPS()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new XPSConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_XPS_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip/WithParams";

            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(xpsOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_JPG()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new JPEGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_JPG_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip/WithParams";

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
                .FromLocalArchive(sourceArch, "index.html")
                .To(jpgOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PNG()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new PNGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PNG_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip/WithParams";

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
                .FromLocalArchive(sourceArch, "index.html")
                .To(pngOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_BMP()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip/WithParams";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new BMPConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_BMP_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip/WithParams";

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
                .FromLocalArchive(sourceArch, "index.html")
                .To(bmpOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_GIF()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new GIFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_GIF_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip/WithParams";

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
                .FromLocalArchive(sourceArch, "index.html")
                .To(gifOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_TIFF()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new TIFFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_TIFF_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip/WithParams";

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
                .FromLocalArchive(sourceArch, "index.html")
                .To(tiffOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_DOC()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new DOCConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_DOC_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip/WithParams";

            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(docOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_MD()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new MarkdownConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_MD_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip/WithParams";

            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(mdOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_MHTML()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = "/TestResult/Zip";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new MHTMLConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

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
