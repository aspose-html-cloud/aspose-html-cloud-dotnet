using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;

namespace Aspose.HTML.Cloud.Sdk.Tests.OCR
{
    [TestClass]
    public class OcrRecognizeTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath("TestData", "HTML");
        private readonly string testoutStorageFolder =
            Path.Combine(BaseTestContext.StorageTestoutFolder, "Ocr").Replace('\\', '/');

        [TestInitialize]
        public void TestSetup()
        {
            if (!StorageApi.FileOrFolderExists(testoutStorageFolder))
            {
                StorageApi.CreateFolder(testoutStorageFolder);
            }
            string[] files = new string[] {
                "ocr_test_1.png", "ocr_test_2.png", "1168_016.3B.jpg", 
            };
            foreach(var fname in files)
            {
                string path = Path.Combine(StorageTestDataPath, fname).Replace('\\', '/');
                if (StorageApi.FileOrFolderExists(path))
                {
                    string localPath = Path.Combine(LocalTestDataPath, fname);
                    StorageApi.UploadFile(localPath, path);
                }
            }
        }

        [TestMethod]
        public void Test_RecognizeAndImport_Get_1()
        {
            var name = "ocr_test_1.png";
            string folder = StorageTestDataPath;
  
            var response = HtmlApi.GetRecognizeAndImportToHtml(name, "en", folder);
            checkGetMethodResponse(response, "Ocr", "_recognize");
        }

        [TestMethod]
        public void Test_RecognizeAndImport_Get_2()
        {
            var name = "1168_016.3B.jpg";
            string folder = StorageTestDataPath;

            var response = HtmlApi.GetRecognizeAndImportToHtml(name, "en", folder);
            checkGetMethodResponse(response, "Ocr", "_recognize");
        }


        [TestMethod]
        public void Test_RecognizeAndTranslate_Get_1()
        {
            var name = "ocr_test_1.png";
            string folder = StorageTestDataPath;

            var response = HtmlApi.GetRecognizeAndTranslateToHtml(name, "en", "de", folder);
            checkGetMethodResponse(response, "Ocr", "_en_de");
        }

        [TestMethod]
        public void Test_RecognizeAndTranslate_Get_2()
        {
            var name = "1168_016.3B.jpg";
            string folder = StorageTestDataPath;

            var response = HtmlApi.GetRecognizeAndTranslateToHtml(name, "en", "de", folder);
            checkGetMethodResponse(response, "Ocr", "_en_de");
        }

    }
}
