using System;
using System.IO;

using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlDocument
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to extract the HTML fragments by XPath query 
    /// from the HTML page from Web by its URL.
    /// </summary>
    public class ExtractHtmlFragmentsByCSSSelectorByUrl : ISdkRunner
    {
        public void Run()
        {
            // setup HTML document URL
            var url = "http://www.sukidog.com/jpierre/strings/basics.htm";
            // setup CSS selector to select fragments
            var selector = "p";

            IDocumentApi docApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            // call the SDK method that returns a query result in the response stream.
            var response = docApi.GetDocumentFragmentByCSSSelectorByUrl(url, selector, "plain");
            if (response != null && response.ContentStream != null)
            {
                if (response.Status == "NoContent")
                    Console.WriteLine("Operation succeeded but result is empty");
                else if (response.Status == "OK")
                {
                    Stream stream = response.ContentStream;
                    string outFile = response.FileName;
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
}
