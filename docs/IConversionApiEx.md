
# IConversionApiEx

All URIs are relative to *https://api.aspose.cloud/v3.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PostConvertDocumentToImageAndDownload**](IConversionApiEx.md#PostConvertDocumentToImageAndDownload) | **POST** /html/convert/image/{outFormat} | Extension method. Convert the HTML document from the request stream to the specified image format, save to storage and download to stream.
[**PostConvertDocumentToImageAndDownload**](IConversionApiEx.md#PostConvertDocumentToImageAndDownload_1) | **POST** /html/convert/image/{outFormat} | Overloaded extension method. Convert the HTML document from the local file system to the specified image format, save to storage and download to stream.
[**PostConvertDocumentToPdfAndDownload**](IConversionApiEx.md#PostConvertDocumentToPdfAndDownload) | **POST** /html/convert/pdf | Extension method. Convert the HTML document from the request stream to PDF, save to storage and download to stream.
[**PostConvertDocumentToPdfAndDownload**](IConversionApiEx.md#PostConvertDocumentToPdfAndDownload_1) | **POST** /html/convert/pdf | Overloaded extension method. Convert the HTML document from the local file system to PDF, save to storage and download to stream.
[**PostConvertDocumentToXpsAndDownload**](IConversionApiEx.md#PostConvertDocumentToXpsAndDownload) | **POST**  /html/convert/xps | Extension method. Convert the HTML document from the request stream to XPS, save to storage and download to stream.
[**PostConvertDocumentToXpsAndDownload**](IConversionApiEx.md#PostConvertDocumentToXpsAndDownload_1) | **POST**  /html/convert/xps | Overloaded extension method. Convert the HTML document from the local file system to XPS, save to storage and download to stream.
[**PostConvertDocumentToMarkdownAndDownload**](IConversionApiEx.md#PostConvertDocumentToMarkdownAndDownload) | **POST**  /html/convert/md | Extension method. Convert the HTML document from the request stream to Markdown, save to storage and download to stream.
[**PostConvertDocumentToMarkdownAndDownload**](IConversionApiEx.md#PostConvertDocumentToMarkdownAndDownload_1) | **POST**  /html/convert/md | Overloaded extension method. Convert the HTML document from the local file system to Markdown, save to storage and download to stream.


<a name="PostConvertDocumentToImageAndDownload"></a>
# **PostConvertDocumentToImageAndDownload**
> StreamResponse PostConvertDocumentToImageAndDownload(inStream, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage)

Extension method. Convert the HTML document from the request stream to the specified image format, save to storage and download to stream.

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended;

public class Example
{
	static string appKey = "XXXXX";   // put here your app key
	static string appSID = "XXXXX";   // put here your app SID
	static string BasePath = "https://api.aspose.cloud";
	static string authPath = "https://api.aspose.cloud";

	public static void Main(string[] args)
	{
		string name = "testpage4_embcss.html";
		string format = "jpeg";
		string folder = "/HTML/Testout";  // result folder in the storage 
		string storage = null;            // default storage
		
		// local source file
		string srcDir = @"d:\testdata";
		string srcPath = Path.Combine(srcDir, name);
		
		// storage file path
		string outFile = $"{name}_converted.jpg"
		string outPath = Path.Combine(folder, outFile).Replace('\\', '/');
		
		// local result file
		string outPathLocal = @"d:\Out";
		string outFileLocal = Path.Combine(outPathLocal, outFile);

		int width = 800;
		int height = 1200;
		int leftMargin = 15;
		int rightMargin = 15;
		int topMargin = 15;
		int bottomMargin = 15;
		int resolution = 96;
		
		try
		{
			IConversionApiEx convApi = new HtmlApi(appKey, appSID, BasePath, authPath);
			if(File.Exists(srcPath))
			{
				using(Stream inStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read)
				{
					var response = convApi.PostConvertDocumentToImageAndDownload(
						inStream, format, outPath, width, height,
						leftMargin, rightMargin, topMargin, bottomMargin,
						resolution, storage);
						
					if(response != null && response.ContentStream != null)
					{
						Stream stream = response.ContentStream;
						
						if(!Directory.Exists(outPathLocal)) Directory.CreateDirectory(outPathLocal);
						using(Stream fstr = new FileStream(outFileLocal, FileMode.Create, FileAccess.Write))
						{
							response.CopyTo(fstr);
							fstr.Flush();
							Console.Out.WriteLine(string.Format("Result file copied to: {0}", outFileLocal));
						}
					}
				}
			}
			else
				throw new Exception($"{srcPath}: file not found");
		}
		catch(Exception ex)
		{
			Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
		}	
	}
}

```


### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **inStream** | **Stream**| Document stream. |
 **outFormat** | **String**| Resulting image format. |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **resolution** | **int**| Horizontal and vertical resolution of resulting image. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: image/jpeg, image/tiff, image/png, image/gif, image/bmp
 
 
 
<a name="PostConvertDocumentToImageAndDownload_1"></a>
# **PostConvertDocumentToImageAndDownload**
> StreamResponse PostConvertDocumentToImageAndDownload(localFilePath, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage)

Overloaded extension method. Convert the HTML document from the local file system to the specified image format, save to storage and download to stream.

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended;

public class Example
{
	static string appKey = "XXXXX";   // put here your app key
	static string appSID = "XXXXX";   // put here your app SID
	static string BasePath = "https://api.aspose.cloud";
	static string authPath = "https://api.aspose.cloud";

	public static void Main(string[] args)
	{
		string name = "testpage4_embcss.html";
		string folder = "/HTML/Testout";  // result folder in the storage 
		string storage = null;            // default storage
		
		// local source file
		string srcDir = @"d:\testdata";
		string srcPath = Path.Combine(srcDir, name);
		
		// storage file path
		string outFile = $"{name}_converted.jpg"
		string outPath = Path.Combine(folder, outFile).Replace('\\', '/');
		
		// local result file
		string outPathLocal = @"d:\Out";
		string outFileLocal = Path.Combine(outPathLocal, outFile);

		int width = 800;
		int height = 1200;
		int leftMargin = 15;
		int rightMargin = 15;
		int topMargin = 15;
		int bottomMargin = 15;
		int resolution = 96;
		
		try
		{
			IConversionApiEx convApi = new HtmlApi(appKey, appSID, BasePath, authPath);
			if(File.Exists(srcPath))
			{
				var response = convApi.PostConvertDocumentToImageAndDownload(
					srcPath, format, outPath, width, height,
					leftMargin, rightMargin, topMargin, bottomMargin,
					resolution, storage);
					
				if(response != null && response.ContentStream != null)
				{
					Stream stream = response.ContentStream;
					
					if(!Directory.Exists(outPathLocal)) Directory.CreateDirectory(outPathLocal);
					using(Stream fstr = new FileStream(outFileLocal, FileMode.Create, FileAccess.Write))
					{
						response.CopyTo(fstr);
						fstr.Flush();
						Console.Out.WriteLine(string.Format("Result file copied to: {0}", outFileLocal));
					}
				}
			}
			else
				throw new Exception($"{srcPath}: file not found");
		}
		catch(Exception ex)
		{
			Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
		}	
	}

}

```


### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **localFilePath** | **String**| Source file path. |
 **outFormat** | **String**| Resulting image format. |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **resolution** | **int**| Horizontal and vertical resolution of resulting image. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: image/jpeg, image/tiff, image/png, image/gif, image/bmp
 
 
 
 <a name="PostConvertDocumentToPdfAndDownload"></a>
# **PostConvertDocumentToPdfAndDownload**
> StreamResponse PostConvertDocumentToPdfAndDownload(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Extension method. Convert the HTML document from the request stream to PDF format, save to storage and download to stream.

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended;

public class Example
{
	static string appKey = "XXXXX";   // put here your app key
	static string appSID = "XXXXX";   // put here your app SID
	static string BasePath = "https://api.aspose.cloud";
	static string authPath = "https://api.aspose.cloud";

	public static void Main(string[] args)
	{
		string name = "testpage1.html";
		string folder = "/HTML/Testout";  // result folder in the storage 
		string storage = null;            // default storage
		
		// local source file
		string srcDir = @"d:\testdata";
		string srcPath = Path.Combine(srcDir, name);
		
		// storage file path
		string outFile = $"{name}_converted.pdf"
		string outPath = Path.Combine(folder, outFile).Replace('\\', '/');
		
		// local result file
		string outPathLocal = @"d:\Out";
		string outFileLocal = Path.Combine(outPathLocal, outFile);

		int width = 800;
		int height = 1200;
		int leftMargin = 15;
		int rightMargin = 15;
		int topMargin = 15;
		int bottomMargin = 15;
		
		try
		{
			IConversionApiEx convApi = new HtmlApi(appKey, appSID, BasePath, authPath);
			if(File.Exists(srcPath))
			{
				using(Stream inStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read)
				{
					var response = convApi.PostConvertDocumentToPdfAndDownload(
						inStream, outPath, width, height,
						leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage);
						
					if(response != null && response.ContentStream != null)
					{
						Stream stream = response.ContentStream;
						
						if(!Directory.Exists(outPathLocal)) Directory.CreateDirectory(outPathLocal);
						using(Stream fstr = new FileStream(outFileLocal, FileMode.Create, FileAccess.Write))
						{
							response.CopyTo(fstr);
							fstr.Flush();
							Console.Out.WriteLine(string.Format("Result file copied to: {0}", outFileLocal));
						}
					}
				}
			}
			else
				throw new Exception($"{srcPath}: file not found");
		}
		catch(Exception ex)
		{
			Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
		}	
	}
}

```


### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **inStream** | **Stream**| Document stream. |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/pdf
 
 
 <a name="PostConvertDocumentToPdfAndDownload_1"></a>
# **PostConvertDocumentToPdfAndDownload**
> StreamResponse PostConvertDocumentToPdfAndDownload(localFilePath, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Overloaded extension method. Convert the HTML document from the local file system to PDF format, save to storage and download to stream.

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended;

public class Example
{
	static string appKey = "XXXXX";   // put here your app key
	static string appSID = "XXXXX";   // put here your app SID
	static string BasePath = "https://api.aspose.cloud";
	static string authPath = "https://api.aspose.cloud";

	public static void Main(string[] args)
	{
		string name = "testpage4_embcss.html";
		string folder = "/HTML/Testout";  // result folder in the storage 
		string storage = null;            // default storage
		
		// local source file
		string srcDir = @"d:\testdata";
		string srcPath = Path.Combine(srcDir, name);
		
		// storage file path
		string outFile = $"{name}_converted.pdf"
		string outPath = Path.Combine(folder, outFile).Replace('\\', '/');
		
		// local result file
		string outPathLocal = @"d:\Out";
		string outFileLocal = Path.Combine(outPathLocal, outFile);

		int width = 800;
		int height = 1200;
		int leftMargin = 15;
		int rightMargin = 15;
		int topMargin = 15;
		int bottomMargin = 15;
		int resolution = 96;
		
		try
		{
			IConversionApiEx convApi = new HtmlApi(appKey, appSID, BasePath, authPath);
			if(File.Exists(srcPath))
			{
				var response = convApi.PostConvertDocumentToPdfAndDownload(
					srcPath, outPath, width, height,
					leftMargin, rightMargin, topMargin, bottomMargin,
					resolution, storage);
					
				if(response != null && response.ContentStream != null)
				{
					Stream stream = response.ContentStream;
					
					if(!Directory.Exists(outPathLocal)) Directory.CreateDirectory(outPathLocal);
					using(Stream fstr = new FileStream(outFileLocal, FileMode.Create, FileAccess.Write))
					{
						response.CopyTo(fstr);
						fstr.Flush();
						Console.Out.WriteLine(string.Format("Result file copied to: {0}", outFileLocal));
					}
				}
			}
			else
				throw new Exception($"{srcPath}: file not found");
		}
		catch(Exception ex)
		{
			Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
		}	
	}

}

```


### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **localFilePath** | **String**| Source file path. |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
  **storage** | **String**| The document storage. | [optional]

### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/pdf
 
 
 
 <a name="PostConvertDocumentToXpsAndDownload"></a>
# **PostConvertDocumentToXpsAndDownload**
> StreamResponse PostConvertDocumentToXpsAndDownload(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Extension method. Convert the HTML document from the request stream to XPS format, save to storage and download to stream.

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended;

public class Example
{
	static string appKey = "XXXXX";   // put here your app key
	static string appSID = "XXXXX";   // put here your app SID
	static string BasePath = "https://api.aspose.cloud";
	static string authPath = "https://api.aspose.cloud";

	public static void Main(string[] args)
	{
		string name = "testpage1.html";
		string folder = "/HTML/Testout";  // result folder in the storage 
		string storage = null;            // default storage
		
		// local source file
		string srcDir = @"d:\testdata";
		string srcPath = Path.Combine(srcDir, name);
		
		// storage file path
		string outFile = $"{name}_converted.xps"
		string outPath = Path.Combine(folder, outFile).Replace('\\', '/');
		
		// local result file
		string outPathLocal = @"d:\Out";
		string outFileLocal = Path.Combine(outPathLocal, outFile);

		int width = 800;
		int height = 1200;
		int leftMargin = 15;
		int rightMargin = 15;
		int topMargin = 15;
		int bottomMargin = 15;
		
		try
		{
			IConversionApiEx convApi = new HtmlApi(appKey, appSID, BasePath, authPath);
			if(File.Exists(srcPath))
			{
				using(Stream inStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read)
				{
					var response = convApi.PostConvertDocumentToXpsAndDownload(
						inStream, outPath, width, height,
						leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage);
						
					if(response != null && response.ContentStream != null)
					{
						Stream stream = response.ContentStream;
						
						if(!Directory.Exists(outPathLocal)) Directory.CreateDirectory(outPathLocal);
						using(Stream fstr = new FileStream(outFileLocal, FileMode.Create, FileAccess.Write))
						{
							response.CopyTo(fstr);
							fstr.Flush();
							Console.Out.WriteLine(string.Format("Result file copied to: {0}", outFileLocal));
						}
					}
				}
			}
			else
				throw new Exception($"{srcPath}: file not found");
		}
		catch(Exception ex)
		{
			Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
		}	
	}
}
```


### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **inStream** | **Stream**| Document stream. |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
 **storage** | **String**| The document storage. | [optional]

### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.ms-xpsdocument
  
 
 <a name="PostConvertDocumentToXpsAndDownload_1"></a>
# **PostConvertDocumentToXpsAndDownload**
> StreamResponse PostConvertDocumentToXpsAndDownload(localFilePath, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Overloaded extension method. Convert the HTML document from the local file system to XPS format, save to storage and download to stream.

```csharp


using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended;

public class Example
{
	static string appKey = "XXXXX";   // put here your app key
	static string appSID = "XXXXX";   // put here your app SID
	static string BasePath = "https://api.aspose.cloud";
	static string authPath = "https://api.aspose.cloud";

	public static void Main(string[] args)
	{
		string name = "testpage4_embcss.html";
		string folder = "/HTML/Testout";  // result folder in the storage 
		string storage = null;            // default storage
		
		// local source file
		string srcDir = @"d:\testdata";
		string srcPath = Path.Combine(srcDir, name);
		
		// storage file path
		string outFile = $"{name}_converted.xps"
		string outPath = Path.Combine(folder, outFile).Replace('\\', '/');
		
		// local result file
		string outPathLocal = @"d:\Out";
		string outFileLocal = Path.Combine(outPathLocal, outFile);

		int width = 800;
		int height = 1200;
		int leftMargin = 15;
		int rightMargin = 15;
		int topMargin = 15;
		int bottomMargin = 15;
		int resolution = 96;
		
		try
		{
			IConversionApiEx convApi = new HtmlApi(appKey, appSID, BasePath, authPath);
			if(File.Exists(srcPath))
			{
				var response = convApi.PostConvertDocumentToXpsAndDownload(
					srcPath, outPath, width, height,
					leftMargin, rightMargin, topMargin, bottomMargin,
					resolution, storage);
					
				if(response != null && response.ContentStream != null)
				{
					Stream stream = response.ContentStream;
					
					if(!Directory.Exists(outPathLocal)) Directory.CreateDirectory(outPathLocal);
					using(Stream fstr = new FileStream(outFileLocal, FileMode.Create, FileAccess.Write))
					{
						response.CopyTo(fstr);
						fstr.Flush();
						Console.Out.WriteLine(string.Format("Result file copied to: {0}", outFileLocal));
					}
				}
			}
			else
				throw new Exception($"{srcPath}: file not found");
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
 **localFilePath** | **String**| Source file path. |
 **width** | **int**| Resulting image width.  | [optional]
 **height** | **int**| Resulting image height.  | [optional]
 **leftMargin** | **int**| Left resulting image margin. | [optional]
 **rightMargin** | **int**| Right resulting image margin. | [optional]
 **topMargin** | **int**| Top resulting image margin. | [optional]
 **bottomMargin** | **int**| Bottom resulting image margin. | [optional]
  **storage** | **String**| The document storage. | [optional]

### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.ms-xpsdocument
 


<a name="PostConvertDocumentToMarkdownAndDownload"></a>
# **PostConvertDocumentToMarkdownAndDownload**
> StreamResponse PostConvertDocumentToMarkdownAndDownload(inStream, outPath, useGit, storage)

Extension method. Convert the HTML document from the request stream to Markdown, save to storage and download to stream.

### Example

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended;

public class Example
{
	static string appKey = "XXXXX";   // put here your app key
	static string appSID = "XXXXX";   // put here your app SID
	static string BasePath = "https://api.aspose.cloud";
	static string authPath = "https://api.aspose.cloud";

	public static void Main(string[] args)
	{
		string name = "testpage4_embcss.html";
		string folder = "/HTML/Testout";  // result folder in the storage 
		string storage = null;            // default storage
		bool useGit = false;
		
		// local source file
		string srcDir = @"d:\testdata";
		string srcPath = Path.Combine(srcDir, name);
		
		// storage file path
		string outFile = $"{name}_converted.md"
		string outPath = Path.Combine(folder, outFile).Replace('\\', '/');
		
		// local result file
		string outPathLocal = @"d:\Out";
		string outFileLocal = Path.Combine(outPathLocal, outFile);	
		
		try
		{
			IConversionApiEx convApi = new HtmlApi(appKey, appSID, BasePath, authPath);
			if(File.Exists(srcPath))
			{
				using(Stream inStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read)
				{
					var response = convApi.PostConvertDocumentToMarkdownAndDownload(inStream, outPath, useGit, storage);
				
					if(response != null && response.ContentStream != null)
					{
						Stream stream = response.ContentStream;
						
						if(!Directory.Exists(outPathLocal)) Directory.CreateDirectory(outPathLocal);
						using(Stream fstr = new FileStream(outFileLocal, FileMode.Create, FileAccess.Write))
						{
							response.CopyTo(fstr);
							fstr.Flush();
							Console.Out.WriteLine(string.Format("Result file copied to: {0}", outFileLocal));
						}
					}
				}
			}
			else
				throw new Exception($"{srcPath}: file not found");
		}
		catch(Exception ex)
		{
			Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
		}	
	
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

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: text/markdown
 
 
 
 <a name="PostConvertDocumentToMarkdownAndDownload_1"></a>
# **PostConvertDocumentToMarkdownAndDownload**
> StreamResponse PostConvertDocumentToMarkdownAndDownload(localFilePath, outPath, useGit, storage)

Overloaded extension method. Convert the HTML document from the local file system to Markdown, save to storage and download to stream.


### Example

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended;

public class Example
{
	static string appKey = "XXXXX";   // put here your app key
	static string appSID = "XXXXX";   // put here your app SID
	static string BasePath = "https://api.aspose.cloud";
	static string authPath = "https://api.aspose.cloud";

	public static void Main(string[] args)
	{
		string name = "testpage4_embcss.html";
		string folder = "/HTML/Testout";  // result folder in the storage 
		string storage = null;            // default storage
		bool useGit = false;
		
		// local source file
		string srcDir = @"d:\testdata";
		string srcPath = Path.Combine(srcDir, name);
		
		// storage file path
		string outFile = $"{name}_converted.md"
		string outPath = Path.Combine(folder, outFile).Replace('\\', '/');
		
		// local result file
		string outPathLocal = @"d:\Out";
		string outFileLocal = Path.Combine(outPathLocal, outFile);	
		
		try
		{
			IConversionApiEx convApi = new HtmlApi(appKey, appSID, BasePath, authPath);
			if(File.Exists(srcPath))
			{
				var response = convApi.PostConvertDocumentToMarkdownAndDownload(srcPath, outPath, useGit, storage);
			
				if(response != null && response.ContentStream != null)
				{
					Stream stream = response.ContentStream;
					
					if(!Directory.Exists(outPathLocal)) Directory.CreateDirectory(outPathLocal);
					using(Stream fstr = new FileStream(outFileLocal, FileMode.Create, FileAccess.Write))
					{
						response.CopyTo(fstr);
						fstr.Flush();
						Console.Out.WriteLine(string.Format("Result file copied to: {0}", outFileLocal));
					}
				}
			}
			else
				throw new Exception($"{srcPath}: file not found");
		}
		catch(Exception ex)
		{
			Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
		}		
	}
}


```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **localFilePath** | **String**| Source file path. |
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg |
 **useGit** | **bool**| Use Git flavor of Markdown format.  | [optional]
 **storage** | **String**| The source and resulting document storage. | [optional]

### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: text/markdown
 
 
