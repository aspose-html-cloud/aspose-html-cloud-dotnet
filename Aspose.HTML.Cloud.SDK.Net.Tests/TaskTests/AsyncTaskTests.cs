using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Conversion.Results;
using Xunit;    

namespace Aspose.HTML.Cloud.Sdk.Tests.TaskTests
{
    public class AsyncTaskTests : IClassFixture<BaseTest>
    {

        private readonly string sourceFile = Path.Combine(TestHelper.SrcDir, "html_file.html");
        private readonly string destFolder = Path.Combine(TestHelper.DstDir, "LocalFileToLocal");
        private readonly BaseTest testData;

        public AsyncTaskTests(BaseTest fixture)
        {
            testData = fixture;
        }

        [Fact]
        public async Task CreateTaskLongConversion()
        {
            var outputFileName = Path.Combine(destFolder, "testFile.pdf".ToLower());

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var observer = new TestObserver();
            var result = await api.ConvertAsync(sourceFile, outputFileName, observer: observer);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));

            Assert.True(observer.UploadingStatusWasCalled);
            Assert.True(observer.RunningWasCalled);
            Assert.False(observer.OnErrorWasCalled);
            Assert.True(observer.OnCompleteWasCalled);
        }



        private class TestObserver : IObserver<ConvertResult>
        {
            public bool UploadingStatusWasCalled { get; set; }
            public bool PendingStatusWasCalled { get; set; }
            public bool RunningWasCalled { get; set; }
            public bool OnErrorWasCalled { get; set; }
            public bool OnCompleteWasCalled { get; set; }

            public void OnCompleted()
            {
                OnCompleteWasCalled = true;
            }

            public void OnError(Exception error)
            {
                OnErrorWasCalled = true;
            }

            public void OnNext(ConvertResult value)
            {
                switch (value.Status)
                {
                    case ConvertResultStatus.Uploading:
                        UploadingStatusWasCalled = true;
                        break;
                    case ConvertResultStatus.Pending:
                        PendingStatusWasCalled = true;
                        break;
                    case ConvertResultStatus.Running:
                        RunningWasCalled = true;
                        break;
                    case ConvertResultStatus.Completed:
                        break;
                    case ConvertResultStatus.Failed:
                        break;
                    case ConvertResultStatus.Canceled:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

    }
}
