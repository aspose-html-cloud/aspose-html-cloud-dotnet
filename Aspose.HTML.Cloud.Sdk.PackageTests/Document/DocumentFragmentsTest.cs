using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;


namespace Aspose.HTML.Cloud.Sdk.Tests.Document
{
    [TestClass]
    public class DocumentFragmentsTest : BaseTestContext
    {
        private readonly string dataFolder = LocalTestDataPath;

        private List<string> testUrls;
        public DocumentFragmentsTest()
        {
            testUrls = new List<string>
            {
                @"https://products.aspose.com/html/net",
                @"http://www.sukidog.com/jpierre/strings/intro.htm",
                @"http://www.sukidog.com/jpierre/strings/why.htm" ,
                @"https://stallman.org/articles/words-to-greece.html",
                @"https://stallman.org/articles/hrant-dink.html",
                @"https://git-scm.com/book/en/v2/Getting-Started-About-Version-Control"
            };
        }

        [TestInitialize]
        public void TestSetUp()
        {
            string[] files = new string[]
            {
                "testpage1.html", "testpage5.html.zip"
            };
            foreach(string fname in files)
            {
                var storagePath = Path.Combine(StorageTestDataPath, fname).Replace('\\', '/');
                if(!StorageApi.FileOrFolderExists(storagePath))
                {
                    var localPath = Path.Combine(dataFolder, fname);
                    StorageApi.UploadFile(localPath, storagePath);
                }              
            }
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByXPath_1()
        {
            string name = "testpage5.html.zip";
            string xpath = ".//p";
            string folder = StorageTestDataPath;

            var response = HtmlApi.GetDocumentFragmentByXPath(name, xpath, "plain", null, folder);
            checkGetMethodResponse(response, "Document", "_xpath_p");
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByXPath_2()
        {
            string name = "testpage1.html";
            string xpath = ".//ol/li";
            string folder = StorageTestDataPath;

            var response = HtmlApi.GetDocumentFragmentByXPath(name, xpath, "json", null, folder);
            checkGetMethodResponseOkOrNoresult(response, "Document", "_xpath_ol_li");
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByCSS_1()
        {
            string name = "testpage5.html.zip";
            string csssel = "p";
            string folder = StorageTestDataPath;

            var response = HtmlApi.GetDocumentFragmentByCSSSelector(name, csssel, "plain", null, folder);
            checkGetMethodResponseOkOrNoresult(response, "Document", "_css_p");
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByCSS_2()
        {
            string name = "testpage1.html";
            string csssel = "ol>li";
            string folder = StorageTestDataPath;

            var response = HtmlApi.GetDocumentFragmentByCSSSelector(name, csssel, "plain", null, folder);
            checkGetMethodResponseOkOrNoresult(response, "Document", "_css_ol_li");
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByXPathByUrl_1()
        {
            var url = testUrls[0];
            var xpath = ".//div[@class=\"container\"]";

            var response = HtmlApi.GetDocumentFragmentByXPathByUrl(url, xpath, "plain");
            checkGetMethodResponseOkOrNoresult(response, "Document", "_url_xpath_div_class");
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByXPathByUrl_2()
        {
            var url = testUrls[3];
            var xpath = ".//p";

            var response = HtmlApi.GetDocumentFragmentByXPathByUrl(url, xpath, "plain");
            checkGetMethodResponseOkOrNoresult(response, "Document", "_url_xpath_p");
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByXPathByUrl_3()
        {
            string sourceUrl = "https://google.com";
            string xpath = "//body";

            var response = HtmlApi.GetDocumentFragmentByXPathByUrl(sourceUrl, xpath, "json");
            checkGetMethodResponse(response, "Document", "_xpath_body");
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByCSSByUrl_1()
        {
            var url = testUrls[0];
            var csssel = "div.container";

            var response = HtmlApi.GetDocumentFragmentByXPathByUrl(url, csssel, "plain");
            checkGetMethodResponseOkOrNoresult(response, "Document", "_url_css_div_class");
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByCSSByUrl_2()
        {
            var url = testUrls[3];
            var csssel = "p";

            var response = HtmlApi.GetDocumentFragmentByXPathByUrl(url, csssel, "plain");
            checkGetMethodResponseOkOrNoresult(response, "Document", "_url_xpath_p");
        }

        [TestMethod]
        public void Test_GetDocumentImages()
        {
            string name = "testpage5.html.zip";
            string folder = StorageTestDataPath;

            var response = HtmlApi.GetDocumentImages(name, null, folder);
            checkGetMethodResponse(response, "Document", "_images");
        }

        [TestMethod]
        public void Test_GetDocumentImagesByUrl_1()
        {
            var url = testUrls[2];

            var response = HtmlApi.GetDocumentImagesByUrl(url);
            checkGetMethodResponse(response, "Document", "_url_images");
        }
    }
}
