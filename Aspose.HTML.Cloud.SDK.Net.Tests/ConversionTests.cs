using System.Linq;
using System.Net.Http;
using Aspose.HTML.Cloud.Sdk.Conversion;
using Xunit;
using Assert = Xunit.Assert;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class ConversionTests : IClassFixture<BaseTest>
    {
        private readonly HttpClient client;

        public ConversionTests(BaseTest fixture)
        {
            client = fixture.CreateClient();
        }

        [Fact]
        public void ConvertFile_SaveResultsIntoStorage()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {

                var storage = api.Storage;
                Assert.False(storage.FileExists("file.pdf"));

                var input = "folder/file.html";
                var output = "file.pdf";
                var result = api.Convert(input, new PDFConversionOptions(), output);

                Assert.Equal("file.pdf", result.Files.First().Name);
                Assert.True(storage.FileExists("file.pdf"));
            }
        }

        [Fact]
        public void ConvertFile_WithoutSavingResults()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {
                var storage = api.Storage;

                var input = "folder/file.html";
                var result = api.Convert(input, new PDFConversionOptions());
                
                var file = result.Files.First();
                Assert.False(storage.FileExists(file));
            }
        }

        [Fact]
        public void ConvertFile_SaveResultsLocally()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {
                var storage = api.Storage;

                var input = "folder/file.html";
                var output = "file.pdf";

                var result = api.Convert(input, new PDFConversionOptions());
                var file = result.Files.First();
                storage.DownloadFile(file, @"c:\work\file.pdf");
                Assert.True(System.IO.File.Exists(@"c:\work\file.pdf"));
            }
        }

        [Fact]
        public void ConvertFile_SaveResultsToStorage()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {
                var storage = api.Storage;

                var input = "folder/file.html";

                var result = api.Convert(input, new PDFConversionOptions());
                var file = result.Files.First();
                storage.CopyFile(file, "output.pdf");

                var exists = storage.FileExists("output.pdf");
                Assert.True(exists);
            }
        }

        [Fact]
        public void ConvertWebSite()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {
                var result = api.ConvertWebSite("https://httpbin.org/forms/post", new PDFConversionOptions());
                Assert.NotEmpty(result.Files);
            }
        }

        [Fact]
        public void ConvertLocalFile()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {
                var result = api.ConvertLocalFile("file.html", new PDFConversionOptions());
                Assert.NotEmpty(result.Files);
            }
        }

        [Fact]
        public void ConvertArchiveFile()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {
                var result = api.Convert(
                    ConversionSource
                        .FromLocalArchiveFile("web-site.zip")
                        .StartingPoint("/file.html"), 
                    new PDFConversionOptions()
                );
                Assert.NotEmpty(result.Files);
            }
        }

        [Fact]
        public void ConvertFile_WithResources()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {
                var result = api.Convert(
                    ConversionSource
                        .FromLocalFile("file.html")
                        .WithResource("image.jpg")
                        .WithResources("style.css", "script.js"),
                    new PDFConversionOptions()
                );
                Assert.NotEmpty(result.Files);
            }
        }

        [Fact]
        public void ConvertFile_ResourcesFromDirectory()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {
                var result = api.Convert(
                    ConversionSource
                        .FromLocalDirectory("./folder")
                        .StartingPoint("./folder/file.html"),
                    new PDFConversionOptions()
                );
                Assert.NotEmpty(result.Files);
            }
        }

        [Fact]
        public void Convert_Asynchronous()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {

                var result = api.ConvertLocalFileAsync(TestHelper.srcDir + "test.html", new PDFConversionOptions());
                
                result.AsyncWaitHandle.WaitOne();
                // OR
                //while (!result.IsCompleted)
                //    Thread.Sleep(10);

                var data = result.Data;
                Assert.NotEmpty(data.Files);
            }
        }

        [Fact]
        public void CheckStatus_AnotherAppInstance()
        {
            string id;

            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {
                var result = api.ConvertLocalFileAsync("file.html", new PDFConversionOptions());
                id = result.Data.Id;

                Assert.False(result.IsCompleted);
            }
            
            using (var api = new HtmlApi(_ => _.WithHttpClient(client)))
            {
                var result = api.GetConversion(id);
                result.AsyncWaitHandle.WaitOne();

                Assert.True(result.IsCompleted);
            }

        }

        [Fact]
        public void ConvertAsynchronous_DownloadResult()
        {
            using (var api = new HtmlApi(_
                => _.WithHttpClient(client)))
            {
                var result = api.ConvertLocalFileAsync(TestHelper.srcDir + "test.html", new PDFConversionOptions());
                
                result.AsyncWaitHandle.WaitOne();
                // OR
                //while (!result.IsCompleted)
                //    Thread.Sleep(10);

                var data = result.Data;
                Assert.NotEmpty(data.Files);

                var file = data.Files.First();
                api.Storage.DownloadFile(file, TestHelper.dstDir + "out.pdf");

                Assert.True(System.IO.File.Exists(TestHelper.dstDir + "out.pdf"));
            }
        }
    }
}
