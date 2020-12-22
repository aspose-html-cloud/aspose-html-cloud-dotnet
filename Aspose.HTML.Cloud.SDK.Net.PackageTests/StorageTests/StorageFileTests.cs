using System.IO;
using System.Net.Http;
using System.Linq;
using Aspose.HTML.Cloud.Sdk.IO;
using Xunit;
using Assert = Xunit.Assert;
using System;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class StorageFileTests : IClassFixture<BaseTest>, IDisposable
    {
        private readonly HttpClient client;
        private HtmlApi api;

        public StorageFileTests(BaseTest fixture)
        {
            //client = fixture.CreateClient();
            api = new HtmlApi(cb => cb
                //.WithHttpClient(client)
                .WithAppSid(fixture.AppSid)
                .WithAppKey(fixture.AppKey)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }


        #region Storage File tests - exists, list, file info

        [Fact]
        public void CheckFileExistsTest()
        {
            var filePath = "/test.html";

            var storage = api.Storage;
            var exists = storage.FileExists(filePath);
        }

        //[Fact]
        //public void CheckFileExistsTest_1()
        //{
        //    var filePath = "/test.html";

        //    var storage = api.Storage;
        //    var builtUri = PathUtility.BuildPath("storage", "", filePath);
        //    Assert.True($"storage://{filePath}" == builtUri);

        //    var remoteFile = new RemoteFile(new Uri(builtUri), null);
        //    var exists = storage.FileExists(remoteFile);
        //    Assert.True(exists);
           
        //}

        [Fact]
        public void GetFilesListTest()
        {
            var folder = "/";

            var storage = api.Storage;
            var files = storage.GetFiles(folder);
            Assert.NotNull(files);
            Assert.NotEmpty(files);
            Assert.True(files.Count > 0);
            Assert.True(files[0].Info != null && files[0].Info.Size > 0);
            
        }

        [Fact]
        public void GetFilesListTest_1()
        {
            var folder = "/HTML";

            var storage = api.Storage;
            var files = storage.GetFiles(folder);
            Assert.NotNull(files);
            Assert.NotEmpty(files);
            Assert.True(files.Count > 0);
            Assert.True(files[0].Info != null && files[0].Info.Size > 0);
            
        }

        [Fact]
        public void GetFileInfoTest()
        {
            var filePath = "/test.html";
            var fileName = Path.GetFileName(filePath);

            var storage = api.Storage;
            var file = storage.GetFileInfo(filePath);

            Assert.Equal(fileName, file.Name);
            
        }

        [Fact]
        public void GetFileFromDirectoryTest()
        {
            var storageFolder = "/HTML";
            var fileName = "html_example1.html";

            var storage = api.Storage;
            var directory = storage.GetDirectory(storageFolder);
            var file = storage.GetFileInfo(directory, fileName);
            Assert.NotNull(file);
            Assert.Equal(fileName, file.Name);           
        }

        #endregion


        #region Storage File tests - copy, move, delete

        [Fact]
        public void CopyFileTest()
        {
            var storagePathSrc = "/HTML/html_example1.html";
            var storagePathDst = "/HTML/Testout/html_example1_copy.html";

            var storage = api.Storage;

            var resultFile = storage.CopyFile(
                storagePathSrc, storagePathDst, "", "", NameCollisionOption.ReplaceExisting);

            var sourceFile = storage.GetFileInfo(storagePathSrc);
            var destinationFile = storage.GetFileInfo(storagePathDst);

            //Assert.Equal(sourceFile.Info.Size, resultFile.Info.Size);
            Assert.Equal(destinationFile.Path, resultFile.Path);
            
        }

        [Fact]
        public void DeleteFile()
        {
            var storagePath = "/HTML/Testout";
            //var storagePath = "folder/file.html";
            var storageFilePath = "";

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

            //delete = storage.DeleteFile(file);
            //Assert.False(delete);
            
        }

        #endregion

        #region Storage File tests - open to read

        [Fact]
        public void ReadFromStreamTest()
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

        #endregion

        public void Dispose()
        {
            client?.Dispose();
            api?.Dispose();
        }
    }
}
