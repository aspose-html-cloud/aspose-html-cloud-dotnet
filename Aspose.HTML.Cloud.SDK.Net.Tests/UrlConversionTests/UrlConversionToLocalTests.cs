using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class UrlConversionToLocalTests 
        : IClassFixture<BaseTest>, IDisposable
    {
        private HtmlApi api;

        public UrlConversionToLocalTests(BaseTest fixture)
        {
            api = new HtmlApi(cb => cb
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void ConvertFromUrlToLocal_PDF()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()                   
                .FromUrl(sourceUrl)
                .To(new PDFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_PDF_WithParams()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url", "WithParams");

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
                .FromUrl(sourceUrl)
                .To(pdfOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_XPS()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl(sourceUrl)
                .To(new XPSConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_XPS_WithParams()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url", "WithParams");

            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl(sourceUrl)
                .To(xpsOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_JPG()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl(sourceUrl)
                .To(new JPEGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_JPG_WithParams()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url", "WithParams");

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
                .FromUrl(sourceUrl)
                .To(jpgOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_PNG()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl(sourceUrl)
                .To(new PNGConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_PNG_WithParams()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url", "WithParams");

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
                .FromUrl(sourceUrl)
                .To(pngOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_BMP()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl(sourceUrl)
                .To(new BMPConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_BMP_WithParams()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url", "WithParams");

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
                .FromUrl(sourceUrl)
                .To(bmpOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_GIF()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl(sourceUrl)
                .To(new GIFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_GIF_WithParams()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url", "WithParams");

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
                .FromUrl(sourceUrl)
                .To(gifOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_TIFF()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl(sourceUrl)
                .To(new TIFFConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_TIFF_WithParams()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url", "WithParams");

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
                .FromUrl(sourceUrl)
                .To(tiffOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_MD()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl(sourceUrl)
                .To(new MarkdownConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_MD_WithParams()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url", "WithParams");

            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl(sourceUrl)
                .To(mdOpts)
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromUrlToLocal_MHTML()
        {
            string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
            string destFolder = Path.Combine(TestHelper.dstDir, "Url");

            // Convert to single file
            ConverterBuilder builder = new ConverterBuilder()
                .FromUrl(sourceUrl)
                .To(new MHTMLConversionOptions())
                .SaveToLocal(destFolder);

            ConversionResult result = api.Convert(builder); ;

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
