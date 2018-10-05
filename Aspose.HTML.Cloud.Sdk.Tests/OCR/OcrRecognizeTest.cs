using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;

namespace Aspose.HTML.Cloud.Sdk.Tests.OCR
{
    [TestClass]
    public class OcrRecognizeTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath("TestData", "HTML");

        [TestMethod]
        public void Test_RecognizeAndImport_Get_1()
        {
            var name = "ocr_test_2.png";
            string folder = "HtmlTestDoc";
            string storagePath = $"{folder}/{name}";
            string srcPath = Path.Combine(dataFolder, name);
            //using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            //{
            //    PutCreateRequest reqCr = new PutCreateRequest(storagePath, fstr);
            //    UploadResponse respUpl = this.StorageApi.PutCreate(reqCr);
            //    GetIsExistRequest reqExist = new GetIsExistRequest(storagePath);
            //    FileExistResponse respEx = this.StorageApi.GetIsExist(reqExist);
            //    Assert.IsTrue(respEx.FileExist.IsExist.HasValue && respEx.FileExist.IsExist.Value);
            //}
            var result = OcrApi.GetRecognizeAndImportToHtml(name, "en", folder);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)result).Name));
        }

        [TestMethod]
        public void Test_RecognizeAndImport_Get_2()
        {
            var name = "1168_016.3B.jpg";
            string folder = "HtmlTestDoc";
            string storagePath = $"{folder}/{name}";
            string srcPath = Path.Combine(dataFolder, name);
            //using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            //{
            //    PutCreateRequest reqCr = new PutCreateRequest(storagePath, fstr);
            //    UploadResponse respUpl = this.StorageApi.PutCreate(reqCr);
            //    GetIsExistRequest reqExist = new GetIsExistRequest(storagePath);
            //    FileExistResponse resp = this.StorageApi.GetIsExist(reqExist);
            //    Assert.IsTrue(resp.FileExist.IsExist.HasValue && resp.FileExist.IsExist.Value);
            //}
            var result = OcrApi.GetRecognizeAndImportToHtml(name, "en", folder);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)result).Name));
        }


        [TestMethod]
        public void Test_RecognizeAndTranslate_Get_1()
        {
            var name = "ocr_test_1.png";
            string folder = "HtmlTestDoc";
            string storagePath = $"{folder}/{name}";
            string srcPath = Path.Combine(dataFolder, name);
            //using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            //{
            //    PutCreateRequest reqCr = new PutCreateRequest(storagePath, fstr);
            //    UploadResponse respUpl = this.StorageApi.PutCreate(reqCr);
            //    GetIsExistRequest reqExist = new GetIsExistRequest(storagePath);
            //    FileExistResponse resp = this.StorageApi.GetIsExist(reqExist);
            //    Assert.IsTrue(resp.FileExist.IsExist.HasValue && resp.FileExist.IsExist.Value);
            //}
            var result = OcrApi.GetRecognizeAndTranslateToHtml(name, "en", "de", folder);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is FileStream);
            Assert.IsTrue(File.Exists(((FileStream)result).Name));
        }

        [TestMethod]
        public void Test_RecognizeAndTranslate_Get_2()
        {
            var name = "1168_016.3B.jpg";
            string folder = "HtmlTestDoc";
            string storagePath = $"{folder}/{name}";
            string srcPath = Path.Combine(dataFolder, name);
            //using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            //{
            //    PutCreateRequest reqCr = new PutCreateRequest(storagePath, fstr);
            //    UploadResponse respUpl = this.StorageApi.PutCreate(reqCr);
            //    GetIsExistRequest reqExist = new GetIsExistRequest(storagePath);
            //    FileExistResponse resp = this.StorageApi.GetIsExist(reqExist);
            //    Assert.IsTrue(resp.FileExist.IsExist.HasValue && resp.FileExist.IsExist.Value);
            //}
            var result = OcrApi.GetRecognizeAndTranslateToHtml(name, "en", "de", folder);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is FileStream);
            Assert.IsTrue(File.Exists(((FileStream)result).Name));
        }

    }
}
