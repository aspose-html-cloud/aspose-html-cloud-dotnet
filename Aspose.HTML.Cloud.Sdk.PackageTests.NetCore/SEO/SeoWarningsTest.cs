using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Newtonsoft.Json.Linq;

namespace Aspose.HTML.Cloud.Sdk.Tests.SEO
{
    [TestClass]
    public class SeoWarningsTest : BaseTestContext
    {
        private List<string> testPages = null;

        [TestInitialize]
        public void SetUp()
        {
            testPages = new List<string>()
            {
                "https://www.aspose.com",
                "www.python.org",
                "www.podrobnosti.ua",
                "www.yahoo.com",
                "w3.org",
                "http://htmlbook.ru",
                "https://stackoverflow.com/jobs",
                "https://www.le.ac.uk/oerresources/bdra/html/page_01.htm"
            };
        }

        [TestMethod]
        public void TestSeoWarnings()
        {
            //foreach (var url in testPages)
            //{
            //    var response = HtmlApi.GetWebPageSEOWarnings(url);
            //    Assert.IsNotNull(response);
            //    Assert.AreEqual(200, response.Code);
            //    Assert.IsNotNull(response.ContentStream);
            //    Assert.IsTrue(response.ContentStream.Length > 0);
            //    Assert.IsFalse(string.IsNullOrEmpty(response.FileName));
            //    //var jsonStr = response.ContentAsString;
            //    //Assert.IsTrue(IsValidJson(jsonStr));
            //    string fileName = response.FileName;
            //    //if(string.IsNullOrEmpty(response.FileName))
            //    //fileName = $"{Path.GetFileName(url)}_seo_warnings.json";
            //    var outPath = saveResultStreamToOutDir(response.ContentStream, fileName, "SEO");
            //}
        }

        private static bool IsValidJson(string value)
        {
            try
            {
                var json = JContainer.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
