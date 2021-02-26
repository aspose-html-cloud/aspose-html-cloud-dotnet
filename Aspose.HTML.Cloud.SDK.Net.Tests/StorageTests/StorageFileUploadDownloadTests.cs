using System.Net.Http;
using System.Text;
using System.Linq;
using Xunit;
using Assert = Xunit.Assert;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;
using Aspose.HTML.Cloud.Sdk.IO;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class StorageFileUploadDownloadTests : IDisposable
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public StorageFileUploadDownloadTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionStorageToStorageTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                api.Storage.UploadFile(@"Input\html_file.html", "html_file.html", "", NameCollisionOption.ReplaceExisting);
                api.Storage.UploadFile(@"Input\testpage1.html", "/TestData/testpage1.html", "", NameCollisionOption.ReplaceExisting);
            }
        }

        #region Storage File tests - upload/download 

        [Fact]
        public void UploadFileTest()
        {
            var localPath = @"Input\html_file.html";
            var storagePath = "/TestData/html_file.html";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var exists = storage.FileExists(storagePath);
                if (exists)
                    storage.DeleteFile(storagePath);
                else
                    Assert.False(exists);

                var file = storage.UploadFile(localPath, storagePath);

                exists = storage.FileExists(storagePath);
                Assert.True(exists);
            }         
        }

        [Fact]
        public void UploadBytesTest()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var data = Encoding.ASCII.GetBytes("Hello World!!");
                var file = storage.UploadData(data, "file.html");

                var parsed = PathUtility.Parse(file.Path);
                var finfo = storage.GetFileInfo(parsed.Path, parsed.StorageName);
                Assert.Equal(data.Length, finfo.Info.Size);
            }           
        }

        [Fact]
        public void DownloadFileTest()
        {
            var storagePath = "/TestData/html_example1.html";
            var localPath = "c:\\work\\html_example1.html";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                storage.DownloadFile(storagePath, localPath);

                Assert.True(System.IO.File.Exists(localPath));
            }
           
        }

        [Fact]
        public void DownloadFileFromLIstTest()
        {
            var storagePath = "/TestData/";
            var localPath = @"Output\StorageDownload";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var files = storage.GetFiles(storagePath);
                Assert.True(files.Count > 0);

                var local = $"{localPath}{files.First().Name}";
                storage.DownloadFile(files.First(), local);

                Assert.True(System.IO.File.Exists(local));
            }
            
        }

        [Fact]
        public void DownloadDataTest()
        {
            var filePath = "/test_hello.html";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var data = Encoding.ASCII.GetBytes("Hello World!!");
                var file = storage.UploadData(data, filePath);

                var fileData = storage.DownloadData(filePath);
                Assert.Equal(data, fileData);
            }           
        }

        [Fact]
        public void DownloadDataTest_1()
        {
            var filePath = "/HTML/html_example1.html";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var fileData = storage.DownloadData(filePath);
                Assert.True(fileData.Length > 0);
            }           
        }

        #endregion


        #region Storage File tests - upload/download asynchronous

        [Fact]
        public void UploadFileAsyncTest()
        {
            var localPath = "d:\\aspose\\TestData\\html_example1.html";
            var storagePath = "/HTML/Testout/html_example1.html";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var exists = storage.FileExists(storagePath);
                if (exists)
                    storage.DeleteFile(storagePath);
                else
                    Assert.False(exists);

                var task = storage.UploadFileAsync(localPath, storagePath);
                task.AsyncWaitHandle.WaitOne();
                // OR
                //while (!result.IsCompleted)
                //    Thread.Sleep(10);

                exists = storage.FileExists(storagePath);
                Assert.True(exists);
            }        
        }

        [Fact]
        public void UploadBytesAsyncTest()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var data = Encoding.ASCII.GetBytes("Hello World!!");
                var task = storage.UploadDataAsync(data, "file.html");

                task.AsyncWaitHandle.WaitOne();
                // OR
                //while (!result.IsCompleted)
                //    Thread.Sleep(10);

                var file = task.Data;
                var parsed = PathUtility.Parse(file.Path);
                var finfo = storage.GetFileInfo(parsed.Path, parsed.StorageName);
                Assert.Equal(data.Length, finfo.Info.Size);
            }         
        }

        [Fact]
        public void DownloadFileAsyncTest()
        {
            var filePath = "/HTML/html_example1.html";
            if (System.IO.File.Exists("c:\\folder\\file.html"))
                File.Delete("c:\\folder\\file.html");

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var task = storage.DownloadFileAsync(filePath, "c:\\folder\\file.html");

                task.AsyncWaitHandle.WaitOne();

                Assert.True(System.IO.File.Exists("c:\\folder\\file.html"));
            }           
        }

        #endregion

        public void Dispose()
        {
        }

    }
}
