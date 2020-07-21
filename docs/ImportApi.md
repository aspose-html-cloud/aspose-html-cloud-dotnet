# IImportApi

All URIs are relative to *https://api.aspose.cloud/v3.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetImportMarkdownToHtml**](ImportApi.md#GetImportMarkdownToHtml) | **GET** /html/{name}/import/md | Create an HTML document from Markdown file (located in the storage) and return it in the response stream.
[**PutImportMarkdownToHtml**](ImportApi.md#PutImportMarkdownToHtml) | **PUT** /html/{name}/import/md | Create an HTML document from Markdown file (located in the storage) and save it to storage.
[**PostImportMarkdownToHtml**](ImportApi.md#PostImportMarkdownToHtml) | **POST** /html/import/md | Create an HTML document from Markdown file as input stream and save it to storage.
[**PostImportMarkdownToHtml**](ImportApi.md#PostImportMarkdownToHtml_1) | **POST** /html/import/md | Overloaded method. Create an HTML document from Markdown file (located in the local file system) and save it to storage.

<a name="GetImportMarkdownToHtml"></a>
# **GetImportMarkdownToHtml**
> StreamResponse GetImportMarkdownToHtml(name, folder, storage)

Create an HTML document from Markdown file (located in the storage) and return it in the response stream.

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
    string BasePath = "https://api.aspose.cloud";
    
    string folder = "/Html/TestData";   // source folder
    string storage = null;              // default storage
    
    string name = "testpage1.md";
    
    string srcDataDir = @"d:\Data";
    string srcPath = Path.Combine(srcDataDir, name);    
    string storagePath = Path.Combine(folder, name).Replace('\\', '/');
    
    string outPath = @"d:\Out";
    string outFile = Path.Combine(outPath, $"{name}_converted.html");
    
    try
    {
        IStorageFileApi fileApi = new StorageApi(appKey, appSID, BasePath, authPath);
        var stResp = fileApi.UploadFile(srcPath, storagePath, storage);
        if(stResp != null && stResp.Status = "OK")
        {
            IImportApi convApi = new HtmlApi(fileApi);
            var response = convApi.GetImportMarkdownToHtml(name, folder, storage);
                
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
 **name** | **String** | Source file name. |
 **folder** | **String** | Source file folder. | [optional]
 **storage** | **String** | Source file storage. | [optional]
 
 ### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: text/markdown
 - **Accept**: text/html
 
<a name="PutImportMarkdownToHtml"></a>
# **PutImportMarkdownToHtml**
> StreamResponse PutImportMarkdownToHtml(name, outPath, folder, storage)

Create an HTML document from Markdown file (located in the storage) and save it to storage.

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
    string BasePath = "https://api.aspose.cloud";
    
    string folder = "/Html/TestData";   // source folder
    string storage = null;              // default storage
    string outFolder = "Html/Testout";
    
    string name = "testpage1.md";
    
    string srcDataDir = "d:\Data";
    string srcPath = Path.Combine(srcPath, name);
    string storagePath = Path.Combine(folder, name).Replace('\\', '/');
    string outPath = Path.Combine(outFolder, $"{name}_converted_put.html").Replace('\\', '/');
    try
    {
        IStorageFileApi fileApi = new StorageApi(appKey, appSID, BasePath, authPath);
        var stResp = fileApi.UploadFile(srcPath, storagePath, storage);
        if(stResp != null && stResp.Status = "OK")
        {
            IImportApi convApi = new HtmlApi(fileApi);
            var response = convApi.PutImportMarkdownToHtml(name, outPath, folder, storage);
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
 **name** | **String** | Source file name. |
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.html |
 **folder** | **String** | Source file folder. | [optional]
 **storage** | **String** | Source & result file storage. | [optional]
 
 ### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: text/markdown
 - **Accept**: application/json
 
 
<a name="PostImportMarkdownToHtml"></a>
# **PostImportMarkdownToHtml**
> StreamResponse PostImportMarkdownToHtml(inStream, outPath, storage)

Create an HTML document from Markdown file as input stream and save it to storage.

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
    string BasePath = "https://api.aspose.cloud";
    
    string storage = null;    // default storage
    string outFolder = "Html/Testout";
    
    string name = "testpage1.md";
    
    string srcDataDir = "d:\Data";
    string srcPath = Path.Combine(srcPath, name);
    string outPath = Path.Combine(outFolder, $"{name}_converted_post.html").Replace('\\', '/');
    
    try
    {
        using(Stream inStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read)
        {
            IImportApi importApi = new HtmlApi(appKey, appSID, BasePath, authPath);
            var response = importApi.PostImportMarkdownToHtml(stream, outPath, storage);
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
 **inStream** | **Stream**| Source stream. |
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.html |
 **storage** | **String** | Result file storage. | [optional]
 
 ### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json
 
 
 <a name="PostImportMarkdownToHtml_1"></a>
# **PostImportMarkdownToHtml**
> StreamResponse PostImportMarkdownToHtml(localFilePath, outPath, storage)

Overloaded method. Create an HTML document from Markdown file (located in the local file system) and save it to storage.

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
    string BasePath = "https://api.aspose.cloud";
    
    string storage = null;    // default storage
    string outFolder = "Html/Testout";
    
    string name = "testpage1.md";
    
    string srcDataDir = "d:\Data";
    string srcPath = Path.Combine(srcPath, name);
    string outPath = Path.Combine(outFolder, $"{name}_converted_post.html").Replace('\\', '/');
    
    try
    {
        IImportApi importApi = new HtmlApi(appKey, appSID, BasePath, authPath);
        var response = importApi.PostImportMarkdownToHtml(srcPath, outPath, storage);
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
 **localFilePath** | **String**| Local file path. |
 **outPath** | **String**| Path to resulting file; like this: [/Folder1][/Folder2]/Filename.html |
 **storage** | **String** | Result file storage. | [optional]
 
 ### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json
 
 