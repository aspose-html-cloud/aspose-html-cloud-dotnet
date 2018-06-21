using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Aspose.Storage.Cloud.Sdk.Model;

namespace Aspose.HTML.Cloud.Sdk.Tests.Summarization
{
    [TestClass]
    public class DetectKeywordsByUrlTest : BaseTestContext
    {
        [TestMethod]
        public void Test_GetHtmlDetectKeywordsByUrl_1()
        {
            var sourceUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_02.htm"; ;

            var stream = SummarizationApi.GetDetectHtmlKeywordsByUrl(sourceUrl);
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }
    }
}
