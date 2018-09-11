using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;

using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;

namespace Aspose.HTML.Cloud.Sdk.Tests.Document
{
    [TestClass]
    public class DocumentFragmentsTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath("TestData", "HTML");

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

        [TestMethod]
        public void Test_GetDocumentFragmentByXPath_1()
        {
            string name = "testpage5.html.zip";
            string xpath = ".//p";
            string folder = "HtmlTestDoc";
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

            Stream stream = DocumentApi.GetDocumentFragmentByXPath(name, xpath, "plain", null, folder);
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream is FileStream);
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByXPath_2()
        {
            string name = "testpage1.html";
            string xpath = ".//ol/li";
            string folder = "HtmlTestDoc";
            string storagePath = $"{folder}/{name}";

            string srcPath = Path.Combine(dataFolder, name);

            using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            {
                var reqCr = new PutCreateRequest(storagePath, fstr);
                var respCr = this.StorageApi.PutCreate(reqCr);
                var reqExist = new GetIsExistRequest(storagePath);
                var respExist = this.StorageApi.GetIsExist(reqExist);
                Assert.IsTrue(respExist.FileExist.IsExist.HasValue && respExist.FileExist.IsExist.Value);
            }

            Stream stream = DocumentApi.GetDocumentFragmentByXPath(name, xpath, "json", null, folder);
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByCSS_1()
        {
            string name = "testpage5.html.zip";
            string csssel = "p";
            string folder = "HtmlTestDoc";
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

            Stream stream = DocumentApi.GetDocumentFragmentByXPath(name, csssel, "plain", null, folder);
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream is FileStream);
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByCSS_2()
        {
            string name = "testpage1.html";
            string csssel = "ol>li";
            string folder = "HtmlTestDoc";
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

            Stream stream = DocumentApi.GetDocumentFragmentByXPath(name, csssel, "plain", null, folder);
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream is FileStream);
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByXPathByUrl_1()
        {
            var url = testUrls[0];
            var xpath = ".//div[@class=\"container\"]";

            Stream stream = DocumentApi.GetDocumentFragmentByXPathByUrl(url, xpath, "plain");
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByXPathByUrl_2()
        {
            var url = testUrls[3];
            var xpath = ".//p";

            Stream stream = DocumentApi.GetDocumentFragmentByXPathByUrl(url, xpath, "plain");
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByCSSByUrl_1()
        {
            var url = testUrls[0];
            var csssel = "div.container";

            Stream stream = DocumentApi.GetDocumentFragmentByXPathByUrl(url, csssel, "plain");
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }

        [TestMethod]
        public void Test_GetDocumentFragmentByCSSByUrl_2()
        {
            var url = testUrls[3];
            var csssel = "p";

            Stream stream = DocumentApi.GetDocumentFragmentByXPathByUrl(url, csssel, "plain");
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }

        [TestMethod]
        public void Test_GetDocumentImages()
        {
            string name = "testpage5.html.zip";
            string folder = "HtmlTestDoc";
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

            Stream stream = DocumentApi.GetDocumentImages(name, null, folder);
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }

        [TestMethod]
        public void Test_GetDocumentImagesByUrl_1()
        {
            var url = testUrls[2];

            Stream stream = DocumentApi.GetDocumentImagesByUrl(url);
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }
    }
}
