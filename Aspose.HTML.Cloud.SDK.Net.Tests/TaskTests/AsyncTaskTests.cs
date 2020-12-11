using Aspose.HTML.Cloud.Sdk.Conversion;
using System;
using System.IO;
using System.Collections.Generic;
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
            api = new HtmlApi(cb => cb
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

        [Fact]
        public void AsyncConversionStatusWatching()
        {
            var lstStatus = new List<string>();

            var sourceFileBig = TestHelper.srcDir + "epub_file.epub";
            var result = api.ConvertLocalFileAsync(sourceFile, new PDFConversionOptions());

            lstStatus.Add(result.Data.Status);
            Assert.True(result.Data.Status == Conversion.Conversion.UPLOADING);

            var status = result.Data.Status;
            while (!result.IsCompleted)
            {
                Thread.Sleep(40);

                if(status != result.Data.Status)
                    lstStatus.Add(result.Data.Status);
                status = result.Data.Status;

            }
            Assert.True(result.Data.Status == Conversion.Conversion.COMPLETED);
            Assert.True(result.Data.Files.Length >= 1);
            Assert.Equal(Conversion.Conversion.UPLOADING, lstStatus[0]);
            Assert.Equal(Conversion.Conversion.PENDING, lstStatus[1]);
            Assert.Equal(Conversion.Conversion.RUNNING, lstStatus[2]);
            Assert.Equal(Conversion.Conversion.COMPLETED, lstStatus[lstStatus.Count - 1]);
        }

        [Fact]
        public void CreateTaskLongConversionWithObserver()
        {
            var lstStatus = new List<string>();

            var sourceFileBig = TestHelper.srcDir + "epub_file.epub";
            var result = api.ConvertLocalFileAsync(sourceFileBig, 
                new PDFConversionOptions(), null, 
                IO.NameCollisionOption.ReplaceExisting,
                new MyObserver(lstStatus));

            Assert.True(result.Data.Status == Conversion.Conversion.UPLOADING);
            lstStatus.Add(result.Data.Status);
            result.AsyncWaitHandle.WaitOne();
            Assert.True(result.Data.Status == Conversion.Conversion.COMPLETED);

            Assert.True(result.Data.Files.Length >= 1);
            Assert.Equal(Conversion.Conversion.UPLOADING, lstStatus[0]);
            Assert.Equal(Conversion.Conversion.COMPLETED, lstStatus[lstStatus.Count - 1]);
        }

        public void Dispose()
        {
        }

        class MyObserver : IObserver<Conversion.Conversion>
        {
            IList<string> lstStatus;

            public MyObserver(IList<string> lstStatus)
            {
                this.lstStatus = lstStatus;
            }
            public void OnCompleted()
            {
                lstStatus.Add(Conversion.Conversion.COMPLETED);
            }

            public void OnError(Exception error)
            {
                lstStatus.Add($"error: {error.Message}");
            }

            public void OnNext(Conversion.Conversion value)
            {
                lstStatus.Add(value.Status);
            }
        }

    }
}
