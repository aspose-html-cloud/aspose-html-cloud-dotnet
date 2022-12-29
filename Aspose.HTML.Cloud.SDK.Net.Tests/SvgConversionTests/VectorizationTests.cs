using Aspose.HTML.Cloud.Sdk.Conversion;
using System.IO;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Conversion.Results;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class VectorizationTests  : IClassFixture<BaseTest>
    {
        private readonly string sourceFile = Path.Combine(TestHelper.SrcDir, "mikki.jpeg");
        private readonly string destFolder = Path.Combine(TestHelper.DstDir, "LocalFileToLocal");
        private readonly BaseTest testData;

        public VectorizationTests(BaseTest fixture)
        {
            testData = fixture;
        }

        [Fact]
        public async Task VectorizeFromLocalFileToLocalFile()
        {
            var outputFileName = Path.Combine(destFolder, "testFile.svg".ToLower());

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).VectorizationApi;
            var result = await api.VectorizeAsync(sourceFile, outputFileName);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Fact]
        public async Task VectorizeWithOptionsFromLocalFileToLocalFile()
        {
            var outputFileName = Path.Combine(destFolder, "testFile.svg".ToLower());

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).VectorizationApi;
            var options = new VectorizationOptions
            {
                ErrorThreshold = 30,
                MaxIterations = 30,
                ColorLimit = 25,
                LineWidth = 1
            };
            var result = await api.VectorizeAsync(sourceFile, outputFileName, options);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Fact]
        public async Task VectorizeUrlToLocalFile()
        {
            var sourceUrl = "https://static.wikia.nocookie.net/disney/images/b/bf/Mickey_Mouse_Disney_1.png";
            var outputFileName = Path.Combine(destFolder, "testFile.svg".ToLower());

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).VectorizationApi;
            var result = await api.VectorizeUrlAsync(sourceUrl, outputFileName);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }
    }
}
