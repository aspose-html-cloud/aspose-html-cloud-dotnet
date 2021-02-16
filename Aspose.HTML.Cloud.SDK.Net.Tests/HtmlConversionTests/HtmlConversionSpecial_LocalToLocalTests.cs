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
    public class HtmlConversionSpecial_LocalToLocalTests
    {
        string CliendId { get; set; }
        string ClientSecret { get; set; }

        public HtmlConversionSpecial_LocalToLocalTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionLocalToLocalTests>().Build();

            CliendId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PDF()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\html_file.html",
                    options: new PDFConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Html\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalDirToLocal_PDF()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalDirectory(
                    directoryPath: @"Input\DirectoryTests\HtmlSite2",
                    startPoint: "index.html",
                    options: new PDFConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Dir\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalArchiveToLocal_PDF()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalArchive(
                    archivePath: @"Input\ZipTests\test1.zip",
                    startPoint: "index.html",
                    options: new PDFConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Zip\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }

        [Fact]
        public void ConvertFromLocalFileToLocal_PDF_WithResources()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\DirectoryTests\HtmlSite2\index.html",
                    options: new PDFConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Html\ConvertLocalWithRes"),
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


        [Fact]
        public void ConvertFromLocalFileToLocal_JPEG()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    @"Input\html_file.html",
                    new JPEGConversionOptions(),
                    new LocalDirectoryParameter(@"Output\Html\ConvertLocal"));

                Assert.True(result.Status == "completed");
                Assert.True(result.Files.Any());
            }
        }


        [Fact]
        public void ConvertFromLocalFileToLocal_JPEG_WithResources()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                Conversion.Conversion result = api.ConvertLocalFile(
                    filePath: @"Input\DirectoryTests\HtmlSite2\index.html",
                    options: new JPEGConversionOptions(),
                    outputPath: new LocalDirectoryParameter(@"Output\Html\ConvertLocalWithRes"),
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
