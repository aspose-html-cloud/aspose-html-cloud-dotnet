# DocumentApi

All URIs are relative to *https://api.aspose.cloud/v1.1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetDocument**](DocumentApi.md#GetDocument) | **GET** /html/{name} | Return the HTML document by the name from default or specified storage.
[**GetDocumentFragmentByXPath**](DocumentApi.md#GetDocumentFragmentByXPath) | **GET** /html/{name}/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query. 
[**GetDocumentImages**](DocumentApi.md#GetDocumentImages) | **GET** /html/{name}/images/all | Return all HTML document images packaged as a ZIP archive.


<a name="GetDocument"></a>
# **GetDocument**
> Stream GetDocument(name, storage, folder)

Return the HTML document by the name from default or specified storage.

### Example
```csharp

using System;
using System.IO;
using Com.Aspose.Html.Api;
using Com.Aspose.Html.Api.Interfaces;

public static void Main(string[] args)
{
	string appKey = "XXXXX";   // put here your app key
	string appSID = "XXXXX";   // put here your app SID
	string BasePath = "https://api.aspose.cloud/v1.1";
	
	string name = "testpage4_embcss.html";
	
	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, name);
	
	string folder = null;     // root folder
	string storage = null;    // default storage

	try
	{
	    IDocumentApi docApi = new DocumentApi(appKey, appSID, BasePath);
		var response = docApi.GetDocument(name, storage, folder);
			
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
 **name** | **String**| The document name. |
 **storage** | **String**| The document folder | [optional]
 **folder** | **String**| The document folder. | [optional]

### Return type

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data, application/zip

<a name="GetDocumentFragmentByXPath"></a>
# **GetDocumentFragmentByXPath**
> Stream GetDocumentFragmentByXPath(name, xPath, outFormat, storage, folder)

Return list of HTML fragments matching the specified XPath query. 

### Example
```csharp

using System;
using System.IO;
using Com.Aspose.Html.Api;
using Com.Aspose.Html.Api.Interfaces;

public static void Main(string[] args)
{
	string appKey = "XXXXX";   // put here your app key
	string appSID = "XXXXX";   // put here your app SID
	string BasePath = "https://api.aspose.cloud/v1.1";
	
	string name = "testpage4_embcss.html";
	String xPath = ".//p/@class";              // String | XPath query string.
	string outFormat = "plain";             // String | Output format. Possible values: 'plain' and 'json'.
	
	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, $"{name}_fragments.txt");
	
	string folder = null;     // root folder
	string storage = null;    // default storage

	try
	{
	    IDocumentApi docApi = new DocumentApi(appKey, appSID, BasePath);
		var response = docApi.GetDocumentFragmentByXPath(name, xPath, outFormat, storage, folder);
			
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
 **name** | **String**| The document name. |
 **xPath** | **String**| XPath query string. |
 **outFormat** | **String**| Output format. Possible values: &#39;plain&#39; and &#39;json&#39;. |
 **storage** | **String**| The document storage. | [optional]
 **folder** | **String**| The document folder. | [optional]

### Return type

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

<a name="GetDocumentImages"></a>
# **GetDocumentImages**
> Stream GetDocumentImages(name, folder, storage)

Return all HTML document images packaged as a ZIP archive.

### Example
```csharp

using System;
using System.IO;
using Com.Aspose.Html.Api;
using Com.Aspose.Html.Api.Interfaces;

public static void Main(string[] args)
{
	string appKey = "XXXXX";   // put here your app key
	string appSID = "XXXXX";   // put here your app SID
	string BasePath = "https://api.aspose.cloud/v1.1";
	
	string name = "testpage5.html.zip";

	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, $"{name}_fragments.txt");
	
	string folder = null;     // root folder
	string storage = null;    // default storage

	try
	{
	    IDocumentApi docApi = new DocumentApi(appKey, appSID, BasePath);
		var response = docApi.GetDocumentFragmentByXPath(name, storage, folder);
			
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
 **name** | **String**| The document name. |
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/zip

