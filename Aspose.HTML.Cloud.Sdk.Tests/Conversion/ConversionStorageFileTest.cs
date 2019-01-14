using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;
using Aspose.Html.Cloud.Sdk.Api.Model;


namespace Aspose.HTML.Cloud.Sdk.Tests.Conversion
{
    [TestClass]
    public class ConversionStorageFileTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath(BaseTestDataPath, "HTML");

        [TestMethod]
        public void Test_GetHtmlConvert_Pdf_StorageToStream()
        {
            string name = "testpage1.html";
            string folder = "14/HTML";

            var response = this.ConversionApi.GetConvertDocumentToPdf(name, 800, 1200, null, null, null, null, folder);
            checkGetMethodResponse(response, "Conversion");
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Jpeg_StorageToStream()
        {
            string name = "testpage1.html";
            string folder = "14/HTML";

            var response = this.ConversionApi.GetConvertDocumentToImage(name, "jpeg", 800, 1200, null, null, null, null, null, null, folder);
            checkGetMethodResponse(response, "Conversion");
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Markdown_StorageToStream()
        {
            string name = "testpage1.html";
            string folder = "14/HTML";

            var response = this.ConversionApi.GetConvertDocumentToMarkdown(name, false, folder);
            checkGetMethodResponse(response, "Conversion");
        }

        [TestMethod]
        public void Test_GetHtmlConvert_MHTML_StorageToStream()
        {
            string name = "testpage1.html";
            string folder = "14/HTML";

            var response = this.ConversionApi.GetConvertDocumentToMHTML(name, 3, ResourceHandling.Embed, UrlRestriction.SameHost, ResourceHandling.Save, folder);
            checkGetMethodResponse(response, "Conversion");
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Markdown_StorageToStorage()
        {
            string name = "testpage1.html";
            string folder = "14/HTML";
            string outPath = $"Testout/{Path.GetFileNameWithoutExtension(name)}_converted_at_{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.md";

            var response = this.ConversionApi.PutConvertDocumentToMarkdown(name, outPath, false, folder);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
        }

        [TestMethod]
        public void Test_GetHtmlConvert_MHTML_StorageToStorage()
        {
            string name = "testpage1.html";
            string folder = "14/HTML";
            string outPath = $"Testout/{Path.GetFileNameWithoutExtension(name)}_converted_at_{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.mht";

            var response = this.ConversionApi.PutConvertDocumentToMHTML(name, outPath, 3, ResourceHandling.Embed, UrlRestriction.SameHost, ResourceHandling.Save, folder);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
        }

    }
}
