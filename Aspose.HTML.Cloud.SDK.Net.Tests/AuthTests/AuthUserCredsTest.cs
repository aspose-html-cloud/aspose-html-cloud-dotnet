using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;
using System.Threading;
using Aspose.HTML.Cloud.Sdk.IO;
using Xunit;
using Assert = Xunit.Assert;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;
using Microsoft.Extensions.Configuration;

namespace Aspose.HTML.Cloud.Sdk.Tests.AuthTests
{

    public class AuthUserCredsTest : IDisposable
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        public AuthUserCredsTest()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionStorageToStorageTests>().Build();

            ClientId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void AuthenticateJwt_Single ()
        {
            var folder = "/HTML";

            using (var api = new HtmlApi(cb => cb
                .WithClientId(ClientId)
                .WithClientSecret(ClientSecret)))
            {
                var storageApi = api.Storage;
                Assert.True(storageApi.DirectoryExists(folder));
            }
        }

        [Fact]
        public void AuthenticateJwt_Sequence()
        {
            var folder = "/HTML";

            using (var api = new HtmlApi(cb => cb
                .WithClientId(ClientId)
                .WithClientSecret(ClientSecret)))
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
                            new KeyValuePair<string, string>("client_id", ClientId),
                            new KeyValuePair<string, string>("client_secret", ClientSecret)
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
                .WithExternalAuthentication(token)))
            {              
                var storageApi = api2.Storage;
                var exists = storageApi.DirectoryExists(folder);
                Assert.True(exists);
            }
        }


        public void Dispose()
        {
        }
    }
}
