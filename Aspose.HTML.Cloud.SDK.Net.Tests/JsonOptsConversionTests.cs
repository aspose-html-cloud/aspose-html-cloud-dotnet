using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class JsonOptsConversionTests : IClassFixture<BaseTest>
    {
        private readonly HttpClient client;

        public JsonOptsConversionTests(BaseTest fixture)
        {
            client = fixture.CreateClient();
        }

        [Fact]
        public void Option_Json_Transform()
        {
            // All fields in the ImageOptions
            ConversionOptions optsImg = new JPEGConversionOptions()
                .setHeight(100)
                .setWidth(100)
                .setLeftMargin(10)
                .setRightMargin(10)
                .setTopMargin(10)
                .setBottomMargin(10)
                .setResolution(150);

            JObject result = (JObject)JToken.FromObject(optsImg);
            JObject expected = (JObject)JToken.FromObject( new {
                width = 100,
                height = 100,
                leftMargin = 10,
                rightMargin = 10,
                topMargin = 10,
                bottomMargin = 10,
                resolution = 150
            });

            Assert.True(JToken.DeepEquals(result, expected));

            // Test nullable values
            optsImg = new PNGConversionOptions().setHeight(100);

            string strResult = optsImg.toJson();
            string strExpected = "{\"height\":100}";
            Assert.True(strResult.Equals(strExpected));

            optsImg = new PNGConversionOptions().setResolution(300);

            result = (JObject)JToken.FromObject(optsImg);
            expected = (JObject)JToken.FromObject(
                new
                {
                    resolution = 300
                });

            // Null value is present
            Assert.False(JToken.DeepEquals(result, expected));

            // All fields in the PdfOptions
            ConversionOptions optsPDF = new PDFConversionOptions()
                .setHeight(100)
                .setWidth(100)
                .setLeftMargin(10)
                .setRightMargin(10)
                .setTopMargin(10)
                .setBottomMargin(10)
                .setQuality(95);

            result = (JObject)JToken.FromObject(optsPDF);
            expected = (JObject)JToken.FromObject(
                new
                {
                    width = 100,
                    height = 100,
                    leftMargin = 10,
                    rightMargin = 10,
                    topMargin = 10,
                    bottomMargin = 10,
                    JpegQuality =95
                });

            Assert.True(JToken.DeepEquals(result, expected));

            // Test nullable values
            optsPDF = new PDFConversionOptions().setHeight(100);

            strResult = optsPDF.toJson();
            strExpected = "{\"height\":100}";
            Assert.True(strResult.Equals(strExpected));

            optsPDF = new PDFConversionOptions().setHeight(300);

            result = (JObject)JToken.FromObject(optsPDF);
            expected = (JObject)JToken.FromObject(new
            {
                height = 300
            });

            // Null value is present
            Assert.False(JToken.DeepEquals(result, expected));

            // All fields in the XpsOptions
            ConversionOptions optsXPS = new XPSConversionOptions()
                .setHeight(100)
                .setWidth(100)
                .setLeftMargin(10)
                .setRightMargin(10)
                .setTopMargin(10)
                .setBottomMargin(10);

            result = (JObject)JToken.FromObject(optsXPS);
            expected = (JObject)JToken.FromObject(
                new
                {
                    width = 100,
                    height = 100,
                    leftMargin = 10,
                    rightMargin = 10,
                    topMargin = 10,
                    bottomMargin = 10
                });

            Assert.True(JToken.DeepEquals(result, expected));

            // Test nullable values
            optsXPS = new XPSConversionOptions().setHeight(100);

            strResult = optsXPS.toJson();
            strExpected = "{\"height\":100}";
            Assert.True(strResult.Equals(strExpected));

            optsXPS = new XPSConversionOptions().setHeight(300);

            result = (JObject)JToken.FromObject(optsXPS);
            expected = (JObject)JToken.FromObject(new
            {
                height = 300
            });

            // Null value is present
            Assert.False(JToken.DeepEquals(result, expected));
        }
    }
}
