using System;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;

namespace Aspose.HTML.Cloud.Sdk.Tests.Conversion
{
    [TestClass]
    public class ConversionStreamToStorageTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath("TestData", "HTML");

        //[TestMethod]
        //public void Test_PutHtmlConvert_Pdf_StreamToStorage()
        //{
        //    string name = "testpage1.html";
        //    string outPath = "TempHtml/testpage1.html_converted.pdf";

        //    string srcPath = Path.Combine(dataFolder, name);

        //    using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
        //    {
        //        var response = this.ConversionApi.PutConvertDocumentToPdf(stream, outPath, 800, 1200);
        //        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //        Assert.AreEqual("application/pdf", response.MimeType);
        //    }
        //    var stRes = this.StorageApi.GetIsExist(outPath, null, null);
        //    Assert.IsTrue(stRes.FileExist.IsExist);
        //}

        //[TestMethod]
        //public void Test_PutHtmlConvert_Xps_StreamToStorage()
        //{
        //    string name = "testpage1.html";
        //    string outPath = "TempHtml/testpage1.html_converted.xps";

        //    string srcPath = Path.Combine(dataFolder, name);

        //    using (Stream stream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
        //    {
        //        var response = this.ConversionApi.PutConvertDocumentToXps(stream, outPath, 800, 1200);
        //        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //        Assert.AreEqual("application/vnd.ms-xpsdocument", response.MimeType);

        //        var stRes = this.StorageApi.GetIsExist(outPath, null, null);
        //        Assert.IsTrue(stRes.FileExist.IsExist);
        //    }
        //}

    }
}
