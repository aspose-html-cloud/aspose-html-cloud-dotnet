



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


<a name="KeyFeatures"/>

## Key Features

* Conversion of HTML document into various formats; PDF, XPS, Markdown document formats and JPEG, PNG, GIF, BMP, TIFF raster graphics formats are supported
* Conversion of MHTML document into the same formats that are supported for HTML
* Conversion of ePub document into the same formats that are supported for HTML
* Conversion of HTML document from Web by its URL to MHTML document format
* Conversion of Markdown file to HTML page



* Downloading of HTML page from Web by its URL with its linked resources as single ZIP archive
* Extraction of HTML fragments using XPath queries
* Extraction of HTML fragments using CSS selectors
* Extraction of all HTML document images in a ZIP archive
* Merging HTML/XHTML templates with external data source; XML and JSON are supported as source data format
* HTML page SEO analysis; returns JSON list of SEO warnings 

<a name="HowToUseSDK" />

## How to use the SDK?


The complete source code is available in this repository folder. You can either use it directly in your project via source code or get [NuGet distribution](https://www.nuget.org/packages/Aspose.HTML-Cloud/) (recommended). 
For more details, please visit our [documentation website](https://docs.aspose.cloud/display/htmlcloud/Available+SDKs#AvailableSDKs-.NET).

<a name="HowTo-prerequisites"/>

### Prerequisites


To use Aspose HTML for Cloud .NET SDK you need to register an account with [Aspose Cloud](https://www.aspose.cloud/) and lookup/create App Key and SID at [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps). There is free quota available. For more details, see [Aspose Cloud Pricing](https://purchase.aspose.cloud/pricing).

<a name="HowTo-installation"/>

### Installation


Get the ready package from [NuGet](https://www.nuget.org/packages/Aspose.HTML-Cloud/) or build from source available in this repository folder Aspose.HTML-Cloud.

<a name="HowTo-install-nuget"/>

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

<a name="HowTo-RunTestsExamples"/>

### Run tests and examples.


To run tests, first modify the Settings\servercreds.json file setting up your AppSID & AppKey that you have obtained before (see Prerequisites) and basePath if it differs from http://api.aspose.cloud.

To run examples, modify the Aspose.HTML.Cloud.SDK.Examples\App.config file setting up AppSID, AppKey, and optionally DataPath.

<a name="CodeExample"/>

### Usage sample

The example below demonstrates how you can use the proposed SDK functionality in your application.
In this example, the HTML document located by its URL is converted to other format, e.g. PDF using Aspose.HTML-Cloud library.

**How to try this code sample**:

 1. Open Visual Studio and create an empty solution.
 2. In the solution, create a  C# console application project.
 3. In the console project, install the last version of Aspose.HTML-Cloud package from NuGet  ( see [Install Aspose.HTML-Cloud via NuGet](README.md#HowTo-install-nuget) above )
 4. Copy the code snippet below and replace Program.cs file content.
 5. Replace APPKEY and APPSID variable values in the code with respective values from your account ( see [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps) page )
 6. Run the application and check a result by the path displayed in the console output.

For more buildable and executable examples, refer the [**Documentation for API Endpoints**](README.md#Doc_API) chapter.

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
		const string ACTION = "Convert the HTML document by its URL to PDF";
			
		const string APPKEY = "XXXXXXXXXXXXXXXXXXX";         // put here the app Key
		const string APPSID = "XXXXXXXXXXXXXXXXXXX";         // put here the app SID
		const string BASEPATH = "https://api.aspose.cloud";
		const string AUTHPATH = "https://api.aspose.cloud";

		const string OUT_PATH = @"d:\aspose\testout";


		static void Main(string[] args)
		{
			// apply a source page URL
			string sourceUrl = "https://www.le.ac.uk/oerresources/bdra/html/page_02.htm";
			// all these parameters are optional
			int width = 800;
			int height = 1200;
			int leftMargin = 15;
			int rightMargin = 15;
			int topMargin = 15;
			int bottomMargin = 15;

			// create instance of the API class
			IConversionApi convApi = new HtmlApi(APPKEY, APPSID, BASEPATH, AUTHPATH);
			try
			{
				Console.WriteLine($"{ACTION} : started...");
				Console.Out.Flush();

				StreamResponse response = convApi.GetConvertDocumentToPdfByUrl(
					sourceUrl, width, height,
					leftMargin, rightMargin, topMargin, bottomMargin);

				if (response != null && response.ContentStream != null)
				{
					Stream stream = response.ContentStream;
					string outFile = Path.Combine(OUT_PATH, response.FileName);

					if (!Directory.Exists(OUT_PATH)) Directory.CreateDirectory(OUT_PATH);

					using (Stream fstr = new FileStream(outFile, FileMode.Create, FileAccess.Write))
					{
						stream.CopyTo(fstr);
						fstr.Flush();

						Console.WriteLine($"Succeeded: result file saved to {outFile}");
						Console.Out.Flush();
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				Console.Out.Flush();
			}
			Console.WriteLine("Press any key to end");
			Console.In.Read();
		}
	}
}

```


<a name="Dependencies"/>

## Dependencies


.NET Standard 2.0 or later
- [Json.NET (12.0.2 or later)](https://www.nuget.org/packages/Newtonsoft.Json/)


<a name="Doc_API"/>

## Documentation for API Endpoints

The functionality provided by the SDK is divided to two groups:

 - HTML methods; represented by [*HtmlApi*](docs/HtmlApi.md) class
 - Storage access methods; represented by [*StorageApi*](docs/StorageApi.md) class

All URIs are relative to *https://api.aspose.cloud/v3.0*

<a name="Doc_Api_Class_HtmlApi"/>

### Class: [*HtmlApi*](docs/HtmlApi.md)


<a name="Doc_API_Interface_IConversionApi"/>

#### Interface: [*IConversionApi*](docs/ConversionApi.md)


 Method | HTTP request | Description
 ------------ | ------------- | -------------
 [**GetConvertDocumentToImage**](docs/ConversionApi.md#GetConvertDocumentToImage) | **GET** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format.
 [**GetConvertDocumentToImageByUrl**](docs/ConversionApi.md#GetConvertDocumentToImageByUrl) | **GET** /html/convert/image/{outFormat} | Convert the HTML page from the web by its URL to the specified image format.
 [**GetConvertDocumentToPdf**](docs/ConversionApi.md#GetConvertDocumentToPdf) | **GET** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF.
 [**GetConvertDocumentToPdfByUrl**](docs/ConversionApi.md#GetConvertDocumentToPdfByUrl) | **GET** /html/convert/pdf | Convert the HTML page from the web by its URL to PDF.
 [**GetConvertDocumentToXps**](docs/ConversionApi.md#GetConvertDocumentToXps) | **GET** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS.
 [**GetConvertDocumentToXpsByUrl**](docs/ConversionApi.md#GetConvertDocumentToXpsByUrl) | **GET** /html/convert/xps | Convert the HTML page from the web by its URL to XPS.
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
 [**PutConvertDocumentToMarkdown**](docs/ConversionApi.md#PutConvertDocumentToMarkdown) | **PUT** /html/{name}/convert/md | Convert the HTML document from the storage by its name to Markdown and save it to storage.
 [**PostConvertDocumentToMarkdown**](docs/ConversionApi.md#PostConvertDocumentToMarkdown) |  **POST** /html/convert/md | Convert the HTML document from the request stream to Markdown and save it to storage.
 [**PostConvertDocumentToMarkdown**](docs/ConversionApi.md#PostConvertDocumentToMarkdown_1) |  **POST** /html/convert/md | Overloaded method. Convert the HTML document from the local file system by its local path to Markdown and save it to storage.
 

<br>
<a name="Doc_API_Interface_IConversionApiEx"/>

#### Interface: [*IConversionApiEx*](docs/IConversionApiEx.md)


 Method | HTTP request | Description
 ------------ | ------------- | -------------
[**PostConvertDocumentToImageAndDownload**](docs/IConversionApiEx.md#PostConvertDocumentToImageAndDownload) | **POST** /html/convert/image/{outFormat} | Extension method. Convert the HTML document from the request stream to the specified image format, save to storage and download to stream.
[**PostConvertDocumentToImageAndDownload**](docs/IConversionApiEx.md#PostConvertDocumentToImageAndDownload_1) | **POST** /html/convert/image/{outFormat} | Overloaded extension method. Convert the HTML document from the local file system to the specified image format, save to storage and download to stream.
[**PostConvertDocumentToPdfAndDownload**](docs/IConversionApiEx.md#PostConvertDocumentToPdfAndDownload) | **POST** /html/convert/pdf | Extension method. Convert the HTML document from the request stream to PDF, save to storage and download to stream.
[**PostConvertDocumentToPdfAndDownload**](docs/IConversionApiEx.md#PostConvertDocumentToPdfAndDownload_1) | **POST** /html/convert/pdf | Overloaded extension method. Convert the HTML document from the local file system to PDF, save to storage and download to stream.
[**PostConvertDocumentToXpsAndDownload**](docs/IConversionApiEx.md#PostConvertDocumentToXpsAndDownload_1) | **POST**  /html/convert/xps | Overloaded extension method. Convert the HTML document from the local file system to XPS, save to storage and download to stream.
[**PostConvertDocumentToXpsAndDownload**](docs/IConversionApiEx.md#PostConvertDocumentToXpsAndDownload) | **POST**  /html/convert/xps | Extension method. Convert the HTML document from the request stream to XPS, save to storage and download to stream.
[**PostConvertDocumentToMarkdownAndDownload**](docs/IConversionApiEx.md#PostConvertDocumentToMarkdownAndDownload) | **POST**  /html/convert/md | Extension method. Convert the HTML document from the request stream to Markdown, save to storage and download to stream.
[**PostConvertDocumentToMarkdownAndDownload**](docs/IConversionApiEx.md#PostConvertDocumentToMarkdownAndDownload_1) | **POST**  /html/convert/md | Overloaded extension method. Convert the HTML document from the local file system to Markdown, save to storage and download to stream.


 <br>
<a name="Doc_API_Interface_IImportApi"/>

#### Interface: [*IImportApi*](docs/ImportApi.md)


 Method | HTTP request | Description
 ------------ | ------------- | -------------
 [**GetImportMarkdownToHtml**](docs/ImportApi.md#GetImportMarkdownToHtml) | **GET** /html/{name}/import/md | Create an HTML document from Markdown file (located in the storage) and return it in the response stream.
 [**PutImportMarkdownToHtml**](docs/ImportApi.md#PutImportMarkdownToHtml) | **PUT** /html/{name}/import/md | Create an HTML document from Markdown file (located in the storage) and save it to storage.
 [**PostImportMarkdownToHtml**](docs/ImportApi.md#PostImportMarkdownToHtml) | **POST** /html/import/md | Create an HTML document from Markdown file as input stream and save it to storage.
 [**PostImportMarkdownToHtml**](docs/ImportApi.md#PostImportMarkdownToHtml_1) | **POST** /html/import/md | Overloaded method. Create an HTML document from Markdown file (located in the local file system) and save it to storage.
 
 <br>
<a name="Doc_API_Interface_IDocumentApi"/>

#### Interface: [*IDocumentApi*](docs/DocumentApi.md)

 Method | HTTP request | Description
 ------------ | ------------- | -------------
 [**GetDocumentByUrl**](docs/DocumentApi.md#GetDocumentByUrl) | **GET** /html/download | Download the HTML page from Web by its URL with linked resources as a ZIP archive.
 [**GetDocumentFragmentByXPath**](docs/DocumentApi.md#GetDocumentFragmentByXPath) | **GET** /html/{name}/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query. 
 [**GetDocumentFragmentByXPathByUrl**](docs/DocumentApi.md#GetDocumentFragmentByXPathByUrl) | **GET** /html/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query - from a Web page by its URL.
 [**GetDocumentFragmentByCSSSelector**](docs/DocumentApi.md#GetDocumentFragmentByCSSSelector) | **GET** /html/{name}/fragments/css/{outFormat} | Return list of HTML fragments matching the specified CSS selector
 [**GetDocumentFragmentByCSSSelectorByUrl**](docs/DocumentApi.md#GetDocumentFragmentByCSSSelectorByUrl) | **GET** /html/fragments/css/{outFormat} | Return list of HTML fragments matching the specified CSS selector - from a Web page by its URL. 
 [**GetDocumentImages**](docs/DocumentApi.md#GetDocumentImages) | **GET** /html/{name}/images/all | Return all HTML document images packaged as a ZIP archive.
 [**GetDocumentImagesByUrl**](docs/DocumentApi.md#GetDocumentImagesByUrl) | **GET** /html/images/all | Return all HTML document images packaged as a ZIP archive - from a Web page by its URL.


<br>
<a name="Doc_API_Interface_ITemplateMergeApi"/>

#### Interface: [*ITemplateMergeApi*](docs/TemplateMergeApi.md)

 Method | HTTP request | Description
 ------------ | ------------- | -------------
 [**GetMergeHtmlTemplate**](docs/TemplateMergeApi.md#GetMergeHtmlTemplate) | **GET** /html/{templateName}/merge | Populate HTML document template with data located as a file in the storage.
 [**PostMergeHtmlTemplate**](docs/TemplateMergeApi.md#PostMergeHtmlTemplate) | **POST** /html/{templateName}/merge | Populate HTML document template with data from the stream. Result document will be saved to storage.
 [**PostMergeHtmlTemplate**](docs/TemplateMergeApi.md#PostMergeHtmlTemplate_1) | **POST** /html/{templateName}/merge | Populate HTML document template with data from the local file system. Result document will be saved to storage.
 

 <br>
 <a name="Doc_API_Interface_ISeoApi"/>
 
#### Interface: [*ISeoApi*](docs/SeoApi.md)
 
 Method | HTTP request | Description
 ------------ | ------------- | ------------- 
 [**GetWebPageSEOWarnings**](docs/SeoApi.md#GetWebPageSEOWarnings) |  **GET** /html/seo | Return list of SEO warnings detected in a specified Web page.
  
<br>
<a name="Doc_Api_Class_StorageApi"/>

### Class: [*StorageApi*](docs/StorageApi.md)

 
 <a name="Doc_API_Interface_IStorageFolderApi"/>
  
#### Interface: [*IStorageFolderApi*](docs/IStorageFolderApi.md)

 
  Method | HTTP request | Description
 ------------ | ------------- | ------------- 
 [**GetFolderContentList**](docs/IStorageFolderApi.md#GetFolderContentList) | **GET** /html/storage/folder/{path} | Get all files and subfolders within a folder
 [**CreateFolder**](docs/IStorageFolderApi.md#CreateFolder) | **PUT** /html/storage/folder/{path} | Create the folder
 [**DeleteFolder**](docs/IStorageFolderApi.md#DeleteFolder) | **DELETE** /html/storage/folder/{path} | Delete folder
 [**CopyFolder**](docs/IStorageFolderApi.md#CopyFolder) | **PUT** /html/storage/folder/copy/{srcPath} |  Copy folder
 [**MoveFolder**](docs/IStorageFolderApi.md#MoveFolder) | **PUT** /html/storage/folder/move/{srcPath} | Move folder
 <br>

 
 
<a name="Doc_API_Interface_IStorageFileApi"/>
 
#### Interface: [*IStorageFileApi*](docs/IStorageFileApi.md)

 
  Method | HTTP request | Description
 ------------ | ------------- | ------------- 
 [**DownloadFile**](docs/IStorageFileApi.md#DownloadFile) | **GET** /html/storage/file/{path} | Download file
 [**UploadFile**](docs/IStorageFileApi.md#UploadFile) | **PUT** /html/storage/file/{path} | Upload file
 [**UploadFile**](docs/IStorageFileApi.md#UploadFile_1) | **PUT** /html/storage/file/{path} | Upload file by local path. Overloaded method.
 [**DeleteFile**](docs/IStorageFileApi.md#DeleteFile) | **DELETE** /html/storage/file/{path} | Delete file
 [**CopyFile**](docs/IStorageFileApi.md#CopyFile) | **PUT** /html/storage/file/copy/{srcPath} | Copy file
 [**MoveFile**](docs/IStorageFileApi.md#MoveFile) | **PUT** /html/storage/file/move/{srcPath} | Move file
 
 <br>
<a name="Doc_API_Interface_IStorageApi"/>
  
#### Interface: [*IStorageApi*](docs/IStorageApi.md)

  Method | HTTP request | Description
 ------------ | ------------- | ------------- 
 [**StorageExists**](docs/IStorageApi.md#StorageExists) | **GET** /html/storage/{storageName}/exist | Check if storage exists
 [**FileOrFolderExists**](docs/IStorageApi.md#FileOrFolderExists) | **GET** /html/storage/exist/{path} | Check if file or folder exists
 [**GetDiscUsage**](docs/IStorageApi.md#GetDiscUsage) | **GET** /html/storage/disc | Get disc usage
 [**GetStorageItemVersions**](docs/IStorageApi.md#GetStorageItemVersions) | **GET** /html/storage/version/{path} | Get list of file versions



<br>
<a name="Doc_Auth"/>

## Documentation for authorization methods

Since Aspose.HTML Cloud REST API currently supports only JWT authorization, SDK also uses JWT tokens to authorize REST API access. 

For more details see [**Authorization**](docs/Authorization.md)

<br>
<a name="Resources"/>

## Resources


- **Website:** [www.aspose.com](http://www.aspose.cloud)
- **Product Home:** [Aspose.HTML for Cloud](https://products.aspose.cloud/html/cloud)
- **Documentation:** [Aspose.HTML for Cloud Documentation](https://docs.aspose.cloud/display/htmlcloud/Home)
- **Forum:** [Aspose.HTML for Cloud Forum](https://forum.aspose.cloud/c/html)
- **Blog:** [Aspose.HTML for Cloud Blog](https://blog.aspose.cloud/category/aspose-products/aspose-html-cloud/)

<br>

## Contact Us
<a name="ContactUs"/>

Your feedback is very important to us. Please feel free to contact us using our [Support Forums](https://forum.aspose.cloud/c/html).
