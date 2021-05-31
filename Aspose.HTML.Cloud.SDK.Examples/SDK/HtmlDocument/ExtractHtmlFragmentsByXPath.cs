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
            // setup HTML document name
            var name = "testpage3_embcss.html";
            // setup XPath query to select fragments
            var xPath = "//ol/li";
            // setup storage folder path where is the source document
            var folder = CommonSettings.StorageDataFolder;
            // Upload source file to cloud storage
            var srcPath = Path.Combine(CommonSettings.LocalDataFolder, name);
            var storagePath = Path.Combine(folder, name).Replace('\\', '/');

            if (File.Exists(srcPath))
            {
                SdkBaseRunner.UploadToStorage(storagePath, srcPath);
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", srcPath));

            IDocumentApi docApi = new HtmlApi(CommonSettings.ClientId, CommonSettings.ClientSecret, CommonSettings.BasePath);
            // call the SDK method that returns a query result in the response stream.
            var response = docApi.GetDocumentFragmentByXPath(name, xPath, "json", null, folder);
            if (response != null && response.ContentStream != null)
            {
                if (response.Status == "NoContent")
                    Console.WriteLine("Operation succeeded but result is empty");
                else if (response.Status == "OK")
                {
                    Stream stream = response.ContentStream;
                    string outFile = response.FileName;
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
}
