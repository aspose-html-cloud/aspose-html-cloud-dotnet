using System;
using System.IO;
using Aspose.Storage.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlTemplateMerge
{
    public class MergeHtmlTemplateWithData : ISdkRunner
    {
        public void Run()
        {
            var templateName = "test_template_3_2.html"; 
            var dataFileName = "templ_merge_data_3.xml";
            var folder = "/14/HTML";

            string filePath = Path.Combine(CommonSettings.DataFolder, templateName);
            // template should be uploaded to storage before
            if (File.Exists(filePath))
            {
                SdkBaseRunner.UploadToStorage(templateName, CommonSettings.DataFolder);
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", filePath));

            filePath = Path.Combine(CommonSettings.DataFolder, dataFileName);
            // data file should be uploaded to storage before
            if (File.Exists(filePath))
            {
                SdkBaseRunner.UploadToStorage(dataFileName, CommonSettings.DataFolder);
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", filePath));

            ITemplateMergeApi mergeApi = new TemplateMergeApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
            // call SDK method that gets an HTML template and a data file from the storage 
            // and returns generated HTML document as stream.
            string dataPath = $"{folder}/{dataFileName}";
            Stream stream = mergeApi.GetMergeHtmlTemplate(templateName, dataPath, folder);
            if (stream != null && typeof(FileStream) == stream.GetType())
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
