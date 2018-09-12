# OcrApi

All URIs are relative to *https://api.aspose.cloud/v1.1*

Method | HTTP request | Description
------------- | ------------- | -------------
*OcrApi* | [**GetRecognizeAndImportToHtml**](docs/OcrApi.md#GetRecognizeAndImportToHtml) | **GET** /html/{name}/ocr/import | Recognize text content from the source image file by its name from default or specified storage, and create an HTML document.
*OcrApi* | [**GetRecognizeAndTranslateToHtml**](docs/OcrApi.md#GetRecognizeAndTranslateToHtml) | **GET** /html/ocr/translate/{srcLang}/{resLang} | Recognize text content from the source image file by its name from default or specified storage, and create an HTML document translated to the specified language.

<a name="GetRecognizeAndImportToHtml"></a>
# **GetRecognizeAndImportToHtml**
> Stream GetRecognizeAndImportToHtml(name, ocrEngineLang, storage, folder)

Recognize text content from the source image file by its name from default or specified storage, and create an HTML document.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
	string appKey = "XXXXX";   // put here your app key
	string appSID = "XXXXX";   // put here your app SID
	string BasePath = "https://api.aspose.cloud/v1.1";
	
	string name = "0211_116.3B.jpg"; // source image name; put here your file name
	                                 // source file should be uploaded first to the storage by {folder}/{filename} path using Aspose.Storage Cloud API
	string ocrEngineLang = "en"; 
	
	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, name);
	
	string folder = null;     // root folder by default;  put folder path here
	string storage = null;    // default storage; put storage name here

	try
	{
	    IOcrApi ocrApi = new OcrApi(appKey, appSID, BasePath);
		var response = ocrApi.GetRecognizeAndImportToHtml(name, ocrEngineLang, storage, folder);
			
		if(response != null && response is FileStream)
		{
			if(!Directory.Exists(outPath)) Directory.CreateDirectory(outPath);
			using(Stream fstr = new FileStream(outFile, FileMode.Create, FileAccess.Write))
			{
				response.CopyTo(fstr);
				fstr.Flush();
				Console.Out.WriteLine(string.Format("Result file copied to: {0}", outFile));
			}
		}
	}
	catch(Exception ex)
	{
		Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
	}
}
```


### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **String**| The source image name. |
 **ocrEngineLang** | **String**| The OCR engine language. |
 **storage** | **String**| The source image folder | [optional]
 **folder** | **String**| The source image folder. | [optional]

### Return type

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data, application/zip
 
 <a name="GetRecognizeAndTranslateToHtml"></a>
# **GetRecognizeAndTranslateToHtml**
> Stream GetRecognizeAndTranslateToHtml(name, srcLang, resLang, storage, folder)

Recognize text content from the source image file by its name from default or specified storage, and create an HTML document translated to the specified language.

### Example
```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
	string appKey = "XXXXX";   // put here your app key
	string appSID = "XXXXX";   // put here your app SID
	string BasePath = "https://api.aspose.cloud/v1.1";
	
	string name = "0211_116.3B.jpg"; // source image name; put here your file name
	                                 // source file should be uploaded first to the storage by {folder}/{filename} path using Aspose.Storage Cloud API
									 
	string srcLang = "en";    // String | Source language.
	string resLang = "fr";    // String | Result language.
	
	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, name);
	
	string folder = null;     // root folder by default;  put folder path here
	string storage = null;    // default storage; put storage name here

	try
	{
	    IOcrApi ocrApi = new OcrApi(appKey, appSID, BasePath);
		var response = ocrApi.GetRecognizeAndTranslateToHtml(name, srcLang, resLang, storage, folder);
			
		if(response != null && response is FileStream)
		{
			if(!Directory.Exists(outPath)) Directory.CreateDirectory(outPath);
			using(Stream fstr = new FileStream(outFile, FileMode.Create, FileAccess.Write))
			{
				response.CopyTo(fstr);
				fstr.Flush();
				Console.Out.WriteLine(string.Format("Result file copied to: {0}", outFile));
			}
		}
	}
	catch(Exception ex)
	{
		Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
	}
}
```


### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **String**| The source image name. |
 **srcLang** | **String**| Source language (also is considered as OCR engine language). |
 **resLang** | **String**| Result language. |
 **storage** | **String**| The source image folder | [optional]
 **folder** | **String**| The source image folder. | [optional]

### Return type

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/zip
 
 
 