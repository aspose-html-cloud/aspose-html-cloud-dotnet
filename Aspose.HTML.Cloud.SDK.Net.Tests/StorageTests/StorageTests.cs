using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Xunit;
using Assert = Xunit.Assert;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class StorageTests :  IDisposable
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        public StorageTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionStorageToStorageTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        #region Storage tests

        //[Fact]
        //public void GetStorageInfoTest()
        //{
        //    string storageName = "First Storage";  // put your storage name here

        //    using (var api = new HtmlApi(cb => cb
        //         .WithClientId(ClientId)
        //         .WithClientSecret(ClientSecret)))
        //    {
        //        var storageApi = api.Storage;
        //        Assert.True(storageApi.Exists(storageName));

        //        var storage = storageApi.GetStorage(storageName);
        //        Assert.Equal(storageName, storage.Name);
        //        Assert.True(storage.TotalSize > 0);
        //    }        
        //}

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
        }


    }
}