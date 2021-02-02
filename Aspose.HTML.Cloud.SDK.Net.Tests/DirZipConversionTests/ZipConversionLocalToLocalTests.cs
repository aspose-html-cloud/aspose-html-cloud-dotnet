
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class ZipConversionLocalToLocalTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public ZipConversionLocalToLocalTests(BaseTest fixture)
        {
            //client = fixture.CreateClient();
            api = new HtmlApi(cb => cb
                //.WithHttpClient(client)
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_PDF()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromLocalArchive(sourceArch, "index.html")
                .To(new PDFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_PDF_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_XPS()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new XPSConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_XPS_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_JPG()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new JPEGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_JPG_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_PNG()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new PNGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_PNG_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_BMP()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new BMPConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_BMP_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_GIF()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new GIFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_GIF_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_TIFF()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new TIFFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_TIFF_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }


        [Fact]
        public void ConvertFromLocalZipToLocal_DOC()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new DOCConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_DOC_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip", "WithParams");

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
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }


        [Fact]
        public void ConvertFromLocalZipToLocal_MD()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new MarkdownConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_MD_WithParams()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip", "WithParams");

            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(mdOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToLocal_MHTML()
        {
            string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
            string destFolder = Path.Combine(TestHelper.dstDir, "Zip");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
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
