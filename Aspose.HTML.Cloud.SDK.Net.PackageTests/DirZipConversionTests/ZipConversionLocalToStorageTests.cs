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
        private readonly HttpClient client;
        private HtmlApi api;
        private string sourceArch = Path.Combine(TestHelper.srcDir, "ZipTests", "test1.zip");
        private string destFolder = "LocalZipToStorage";
        private string destWithParamFolder = "LocalZipToStorageWithParam";

        public ZipConversionLocalToStorageTests(BaseTest fixture)
        {
            //client = fixture.CreateClient();
            api = new HtmlApi(cb => cb
                //.WithHttpClient(client)
                .WithAppSid(fixture.ClientId)
                .WithAppKey(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PDF()
        {
            // Convert to single file
            ConverterBuilder convHtmlPdf = new ConverterBuilder()                   
                .FromLocalArchive(sourceArch, "index.html")
                .To(new PDFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPdf); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PDF_WithParams()
        {
            ConversionOptions pdfOpts = new PDFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetQuality(95);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlPdf = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(pdfOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPdf);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_XPS()
        {
            // Convert to single file
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new XPSConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlXps); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_XPS_WithParams()
        {
            ConversionOptions xpsOpts = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(xpsOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlXps);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_JPG()
        {
            // Convert to single file
            ConverterBuilder convHtmlJpg = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new JPEGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlJpg); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_JPG_WithParams()
        {
            ConversionOptions jpgOpts = new JPEGConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlJpg = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(jpgOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlJpg);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PNG()
        {
            // Convert to single file
            ConverterBuilder convHtmlPng = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new PNGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPng); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_PNG_WithParams()
        {
            ConversionOptions pngOpts = new PNGConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlPng = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(pngOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPng);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_BMP()
        {
            // Convert to single file
            ConverterBuilder convHtmlBmp = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new BMPConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlBmp); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_BMP_WithParams()
        {
            ConversionOptions bmpOpts = new BMPConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlBmp = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(bmpOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlBmp);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_GIF()
        {
            // Convert to single file
            ConverterBuilder convHtmlGif = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new GIFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlGif); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_GIF_WithParams()
        {
            ConversionOptions gifOpts = new GIFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlGif = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(gifOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlGif);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_TIFF()
        {
            // Convert to single file
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new TIFFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlTiff); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_TIFF_WithParams()
        {
            ConversionOptions tiffOpts = new TIFFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10)
                .SetResolution(300);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(tiffOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlTiff);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_MD()
        {
            // Convert to single file
            ConverterBuilder convHtmlMD = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new MarkdownConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlMD); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlMD = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(mdOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlMD);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromLocalZipToStorage_MHTML()
        {
            // Convert to single file
            ConverterBuilder convHtmlMHTML = new ConverterBuilder()
                .FromLocalArchive(sourceArch, "index.html")
                .To(new MHTMLConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlMHTML); ;

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
