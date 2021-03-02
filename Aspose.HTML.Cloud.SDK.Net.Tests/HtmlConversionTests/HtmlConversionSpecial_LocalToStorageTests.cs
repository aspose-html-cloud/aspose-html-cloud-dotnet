using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.ApiParameters;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class HtmlConversionSpecial_LocalToStorageTests
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public HtmlConversionSpecial_LocalToStorageTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionLocalToLocalTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_PDF()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\html_file.html",
                    options: new PDFConversionOptions(),
                    outputPath: new RemoteDirectoryParameter("/TestResult/Html/ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_PDF_1()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\html_file.html",
                    options: new PDFConversionOptions(),
                    outputPath: "/TestResult/Html/ConvertLocal");
                // string outputPath is treated as remote storage path

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_JPEG()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\html_file.html",
                    options: new JPEGConversionOptions(),
                    outputPath: new RemoteDirectoryParameter("/TestResult/Html/ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_JPEG_1()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\html_file.html",
                    options: new JPEGConversionOptions(),
                    outputPath: "/TestResult/Html/ConvertLocal");
                // string outputPath is treated as remote storage path

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_PDF()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalDirectory(
                    directoryPath: @"Input\DirectoryTests\HtmlSite2",
                    startPoint: "index.html",
                    options: new PDFConversionOptions(),
                    outputPath: new RemoteDirectoryParameter("/TestResult/Dir/ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_PDF_1()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalDirectory(
                    directoryPath: @"Input\DirectoryTests\HtmlSite2",
                    startPoint: "index.html",
                    options: new PDFConversionOptions(),
                    outputPath: "/TestResult/Dir/ConvertLocal2");
                    // string outputPath is treated as default remote storage path

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_JPEG()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalDirectory(
                    directoryPath: @"Input\DirectoryTests\HtmlSite2",
                    startPoint: "index.html",
                    options: new JPEGConversionOptions(),
                    outputPath: new RemoteDirectoryParameter("/TestResult/Dir/ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalDirToStorage_JPEG_1()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalDirectory(
                    directoryPath: @"Input\DirectoryTests\HtmlSite2",
                    startPoint: "index.html",
                    options: new JPEGConversionOptions(),
                    outputPath: "/TestResult/Dir/ConvertLocal2");
                // string outputPath is treated as default remote storage path

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalArchiveToStorage_PDF()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalArchive(
                    archivePath: @"Input\ZipTests\test1.zip",
                    startPoint: "index.html",
                    options: new PDFConversionOptions(),
                    outputPath: new RemoteDirectoryParameter("/TestResult/Zip/ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalArchiveToStorage_PDF_1()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {             
                Conversion.Conversion result = api.ConvertLocalArchive(
                    archivePath: @"Input\ZipTests\test1.zip",
                    startPoint: "index.html",
                    options: new PDFConversionOptions(),
                    outputPath: "/TestResult/Zip/ConvertLocal"); 
                    // string outputPath is treated as remote storage path

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalArchiveToStorage_JPEG()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalArchive(
                    archivePath: @"Input\ZipTests\test1.zip",
                    startPoint: "index.html",
                    options: new JPEGConversionOptions(),
                    outputPath: new RemoteDirectoryParameter("/TestResult/Zip/ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalArchiveToStorage_JPEG_1()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalArchive(
                    archivePath: @"Input\ZipTests\test1.zip",
                    startPoint: "index.html",
                    options: new JPEGConversionOptions(),
                    outputPath: "/TestResult/Zip/ConvertLocal");
                // string outputPath is treated as remote storage path

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToStorage_PDF_WithResources()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\DirectoryTests\HtmlSite2\index.html",
                    options: new PDFConversionOptions(),
                    outputPath: new RemoteDirectoryParameter("/TestResult/Zip/ConvertLocalWithRes"),
                    resources: new System.Collections.Generic.List<string>() {
                        @"Input\DirectoryTests\HtmlSite2\css\styles.css",
                        @"Input\DirectoryTests\HtmlSite2\images\mount-river.jpg",
                        @"Input\DirectoryTests\HtmlSite2\images\Penguins.jpg",
                        @"Input\DirectoryTests\HtmlSite2\images\waterfall-1.jpg",
                        @"Input\DirectoryTests\HtmlSite2\images\waterfall-2.jpg",
                        @"Input\DirectoryTests\HtmlSite2\images\waterfall-3.jpg"
                    });

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

    }
}
