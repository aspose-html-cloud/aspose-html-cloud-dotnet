using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.ApiParameters;
using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.Tests.TaskTests
{
    public class AsyncTaskTests 
    {
        string CliendId { get; set; }
        string ClientSecret { get; set; }

        private string sourceFile = TestHelper.SrcDir + "html_file.html";
        private string destFolder = Path.Combine(TestHelper.DstDir, "TaskTests");

        public AsyncTaskTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<HtmlConversionLocalToLocalTests>().Build();

            CliendId = config["AsposeUserCredentials:ClientId"];
            ClientSecret = config["AsposeUserCredentials:ClientSecret"];

            if (Directory.GetCurrentDirectory().IndexOf(@"\bin") >= 0)
                Directory.SetCurrentDirectory(@"..\..\..");
        }

        [Fact]
        public void CreateTaskLongConversion()
        {
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)              
                 .WithClientSecret(ClientSecret)))
            {
                var result = api.ConvertLocalFileAsync(@"Input\html_file.html", new PDFConversionOptions());
                Assert.True(result.Data.Status == "uploading");

                result.AsyncWaitHandle.WaitOne();
                Assert.True(result.Data.Status == "completed");
                Assert.True(result.Data.Files.Any());
            }


        }

        [Fact]
        public void AsyncConversionStatusWatching()
        {
            var lstStatus = new List<string>();
            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                var result = api.ConvertLocalFileAsync(@"Input\epub_file.epub", new PDFConversionOptions());
                lstStatus.Add(result.Data.Status);
                Assert.True(result.Data.Status == Conversion.Conversion.UPLOADING);

                var status = result.Data.Status;
                while (!result.IsCompleted)
                {
                    Thread.Sleep(20);

                    if (status != result.Data.Status)
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



        }

        [Fact]
        public void CreateTaskLongConversionWithObserver()
        {
            var lstStatus = new List<string>();

            using (var api = new HtmlApi(cb => cb
                 .WithClientId(CliendId)
                 .WithClientSecret(ClientSecret)))
            {
                var result = api.ConvertLocalFileAsync(@"Input\epub_file.epub",
                    new PDFConversionOptions(),
                    new RemoteDirectoryParameter("/TestResult/Async"), null,
                    IO.NameCollisionOption.ReplaceExisting,
                    new MyObserver(lstStatus));

                Assert.True(result.Data.Status == Conversion.Conversion.UPLOADING);
                lstStatus.Add(result.Data.Status);
                result.AsyncWaitHandle.WaitOne();
                Assert.Equal(Conversion.Conversion.UPLOADING, lstStatus[0]);
                Assert.Equal(Conversion.Conversion.COMPLETED, lstStatus[lstStatus.Count - 1]);


                Assert.True(result.Data.Status == Conversion.Conversion.COMPLETED
                    || result.Data.Status == Conversion.Conversion.FAULTED);
                if (result.Data.Status == Conversion.Conversion.COMPLETED)
                    Assert.True(result.Data.Files.Length >= 1);
                else if (result.Data.Status == Conversion.Conversion.FAULTED)
                    Assert.Null(result.Data.Files);
            }
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
