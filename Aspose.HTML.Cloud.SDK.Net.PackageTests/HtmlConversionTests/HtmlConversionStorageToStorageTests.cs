﻿using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class HtmlConversionStorageToStorageTests
        : IClassFixture<BaseTest>, IDisposable
    {
        private readonly HttpClient client;
        private HtmlApi api;
        private string sourceFile = "/html_file.html";
        private string destFolder = "StorageFileToStorage";
        private string destWithParamFolder = "StorageFileToStorageWithParam";


        public HtmlConversionStorageToStorageTests(BaseTest fixture)
        {
            //client = fixture.CreateClient();
            api = new HtmlApi(cb => cb
                //.WithHttpClient(client)
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
            var remoteFile = api.Storage.UploadFile(TestHelper.srcDir + "html_file.html", "/html_file.html");
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PDF()
        {
            // Convert to single file
            ConverterBuilder convHtmlPdf = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new PDFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPdf); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PDF_WithParams()
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
                .FromStorageFile(sourceFile)
                .To(pdfOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPdf);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_XPS()
        {
            // Convert to single file
            ConverterBuilder convHtmlXps = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new XPSConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlXps); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_XPS_WithParams()
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
                .FromStorageFile(sourceFile)
                .To(xpsOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlXps);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_JPG()
        {
            // Convert to single file
            ConverterBuilder convHtmlJpg = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new JPEGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlJpg); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_JPG_WithParams()
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
                .FromStorageFile(sourceFile)
                .To(jpgOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlJpg);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PNG()
        {
            // Convert to single file
            ConverterBuilder convHtmlPng = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new PNGConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlPng); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_PNG_WithParams()
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
                .FromStorageFile(sourceFile)
                .To(pngOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlPng);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_BMP()
        {
            // Convert to single file
            ConverterBuilder convHtmlBmp = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new BMPConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlBmp); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_BMP_WithParams()
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
                .FromStorageFile(sourceFile)
                .To(bmpOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlBmp);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_GIF()
        {
            // Convert to single file
            ConverterBuilder convHtmlGif = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new GIFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlGif); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_GIF_WithParams()
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
                .FromStorageFile(sourceFile)
                .To(gifOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlGif);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_TIFF()
        {
            // Convert to single file
            ConverterBuilder convHtmlTiff = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new TIFFConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlTiff); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_TIFF_WithParams()
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
                .FromStorageFile(sourceFile)
                .To(tiffOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlTiff);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_DOC()
        {
            // Convert to single or multiple files with default options
            ConverterBuilder convHtmlDoc = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new DOCConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlDoc);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_DOC_WithParams()
        {
            ConversionOptions docOpts = new DOCConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlDoc = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(docOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlDoc);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_MD()
        {
            // Convert to single file
            ConverterBuilder convHtmlMD = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(new MarkdownConversionOptions())
                .SaveToStorage(destFolder);

            ConversionResult result = api.Convert(convHtmlMD); ;

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length == 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_MD_WithParams()
        {
            ConversionOptions mdOpts = new MarkdownConversionOptions()
                .SetUseGit(true);

            // Convert to single or multiple files with options
            ConverterBuilder convHtmlMD = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .To(mdOpts)
                .SaveToStorage(destWithParamFolder);

            ConversionResult result = api.Convert(convHtmlMD);

            //ToDo: Status - to enum
            Assert.True(result.Status == "success");
            Assert.True(result.Files.Length >= 1);
        }

        [Fact]
        public void ConvertFromStorageFileToStorage_MHTML()
        {
            // Convert to single file
            ConverterBuilder convHtmlMHTML = new ConverterBuilder()
                .FromStorageFile(sourceFile)
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
