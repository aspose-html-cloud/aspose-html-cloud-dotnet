using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;

namespace Aspose.HTML.Cloud.Sdk.Tests.Translation
{
    [TestClass]
    public class TranslateStorageFileTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath("TestData", "HTML");

        [TestMethod]
        public void Test_GetHtmlTranslate_en_fr_1()
        {
            string name = "testpage1.html";
            string folder = "HtmlTestTranslate";
            string storagePath = $"{folder}/{name}";

            string srcPath = Path.Combine(dataFolder, name);
            using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                PutCreateRequest reqCr = new PutCreateRequest(storagePath, fstr);
                this.StorageApi.PutCreate(reqCr);
                GetIsExistRequest reqExist = new GetIsExistRequest(storagePath);
                FileExistResponse resp = this.StorageApi.GetIsExist(reqExist);
                Assert.IsTrue(resp.FileExist.IsExist.HasValue && resp.FileExist.IsExist.Value);
            }

            var response = TranslationApi.GetTranslateDocument(
                name, "en", "fr", folder, null);
            checkGetMethodResponse(response, "Translate", "_en_fr");
        }

        //[TestMethod]
        //public void Test_PutHtmlTranslate_en_de_1()
        //{
        //    string name = "testpage1.html";
        //    string folder = "HtmlTestTranslate";
        //    string storagePath = $"{folder}/{name}";

        //    string srcPath = Path.Combine(dataFolder, name);

        //    StorageApi.PutCreate(storagePath, null, null, File.ReadAllBytes(srcPath));
        //    FileExistResponse resp = StorageApi.GetIsExist(storagePath, null, null);
        //    Assert.IsTrue(resp.FileExist.IsExist);

        //    var response = TranslationApi.PutTranslateDocument(name, "en", "de", folder);
        //    Assert.AreEqual("storage", (string)response.Content);
        //    Assert.IsTrue(response.ContentName != null);

        //    storagePath = string.Format("{0}/{1}", folder, response.ContentName);
        //    var stResp = StorageApi.GetIsExist(storagePath, null, null);
        //    Assert.IsTrue(stResp.FileExist.IsExist);
        //}

        //[TestMethod]
        //public void Test_PutHtmlTranslate_en_ru_1()
        //{
        //    string name = "testpage1.html";
        //    string folder = "HtmlTestTranslate";
        //    string storagePath = $"{folder}/{name}";

        //    string srcPath = Path.Combine(dataFolder, name);
        //    StorageApi.PutCreate(storagePath, null, null, File.ReadAllBytes(srcPath));
        //    FileExistResponse resp = StorageApi.GetIsExist(storagePath, null, null);
        //    Assert.IsTrue(resp.FileExist.IsExist);

        //    var response = TranslationApi.PutTranslateDocument(name, "en", "ru", folder);
        //    Assert.AreEqual("storage", (string)response.Content);
        //    Assert.IsTrue(response.ContentName != null);

        //    storagePath = string.Format("{0}/{1}", folder, response.ContentName);
        //    var stResp = StorageApi.GetIsExist(storagePath, null, null);
        //    Assert.IsTrue(stResp.FileExist.IsExist);
        //}
    }
}
