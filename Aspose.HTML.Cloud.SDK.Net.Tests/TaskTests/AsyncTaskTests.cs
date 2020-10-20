using Aspose.HTML.Cloud.Sdk.Conversion;
using System;
using System.IO;
using System.Net.Http;
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
        public void CreateTaskLongConversionCancel()
        {
            var result = api.ConvertLocalFileAsync(sourceFile, new PDFConversionOptions());
            var data = result.Data;
            var id = result.Data.Id;
            bool res = api.DeleteTask(id);
            Assert.True(res);

            var cancel = api.GetConversion(id);
            Assert.True(cancel.Data.Status == "canceled");
        }

        public void Dispose()
        {
        }
    }
}
