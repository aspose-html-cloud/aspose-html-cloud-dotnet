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

namespace Aspose.HTML.Cloud.Sdk.Tests.AuthTests
{
    public class AuthUserCredsConstructorsTest : BaseTest, IDisposable
    {
        private readonly string QA_APPSID = "html.cloud";
        private readonly string QA_APPKEY = "html.cloud";
        private readonly string LOCAL_BASE_URL = "https://localhost:5001/v4.0/html";
        private const string LOCAL_DOCKER_BASE_URL = "https://localhost:47976/v4.0/html";

        private readonly HttpClient client;
        private HtmlApi api;

        public AuthUserCredsConstructorsTest()
        {

        }

        [Fact]
        public void AuthenticateJwt_Single()
        {
            string storageName = "First Storage";

            api = new HtmlApi(QA_APPSID, QA_APPKEY, ApiServiceBaseUrl);

            var storageApi = api.Storage;
            Assert.True(storageApi.Exists(storageName));

        }

        [Fact]
        public void AuthenticateJwt_Sequence()
        {
            var folder = "/HTML";
            api = new HtmlApi(QA_APPSID, QA_APPKEY, ApiServiceBaseUrl);
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

        public void Dispose()
        {
            client?.Dispose();
            api?.Dispose();
        }
    }
}
