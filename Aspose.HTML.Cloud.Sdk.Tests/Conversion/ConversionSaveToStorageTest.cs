using System;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;

namespace Aspose.HTML.Cloud.Sdk.Tests.Conversion
{
    [TestClass]
    public class ConversionSaveToStorageTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath("TestData", "HTML");
        private readonly string testoutStorageFolder = "/Testout/Conversion";

        [TestMethod]
        public void Test_PutHtmlConvert_Pdf_StorageDocToStorage()
        {
            string name = "testpage1.html";
            string folder = null;
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.pdf");
            var response = this.ConversionApi.PutConvertDocumentToPdf(name, outPath, null, null, null, null, null, null, folder);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);

            var existReq = new GetIsExistRequest(outPath);
            var stRes = this.StorageApi.GetIsExist(existReq);
            Assert.AreEqual(200, stRes.Code);
            Assert.IsTrue(stRes.FileExist.IsExist.HasValue && (bool)(stRes.FileExist.IsExist.Value));
        }

        [TestMethod]
        public void Test_PutHtmlConvert_Pdf_LocalFileToStorage()
        {
            string name = "testpage1.html";
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.pdf");
            string srcPath = Path.Combine(dataFolder, name);
            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.ConversionApi.PutConvertDocumentToPdf(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
            }

            var existReq = new GetIsExistRequest(outPath);
            var stRes = this.StorageApi.GetIsExist(existReq);
            Assert.AreEqual(200, stRes.Code);
            Assert.IsTrue(stRes.FileExist.IsExist.HasValue && (bool)(stRes.FileExist.IsExist.Value));
        }

        [TestMethod]
        public void Test_PutHtmlConvert_Xps_StorageDocToStorage()
        {
            string name = "testpage1.html";
            string folder = null;
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.xps");
            var response = this.ConversionApi.PutConvertDocumentToXps(name, outPath, null, null, null, null, null, null, folder);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);

            var existReq = new GetIsExistRequest(outPath);
            var stRes = this.StorageApi.GetIsExist(existReq);
            Assert.AreEqual(200, stRes.Code);
            Assert.IsTrue(stRes.FileExist.IsExist.HasValue && (bool)(stRes.FileExist.IsExist.Value));
        }

        [TestMethod]
        public void Test_PutHtmlConvert_Xps_LocalFileToStorage()
        {
            string name = "testpage1.html";
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.xps");
            string srcPath = Path.Combine(dataFolder, name);
            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.ConversionApi.PutConvertDocumentToXps(stream, outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
            }

            var existReq = new GetIsExistRequest(outPath);
            var stRes = this.StorageApi.GetIsExist(existReq);
            Assert.AreEqual(200, stRes.Code);
            Assert.IsTrue(stRes.FileExist.IsExist.HasValue && (bool)(stRes.FileExist.IsExist.Value));
        }

        [TestMethod]
        public void Test_PutHtmlConvert_Jpeg_StorageDocToStorage()
        {
            string name = "testpage1.html";
            string folder = null;
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.jpg");
            var response = this.ConversionApi.PutConvertDocumentToImage(name, "jpeg", outPath, null, null, null, null, null, null, 96, folder);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.Code);

            var existReq = new GetIsExistRequest(outPath);
            var stRes = this.StorageApi.GetIsExist(existReq);
            Assert.AreEqual(200, stRes.Code);
            Assert.IsTrue(stRes.FileExist.IsExist.HasValue && (bool)(stRes.FileExist.IsExist.Value));
        }

        [TestMethod]
        public void Test_PutHtmlConvert_Jpeg_LocalFileToStorage()
        {
            string name = "testpage1.html";
            string outPath = Path.Combine(testoutStorageFolder, $"{name}_converted_at_{DateTime.Now.ToString("yyMMdd_hhmmss")}.jpg");
            string srcPath = Path.Combine(dataFolder, name);
            using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = this.ConversionApi.PutConvertDocumentToImage(stream, "jpeg", outPath);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
            }

            var existReq = new GetIsExistRequest(outPath);
            var stRes = this.StorageApi.GetIsExist(existReq);
            Assert.AreEqual(200, stRes.Code);
            Assert.IsTrue(stRes.FileExist.IsExist.HasValue && (bool)(stRes.FileExist.IsExist.Value));
        }


    }
}
