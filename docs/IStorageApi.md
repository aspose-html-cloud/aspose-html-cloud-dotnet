# IStorageApi

All URIs are relative to *https://api.aspose.cloud/v3.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**StorageExists**](IStorageApi.md#StorageExists) | **GET** /html/storage/{storageName}/exist | Check if storage exists
[**FileOrFolderExists**](IStorageApi.md#FileOrFolderExists) | **GET** /html/storage/exist/{path} | Check if file or folder exists
[**GetDiscUsage**](IStorageApi.md#GetDiscUsage) | **GET** /html/storage/disc | Get disc usage
[**GetStorageItemVersions**](IStorageApi.md#GetStorageItemVersions) | **GET** /html/storage/version/{path} | Get list of file versions

<a name="StorageExists"></a>
# **StorageExists**
> bool StorageExists(storage)
 
Check if storage exists

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

string storage = "First Storage";

public static void Main()
{
	try
	{
		IStorageApi stApi = new StorageApi(appSID, appKey, BasePath, authPath);	
		bool exists = stApi.StorageExists(storage);
		Console.WriteLine($"Storage {storage} exists: {exists}.");
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
**storage** | **String** | Storage name |


### Return type

**Boolean**

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json
 

<a name="FileOrFolderExists"></a>
# **FileOrFolderExists**
> bool FileOrFolderExists(path, storage)
 
Check if file or folder exists

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

string storage = null;
string folder = "/Html/TestData"

string fileName = "testpage2.html";

string path = Path.Combine(folder, fileName).Replace('\\', '/');

public static void Main()
{
	try
	{
		IStorageApi stApi = new StorageApi(appSID, appKey, BasePath, authPath);	
		bool exists = stApi.FileOrFolderExists(path, storage);
		Console.WriteLine($"File/folder {path} exists: {exists}.");
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
**path** | **String** | File or folder path, e.g. /folder/filename.ext |
**storage** | **String** | Storage name |


### Return type

**Boolean**

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


<a name="GetDiscUsage"></a>
# **GetDiscUsage**
> DiscUsage GetDiscUsage(path)
 
Get disc usage

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

string storage = "First Storage";

public static void Main()
{
	try
	{
		IStorageApi stApi = new StorageApi(appSID, appKey, BasePath, authPath);	
		var usage = stApi.GetDiscUsage(storage);
		if(usage != null)
		{
			Console.WriteLine($"Storage: {storage}\r\n Used: {usage.UsedSize}, Total: {usage.TotalSize}.");
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
**storage** | **String** | Storage name |


### Return type

[**DiscUsage**](DiscUsage.md)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json
 

<a name="GetStorageItemVersions"></a>
# **GetStorageItemVersions**
> List<StorageItemVersion> GetStorageItemVersions(path, storage)
 
Get list of file versions

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

string storage = null;
string folder = "/Html/TestData"
string fileName = "testpage2.html";

public static void Main()
{
	try
	{
		string path = Path.Combine(folder, fileName).Replace('\\', '/');
		IStorageApi stApi = new StorageApi(appSID, appKey, BasePath, authPath);	
		var list = stApi.GetStorageItemVersions(path, storage);
		if(list != null)
		{
			foreach(var f in list)
			{
				Console.WriteLine($"Name={f.Name}; path={f.Path}; VersionId={f.VersionId}; IsLatest={f.IsLatest}");				
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
**path** | **String** | File path, e.g. /folder/filename.ext |
**storage** | **String** | Storage name |


### Return type

[**List<StorageItemVersion>**](StorageItemVersion.md)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json
