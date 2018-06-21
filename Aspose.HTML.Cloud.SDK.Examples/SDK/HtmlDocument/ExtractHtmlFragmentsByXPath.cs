using System;
using System.IO;
using Aspose.Storage.Cloud.Sdk;
using Aspose.Storage.Cloud.Sdk.Api;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;

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
            var srcPath = Path.Combine(CommonSettings.DataFolder, name);
            if (File.Exists(srcPath))
            {
                SdkBaseRunner.uploadToStorage(name, CommonSettings.DataFolder);
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", srcPath));

            IDocumentApi docApi = new DocumentApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
            // call the SDK method that returns a query result in the response stream.
            Stream stream = docApi.GetDocumentFragmentByXPath(name, xPath, "json", null, null);
            if (stream != null && typeof(FileStream) == stream.GetType())
            {
                string outFile = $"{Path.GetFileNameWithoutExtension(name)}_fragments.json";
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
