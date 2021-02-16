using System.Net.Http;
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
    public class StorageDirectoryTests :  IDisposable
    {
        string CliendId { get; set; }
        string ClientSecret { get; set; }

        public StorageDirectoryTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionStorageToStorageTests>().Build();

            CliendId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }


        #region Storage Directory tests

        [Fact]
        public void GetDirectoriesListTest()
        {
            var folder = "/";
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var directories = storage.GetDirectories(folder);
                Assert.NotEmpty(directories);
            }
        }


        [Fact]
        public void GetDirectoryTest()
        {
            var folder = "/HtmlTestDoc";
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;

                var directory = storage.GetDirectory(folder);
                Assert.Equal("HtmlTestDoc/", directory.Name);
            }
        }

        [Fact]
        public void CreateDirectoryTest()
        {
            var folder = $"/NewFolder_{Guid.NewGuid():N}";

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var exists = storage.DirectoryExists(folder);
                Assert.False(exists);

                var dirInfo = storage.CreateDirectory(folder);
                Assert.NotNull(dirInfo);

                exists = storage.DirectoryExists(folder);
                Assert.True(exists);
            }        
        }

        [Fact]
        public void CheckDirectoryExistsTest()
        {
            var folder = "/HTML";
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var exists = storage.DirectoryExists(folder);

            }
        }

        [Fact]
        public void CheckDirectoryExistsTest_1()
        {
            var folder = "/HTML";
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var builtUri = PathUtility.BuildPath("storage", "", folder);
                Assert.True($"storage://{folder}" == builtUri);

                var remoteDir = new RemoteDirectory(new Uri(builtUri), null);
                var exists = storage.DirectoryExists(remoteDir);
                Assert.True(exists);
            }
        }

        [Fact]
        public void DeleteDirectoryTest()
        {
            var folder = $"/NewFolder_{Guid.NewGuid():N}";
            var storageName = ""; // default

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var dirInfo = storage.CreateDirectory(folder, storageName);
                Assert.NotNull(dirInfo);
                var exists = storage.DirectoryExists(folder, storageName);
                Assert.True(exists);

                var delRes = storage.DeleteDirectory(folder, storageName);

                exists = storage.DirectoryExists(folder);
                Assert.False(exists);
            }

        }

        [Fact]
        public void DeleteDirectoryRecursiveTest()
        {
            var folder = $"/NewFolder_{Guid.NewGuid():N}";
            var storageName = ""; // default

            using (var api = new HtmlApi(cb => cb
     .WithClientId(CliendId)
     .WithClientSecret(ClientSecret)))
            {
                var storage = api.Storage;
                var dirInfo = storage.CreateDirectory(folder, storageName);
                Assert.NotNull(dirInfo);
                var exists = storage.DirectoryExists(folder, storageName);
                Assert.True(exists);

                var subfolder = $"{folder}/1";
                dirInfo = storage.CreateDirectory(subfolder, storageName);
                Assert.NotNull(dirInfo);
                exists = storage.DirectoryExists(subfolder, storageName);
                Assert.True(exists);

                subfolder = $"{folder}/2";
                dirInfo = storage.CreateDirectory(subfolder, storageName);
                Assert.NotNull(dirInfo);
                exists = storage.DirectoryExists(subfolder, storageName);
                Assert.True(exists);

                var delRes = storage.DeleteDirectory(folder, storageName, true);

                exists = storage.DirectoryExists(folder);
                Assert.False(exists);
            }          
        }

        #endregion

        public void Dispose()
        {
        }


    }
}
