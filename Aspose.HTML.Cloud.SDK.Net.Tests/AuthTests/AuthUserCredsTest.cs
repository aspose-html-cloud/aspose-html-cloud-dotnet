// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="AuthUserCredsTest.cs">
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


using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;
using Assert = Xunit.Assert;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Aspose.HTML.Cloud.Sdk.Tests.AuthTests
{

    public class AuthUserCredsTest : IClassFixture<BaseTest>, IDisposable
    {
        private readonly string QA_APPSID = "html.cloud";
        private readonly string QA_APPKEY = "html.cloud";
        private readonly string LOCAL_BASE_URL = "https://localhost:5001/v4.0/html";
        private const string LOCAL_DOCKER_BASE_URL = "https://localhost:47976/v4.0/html";
        

        private readonly HttpClient client;
        private HtmlApi api;

        private string ApiBaseUrl { get; set; }

        public AuthUserCredsTest(BaseTest fixture)
        {
            ApiBaseUrl = fixture.ApiServiceBaseUrl;
            client = fixture.CreateClient();
            api = new HtmlApi(cb => cb
                .WithAppSid(fixture.AppSid)
                .WithAppKey(fixture.AppKey)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void AuthenticateJwt_Single ()
        {
            string storageName = "First Storage";

            var storageApi = api.Storage;
            Assert.True(storageApi.Exists(storageName));

        }

        [Fact]
        public void AuthenticateJwt_Sequence()
        {
            var folder = "/HTML";

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

        [Fact]
        public void AuthenticateJwt_External()
        {
            var folder = "/HTML";
            var token = "";

            // this code block emulates an external source of an authentication token
            using(var authClient = new HttpClient())
            {
                var authUrl = "https://api-qa.aspose.cloud/connect/token";
                
                HttpRequestMessage authReq = new HttpRequestMessage()
                {
                    RequestUri = new Uri(authUrl),
                    Method = HttpMethod.Post
                };
                authReq.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                List<KeyValuePair<string, string>> authReqContent = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("grant_type", "client_credentials"),
                            new KeyValuePair<string, string>("client_id", QA_APPSID),
                            new KeyValuePair<string, string>("client_secret", QA_APPKEY)
                        };
                authReq.Content = new FormUrlEncodedContent(authReqContent);
                authReq.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                var authResponse = authClient.SendAsync(authReq).Result;
                Assert.True(authResponse.StatusCode == System.Net.HttpStatusCode.OK);

                var content = authResponse.Content.ReadAsStringAsync().Result;
                Dictionary<string, object> dict =
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                Assert.True(dict.ContainsKey("access_token"));
                token = dict["access_token"].ToString();
                Assert.NotEmpty(token);
            }

            // base URL (REST API service URL) and externally obtained auth token are required here
            using (var api2 = new HtmlApi(cb => cb
            .WithBaseUrl(ApiBaseUrl)
            .WithExternalAuthentication(token)))
            {
                
                var storageApi = api.Storage;

                var exists = storageApi.DirectoryExists(folder);
                Assert.True(exists);
            }
        }


        public void Dispose()
        {
            client?.Dispose();
            api?.Dispose();
        }
    }
}
