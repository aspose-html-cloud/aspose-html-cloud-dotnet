using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;

namespace Aspose.HTML.Cloud.Sdk.Tests.Summarization
{
    [TestClass]
    public class DetectKeywordsByUrlTest : BaseTestContext
    {
        [TestMethod]
        public void Test_GetHtmlDetectKeywordsByUrl_1()
        {
            var sourceUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_02.htm"; ;

            var response = HtmlApi.GetDetectHtmlKeywordsByUrl(sourceUrl);
            checkGetMethodResponse(response, "Keywords");
        }
    }
}
