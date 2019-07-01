using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;


namespace Aspose.HTML.Cloud.Examples.SDK.HtmlTranslate
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to translate HTML page by its URL 
    /// and to get the result in the response stream.
    /// </summary>
    public class TranslateHTMLByUrl : ISdkRunner
    {
        string SrcLang { get; set; }
        string ResLang { get; set; }

        public TranslateHTMLByUrl(string srclang, string reslang)
        {
            SrcLang = srclang;
            ResLang = reslang;
        }

        public void Run()
        {
            // setup the source HTML document URL
            string srcUrl = "https://stallman.org/sayings.html";
            //string srcUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_01.htm";

            ITranslationApi transApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            StreamResponse response = transApi.GetTranslateDocumentByUrl(srcUrl, SrcLang, ResLang);
            Stream stream = response.ContentStream;

            if (stream != null && response.Status == "OK")
            {
                string name = response.FileName;
                string outPath = Path.Combine(CommonSettings.OutDirectory, Path.GetFileName(name));
                using (FileStream fstr = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fstr);
                    fstr.Flush();
                    Console.WriteLine(string.Format("File '{0}' downloaded to: {1}", Path.GetFileName(name), outPath));
                }
            }
            stream.Close();
            stream.Dispose();
        }
    }
}
