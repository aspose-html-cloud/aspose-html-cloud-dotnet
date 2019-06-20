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
            var url = "http://www.sukidog.com/jpierre/strings/basics.htm";
            var name = "basics.htm";
            var xpath = ".//p";

            IDocumentApi docApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            // call the SDK method that returns a query result in the response stream.
            var response = docApi.GetDocumentFragmentByXPathByUrl(url, xpath, "plain");
            if (response != null && response.ContentStream != null)
            {
                Stream stream = response.ContentStream;
                string outFile = $"{Path.GetFileNameWithoutExtension(name)}_fragments.txt";
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
