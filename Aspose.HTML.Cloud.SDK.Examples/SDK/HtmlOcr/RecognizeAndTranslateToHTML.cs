using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.HTML.Cloud.Examples.SDK;

namespace Aspose.HTML.Cloud.SDK.Examples.SDK.HtmlOcr
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to recognize the image text content, create an HTML document of it and translate it to specified language;
    /// (currently only English is supported as OCR engine language);
    /// source image is in the storage, and the resulting document is returned in the response stream.
    /// </summary>
    public class RecognizeAndTranslateToHTML : ISdkRunner
    {
        string SrcLang { get; set; }
        string ResLang { get; set; }

        public RecognizeAndTranslateToHTML(string srclang, string reslang)
        {
            SrcLang = srclang;
            ResLang = reslang;
        }

        public void Run()
        {
            string srcName = "ocr_test_1.png";
            string folder = "HtmlTestDoc";
            string storage = null;

            OcrApi ocrApi = new OcrApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
            var response = ocrApi.GetRecognizeAndTranslateToHtml(srcName, SrcLang, ResLang, folder, storage);

            if (response != null && response.ContentStream != null)
            {
                Stream stream = response.ContentStream;
                string name = response.FileName;
                string outPath = Path.Combine(CommonSettings.OutDirectory, Path.GetFileName(name));
                using (FileStream fstr = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fstr);
                    fstr.Flush();
                    Console.WriteLine(string.Format("File '{0}' downloaded to: {1}", Path.GetFileName(name), outPath));
                }
            }
        }
    }
}
