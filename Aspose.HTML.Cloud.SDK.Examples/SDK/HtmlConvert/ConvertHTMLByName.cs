using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.HTML.Cloud.Examples.SDK;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlConvert
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to convert HTML page in the local filesystem uploading it to default Aspose cloud storage 
    /// and using its name and storage folder path; result is returned in the response stream and can be saved in the local file system.
    /// </summary>
    public class ConvertHTMLByName : ISdkRunner
    {
        private string Format { get; set; }

        public ConvertHTMLByName(string format)
        {
            Format = format;
        }

        public void Run()
        {
            // setup HTML document name
            var name = "testpage4_embcss.html";
            // setup local document path
            var srcPath = Path.Combine(CommonSettings.LocalDataFolder, name);
            // setup storage folder where the source document should be present
            string folder = CommonSettings.StorageDataFolder;
            // setup storage name (null for default storage)
            string storage = null;
            string storagePath = (folder == null) ? name : Path.Combine(folder, name).Replace('\\', '/');

            // setup resulting file parameters
            int width = 800;
            int height = 1200;
            int leftMargin = 15;
            int rightMargin = 15;
            int topMargin = 15;
            int bottomMargin = 15;
            int resolution = 96;

            string ext = (Format == "tiff") ? "tif" : ((Format == "jpeg") ? "jpg" : Format);
            string outFile = $"{Path.GetFileNameWithoutExtension(name)}_converted.{ext}";
            if (File.Exists(srcPath))
            {
                SdkBaseRunner.UploadToStorage(storagePath, srcPath);
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", srcPath));

            IConversionApi convApi = new HtmlApi(CommonSettings.ClientId, CommonSettings.ClientSecret,  CommonSettings.BasePath, CommonSettings.AuthPath);

            StreamResponse response = null;
            // call SDK methods that convert HTML document to supported out format
            switch (Format)
            {
                case "pdf":
                    outFile += ".pdf";
                    // call the SDK method that returns a query result in the response stream
                    response = convApi.GetConvertDocumentToPdf(
                        name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
                    break;
                case "xps":
                    response = convApi.GetConvertDocumentToXps(
                        name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
                    break;
                case "doc":
                    response = convApi.GetConvertDocumentToDoc(
                        name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
                    break;
                case "jpeg":
                case "bmp":
                case "png":
                case "tiff":
                case "gif":
                    response = convApi.GetConvertDocumentToImage(
                        name, Format, width, height,
                        leftMargin, rightMargin, topMargin, bottomMargin,
                        resolution, folder, storage);
                    break;
                case "md":
                    response = convApi.GetConvertDocumentToMarkdown(name, false);
                    break;
                default:
                    throw new ArgumentException($"Unsupported output format: {Format}");
            }

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
