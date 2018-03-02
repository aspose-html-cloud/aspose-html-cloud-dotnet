<img src="Data/header.png">

# Aspose.HTML Cloud SDK for .NET [![NuGet](https://img.shields.io/nuget/v/Aspose.HTML-Cloud.svg)](https://www.nuget.org/packages/Aspose.HTML-Cloud/)
This repository contains Aspose.HTML Cloud SDK for .NET source code. This SDK allows you to work with Aspose.HTML Cloud REST APIs in your .NET applications quickly and easily, with zero initial cost.

# Key Features
* Conversion of HTML document into various formats; PDF, XPS document formats and JPEG, PNG, BMP, TIFF raster graphics formats are supported
* Conversion of MHTML document into the same formats that are supported for HTML
* Translation of HTML document between various human languages; the following language pairs are currently supported:
- English to German
- English to French
- English to Russian
- German to English
- Russian to English
* Extraction of HTML fragments using XPath queries
* Extraction of all HTML document images in a ZIP archive
* Recognition of text content of an image using the OCR service and its import into HTML document.
* Recognition of text content of an image, import into HTML document with further translation to other languages.

See [API Reference](https://apireference.aspose.cloud/words/) for full API specification.

## How to use the SDK?
The complete source code is available in this repository folder. You can either directly use it in your project via source code or get [NuGet distribution](https://www.nuget.org/packages/Aspose.HTML-Cloud/) (recommended). For more details, please visit our [documentation website](https://docs.aspose.cloud/display/htmlcloud/Available+SDKs#AvailableSDKs-.NET).


### Prerequisites

To use Aspose HTML for Cloud .NET SDK you need to register an account with [Aspose Cloud](https://www.aspose.cloud/) and lookup/create App Key and SID at [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps). There is free quota available. For more details, see [Aspose Cloud Pricing](https://purchase.aspose.cloud/pricing).


### Installation

#### Install Aspose.HTML-Cloud via NuGet

From the command line:

	nuget install Aspose.HTML-Cloud

From Package Manager:

	PM> Install-Package Aspose.HTML-Cloud

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "Aspose.HTML-Cloud".
5. Click on the Aspose.HTML-Cloud package, select the appropriate version in the right-tab and click *Install*.

### Run tests and examples.

To run tests, first modify the Settings\servercreds.json file setting up your AppSID & AppKey that you have obtained before (see Prerequisites).

To run examples, modify the Aspose.HTML.Cloud.SDK.Examples\App.config file setting up AppSID, AppKey, and optionally DataPath.

### Sample usage

The example below shows how your application have to translate the HTML document located by its URL using Aspose.HTML-Cloud library:

```csharp
using System;
using System.IO;
using Com.Aspose.Storage.Api;
using Com.Aspose.Storage.Model;
using Com.Aspose.Html.Api;

namespace MyAppNamespace
{
    public class Example
    {
        string APPKEY = "XXXXXXX"; // put here the app Key
        string APPSID = "XXXXXXX"; // put here the app SID
        string BASEPATH = "https://api.aspose.cloud/v.1.1";

        string sourceUrl = "https://www.le.ac.uk/oerresources/bdra/html/page_02.htm";
        // 
        string source_lang = "en";  // source language
        string result_lang = "fr";  // result language

        string resultFile = "page_02_en_fr.htm";

        static void Main(string[] args)
        {
            // create instance of the API class
            ITranslationApi trApi = new TranslationApi(APPKEY, APPSID, BASEPATH);
            // translate the HTML document by its URL
            Stream stream = trApi.GetTranslateDocumentByUrl(sourceUrl, source_lang, result_lang);
            // copy result to file 
            using (FileStream fs = new FileStream("page_02_en_fr.htm", FileMode.Create, FileAccess.Write))
            {
                stream.Position = 0;
                stream.CopyTo(fs);
                fs.Flush();
            }
        }
    }
}
```

## Dependencies
- .NET Framework 4.0 or later
- [Json.NET (9.0.1 or later)](https://www.nuget.org/packages/Newtonsoft.Json/)
- [Aspose.Storage-Cloud (1.0.10 or later)] (https://www.nuget.org/packages/Aspose.Storage-Cloud/)


## Roadmap

Known issues that we are set to fix soon:
* Get supported language pairs - issue of Aspose.HTML.Cloud; will be fixed in the next versions.

In the upcoming releases, we are set to implement a number of new features:
* Add more language pairs to translate: French-to-English, English-to-Japanese, Japanese-to-English and some others.
* Improve quality of translation.



## Resources

- **Website:** [www.aspose.com](http://www.aspose.com)
- **Product Home:** [Aspose.HTML for Cloud](https://products.aspose.cloud/html/cloud)
- **Documentation:** [Aspose.HTML for Cloud Documentation](https://docs.aspose.cloud/display/htmlcloud/Home)
- **Forum:** [Aspose.HTML for Cloud Forum](https://forum.aspose.com/c/html)
- **Blog:** [Aspose.HTML for Cloud Blog](http://www.aspose.com/blogs/aspose-products/aspose-html-product-family.html)


## Contact Us
Your feedback is very important to us. Please feel free to contact us using our [Support Forums](https://forum.aspose.cloud/c/html).
