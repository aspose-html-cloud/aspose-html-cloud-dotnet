# ISeoApi

All URIs are relative to *https://api.aspose.cloud/v3.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetWebPageSEOWarnings**](SeoApi.md#GetWebPageSEOWarnings) |  **GET** /html/seo | Return list of SEO warnings detected in a specified Web page.
 

<a name="GetWebPageSEOWarnings"></a>
# **GetWebPageSEOWarnings**
> StreamResponse GetWebPageSEOWarnings(sourceUrl)

Return list of SEO warnings detected in a specified Web page.
Analyze the HTML page from Web by its URL and return a JSON list of warnings detected.
The following analysis points are provided (and this list can be extended in the next versions):
* detection of the broken links;
* validation of the e-mail links;
* checking IMG elements for the absence of ALT attributes;
* checking for duplicated H1 headers.

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
	string BasePath = "https://api.aspose.cloud"; // API version is 3.0
	string AuthPath = "https://api.aspose.cloud";

	string sourceUrl = "https://www.le.ac.uk/oerresources/bdra/html/page_01.htm";   // web page URL
	
	string outPath = @"d:\Out";
	
	try
	{
	    ISeoApi seoApi = new HtmlApi(appKey, appSID, BasePath, AuthPath);
		var response = seoApi.GetWebPageSEOWarnings(sourceUrl);
		if(response != null && response.ContentStream != null)
		{
			string fileName = Path.GetFileName()
			Stream stream = response.ContentStream;
			if(response.FileName == null)

			string outFile = Path.Combine(outPath, 
				(response.FileName == null) ? : response.FileName);
			
			if(!Directory.Exists(outPath)) Directory.CreateDirectory(outPath);
			using(Stream fstr = new FileStream(outFile, FileMode.Create, FileAccess.Write))
			{
				stream.CopyTo(fstr);
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
**sourceUrl** | **String**| The source web page URL to analyze. |


### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/zip