using Aspose.HTML.Cloud.Sdk.Conversion;
using Newtonsoft.Json.Linq;
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
                .SetHeight(100)
                .SetWidth(100)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetTopMargin(10)
                .SetBottomMargin(10)
                .SetResolution(150);

            JObject result = (JObject)JToken.FromObject(optsImg);
            JObject expected = (JObject)JToken.FromObject( new {
                Width = 100,
                Height = 100,
                LeftMargin = 10,
                RightMargin = 10,
                TopMargin = 10,
                BottomMargin = 10,
                Resolution = 150
            });

            Assert.True(JToken.DeepEquals(result, expected));

            // Test nullable values
            optsImg = new PNGConversionOptions().SetHeight(100);

            string strResult = optsImg.ToJson();
            string strExpected = "{\"height\":100}";
            Assert.True(strResult.Equals(strExpected));

            optsImg = new PNGConversionOptions().SetResolution(300);

            result = (JObject)JToken.FromObject(optsImg);
            expected = (JObject)JToken.FromObject(
                new
                {
                    Resolution = 300
                });

            // Null value is present
            Assert.False(JToken.DeepEquals(result, expected));

            // All fields in the PdfOptions
            ConversionOptions optsPDF = new PDFConversionOptions()
                .SetHeight(100)
                .SetWidth(100)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetTopMargin(10)
                .SetBottomMargin(10)
                .SetQuality(95);

            result = (JObject)JToken.FromObject(optsPDF);
            expected = (JObject)JToken.FromObject(
                new
                {
                    Width = 100,
                    Height = 100,
                    LeftMargin = 10,
                    RightMargin = 10,
                    TopMargin = 10,
                    BottomMargin = 10,
                    JpegQuality =95
                });

            Assert.True(JToken.DeepEquals(result, expected));

            // Test nullable values
            optsPDF = new PDFConversionOptions().SetHeight(100);

            strResult = optsPDF.ToJson();
            strExpected = "{\"height\":100}";
            Assert.True(strResult.Equals(strExpected));

            optsPDF = new PDFConversionOptions().SetHeight(300);

            result = (JObject)JToken.FromObject(optsPDF);
            expected = (JObject)JToken.FromObject(new
            {
                height = 300
            });

            // Null value is present
            Assert.False(JToken.DeepEquals(result, expected));

            // All fields in the XpsOptions
            ConversionOptions optsXPS = new XPSConversionOptions()
                .SetHeight(100)
                .SetWidth(100)
                .SetLeftMargin(10)
                .SetRightMargin(10)
                .SetTopMargin(10)
                .SetBottomMargin(10);

            result = (JObject)JToken.FromObject(optsXPS);
            expected = (JObject)JToken.FromObject(
                new
                {
                    Width = 100,
                    Height = 100,
                    LeftMargin = 10,
                    RightMargin = 10,
                    TopMargin = 10,
                    BottomMargin = 10
                });

            Assert.True(JToken.DeepEquals(result, expected));

            // Test nullable values
            optsXPS = new XPSConversionOptions().SetHeight(100);

            strResult = optsXPS.ToJson();
            strExpected = "{\"height\":100}";
            Assert.True(strResult.Equals(strExpected));

            optsXPS = new XPSConversionOptions().SetHeight(300);

            result = (JObject)JToken.FromObject(optsXPS);
            expected = (JObject)JToken.FromObject(new
            {
                Height = 300
            });

            // Null value is present
            Assert.False(JToken.DeepEquals(result, expected));
        }
    }
}
