using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlTemplateMerge
{
    public class MergeHtmlTemplateWithData : ISdkRunner
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
            var templatePath = "";
            var dataPath = "";

            string filePath = Path.Combine(srcDir, templateName);
            string storagePath = Path.Combine(folder, templateName).Replace('\\', '/');
            // template should be uploaded to storage before
            if (File.Exists(filePath))
            {
                SdkBaseRunner.UploadToStorage(storagePath, filePath);
                templatePath = storagePath;
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", filePath));

            filePath = Path.Combine(srcDir, dataFileName);
            storagePath = Path.Combine(folder, dataFileName).Replace('\\', '/');
            // data file should be uploaded to storage before
            if (File.Exists(filePath))
            {
                SdkBaseRunner.UploadToStorage(storagePath, filePath);
                dataPath = storagePath;
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", filePath));

            ITemplateMergeApi mergeApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            // call SDK method that gets an HTML template and a data file from the storage 
            // and returns generated HTML document as stream.
            var response = mergeApi.GetMergeHtmlTemplate(templateName, dataPath, options, folder);
            Stream stream = response.ContentStream;
            if (stream != null)
            {
                string outFile = $"{Path.GetFileNameWithoutExtension(templateName)}_merged.{Path.GetExtension(templateName)}";
                string outPath = Path.Combine(CommonSettings.OutDirectory, outFile);
                using (FileStream fstr = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                {
                    stream.Position = 0;
                    stream.CopyTo(fstr);
                    fstr.Flush();
                    Console.WriteLine(string.Format("\nResult file downloaded to: {0}", outPath));
                }
            }
        }
    }
}
