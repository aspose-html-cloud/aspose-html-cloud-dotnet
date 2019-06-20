using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aspose.HTML.Cloud.Sdk.Tests.Base;

namespace Aspose.HTML.Cloud.Sdk.Tests.TemplateMerge
{
    [TestClass]
    public class TemplateMergeTest : BaseTestContext
    {
        private readonly string dataFolder = DirectoryHelper.GetPath("TestData", "HTML");

        private static List<string> templates;

        private static List<string> dataFiles;

        static TemplateMergeTest()
        {
            templates = new List<string>()
            {
                "",
                "test_template_1.html",
                "test_template_2.html",
                "test_template_3.html",
                "test_template_3_1.html",
                "test_template_3_2.html",
                "test_template_4.html",
                "test_template_4_1.html"
            };

            dataFiles = new List<string>()
            {
                "",
                "templ_merge_data_1.xml",
                "templ_merge_data_2.xml",
                "templ_merge_data_3.xml",
                "templ_merge_data_4.xml",
                "templ_merge_data_1.json",
                "templ_merge_data_2.json",
                "templ_merge_data_2_1.json",
                "templ_merge_data_3.json",
                ""
            };

        }

        //[TestInitialize]
        //public void TestInit()
        //{
        //}

        [TestMethod]
        public void Test_MergeTemplate_Get_1()
        {
            string templateName = templates[1];
            string folder = "14/HTML";
            string dataFile = dataFiles[1];
            string dataPath = Path.Combine("/", folder, dataFile).Replace('\\', '/');
            string options = null;

            //uploadFileToStorage(dataFolder, templateName, folder);
            //uploadFileToStorage(dataFolder, dataFile, folder);

            var response = HtmlApi.GetMergeHtmlTemplate(
                templateName, dataPath, options, folder);
            checkGetMethodResponse(response, "TemplateMerge");
        }

        [TestMethod]
        public void Test_MergeTemplate_Get_2()
        {
            string templateName = templates[1];
            string folder = "14/HTML";
            string dataFile = dataFiles[1];
            string dataPath = Path.Combine("/", folder, dataFile).Replace('\\', '/');
            string options = "{'cs_names':false}";

            //uploadFileToStorage(dataFolder, templateName, folder);
            //uploadFileToStorage(dataFolder, dataFile, folder);

            var response = HtmlApi.GetMergeHtmlTemplate(
                templateName, dataPath, options, folder);
            checkGetMethodResponse(response, "TemplateMerge");
        }

        [TestMethod]
        public void Test_MergeTemplate_Post_1()
        {
            string templateName = templates[1];
            string folder = "14/HTML";
            string dataFile = dataFiles[1];
            string dataPath = Path.Combine(dataFolder, dataFile);
            string options = null;
            string outPath = Path.Combine("/", folder, 
                $"{templateName}_merged_at_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}").Replace('\\', '/');

            //uploadFileToStorage(dataFolder, templateName, folder);
            using (var datastr = new FileStream(dataPath, FileMode.Open, FileAccess.Read))
            {
                var dataType = Path.GetExtension(dataFile).Replace(".", "");
                var response = this.HtmlApi.PostMergeHtmlTemplate(
                    templateName, datastr, dataType, outPath, options, folder);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
            }
        }

        [TestMethod]
        public void Test_MergeTemplate_Post_2()
        {
            string templateName = templates[4];
            string folder = "14/HTML";
            string dataFile = dataFiles[4];
            string dataPath = Path.Combine(dataFolder, dataFile);
            string options = null;
            string outPath = Path.Combine("/", folder,
                $"{templateName}_merged_at_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}").Replace('\\', '/');

            //uploadFileToStorage(dataFolder, templateName, folder);
            using (var datastr = new FileStream(dataPath, FileMode.Open, FileAccess.Read))
            {
                var dataType = Path.GetExtension(dataFile).Replace(".", "");
                var response = this.HtmlApi.PostMergeHtmlTemplate(
                    templateName, datastr, dataType, outPath, options, folder);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
            }
        }

        [TestMethod]
        public void Test_MergeTemplate_Post_3()
        {
            string templateName = templates[4];
            string folder = "14/HTML";
            string dataFile = dataFiles[5];
            string dataPath = Path.Combine(dataFolder, dataFile);
            string options = null;
            string outPath = Path.Combine("/", folder,
                $"{templateName}_merged_at_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}").Replace('\\', '/');

            //uploadFileToStorage(dataFolder, templateName, folder);
            using (var datastr = new FileStream(dataPath, FileMode.Open, FileAccess.Read))
            {
                var dataType = Path.GetExtension(dataFile).Replace(".", "");
                var response = this.HtmlApi.PostMergeHtmlTemplate(
                    templateName, datastr, dataType, outPath, options, folder);
                Assert.IsNotNull(response);
                Assert.AreEqual(200, response.Code);
            }
        }

    }
}
