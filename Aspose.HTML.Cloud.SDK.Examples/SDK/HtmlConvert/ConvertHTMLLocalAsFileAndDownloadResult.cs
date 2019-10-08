using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended;
using Aspose.HTML.Cloud.Examples.SDK;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlConvert
{
    public class ConvertHTMLLocalAsFileAndDownloadResult : ISdkRunner
    {
        private string Format { get; set; }

        public ConvertHTMLLocalAsFileAndDownloadResult(string format)
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

            int? width = null;
            int? height = null;
            int? leftMargin = null;
            int? rightMargin = null;
            int? topMargin = null;
            int? bottomMargin = null;
            int? resolution = null;

            string ext = (Format == "tiff") ? "tif" : ((Format == "jpeg") ? "jpg" : Format);
            string outFile = $"{Path.GetFileNameWithoutExtension(name)}_converted_at_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.{ext}";
            string outPath = Path.Combine(folder, outFile).Replace('\\', '/');

            IConversionApiEx convApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);

            string dataType = Path.GetExtension(name).Replace(".", "");
            // call SDK methods that convert HTML document to supported out format
            StreamResponse response = null;
            switch (Format)
            {
                case "pdf":
                    response = convApi.PostConvertDocumentToPdfAndDownload(path, outPath,
                        width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
                    break;
                case "xps":
                    response = convApi.PostConvertDocumentToXpsAndDownload(path, outPath,
                        width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
                    break;
                case "md":
                    response = convApi.PostConvertDocumentToMarkdownAndDownload(path, outPath, false, storage);
                    break;
                case "jpeg":
                case "bmp":
                case "png":
                case "tiff":
                case "gif":
                    response = convApi.PostConvertDocumentToImageAndDownload(
                        path, Format, outPath, width, height,
                        leftMargin, rightMargin, topMargin, bottomMargin,
                        resolution, storage);
                    break;
                default:
                    throw new ArgumentException($"Unsupported output format: {Format}");
            }

            if (response != null && response.Status == "OK")
            {
                string localOutPath = Path.Combine(CommonSettings.OutDirectory, outFile);

                Stream stream = response.ContentStream;
                using (FileStream fstr = new FileStream(localOutPath, FileMode.Create, FileAccess.Write))
                {
                    stream.Position = 0;
                    stream.CopyTo(fstr);
                    fstr.Flush();
                    Console.WriteLine(string.Format("\nResult file downloaded to: {0}", localOutPath));
                }
            }


        }
    }
}
