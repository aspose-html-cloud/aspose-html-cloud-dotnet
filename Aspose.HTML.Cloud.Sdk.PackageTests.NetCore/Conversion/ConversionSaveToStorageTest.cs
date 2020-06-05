using System;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;


namespace Aspose.HTML.Cloud.Sdk.Tests.Conversion
{
    [TestClass]
    public class ConversionSaveToStorageTest : BaseTestContext
    {
        private readonly string testoutStorageFolder = 
            Path.Combine(BaseTestContext.StorageTestoutFolder, "Conversion").Replace('\\', '/');
        
        [TestInitialize]
        public void TestSetup()
        {
            if(!StorageApi.FileOrFolderExists(testoutStorageFolder))
            {
                StorageApi.CreateFolder(testoutStorageFolder);
            }
            string path = Path.Combine(StorageTestDataPath, "testpage1.html").Replace('\\', '/');
            if (StorageApi.FileOrFolderExists(path))
            {
                string localPath = Path.Combine(LocalTestDataPath, "testpage1.html");
                StorageApi.UploadFile(localPath, path);
            }
        }

        [TestMethod]
        public void Test_PutHtmlConvert_Pdf_StorageDocToStorage()
        {
            string name = "testpage1.html";
            string folder = StorageTestDataPath;
            string storage = null;

            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.pdf");
            var response = this.HtmlApi.PutConvertDocumentToPdf(name, outPath, null, null, null, null, null, null, folder);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            Assert.IsTrue(this.StorageApi.FileOrFolderExists(outPath, storage));
         }

        [TestMethod]
        public void Test_PostHtmlConvert_Pdf_LocalFileToStorage()
        {
            string name = "testpage1.html";
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.pdf");
            string srcPath = Path.Combine(LocalTestDataPath, name);
            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToPdf(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
            }
            Assert.IsTrue(StorageApi.FileOrFolderExists(outPath));
        }

        [TestMethod]
        public void Test_PostHtmlConvert_Pdf_LocalFileToStorage_1()
        {
            string name = "testpage1.html";
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.pdf");
            string srcPath = Path.Combine(LocalTestDataPath, name);
            var response = this.HtmlApi.PostConvertDocumentToPdf(srcPath, outPath);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
        }

        [TestMethod]
        public void Test_PostHtmlConvert_Pdf_LocalFileToStorage_2()
        {
            string name = "testpage5.html.zip";
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.pdf");
            string srcPath = Path.Combine(LocalTestDataPath, name);
            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToPdf(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
            }
            Assert.IsTrue(StorageApi.FileOrFolderExists(outPath));
        }

        [TestMethod]
        public void Test_PutHtmlConvert_Xps_StorageDocToStorage()
        {
            string name = "testpage1.html";
            string folder = StorageTestDataPath;
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.xps");
            var response = this.HtmlApi.PutConvertDocumentToXps(name, outPath, null, null, null, null, null, null, folder);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            Assert.IsTrue(StorageApi.FileOrFolderExists(outPath));
        }

        [TestMethod]
        public void Test_PostHtmlConvert_Xps_LocalFileToStorage()
        {
            string name = "testpage1.html";
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.xps");
            string srcPath = Path.Combine(LocalTestDataPath, name);
            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToXps(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
            }
            Assert.IsTrue(StorageApi.FileOrFolderExists(outPath));
        }


        [TestMethod]
        public void Test_PutHtmlConvert_Jpeg_StorageDocToStorage()
        {
            string name = "testpage1.html";
            string folder = StorageTestDataPath;
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.jpg");
            var response = this.HtmlApi.PutConvertDocumentToImage(name, "jpeg", outPath, null, null, null, null, null, null, 96, folder);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            Assert.IsTrue(StorageApi.FileOrFolderExists(outPath));
        }

        [TestMethod]
        public void Test_PostHtmlConvert_Jpeg_LocalFileToStorage()
        {
            string name = "testpage2.html";
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.jpg");
            string srcPath = Path.Combine(LocalTestDataPath, name);
            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToImage(stream, "jpeg", outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
            }
            Assert.IsTrue(StorageApi.FileOrFolderExists(outPath));
        }

        [TestMethod]
        public void Test_PostHtmlConvert_Jpeg_LocalFileToStorage_1()
        {
            string name = "testpage1.html";
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.jpg");
            string srcPath = Path.Combine(LocalTestDataPath, name);
            var response = this.HtmlApi.PostConvertDocumentToImage(srcPath, "jpeg", outPath);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
        }

        [TestMethod]
        public void Test_PutHtmlConvert_Markdown_StorageToStorage()
        {
            string name = "testpage1.html";
            string folder = StorageTestDataPath;
            string storage = null;

            string outFile = $"{Path.GetFileNameWithoutExtension(name)}_converted_at_{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.md";
            string outPath = Path.Combine(testoutStorageFolder, outFile).Replace('\\', '/');

            var response = this.HtmlApi.PutConvertDocumentToMarkdown(name, outPath, false, folder, storage);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);
            Assert.IsTrue(StorageApi.FileOrFolderExists(outPath));
        }


    }
}
