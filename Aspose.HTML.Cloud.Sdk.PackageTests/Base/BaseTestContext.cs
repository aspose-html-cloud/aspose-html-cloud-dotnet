// // --------------------------------------------------------------------------------------------------------------------
// // <copyright company="Aspose" file="BaseTestContext.cs">
// //   Copyright (c) 2019 Aspose.HTML Cloud
// // </copyright>
// // <summary>
// //   Permission is hereby granted, free of charge, to any person obtaining a copy
// //  of this software and associated documentation files (the "Software"), to deal
// //  in the Software without restriction, including without limitation the rights
// //  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// //  copies of the Software, and to permit persons to whom the Software is
// //  furnished to do so, subject to the following conditions:
// // 
// //  The above copyright notice and this permission notice shall be included in all
// //  copies or substantial portions of the Software.
// // 
// //  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// //  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// //  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// //  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// //  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// //  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// //  SOFTWARE.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------


namespace Aspose.HTML.Cloud.Sdk.Tests.Base
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;
    using Aspose.Html.Cloud.Sdk.Api;
    using Aspose.Html.Cloud.Sdk.Api.Interfaces;
    using Aspose.Html.Cloud.Sdk.Api.Model;
    using Aspose.Html.Cloud.Sdk.Client;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Aspose.Html.Cloud.Sdk.Client.Authentication;


    /// <summary>
    /// Base class for all tests
    /// </summary>
    public abstract class BaseTestContext
    {
        protected class Keys
        {
            [JsonProperty(PropertyName = "AppSid", Required = Required.Always)]
            public string AppSid { get; set; }

            [JsonProperty(PropertyName = "AppKey", Required = Required.Always)]
            public string AppKey { get; set; }

            [JsonProperty(PropertyName = "basePath", Required = Required.Always)]
            public string BaseProductUri { get; set; }

            [JsonProperty(PropertyName = "authPath")]
            public string AuthServerUri { get; set; }

            [JsonProperty(PropertyName = "apiVersion")]
            public string ApiVersion { get; set; }
        }

        protected const string DefBaseProductUri = @"http://aspose.aspose.cloud";
        //protected const string BaseProductUri = @"http://sikorsky-js3.dynabic.com:9083";

        protected const string DefAuthServerUri = @"http://aspose.aspose.cloud";

        protected Keys keys;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTestContext"/> class.
        /// </summary>
        protected BaseTestContext()
        {
            // To run tests with your own credentials please substitute code bellow with this one
            // this.keys = new Keys { AppKey = "your app key", AppSid = "your app sid" };
            var serverCreds = DirectoryHelper.GetPath("Settings", "servercreds.json");
            this.keys = JsonConvert.DeserializeObject<Keys>(File.ReadAllText(serverCreds));
            if (this.keys == null)
            {
                throw new FileNotFoundException("servercreds.json doesn't contain AppKey and AppSid");
            }

            var config = new Configuration {
                ApiBaseUrl = this.keys.BaseProductUri,
                AuthUrl = this.keys.AuthServerUri ?? DefAuthServerUri,
                ApiVersion = this.keys.ApiVersion ?? Configuration.DefaultApiVersion,
                AppKey = this.keys.AppKey,
                AppSid = this.keys.AppSid };

            var baseUrl = config.ApiBaseUrl + $"/v{config.ApiVersion}";

            this.HtmlApi = new HtmlApi(
                config.AppSid, config.AppKey, baseUrl, config.AuthUrl);

            this.StorageApi = new StorageApi(this.HtmlApi);

            var tokenObj = GetAuthToken();
            //this.HtmlApiEx = new HtmlApi(tokenObj, baseUrl);
            //this.StorageApiEx = new StorageApi(tokenObj, baseUrl);
            this.StorageApiEx = new StorageApi(tokenObj.Token, baseUrl);
            this.HtmlApiEx = new HtmlApi(tokenObj.Token, baseUrl);
        }

        /// <summary>
        /// Base path to test data - local      
        /// </summary>
        /// 
        protected static string LocalTestDataPath
        {
            get
            {
                var root = DirectoryHelper.GetRootSdkFolder();
                return Path.Combine(root, "TestData", "HTML");
            }
        }

        /// <summary>
        /// Base path to test data - storage      
        /// </summary>
        protected static string StorageTestDataPath
        {
            get
            {
                //return "Temp/SdkTests/TestData";
                return "/Html/TestData";
            }
        }

        /// <summary>
        /// Base path to output data - local
        /// </summary>
        protected static string BaseTestOutPath
        {
            get
            {
                return "TestOut";
            }
        }

        /// <summary>
        /// Base storage path to output data - storage
        /// </summary>
        protected static string StorageTestoutFolder
        {
            get
            {
                return "/Html/TestOut";
            }
        }



        /// <summary>
        /// Returns common folder with source test files
        /// </summary>
        protected static string CommonFolder
        {
            get
            {
                return "Common/";
            }
        }

        /// <summary>
        /// Storage API
        /// </summary>
        protected StorageApi StorageApi { get; set; }

        /// <summary>
        /// Html API
        /// </summary>
        protected HtmlApi HtmlApi { get; set; }

        protected HtmlApi HtmlApiEx { get; set; }

        protected StorageApi StorageApiEx { get; set; }


        /// <summary>
        /// AppSid
        /// </summary>
        protected string AppSid
        {
            get
            {
                return this.keys.AppSid;
            }
        }

        /// <summary>
        /// AppSid
        /// </summary>
        protected string AppKey
        {
            get
            {
                return this.keys.AppKey;
            }
        }

        /// <summary>
        /// Returns test data path
        /// </summary>
        /// <param name="subfolder">subfolder for specific tests</param>
        /// <returns>test data path</returns>
        protected static string GetDataDir(string subfolder = null)
        {
            return Path.Combine("TestData", string.IsNullOrEmpty(subfolder) ? string.Empty : subfolder);
        }

        protected void uploadFileToStorage(string dataFolder, string name, string folder)
        {
            string srcPath = Path.Combine(dataFolder, name);
            string path = Path.Combine(folder, name).Replace('\\', '/');
            using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = StorageApi.UploadFile(fstr, path);
                Assert.IsTrue(response != null);
                Assert.IsTrue(response.Code == 200);
                bool exists = StorageApi.FileOrFolderExists(path);
                Assert.IsTrue(exists);
            }
        }

        protected static string saveResultStreamToOutDir(Stream stream, string fileName, string subDir = "")
        {
            string outDir = Path.Combine(DirectoryHelper.GetRootSdkFolder(), BaseTestOutPath);
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);
            if(!string.IsNullOrEmpty(subDir))
            {
                outDir = Path.Combine(outDir, subDir);
                if (!Directory.Exists(outDir))
                    Directory.CreateDirectory(outDir);
            }
            string outPath = Path.Combine(outDir, fileName);
            using (Stream fstr = new FileStream(outPath, FileMode.Create, FileAccess.Write))
            {
                stream.Position = 0;
                stream.CopyTo(fstr);
                fstr.Flush();
            }
            return outPath;
        }

        protected static string getFileNameWithTimestamp(string fileName, string suffix="")
        {
            var time = $"at_{DateTime.Now.ToString("yyyyMMdd-hhmmss")}";
            var resultName = $"{Path.GetFileNameWithoutExtension(fileName)}_{time}{suffix}{Path.GetExtension(fileName)}";
            return resultName;
        }

        protected void checkGetMethodResponse(StreamResponse response, string outSubdir, string suffix = "")
        {
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Code == 200);
            Assert.IsNotNull(response.ContentStream);
            var fileName = getFileNameWithTimestamp(response.FileName, suffix);
            var outPath = saveResultStreamToOutDir(response.ContentStream, fileName, outSubdir);
            Assert.IsTrue(File.Exists(outPath));
        }

        protected void checkGetMethodResponseOkOrNoresult(StreamResponse response, string outSubdir, string suffix = "")
        {
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Code == 200 || response.Code == 204);
            Assert.IsNotNull(response.ContentStream);
            var fileName = getFileNameWithTimestamp(response.FileName, suffix);
            var outPath = saveResultStreamToOutDir(response.ContentStream, fileName, outSubdir);
            Assert.IsTrue(File.Exists(outPath));
        }

        static Regex re = new Regex(@"^v(\d{1,})\.(\d{1,})$");
        internal static bool UrlContainsVersion(string url)
        {
            Uri uri = new Uri(url);
            var s = uri.Segments.Last<string>();
            bool res = re.Match(s).Success;
            return res;
        }

        protected JwtToken GetAuthToken(int forceExpiresIn = -1)
        {
            string authServicePath = $"{keys.AuthServerUri}/connect/token";
            List<KeyValuePair<string, string>> authReqContent = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("grant_type", "client_credentials"),
                            new KeyValuePair<string, string>("client_id", keys.AppSid),
                            new KeyValuePair<string, string>("client_secret", keys.AppKey)
                        };

            HttpRequestMessage authReq = new HttpRequestMessage()
            {
                RequestUri = new Uri(authServicePath),
                Method = HttpMethod.Post
            };
            authReq.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            authReq.Content = new FormUrlEncodedContent(authReqContent);
            authReq.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpClient authClient = new HttpClient();
            var authResponse = authClient.SendAsync(authReq).Result;
            if (authResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = authResponse.Content.ReadAsStringAsync().Result;
                Dictionary<string, object> dict =
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                if (dict.ContainsKey("error"))
                {
                    var errDescr = dict.ContainsKey("error_description") ? dict["error_description"] : "";
                    Console.WriteLine($"Unsuccessful authorization: {errDescr}");
                    return null;
                }
                JwtToken token = new JwtToken()
                {
                    Token = dict["access_token"].ToString(),
                    IssuedOn = DateTime.UtcNow,
                    ExpiresInSeconds = (forceExpiresIn > 0) ? forceExpiresIn : Convert.ToInt32(dict["expires_in"])
                };
                return token;
            }
            return null;
        }
    }
}