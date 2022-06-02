




<img src="Data/header.png">

# Aspose.HTML Cloud SDK for .NET [![NuGet](https://img.shields.io/nuget/v/Aspose.HTML-Cloud.svg)](https://www.nuget.org/packages/Aspose.HTML-Cloud/)
This repository contains Aspose.HTML Cloud SDK for .NET source code. This SDK allows you to work with Aspose.HTML Cloud REST APIs in your .NET applications quickly and easily, with zero initial cost.

See [API Reference](https://apireference.aspose.cloud/html/) for full API specification.

## Table of Contents

>  -  [Key Features](README.md#KeyFeatures)
>  - [How to use the SDK?](README.md#HowToUseSDK)
> 	 - [Prerequisites](README.md#HowTo-prerequisites)
> 	 - [Installation](README.md#HowTo-installation)
> 		 - [Install Aspose.HTML-Cloud via NuGet](README.md#HowTo-install-nuget)
> 	 - [Run tests and examples](README.md#HowTo-RunTestsExamples)
> 	 - [Usage sample](README.md#CodeExample)
>  - [Dependencies](README.md#Dependencies)
>  - [Documentation for API Endpoints](README.md#Doc_API)
> 	 - [Class: **HtmlApi**](README.md#Doc_Api_Class_HtmlApi)
> 		 - [Interface: *IConversionApi*](README.md#Doc_API_Interface_IConversionApi)
> 		 - [Interface: *IConversionApiEx*](README.md#Doc_API_Interface_IConversionApiEx)
> 		 - [Interface: *IImportApi*](README.md#Doc_API_Interface_IImportApi)
> 		 - [Interface: *IDocumentApi*](README.md#Doc_API_Interface_IDocumentApi)
> 		 - [Interface: *ITemplateMergeApi*](README.md#Doc_API_Interface_ITemplateMergeApi)
> 		 - [Interface: *ISeoApi*](README.md#Doc_API_Interface_ISeoApi)
> 	 - [Class: **StorageApi**](README.md#Doc_Api_Class_StorageApi)
> 		 - [Interface: *IStorageFolderApi*](README.md#Doc_API_Interface_IStorageFolderApi)
> 		 - [Interface: *IStorageFileApi*](README.md#Doc_API_Interface_IStorageFileApi)
> 		 - [Interface: *IStorageApi*](README.md#Doc_API_Interface_IStorageApi)
>  - [Documentation for authorization methods](README.md#Doc_Auth)
>  - [Resources](README.md#Resources)
>  - [Contact Us](README.md#ContactUs)



## Key Features
<a name="KeyFeatures"/>

* Conversion of HTML document into various formats; PDF, XPS, DOCX, Markdown document formats and JPEG, PNG, GIF, BMP, TIFF raster graphics formats are supported
* Conversion of MHTML document into the same formats that are supported for HTML
* Conversion of ePub document into the same formats that are supported for HTML
* Conversion of HTML document from Web by its URL to MHTML document format
* Conversion (import) of Markdown file to HTML page
* Downloading of HTML page from Web by its URL with its linked resources as single ZIP archive
* Extraction of HTML fragments using XPath queries
* Extraction of HTML fragments using CSS selectors
* Extraction of all HTML document images in a ZIP archive
* Merging HTML/XHTML templates with external data source; XML and JSON are supported as source data format
* HTML page SEO analysis; returns JSON list of SEO warnings 

## How to use the SDK?
<a name="HowToUseSDK" />

The complete source code is available in this repository folder. You can either use it directly in your project via source code or get [NuGet distribution](https://www.nuget.org/packages/Aspose.HTML-Cloud/) (recommended). 
For more details, please visit our [documentation website](https://docs.aspose.cloud/display/htmlcloud/Available+SDKs#AvailableSDKs-.NET).


### Prerequisites
<a name="HowTo-prerequisites"/>

To use Aspose HTML for Cloud .NET SDK you need to register an account with [Aspose Cloud](https://www.aspose.cloud/) and lookup/create App Key and SID at [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps). There is free quota available. For more details, see [Aspose Cloud Pricing](https://purchase.aspose.cloud/pricing).


### Installation
<a name="HowTo-installation"/>

Get the ready package from [NuGet](https://www.nuget.org/packages/Aspose.HTML-Cloud/) or build from source available in this repository folder Aspose.HTML-Cloud.

#### Install Aspose.HTML-Cloud via NuGet
<a name="HowTo-install-nuget"/>

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
<a name="HowTo-RunTestsExamples"/>

To run tests, first modify the Settings\servercreds.json file setting up your AppSID & AppKey that you have obtained before (see Prerequisites) and basePath if it differs from http://api.aspose.cloud.

To run examples, modify the Aspose.HTML.Cloud.SDK.Examples\App.config file setting up AppSID, AppKey, and optionally DataPath.


### Usage sample
<a name="CodeExample"/>

The example below demonstrates how you can use the proposed SDK functionality in your application.
In this example, the HTML document located by its URL is converted to other format, e.g. PDF using Aspose.HTML-Cloud library.

**How to try this code sample**:

 1. Open Visual Studio and create an empty solution.
 2. In the solution, create a  C# console application project.
 3. In the console project, install the last version of Aspose.HTML-Cloud package from NuGet  ( see [Install Aspose.HTML-Cloud via NuGet](README.md#HowTo-install-nuget) above )
 4. Copy the code snippet below and replace Program.cs file content.
 5. Replace APPKEY and APPSID variable values in the code with respective values from your account ( see [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps) page )
 6. Run the application and check a result by the path displayed in the console output.

To get more buildable and executable examples, click here.

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace MyAppNamespace
{
	public class Example
	{
		static string CLIENT_ID     = "XXXXXXXXXXXXXXXXXXX";      // put here the Client ID
		static string CLIENT_SECRET = "XXXXXXXXXXXXXXXXXXX";      // put here the Client Secret
		static string BASEPATH = "https://api.aspose.cloud";
		static string AUTHPATH = "https://api.aspose.cloud";

		static void Main(string[] args)
		{
			string sourceUrl = "https://www.le.ac.uk/oerresources/bdra/html/page_02.htm";
			// apply a source page URL
			int width = 800;
			int height = 1200;
			int leftMargin = 15;
			int rightMargin = 15;
			int topMargin = 15;
			int bottomMargin = 15;

			//string resultFile = "page_02_converted.pdf";
			string outPath = @"d:\aspose\testout";

			// create instance of the API class
			IConversionApi convApi = new HtmlApi(CLIENT_ID, CLIENT_SECRET, BASEPATH, AUTHPATH);
			// convert the HTML document by its URL to PDF
			StreamResponse response = convApi.GetConvertDocumentToPdfByUrl(
				sourceUrl, width, height,
				leftMargin, rightMargin, topMargin, bottomMargin);

			if (response != null && response.ContentStream != null)
			{
				Stream stream = response.ContentStream;
				string outFile = Path.Combine(outPath, response.FileName);

				if (!Directory.Exists(outPath)) Directory.CreateDirectory(outPath);

				using (Stream fstr = new FileStream(outFile, FileMode.Create, FileAccess.Write))
				{
					stream.CopyTo(fstr);
					fstr.Flush();

					Console.WriteLine($"Succeeded: result file saved to {outFile}");
					Console.Out.Flush();
					Console.WriteLine("Press any key to end");
					Console.In.Read();
				}
			}
		}
	}
}

```

## Dependencies
<a name="Dependencies"/>

.NET Framework 4.0 or later
- [Json.NET (12.0.12 or later)](https://www.nuget.org/packages/Newtonsoft.Json/)

.NET Standard 2.0 or later
- [Json.NET (12.0.2 or later)](https://www.nuget.org/packages/Newtonsoft.Json/)



## Documentation for API Endpoints
<a name="Doc_API"/>

The functionality provided by the SDK is divided to two groups:

 - HTML methods; represented by [*HtmlApi*](docs/HtmlApi.md) class
 - Storage access methods; represented by [*StorageApi*](docs/StorageApi.md) class

All URIs are relative to *https://api.aspose.cloud/v3.0*


### Class: [*HtmlApi*](docs/HtmlApi.md)
<a name="Doc_Api_Class_HtmlApi"/>

Provides HTML functionality 

#### Interface: [*IConversionApi*](docs/ConversionApi.md)
<a name="Doc_API_Interface_IConversionApi"/>



 Method | HTTP request | Description
 ------------ | ------------- | -------------
 [**GetConvertDocumentToImage**](docs/ConversionApi.md#GetConvertDocumentToImage) | **GET** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format.
 [**GetConvertDocumentToImageByUrl**](docs/ConversionApi.md#GetConvertDocumentToImageByUrl) | **GET** /html/convert/image/{outFormat} | Convert the HTML page from the web by its URL to the specified image format.
 [**GetConvertDocumentToPdf**](docs/ConversionApi.md#GetConvertDocumentToPdf) | **GET** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF.
 [**GetConvertDocumentToPdfByUrl**](docs/ConversionApi.md#GetConvertDocumentToPdfByUrl) | **GET** /html/convert/pdf | Convert the HTML page from the web by its URL to PDF.
 [**GetConvertDocumentToXps**](docs/ConversionApi.md#GetConvertDocumentToXps) | **GET** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS.
 [**GetConvertDocumentToXpsByUrl**](docs/ConversionApi.md#GetConvertDocumentToXpsByUrl) | **GET** /html/convert/xps | Convert the HTML page from the web by its URL to XPS.
 [**GetConvertDocumentToDoc**](docs/ConversionApi.md#GetConvertDocumentToDoc) | **GET** /html/{name}/convert/doc | Convert the HTML document from the storage by its name to DOCX (MS Word). 
 [**GetConvertDocumentToDocByUrl**](docs/ConversionApi.md#GetConvertDocumentToDocByUrl) | **GET** /html/convert/doc | Convert the HTML page from the web by its URL to DOCX (MS Word). 
 [**GetConvertDocumentToMarkdown**](docs/ConversionApi.md#GetConvertDocumentToMarkdown) | **GET** /html/{name}/convert/md | Convert the HTML document from the storage by its name to Markdown.
 [**GetConvertDocumentToMHTMLByUrl**](docs/ConversionApi.md#GetConvertDocumentToMHTMLByUrl) | **GET** /html/convert/mhtml | Convert the HTML page from the web by its URL to MHTML.
 [**PutConvertDocumentToImage**](docs/ConversionApi.md#PutConvertDocumentToImage) | **PUT** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format and save it to storage.
 [**PostConvertDocumentToImage**](docs/ConversionApi.md#PostConvertDocumentToImage) | **POST** /html/convert/image/{outFormat} | Convert the HTML document from the request stream to the specified image format and save it to storage.
 [**PostConvertDocumentToImage**](docs/ConversionApi.md#PostConvertDocumentToImage_1) | **POST** /html/convert/image/{outFormat} | Overloaded method. Convert the HTML document from the local file system by its local path to the specified image format and save it to storage.
 [**PutConvertDocumentToPdf**](docs/ConversionApi.md#PutConvertDocumentToPdf) | **PUT** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF and save it to storage.
 [**PostConvertDocumentToPdf**](docs/ConversionApi.md#PostConvertDocumentToPdf) | **POST** /html/convert/pdf | Convert the HTML document from the request stream to PDF and save it to storage.
 [**PostConvertDocumentToPdf**](docs/ConversionApi.md#PostConvertDocumentToPdf_1) | **POST** /html/convert/pdf | Overloaded method. Convert the HTML document from the local file system by its local path to PDF and save it to storage.
 [**PutConvertDocumentToXps**](docs/ConversionApi.md#PutConvertDocumentToXps) | **PUT** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS and save it to storage.
 [**PostConvertDocumentToXps**](docs/ConversionApi.md#PostConvertDocumentToXps) |  **POST** /html/convert/xps | Convert the HTML document from the request stream to XPS and save it to storage.
 [**PostConvertDocumentToXps**](docs/ConversionApi.md#PostConvertDocumentToXps_1) |  **POST** /html/convert/xps | Overloaded method. Convert the HTML document from the local file system by its local path to XPS and save it to storage
 [**PutConvertDocumentToDoc**](docs/ConversionApi.md#PutConvertDocumentToDoc) | **PUT** /html/{name}/convert/doc | Convert the HTML document from the storage by its name to DOCX (MS Word). and save it to storage. 
 [**PostConvertDocumentToDoc**](docs/ConversionApi.md#PostConvertDocumentToDoc) | **POST** /html/convert/doc | Convert the HTML document from the request stream to DOCX (MS Word).and save it to storage. 
 [**PostConvertDocumentToDoc**](docs/ConversionApi.md#PostConvertDocumentToDoc_1) | **POST** /html/convert/doc | Overloaded method. Convert the HTML document from the local file system by its local path to DOCX (MS Word).and save it to storage 
 [**PutConvertDocumentToMarkdown**](docs/ConversionApi.md#PutConvertDocumentToMarkdown) | **PUT** /html/{name}/convert/md | Convert the HTML document from the storage by its name to Markdown and save it to storage.
 [**PostConvertDocumentToMarkdown**](docs/ConversionApi.md#PostConvertDocumentToMarkdown) |  **POST** /html/convert/md | Convert the HTML document from the request stream to Markdown and save it to storage.
 [**PostConvertDocumentToMarkdown**](docs/ConversionApi.md#PostConvertDocumentToMarkdown_1) |  **POST** /html/convert/md | Overloaded method. Convert the HTML document from the local file system by its local path to Markdown and save it to storage.

 [&#8593;Up to API doc&#8593;](README.md#Doc_API)






#### Interface: [*IImportApi*](docs/ImportApi.md)
<a name="Doc_API_Interface_IImportApi"/>

 Method | HTTP request | Description
 ------------ | ------------- | -------------
 [**GetImportMarkdownToHtml**](docs/ImportApi.md#GetImportMarkdownToHtml) | **GET** /html/{name}/import/md | Create an HTML document from Markdown file (located in the storage) and return it in the response stream.
 [**PutImportMarkdownToHtml**](docs/ImportApi.md#PutImportMarkdownToHtml) | **PUT** /html/{name}/import/md | Create an HTML document from Markdown file (located in the storage) and save it to storage.
 [**PostImportMarkdownToHtml**](docs/ImportApi.md#PostImportMarkdownToHtml) | **POST** /html/import/md | Create an HTML document from Markdown file as input stream and save it to storage.
 [**PostImportMarkdownToHtml**](docs/ImportApi.md#PostImportMarkdownToHtml_1) | **POST** /html/import/md | Overloaded method. Create an HTML document from Markdown file (located in the local file system) and save it to storage.


#### Interface: [*IDocumentApi*](docs/DocumentApi.md)
<a name="Doc_API_Interface_IDocumentApi"/>

 Method | HTTP request | Description
 ------------ | ------------- | -------------
 [**GetDocumentByUrl**](docs/DocumentApi.md#GetDocumentByUrl) | **GET** /html/download | Download the HTML page from Web by its URL with linked resources as a ZIP archive.
 [**GetDocumentFragmentByXPath**](docs/DocumentApi.md#GetDocumentFragmentByXPath) | **GET** /html/{name}/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query. 
 [**GetDocumentFragmentByXPathByUrl**](docs/DocumentApi.md#GetDocumentFragmentByXPathByUrl) | **GET** /html/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query - from a Web page by its URL.
 [**GetDocumentFragmentByCSSSelector**](docs/DocumentApi.md#GetDocumentFragmentByCSSSelector) | **GET** /html/{name}/fragments/css/{outFormat} | Return list of HTML fragments matching the specified CSS selector
 [**GetDocumentFragmentByCSSSelectorByUrl**](docs/DocumentApi.md#GetDocumentFragmentByCSSSelectorByUrl) | **GET** /html/fragments/css/{outFormat} | Return list of HTML fragments matching the specified CSS selector - from a Web page by its URL. 
 [**GetDocumentImages**](docs/DocumentApi.md#GetDocumentImages) | **GET** /html/{name}/images/all | Return all HTML document images packaged as a ZIP archive.
 [**GetDocumentImagesByUrl**](docs/DocumentApi.md#GetDocumentImagesByUrl) | **GET** /html/images/all | Return all HTML document images packaged as a ZIP archive - from a Web page by its URL.

 [&#8593;Up to API doc&#8593;](README.md#Doc_API)

#### Interface: [*ITemplateMergeApi*](docs/TemplateMergeApi.md)
<a name="Doc_API_Interface_ITemplateMergeApi"/>

 Method | HTTP request | Description
 ------------ | ------------- | -------------
 [**GetMergeHtmlTemplate**](docs/TemplateMergeApi.md#GetMergeHtmlTemplate) | **GET** /html/{templateName}/merge | Populate HTML document template with data located as a file in the storage.
 [**PostMergeHtmlTemplate**](docs/TemplateMergeApi.md#PostMergeHtmlTemplate) | **POST** /html/{templateName}/merge | Populate HTML document template with data from the stream. Result document will be saved to storage.
 [**PostMergeHtmlTemplate**](docs/TemplateMergeApi.md#PostMergeHtmlTemplate_1) | **POST** /html/{templateName}/merge | Populate HTML document template with data from the local file system. Result document will be saved to storage.

  [&#8593;Up to API doc&#8593;](README.md#Doc_API)

#### Interface: [*ISeoApi*](docs/SeoApi.md)
 <a name="Doc_API_Interface_ISeoApi"/>

 Method | HTTP request | Description
 ------------ | ------------- | ------------- 
 [**GetWebPageSEOWarnings**](docs/SeoApi.md#GetWebPageSEOWarnings) |  **GET** /html/seo | Return list of SEO warnings detected in a specified Web page.

 

### Class: [*StorageApi*](docs/StorageApi.md)
<a name="Doc_Api_Class_StorageApi"/>

#### Interface: [*IStorageFolderApi*](docs/IStorageFolderApi.md)
 <a name="Doc_API_Interface_IStorageFolderApi"/>

  Method | HTTP request | Description
 ------------ | ------------- | ------------- 
 [**GetFolderContentList**](docs/IStorageFolderApi.md#GetFolderContentList) | **GET** /html/storage/folder/{path} | Get all files and subfolders within a folder
 [**CreateFolder**](docs/IStorageFolderApi.md#CreateFolder) | **PUT** /html/storage/folder/{path} | Create the folder
 [**DeleteFolder**](docs/IStorageFolderApi.md#DeleteFolder) | **DELETE** /html/storage/folder/{path} | Delete folder
 [**CopyFolder**](docs/IStorageFolderApi.md#CopyFolder) | **PUT** /html/storage/folder/copy/{srcPath} |  Copy folder
 [**MoveFolder**](docs/IStorageFolderApi.md#MoveFolder) | **PUT** /html/storage/folder/move/{srcPath} | Move folder

  [&#8593;Up to API doc&#8593;](README.md#Doc_API)

#### Interface: [*IStorageFileApi*](docs/IStorageFileApi.md)
 <a name="Doc_API_Interface_IStorageFileApi"/>

  Method | HTTP request | Description
 ------------ | ------------- | ------------- 
 [**DownloadFile**](docs/IStorageFileApi.md#DownloadFile) | **GET** /html/storage/file/{path} | Download file
 [**UploadFile**](docs/IStorageFileApi.md#UploadFile) | **PUT** /html/storage/file/{path} | Upload file
 [**UploadFile**](docs/IStorageFileApi.md#UploadFile_1) | **PUT** /html/storage/file/{path} | Upload file by local path. Overloaded method.
 [**DeleteFile**](docs/IStorageFileApi.md#DeleteFile) | **DELETE** /html/storage/file/{path} | Delete file
 [**CopyFile**](docs/IStorageFileApi.md#CopyFile) | **PUT** /html/storage/file/copy/{srcPath} | Copy file
 [**MoveFile**](docs/IStorageFileApi.md#MoveFile) | **PUT** /html/storage/file/move/{srcPath} | Move file

  [&#8593;Up to API doc&#8593;](README.md#Doc_API)

#### Interface: [*IStorageApi*](docs/IStorageApi.md)
  <a name="Doc_API_Interface_IStorageApi"/>

  Method | HTTP request | Description
 ------------ | ------------- | ------------- 
 [**StorageExists**](docs/IStorageApi.md#StorageExists) | **GET** /html/storage/{storageName}/exist | Check if storage exists
 [**FileOrFolderExists**](docs/IStorageApi.md#FileOrFolderExists) | **GET** /html/storage/exist/{path} | Check if file or folder exists
 [**GetDiscUsage**](docs/IStorageApi.md#GetDiscUsage) | **GET** /html/storage/disc | Get disc usage
 [**GetStorageItemVersions**](docs/IStorageApi.md#GetStorageItemVersions) | **GET** /html/storage/version/{path} | Get list of file versions

 [&#8593;Up to API doc&#8593;](README.md#Doc_API)


## Documentation for authorization methods
<a name="Doc_Auth"/>

Since Aspose.HTML Cloud REST API currently supports only JWT authorization, SDK also uses JWT tokens to authorize REST API access. 

For more details see [**Authorization**](docs/Authorization.md)



## Resources
<a name="Resources"/>

- **Website:** [www.aspose.com](http://www.aspose.cloud)
- **Product Home:** [Aspose.HTML for Cloud](https://products.aspose.cloud/html/cloud)
- **Documentation:** [Aspose.HTML for Cloud Documentation](https://docs.aspose.cloud/display/htmlcloud/Home)
- **Forum:** [Aspose.HTML for Cloud Forum](https://forum.aspose.cloud/c/html)
- **Blog:** [Aspose.HTML for Cloud Blog](https://blog.aspose.cloud/category/aspose-products/aspose-html-cloud/)


## Contact Us
<a name="ContactUs"/>

Your feedback is very important to us. Please feel free to contact us using our [Support Forums](https://forum.aspose.cloud/c/html).

## Workflow

In order to make changes in the repository, you need to:

1. Create a branch with the proposed changes whose name matches the feature/* pattern.
2. Create a pull request for this branch. It will be automatically assigned to a suitable reviewer.
3. Once the request is approved, it can be merged.
