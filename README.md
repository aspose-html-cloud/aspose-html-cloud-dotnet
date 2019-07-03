<img src="Data/header.png">

# Aspose.HTML Cloud SDK for .NET [![NuGet](https://img.shields.io/nuget/v/Aspose.HTML-Cloud.svg)](https://www.nuget.org/packages/Aspose.HTML-Cloud/)
This repository contains Aspose.HTML Cloud SDK for .NET source code. This SDK allows you to work with Aspose.HTML Cloud REST APIs in your .NET applications quickly and easily, with zero initial cost.


# Key Features
* Conversion of HTML document into various formats; PDF, XPS, Markdown document formats and JPEG, PNG, BMP, TIFF raster graphics formats are supported
* Conversion of MHTML document into the same formats that are supported for HTML
* Conversion of HTML document from Web by its URLto MHTML document format
* Merging HTML/XHTML templates with external data source; XML is supported as source data format
* Translation of HTML document between various human languages; the following language pairs are currently supported:
- English to German
- English to French
- English to Russian
- German to English
- Russian to English
- English to Chinese
* Downloading of HTML page from Web by its URL with its linked resources as single ZIP archive
* Extraction of HTML fragments using XPath queries
* Extraction of HTML fragments using CSS selectors
* Extraction of all HTML document images in a ZIP archive
* Recognition of text content of an image using the OCR service and its import into HTML document.
* Recognition of text content of an image, import into HTML document with further translation to other languages.
* Detection of keywords in the HTML text content.

See [API Reference](https://apireference.aspose.cloud/html/) for full API specification.

## What's new in the last version (19.5.0)

1) This SDK version uses Aspose.HTML Cloud REST API version 3.0 (implemented as a Docker container application). So the SDK has been updated according to API v3.0 and to use JWT authorization inside.
2) All HTML REST API wrapper methods have been joined in the single [**HtmlApi**](docs/HtmlApi.md) class; it becomes a common facade for all HTML API groups. All HTML SDK methods are available using HtmlApi class instance or any of interfaces that it exposes (*IDocumentApi, IConversionApi, ITranslateApi, IOcrApi, ITemplateMergeApi, ISummarizationApi*)
3) A special group of SDK methods that provide a cloud storage access has been added. The storage access functionality is available using [**StorageApi**](docs/StorageApi.md) class instance or interfaces that it exposes (*IStorageApi, IStorageFileApi, IStorageFolderApi*). Thus, dependence on Aspose.Storage-Cloud SDK package has been removed.

