## Conversion

### HTML -> PDF

#### Synchronous conversion of the local file, saving the result in the local folder
```code
using Aspose.HTML.Cloud.Sdk;
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using System;
using System.IO;

namespace ExamplesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string AppSid = "html.cloud";
            string AppKey = "html.cloud";
            string baseUrl = "https://localhost:5001/v4.0/html";

            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string projPath = appDir.Substring(0, appDir.IndexOf("\\bin"));
            string sourceFile = Path.Combine(projPath, "TestSource", "test.html");

            var api = new HtmlApi(appSid : AppSid, appKey : AppKey, baseUrl: baseUrl);
            
            // Convert to single file
            ConverterBuilder convHtmlPdf = new ConverterBuilder()
                .fromLocalFile(sourceFile)
                .to(new PDFConversionOptions())
                .SaveToLocal("test.pdf");

            ConversionResult result = api.Convert(convHtmlPdf);

        }
    }
}

```
