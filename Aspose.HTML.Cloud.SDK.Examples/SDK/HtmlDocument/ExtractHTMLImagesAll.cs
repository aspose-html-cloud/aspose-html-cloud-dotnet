using System;
using System.IO;
using Com.Aspose.Storage.Api;
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
            string folder = "HtmlTemp"; // storage folder name

            string filePath = Path.Combine(CommonSettings.DataFolder, name);
            StorageApi storageApi = new StorageApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
            string storagePath = string.IsNullOrEmpty(folder) ? name : string.Format("{0}/{1}", folder, name);
            if (File.Exists(filePath))
            {
                // upload source file to the cloud storage (default is AmazonS3)
                //filePath = string.Format("file:///{0}", filePath.Replace('\\', '/'));
                storageApi.PutCreate(storagePath, null, null, File.ReadAllBytes(filePath));
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", filePath));

            IDocumentApi docApi = new DocumentApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
            // call SDK method that gets a zip archive with all HTML document images
            Stream stream = docApi.GetDocumentImages(name, null, folder);
            if (stream != null && typeof(FileStream) == stream.GetType())
            {
                string outFile = $"{Path.GetFileNameWithoutExtension(name)}_images.zip";
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
