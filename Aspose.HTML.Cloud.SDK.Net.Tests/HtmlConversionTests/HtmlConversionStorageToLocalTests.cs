using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class HtmlConversionStorageToLocalTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public HtmlConversionStorageToLocalTests(BaseTest fixture)
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
        public void ConvertFromStorageFileToLocal_PDF()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromStorageFile(sourceFile)
                .To(new PDFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_PDF_WithParams()
        {
            string sourceFile = "/html_file.html";
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
                .FromStorageFile(sourceFile)
                .To(pdfOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_XPS()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new XPSConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_XPS_WithParams()
        {
            string sourceFile = "/html_file.html";
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
                .FromStorageFile(sourceFile)
                .To(xpsOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_JPG()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new JPEGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_JPG_WithParams()
        {
            string sourceFile = "/html_file.html";
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
                .FromStorageFile(sourceFile)
                .To(jpgOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_PNG()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new PNGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_PNG_WithParams()
        {
            string sourceFile = "/html_file.html";
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
                .FromStorageFile(sourceFile)
                .To(pngOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_BMP()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new BMPConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_BMP_WithParams()
        {
            string sourceFile = "/html_file.html";
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
                .FromStorageFile(sourceFile)
                .To(bmpOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_GIF()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new GIFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_GIF_WithParams()
        {
            string sourceFile = "/html_file.html";
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
                .FromStorageFile(sourceFile)
                .To(gifOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_TIFF()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new TIFFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_TIFF_WithParams()
        {
            string sourceFile = "/html_file.html";
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
                .FromStorageFile(sourceFile)
                .To(tiffOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }


        [Fact]
        public void ConvertFromStorageFileToLocal_DOC()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single or multiple files with default options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new DOCConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_DOC_WithParams()
        {
            string sourceFile = "/html_file.html";
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
                .FromStorageFile(sourceFile)
                .To(docOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_MD()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new MarkdownConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_MD_WithParams()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html", "WithParams");

            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(mdOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToLocal_MHTML()
        {
            string sourceFile = "/html_file.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Html");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
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
