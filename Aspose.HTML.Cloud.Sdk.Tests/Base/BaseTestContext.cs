// // --------------------------------------------------------------------------------------------------------------------
// // <copyright company="Aspose" file="BaseTestContext.cs">
// //   Copyright (c) 2018 Aspose.HTML for Cloud
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
    using System.IO;
    using Aspose.Storage.Cloud.Sdk.Api;
    //using Aspose.Storage.Cloud.Sdk;
    using Aspose.Html.Cloud.Sdk.Api;
    using Aspose.Html.Cloud.Sdk.Client;
    using Newtonsoft.Json;

    /// <summary>
    /// Base class for all tests
    /// </summary>
    public abstract class BaseTestContext
    {
        protected const string DefBaseProductUri = @"http://aspose-qa.aspose.cloud";
        //protected const string BaseProductUri = @"http://sikorsky-js3.dynabic.com:9083";

        private Keys keys;

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

            var configuration = new Configuration { ApiBaseUrl = this.keys.BaseProductUri, AppKey = this.keys.AppKey, AppSid = this.keys.AppSid };
            this.ConversionApi = new ConversionApi(
                configuration.AppKey, configuration.AppSid, configuration.ApiBaseUrl + "/v1.1");
            this.DocumentApi = new DocumentApi(
                configuration.AppKey, configuration.AppSid, configuration.ApiBaseUrl + "/v1.1");
            this.TranslationApi = new TranslationApi(
                configuration.AppKey, configuration.AppSid, configuration.ApiBaseUrl + "/v1.1");
            this.OcrApi = new OcrApi(
                configuration.AppKey, configuration.AppSid, configuration.ApiBaseUrl + "/v1.1");
            this.SummarizationApi = new SummarizationApi(
                configuration.AppKey, configuration.AppSid, configuration.ApiBaseUrl + "/v1.1");

            Aspose.Storage.Cloud.Sdk.Configuration storageConf = new Storage.Cloud.Sdk.Configuration()
            {
                ApiBaseUrl = configuration.ApiBaseUrl, // + "/v1.1",
                AppKey = configuration.AppKey,
                AppSid = configuration.AppSid
            };
            this.StorageApi = new StorageApi(storageConf);
        }

        /// <summary>
        /// Base path to test data        
        /// </summary>
        protected static string BaseTestDataPath
        {
            get
            {
                //return "Temp/SdkTests/TestData";
                return "TestData";
            }
        }

        /// <summary>
        /// Base path to output data
        /// </summary>
        protected static string BaseTestOutPath
        {
            get
            {
                return "TestOut";
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
        protected ConversionApi ConversionApi { get; set; }
        protected DocumentApi DocumentApi { get; set; }
        protected TranslationApi TranslationApi { get; set; }
        protected OcrApi OcrApi { get; set; }
        protected SummarizationApi SummarizationApi { get; set; }

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

        private class Keys
        {
            [JsonProperty(PropertyName = "AppSid")]
            public string AppSid { get; set; }
            [JsonProperty(PropertyName = "AppKey")]
            public string AppKey { get; set; }
            [JsonProperty(PropertyName = "basePath")]
            public string BaseProductUri { get; set; }
            //[JsonProperty(PropertyName = "authPath")]
            //public string AuthServerPath { get; set; }
        }
    }
}