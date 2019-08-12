# IStorageFolderApi

All URIs are relative to *https://api.aspose.cloud/v3.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetFolderContentList**](IStorageFolderApi.md#GetFolderContentList) | **GET** /html/storage/folder/{path} | Get all files and subfolders within a folder
[**CreateFolder**](IStorageFolderApi.md#CreateFolder) | **PUT** /html/storage/folder/{path} | Create the folder
[**DeleteFolder**](IStorageFolderApi.md#DeleteFolder) | **DELETE** /html/storage/folder/{path} | Delete folder
[**CopyFolder**](IStorageFolderApi.md#CopyFolder) | **PUT** /html/storage/folder/copy/{srcPath} |  Copy folder
[**MoveFolder**](IStorageFolderApi.md#MoveFolder) | **PUT** /html/storage/folder/move/{srcPath} | Move folder


<a name="GetFolderContentList"></a>
# **GetFolderContentList**
> List<StorageItem> GetFolderContentList(path, storage);

Get all files and subfolders within a storage folder

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

string folder = "/Html/TestData"
string storage = null;

public static void Main()
{
	try
	{
		IStorageFolderApi fApi = new StorageApi(appSID, appKey, BasePath, authPath);
		var list = stApi.GetFolderContentList(path, storage);
		if(list != null)
		{
			foreach(var f in list)
			{
				Console.WriteLine($"Name={f.Name}; path={f.Path}; IsFolder={f.IsFolder}; Size={f.Size}");				
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
**path** | **String** | Storage folder path, e.g. /folder1/folder2 |
**storage** | **String** | Storage name |

### Return type

[**List**<StorageItem>**](StorageItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json



<a name="CreateFolder"></a>
# **CreateFolder**
> AsposeResponse CreateFolder(path, storage)

Create folder in the storage 

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

string folder = "/Html/TestDataNew"
string storage = null;

public static void Main()
{
	try
	{
		IStorageFolderApi fApi = new StorageApi(appSID, appKey, BasePath, authPath);	
		var response = fApi.CreateFolder(folder, storage);
		if(response != null && response.Status == "OK")
		{
			Console.WriteLine($"Folder {folder} created.");
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
**path** | **String** | Storage folder path to delete, e.g. /folder1/folder2 |
**storage** | **String** | Storage name |

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json




<a name="DeleteFolder"></a>
# **DeleteFolder**
> AsposeResponse DeleteFolder(path, storage)

Delete folder from the storage

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

string folder = "/Html/TestData"
string storage = null;

public static void Main()
{
	try
	{
		IStorageFolderApi fApi = new StorageApi(appSID, appKey, BasePath, authPath);	
		var response = fApi.DeleteFolder(folder, storage);
		if(response != null && response.Status == "OK")
		{
			Console.WriteLine($"Folder {folder} deleted.");
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
**path** | **String** | Storage folder path to delete, e.g. /folder1/folder2 |
**storage** | **String** | Storage name |

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


<a name="CopyFolder"></a>
# **CopyFolder**
> AsposeResponse CopyFolder(srcPath, destPath, srcStorage, destStorage)

Copy storage folder

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

string srcFolder = "/Html/TestData"
string destFolder = "/Html/TestDataCopy"
string storage = null;

public static void Main()
{
	try
	{
		IStorageFolderApi fApi = new StorageApi(appSID, appKey, BasePath, authPath);	
		var response = fApi.CopyFolder(srcFolder, destFolder, storage, storage);
		if(response != null && response.Status == "OK")
		{
			Console.WriteLine($"Folder {srcFolder} copied to {destFolder}.");
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
**srcPath** | **String** | Source storage folder path, e.g. /folder1/folder2 |
**destPath** | **String** | Destination storage folder path, e.g. /folder1/folder2 |
**srcStorage** | **String** | Source storage name |
**destStorage** | **String** | Destination storage name |

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json



<a name="MoveFolder"></a>
# **MoveFolder**
> AsposeResponse MoveFolder(srcPath, destPath, srcStorage, destStorage)

Move storage folder

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

string srcFolder = "/Html/TestData"
string destFolder = "/Html/TestDataCopy"
string storage = null;

public static void Main()
{
	try
	{
		IStorageFolderApi fApi = new StorageApi(appSID, appKey, BasePath, authPath);	
		var response = fApi.MoveFolder(srcFolder, destFolder, storage, storage);
		if(response != null && response.Status == "OK")
		{
			Console.WriteLine($"Folder {srcFolder} moved to {destFolder}.");
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
**srcPath** | **String** | Source storage folder path, e.g. /folder1/folder2 |
**destPath** | **String** | Destination storage folder path, e.g. /folder1/folder2 |
**srcStorage** | **String** | Source storage name |
**destStorage** | **String** | Destination storage name |

### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


