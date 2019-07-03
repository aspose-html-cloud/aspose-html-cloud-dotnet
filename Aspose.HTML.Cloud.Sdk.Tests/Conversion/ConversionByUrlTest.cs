using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;

namespace Aspose.HTML.Cloud.Sdk.Tests.Conversion
{
    [TestClass]
    [DeploymentItem("TestData", "TestData")]
    public class ConversionByUrlTest : BaseTestContext
    {
        [TestMethod]
        public void Test_GetHtmlConvert_Pdf_UrlToStream()
        {
            string sourceUrl = @"https://stallman.org/articles/anonymous-payments-thru-phones.html";

            var response = this.HtmlApi.GetConvertDocumentToPdfByUrl(sourceUrl, 800, 1200);
            checkGetMethodResponse(response, "Conversion");
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Xps_UrlToStream()
        {
            string sourceUrl = @"https://stallman.org/articles/anonymous-payments-thru-phones.html";

            var response = this.HtmlApi.GetConvertDocumentToXpsByUrl(sourceUrl, 800, 1200);
            checkGetMethodResponse(response, "Conversion");
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Jpeg_UrlToStream()
        {
            string sourceUrl = @"https://stallman.org/articles/anonymous-payments-thru-phones.html";

            var response = this.HtmlApi.GetConvertDocumentToImageByUrl(
                sourceUrl, "jpeg", 800, 1200);
            checkGetMethodResponse(response, "Conversion");
        }


        [TestMethod]
        public void Test_GetHtmlConvert_MHTML_UrlToStream()
        {
            string sourceUrl = @"https://stallman.org/articles/anonymous-payments-thru-phones.html";

            var response = this.HtmlApi.GetConvertDocumentToMHTMLByUrl(sourceUrl);
            checkGetMethodResponse(response, "Conversion");
        }
    }
}
