using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Client;

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

        [TestMethod]
        public void Test_GetHtmlConvert_Pdf_NoStorageFile()
        {
            string methodName = "GetConvertDocumentToPdf";
            string name = "testpage_99999.html";
            string folder = StorageTestDataPath;
            string storage = null;

            var exception = Assert.ThrowsException<ApiException>(() =>
            {
                var response = this.HtmlApi.GetConvertDocumentToPdf(name, 800, 1200, null, null, null, null, folder, storage);
            });
            var path = $"{folder}/{name}";
            Assert.IsTrue(exception.ErrorCode == (int)System.Net.HttpStatusCode.NotFound);
            var msg = $"Error calling {methodName}: StatusCode=404 (NotFound); Dynabic.Storage.Exceptions.HttpWebException : Requested storage file not found by path '{ path }' or storage error";
            Assert.AreEqual(msg, exception.Message);
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Jpeg_NoStorageFile()
        {
            string methodName = "GetConvertDocumentToImage";
            string name = "testpage_99999.html";
            string folder = StorageTestDataPath;
            string storage = null;
            var exception = Assert.ThrowsException<ApiException>(() =>
            {
                var response = this.HtmlApi.GetConvertDocumentToImage(
                    name, "jpeg", 800, 1200, null, null, null, null, null, folder, storage);
            });
            var path = $"{folder}/{name}";
            Assert.IsTrue(exception.ErrorCode == (int)System.Net.HttpStatusCode.NotFound);
            var msg = $"Error calling {methodName}: StatusCode=404 (NotFound); Dynabic.Storage.Exceptions.HttpWebException : Requested storage file not found by path '{ path }' or storage error";
            Assert.AreEqual(msg, exception.Message);
        }

    }
}
