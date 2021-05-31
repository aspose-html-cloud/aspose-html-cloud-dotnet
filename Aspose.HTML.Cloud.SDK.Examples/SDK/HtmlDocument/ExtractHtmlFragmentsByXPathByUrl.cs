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
    public class ExtractHtmlFragmentsByXPathByUrl : ISdkRunner
    {
        public void Run()
        {
            // setup HTML document URL
            var url = "http://www.sukidog.com/jpierre/strings/basics.htm";
            var name = Path.GetFileName(url);
            // setup XPath query to select fragments
            var xpath = "//p";
 
            IDocumentApi docApi = new HtmlApi(CommonSettings.ClientId, CommonSettings.ClientSecret, CommonSettings.BasePath);
            // call the SDK method that returns a query result in the response stream.
            var response = docApi.GetDocumentFragmentByXPathByUrl(url, xpath, "plain");
            if (response != null && response.ContentStream != null)
            {
                if (response.Status == "NoContent")
                    Console.WriteLine("Operation succeeded but result is empty");
                else if (response.Status == "OK")
                {
                    Stream stream = response.ContentStream;
                    string fname = response.FileName;
                    string outFile = (string.IsNullOrEmpty(fname)) ? $"{Path.GetFileNameWithoutExtension(name)}_fragments.txt" : fname;
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
