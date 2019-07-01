using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;


namespace Aspose.HTML.Cloud.Sdk.Tests.Summarization
{
    [TestClass]
    public class DetectKeywordsTest : BaseTestContext
    {
        [TestInitialize]
        public void TestSetup()
        {
            string path = Path.Combine(StorageTestDataPath, "testpage1.html").Replace('\\', '/');
            if (StorageApi.FileOrFolderExists(path))
            {
                string localPath = Path.Combine(LocalTestDataPath, "testpage1.html");
                StorageApi.UploadFile(localPath, path);
            }
        }

        [TestMethod]
        public void Test_GetHtmlDetectKeywords_1()
        {
            string name = "testpage1.html";
            string folder = "HtmlTestTranslate";

            var response = HtmlApi.GetDetectHtmlKeywords(name, folder, null);
            checkGetMethodResponse(response, "Keywords");
        }

    }
}
