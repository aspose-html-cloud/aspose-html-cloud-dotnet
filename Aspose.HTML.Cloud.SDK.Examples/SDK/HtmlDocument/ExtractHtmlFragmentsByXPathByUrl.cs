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
            var url = "https://google.com";
            //var url = "http://www.sukidog.com/jpierre/strings/basics.htm";
            var name = Path.GetFileName(url);
            // setup XPath query to select fragments
            //var xpath = "//p";
            var xpath = "//body";

            // setup output format
            //var outformat = "plain";
            var outformat = "json";

            //string basePath = "https://api-qa.aspose.cloud/v3.0";
            //string authToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE1NzI5NTc3OTEsImV4cCI6MTU3MzA0NDE5MSwiaXNzIjoiaHR0cHM6Ly9hcGktcWEuYXNwb3NlLmNsb3VkIiwiYXVkIjpbImh0dHBzOi8vYXBpLXFhLmFzcG9zZS5jbG91ZC9yZXNvdXJjZXMiLCJhcGkucGxhdGZvcm0iLCJhcGkucHJvZHVjdHMiXSwiY2xpZW50X2lkIjoiODBlMzJjYTUtYTgyOC00NmE0LTlkNTQtNzE5OWRmZDM3NjRhIiwiY2xpZW50X2lkU3J2SWQiOiIiLCJzY29wZSI6WyJhcGkucGxhdGZvcm0iLCJhcGkucHJvZHVjdHMiXX0.iVzfHF-SwAAgIMcc81rYYp4SuNe8FVkFoAii8vtHyAMJ28BJdRPdKI_szs1X5UtajnJ0mJGW4mol_VHdtSStYFA4leyNUmdF-ySYJ89PA28UaoqL06whG-mUjuMM8QlmZOw4WpSGWR-uXyMxHKrh4HnAssol7IirycEuNIVJzmG52BkRd-08ndxUacxBou-nW7KVbth0IVq4Ik2Zd8hOYmX5zcyCVUCuUe-jplceZ7BZ2pUlsofajiaOYS3J6wgKC72RSXsD1hPc0EzqtP6EiqyRuRofUgCuVDuaMODuAJqNA5q_LwPmrqk9WmvGYZpMRbr6O_DE4w67WF3hw4PfTw";
            //IDocumentApi docApi = new HtmlApi(authToken, basePath);

            IDocumentApi docApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            // call the SDK method that returns a query result in the response stream.
            var response = docApi.GetDocumentFragmentByXPathByUrl(url, xpath, outformat);
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
