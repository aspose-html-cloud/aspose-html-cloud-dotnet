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


<a name="GetConvertDocumentToImage"></a>
# **GetConvertDocumentToImage**
> Stream GetConvertDocumentToImage(name, outFormat, width, height, leftMargin, rightMargin, topMargin, bottomMargin, xResolution, yResolution, folder, storage)

Convert the HTML document from the storage by its name to the specified image format.

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
	int xResolution = 96;
	int yResolution = 96;	
	
	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.GetConvertDocumentToImage(
			name, format, width, height,
			leftMargin, rightMargin, topMargin, bottomMargin,
			xResolution, yResolution, folder, storage);
			
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
 **name** | **String**| Document name. |
 **outFormat** | **String**| Resulting image format. |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **xResolution** | **int**| Horizontal resolution of resulting image. | [optional]
 **yResolution** | **int**| Vertical resolution of resulting image. | [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

 
<a name="GetConvertDocumentToImageByUrl"></a>
# **GetConvertDocumentToImageByUrl**
> Stream GetConvertDocumentToImageByUrl(sourceUrl, outFormat, width, height, leftMargin, rightMargin, topMargin, bottomMargin, xResolution, yResolution, storage)

Convert the HTML page from the web by its URL to the specified image format.

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
	int xResolution = 96;
	int yResolution = 96;	
	
	try
	{
	    IConversionApi convApi = new ConversionApi(appKey, appSID, BasePath);
		var response = convApi.GetConvertDocumentToImageByUrl(
			sourceUrl, format, width, height,
			leftMargin, rightMargin, topMargin, bottomMargin,
			xResolution, yResolution);
			
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
 **sourceUrl** | **String**| Source page URL. |
 **outFormat** | **String**| Resulting image format. |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **xResolution** | **int**| Horizontal resolution of resulting image. | [optional]
 **yResolution** | **int**| Vertical resolution of resulting image. | [optional]

### Return type

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

 
<a name="GetConvertDocumentToPdf"></a>
# **GetConvertDocumentToPdf**
> Stream GetConvertDocumentToPdf(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage)

Convert the HTML document from the storage by its name to PDF.

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

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

<a name="GetConvertDocumentToPdfByUrl"></a>
# **GetConvertDocumentToPdfByUrl**
> Stream GetConvertDocumentToPdfByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Convert the HTML page from the web by its URL to PDF.

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
 **sourceUrl** | **String**| Source page URL. |
 **width** | **Integer**| Resulting image width.  | [optional]
 **height** | **Integer**| Resulting image height.  | [optional]
 **leftMargin** | **Integer**| Left resulting image margin. | [optional]
 **rightMargin** | **Integer**| Right resulting image margin. | [optional]
 **topMargin** | **Integer**| Top resulting image margin. | [optional]
 **bottomMargin** | **Integer**| Bottom resulting image margin. | [optional]

### Return type

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

<a name="GetConvertDocumentToXps"></a>
# **GetConvertDocumentToXps**
> Stream GetConvertDocumentToXps(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage)

Convert the HTML document from the storage by its name to XPS.

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

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

<a name="GetConvertDocumentToXpsByUrl"></a>
# **GetConvertDocumentToXpsByUrl**
> Stream GetConvertDocumentToXpsByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Convert the HTML page from the web by its URL to XPS.

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
			leftMargin, rightMargin, topMargin, bottomMargin,
			xResolution, yResolution);
			
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
 **sourceUrl** | **String**| Source page URL. |
 **width** | **Integer**| Resulting image width.  | [optional]
 **height** | **Integer**| Resulting image height.  | [optional]
 **leftMargin** | **Integer**| Left resulting image margin. | [optional]
 **rightMargin** | **Integer**| Right resulting image margin. | [optional]
 **topMargin** | **Integer**| Top resulting image margin. | [optional]
 **bottomMargin** | **Integer**| Bottom resulting image margin. | [optional]

### Return type

[**Stream**](FileStream.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/form-data

