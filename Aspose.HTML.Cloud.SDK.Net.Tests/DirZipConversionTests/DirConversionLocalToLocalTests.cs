
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class DirConversionLocalToLocalTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public DirConversionLocalToLocalTests(BaseTest fixture)
        {
            api = new HtmlApi(cb => cb
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_PDF()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new PDFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_PDF_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_XPS()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new XPSConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_XPS_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_JPG()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new JPEGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_JPG_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_PNG()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new PNGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_PNG_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_BMP()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new BMPConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_BMP_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_GIF()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new GIFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_GIF_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_TIFF()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new TIFFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_TIFF_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_DOC()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new DOCConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_DOC_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_MD()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(new MarkdownConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_MD_WithParams()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory", "WithParams");

            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
                .To(mdOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_MHTML()
        {
            string sourceDir = Path.Combine(TestHelper.srcDir, "DirectoryTests", "HtmlSite2");
            string destFolder = Path.Combine(TestHelper.dstDir, "Directory");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalDirectory(sourceDir, "index.html")
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
