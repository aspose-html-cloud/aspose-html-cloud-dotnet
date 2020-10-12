using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests.TaskTests
{
    public class CreateDeleteTasks
        : IClassFixture<BaseTest>, IDisposable
    {
        private readonly HttpClient client;
        private HtmlApi api;
        private string sourceFile = TestHelper.srcDir + "html_file.html";
        private string destFolder = Path.Combine(TestHelper.dstDir, "TaskTests");

        public CreateDeleteTasks(BaseTest fixture)
        {
            client = fixture.CreateClient();
            api = new HtmlApi(cb => cb
                .WithHttpClient(client)
                .WithAppSid(fixture.AppSid)
                .WithAppKey(fixture.AppKey)
                .WithAuthUrl(fixture.AuthServiceUrl)
                .WithBaseUrl(fixture.ApiServiceBaseUrl));
        }

        [Fact]
        public void CreateTaskPDFConversion()
        {
            using (var api = new HtmlApi(_
               => _.WithHttpClient(client)))
            {
                var result = api.ConvertLocalFileAsync(sourceFile, new PDFConversionOptions());
                
                result.AsyncWaitHandle.WaitOne();

                var data = result.Data;
                Assert.NotEmpty(data.Files);

                var id = result.Data.Id;

            }
        }

        public void Dispose()
        {
        }
    }
}
