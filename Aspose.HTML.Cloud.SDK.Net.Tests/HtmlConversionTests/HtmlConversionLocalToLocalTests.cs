using System;
using System.Collections.Generic;
using Aspose.HTML.Cloud.Sdk.Conversion;
using System.IO;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Conversion.Results;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class HtmlConversionLocalToLocalTests  : IClassFixture<BaseTest>
    {
        private readonly string sourceFile = Path.Combine(TestHelper.SrcDir, "html_file.html");
        private readonly string destFolder = Path.Combine(TestHelper.DstDir, "LocalFileToLocal");
        private readonly string destWithParamFolder = Path.Combine(TestHelper.DstDir, "LocalFileToLocalWithParam");
        private readonly BaseTest testData;

        public HtmlConversionLocalToLocalTests(BaseTest fixture)
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
        public async Task ConvertFromLocalFileToLocalFile(OutputFormats format)
        {
            var outputFileName = Path.Combine(destFolder, $"testFile.{format}".ToLower());

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(sourceFile, outputFileName);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Theory]
        [InlineData(OutputFormats.JPEG)]
        [InlineData(OutputFormats.BMP)]
        [InlineData(OutputFormats.PNG)]
        [InlineData(OutputFormats.GIF)]
        public async Task ConvertFromLocalFileToLocalFileWithZipOutput(OutputFormats format)
        {
            var options = new ImageConversionOptions()
                .SetHeight(300)
                .SetWidth(1000)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetBottomMargin(10)
                .SetTopMargin(10);
            
            var inputFile = Path.Combine(TestHelper.SrcDir, "html_file_long.html");
            var outputFileName = $"testFile.{format}".ToLower();
            var outputFilePath = Path.Combine(destFolder, outputFileName);

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(inputFile, outputFilePath, options);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
            Assert.True(result.OutputFile.IndexOf(outputFileName + ".zip", StringComparison.OrdinalIgnoreCase) > -1);
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
        public async Task ConvertFromLocalFileToLocalFile_WithResources(OutputFormats format)
        {
            var outputFileName = Path.Combine(destFolder, $"testFile.{format}".ToLower());
            var inputFile = Path.Combine(TestHelper.SrcDir, "html_file_with_resources.html");
            var resource = Path.Combine(TestHelper.SrcDir, "mikki.jpg");
            var resources = new List<string> { resource };

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(inputFile, resources, outputFileName);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Theory]
        [InlineData(OutputFormats.JPEG)]
        [InlineData(OutputFormats.BMP)]
        [InlineData(OutputFormats.PNG)]
        [InlineData(OutputFormats.TIFF)]
        public async Task ConvertFromLocalFileToLocalFile_WithResources_BigImage(OutputFormats format)
        {
            var outputFileName = Path.Combine(destFolder, $"testFile.{format}".ToLower());
            var inputFile = Path.Combine(TestHelper.SrcDir, "html_file_with_resources_big.html");
            var resource = Path.Combine(TestHelper.SrcDir, "mikki_big.jpg");
            var resources = new List<string> { resource };

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(inputFile, resources, outputFileName);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
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
        public async Task ConvertFromLocalFileToLocalFile_WithResourcesFolder(OutputFormats format)
        {
            var outputFileName = Path.Combine(destFolder, $"testFile.{format}".ToLower());
            var inputFile = Path.Combine(TestHelper.SrcDir, "html_file_with_resources_folder.html");
            var resource = Path.Combine(TestHelper.SrcDir, "Resources");

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(inputFile, resource, outputFileName);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Theory]
        [InlineData(OutputFormats.JPEG)]
        [InlineData(OutputFormats.BMP)]
        [InlineData(OutputFormats.PNG)]
        [InlineData(OutputFormats.TIFF)]
        [InlineData(OutputFormats.GIF)]
        public async Task ConvertFromLocalFileToLocalFile_Image_WithParams(OutputFormats format)
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
            var result = await api.ConvertAsync(sourceFile, outputFileName, options);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Fact]
        public async Task ConvertFromLocalFileToLocalFile_PDF_WithParams()
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
            var result = await api.ConvertAsync(sourceFile, outputFileName, options);

            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
            Assert.True(File.Exists(outputFileName));
        }

        [Fact]
        public async Task ConvertFromLocalFileToLocalFile_XPS_WithParams()
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
            var result = await api.ConvertAsync(sourceFile, outputFileName, options);
            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }

        [Fact]
        public async Task ConvertFromLocalFileToLocalFile_MD()
        {

            var outputFileName = Path.Combine(destWithParamFolder, $"testFile.{OutputFormats.MD}".ToLower());

            var api = new HtmlApi(testData.ClientId, testData.ClientSecret).ConvertApi;
            var result = await api.ConvertAsync(sourceFile, outputFileName);
            Assert.True(result.Status == ConvertResultStatus.Completed);
            Assert.True(!string.IsNullOrWhiteSpace(result.OutputFile));
        }
    }
}
