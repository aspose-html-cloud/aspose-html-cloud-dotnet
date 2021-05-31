# IConversionApi

All URIs are relative to *https://api.aspose.cloud/v3.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetConvertDocumentToImage**](ConversionApi.md#GetConvertDocumentToImage) | **GET** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format.
[**GetConvertDocumentToImageByUrl**](ConversionApi.md#GetConvertDocumentToImageByUrl) | **GET** /html/convert/image/{outFormat} | Convert the HTML page from the web by its URL to the specified image format.
[**GetConvertDocumentToPdf**](ConversionApi.md#GetConvertDocumentToPdf) | **GET** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF.
[**GetConvertDocumentToPdfByUrl**](ConversionApi.md#GetConvertDocumentToPdfByUrl) | **GET** /html/convert/pdf | Convert the HTML page from the web by its URL to PDF.
[**GetConvertDocumentToXps**](ConversionApi.md#GetConvertDocumentToXps) | **GET** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS.
[**GetConvertDocumentToXpsByUrl**](ConversionApi.md#GetConvertDocumentToXpsByUrl) | **GET** /html/convert/xps | Convert the HTML page from the web by its URL to XPS.
[**GetConvertDocumentToDoc**](ConversionApi.md#GetConvertDocumentToDoc) | **GET** /html/{name}/convert/doc | Convert the HTML document from the storage by its name to DOCX (MS Word). 
[**GetConvertDocumentToDocByUrl**](ConversionApi.md#GetConvertDocumentToDocByUrl) | **GET** /html/convert/doc | Convert the HTML page from the web by its URL to DOCX (MS Word). 
[**GetConvertDocumentToMarkdown**](ConversionApi.md#GetConvertDocumentToMarkdown) | **GET** /html/{name}/convert/md | Convert the HTML document from the storage by its name to Markdown.
[**GetConvertDocumentToMHTMLByUrl**](ConversionApi.md#GetConvertDocumentToMHTMLByUrl) | **GET** /html/convert/mhtml | Convert the HTML page from the web by its URL to MHTML.
[**PutConvertDocumentToImage**](ConversionApi.md#PutConvertDocumentToImage) | **PUT** /html/{name}/convert/image/{outFormat} | Convert the HTML document from the storage by its name to the specified image format and save to storage.
[**PostConvertDocumentToImage**](ConversionApi.md#PostConvertDocumentToImage) | **POST** /html/convert/image/{outFormat} | Convert the HTML document from the request stream to the specified image format and save to storage.
[**PostConvertDocumentToImage**](ConversionApi.md#PostConvertDocumentToImage_1) | **POST** /html/convert/image/{outFormat} | Overloaded method. Convert the HTML document from the local file system to the specified image format and save to storage.
[**PutConvertDocumentToPdf**](ConversionApi.md#PutConvertDocumentToPdf) | **PUT** /html/{name}/convert/pdf | Convert the HTML document from the storage by its name to PDF and save to storage.
[**PostConvertDocumentToPdf**](ConversionApi.md#PostConvertDocumentToPdf) | **POST** /html/convert/pdf | Convert the HTML document from the request stream to PDF and save to storage.
[**PostConvertDocumentToPdf**](ConversionApi.md#PostConvertDocumentToPdf_1) | **POST** /html/convert/pdf | Overloaded method. Convert the HTML document from the local file system to PDF and save to storage.
[**PutConvertDocumentToXps**](ConversionApi.md#PutConvertDocumentToXps) | **PUT** /html/{name}/convert/xps | Convert the HTML document from the storage by its name to XPS and save to storage.
[**PostConvertDocumentToXps**](ConversionApi.md#PostConvertDocumentToXps) | **POST**  /html/convert/xps | Convert the HTML document from the request stream to XPS and save to storage.
[**PostConvertDocumentToXps**](ConversionApi.md#PostConvertDocumentToXps_1) | **POST**  /html/convert/xps | Overloaded method. Convert the HTML document from the local file system to XPS and save to storage.
[**PutConvertDocumentToDoc**](ConversionApi.md#PutConvertDocumentToDoc) | **PUT** /html/{name}/convert/doc               | Convert the HTML document from the storage by its name to DOCX (MS Word). and save it to storage. 
 [**PostConvertDocumentToDoc**](ConversionApi.md#PostConvertDocumentToDoc) | **POST** /html/convert/doc                     | Convert the HTML document from the request stream to DOCX (MS Word).and save it to storage. 
 [**PostConvertDocumentToDoc**](ConversionApi.md#PostConvertDocumentToDoc_1) | **POST** /html/convert/doc | Overloaded method. Convert the HTML document from the local file system by its local path to DOCX (MS Word).and save it to storage 
[**PutConvertDocumentToMarkdown**](ConversionApi.md#PutConvertDocumentToMarkdown) | **PUT** /html/{name}/convert/md | Convert the HTML document from the storage by its name to Markdown and save to storage.
[**PostConvertDocumentToMarkdown**](ConversionApi.md#PostConvertDocumentToMarkdown) | **POST**  /html/convert/md | Convert the HTML document from the request stream to Markdown and save to storage.
[**PostConvertDocumentToMarkdown**](ConversionApi.md#PostConvertDocumentToMarkdown_1) | **POST**  /html/convert/md | Overloaded method. Convert the HTML document from the local file system to Markdown and save to storage.



<a name="GetConvertDocumentToImage"></a>
# **GetConvertDocumentToImage**
> StreamResponse GetConvertDocumentToImage(name, outFormat, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, folder, storage)

Convert the HTML document from the storage by its name to the specified image format.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";
    string authPath = "https://api.aspose.cloud";
    
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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath, authPath);
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

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: image/jpeg, image/tiff, image/png, image/gif, image/bmp


<a name="GetConvertDocumentToImageByUrl"></a>
# **GetConvertDocumentToImageByUrl**
> StreamResponse GetConvertDocumentToImageByUrl(sourceUrl, outFormat, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution)

Convert the HTML page from the web by its URL to the specified image format.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";
    string authPath = "https://api.aspose.cloud";    

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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath, authPath);
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

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: image/jpeg, image/tiff, image/png, image/gif, image/bmp


<a name="GetConvertDocumentToPdf"></a>
# **GetConvertDocumentToPdf**
> StreamResponse GetConvertDocumentToPdf(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage)

Convert the HTML document from the storage by its name to PDF.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";
    string authPath = "https://api.aspose.cloud";

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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath, authPath);
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

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/pdf


<a name="GetConvertDocumentToPdfByUrl"></a>
# **GetConvertDocumentToPdfByUrl**
> StreamResponse GetConvertDocumentToPdfByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin)

Convert the HTML page from the web by its URL to PDF.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";
    string authPath = "https://api.aspose.cloud";    

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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath, authPath);
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

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/pdf


<a name="GetConvertDocumentToXps"></a>
# **GetConvertDocumentToXps**
> StreamResponse GetConvertDocumentToXps(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage)

Convert the HTML document from the storage by its name to XPS.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";
    string authPath = "https://api.aspose.cloud";
    
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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath, authPath);
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

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.ms-xpsdocument



<a name="GetConvertDocumentToXpsByUrl"></a>

# **GetConvertDocumentToXpsByUrl**
> StreamResponse GetConvertDocumentToXpsByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin)

Convert the HTML page from the web by its URL to XPS.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";
    string authPath = "https://api.aspose.cloud";

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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath, authPath);
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

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.ms-xpsdocument



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
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";
    string authPath = "https://api.aspose.cloud";
    
    string name = "testpage4_embcss.html";
    
    string outPath = @"d:\Out";
    string outFile = Path.Combine(outPath, $"{name}_converted.md");
    
    string folder = null;    // root folder
    string storage = null;   // default storage

    bool useGit = false;
    
    try
    {
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath, authPath);
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

| Name        | Type        | Description                        | Notes      |
| ----------- | ----------- | ---------------------------------- | ---------- |
| **name**    | **String**  | Document name.                     |            |
| **useGit**  | **Boolean** | Use Git flavor of Markdown format. | [optional] |
| **folder**  | **String**  | The document folder.               | [optional] |
| **storage** | **String**  | The document storage.              | [optional] |

### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/markdown


<a name="GetConvertDocumentToMHTMLByUrl"></a>
# **GetConvertDocumentToMHTMLByUrl**
> StreamResponse GetConvertDocumentToMHTMLByUrl(sourceUrl)

Convert the HTML page from the web by its URL to MHTML.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";
    
    string sourceUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_01.htm";
    
    string outPath = @"d:\Out";
    string outFile = Path.Combine(outPath, $"{name}_converted.mht");
    
    try
    {
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
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

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: multipart/related



<a name="GetConvertDocumentToDoc"></a>

# **GetConvertDocumentToDoc**

> StreamResponse GetConvertDocumentToDoc(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage)

Convert the HTML document from the storage by its name to DOCX (MS Word).

### Example

```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";
    string authPath = "https://api.aspose.cloud";
    
    string name = "testpage4_embcss.html";

    string outPath = @"d:\Out";
    string outFile = Path.Combine(outPath, $"{name}_converted.docx");
    
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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath, authPath);
        var response = convApi.GetConvertDocumentToDoc(
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

| Name             | Type        | Description                    | Notes      |
| ---------------- | ----------- | ------------------------------ | ---------- |
| **name**         | **String**  | Document name.                 |            |
| **width**        | **Integer** | Resulting image width.         | [optional] |
| **height**       | **Integer** | Resulting image height.        | [optional] |
| **leftMargin**   | **Integer** | Left resulting image margin.   | [optional] |
| **rightMargin**  | **Integer** | Right resulting image margin.  | [optional] |
| **topMargin**    | **Integer** | Top resulting image margin.    | [optional] |
| **bottomMargin** | **Integer** | Bottom resulting image margin. | [optional] |
| **folder**       | **String**  | The document folder.           | [optional] |
| **storage**      | **String**  | The document storage.          | [optional] |

### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.openxmlformats-officedocument.wordprocessingml.document



<a name="GetConvertDocumentToDocByUrl"></a>

# **GetConvertDocumentToDocByUrl**

> StreamResponse GetConvertDocumentToDocByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin)

Convert the HTML page from the web by its URL to DOCX (MS Word).

### Example

```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";
    string authPath = "https://api.aspose.cloud";

    string sourceUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_01.htm";
    
    string outPath = @"d:\Out";
    string outFile = Path.Combine(outPath, $"{name}_converted.docx");
    
    int width = 800;
    int height = 1200;
    int leftMargin = 15;
    int rightMargin = 15;
    int topMargin = 15;
    int bottomMargin = 15;
    
    try
    {
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath, authPath);
        var response = convApi.GetConvertDocumentToDocByUrl(
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

| Name             | Type        | Description                    | Notes      |
| ---------------- | ----------- | ------------------------------ | ---------- |
| **sourceUrl**    | **String**  | Source page URL.               |            |
| **width**        | **Integer** | Resulting image width.         | [optional] |
| **height**       | **Integer** | Resulting image height.        | [optional] |
| **leftMargin**   | **Integer** | Left resulting image margin.   | [optional] |
| **rightMargin**  | **Integer** | Right resulting image margin.  | [optional] |
| **topMargin**    | **Integer** | Top resulting image margin.    | [optional] |
| **bottomMargin** | **Integer** | Bottom resulting image margin. | [optional] |

### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.openxmlformats-officedocument.wordprocessingml.document



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
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
        var response = convApi.PutConvertDocumentToImage(name, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, folder, storage);
        if(response != null && response.Status == "OK")
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


<a name="PostConvertDocumentToImage"></a>
# **PostConvertDocumentToImage**
> AsposeResponse PostConvertDocumentToImage(inStream, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage)

Convert the HTML document from the request stream to the specified image format and save to the storage.

### Example

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

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
            IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
            var response = convApi.PostConvertDocumentToImage(
                inStream, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage);
            if(response != null && response.Status == "OK")
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


 <a name="PostConvertDocumentToImage_1"></a>
# **PostConvertDocumentToImage**
> AsposeResponse PostConvertDocumentToImage(localFilePath, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage)

Overloaded method. Convert the HTML document from the local file system to the specified image format and save to the storage.

### Example

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

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
            IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
            var response = convApi.PostConvertDocumentToImage(srcPath, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage);
            if(response != null && response.Status == "OK")
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
 **localFilePath** | **String**| Source file path. |
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
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

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
        IConversionApi convApi = new ConversionApi(clientID, clientSecret, BasePath);
        var response = convApi.PutConvertDocumentToPdf(name, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        if(response != null && response.Status == "OK")
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

<a name="PostConvertDocumentToPdf"></a>
# **PostConvertDocumentToPdf**
> AsposeResponse PostConvertDocumentToPdf(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Convert the HTML document from the request stream to PDF and save to the storage.

### Example

```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

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
            IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
            var response = convApi.PostConvertDocumentToPdf(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
            if(response != null && response.Status == "OK")
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


 <a name="PostConvertDocumentToPdf_1"></a>
# **PostConvertDocumentToPdf**
> AsposeResponse PostConvertDocumentToPdf(localFilePath, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Overloaded method. Convert the HTML document from the local file system to PDF and save to the storage.

### Example

```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
        var response = convApi.PostConvertDocumentToPdf(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
        if(response != null && response.Status == "OK")
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
 **localFilePath** | **String**| Local document file path. |
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
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
        var response = convApi.PutConvertDocumentToXps(name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        if(response != null && response.Status == "OK")
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

<a name="PostConvertDocumentToXps"></a>
# **PostConvertDocumentToXps**
> AsposeResponse PostConvertDocumentToXps(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Convert the HTML document from the request stream to XPS and save to the storage.

### Example

```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

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
            IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
            var response = convApi.PostConvertDocumentToXps(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
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


<a name="PostConvertDocumentToXps_1"></a>
# **PostConvertDocumentToXps**
> AsposeResponse PostConvertDocumentToXps(localFilePath, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Overloaded method. Convert the HTML document from the local file system to XPS and save to the storage.

### Example

```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
        var response = convApi.PostConvertDocumentToXps(srcPath, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
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
 **localFilePath** | **String**| Local document file path. |
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

 

<a name="PutConvertDocumentToDoc"></a>
# **PutConvertDocumentToDoc**
> AsposeResponse PutConvertDocumentToDoc(name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage)

Convert the HTML document from the storage by its name to DOCX (MS Word) and save to the storage.

### Example

```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

    string name = "testpage4_embcss.html";
    
    string outPath = $"/Testout/Conversion/{name}_converted.docx;

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
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
        var response = convApi.PutConvertDocumentToDoc(name, outPath, width, height, 
                                                       leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        if(response != null && response.Status == "OK")
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



<a name="PostConvertDocumentToDoc"></a>
# **PostConvertDocumentToDoc**
> AsposeResponse PostConvertDocumentToDoc(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Convert the HTML document from the request stream to DOCX (MS Word) and save to the storage.

### Example

```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

    string name = "testpage4_embcss.html";
    
    string srcDataDir = "d:\Data";
    string srcPath = Path.Combine(srcPath, name);
    
    string outPath = $"/Testout/Conversion/{name}_converted.docx";

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
            IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
            var response = convApi.PostConvertDocumentToDoc(inStream, outPath, width, height, 
                                                            leftMargin, rightMargin, topMargin, bottomMargin, storage);
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


<a name="PostConvertDocumentToDoc_1"></a>
# **PostConvertDocumentToDoc**
> AsposeResponse PostConvertDocumentToDoc(localFilePath, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage)

Overloaded method. Convert the HTML document from the local file system to DOCX (MS Word) and save to the storage.

### Example

```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

    string name = "testpage4_embcss.html";
    
    string srcDataDir = "d:\Data";
    string srcPath = Path.Combine(srcPath, name);
    
    string outPath = $"/Testout/Conversion/{name}_converted.docx";

    string storage = null;   // default storage - where result file will be stored 

    int width = 800;
    int height = 1200;
    int leftMargin = 15;
    int rightMargin = 15;
    int topMargin = 15;
    int bottomMargin = 15;

    try
    {
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
        var response = convApi.PostConvertDocumentToDoc(srcPath, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
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
 **localFilePath** | **String**| Local document file path. |
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
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

    string name = "testpage4_embcss.html";
    
    string outPath = $"/Testout/Conversion/{name}_converted.md;

    string folder = null;    // root folder
    string storage = null;   // default storage

    bool useGit = false;

    try
    {
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
        var response = convApi.PutConvertDocumentToMarkdown(name, outPath, useGit, folder, storage);
        if(response != null && response.Status == "OK")
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


<a name="PostConvertDocumentToMarkdown"></a>
# **PostConvertDocumentToMarkdown**
> AsposeResponse PostConvertDocumentToMarkdown(inStream, outPath, useGit, storage)

Convert the HTML document from the request stream to Markdown and save to the storage.

### Example

```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

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
            IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
            var response = convApi.PostConvertDocumentToMarkdown(inStream, outPath, useGit, storage);
            if(response != null && response.Status == "OK")
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


 <a name="PostConvertDocumentToMarkdown_1"></a>
# **PostConvertDocumentToMarkdown**
> AsposeResponse PostConvertDocumentToMarkdown(localFilePath, outPath, useGit, storage)

Convert the HTML document from the request stream to Markdown and save to the storage.

### Example

```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

public static void Main(string[] args)
{
    string clientSecret = "XXXXX";   // put here your app key
    string clientID = "XXXXX";   // put here your app SID
    string BasePath = "https://api.aspose.cloud";

    string name = "testpage4_embcss.html";
    
    string srcDataDir = "d:\Data";
    string srcPath = Path.Combine(srcPath, name);
    
    string outPath = $"/Testout/Conversion/{name}_converted.md";

    string storage = null;   // default storage - where result file will be stored 

    bool useGit = false;

    try
    {
        IConversionApi convApi = new HtmlApi(clientID, clientSecret, BasePath);
        var response = convApi.PostConvertDocumentToMarkdown(srcPath, outPath, useGit, storage);
        if(response != null && response.Status == "OK")
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
 **localFilePath** | **String**| Local document file path. |
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