## How to use the SDK?
The complete source code is available in this repository folder. You can either use it directly in your project via source code or get [NuGet distribution](https://www.nuget.org/packages/Aspose.HTML-Cloud/) (recommended). For more details, please visit our [documentation website](https://docs.aspose.cloud/display/htmlcloud/Available+SDKs#AvailableSDKs-.NET).


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
        string BASEPATH = "https://api.aspose.cloud";
		string AUTHPATH = "https://api.aspose.cloud";

        string sourceUrl = "https://www.le.ac.uk/oerresources/bdra/html/page_02.htm";
        // apply a source page URL
        string source_lang = "en";  // source language
        string result_lang = "fr";  // result language

        string resultFile = "page_02_en_fr.htm";

        static void Main(string[] args)
        {
            // create instance of the API class
            ITranslationApi trApi = new HtmlApi(APPKEY, APPSID, BASEPATH, AUTHPATH);
            // translate the HTML document by its URL
            StreamResponse response = trApi.GetTranslateDocumentByUrl(sourceUrl, source_lang, result_lang);
			if(response.Status == "OK" && response.ContentStream != null)
			{
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
}
```

## Dependencies
- .NET Framework 4.0 or later
- [Json.NET (9.0.1 or later)](https://www.nuget.org/packages/Newtonsoft.Json/)

## Roadmap

In the upcoming releases, we are set to implement a number of new features:
* Support of conversion from HTML (and other supported input format) to GIF, from Markdown to HTML.
* Improve quality of translation: new neural network translator models will be applied to increase translation quality and performance.
* Add more language pairs to translate: French-to-English, English-to-Japanese, Japanese-to-English and some others.

Known issues that we are set to fix soon:
* 

## Documentation for API Endpoints

All URIs are relative to *https://api.aspose.cloud/v3.0*

Class | Interface | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*HtmlApi* | *IConversionApi* | [**GetConvertDocumentToImage**](docs/ConversionApi.md#GetConvertDocumentToImage) | **GET** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format.
*HtmlApi* | *IConversionApi* | [**GetConvertDocumentToImageByUrl**](docs/ConversionApi.md#GetConvertDocumentToImageByUrl) | **GET** /html/convert/image/{outFormat} | Convert the HTML page from the web by its URL to the specified image format.
*HtmlApi* | *IConversionApi* | [**GetConvertDocumentToPdf**](docs/ConversionApi.md#GetConvertDocumentToPdf) | **GET** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF.
*HtmlApi* | *IConversionApi* | [**GetConvertDocumentToPdfByUrl**](docs/ConversionApi.md#GetConvertDocumentToPdfByUrl) | **GET** /html/convert/pdf | Convert the HTML page from the web by its URL to PDF.
*HtmlApi* | *IConversionApi* | [**GetConvertDocumentToXps**](docs/ConversionApi.md#GetConvertDocumentToXps) | **GET** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS.
*HtmlApi* | *IConversionApi* | [**GetConvertDocumentToMarkdown**](docs/ConversionApi.md#GetConvertDocumentToMarkdown) | **GET** /html/{name}/convert/md | Convert the HTML document from the storage by its name to Markdown.
*HtmlApi* | *IConversionApi* | [**GetConvertDocumentToXpsByUrl**](docs/ConversionApi.md#GetConvertDocumentToXpsByUrl) | **GET** /html/convert/xps | Convert the HTML page from the web by its URL to XPS.
*HtmlApi* | *IConversionApi* | [**GetConvertDocumentToMHTMLByUrl**](docs/ConversionApi.md#GetConvertDocumentToMHTMLByUrl) | **GET** /html/convert/mhtml | Convert the HTML page from the web by its URL to MHTML.
*HtmlApi* | *IConversionApi* | [**PutConvertDocumentToImage**](docs/ConversionApi.md#PutConvertDocumentToImage) | **PUT** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format and save it to storage.
*HtmlApi* | *IConversionApi* | [**PostConvertDocumentToImage**](docs/ConversionApi.md#PostConvertDocumentToImage) | **PUT** /html/convert/image/{outFormat} | Convert the HTML document from the request stream to the specified image format and save it to storage.
*HtmlApi* | *IConversionApi* | [**PostConvertDocumentToImage**](docs/ConversionApi.md#PostConvertDocumentToImage_1) | **PUT** /html/convert/image/{outFormat} | Convert the HTML document from the local file system by its local path to the specified image format and save it to storage.
*HtmlApi* | *IConversionApi* | [**PutConvertDocumentToPdf**](docs/ConversionApi.md#PutConvertDocumentToPdf) | **PUT** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF and save it to storage.
*HtmlApi* | *IConversionApi* | [**PostConvertDocumentToPdf**](docs/ConversionApi.md#PostConvertDocumentToPdf) | **POST** /html/convert/pdf | Convert the HTML document from the request stream to PDF and save it to storage.
*HtmlApi* | *IConversionApi* | [**PutConvertDocumentToPdf**](docs/ConversionApi.md#PostConvertDocumentToPdf_1) | **POST** /html/convert/pdf | Convert the HTML document from the local file system by its local path to PDF and save it to storage.
*HtmlApi* | *IConversionApi* | [**PutConvertDocumentToXps**](docs/ConversionApi.md#PutConvertDocumentToXps) | **PUT** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS and save it to storage.
*HtmlApi* | *IConversionApi* | [**PostConvertDocumentToXps**](docs/ConversionApi.md#PostConvertDocumentToXps) |  **POST** /html/convert/xps | Convert the HTML document from the request stream to XPS and save it to storage.
*HtmlApi* | *IConversionApi* | [**PostConvertDocumentToXps**](docs/ConversionApi.md#PostConvertDocumentToXps_1) |  **POST** /html/convert/xps | Convert the HTML document from the local file system by its local path to XPS and save it to storage.
*HtmlApi* | *IConversionApi* | [**PutConvertDocumentToMarkdown**](docs/ConversionApi.md#PutConvertDocumentToMarkdown) | **PUT** /html/{name}/convert/md | Convert the HTML document from the storage by its name to Markdown and save it to storage.
*HtmlApi* | *IConversionApi* | [**PostConvertDocumentToMarkdown**](docs/ConversionApi.md#PostConvertDocumentToMarkdown) |  **POST** /html/convert/md | Convert the HTML document from the request stream to Markdown and save it to storage.
*HtmlApi* | *IConversionApi* | [**PostConvertDocumentToMarkdown**](docs/ConversionApi.md#PostConvertDocumentToMarkdown_1) |  **POST** /html/convert/md | Convert the HTML document from the local file system by its local path to Markdown and save it to storage.
*HtmlApi* | *IDocumentApi* | [**GetDocumentByUrl**](docs/DocumentApi.md#GetDocumentByUrl) | **GET** /html/download | Download the HTML page from Web by its URL with linked resources as a ZIP archive. 
*HtmlApi* | *IDocumentApi* | [**GetDocumentFragmentByXPath**](docs/DocumentApi.md#GetDocumentFragmentByXPath) | **GET** /html/{name}/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query. 
*HtmlApi* | *IDocumentApi* | [**GetDocumentFragmentByXPathByUrl**](docs/DocumentApi.md#GetDocumentFragmentByXPathByUrl) | **GET** /html/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query - from a Web page by its URL. 
*HtmlApi* | *IDocumentApi* |[**GetDocumentFragmentByCSSSelector**](docs/DocumentApi.md#GetDocumentFragmentByCSSSelector) | **GET** /html/{name}/fragments/css/{outFormat} | Return list of HTML fragments matching the specified CSS selector
*HtmlApi* | *IDocumentApi* |[**GetDocumentFragmentByCSSSelectorByUrl**](docs/DocumentApi.md#GetDocumentFragmentByCSSSelectorByUrl) | **GET** /html/fragments/css/{outFormat} | Return list of HTML fragments matching the specified CSS selector - from a Web page by its URL. 
*HtmlApi* | *IDocumentApi* | [**GetDocumentImages**](docs/DocumentApi.md#GetDocumentImages) | **GET** /html/{name}/images/all | Return all HTML document images packaged as a ZIP archive.
*HtmlApi* | *IDocumentApi* | [**GetDocumentImagesByUrl**](docs/DocumentApi.md#GetDocumentImagesByUrl) | **GET** /html/images/all | Return all HTML document images packaged as a ZIP archive - from a Web page by its URL.
*HtmlApi* | *ITemplateMergeApi* | [**GetMergeHtmlTemplate**](docs/TemplateMergeApi.md#GetMergeHtmlTemplate) | **GET** /html/{templateName}/merge | Populate HTML document template with data located as a file in the storage.
*HtmlApi* | *ITemplateMergeApi* | [**PostMergeHtmlTemplate**](docs/TemplateMergeApi.md#PostMergeHtmlTemplate) | **POST** /html/{templateName}/merge | Populate HTML document template with data from the stream. Result document will be saved to storage.
*HtmlApi* | *ITemplateMergeApi* | [**PostMergeHtmlTemplate**](docs/TemplateMergeApi.md#PostMergeHtmlTemplate_1) | **POST** /html/{templateName}/merge | Populate HTML document template with data from the local file system. Result document will be saved to storage.
*HtmlApi* | *ITranslationApi* | [**GetTranslateDocument**](docs/TranslationApi.md#GetTranslateDocument) | **GET** /html/{name}/translate/{srcLang}/{resLang} | Translate the HTML document specified by the name from default or specified storage.
*HtmlApi* | *ITranslationApi* | [**GetTranslateDocumentByUrl**](docs/TranslationApi.md#GetTranslateDocumentByUrl) | **GET** /html/translate/{srcLang}/{resLang} | Translate the HTML document specified by its URL.
*HtmlApi* | *IOcrApi* | [**GetRecognizeAndImportToHtml**](docs/OcrApi.md#GetRecognizeAndImportToHtml) | **GET** /html/{name}/ocr/import | Recognize text content from the source image file by its name from default or specified storage, and create an HTML document.
*HtmlApi* | *IOcrApi* | [**GetRecognizeAndTranslateToHtml**](docs/OcrApi.md#GetRecognizeAndTranslateToHtml) | **GET** /html/{name}/ocr/translate/{srcLang}/{resLang} | Recognize text content from the source image file by its name from default or specified storage, and create an HTML document translated to the specified language.
*HtmlApi* | *ISummarizationApi* | [**GetDetectHtmlKeywords**](docs/SummarizationApi.md#GetDetectHtmlKeywords) | **GET** /html/{name}/summ/keywords | Detect keywords of the HTML document specified by the name from default or specified storage.
*HtmlApi* | *ISummarizationApi* | [**GetDetectHtmlKeywordsByUrl**](docs/SummarizationApi.md#GetDetectHtmlKeywordsByUrl) | **GET** /html/summ/keywords | Detect keywords of the HTML document specified by its URL.
*StorageApi* | *IStorageFolderApi* | [**GetFolderContentList**] (docs/IStorageFolderApi.md#GetFolderContentList) | **GET** /html/storage/folder/{path} | Get all files and subfolders within a folder
*StorageApi* | *IStorageFolderApi* | [**CreateFolder**] (docs/IStorageFolderApi.md#CreateFolder) | **PUT** /html/storage/folder/{path} | Create the folder
*StorageApi* | *IStorageFolderApi* | [**DeleteFolder**] (docs/IStorageFolderApi.md#DeleteFolder) | **DELETE** /html/storage/folder/{path} | Delete folder
*StorageApi* | *IStorageFolderApi* | [**CopyFolder**] (docs/IStorageFolderApi.md#CopyFolder) | **PUT** /html/storage/folder/copy/{srcPath} |  Copy folder
*StorageApi* | *IStorageFolderApi* | [**MoveFolder**] (docs/IStorageFolderApi.md#MoveFolder) | **PUT** /html/storage/folder/move/{srcPath} | Move folder
*StorageApi* | *IStorageFileApi* | [**DownloadFile] (docs/IStorageFileApi.md#DownloadFile) | **GET** /html/storage/file/{path} | Download file
*StorageApi* | *IStorageFileApi* | [**UploadFile] (docs/IStorageFileApi.md#UploadFile) | **PUT** /html/storage/file/{path} | Upload file
*StorageApi* | *IStorageFileApi* | [**UploadFile] (docs/IStorageFileApi.md#UploadFile_1) | **PUT** /html/storage/file/{path} | Upload file by local path. Overloaded method.
*StorageApi* | *IStorageFileApi* | [**DeleteFile] (docs/IStorageFileApi.md#DeleteFile) | **DELETE** /html/storage/file/{path} | Delete file
*StorageApi* | *IStorageFileApi* | [**CopyFile] (docs/IStorageFileApi.md#CopyFile) | **PUT** /html/storage/file/copy/{srcPath} | Copy file
*StorageApi* | *IStorageFileApi* | [**MoveFile] (docs/IStorageFileApi.md#MoveFile) | **PUT** /html/storage/file/move/{srcPath} | Move file
*StorageApi* | *IStorageApi* | [**StorageExists**](docs/IStorageApi.md#StorageExists) | **GET** /html/storage/{storageName}/exist | Check if storage exists
*StorageApi* | *IStorageApi* | [**FileOrFolderExists](docs/IStorageApi.md#FileOrFolderExists) | **GET** /html/storage/exist/{path} | Check if file or folder exists
*StorageApi* | *IStorageApi* | [**GetDiscUsage**](docs/IStorageApi.md#GetDiscUsage) | **GET** /html/storage/disc | Get disc usage
*StorageApi* | *IStorageApi* | [**GetStorageItemVersions**] (docs/IStorageApi.md#GetStorageItemVersions) | **GET** /html/storage/version/{path} | Get list of file versions


## Resources

- **Website:** [www.aspose.com](http://www.aspose.cloud)
- **Product Home:** [Aspose.HTML for Cloud](https://products.aspose.cloud/html/cloud)
- **Documentation:** [Aspose.HTML for Cloud Documentation](https://docs.aspose.cloud/display/htmlcloud/Home)
- **Forum:** [Aspose.HTML for Cloud Forum](https://forum.aspose.cloud/c/html)
- **Blog:** [Aspose.HTML for Cloud Blog](https://blog.aspose.cloud/category/aspose-products/aspose-html-cloud/)


## Contact Us
Your feedback is very important to us. Please feel free to contact us using our [Support Forums](https://forum.aspose.cloud/c/html).
