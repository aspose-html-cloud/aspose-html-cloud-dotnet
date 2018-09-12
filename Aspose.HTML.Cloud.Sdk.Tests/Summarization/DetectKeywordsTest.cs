using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;

namespace Aspose.HTML.Cloud.Sdk.Tests.Summarization
{
    [TestClass]
    public class DetectKeywordsTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath("TestData", "HTML");

        [TestMethod]
        public void Test_GetHtmlDetectKeywords_1()
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

            var stream = SummarizationApi.GetDetectHtmlKeywords(name, folder, null);
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }

    }
}
