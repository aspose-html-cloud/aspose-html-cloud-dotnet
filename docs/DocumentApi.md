# DocumentApi

All URIs are relative to *https://api.aspose.cloud/v1.1*


Method | HTTP request | Description
------------- | ------------- | -------------
[**GetDocumentFragmentByXPath**](DocumentApi.md#GetDocumentFragmentByXPath) | **GET** /html/{name}/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query. 
[**GetDocumentFragmentByXPathByUrl**](DocumentApi.md#GetDocumentFragmentByXPathByUrl) | **GET** /html/fragments/{outFormat} | Return list of HTML fragments matching the specified XPath query - from a Web page by its URL.
[**GetDocumentFragmentByCSSSelector**](DocumentApi.md#GetDocumentFragmentByCSSSelector) | **GET** /html/{name}/fragments/css/{outFormat} | Return list of HTML fragments matching the specified CSS selector. 
[**GetDocumentFragmentByCSSSelectorByUrl**](DocumentApi.md#GetDocumentFragmentByCSSSelectorByUrl) | **GET** /html/fragments/css/{outFormat} | Return list of HTML fragments matching the specified CSS selector - from a Web page by its URL.
[**GetDocumentImages**](DocumentApi.md#GetDocumentImages) | **GET** /html/{name}/images/all | Return all HTML document images packaged as a ZIP archive.
[**GetDocumentImagesByUrl**](DocumentApi.md#GetDocumentImagesByUrl) | **GET** /html/images/all | Return all HTML document images packaged as a ZIP archive - from a Web page by its URL.
[**GetDocumentByUrl**](DocumentApi.md#GetDocumentByUrl) | **GET** /html/download | Download the HTML page from Web by its URL with linked resources as a ZIP archive.


<a name="GetDocumentByUrl"></a>
# **GetDocumentByUrl**
> AsposeStreamResponse GetDocumentByUrl(name, storage, folder)

Download the HTML page from Web by its URL with linked resources as a ZIP archive.

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
	

	string sourceUrl = "https://www.le.ac.uk/oerresources/bdra/html/page_01.htm";   // web page URL
	
	string outPath = @"d:\Out";

	try
	{
	    IDocumentApi docApi = new DocumentApi(appKey, appSID, BasePath);
		var response = docApi.GetDocumentByUrl(sourceUrl);
			
		if(response != null && response.ContentStream != null)
		{
			Stream stream = response.ContentStream;
			string outFile = Path.Combine(outPath, response.FileName);
			
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
**sourceUrl** | **String**| The source web page URL to download. |

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/zip

<a name="GetDocumentFragmentByXPath"></a>
# **GetDocumentFragmentByXPath**
> AsposeStreamResponse GetDocumentFragmentByXPath(name, xPath, outFormat, storage, folder)

Return list of HTML fragments matching the specified XPath query. 

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
	String xPath = ".//p/@class";              // String | XPath query string.
	string outFormat = "plain";                // String | Output format. Possible values: 'plain' and 'json'.
	
	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, $"{name}_fragments.txt");
	
	string folder = null;     // root folder by default;  put folder path here
	string storage = null;    // default storage; put storage name here

	try
	{
	    IDocumentApi docApi = new DocumentApi(appKey, appSID, BasePath);
		var response = docApi.GetDocumentFragmentByXPath(name, xPath, outFormat, storage, folder);
			
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
 **name** | **String**| The document name. |
 **xPath** | **String**| XPath query string. |
 **outFormat** | **String**| Output format. Possible values: &#39;plain&#39; and &#39;json&#39;. |
 **storage** | **String**| The document storage. | [optional]
 **folder** | **String**| The document folder. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data
 
<a name="GetDocumentFragmentByXPathByUrl"></a>
# **GetDocumentFragmentByXPathByUrl**
> AsposeStreamResponse GetDocumentFragmentByXPathByUrl(sourceUrl, xPath, outFormat)

Return list of HTML fragments matching the specified XPath query - from a Web page by its URL. 

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
	
	string sourceUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_01.htm"; // put here a HTML page URL
	
	string outPath = @"d:\Out";
	Uri uri = new Uri(sourceUrl);
	string outFile = Path.Combine(outPath, $"{Path.GetFileNameWithoutExtension(uri.Segments.LastOrDefault())}_fragments.txt");
	
	string xPath = ".//p/@class";              // String | XPath query string.
	string outFormat = "plain";                // String | Output format. Possible values: 'plain' and 'json'.
	 
	try
	{
	    IDocumentApi docApi = new DocumentApi(appKey, appSID, BasePath);
		var response = docApi.GetDocumentFragmentByXPathByUrl(sourceUrl, xPath, outFormat);
			
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
 **sourceUrl** | **String**| The source document URL. |
 **xPath** | **String**| XPath query string. |
 **outFormat** | **String**| Output format. Possible values: &#39;plain&#39; and &#39;json&#39;. |


### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/plain
 - **Accept**: multipart/form-data


<a name="GetDocumentFragmentByCSSSelector"></a>
# **GetDocumentFragmentByCSSSelector**
> AsposeStreamResponse GetDocumentFragmentByCSSSelector(name, selector, outFormat, storage, folder)

Return list of HTML fragments matching the specified CSS selector. 

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
	String selector = "p[class]";       // String | CSS selector string.
	string outFormat = "plain";         // String | Output format. Possible values: 'plain' and 'json'.
	
	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, $"{name}_css_fragments.txt");
	
	string folder = null;     // root folder by default;  put folder path here
	string storage = null;    // default storage; put storage name here

	try
	{
	    IDocumentApi docApi = new DocumentApi(appKey, appSID, BasePath);
		var response = docApi.GetDocumentFragmentByCSSSelector(name, selector, outFormat, storage, folder);
			
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
 **name** | **String**| The document name. |
 **selector** | **String**| CSS selector string. |
 **outFormat** | **String**| Output format. Possible values: &#39;plain&#39; and &#39;json&#39;. |
 **storage** | **String**| The document storage. | [optional]
 **folder** | **String**| The document folder. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data


#########################################################################

 
<a name="GetDocumentFragmentByCSSSelectorByUrl"></a>
# **GetDocumentFragmentByCSSSelectorByUrl**
> AsposeStreamResponse GetDocumentFragmentByCSSSelectorByUrl(sourceUrl, xPath, outFormat)

Return list of HTML fragments matching the specified CSS selector - from a Web page by its URL. 

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
	
	string sourceUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_01.htm"; // put here a HTML page URL
	
	string outPath = @"d:\Out";
	Uri uri = new Uri(sourceUrl);
	string outFile = Path.Combine(outPath, $"{Path.GetFileNameWithoutExtension(uri.Segments.LastOrDefault())}_css_fragments.txt");
	
	string selector = "p[class]";           // String | CSS selector string.
	string outFormat = "plain";                // String | Output format. Possible values: 'plain' and 'json'.
	 
	try
	{
	    IDocumentApi docApi = new DocumentApi(appKey, appSID, BasePath);
		var response = docApi.GetDocumentFragmentByCSSSelectorByUrl(sourceUrl, selector, outFormat);
			
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
 **sourceUrl** | **String**| The source document URL. |
 **selector**  | **String**| CSS selector string. |
 **outFormat** | **String**| Output format. Possible values: &#39;plain&#39; and &#39;json&#39;. |


### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/plain
 - **Accept**: multipart/form-data



#########################################################################
 
 
<a name="GetDocumentImages"></a>
# **GetDocumentImages**
> AsposeStreamResponse GetDocumentImages(name, folder, storage)

Return all HTML document images packaged as a ZIP archive.

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
	
	string name = "testpage5.html.zip";

	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, $"{name}_fragments.txt");
	
	string folder = null;     // root folder
	string storage = null;    // default storage

	try
	{
	    IDocumentApi docApi = new DocumentApi(appKey, appSID, BasePath);
		var response = docApi.GetDocumentFragmentByXPath(name, storage, folder);
			
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
 **name** | **String**| The document name. |
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/zip

 
<a name="GetDocumentImagesByUrl"></a>
# **GetDocumentImagesByUrl**
> Stream GetDocumentImagesByUrl(sourceUrl)

Return all HTML document images packaged as a ZIP archive.

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
	
	string sourceUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_01.htm"; // put here a HTML page URL
	
	string outPath = @"d:\Out";
	Uri uri = new Uri(sourceUrl);
	string outFile = Path.Combine(outPath, $"{Path.GetFileNameWithoutExtension(uri.Segments.LastOrDefault())}_fragments.txt");
	
	try
	{
	    IDocumentApi docApi = new DocumentApi(appKey, appSID, BasePath);
		var response = docApi.GetDocumentImagesByUrl(sourceUrl);
			
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
 **sourceUrl** | **String**| The source document URL. |

 
### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/zip

