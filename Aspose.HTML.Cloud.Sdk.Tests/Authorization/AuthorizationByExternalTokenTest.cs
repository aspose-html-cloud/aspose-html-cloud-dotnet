using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;

using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Client.Authentication;

namespace Aspose.HTML.Cloud.Sdk.Tests.Authorization
{
    [TestClass]
    [DeploymentItem("TestData", "TestData")]
    public class AuthorizationByExternalTokenTest : BaseTestContext
    {
        [TestMethod]
        public void Test_AuthorizeByExternalToken_1()
        {
            string name = "testpage5.html.zip";
            string xpath = ".//p";
            string folder = StorageTestDataPath; 

            try
            {
                var response = this.HtmlApiEx.GetDocumentFragmentByXPath(name, xpath, "plain", null, folder);
                Assert.AreEqual(response.Code, 200);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_AuthorizeByExternalToken_1_2()
        {
            string name = "childrens-literature-20130206.epub";
            string folder = StorageTestDataPath;

            try
            {
                var response = this.HtmlApiEx.GetConvertDocumentToPdf(name, 
                    null, null, null, null, null, null, folder);
                Assert.AreEqual(response.Code, 200);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_AuthorizeByExternalToken_2_1()
        {
            // setup folder path
            string folder = "/Html/TestData";
            // setup storage name (default storage if null)
            string storage = null;

            try
            {
                var response = this.StorageApiEx.GetFolderContentList(folder, storage);
                Assert.IsTrue(response != null && response is List<StorageItem>);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void Test_AuthorizeByExternalToken_2_2()
        {
            // setup folder path
            string folder = "/Html/Testout";
            // setup storage name (default storage if null)
            string storage = null;

            try
            {
                var response = this.StorageApiEx.GetFolderContentList(folder, storage);
                Assert.IsTrue(response != null && response is List<StorageItem>);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        //[TestMethod]
        //public void Test_AuthorizeByExternalToken_3()
        //{
        //    string name = "testpage5.html.zip";
        //    string xpath = ".//p";
        //    string folder = StorageTestDataPath;


        //}


        [TestMethod]
        public void Test_ExternalTokenExpiration_1()
        {

            string name = "testpage5.html.zip";
            string xpath = ".//p";
            string folder = StorageTestDataPath;
            int expiresInSec = 60;
            bool expired = false;

            string ApiVersion = this.keys.ApiVersion ?? "3.0";
            string baseUri = keys.BaseProductUri + $"/v{ApiVersion}";
            var tokenObj = GetAuthToken(expiresInSec);

            this.HtmlApiEx = new HtmlApi(tokenObj, baseUri);
            try
            {
                var response = this.HtmlApiEx.GetDocumentFragmentByXPath(name, xpath, "plain", null, folder);
                Assert.AreEqual(response.Code, 200);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            System.Threading.Thread.Sleep(60000);
            try
            {
                var response = this.HtmlApiEx.GetDocumentFragmentByXPath(name, xpath, "plain", null, folder);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is SdkAuthException 
                    && ( ((SdkAuthException)ex).ErrorReason == SdkAuthException.Reason.TokenExpired
                    || ex.Message.Contains("Externally provided authorization token expired.")));
                expired = true;
            }
            if(expired)
            {
                tokenObj = GetAuthToken();

                this.HtmlApiEx = new HtmlApi(tokenObj, baseUri);
                try
                {
                    var response = this.HtmlApiEx.GetDocumentFragmentByXPath(name, xpath, "plain", null, folder);
                    Assert.AreEqual(response.Code, 200);
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
            }

        }

    }
}
