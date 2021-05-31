using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.HTML.Cloud.Examples.SDK;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlImport
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to convert Markdown file to HTML page in the local filesystem 
    /// uploading it to default Aspose cloud storage and using its name and storage folder path; 
    /// result is returned in the response stream and can be saved in the local file system.
    /// </summary>
    public class ImportHtmlFromMarkdownByName : ISdkRunner
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

            string storagePath = (folder == null) ? name : Path.Combine(folder, name).Replace('\\', '/');
            string outFile = $"{name}_get_to_html_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.html";
            if (File.Exists(srcPath))
            {
                SdkBaseRunner.UploadToStorage(storagePath, srcPath);
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", srcPath));

            IImportApi impApi = new HtmlApi(CommonSettings.ClientId, CommonSettings.ClientSecret, CommonSettings.BasePath, CommonSettings.AuthPath);
            StreamResponse response = impApi.GetImportMarkdownToHtml(name, folder, storage);
            if (response != null && response.ContentStream != null && response.Status == "OK")
            {
                var respFileName = response.FileName;
                Stream outStream = response.ContentStream;
                string outPath = Path.Combine(CommonSettings.OutDirectory, respFileName ?? outFile);
                using (FileStream fstr = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                {
                    outStream.Position = 0;
                    outStream.CopyTo(fstr);
                    fstr.Flush();
                    Console.WriteLine(string.Format("\nResult file downloaded to: {0}", outPath));
                }
            }
        }
    }
}
