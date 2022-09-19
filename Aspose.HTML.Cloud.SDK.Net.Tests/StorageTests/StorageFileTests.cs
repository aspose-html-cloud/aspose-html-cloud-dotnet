using System.IO;
using System.Linq;
using Xunit;
using Assert = Xunit.Assert;
using System.Threading.Tasks;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class StorageFileTests : IClassFixture<BaseTest>
    {
        private readonly BaseTest testData;

        public StorageFileTests(BaseTest fixture)
        {
            testData = fixture;
        }

        [Fact]
        public async Task CheckFileExistsTest()
        {
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var data = System.Text.Encoding.ASCII.GetBytes("Hello World!!");
            await api.UploadDataAsync(data, "test.html");
            var filePath = "/test.html";
            var exists = await api.FileExistsAsync(filePath);
            Assert.True(exists);
        }


        [Fact]
        public async Task DeleteFile()
        {
            var storagePath = "/HTML/Testout";
            var fileName = "file_to_delete.html";
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var data = System.Text.Encoding.ASCII.GetBytes("Hello World!!");
            await api.UploadDataAsync(data, $"{storagePath}/{fileName}");

            var files = await api.GetFilesAsync(storagePath);
            Assert.True(files.Count > 0);
            var storageFilePath = files.Last().Path;
            Assert.NotEmpty(storageFilePath);

            var file = await api.GetFileInfoAsync(storageFilePath);
            var exists = await api.FileExistsAsync(file.Path);
            Assert.True(exists);

            var delete = await api.DeleteFileAsync(file.Path);
            Assert.True(delete);

            exists = await api.FileExistsAsync(file.Path);
            Assert.False(exists);
        }

        [Fact]
        public async Task ReadFromStreamTest()
        {
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var data = System.Text.Encoding.ASCII.GetBytes("Hello World!!");
            var file = await api.UploadDataAsync(data, "file.html");
            
            using (var stream = await api.OpenReadAsync(file.Path))
            using (var reader = new StreamReader(stream))
            {
                var content = await reader.ReadToEndAsync();
                Assert.Equal("Hello World!!", content);
            }
            
        }
    }
}
