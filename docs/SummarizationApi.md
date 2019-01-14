# SummarizationApi

All URIs are relative to *https://api.aspose.cloud/v1.1*

Method | HTTP request | Description
------------- | ------------- | -------------
*SummarizationApi* | [**GetDetectHtmlKeywords**](docs/SummarizationApi.md#GetDetectHtmlKeywords) | **GET** /html/{name}/summ/keywords | Detect keywords of the HTML document specified by the name from default or specified storage.
*SummarizationApi* | [**GetDetectHtmlKeywordsByUrl**](docs/SummarizationApi.md#GetDetectHtmlKeywordsByUrl) | **GET** /html/summ/keywords | Detect keywords of the HTML document specified by its URL.

<a name="GetDetectHtmlKeywords"></a>

# **GetDetectHtmlKeywords**
> AsposeStreamResponse GetDetectHtmlKeywords(name, storage, folder)


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
	
	string name = "testpage.html";
	
	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, $"{name}_keywords.json";
	try
	{
	    ISummarizationApi summApi = new SummarizationApi(appKey, appSID, BasePath);
		var response = summApi.GetDetectHtmlKeywords(name, storage, folder);
			
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

```csharp

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **String**| Document name. |
 **storage** | **String**| The document storage. | [optional]
 **folder** | **String**| The document folder. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data
 
 
<a name="GetDetectHtmlKeywordsByUrl"></a>

# **GetDetectHtmlKeywordsByUrl**
> AsposeStreamResponse GetDetectHtmlKeywordsByUrl(sourceUrl)


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
	Uri uri = new Uri(sourceUrl);
	string outFile = Path.Combine(outPath, $"{Path.GetFileNameWithoutExtension(uri.Segments.LastOrDefault())}_keywords.json");
	
	string outPath = @"d:\Out";
	try
	{
	    ISummarizationApi summApi = new SummarizationApi(appKey, appSID, BasePath);
		var response = summApi.GetDetectHtmlKeywordsByUrl(sourceUrl);
			
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

```csharp

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sourceUrl** | **String**| Document URL. |

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data
 
 