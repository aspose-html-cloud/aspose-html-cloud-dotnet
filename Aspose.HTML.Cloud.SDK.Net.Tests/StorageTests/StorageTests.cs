using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class StorageTests : IClassFixture<BaseTest>
    {
        private readonly BaseTest testData;

        public StorageTests(BaseTest fixture)
        {
            testData = fixture;
        }


        [Fact]
        public async Task GetStorageInfoTest()
        {
            var storageName = "First Storage";
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var exists = await api.ExistsAsync(storageName);
            Assert.True(exists);
            var storage = await api.GetStorageAsync(storageName);
            Assert.Equal(storageName, storage.Name);
            Assert.True(storage.TotalSize > 0);
        }

    }
}