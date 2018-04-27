using System;
using System.IO;
using Com.Aspose.Storage.Model;
using Com.Aspose.Storage.Api;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlConvert
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to convert HTML page in the local filesystem passing it to the request stream,
    /// convert it to one of the supported by Aspose.HTML for Cloud and save it to the cloud storage.
    /// </summary>
    public class ConvertHTMLLocal : ISdkRunner
    {
        private string Format { get; set; }

        public ConvertHTMLLocal(string format)
        {
            Format = format;
        }

        public void Run()
        {
            string name = "testpage4_embcss.html";
            string path = Path.Combine(CommonSettings.DataFolder, name);
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found in the Data folder", name);

            string folder = null;
            string storage = null;

            int width = 800;
            int height = 1200;
            int leftMargin = 15;
            int rightMargin = 15;
            int topMargin = 15;
            int bottomMargin = 15;
            int xResolution = 96;
            int yResolution = 96;

            string ext = (Format == "tiff") ? "tif" : ((Format == "jpeg") ? "jpg" : Format);
            string outFile = $"{Path.GetFileNameWithoutExtension(name)}_converted.{ext}";

            using (Stream srcStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                IConversionApi convApi = new ConversionApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
                Stream response = null;
                // call SDK methods that convert HTML document to supported out format
                switch (Format)
                {
                    case "pdf":
                        outFile += ".pdf";
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
                            xResolution, yResolution, folder, storage);
                        break;
                    default:
                        throw new ArgumentException($"Unsupported output format: {Format}");
                }

                if (response != null && response is FileStream)
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
}
