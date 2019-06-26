using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlDocument
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to extract the HTML fragments by XPath query 
    /// from the HTML document in the cloud storage.
    /// </summary>
    public class ExtractHtmlFragmentsByXPath : ISdkRunner
    {
        public void Run()
        {
            var name = "testpage3_embcss.html";
            var xPath = "//ol/li";

            // Upload source file to cloud storage (default is AmazonS3)
            var srcPath = Path.Combine(CommonSettings.LocalDataFolder, name);

            var storageFolder = CommonSettings.StorageDataFolder;
            var delim = (storageFolder[storageFolder.Length - 1] == '/') ? string.Empty : "/";
            var storageFilePath = $"{storageFolder}{delim}{name}";

            if (File.Exists(srcPath))
            {
                SdkBaseRunner.UploadToStorage(storageFilePath, CommonSettings.LocalDataFolder);
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", srcPath));

            IDocumentApi docApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            // call the SDK method that returns a query result in the response stream.
            var response = docApi.GetDocumentFragmentByXPath(name, xPath, "json", null, null);
            if (response != null && response.ContentStream != null)
            {
                Stream stream = response.ContentStream;
                string outFile = $"{Path.GetFileNameWithoutExtension(response.FileName)}_fragments.json";
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
