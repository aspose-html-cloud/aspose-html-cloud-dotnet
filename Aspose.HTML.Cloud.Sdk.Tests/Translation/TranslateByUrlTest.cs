using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;

namespace Aspose.HTML.Cloud.Sdk.Tests.Translation
{
    [TestClass]
    public class TranslateByUrlTest : BaseTestContext
    {
        [TestMethod]
        public void Test_GetHtmlTranslateByURL_en_fr_1()
        {
            string sourceUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_02.htm";

            var response = HtmlApi.GetTranslateDocumentByUrl(sourceUrl, "en", "fr");
            checkGetMethodResponse(response, "Translate", "_url_en_fr");
        }

        //[TestMethod]
        //public void Test_PutHtmlTranslateByURL_en_de_1()
        //{
        //    string sourceUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_02.htm";
        //    string folder = "TempHtml";

        //    var response = TranslationApi.PutTranslateDocumentByUrl(sourceUrl, "en", "de", folder);
        //    Assert.AreEqual("storage", (string)response.Content);
        //    Assert.IsTrue(response.ContentName != null);

        //    var path = string.Format("{0}/{1}", folder, response.ContentName);
        //    var stResp = StorageApi.GetIsExist(path, null, null);
        //    Assert.IsTrue(stResp.FileExist.IsExist);
        //}
    }
}
