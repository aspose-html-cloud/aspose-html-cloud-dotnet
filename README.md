![](https://img.shields.io/badge/api-v3.0-lightgrey)  ![Nuget](https://img.shields.io/nuget/v/Aspose.html-Cloud) ![Nuget](https://img.shields.io/nuget/dt/Aspose.html-Cloud) [![GitHub license](https://img.shields.io/github/license/aspose-html-cloud/aspose-html-cloud-dotnet)](https://github.com/aspose-html-cloud/aspose-html-cloud-dotnet/blob/master/LICENSE)
# HTML Rendering & Conversion .NET Cloud REST API
Aspose.HTML Cloud for .NET is a programming SDK that allows software developers to manipulate and convert HTML documents from within their own applications. A Wrapper of RESTful APIs, Aspose.HTML Cloud for .NET speeds up HTML programming and conversion.
This cloud SDK assists to develop cloud-based [HTML page rendering, processing, translation & conversion](https://products.aspose.cloud/html/net) apps in C#, ASP.NET & other .NET languages via REST API.

## HTML Processing Features
- Convert HTML or XHTML page to numerous other file formats.
- Convert ePub, MHTML, Markdown file to numerous other file formats.
- Manipulate files and directories in cloud storage (upload/download files, get directory contents, create and delete directories, copy and move files and directories) 

### Read & Write HTML Formats
HTML, XHTML, zipped HTML, zipped XHTML, MHTML, HTML containing SVG markup, Markdown

### Read HTML Formats

*eBook*: EPUB

### Save HTML As
*Fixed Layout*: PDF, XPS, DOCX
*Images*: TIFF, JPEG, PNG, BMP, GIF
*Other*: ZIP (archived images)



## How to use the SDK?

The complete source code is available in this repository folder. You can either use it directly in your project via source code or get [NuGet distribution](https://www.nuget.org/packages/Aspose.HTML-Cloud/) (recommended).
For more details, please visit our [documentation website](https://docs.aspose.cloud/display/htmlcloud/Available+SDKs#AvailableSDKs-.NET).

<a name="HowTo-prerequisites"></a>
### Prerequisites

To use Aspose HTML for Cloud .NET SDK you need to register an account with [Aspose Cloud](https://www.aspose.cloud/) and lookup/create `Client ID` and `Client Secret` at [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps). There is free quota available. For more details, see [Aspose Cloud Pricing](https://purchase.aspose.cloud/pricing).

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

To run tests, firstly modify the user secrets of Aspose.HTML.Cloud.Sdk.Tests project: in Solution Explorer, right-click the project and select Manage User Secrets menu item. Then replace secrets.json file contents with the following JSON:

```json
{
  "AsposeUserCredentials": {
    "ClientId": "your_client_id",
    "ClientSecret": "your_client_secret"
  }
} 
```

where `ClientId` & `ClientSecret` fields should be replaced with your `Client ID` & `Client Secret` that you have obtained before (see Prerequisites) 


<a name="CodeExample"></a>
### Usage sample

The example below demonstrates how you can use the proposed SDK functionality in your application.
In this example, the HTML document located by local path is converted to another format, e.g. PDF using Aspose.HTML-Cloud library.

**How to try this code sample**:

 1. Open Visual Studio and create an empty solution.
 2. In the solution, create a  C# console application project.
 3. In the console project, install the last version of Aspose.HTML-Cloud package from NuGet  ( see [Install Aspose.HTML-Cloud via NuGet](README.md#HowTo-install-nuget) above ).
 4. Copy the code snippet below and replace Program.cs file content.
 5. Replace `ClientSecret` and `ClientId` variable values in the code with respective values from your account ( see [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps) page ).
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
            string ClientId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";
            string ClientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string projPath = appDir.Substring(0, appDir.IndexOf("\\bin"));
            string sourceFile = Path.Combine(projPath, "TestSource", "test.html");

            // Creating api with credentials.
            var api = new HtmlApi(clientId : clientId, clientSecret : ClientSecret);

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





## Enhancements Version 21.02

- Conversion API has been revised and simplified by excluding a number of ambiguous methods . 

## Enhancements Version 20.12

- Conversion to DOCX format support is provided.
- Bug fix: conversion result saving to the local file system produced incorrect file format.
- To match the common standard, all occurrences of AppSid & AppKey (and similar names) in the SDK source code have been replaced to ClientId & ClientSecret respectively. 

## Enhancements Version 20.11

- New generation of Aspose.HTML Cloud SDK for .NET (C#) is provided.
- This version of SDK has been redesigned from scratch being based on the new Aspose.HTML Cloud REST API (v4.0).
- Currently, it provides only the conversion feature. Other features that are still available in the versions up to v.20.08 are planned to be implemented in this SDK later.
- Conversion interface provides a more flexible conversion parameters setup.
- Redesigned storage access is provided using SDK entry point HtmlApi.Storage.
- Availability of synchronous and asynchronous file upload and download methods.
- Asynchronous download provides the ability to get progress data for the longer downloads.



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
