using System;
using System.IO;

using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Client.Authentication;

namespace Aspose.HTML.Cloud.Examples.SDK.ExternalJwtAuth
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to use external JWT token for authorization 
    /// on the example of getting images from the HTML document.
    /// </summary>
    public class ExtractHTMLImages_ExtJwtToken : ExternalJwtAuthExampleBase, ISdkRunner
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

            // here the JWT token is acquired with its issue date and expiration period 
            JwtToken token = GetAuthToken();

            // constructor that accepts a token as parameter  
            // 14.10.2019 * changed to constructor accepting token as a string
            ///IDocumentApi docApi = new HtmlApi(token.Token, CommonSettings.BasePath);
            IDocumentApi docApi = new HtmlApi(token.Token, "https://api-qa.aspose.cloud");
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
