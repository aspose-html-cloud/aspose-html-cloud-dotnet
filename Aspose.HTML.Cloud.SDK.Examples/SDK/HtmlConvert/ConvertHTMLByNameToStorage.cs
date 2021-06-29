﻿using System;
using System.IO;
//using Aspose.Storage.Cloud.Sdk.Model;
//using Aspose.Storage.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

using Aspose.HTML.Cloud.Examples.SDK;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlConvert
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to convert HTML page in the local filesystem uploading it to Aspose cloud storage 
    /// and using its name and storage folder path; result is saved to the cloud storage.
    /// </summary>
    public class ConvertHTMLByNameToStorage : ISdkRunner
    {
        protected string Format { get; set; }

        protected string FileName { get; set; }

        protected virtual bool CheckIfStorageFileExists { get; set; } = true;

        public ConvertHTMLByNameToStorage(string format)
        {
            Format = format;
            FileName = "testpage4_embcss.html";
        }

        public void Run()
        {
            var name = FileName;
            var srcPath = Path.Combine(CommonSettings.LocalDataFolder, name);
            string folder = CommonSettings.StorageDataFolder;
            string storage = null;
            // setup storage folder path where the result file will be uploaded to 
            string outFolder = "/Html/Testout/Conversion";

            int width = 800;
            int height = 1200;
            int leftMargin = 15;
            int rightMargin = 15;
            int topMargin = 15;
            int bottomMargin = 15;
            int resolution = 96;

            string storagePath = (folder == null) ? name : Path.Combine(folder, name).Replace('\\', '/');

            string ext = (Format == "tiff") ? "tif" : ((Format == "jpeg") ? "jpg" : Format);
            string outFile = $"{Path.GetFileNameWithoutExtension(name)}_converted_at_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.{ext}";
            string outPath = Path.Combine(outFolder, outFile).Replace('\\', '/');

            if(CheckIfStorageFileExists)
            {
                if (File.Exists(srcPath))
                {
                    SdkBaseRunner.UploadToStorage(storagePath, srcPath);
                }
                else
                    throw new Exception(string.Format("Error: file {0} not found.", srcPath));
            }

            IConversionApi convApi = new HtmlApi(CommonSettings.ClientId, CommonSettings.ClientSecret, CommonSettings.BasePath);
            AsposeResponse response = null;
            // call SDK methods that convert HTML document to supported out format
            switch (Format)
            {
                case "pdf":
                    outFile += ".pdf";
                    response = convApi.PutConvertDocumentToPdf(
                        name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
                    break;
                case "xps":
                    response = convApi.PutConvertDocumentToXps(
                        name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
                    break;
                case "jpeg":
                case "bmp":
                case "png":
                case "tiff":
                case "gif":
                    response = convApi.PutConvertDocumentToImage(
                        name, Format, outPath, width, height,
                        leftMargin, rightMargin, topMargin, bottomMargin,
                        resolution, folder, storage);
                    break;
                case "md":
                    response = convApi.PutConvertDocumentToMarkdown(name, outPath, false);
                    break;
                default:
                    throw new ArgumentException($"Unsupported output format: {Format}");
            }

            if (response != null && response.Status == "OK")
            {
                Console.WriteLine(string.Format("\nResult file uploaded to: {0}", outPath));
            }
        }
    }
}
