using System.IO;
using System.Text;
using System.Linq;
using Xunit;
using Assert = Xunit.Assert;
using System.Threading.Tasks;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class StorageFileUploadDownloadTests : IClassFixture<BaseTest>
    {
        private readonly BaseTest testData;
        private readonly string sourceFile = Path.Combine(TestHelper.SrcDir, "html_file.html");

        public StorageFileUploadDownloadTests(BaseTest fixture)
        {
            testData = fixture;
        }

        [Fact]
        public async Task UploadFileTest()
        {
            var storagePath = "/HTML/html_example1.html";

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var exists = await api.FileExistsAsync(storagePath);
            if (exists)
            {
                await api.DeleteFileAsync(storagePath);
            }

            var file = await api.UploadFileAsync(sourceFile, storagePath);
            Assert.NotNull(file);
            exists = await api.FileExistsAsync(storagePath);
            Assert.True(exists);
            
        }

        [Fact]
        public async Task UploadBytesTest()
        {
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var data = Encoding.ASCII.GetBytes("Hello World!!");
            var storageFile = "html_file.html";
            var exists = await api.FileExistsAsync(storageFile);
            if (exists)
            {
                await api.DeleteFileAsync(storageFile);
            }
            var file = await api.UploadDataAsync(data, storageFile);

            var remoteFile = await api.GetFileInfoAsync(file.Path);
            Assert.Equal(data.Length, remoteFile.Info.Size);
            
        }

        [Fact]
        public async Task DownloadFileTest()
        {
            var localPath = "c:\\folder\\";
            var storagePath = "/HTML/html_example1.html";
            var localFile = $"{localPath}\\html_example1.html";

            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var data = Encoding.ASCII.GetBytes("Hello World!!");
            await api.UploadDataAsync(data, storagePath);

            await api.DownloadFileAsync(storagePath, localFile);
            Assert.True(File.Exists(localFile));
        }

        [Fact]
        public async Task DownloadFileFromListTest()
        {
            var storagePath = "/HtmlTestDoc";
            var localPath = "c:\\folder\\";
            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var data = Encoding.ASCII.GetBytes("Hello World!!");
            await api.UploadDataAsync(data, $"{storagePath}/test.html");

            var files = await api.GetFilesAsync(storagePath);
            Assert.True(files.Count > 0);

            var local = $"{localPath}{Path.GetFileName(files.First().Path)}";
            await api.DownloadFileAsync(files.First().Path, local);

            Assert.True(File.Exists(local));
            
        }

        [Fact]
        public async Task DownloadDataTest()
        {
            var filePath = "/test_hello.html";

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var data = Encoding.ASCII.GetBytes("Hello World!!");
            await api.UploadDataAsync(data, filePath);
            var fileData = await api.DownloadDataAsync(filePath);
            Assert.Equal(data, fileData);
            
        }

        [Fact]
        public async Task DownloadDataTest_1()
        {
            var filePath = "/HTML/html_example1.html";

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var fileData = await api.DownloadDataAsync(filePath);
            Assert.True(fileData.Length > 0);
            
        }

        [Fact]
        public async Task UploadFileAsyncTest()
        {
            var storagePath = "/HTML/Testout/html_example1.html";
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var exists = await api.FileExistsAsync(storagePath);
            if (exists)
            {
                await api.DeleteFileAsync(storagePath);
            }
            else
            {
                Assert.False(exists);
            }

            await api.UploadFileAsync(sourceFile, storagePath);

            exists = await api.FileExistsAsync(storagePath);
            Assert.True(exists);
            
        }

        [Fact]
        public async Task UploadBytesAsyncTest()
        {
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var data = Encoding.ASCII.GetBytes("Hello World!!");
            var file = await api.UploadDataAsync(data, "file.html");
            var fileInfo = await api.GetFileInfoAsync(file.Path);
            Assert.Equal(data.Length, fileInfo.Info.Size);
            
        }

        [Fact]
        public async Task DownloadFileAsyncTest()
        {
            var filePath = "/HTML/html_example1.html";
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var data = Encoding.ASCII.GetBytes("Hello World!!");
            await api.UploadDataAsync(data, filePath);

            if (!Directory.Exists(@"c:\\folder"))
            {
                Directory.CreateDirectory(@"c:\\folder");
            }
            await api.DownloadFileAsync(filePath, "c:\\folder\\file.html");
            Assert.True(File.Exists("c:\\folder\\file.html"));
        }
    }
}
