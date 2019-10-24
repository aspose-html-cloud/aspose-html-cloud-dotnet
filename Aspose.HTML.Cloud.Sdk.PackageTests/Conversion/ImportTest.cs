using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;

namespace Aspose.HTML.Cloud.Sdk.Tests.Conversion
{
    [TestClass]
    public class ImportTest : BaseTestContext
    {
        private readonly string dataFolder = LocalTestDataPath;

        private readonly string testoutStorageFolder =
            Path.Combine(BaseTestContext.StorageTestoutFolder, "Conversion").Replace('\\', '/');

        [TestInitialize]
        public void TestSetUp()
        {
            string[] files = new string[]
            {
                "testpage1.md"
            };
            foreach (string fname in files)
            {
                var storagePath = Path.Combine(StorageTestDataPath, fname).Replace('\\', '/');
                if (!StorageApi.FileOrFolderExists(storagePath))
                {
                    var localPath = Path.Combine(dataFolder, fname);
                    StorageApi.UploadFile(localPath, storagePath);
                }
            }
        }

        [TestMethod]
        public void Test_GetImportMarkdownToHtml_StorageFileToResponse_1()
        {
            var name = "testpage1.md";
            string folder = StorageTestDataPath;
            string storage = null;

            var response = HtmlApi.GetImportMarkdownToHtml(name, folder, storage);
            checkGetMethodResponse(response, "Conversion", "_md_to_html");
        }

        [TestMethod]
        public void Test_PutImportMarkdownToHtml_StorageFileToStorage_1()
        {
            var name = "testpage1.md";
            string folder = StorageTestDataPath;
            string storage = null;

            string outPath = Path.Combine(testoutStorageFolder, $"{name}_put_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.html");
            var response = this.HtmlApi.PutImportMarkdownToHtml(name, outPath, folder, storage);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            Assert.IsTrue(this.StorageApi.FileOrFolderExists(outPath, storage));
        }

        [TestMethod]
        public void Test_PostImportMarkdownToHtml_LocalFileToStorage_1()
        {
            var name = "testpage1.md";
            string storage = null;
            string srcPath = Path.Combine(LocalTestDataPath, name);
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_post_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.html");

            var response = this.HtmlApi.PostImportMarkdownToHtml(srcPath, outPath, storage);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            Assert.IsTrue(this.StorageApi.FileOrFolderExists(outPath, storage));
        }

    }
}
