using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aspose.Storage.Cloud.Sdk;
using Aspose.Storage.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.HTML.Cloud.Examples.SDK;

namespace Aspose.HTML.Cloud.SDK.Examples.SDK.HtmlOcr
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to recognize the image text content and create HTML document of it;
    /// source image is in the storage, and the resulting document is returned in the response stream.
    /// </summary>
    public class RecognizeAndImportToHTML : ISdkRunner
    {
        public void Run()
        {
            string srcName = "ocr_test_1.png";
            string folder = "HtmlTestDoc";
            string storage = null;

            OcrApi ocrApi = new OcrApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
            var response = ocrApi.GetRecognizeAndImportToHtml(srcName, "en", folder, storage);

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
