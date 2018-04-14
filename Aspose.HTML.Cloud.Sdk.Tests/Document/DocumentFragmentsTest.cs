using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;
using Com.Aspose.Storage.Model;

namespace Aspose.HTML.Cloud.Sdk.Tests.Document
{
    [TestClass]
    public class DocumentFragmentsTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath("TestData", "HTML");

        [TestMethod]
        public void Test_GetDocumentFragmentByXPath_1()
        {
            string name = "testpage5.html.zip";
            string xpath = ".//p";
            string folder = "HtmlTestDoc";
            string storagePath = $"{folder}/{name}";

            string srcPath = Path.Combine(dataFolder, name);
            StorageApi.PutCreate(storagePath, null, null, File.ReadAllBytes(srcPath));
            FileExistResponse resp = StorageApi.GetIsExist(storagePath, null, null);
            Assert.IsTrue(resp.FileExist.IsExist);

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
            StorageApi.PutCreate(storagePath, null, null, File.ReadAllBytes(srcPath));
            FileExistResponse resp = StorageApi.GetIsExist(storagePath, null, null);
            Assert.IsTrue(resp.FileExist.IsExist);

            Stream stream = DocumentApi.GetDocumentFragmentByXPath(name, xpath, "json", null, folder);
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
            StorageApi.PutCreate(storagePath, null, null, File.ReadAllBytes(srcPath));
            FileExistResponse resp = StorageApi.GetIsExist(storagePath, null, null);
            Assert.IsTrue(resp.FileExist.IsExist);

            Stream stream = DocumentApi.GetDocumentImages(name, null, folder);
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.GetType() == typeof(FileStream));
            Assert.IsTrue(File.Exists(((FileStream)stream).Name));
        }
    }
}
