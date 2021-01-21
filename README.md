![](https://img.shields.io/badge/api-v3.0-lightgrey)  ![Nuget](https://img.shields.io/nuget/v/Aspose.html-Cloud) ![Nuget](https://img.shields.io/nuget/dt/Aspose.html-Cloud) [![GitHub license](https://img.shields.io/github/license/aspose-html-cloud/aspose-html-cloud-dotnet)](https://github.com/aspose-html-cloud/aspose-html-cloud-dotnet/blob/master/LICENSE)
# HTML Rendering & Conversion .NET Cloud REST API
Aspose.HTML Cloud for .NET is a programming SDK that allows software developers to manipulate and convert HTML documents from within their own applications. A Wrapper of RESTful APIs, Aspose.HTML Cloud for .NET speeds up HTML programming and conversion.
This cloud SDK assists to develop cloud-based [HTML page rendering, processing, translation & conversion](https://products.aspose.cloud/html/net) apps in C#, ASP.NET & other .NET languages via REST API.

## HTML Processing Features
- Fetch the HTML page along with its resources as a ZIP archive by providing the page URL.
- Based on page URL, retrieve all images of an HTML page as a ZIP package.
- Load data from a local file to populate the HTML document template.
- Use the request body to populate the HTML document template.
- Convert HTML page to numerous other file formats.

## Read & Write HTML Formats
HTML, XHTML, zipped HTML, zipped XHTML, MHTML, HTML containing SVG markup, Markdown, JSON

## Save HTML As
*Fixed Layout*: PDF, XPS, DOCX
*Images*: TIFF, JPEG, PNG, BMP, GIF
*Other*: TXT, ZIP (images)

## Read HTML Formats
*eBook*: EPUB
*Other*: XML, SVG

## Enhancements Version 20.12

- Conversion to DOCX format support is provided
- Bug fix: conversion result saving to the local file system produced incorrect file format.
- To match the common standard, all occurrences of AppSid & AppKey (and similar names) in the SDK source code have been replaced to ClientId & ClientSecret respectively. 

## Enhancements Version 20.11

- New generation of Aspose.HTML Cloud SDK for .NET (C#) is provided.
- This version of SDK has been redesigned from scratch being based on the new Aspose.HTML Cloud REST API (v3.0).
- Currently, it provides only the conversion feature. Other features that are still available in the versions up to v.20.08 are planned to be implemented in this SDK later.
- Conversion interface provides a more flexible conversion parameters setup.
- Redesigned storage access is provided using SDK entry point HtmlApi.Storage.
- Availability of synchronous and asynchronous file upload and download methods.
- Asynchronous download provides the ability to get progress data for the longer downloads.

## How to use the SDK?

The complete source code is available in this repository folder. You can either use it directly in your project via source code or get [NuGet distribution](https://www.nuget.org/packages/Aspose.HTML-Cloud/) (recommended).
For more details, please visit our [documentation website](https://docs.aspose.cloud/display/htmlcloud/Available+SDKs#AvailableSDKs-.NET).

<a name="HowTo-prerequisites"></a>
### Prerequisites

To use Aspose HTML for Cloud .NET SDK you need to register an account with [Aspose Cloud](https://www.aspose.cloud/) and lookup/create App Key and SID at [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps). There is free quota available. For more details, see [Aspose Cloud Pricing](https://purchase.aspose.cloud/pricing).


<a name="HowTo-installation"></a>
### Installation

Get the ready package from [NuGet](https://www.nuget.org/packages/Aspose.HTML-Cloud/) or build from source available in this repository folder Aspose.HTML-Cloud.

<a name="HowTo-install-nuget"></a>
#### Install Aspose.HTML-Cloud via NuGet


From the command line:

    nuget install Aspose.HTML-Cloud

From Package Manager:

    PM> Install-Package Aspose.HTML-Cloud

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages.*
4. Click on the *Browse* tab and search for "Aspose.HTML-Cloud".
5. Click on the Aspose.HTML-Cloud package, select the appropriate version in the right-tab and click *Install*.

<a name="HowTo-RunTestsExamples"></a>

### Run tests and examples

To run tests, firstly modify the Settings\servercreds.json file setting up your AppSID & AppKey that you have obtained before (see Prerequisites) and basePath if it differs from http://api.aspose.cloud.

To run examples, modify the Aspose.HTML.Cloud.SDK.Examples\App.config file setting up AppSID, AppKey, and optionally DataPath.

<a name="CodeExample"></a>
### Usage sample

The example below demonstrates how you can use the proposed SDK functionality in your application.
In this example, the HTML document located by local path is converted to another format, e.g. PDF using Aspose.HTML-Cloud library.

**How to try this code sample**:

 1. Open Visual Studio and create an empty solution.
 2. In the solution, create a  C# console application project.
 3. In the console project, install the last version of Aspose.HTML-Cloud package from NuGet  ( see [Install Aspose.HTML-Cloud via NuGet](README.md#HowTo-install-nuget) above ).
 4. Copy the code snippet below and replace Program.cs file content.
 5. Replace APPKEY and APPSID variable values in the code with respective values from your account ( see [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps) page ).
 6. Run the application and check a result by the path displayed in the console output.

For more buildable and executable examples, refer the [**Documentation for API Endpoints**](README.md#Doc_API) chapter.

```csharp
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
            string AppSid = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";
            string AppKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string projPath = appDir.Substring(0, appDir.IndexOf("\\bin"));
            string sourceFile = Path.Combine(projPath, "TestSource", "test.html");

            // Creating api with credentials.
            var api = new HtmlApi(appSid : AppSid, appKey : AppKey);

            // Create converter by ConverterBuilder
            ConverterBuilder convHtmlPdf = new ConverterBuilder()
                .FromLocalFile(sourceFile)
                .To(new PDFConversionOptions())
                .SaveToLocal("TestResultDirectory");

            // Convert html page to pdf
            ConversionResult result = api.Convert(convHtmlPdf);

        }
    }
}
```

## ConverterBuilder

### From...

Specifies input data for conversion.

Possible conversions:
 - HTML -> PDF, XPS, JPEG, PNG, BMP, GIF, TIFF, DOCX, MHTML, MD
 - XHTML -> PDF, XPS, JPEG, PNG, BMP, GIF, TIFF, DOCX, MHTML, MD
 - MHTML -> HTML, PDF, XPS, JPEG, PNG, BMP, DOCX, GIF, TIFF
 - EPUB -> PDF, XPS, JPEG, PNG, BMP, GIF, TIFF, DOCX


  Method | Parameters | Description
 ------------ | ------------- | -------------
FromLocalFile(string inputPath) | inputPath - path to a local file | A source is a file in a local file system.
FromStorageFile(string inputPath) | inputPath - path to the file in the cloud storage | A source is a file in the cloud (user storage).
FromLocalDirectory(string inputDir, string startPoint, params string[] files) | inputDir - path to the local directory<br> startPoint - name of the file for conversion<br> files - other files in the directory for conversion (optional) | Converts a file or files in a local directory with linked resources (css, image, etc.) in this directory.
FromLocalArchive(string inputPath, string startPoint, params string[] files) | inputPath - path to a zip archive<br> startPoint - file in the archive for conversion<br> files - other files in the archive for conversion (optional) | A source with linked resources is a zip archive, located in a local file system.
FromStorageDirectory(string inputDir, string startPoint, params string[] files) | inputDir - path to the directory in the storage<br> startPoint - name of the file for conversion<br> files - other files in the directory for conversion (optional) | Converts a file or files in a directory with linked resources (css, image, etc.) in this directory.
FromStorageArchive(string inputPath, string startPoint, params string[] files) | inputPath - path to zip archive in the storage<br> startPoint - file in the archive for conversion<br> files - other files in the archive for conversion (optional) | A source with linked resources is a zip archive, located in the storage.
FromUrl(string urlAddress) | urlAddress - web site for conversion | A source gets from a URL.


### To(ConversionOptions)

Specifies the output format for conversion.

  Options | Description
 ------------ | -------------
[GIFConversionOptions](docs/ConversionOptions.md#GIFConversionOptions) | Converting source file or URL to single or several images in GIF format.
[JPEGConversionOptions](docs/ConversionOptions.md#JPEGConversionOptions) | Converting source file or URL to single or several images in JPEG format.
[PNGConversionOptions](docs/ConversionOptions.md#PNGConversionOptions) | Converting source file or URL to single or several images in PNG format.
[TIFFConversionOptions](docs/ConversionOptions.md#TIFFConversionOptions) | Converting source file or URL to single or several images in TIFF format.
[BMPConversionOptions](docs/ConversionOptions.md#BMPConversionOptions) | Converting source file or URL to single or several images in BMP format.
[PDFConversionOptions](docs/ConversionOptions.md#PDFConversionOptions) | Converting source file or URL to PDF.
[XPSConversionOptions](docs/ConversionOptions.md#XPSConversionOptions) | Converting source file or URL to XPS.
[DOCConversionOptions](docs/ConversionOptions.md#DOCConversionOptions) | Converting source file or URL to DOCX. 
[MarkdownConversionOptions](docs/ConversionOptions.md#MarkdownConversionOptions) | Converting source file or URL to Markdown.

### SaveTo...

The target directory for a conversion result.

  Method | Parameters | Description
 ------------ | ------------- | -------------
SaveToLocal(string outputDirectory) | outputDirectory - directory to save a result. | A directory in the local file system to save a conversion result.
SaveToStorage(string outputDirectory) | outputDirectory - directory to save a result. | A directory in the cloud (user storage) to save a conversion result.

## ConversionResult

Result object for conversion.

  Field | Description
 ------------ | -------------
string[] Files | A list of conversion result files.
string Description | A description in case of unsuccessful conversion.

<a name="Dependencies"></a>
## Dependencies

.NET Standard 2.0 or later
- [Json.NET (12.0.2 or later)](https://www.nuget.org/packages/Newtonsoft.Json/)

<a name="Doc_API"></a>
## Documentation for API Endpoints

The functionality provided by the SDK is divided into two groups:

 - HTML methods; represented by [*HtmlApi*](docs/HtmlApi.md) class.
 - Storage access methods; represented by [*StorageProvider*](docs/StorageProvider.md) class; the storage entry point is represented by an instance of *StorageProvider* that is available as [*HtmlApi.Storage*](docs/HtmlApi.md#Storage) property of the [*HtmlApi*](docs/HtmlApi.md) class.

All URIs are relative to *https://api.aspose.cloud/v4.0*.

<a name="Doc_Api_Class_HtmlApi"></a>

### Class: [*HtmlApi*](docs/HtmlApi.md)

<a name="Doc_Auth"></a>
## Documentation for authorization methods

Since Aspose.HTML Cloud REST API currently supports only JWT authorization, SDK also uses JWT tokens to authorize REST API access.

For more details, see [**Authorization**](docs/Authorization.md).

<br>
<a name="Resources"></a>

## Aspose.HTML Cloud SDKs in Popular Languages

| .NET | Java | PHP | Python | Ruby | Node.js | Android | Swift|C++|Go|
|---|---|---|---|---|---|---|--|--|--|
| [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-dotnet) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-java) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-php) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-python) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-ruby)  | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-nodejs) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-android) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-swift)|[GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-cpp) |[GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-go) |
| [NuGet](https://www.nuget.org/packages/Aspose.html-Cloud/) | [Maven](https://repository.aspose.cloud/webapp/#/artifacts/browse/tree/General/repo/com/aspose/aspose-html-cloud) | [Composer](https://packagist.org/packages/aspose/aspose-html-cloud-php) | [PIP](https://pypi.org/project/asposehtmlcloud/) | [GEM](https://rubygems.org/gems/aspose_html_cloud)  | [NPM](https://www.npmjs.com/package/@asposecloud/aspose-html-cloud) | [Maven](https://repository.aspose.cloud/webapp/#/artifacts/browse/tree/General/repo/com/aspose/aspose-html-cloud) | [Cocoapods](https://cocoapods.org/pods/AsposeHtmlCloud)|[NuGet](https://www.nuget.org/packages/Aspose.Html-Cloud.Cpp/) | [Go.Dev](#) |

[Product Page](https://products.aspose.cloud/html/net) | [Documentation](https://docs.aspose.cloud/display/htmlcloud/Home) | [API Reference](https://apireference.aspose.cloud/html/) | [Code Samples](https://github.com/aspose-html-cloud/aspose-html-cloud-dotnet) | [Blog](https://blog.aspose.cloud/category/html/) | [Free Support](https://forum.aspose.cloud/c/html) | [Free Trial](https://dashboard.aspose.cloud/#/apps)
