# TranslationApi

All URIs are relative to *https://api.aspose.cloud/v1.1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetTranslateDocument**](TranslationApi.md#GetTranslateDocument) | **GET** /html/{name}/translate/{srcLang}/{resLang} | Translate the HTML document specified by the name from default or specified storage.
[**GetTranslateDocumentByUrl**](TranslationApi.md#GetTranslateDocumentByUrl) | **GET** /html/{name}/translate/{srcLang}/{resLang} | Translate the HTML document specified by its URL.


<a name="GetTranslateDocument"></a>
# **GetTranslateDocument**
> AsposeStreamResponse GetTranslateDocument(name, srcLang, resLang, storage, folder)

Translate the HTML document specified by the name from default or specified storage.

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
	
	string name = "testpage4_embcss.html";
	
	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, $"{Path.GetFileNameWithoutExtension(name)}_EnglishToFrench.html.zip");
	
	string srcLang = "en";    // String | Source language.
	string resLang = "fr";    // String | Result language.
	string folder = null;     // root folder
	string storage = null;    // default storage

	try
	{
	    ITranslationApi transApi = new TranslationApi(appKey, appSID, BasePath);
		var response = transApi.GetTranslateDocument(name, srcLang, resLang, storage, folder);
			
		if(response != null && response.ContentStream != null)
		{
			Stream stream = response.ContentStream;
			string outFile = Path.Combine(outPath, response.FileName);
			
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
 **name** | **String**| Document name. |
 **srcLang** | **String**| Source language. Allowed values are: "en" (alias "eng", "english"), "de" (alias "deu", "deutsch", "german"), "fr" (alias "fra", "french"), "ru" (alias "rus", "russian"), "zh", alias ("chinese").|
 **resLang** | **String**| Result language. Allowed values are: "en" (alias "eng", "english"), "de" (alias "deu", "deutsch", "german"), "fr" (alias "fra", "french"), "ru" (alias "rus", "russian"), "zh", alias ("chinese").|
 **storage** | **String**| The document storage. | [optional]
 **folder** | **String**| The document folder. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

<a name="translationGetTranslateDocumentByUrl"></a>
# **GetTranslateDocumentByUrl**
> AsposeStreamResponse GetTranslateDocumentByUrl(sourceUrl, srcLang, resLang)

Translate the HTML document specified by its URL.

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
	
	string sourceUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_01.htm";
	
	string outPath = @"d:\Out";
	Uri uri = new Uri(sourceUrl);
	string outFile = Path.Combine(outPath, $"{Path.GetFileNameWithoutExtension(uri.Segments.LastOrDefault())}_EnglishToFrench.html.zip");
	
	string srcLang = "en";    // String | Source language.
	string resLang = "fr";    // String | Result language.
	string folder = null;     // root folder
	string storage = null;    // default storage

	try
	{
	    ITranslationApi transApi = new TranslationApi(appKey, appSID, BasePath);
		var response = docApi.GetTranslateDocument(sourceUrl, srcLang, resLang);
			
		if(response != null && response.ContentStream != null)
		{
			Stream stream = response.ContentStream;
			string outFile = Path.Combine(outPath, response.FileName);
			
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
 **sourceUrl** | **String**| Source document URL. |
 **srcLang** | **String**| Source language.  Allowed values are: "en" (alias "eng", "english"), "de" (alias "deu", "deutsch", "german"), "fr" (alias "fra", "french"), "ru" (alias "rus", "russian"), "zh", alias ("chinese").|
 **resLang** | **String**| Result language.  Allowed values are: "en" (alias "eng", "english"), "de" (alias "deu", "deutsch", "german"), "fr" (alias "fra", "french"), "ru" (alias "rus", "russian"), "zh", alias ("chinese").|

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data


