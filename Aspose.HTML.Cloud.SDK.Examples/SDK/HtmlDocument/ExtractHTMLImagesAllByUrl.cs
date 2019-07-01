using System;
using System.IO;

using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;


namespace Aspose.HTML.Cloud.Examples.SDK.HtmlDocument
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to get all images of the HTML page from Web by its URL.
    /// </summary>
    public class ExtractHTMLImagesAllByUrl : ISdkRunner
    {
        public void Run()
        {
            var url = "http://www.sukidog.com/jpierre/strings/basics.htm";
            var name = "basics.htm";

            IDocumentApi docApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            // call SDK method that gets a zip archive with all HTML document images
            var response = docApi.GetDocumentImagesByUrl(url);
            if (response != null && response.ContentStream != null && response.Status == "OK")
            {
                Stream stream = response.ContentStream;
                string fname = response.FileName;
                string outFile = fname ?? $"{name}_images.zip";
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
