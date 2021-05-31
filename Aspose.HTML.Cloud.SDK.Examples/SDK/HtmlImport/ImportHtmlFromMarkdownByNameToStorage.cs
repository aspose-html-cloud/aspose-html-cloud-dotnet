using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.HTML.Cloud.Examples.SDK;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlImport
{
    public class ImportHtmlFromMarkdownByNameToStorage : ISdkRunner
    {
        public void Run()
        {
            // setup HTML document name
            var name = "testpage1.md";
            // setup local document path
            var srcPath = Path.Combine(CommonSettings.LocalDataFolder, name);
            // setup storage folder where the source document should be present
            string folder = CommonSettings.StorageDataFolder;
            // setup storage name (null for default storage)
            string storage = null;
            // setup storage folder path where the result file will be uploaded to 
            string outFolder = "/Html/Testout/Conversion";

            string outFile = $"{name}_get_to_html_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.html";
            string storagePath = (folder == null) ? name : Path.Combine(folder, name).Replace('\\', '/');
            string outPath = Path.Combine(outFolder, outFile).Replace('\\', '/');

            if (File.Exists(srcPath))
            {
                SdkBaseRunner.UploadToStorage(storagePath, srcPath);
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", srcPath));

            IImportApi impApi = new HtmlApi(CommonSettings.ClientId, CommonSettings.ClientSecret, CommonSettings.BasePath, CommonSettings.AuthPath);
            AsposeResponse response = impApi.PutImportMarkdownToHtml(name, outPath, folder, storage);
            if (response != null && response.Status == "OK")
            {
                Console.WriteLine(string.Format("\nResult file uploaded to: {0}", outPath));
            }
        }
    }
}
