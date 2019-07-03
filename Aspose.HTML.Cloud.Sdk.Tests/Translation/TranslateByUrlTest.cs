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

    }
}
