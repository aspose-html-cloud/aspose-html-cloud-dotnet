using System;
using System.IO;
using Com.Aspose.Storage.Model;
using Com.Aspose.Storage.Api;
using Com.Aspose.Html.Api;
using Com.Aspose.Html.Api.Interfaces;
using Com.Aspose.Html.NativeClient;

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
                NativeRestResponse response = null;
                // call SDK methods that convert HTML document to supported out format
                switch (Format)
                {
                    case "pdf":
                        outFile += ".pdf";
                        response = convApi.PutConvertDocumentToPdf(
                            srcStream, outFile, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
                        break;
                    case "xps":
                        response = convApi.PutConvertDocumentToXps(
                            srcStream, outFile, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
                        break;
                    case "jpeg":
                    case "bmp":
                    case "png":
                    case "tiff":
                        response = convApi.PutConvertDocumentToImage(
                            srcStream, Format, outFile, width, height, 
                            leftMargin, rightMargin, topMargin, bottomMargin,
                            xResolution, yResolution, storage);
                        break;
                    default:
                        throw new ArgumentException($"Unsupported output format: {Format}");
                }

                if (response != null
                    && (string)response.Content == "storage"
                    && response.ContentType == NativeRestResponse.RespContentType.FileName)
                {
                    // get the result file name from response object
                    string outFileName = response.ContentName;
                    StorageApi storageApi = new StorageApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
                    FileExistResponse resp2 = storageApi.GetIsExist(outFileName, null, null);
                    if (resp2.FileExist.IsExist)
                    {
                        // if result file exists in the storage, try to downloa it to the local file system
                        var resp3 = storageApi.GetDownload(outFileName, null, null);
                        if (resp3.ResponseStream != null)
                        {
                            string outPath = Path.Combine(CommonSettings.OutDirectory, outFileName);
                            using (FileStream fstr = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                            {
                                fstr.Write(resp3.ResponseStream, 0, resp3.ResponseStream.Length);
                                fstr.Flush();
                                Console.WriteLine(string.Format("\nResult file downloaded to: {0}", outPath));
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: result file wasn't saved to storage.");
                    }
                }
            }
        }
    }
}
