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
- English to Chinese
* Extraction of HTML fragments using XPath queries
* Extraction of all HTML document images in a ZIP archive
* Recognition of text content of an image using the OCR service and its import into HTML document.
* Recognition of text content of an image, import into HTML document with further translation to other languages.
* Detection of keywords in the HTML text content.

See [API Reference](https://apireference.aspose.cloud/html/) for full API specification.

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

To run tests, first modify the Settings\servercreds.json file setting up your AppSID & AppKey that you have obtained before (see Prerequisites) and basePath if it differs from http://api.aspose.cloud.

To run examples, modify the Aspose.HTML.Cloud.SDK.Examples\App.config file setting up AppSID, AppKey, and optionally DataPath.

### Sample usage

The example below shows how your application have to translate the HTML document located by its URL using Aspose.HTML-Cloud library:

```csharp
using System;
using System.IO;
using Com.Aspose.Storage.Api;
using Com.Aspose.Storage.Model;
using Aspose.Html.Cloud.Sdk.Api;

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


## Documentation for API Endpoints

All URIs are relative to *https://api.aspose.cloud/v1.1*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*ConversionApi* | [**GetConvertDocumentToImage**](docs/ConversionApi.md#GetConvertDocumentToImage) | **GET** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format.
*ConversionApi* | [**GetConvertDocumentToImageByUrl**](docs/ConversionApi.md#GetConvertDocumentToImageByUrl) | **GET** /html/convert/image/{outFormat} | Convert the HTML page from the web by its URL to the specified image format.
*ConversionApi* | [**GetConvertDocumentToPdf**](docs/ConversionApi.md#GetConvertDocumentToPdf) | **GET** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF.
*ConversionApi* | [**GetConvertDocumentToPdfByUrl**](docs/ConversionApi.md#GetConvertDocumentToPdfByUrl) | **GET** /html/convert/pdf | Convert the HTML page from the web by its URL to PDF.
*ConversionApi* | [**GetConvertDocumentToXps**](docs/ConversionApi.md#GetConvertDocumentToXps) | **GET** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS.
*ConversionApi* | [**GetConvertDocumentToXpsByUrl**](docs/ConversionApi.md#GetConvertDocumentToXpsByUrl) | **GET** /html/convert/xps | Convert the HTML page from the web by its URL to XPS.
*ConversionApi* | [**PutConvertDocumentToImage**](docs/ConversionApi.md#PutConvertDocumentToImage) | **PUT** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format and save it to storage.
*ConversionApi* | [**PutConvertDocumentToImage**](docs/ConversionApi.md#PutConvertDocumentToImage_1) | **PUT** /html/convert/image/{outFormat} | Convert the HTML document from the request stream to the specified image format and save it to storage.
*ConversionApi* | [**PutConvertDocumentToPdf**](docs/ConversionApi.md#PutConvertDocumentToPdf) | **PUT** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF and save it to storage.
*ConversionApi* | [**PutConvertDocumentToPdf**](docs/ConversionApi.md#PutConvertDocumentToPdf_1) | **PUT** /html/convert/pdf | Convert the HTML document from the request stream to PDF and save it to storage.
*ConversionApi* | [**PutConvertDocumentToXps**](docs/ConversionApi.md#PutConvertDocumentToXps) | **PUT** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS and save it to storage.
*ConversionApi* | [**PutConvertDocumentToXps**](docs/ConversionApi.md#PutConvertDocumentToXps_1) |  **PUT** /html/convert/xps Convert the HTML document from the request stream to XPS and save it to storage.
*DocumentApi* | [**GetDocument**](docs/DocumentApi.md#GetDocument) | **GET** /html/{name} | Return the HTML document by the name from default or specified storage.
*DocumentApi* | [**GetDocumentFragmentByXPath**](docs/DocumentApi.md#GetDocumentFragmentByXPath) | **GET** /html/{name}/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query. 
*DocumentApi* | [**GetDocumentFragmentByXPathByUrl**](docs/DocumentApi.md#GetDocumentFragmentByXPathByUrl) | **GET** /html/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query - from a Web page by its URL. 
*DocumentApi* |[**GetDocumentFragmentByCSSSelector**](docs/DocumentApi.md#GetDocumentFragmentByCSSSelector) | **GET** /html/{name}/fragments/css/{outFormat} | Return list of HTML fragments matching the specified CSS selector
*DocumentApi* |[**GetDocumentFragmentByCSSSelectorByUrl**](docs/DocumentApi.md#GetDocumentFragmentByCSSSelectorByUrl) | **GET** /html/fragments/css/{outFormat} | Return list of HTML fragments matching the specified CSS selector - from a Web page by its URL. 
*DocumentApi* | [**GetDocumentImages**](docs/DocumentApi.md#GetDocumentImages) | **GET** /html/{name}/images/all | Return all HTML document images packaged as a ZIP archive.
*DocumentApi* | [**GetDocumentImagesByUrl**](docs/DocumentApi.md#GetDocumentImagesByUrl) | **GET** /html/images/all | Return all HTML document images packaged as a ZIP archive - from a Web page by its URL.
*TranslationApi* | [**GetTranslateDocument**](docs/TranslationApi.md#GetTranslateDocument) | **GET** /html/{name}/translate/{srcLang}/{resLang} | Translate the HTML document specified by the name from default or specified storage.
*TranslationApi* | [**GetTranslateDocumentByUrl**](docs/TranslationApi.md#GetTranslateDocumentByUrl) | **GET** /html/translate/{srcLang}/{resLang} | Translate the HTML document specified by its URL.
*OcrApi* | [**GetRecognizeAndImportToHtml**](docs/OcrApi.md#GetRecognizeAndImportToHtml) | **GET** /html/{name}/ocr/import | Recognize text content from the source image file by its name from default or specified storage, and create an HTML document.
*OcrApi* | [**GetRecognizeAndTranslateToHtml**](docs/OcrApi.md#GetRecognizeAndTranslateToHtml) | **GET** /html/{name}/ocr/translate/{srcLang}/{resLang} | Recognize text content from the source image file by its name from default or specified storage, and create an HTML document translated to the specified language.
*SummarizationApi* | [**GetDetectHtmlKeywords**](docs/SummarizationApi.md#GetDetectHtmlKeywords) | **GET** /html/{name}/summ/keywords | Detect keywords of the HTML document specified by the name from default or specified storage.
*SummarizationApi* | [**GetDetectHtmlKeywordsByUrl**](docs/SummarizationApi.md#GetDetectHtmlKeywordsByUrl) | **GET** /html/summ/keywords | Detect keywords of the HTML document specified by its URL.



## Resources

- **Website:** [www.aspose.com](http://www.aspose.cloud)
- **Product Home:** [Aspose.HTML for Cloud](https://products.aspose.cloud/html/cloud)
- **Documentation:** [Aspose.HTML for Cloud Documentation](https://docs.aspose.cloud/display/htmlcloud/Home)
- **Forum:** [Aspose.HTML for Cloud Forum](https://forum.aspose.cloud/c/html)
- **Blog:** [Aspose.HTML for Cloud Blog](https://blog.aspose.cloud/category/aspose-products/aspose-html-cloud/)


## Contact Us
Your feedback is very important to us. Please feel free to contact us using our [Support Forums](https://forum.aspose.cloud/c/html).
