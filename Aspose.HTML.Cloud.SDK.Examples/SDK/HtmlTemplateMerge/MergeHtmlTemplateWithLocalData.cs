using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlTemplateMerge
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to populate HTML template with data from local file
    /// and to get the result in the response stream.
    /// </summary>
    public class MergeHtmlTemplateWithLocalData : ISdkRunner
    {
        public void Run()
        {
            // setup local path the files are located by
            var srcDir = CommonSettings.LocalDataFolder;
            // setup HTML template file name
            var templateName = "test_template_3_2.html";
            // setup data to merge file name
            var dataFileName = "templ_merge_data_2.xml";
            // setup merge options
            var options = "{'cs_names':false, 'rm_tabhdr':false}";
            // setup the storage folder where the files will be uploaded before
            var folder = CommonSettings.StorageDataFolder;

            var outFolder = "/Html/Testout";
            var mergedName = $"{templateName}_merged_at_{DateTime.Now.ToString("yyyyMMdd-hhmmss")}{Path.GetExtension(templateName)}";

            var templatePath = "";
            var dataPath = Path.Combine(srcDir, dataFileName);

            string filePath = Path.Combine(srcDir, templateName);
            string storagePath = Path.Combine(folder, templateName).Replace('\\', '/');
            string outPath = Path.Combine(outFolder, mergedName).Replace('\\', '/');
            // template should be uploaded to storage before
            if (File.Exists(filePath))
            {
                SdkBaseRunner.UploadToStorage(storagePath, filePath);
                templatePath = storagePath;
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", filePath));

            using (Stream dataStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read))
            {
                Stream inStream = new MemoryStream();
                dataStream.CopyTo(inStream);
                inStream.Flush();
                inStream.Position = 0;

                ITemplateMergeApi api = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
                var response = api.PostMergeHtmlTemplate(templateName, inStream, outPath, options, folder);
                if(response != null && response.Status == "OK")
                {
                    Console.WriteLine($"TemplateMerge: Result file uploaded to {outPath}");
                }
            }
        }
    }
}
