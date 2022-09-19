using Xunit;
using Assert = Xunit.Assert;
using System;
using System.Threading.Tasks;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class StorageDirectoryTests : IClassFixture<BaseTest>
    {

        private readonly BaseTest testData;

        public StorageDirectoryTests(BaseTest fixture)
        {
            testData = fixture;
        }

        [Fact]
        public async Task GetDirectoriesListTest()
        {
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var folder = "/";
            var directories = await api.GetDirectoriesAsync(folder);
            Assert.NotEmpty(directories);
        }

        [Fact]
        public async Task CreateDirectoryTest()
        {
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var folder = $"NewFolder_{Guid.NewGuid():N}";

            var exists = await api.DirectoryExistsAsync(folder);
            Assert.False(exists);

            var dirInfo = await api.CreateDirectoryAsync(folder);
            Assert.NotNull(dirInfo);

            exists = await api.DirectoryExistsAsync(folder);
            Assert.True(exists);
            
        }

        [Fact]
        public async Task DeleteDirectoryTest()
        {
            var folder = $"/NewFolder_{Guid.NewGuid():N}";
            var storageName = ""; // default
            
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var dirInfo = await api.CreateDirectoryAsync(folder, storageName);
            Assert.NotNull(dirInfo);
            var exists = await api.DirectoryExistsAsync(folder, storageName);
            Assert.True(exists);

            await api.DeleteDirectoryAsync(folder, storageName);

            exists = await api.DirectoryExistsAsync(folder);
            Assert.False(exists);
        }

        [Fact]
        public async Task DeleteDirectoryRecursiveTest()
        {
            var folder = $"/NewFolder_{Guid.NewGuid():N}";
            var storageName = ""; // default

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var dirInfo = await api.CreateDirectoryAsync(folder, storageName);
            Assert.NotNull(dirInfo);
            var exists = await api.DirectoryExistsAsync(folder, storageName);
            Assert.True(exists);

            var subfolder = $"{folder}/1";
            dirInfo = await api.CreateDirectoryAsync(subfolder, storageName);
            Assert.NotNull(dirInfo);
            exists = await api.DirectoryExistsAsync(subfolder, storageName);
            Assert.True(exists);

            subfolder = $"{folder}/2";
            dirInfo = await api.CreateDirectoryAsync(subfolder, storageName);
            Assert.NotNull(dirInfo);
            exists = await api.DirectoryExistsAsync(subfolder, storageName);
            Assert.True(exists);

            await api.DeleteDirectoryAsync(folder, storageName, true);

            exists = await api.DirectoryExistsAsync(folder);
            Assert.False(exists);
           
        }
    }
}
