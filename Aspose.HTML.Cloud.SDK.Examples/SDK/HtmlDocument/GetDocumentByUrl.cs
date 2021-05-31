using System;
using System.IO;

using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Client;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlDocument
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to download a Web page by its URL with linked resources
    /// and save it locally as a ZIP archive.
    public class GetDocumentByUrl : ISdkRunner
    {
        public void Run()
        {
            // setup web page URL to download
            string sourceUrl = "https://www.le.ac.uk/oerresources/bdra/html/page_01.htm";
            // setup local file system directory to save the result file.
            string destDir = @"d:\testout";

            var conf = new Configuration()
            {
                ClientId = CommonSettings.ClientId,
                ClientSecret = CommonSettings.ClientSecret,
                ApiBaseUrl = CommonSettings.BasePath,
                AuthUrl = CommonSettings.AuthPath,
                ApiVersion = "3.0"
            };
            IDocumentApi api = new HtmlApi(conf);
            var response = api.GetDocumentByUrl(sourceUrl);
            if(response.Status == "OK")
            {
                var destPath = Path.Combine(destDir, response.FileName);
                using(FileStream fstr = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                {
                    response.ContentStream.Position = 0;
                    response.ContentStream.CopyTo(fstr);
                    fstr.Flush();
                    Console.WriteLine($"Page by URL: {sourceUrl}\r\n ---- downloaded to: {destPath}");
                }
            }
        }
    }
}
