using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Aspose.Html.Cloud.Sdk.Api.Model;


namespace Aspose.HTML.Cloud.Sdk.Tests.Conversion
{
    [TestClass]
    public class ConversionStorageFileTest : BaseTestContext
    {
        private readonly string dataFolder = BaseTestContext.LocalTestDataPath;

        [TestInitialize]
        public void TestSetup()
        {
            string path = Path.Combine(StorageTestDataPath, "testpage1.html").Replace('\\', '/');
            if(StorageApi.FileOrFolderExists(path))
            {
                string localPath = Path.Combine(LocalTestDataPath, "testpage1.html");
                StorageApi.UploadFile(localPath, path);
            }
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Pdf_StorageToStream()
        {
            string name = "testpage1.html";
            string folder = StorageTestDataPath;
            string storage = null;

            var response = this.HtmlApi.GetConvertDocumentToPdf(name, 800, 1200, null, null, null, null, folder, storage);
            checkGetMethodResponse(response, "Conversion");
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Doc_StorageToStream()
        {
            string name = "testpage1.html";
            string folder = StorageTestDataPath;
            string storage = null;

            var response = this.HtmlApi.GetConvertDocumentToDoc(name, 800, 1200, null, null, null, null, folder, storage);
            checkGetMethodResponse(response, "Conversion");
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Jpeg_StorageToStream()
        {
            string name = "testpage1.html";
            string folder = StorageTestDataPath;
            string storage = null;

            var response = this.HtmlApi.GetConvertDocumentToImage(name, "jpeg", 800, 1200, null, null, null, null, null, folder, storage);
            checkGetMethodResponse(response, "Conversion");
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Markdown_StorageToStream()
        {
            string name = "testpage1.html";
            string folder = StorageTestDataPath;
            string storage = null;

            var response = this.HtmlApi.GetConvertDocumentToMarkdown(name, false, folder, storage);
            checkGetMethodResponse(response, "Conversion");
        }


    }
}
