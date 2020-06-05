using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.Configuration
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to apply default HTTP request headers by Configuration object.
    class ConvertHTMLByUrl_DefaultHeaders : ISdkRunner
    {
        private string Format { get; set; }

        public ConvertHTMLByUrl_DefaultHeaders(string format)
        {
            Format = format;
        }

        public string FileUrl { get; set; }

        public void Run()
        {
            FileUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_01.htm";
            //FileUrl = @"https://docs.gitlab.com/ee/README.html";
            string name = "page_01.htm";
            string ext = (Format == "tiff") ? "tif"
                : ((Format == "jpeg") ? "jpg"
                : ((Format == "mhtml") ? "mht" : Format));
            string outFile = $"{Path.GetFileNameWithoutExtension(name)}_converted.{ext}";
            var conf = new Aspose.Html.Cloud.Sdk.Client.Configuration()
            {
                AppSid = CommonSettings.AppSID,
                AppKey = CommonSettings.AppKey,
                ApiBaseUrl = CommonSettings.BasePath,
                AuthUrl = CommonSettings.AuthPath,
                ApiVersion = "3.0"
            };
            // define some headers that will be added to an HTTP request by each call of configured API object
            conf.AddDefaultHeader("x_custom_header_1", "header1");
            conf.AddDefaultHeader("x_custom_header_2", "header2");

            IConversionApi convApi = new HtmlApi(conf);
            StreamResponse response = null;
            // call SDK methods that convert HTML document to supported out format
            switch (Format)
            {
                case "pdf":
                    response = convApi.GetConvertDocumentToPdfByUrl(FileUrl, 1200, 800);
                    break;
                default:
                    throw new ArgumentException($"Unsupported output format: {Format}");
            }

            if (response != null && response.ContentStream != null && response.Status == "OK")
            {
                string respFileName = response.FileName;
                string outPath = Path.Combine(CommonSettings.OutDirectory, respFileName ?? outFile);

                Stream stream = response.ContentStream;
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
