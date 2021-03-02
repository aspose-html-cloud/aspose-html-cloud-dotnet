using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;
using System.Threading;
using Aspose.HTML.Cloud.Sdk.IO;
using Xunit;
using Assert = Xunit.Assert;
using System.Collections.Generic;
using Newtonsoft.Json;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;
using Microsoft.Extensions.Configuration;


namespace Aspose.HTML.Cloud.Sdk.Tests.AuthTests
{
    public class AuthUserCredsConstructorsTest : IDisposable
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public AuthUserCredsConstructorsTest()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionStorageToStorageTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void AuthenticateUserCreds_Single()
        {
            var folder = "/Html";

            using (var api = new HtmlApi(ClientId, ClientSecret))
            {
                var storageApi = api.Storage;
                var exists = storageApi.DirectoryExists(folder);
                Assert.True(exists);
            }
        }


        [Fact]
        public void AuthenticateUserCreds_Sequence()
        {
            var folder = "/Html";

            using (var api = new HtmlApi(ClientId, ClientSecret))
            {
                var storageApi = api.Storage;

                var exists = storageApi.DirectoryExists(folder);
                Assert.True(exists);

                var rndFolder = $"/NewFolder_{Guid.NewGuid():N}";
                exists = storageApi.DirectoryExists(rndFolder);
                Assert.False(exists);

                var dirInfo = storageApi.CreateDirectory(rndFolder);
                Assert.NotNull(dirInfo);

                exists = storageApi.DirectoryExists(rndFolder);
                Assert.True(exists);
            }
        }

        public void Dispose()
        {
        }
    }
}
