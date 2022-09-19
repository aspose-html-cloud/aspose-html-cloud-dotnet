using Aspose.HTML.Cloud.Sdk.Conversion;
using System.IO;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Conversion.Results;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class HtmlConversionStorageToStorageTests : IClassFixture<BaseTest>
    {
        private readonly string sourceFile = "/html_file.html";
        private readonly string destFolder = "StorageFileToStorage";
        private readonly string destWithParamFolder = "StorageFileToStorageWithParam";
        private readonly BaseTest testData;

        public HtmlConversionStorageToStorageTests(BaseTest fixture)
        {
            testData = fixture;
            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).StorageApi;
            var file = api.UploadFileAsync(Path.Combine(TestHelper.SrcDir, "html_file.html"), "/html_file.html")
                .Result;
            var exist = api.FileExistsAsync(file.Path).Result;
            Assert.True(exist);
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
        public async Task ConvertFromStorageFileToStorageFile(OutputFormats format)
        {
            var outputFileName = $"/{destFolder}/testFile.{format}";

            var builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .ToStorageFile(outputFileName);

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(builder);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(((ConvertResultFile)result).OutputFile));
        }

        [Theory]
        [InlineData(OutputFormats.JPEG)]
        [InlineData(OutputFormats.BMP)]
        [InlineData(OutputFormats.PNG)]
        [InlineData(OutputFormats.TIFF)]
        [InlineData(OutputFormats.GIF)]
        public async Task ConvertFromStorageFileToStorageFile_Image_WithParams(OutputFormats format)
        {
            ConversionOptions options = new ImageConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{format}".ToLower());

            var builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .ToStorageFile(outputFileName)
                .UseOptions(options);

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(builder);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(((ConvertResultFile)result).OutputFile));
        }

        [Fact]
        public async Task ConvertFromStorageFileToStorageFile_PDF_WithParams()
        {
            ConversionOptions options = new PDFConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{OutputFormats.PDF}".ToLower());

            var builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .ToStorageFile(outputFileName)
                .UseOptions(options);

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(builder);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(((ConvertResultFile)result).OutputFile));
        }

        [Fact]
        public async Task ConvertFromStorageFileToStorageFile_XPS_WithParams()
        {
            ConversionOptions options = new XPSConversionOptions()
                .SetHeight(800)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);

            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{OutputFormats.XPS}".ToLower());

            var builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .ToStorageFile(outputFileName)
                .UseOptions(options);

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(builder);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(((ConvertResultFile)result).OutputFile));
        }

        [Fact]
        public async Task ConvertFromStorageFileToStorageFile_DOC()
        {
            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{OutputFormats.DOC}".ToLower());

            var builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .ToStorageFile(outputFileName);

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(builder);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(((ConvertResultFile)result).OutputFile));
        }

        [Fact]
        public async Task ConvertFromStorageFileToStorageFile_MD()
        {
            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{OutputFormats.MD}".ToLower());

            var builder = new ConverterBuilder()
                .FromStorageFile(sourceFile)
                .ToStorageFile(outputFileName);

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(builder);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(((ConvertResultFile)result).OutputFile));
        }
    }
}
