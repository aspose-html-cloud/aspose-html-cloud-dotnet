using System;
using System.IO;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api;
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
            var name = "testpage4_embcss.html";
            var srcPath = Path.Combine(CommonSettings.DataFolder, name);
            string folder = " HtmlTestFolder";
            string storage = null;
            string storagePath = (folder == null) ? name : Path.Combine(folder, name).Replace('\\', '/');

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
                SdkBaseRunner.UploadToStorage(storagePath, CommonSettings.DataFolder);
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", srcPath));

            IConversionApi convApi = new ConversionApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);

            Stream response = null;
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
                case "jpeg":
                case "bmp":
                case "png":
                case "tiff":
                    response = convApi.GetConvertDocumentToImage(
                        name, Format, width, height,
                        leftMargin, rightMargin, topMargin, bottomMargin,
                        resolution, folder, storage);
                    break;
                default:
                    throw new ArgumentException($"Unsupported output format: {Format}");
            }

            if (response != null && typeof(FileStream) == response.GetType())
            {
                string outPath = Path.Combine(CommonSettings.OutDirectory, outFile);
                using (FileStream fstr = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                {
                    response.Position = 0;
                    response.CopyTo(fstr);
                    fstr.Flush();
                    Console.WriteLine(string.Format("\nResult file downloaded to: {0}", outPath));
                }
            }
        }
    
    }
}
