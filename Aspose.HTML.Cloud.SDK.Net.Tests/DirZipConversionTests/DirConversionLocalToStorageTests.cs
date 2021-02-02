
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
        private HtmlApi api;

        public DirConversionLocalToStorageTests(BaseTest fixture)
        {
            api = new HtmlApi(cb => cb
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_PDF()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new PDFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_PDF_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory/WithParams";

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
                .FromLocalDirectory(sourceDir, "index.html")
                .To(pdfOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_XPS()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new XPSConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_XPS_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory/WithParams";

            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(xpsOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_JPG()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new JPEGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_JPG_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory/WithParams";

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
                .FromLocalDirectory(sourceDir, "index.html")
                .To(jpgOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_PNG()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new PNGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_PNG_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory/WithParams";

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
                .FromLocalDirectory(sourceDir, "index.html")
                .To(pngOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_BMP()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new BMPConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_BMP_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory/WithParams";

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
                .FromLocalDirectory(sourceDir, "index.html")
                .To(bmpOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_GIF()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new GIFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_GIF_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory/WithParams";

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
                .FromLocalDirectory(sourceDir, "index.html")
                .To(gifOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_TIFF()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new TIFFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_TIFF_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory/WithParams";

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
                .FromLocalDirectory(sourceDir, "index.html")
                .To(tiffOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_DOC()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new DOCConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_DOC_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory/WithParams";

            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(docOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_MD()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new MarkdownConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_MD_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory/WithParams";

            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(mdOpts)
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_MHTML()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = "/TestResult/Directory";

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
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
