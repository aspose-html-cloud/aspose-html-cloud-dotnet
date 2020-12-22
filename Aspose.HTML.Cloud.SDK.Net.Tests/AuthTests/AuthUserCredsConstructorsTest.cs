// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="AuthUserCredsConstructorsTest.cs">
//   Copyright (c) 2020 Aspose.HTML Cloud
// </copyright>
// <summary>
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net.Http;
using Xunit;
using Assert = Xunit.Assert;

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
