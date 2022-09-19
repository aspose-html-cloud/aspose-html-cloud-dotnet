using Aspose.HTML.Cloud.Sdk.Conversion;
using System.IO;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Conversion.Results;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class UrlConversionToLocalTests  : IClassFixture<BaseTest>
    {
        private readonly string sourceUrl = "https://stallman.org/articles/anonymous-payments-thru-phones.html";
        private readonly string destFolder = Path.Combine(TestHelper.DstDir, "UrlToLocal");
        private readonly string destWithParamFolder = Path.Combine(TestHelper.DstDir, "UrlToLocalWithParam");
        private readonly BaseTest testData;

        public UrlConversionToLocalTests(BaseTest fixture)
        {
            testData = fixture;
        }

        [Theory]
        [InlineData(OutputFormats.JPEG)]
        [InlineData(OutputFormats.BMP)]
        [InlineData(OutputFormats.PNG)]
        [InlineData(OutputFormats.TIFF)]
        [InlineData(OutputFormats.GIF)]
        [InlineData(OutputFormats.PDF)]
        [InlineData(OutputFormats.XPS)]
        [InlineData(OutputFormats.DOC)]
        [InlineData(OutputFormats.MD)]
        [InlineData(OutputFormats.MHTML)]
        public async Task ConvertFromUrlFileToLocalFile(OutputFormats format)
        {
            var outputFileName = Path.Combine(destFolder, $"testFile.{format}".ToLower());

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertUrlAsync(sourceUrl, outputFileName);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Theory]
        [InlineData(OutputFormats.JPEG)]
        [InlineData(OutputFormats.BMP)]
        [InlineData(OutputFormats.PNG)]
        [InlineData(OutputFormats.TIFF)]
        [InlineData(OutputFormats.GIF)]
        public async Task ConvertFromUrlToLocalFile_Image_WithParams(OutputFormats format)
        {
            ConversionOptions options = new ImageConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{format}".ToLower());

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertUrlAsync(sourceUrl, outputFileName, options);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Fact]
        public async Task ConvertFromUrlToLocalFile_PDF_WithParams()
        {
            ConversionOptions options = new PDFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{OutputFormats.PDF}".ToLower());

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertUrlAsync(sourceUrl, outputFileName, options);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Fact]
        public async Task ConvertFromUrlToLocalFile_XPS_WithParams()
        {
            ConversionOptions options = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{OutputFormats.XPS}".ToLower());

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertUrlAsync(sourceUrl, outputFileName, options);
            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Fact]
        public async Task ConvertFromUrlToLocalFile_DOC()
        {
            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{OutputFormats.DOC}".ToLower());
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertUrlAsync(sourceUrl, outputFileName);
            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Fact]
        public async Task ConvertFromUrlToLocalFile_MD()
        {
            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{OutputFormats.MD}".ToLower());
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertUrlAsync(sourceUrl, outputFileName);
            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }
    }
}
