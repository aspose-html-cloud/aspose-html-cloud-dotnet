using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;

using Aspose.Html.Cloud.Sdk.Api.Model; //Interfaces.Extended;

namespace Aspose.HTML.Cloud.Sdk.Tests.Conversion
{
    [TestClass]
    [DeploymentItem("TestData", "TestData")]
    public class ConversionExtendedTest : BaseTestContext
    {
        private readonly string testoutStorageFolder =
            Path.Combine(BaseTestContext.StorageTestoutFolder, "Conversion").Replace('\\', '/');

        [TestInitialize]
        public void TestSetup()
        {
            if (!StorageApi.FileOrFolderExists(testoutStorageFolder))
            {
                StorageApi.CreateFolder(testoutStorageFolder);
            }
        }

        [TestMethod]
        public void Test_PostConvertToImageAndDownload_1()
        {
            string name = "testpage1.html";
            string srcPath = Path.Combine(LocalTestDataPath, name);
            string outFile = $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.jpg";
            string outPath = Path.Combine(testoutStorageFolder, outFile).Replace('\\', '/');

            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToImageAndDownload(stream, "jpeg", outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
                Assert.IsInstanceOfType(response, typeof(StreamResponse));
                Assert.IsTrue(response.ContentStream != null);

                saveResultStreamToOutDir(response.ContentStream, outFile, "Conversion");
            }
        }

        [TestMethod]
        public void Test_PostConvertToImageAndDownload_2()
        {
            string name = "testpage3_embcss.html";
            string srcPath = Path.Combine(LocalTestDataPath, name);
            string outFile = $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.jpg";
            string outPath = Path.Combine(testoutStorageFolder, outFile).Replace('\\', '/');

            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToImageAndDownload(stream, "jpeg", outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
                Assert.IsInstanceOfType(response, typeof(StreamResponse));
                Assert.IsTrue(response.ContentStream != null);

                saveResultStreamToOutDir(response.ContentStream, outFile, "Conversion");
            }
        }

        [TestMethod]
        public void Test_PostConvertToImageAndDownload_3()
        {
            string name = "testpage5.html.zip";
            string srcPath = Path.Combine(LocalTestDataPath, name);
            string outFile = $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.jpg";
            string outPath = Path.Combine(testoutStorageFolder, outFile).Replace('\\', '/');

            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToImageAndDownload(stream, "jpeg", outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
                Assert.IsInstanceOfType(response, typeof(StreamResponse));
                Assert.IsTrue(response.ContentStream != null);

                saveResultStreamToOutDir(response.ContentStream, outFile, "Conversion");
            }
        }

        [TestMethod]
        public void Test_PostConvertToPdfAndDownload_1()
        {
            string name = "testpage1.html";
            string srcPath = Path.Combine(LocalTestDataPath, name);
            string outFile = $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.pdf";
            string outPath = Path.Combine(testoutStorageFolder, outFile).Replace('\\', '/');

            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToPdfAndDownload(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
                Assert.IsInstanceOfType(response, typeof(StreamResponse));
                Assert.IsTrue(response.ContentStream != null);

                saveResultStreamToOutDir(response.ContentStream, outFile, "Conversion");
            }
        }

        [TestMethod]
        public void Test_PostConvertToPdfAndDownload_2()
        {
            string name = "testpage3_embcss.html";
            string srcPath = Path.Combine(LocalTestDataPath, name);
            string outFile = $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.pdf";
            string outPath = Path.Combine(testoutStorageFolder, outFile).Replace('\\', '/');

            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToPdfAndDownload(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
                Assert.IsInstanceOfType(response, typeof(StreamResponse));
                Assert.IsTrue(response.ContentStream != null);

                saveResultStreamToOutDir(response.ContentStream, outFile, "Conversion");
            }
        }

        [TestMethod]
        public void Test_PostConvertToPdfAndDownload_3()
        {
            string name = "testpage5.html.zip";
            string srcPath = Path.Combine(LocalTestDataPath, name);
            string outFile = $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.pdf";
            string outPath = Path.Combine(testoutStorageFolder, outFile).Replace('\\', '/');

            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToPdfAndDownload(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
                Assert.IsInstanceOfType(response, typeof(StreamResponse));
                Assert.IsTrue(response.ContentStream != null);

                saveResultStreamToOutDir(response.ContentStream, outFile, "Conversion");
            }
        }

        [TestMethod]
        public void Test_PostConvertToXpsAndDownload_1()
        {
            string name = "testpage1.html";
            string srcPath = Path.Combine(LocalTestDataPath, name);
            string outFile = $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.xps";
            string outPath = Path.Combine(testoutStorageFolder, outFile).Replace('\\', '/');

            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToXpsAndDownload(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
                Assert.IsInstanceOfType(response, typeof(StreamResponse));
                Assert.IsTrue(response.ContentStream != null);

                saveResultStreamToOutDir(response.ContentStream, outFile, "Conversion");
            }
        }

        [TestMethod]
        public void Test_PostConvertToXpsAndDownload_2()
        {
            string name = "testpage3_embcss.html";
            string srcPath = Path.Combine(LocalTestDataPath, name);
            string outFile = $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.xps";
            string outPath = Path.Combine(testoutStorageFolder, outFile).Replace('\\', '/');

            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToXpsAndDownload(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
                Assert.IsInstanceOfType(response, typeof(StreamResponse));
                Assert.IsTrue(response.ContentStream != null);

                saveResultStreamToOutDir(response.ContentStream, outFile, "Conversion");
            }
        }

        [TestMethod]
        public void Test_PostConvertToXpsAndDownload_3()
        {
            string name = "testpage5.html.zip";
            string srcPath = Path.Combine(LocalTestDataPath, name);
            string outFile = $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.xps";
            string outPath = Path.Combine(testoutStorageFolder, outFile).Replace('\\', '/');

            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.HtmlApi.PostConvertDocumentToXpsAndDownload(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
                Assert.IsInstanceOfType(response, typeof(StreamResponse));
                Assert.IsTrue(response.ContentStream != null);

                saveResultStreamToOutDir(response.ContentStream, outFile, "Conversion");
            }
        }
    }
}
