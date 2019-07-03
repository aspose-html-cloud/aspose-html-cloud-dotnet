using System;
using System.IO;

using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlDocument
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to get all images of the HTML document that is stored
    /// in the cloud storage.
    /// </summary>
    public class ExtractHTMLImagesAll : ISdkRunner
    {

        public void Run()
        {
            string name = "testpage5.html.zip";   // storage file name
            string folder = "/Html/TestData";     // storage folder name

            string filePath = Path.Combine(CommonSettings.LocalDataFolder, name);
            string storageFilePath = Path.Combine(folder, name).Replace('\\', '/');
            if (File.Exists(filePath))
            {
                SdkBaseRunner.UploadToStorage(storageFilePath, filePath);
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", filePath));

            IDocumentApi docApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            // call SDK method that gets a zip archive with all HTML document images
            var response = docApi.GetDocumentImages(name, null, folder);
            if (response != null && response.ContentStream != null && response.Status == "OK")
            {
                Stream stream = response.ContentStream;
                string outFile = $"{Path.GetFileNameWithoutExtension(response.FileName)}_images.zip";
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
