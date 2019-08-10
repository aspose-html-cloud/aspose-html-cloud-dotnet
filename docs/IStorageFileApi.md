# IStorageFileApi

All URIs are relative to *https://api.aspose.cloud/v3.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DownloadFile] (IStorageFileApi.md#DownloadFile) | **GET** /html/storage/file/{path} | Download file
[**UploadFile] (IStorageFileApi.md#UploadFile) | **PUT** /html/storage/file/{path} | Upload file
[**UploadFile] (IStorageFileApi.md#UploadFile_1) | **PUT** /html/storage/file/{path} | Upload file by local path. Overloaded method.
[**DeleteFile] (IStorageFileApi.md#DeleteFile) | **DELETE** /html/storage/file/{path} | Delete file
[**CopyFile] (IStorageFileApi.md#CopyFile) | **PUT** /html/storage/file/copy/{srcPath} | Copy file
[**MoveFile] (IStorageFileApi.md#MoveFile) | **PUT** /html/storage/file/move/{srcPath} | Move file


<a name="DownloadFile"></a>
#**DownloadFile**
> StreamResponse DownloadFile(path, storage, versionId)

Download file from storage.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;

string appKey = "XXXXX";   // put here your app key
string appSID = "XXXXX";   // put here your app SID
string BasePath = "https://api.aspose.cloud";
string authPath = "https://api.aspose.cloud";

string name = "testpage1.html";
string folder = "/Html/TestData";
string storage = null;
string versionId = null;

string outPath = @"d:\Out";
string outFile = Path.Combine(outPath, name);


public static void Main()
{
    try
    {
        var path = Path.Combine(folder, name).Replace('\\', '/');
        IStorageFileApi api = new StorageApi(appSID, appKey, BasePath, authPath);
        var response = api.DownloadFile(path, storage, versionId);
        if(response != null && response.Status == "OK" && response.ContentStream != null)
        {
            // copy response stream to local file
            using(FileStream fstr = new FileStream(outFile, FileMode.Create, FileAccess.Write)
            {
                response.ContentStream.CopyTo(fstr);
                fstr.Flush();
            }
        }
    }
    catch(Exception ex)
    {
        Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
    }
}

```

## Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**path** | **String** | Storage file path to download, e.g. /folder/filename.ext |
**storage** | **String** | Storage name |
**versionId** | File version ID to download | Default is the latest version

 ### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json



<a name="UploadFile"></a>
#**UploadFile**
> AsposeResponse DownloadFile(inStream, path, storage)

Upload file to storage using file stream.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;

string appKey = "XXXXX";   // put here your app key
string appSID = "XXXXX";   // put here your app SID
string BasePath = "https://api.aspose.cloud";
string authPath = "https://api.aspose.cloud";

string name = "testpage_upload.html";
string folder = "/Html/Testout";
string storage = null;

string sourceDir = @"D:\DataDir"; 
string sourcePath = Path.Combine(sourceDir, name);

public static void Main()
{
    try
    {
        var path = Path.Combine(folder, name).Replace('\\', '/');
        IStorageFileApi api = new StorageApi(appSID, appKey, BasePath, authPath);
        using(FileStream fstr = new FileStream(outFile, FileMode.Create, FileAccess.Write)
        {
            var response = api.UploadFile(fstr, path, storage);
            if(response != null && response.Status == "OK")
            {
                Console.WriteLine($"File {name} uploaded to {path}");
            }
        }
    }
    catch(Exception ex)
    {
        Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
    }
}

```

## Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**inStream** | **Stream** | Source stream to upload |
**path** | **String** | Storage path the file will be upload by, e.g. /folder/filename.ext |
**storage** | **String** | Storage name |

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json
 

<a name="UploadFile_1"></a>
#**UploadFile**
> AsposeResponse DownloadFile(localPath, path, storage)

Overloaded method. Upload file to storage using file local path.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;

string appKey = "XXXXX";   // put here your app key
string appSID = "XXXXX";   // put here your app SID
string BasePath = "https://api.aspose.cloud";
string authPath = "https://api.aspose.cloud";

string name = "testpage_upload.html";
string folder = "/Html/Testout";
string storage = null;

string sourceDir = @"D:\DataDir"; 
string sourcePath = Path.Combine(sourceDir, name);

public static void Main()
{
    try
    {
        var path = Path.Combine(folder, name).Replace('\\', '/');
        IStorageFileApi api = new StorageApi(appSID, appKey, BasePath, authPath);
        var response = api.UploadFile(sourcePath, path, storage);
        if(response != null && response.Status == "OK")
        {
            Console.WriteLine($"File {name} uploaded to {path}");
        }        
    }
    catch(Exception ex)
    {
        Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
    }
}

```

## Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**localPath** | **Stream** | Local source file path |
**path** | **String** | Storage path the file will be upload by, e.g. /folder/filename.ext |
**storage** | **String** | Storage name |

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json



<a name="DeleteFile"></a>
#**DeleteFile**
> AsposeResponse DeleteFile(path, storage, versionId)

Delete file from the storage.

### Example
```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;

string appKey = "XXXXX";   // put here your app key
string appSID = "XXXXX";   // put here your app SID
string BasePath = "https://api.aspose.cloud";
string authPath = "https://api.aspose.cloud";

string name = "testpage_delete.html";
string folder = "/Html/TestData";
string storage = null;
string versionId = null;

public static void Main()
{
    try
    {
        var path = Path.Combine(folder, name).Replace('\\', '/');
        IStorageFileApi api = new StorageApi(appSID, appKey, BasePath, authPath);
        var response = api.DeleteFile(path, storage, versionId);
        if(response != null && response.Status == "OK")
        {
            Console.WriteLine($"File {path} deleted.");
        }        
    }
    catch(Exception ex)
    {
        Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
    }
}

```

## Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**path** | **String** | Storage file path to delete, e.g. /folder/filename.ext |
**storage** | **String** | Storage name |
**versionId** | File version ID to delete | Default is the latest version

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json



<a name="CopyFile"></a>
#**CopyFile**
> AsposeResponse CopyFile(srcPath, destPath, srcStorage, destStorage, versionId)
 
Copy storage file.

### Example
```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;

string appKey = "XXXXX";   // put here your app key
string appSID = "XXXXX";   // put here your app SID
string BasePath = "https://api.aspose.cloud";
string authPath = "https://api.aspose.cloud";

string name = "testpage_to_copy.html";
string srcFolder = "/Html/TestData";
string destFolder = "/Html/TestDataNew";
string storage = null;
string versionId = null;

public static void Main()
{
    try
    {
        var srcpath = Path.Combine(srcFolder, name).Replace('\\', '/');
        var destpath = Path.Combine(destFolder, name).Replace('\\', '/');
        IStorageFileApi api = new StorageApi(appSID, appKey, BasePath, authPath);
        var response = api.CopyFile(srcpath, destpath, storage, storage, versionId);
        if(response != null && response.Status == "OK")
        {
            Console.WriteLine($"File {srcpath} copied to {destpath}.");
        }        
    }
    catch(Exception ex)
    {
        Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
    }
}

```

## Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**srcPath** | **String** | Source storage file path, e.g. /folder/filename.ext |
**destPath** | **String** | Destination storage file path, e.g. /folder/filename.ext |
**srcStorage** | **String** | Source storage name |
**destStorage** | **String** | Destination storage name |
**versionId** | File version ID to copy | Default is the latest version

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json



<a name="MoveFile"></a>
#**MoveFile**
> AsposeResponse MoveFile(srcPath, destPath, srcStorage, destStorage, versionId)
 
Move storage file.

### Example
```csharp
using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;

string appKey = "XXXXX";   // put here your app key
string appSID = "XXXXX";   // put here your app SID
string BasePath = "https://api.aspose.cloud";
string authPath = "https://api.aspose.cloud";

string name = "testpage_to_copy.html";
string srcFolder = "/Html/TestData";
string destFolder = "/Html/TestDataNew";
string storage = null;
string versionId = null;

public static void Main()
{
    try
    {
        var srcpath = Path.Combine(srcFolder, name).Replace('\\', '/');
        var destpath = Path.Combine(destFolder, name).Replace('\\', '/');
        IStorageFileApi api = new StorageApi(appSID, appKey, BasePath, authPath);
        var response = api.MoveFile(srcpath, destpath, storage, storage, versionId);
        if(response != null && response.Status == "OK")
        {
            Console.WriteLine($"File {srcpath} moved to {destpath}.");
        }        
    }
    catch(Exception ex)
    {
        Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
    }
}

```

## Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**srcPath** | **String** | Source storage file path, e.g. /folder/filename.ext |
**destPath** | **String** | Destination storage file path, e.g. /folder/filename.ext |
**srcStorage** | **String** | Source storage name |
**destStorage** | **String** | Destination storage name |
**versionId** | File version ID to move | Default is the latest version

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


