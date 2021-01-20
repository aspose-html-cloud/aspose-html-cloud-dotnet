using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Xunit;
using Assert = Xunit.Assert;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class StorageTests : IClassFixture<BaseTest>, IDisposable
    {
        private readonly HttpClient client;
        private HtmlApi api;

        public StorageTests(BaseTest fixture)
        {
            //client = fixture.CreateClient();
            api = new HtmlApi(cb => cb
                //.WithHttpClient(client)
                .WithClientId(fixture.ClientId)
                .WithClientSecret(fixture.ClientSecret)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        #region Storage tests

        [Fact]
        public void GetStorageInfoTest()
        {
            string storageName = "First Storage";

            var storageApi = api.Storage;
            Assert.True(storageApi.Exists(storageName));

            var storage = storageApi.GetStorage(storageName);
            Assert.Equal(storageName, storage.Name);
            Assert.True(storage.TotalSize > 0);
           
        }

        #endregion

        //[Fact]
        //public void WriteToStreamTest()
        //{
        //    //using (var api = new HtmlApi(_ 
        //    //    => _.WithHttpClient(client)))
        //    //{
        //    //    var storage = api.Storage;
        //    //    var file = storage.CreateFile("file.html");
        //    //    Assert.Equal(0, file.Info.Size);

        //    //    var data = Encoding.ASCII.GetBytes("Hello World!!");
        //    //    using (var stream = storage.OpenWrite(file))
        //    //    {
        //    //        stream.Write(data, 0, data.Length);
        //    //    }

        //    //    file = storage.GetFileInfo("file.html");
        //    //    Assert.Equal(data.Length, file.Info.Size);
        //    //}
        //}


        public void Dispose()
        {
            client?.Dispose();
            api?.Dispose();
        }


    }
}