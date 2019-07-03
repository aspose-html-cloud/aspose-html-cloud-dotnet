using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;


namespace Aspose.HTML.Cloud.Examples.SDK.HtmlConvert
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to convert HTML page in the local filesystem passing it to the request stream,
    /// convert it to one of the supported by Aspose.HTML for Cloud and save it to the cloud storage.
    /// </summary>
    public class ConvertHTMLLocalToStorage : ISdkRunner
    {
        private string Format { get; set; }

        public ConvertHTMLLocalToStorage(string format)
        {
            Format = format;
        }

        public void Run()
        {
            string name = "testpage4_embcss.html";
            string path = Path.Combine(CommonSettings.LocalDataFolder, name);
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found in the Data folder", name);

            string folder = "/Html/Testout/Conversion";
            string storage = null;

            int width = 800;
            int height = 1200;
            int leftMargin = 15;
            int rightMargin = 15;
            int topMargin = 15;
            int bottomMargin = 15;
            int resolution = 96;

            string ext = (Format == "tiff") ? "tif" : ((Format == "jpeg") ? "jpg" : Format);
            string outFile = $"{Path.GetFileNameWithoutExtension(name)}_converted_at_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.{ext}";
            string outPath = Path.Combine(folder, outFile).Replace('\\', '/');

            using (Stream srcStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                IConversionApi convApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
                IStorageApi storageApi = new StorageApi((ApiBase)convApi);

                if( !storageApi.FileOrFolderExists(folder, storage))
                {
                    ((IStorageFolderApi)storageApi).CreateFolder(folder, storage);
                }
                AsposeResponse response = null;
                string dataType = Path.GetExtension(name).Replace(".", "");
                // call SDK methods that convert HTML document to supported out format
                switch (Format)
                {
                    case "pdf":
                        outFile += ".pdf";
                        response = convApi.PostConvertDocumentToPdf(
                            srcStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
                        break;
                    case "xps":
                        response = convApi.PostConvertDocumentToXps(
                            srcStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
                        break;
                    case "jpeg":
                    case "bmp":
                    case "png":
                    case "tiff":
                    case "gif":
                        response = convApi.PostConvertDocumentToImage(
                            srcStream, Format, outPath, width, height,
                            leftMargin, rightMargin, topMargin, bottomMargin,
                            resolution, storage);
                        break;
                    default:
                        throw new ArgumentException($"Unsupported output format: {Format}");
                }

                if (response != null && response.Status == "OK")
                {
                    storageApi = new StorageApi((ApiBase)convApi);
                    if (storageApi.FileOrFolderExists(outPath))
                    {
                        Console.WriteLine(string.Format("\nResult file uploaded to: {0}", outPath));
                    }
                }
            }
        }
    }
}
