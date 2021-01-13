<img src="Data/header.png">

# Aspose.HTML Cloud SDK for .NET [![NuGet](https://img.shields.io/nuget/v/Aspose.HTML-Cloud.svg)](https://www.nuget.org/packages/Aspose.HTML-Cloud/)
This repository contains Aspose.HTML Cloud SDK for .NET source code. This SDK allows you to work with Aspose.HTML Cloud REST APIs in your .NET applications quickly and easily, with zero initial cost.

See [API Reference](https://apireference.aspose.cloud/html/) for full API specification.

## Table of Contents

>  - [Key Features](README.md#KeyFeatures)
>  - [How to use the SDK?](README.md#HowToUseSDK)
> 	 - [Prerequisites](README.md#HowTo-prerequisites)
> 	 - [Installation](README.md#HowTo-installation)
> 		 - [Install Aspose.HTML-Cloud via NuGet](README.md#HowTo-install-nuget)
> 	 - [Run tests and examples](README.md#HowTo-RunTestsExamples)
> 	 - [Usage sample](README.md#CodeExample)
>  - [Dependencies](README.md#Dependencies)
>  - [Documentation for API Endpoints](README.md#Doc_API)
> 	 - [Class: **HtmlApi**](README.md#Doc_Api_Class_HtmlApi)
>  - [Documentation for authorization methods](README.md#Doc_Auth)
>  - [Resources](README.md#Resources)
>  - [Contact Us](README.md#ContactUs)


<a name="KeyFeatures"></a>
## Key Features

* Conversion of HTML documents into various formats; PDF, XPS, Markdown document formats and JPEG, PNG, GIF, BMP, TIFF raster graphics formats are supported
* Conversion of an MHTML document into the same formats that are supported for HTML
* Conversion of an ePub document into the same formats that are supported for HTML
* Conversion of an HTML document from the Web by its URL to MHTML document format
* Conversion of a Markdown file to an HTML page

<a name="HowToUseSDK"></a>


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
 - HTML -> PDF, XPS, JPEG, PNG, BMP, GIF, TIFF, MHTML, MD, DOC, DOCX
 - XHTML -> PDF, XPS, JPEG, PNG, BMP, GIF, TIFF, MHTML, MD, DOC, DOCX
 - MHTML -> HTML, PDF, XPS, JPEG, PNG, BMP, GIF, TIFF, DOC, DOCX
 - EPUB -> PDF, XPS, JPEG, PNG, BMP, GIF, TIFF, DOC, DOCX


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
DocConversionOptions | Converting source file or URL to DOC/DOCX 
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

## Resources


- **Website:** [www.aspose.com](http://www.aspose.cloud)
- **Product Home:** [Aspose.HTML for Cloud](https://products.aspose.cloud/html/cloud)
- **Documentation:** [Aspose.HTML for Cloud Documentation](https://docs.aspose.cloud/display/htmlcloud/Home)
- **Forum:** [Aspose.HTML for Cloud Forum](https://forum.aspose.cloud/c/html)
- **Blog:** [Aspose.HTML for Cloud Blog](https://blog.aspose.cloud/category/aspose-products/aspose-html-cloud/)

<br>

<a name="ContactUs"></a>
## Contact Us

Your feedback is very important to us. Please feel free to contact us using our [Support Forums](https://forum.aspose.cloud/c/html).
