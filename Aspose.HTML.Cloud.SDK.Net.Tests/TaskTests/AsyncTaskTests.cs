using Aspose.HTML.Cloud.Sdk.Conversion;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests.TaskTests
{
    public class AsyncTaskTests : BaseTest, IDisposable
    {
        private readonly HttpClient client;
        private HtmlApi api;
        private string sourceFile = TestHelper.srcDir + "html_file.html";
        private string destFolder = Path.Combine(TestHelper.dstDir, "TaskTests");

        public AsyncTaskTests()
        {
            //client = this.CreateClient();
            api = new HtmlApi(cb => cb
                //.WithHttpClient(client)
                .WithAppSid(AppSid)
                .WithAppKey(AppKey)
                .WithAuthUrl(AuthServiceUrl)
                .WithBaseUrl(ApiServiceBaseUrl));
        }

        [Fact]
        public void CreateTaskLongConversion()
        {
            var result = api.ConvertLocalFileAsync(sourceFile, new PDFConversionOptions());
            Assert.True(result.Data.Status == "uploading");

            result.AsyncWaitHandle.WaitOne();
            Assert.True(result.Data.Status == "completed");

            Assert.True(result.Data.Files.Length >= 1);
        }

        public void Dispose()
        {
        }
    }
}
