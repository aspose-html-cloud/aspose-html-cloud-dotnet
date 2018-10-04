using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;

namespace Aspose.HTML.Cloud.Sdk.Tests.Conversion
{
    [TestClass]
    public class ConversionStorageFileTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath("TestData", "HTML");

        [TestMethod]
        public void Test_GetHtmlConvert_Pdf_StorageToStream()
        {
            string name = "testpage1.html";
            string folder = "TempHtml";

            //uploadFileToStorage(dataFolder, name, folder);
            #region REM - refactored
            // AR 2.10.2018 - : refactored - moved to base class
            //string srcPath = Path.Combine(dataFolder, name);
            //string path = string.Format("{0}/{1}", folder, name);
            //using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            //{
            //    PutCreateRequest reqCr = new PutCreateRequest(path, fstr);
            //    this.StorageApi.PutCreate(reqCr);
            //    GetIsExistRequest reqExist = new GetIsExistRequest(path);
            //    FileExistResponse resp = this.StorageApi.GetIsExist(reqExist);
            //    Assert.IsTrue(resp.FileExist.IsExist.HasValue && resp.FileExist.IsExist.Value);
            //}
            #endregion

            var response = this.ConversionApi.GetConvertDocumentToPdf(name, 800, 1200, null, null, null, null, folder);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)response).Name));
        }

        [TestMethod]
        public void Test_GetHtmlConvert_Jpeg_StorageToStream()
        {
            string name = "testpage1.html";
            string folder = "TempHtml";

            //uploadFileToStorage(dataFolder, name, folder);
            #region REM - refactored
            // AR 2.10.2018 - : refactored - moved to base class
            //string srcPath = Path.Combine(dataFolder, name);
            //string path = string.Format("{0}/{1}", folder, name);
            //using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            //{
            //    PutCreateRequest reqCr = new PutCreateRequest(path, fstr);
            //    this.StorageApi.PutCreate(reqCr);
            //    GetIsExistRequest reqExist = new GetIsExistRequest(path);
            //    FileExistResponse resp = this.StorageApi.GetIsExist(reqExist);
            //    Assert.IsTrue(resp.FileExist.IsExist.HasValue && resp.FileExist.IsExist.Value);
            //}
            #endregion

            var response = this.ConversionApi.GetConvertDocumentToImage(name, "jpeg", 800, 1200, null, null, null, null, null, null, folder);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)response).Name));
        }
    }
}
