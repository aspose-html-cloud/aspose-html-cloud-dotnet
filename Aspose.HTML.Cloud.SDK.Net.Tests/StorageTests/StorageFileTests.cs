using System.IO;
using System.Net.Http;
using System.Linq;
using Aspose.HTML.Cloud.Sdk.IO;
using Xunit;
using Assert = Xunit.Assert;
using System;
using System.IO;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class StorageFileTests : IDisposable
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public StorageFileTests()
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


        #region Storage File tests - exists, list, file info

        [Fact]
        public void CheckFileExistsTest()
        {
            var filePath = "/html_file.html";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var exists = storage.FileExists(filePath);                  

                Assert.True(exists);
            }
        }

        [Fact]
        public void CheckFileExistsTest_1()
        {
            var filePath = "/html_file.html";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var builtUri = PathUtility.BuildPath("storage", "", filePath);
                Assert.True($"storage://{filePath}" == builtUri);

                var remoteFile = new RemoteFile(new Uri(builtUri), null);
                var exists = storage.FileExists(remoteFile);
                Assert.True(exists);
            }
        }

        [Fact]
        public void GetFilesListTest()
        {
            var folder = "/";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var files = storage.GetFiles(folder);
                Assert.NotNull(files);
                Assert.NotEmpty(files);
                Assert.True(files.Count > 0);
                Assert.True(files[0].Info != null && files[0].Info.Size > 0);
            }          
        }

        [Fact]
        public void GetFilesListTest_1()
        {
            var folder = "/TestData";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var files = storage.GetFiles(folder);
                Assert.NotNull(files);
                Assert.NotEmpty(files);
                Assert.True(files.Count > 0);
                Assert.True(files[0].Info != null && files[0].Info.Size > 0);
            }               
        }

        [Fact]
        public void GetFileInfoTest()
        {
            var filePath = "/TestData/testpage1.html";
            var fileName = Path.GetFileName(filePath);

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var file = storage.GetFileInfo(filePath);

                Assert.Equal(fileName, file.Name);
            }           
        }

        [Fact]
        public void GetFileFromDirectoryTest()
        {
            var storageFolder = "/TestData";
            var fileName = "testpage1.html";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var directory = storage.GetDirectory(storageFolder);
                Assert.NotNull(directory);
                var file = storage.GetFileInfo(directory, fileName);
                Assert.NotNull(file);
                Assert.Equal(fileName, file.Name);
            }         
        }

        #endregion


        #region Storage File tests - copy, move, delete

        [Fact]
        public void CopyFileTest()
        {
            var storagePathSrc = "/TestData/testpage1.html";
            var storagePathDst = "/Testout/testpage1_copy.html";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var exists = storage.FileExists(storagePathSrc);
                Assert.True(exists);

                var resultFile = storage.CopyFile(
                    storagePathSrc, storagePathDst, "", "", NameCollisionOption.ReplaceExisting);

                var sourceFile = storage.GetFileInfo(storagePathSrc);
                var destinationFile = storage.GetFileInfo(storagePathDst);

                //Assert.Equal(sourceFile.Info.Size, resultFile.Info.Size);
                Assert.Equal(destinationFile.Path, resultFile.Path);
            }          
        }

        [Fact]
        public void DeleteFile()
        {
            var storagePath = "/TestData";
            //var storagePath = "folder/file.html";
            var storageFilePath = "";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;

                var files = storage.GetFiles(storagePath);
                Assert.True(files.Count > 0);
                storageFilePath = files.LastOrDefault().Path;
                Assert.NotEmpty(storageFilePath);

                var file = storage.GetFileInfo(storageFilePath);
                var exists = storage.FileExists(file);
                Assert.True(exists);

                var delete = storage.DeleteFile(file);
                Assert.True(delete);

                exists = storage.FileExists(file);
                Assert.False(exists);
            }
        }

        #endregion

        #region Storage File tests - open to read

        [Fact]
        public void ReadFromStreamTest()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(ClientId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var data = System.Text.Encoding.ASCII.GetBytes("Hello World!!");
                var file = storage.UploadData(data, "file.html");

                using (var stream = storage.OpenRead(file))
                using (StreamReader reader = new StreamReader(stream))
                {
                    var content = reader.ReadToEnd();
                    Assert.Equal("Hello World!!", content);
                }
            }            
        }

        #endregion

        public void Dispose()
        {
        }
    }
}
