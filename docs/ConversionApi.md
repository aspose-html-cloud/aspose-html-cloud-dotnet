# ConversionApi

All URIs are relative to *https://api.aspose.cloud/v1.1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetConvertDocumentToImage**](ConversionApi.md#GetConvertDocumentToImage) | **GET** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format.
[**GetConvertDocumentToImageByUrl**](ConversionApi.md#GetConvertDocumentToImageByUrl) | **GET** /html/convert/image/{outFormat} | Convert the HTML page from the web by its URL to the specified image format.
[**GetConvertDocumentToPdf**](ConversionApi.md#GetConvertDocumentToPdf) | **GET** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF.
[**GetConvertDocumentToPdfByUrl**](ConversionApi.md#GetConvertDocumentToPdfByUrl) | **GET** /html/convert/pdf | Convert the HTML page from the web by its URL to PDF.
[**GetConvertDocumentToXps**](ConversionApi.md#GetConvertDocumentToXps) | **GET** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS.
[**GetConvertDocumentToXpsByUrl**](ConversionApi.md#GetConvertDocumentToXpsByUrl) | **GET** /html/convert/xps | Convert the HTML page from the web by its URL to XPS.
[**GetConvertDocumentToMarkdown**](ConversionApi.md#GetConvertDocumentToMarkdown) | **GET** /html/{name}/convert/md | Convert the HTML document from the storage by its name to Markdown.
[**GetConvertDocumentToMHTMLByUrl**](ConversionApi.md#GetConvertDocumentToMHTMLByUrl) | **GET** /html/convert/mhtml | Convert the HTML page from the web by its URL to MHTML.
[**PutConvertDocumentToImage**](ConversionApi.md#PutConvertDocumentToImage) | **PUT** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format and save to storage.
[**PutConvertDocumentToImage**](ConversionApi.md#PutConvertDocumentToImage_1) | **PUT** /html/convert/image/{outFormat} | Convert the HTML document from the request stream to the specified image format and save to storage.
[**PutConvertDocumentToPdf**](ConversionApi.md#PutConvertDocumentToPdf) | **PUT** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF and save to storage.
[**PutConvertDocumentToPdf**](ConversionApi.md#PutConvertDocumentToPdf_1) | **PUT** /html/convert/pdf | Convert the HTML document from the request stream to PDF and save to storage.
[**PutConvertDocumentToXps**](ConversionApi.md#PutConvertDocumentToXps) | **PUT** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS and save to storage.
[**PutConvertDocumentToXps**](ConversionApi.md#PutConvertDocumentToXps_1) | **PUT**  /html/convert/xps | Convert the HTML document from the request stream to XPS and save to storage.
[**PutConvertDocumentToMarkdown**](ConversionApi.md#PutConvertDocumentToMarkdown) | **PUT** /html/{name}/convert/md | Convert the HTML document from the storage by its name to Markdown and save to storage.
[**PutConvertDocumentToMarkdown**](ConversionApi.md#PutConvertDocumentToMarkdown_1) | **PUT**  /html/convert/md | Convert the HTML document from the request stream to Markdown and save to storage.



<a name="GetConvertDocumentToImage"></a>
# **GetConvertDocumentToImage**
> AsposeStreamResponse GetConvertDocumentToImage(name, outFormat, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, folder, storage)

Convert the HTML document from the storage by its name to the specified image format.

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
	string format = "jpeg";
	
	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, $"{name}_converted.jpg");
	
	string folder = null;     // root folder
	string storage = null;    // default storage

	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;
	int resolution = 96;
	
	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.GetConvertDocumentToImage(
			name, format, width, height,
			leftMargin, rightMargin, topMargin, bottomMargin,
			resolution, folder, storage);
			
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
 **outFormat** | **String**| Resulting image format. |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **resolution** | **int**| Horizontal and vertical resolution of resulting image. | [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

 
<a name="GetConvertDocumentToImageByUrl"></a>
# **GetConvertDocumentToImageByUrl**
> AsposeStreamResponse GetConvertDocumentToImageByUrl(sourceUrl, outFormat, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution)

Convert the HTML page from the web by its URL to the specified image format.

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
	string format = "jpeg";
	
	string outPath = @"d:\Out";
	string outFile = Path.Combine(outPath, $"{name}_converted.jpg");

	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;
	int resolution = 96;
	
	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.GetConvertDocumentToImageByUrl(
			sourceUrl, format, width, height,
			leftMargin, rightMargin, topMargin, bottomMargin, resolution);
			
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
 **sourceUrl** | **String**| Source page URL. |
 **outFormat** | **String**| Resulting image format. |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **resolution** | **int**| Horizontal and vertical resolution of resulting image. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

 
<a name="GetConvertDocumentToPdf"></a>
# **GetConvertDocumentToPdf**
> AsposeStreamResponse GetConvertDocumentToPdf(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage)

Convert the HTML document from the storage by its name to PDF.

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
	string outFile = Path.Combine(outPath, $"{name}_converted.pdf");
	
	string folder = null;    // root folder
	string storage = null;   // default storage

	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;
	
	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.GetConvertDocumentToPdf(
			name, format, width, height,
			leftMargin, rightMargin, topMargin, bottomMargin,
			folder, storage);
			
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
 **width** | **Integer**| Resulting image width.  | [optional]
 **height** | **Integer**| Resulting image height.  | [optional]
 **leftMargin** | **Integer**| Left resulting image margin. | [optional]
 **rightMargin** | **Integer**| Right resulting image margin. | [optional]
 **topMargin** | **Integer**| Top resulting image margin. | [optional]
 **bottomMargin** | **Integer**| Bottom resulting image margin. | [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

<a name="GetConvertDocumentToPdfByUrl"></a>
# **GetConvertDocumentToPdfByUrl**
> AsposeStreamResponse GetConvertDocumentToPdfByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin)

Convert the HTML page from the web by its URL to PDF.

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
	string outFile = Path.Combine(outPath, $"{name}_converted.pdf");
	
	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;

	
	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.GetConvertDocumentToPdfByUrl(
			sourceUrl, format, width, height,
			leftMargin, rightMargin, topMargin, bottomMargin,
			xResolution, yResolution);
			
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
 **sourceUrl** | **String**| Source page URL. |
 **width** | **Integer**| Resulting image width.  | [optional]
 **height** | **Integer**| Resulting image height.  | [optional]
 **leftMargin** | **Integer**| Left resulting image margin. | [optional]
 **rightMargin** | **Integer**| Right resulting image margin. | [optional]
 **topMargin** | **Integer**| Top resulting image margin. | [optional]
 **bottomMargin** | **Integer**| Bottom resulting image margin. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

<a name="GetConvertDocumentToXps"></a>
# **GetConvertDocumentToXps**
> AsposeStreamResponse GetConvertDocumentToXps(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage)

Convert the HTML document from the storage by its name to XPS.

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
	string outFile = Path.Combine(outPath, $"{name}_converted.xps");
	
	string folder = null;    // root folder
	string storage = null;   // default storage

	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;
	
	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.GetConvertDocumentToXps(
			name, format, width, height,
			leftMargin, rightMargin, topMargin, bottomMargin,
			folder, storage);
			
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
 **width** | **Integer**| Resulting image width.  | [optional]
 **height** | **Integer**| Resulting image height.  | [optional]
 **leftMargin** | **Integer**| Left resulting image margin. | [optional]
 **rightMargin** | **Integer**| Right resulting image margin. | [optional]
 **topMargin** | **Integer**| Top resulting image margin. | [optional]
 **bottomMargin** | **Integer**| Bottom resulting image margin. | [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data
 

<a name="GetConvertDocumentToMarkdown"></a>
# **GetConvertDocumentToMarkdown**
> AsposeStreamResponse GetConvertDocumentToMarkdown(name, useGit, folder, storage)

Convert the HTML document from the storage by its name to Markdown.

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
	string outFile = Path.Combine(outPath, $"{name}_converted.md");
	
	string folder = null;    // root folder
	string storage = null;   // default storage

	bool useGit = false;
	
	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.GetConvertDocumentToMarkdown(name, useGit, folder, storage);
			
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
 **useGit** | **Boolean**| Use Git flavor of Markdown format.  | [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data



<a name="GetConvertDocumentToXpsByUrl"></a>
# **GetConvertDocumentToXpsByUrl**
> AsposeStreamResponse GetConvertDocumentToXpsByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin)

Convert the HTML page from the web by its URL to XPS.

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
	string outFile = Path.Combine(outPath, $"{name}_converted.xps");
	
	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;
	
	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.GetConvertDocumentToXpsByUrl(
			sourceUrl, format, width, height,
			leftMargin, rightMargin, topMargin, bottomMargin);
			
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
 **sourceUrl** | **String**| Source page URL. |
 **width** | **Integer**| Resulting image width.  | [optional]
 **height** | **Integer**| Resulting image height.  | [optional]
 **leftMargin** | **Integer**| Left resulting image margin. | [optional]
 **rightMargin** | **Integer**| Right resulting image margin. | [optional]
 **topMargin** | **Integer**| Top resulting image margin. | [optional]
 **bottomMargin** | **Integer**| Bottom resulting image margin. | [optional]

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data


<a name="GetConvertDocumentToMHTMLByUrl"></a>
# **GetConvertDocumentToMHTMLByUrl**
> AsposeStreamResponse GetConvertDocumentToMHTMLByUrl(sourceUrl)

Convert the HTML page from the web by its URL to MHTML.

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
	string outFile = Path.Combine(outPath, $"{name}_converted.mht");
	

	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.GetConvertDocumentToMHTMLByUrl(sourceUrl);
			
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
 **sourceUrl** | **String**| Source page URL. |

### Return type

[**AsposeStreamResponse**](AsposeStreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data
 
  
<a name="PutConvertDocumentToImage"></a>
# **PutConvertDocumentToImage**
> AsposeResponse PutConvertDocumentToImage(name, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, folder, storage)

Convert the HTML document from the storage by its name to the specified image format and save to the storage.

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
	
	string outPath = $"/Testout/Conversion/{name}_converted.jpg";
	string outFormat = "jpeg";
	
	string folder = null;    // root folder
	string storage = null;   // default storage

	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;
	int resolution = 300;

	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.PutConvertDocumentToImage(name, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, folder, storage);
		if(response != null && response.Code == 0)
		{
			Console.Out.WriteLine(string.Format("Success: Result file uploaded as {0}", outPath));
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
 **outFormat** | **String**| Resulting image format. |
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **resolution** | **int**| Horizontal and vertical resolution of resulting image. | [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json
 
  
<a name="PutConvertDocumentToImage_1"></a>
# **PutConvertDocumentToImage**
> AsposeResponse PutConvertDocumentToImage(inStream, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage)

Convert the HTML document from the request stream to the specified image format and save to the storage.

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
	
	string srcDataDir = "d:\Data";
	string srcPath = Path.Combine(srcPath, name);
	
	string outPath = $"/Testout/Conversion/{name}_converted.jpg";
	string outFormat = "jpeg";
	
	string storage = null;   // default storage - where result file will be stored 

	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;
	int resolution = 300;

	try
	{
		using(Stream inStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read)
		{
			IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
			var response = convApi.PutConvertDocumentToImage(inStream, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage);
			if(response != null && response.Code == 0)
			{
				Console.Out.WriteLine(string.Format("Success: Result file uploaded as {0}", outPath));
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
 **inStream** | **Stream**| Document stream. |
 **outFormat** | **String**| Resulting image format. |
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **resolution** | **int**| Horizontal and vertical resolution of resulting image. | [optional]
 **storage** | **String**| The source and resulting document storage. | [optional]

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json
 
 
<a name="PutConvertDocumentToPdf"></a>
# **PutConvertDocumentToPdf**
> AsposeResponse PutConvertDocumentToPdf(name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, folder, storage)

Convert the HTML document from the storage by its name to PDF and save to the storage.

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
	
	string outPath = $"/Testout/Conversion/{name}_converted.pdf;

	string folder = null;    // root folder
	string storage = null;   // default storage

	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;

	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.PutConvertDocumentToPdf(name, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
		if(response != null && response.Code == 0)
		{
			Console.Out.WriteLine(string.Format("Success: Result file uploaded as {0}", outPath));
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
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json
 
<a name="PutConvertDocumentToPdf_1"></a>
# **PutConvertDocumentToPdf**
> AsposeResponse PutConvertDocumentToPdf(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Convert the HTML document from the request stream to PDF and save to the storage.

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
	
	string srcDataDir = "d:\Data";
	string srcPath = Path.Combine(srcPath, name);
	
	string outPath = $"/Testout/Conversion/{name}_converted.pdf";
	string outFormat = "pdf";
	
	string storage = null;   // default storage - where result file will be stored 

	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;

	try
	{
		using(Stream inStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read)
		{
			IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
			var response = convApi.PutConvertDocumentToPdf(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
			if(response != null && response.Code == 0)
			{
				Console.Out.WriteLine(string.Format("Success: Result file uploaded as {0}", outPath));
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
 **inStream** | **Stream**| Document stream. |
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **storage** | **String**| The source and resulting document storage. | [optional]

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json
 
<a name="PutConvertDocumentToXps"></a>
# **PutConvertDocumentToXps**
> AsposeResponse PutConvertDocumentToXps(name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage)

Convert the HTML document from the storage by its name to XPS and save to the storage.

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
	
	string outPath = $"/Testout/Conversion/{name}_converted.xps;

	string folder = null;    // root folder
	string storage = null;   // default storage

	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;

	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.PutConvertDocumentToXps(name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
		if(response != null && response.Code == 0)
		{
			Console.Out.WriteLine(string.Format("Success: Result file uploaded as {0}", outPath));
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
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json
 
<a name="PutConvertDocumentToXps_1"></a>
# **PutConvertDocumentToXps**
> AsposeResponse PutConvertDocumentToXps(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Convert the HTML document from the request stream to XPS and save to the storage.

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
	
	string srcDataDir = "d:\Data";
	string srcPath = Path.Combine(srcPath, name);
	
	string outPath = $"/Testout/Conversion/{name}_converted.xps";

	string storage = null;   // default storage - where result file will be stored 

	int width = 800;
	int height = 1200;
	int leftMargin = 15;
	int rightMargin = 15;
	int topMargin = 15;
	int bottomMargin = 15;

	try
	{
		using(Stream inStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read)
		{
			IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
			var response = convApi.PutConvertDocumentToXps(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
			if(response != null && response.Code == 0)
			{
				Console.Out.WriteLine(string.Format("Success: Result file uploaded as {0}", outPath));
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
 **inStream** | **Stream**| Document stream. |
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **storage** | **String**| The source and resulting document storage. | [optional]

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json
 
 
 
<a name="PutConvertDocumentToMarkdown"></a>
# **PutConvertDocumentToMarkdown**
> AsposeResponse PutConvertDocumentToMarkdown(name, outPath, useGit, folder, storage)

Convert the HTML document from the storage by its name to Markdown and save to the storage.

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
	
	string outPath = $"/Testout/Conversion/{name}_converted.md;

	string folder = null;    // root folder
	string storage = null;   // default storage

	bool useGit = false;

	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.PutConvertDocumentToMarkdown(name, outPath, useGit, folder, storage);
		if(response != null && response.Code == 0)
		{
			Console.Out.WriteLine(string.Format("Success: Result file uploaded as {0}", outPath));
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
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg |
 **useGit** | **bool**| Use Git flavor of Markdown format.  | [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

 
<a name="PutConvertDocumentToMarkdown_1"></a>
# **PutConvertDocumentToMarkdown**
> AsposeResponse PutConvertDocumentToMarkdown(inStream, outPath, useGit, storage)

Convert the HTML document from the request stream to Markdown and save to the storage.

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
	
	string srcDataDir = "d:\Data";
	string srcPath = Path.Combine(srcPath, name);
	
	string outPath = $"/Testout/Conversion/{name}_converted.md";

	string storage = null;   // default storage - where result file will be stored 

	bool useGit = false;

	try
	{
		using(Stream inStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read)
		{
			IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
			var response = convApi.PutConvertDocumentToMarkdown(inStream, outPath, useGit, storage);
			if(response != null && response.Code == 0)
			{
				Console.Out.WriteLine(string.Format("Success: Result file uploaded as {0}", outPath));
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
 **inStream** | **Stream**| Document stream. |
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg |
 **useGit** | **bool**| Use Git flavor of Markdown format.  | [optional]
 **storage** | **String**| The source and resulting document storage. | [optional]

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json
 