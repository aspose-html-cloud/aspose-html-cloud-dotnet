# ITemplateMergeApi

All URIs are relative to *https://api.aspose.cloud/v3.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetMergeHtmlTemplate**](TemplateMergeApi.md#GetMergeHtmlTemplate) | **GET** /html/{templateName}/merge | Populate HTML document template with data located as a file in the storage.
[**PostMergeHtmlTemplate**](TemplateMergeApi.md#PostMergeHtmlTemplate) | **POST** /html/{templateName}/merge | Populate HTML document template with data from the stream. Result document will be saved to storage.
[**PostMergeHtmlTemplate**](TemplateMergeApi.md#PostMergeHtmlTemplate_1) | **POST** /html/{templateName}/merge | Overloaded method. Populate HTML document template with data from the local file system. Result document will be saved to storage.

<a name="GetMergeHtmlTemplate"></a>
#**GetMergeHtmlTemplate**
> StreamResponse GetMergeHtmlTemplate(templateName, dataPath, options, folder, storage)

Populate HTML document template with data located as a file in the storage.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

string appKey = "XXXXX";   // put here your app key
string appSID = "XXXXX";   // put here your app SID
string BasePath = "https://api.aspose.cloud";

string templateName = "test_template_1.html";                 // template file must be uploaded to storage by path /{folder}/{templateName}
string dataPath = "TestFolder/Merge/templ_merge_data_1.xml";   // data file must be uploaded to storage by path /{dataPath}

string options = "{'cs_names':false}";
string folder = "TestFolder/Merge";  // setup folder where the HTML template is located in the storage 
string storage = null;               // default storage

string outPath = @"d:\Out";
string outFile = Path.Combine(outPath, $"{name}_merged.html");


public static void Main()
{
	try
	{
		ITemplateMergeApi mergeApi = new HtmlApi(appKey, appSID, BasePath);
		var response = mergeApi.GetMergeHtmlTemplate(templateName, dataPath, options, folder, storage);
		
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

## Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **templateName** | **String**| Template document name.  Template document is HTML or zipped HTML. Template location is /{folder}/{templateName}. | 
 **dataPath** | **String**| Data source file path in the storage. Supported data formats: XML, JSON. |
 **options** | **String**| Template merge options: JSON list of name:value pairs. See below for details.| [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]
 
Available options:
 - **cs_names**: if 'true', names of template fields are case-sensitive (default), or case-insensitive, if 'false'.
 - **rm_tabhdr**: if there are no data to fill the TABLE element marked with #foreach, then:
 *if 'true', TABLE element will not be included to result document  (default); 
 *if 'false', the TABLE header with one empty data row will be included. 

 ### Return type

[**StreamResponse**](StreamResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/html, application/zip

 
 
<a name="PostMergeHtmlTemplate"></a>
#**PostMergeHtmlTemplate**
> AsposeResponse PostMergeHtmlTemplate(templateName, inStream, outPath, options, folder, storage)

Populate HTML document template with data from the stream. Result document will be saved to storage.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

string appKey = "XXXXX";   // put here your app key
string appSID = "XXXXX";   // put here your app SID
string BasePath = "https://api.aspose.cloud";

string templateName = "test_template_1.html";                  // template file must be uploaded to storage by path /{folder}/{templateName}
string dataPathLocal = @"d:\testdata\templ_merge_data_1.xml";  // data file is located in local file system

string outPath = "/TestFolder/MergeResults/{templateName}_merged.html"; // storage path the result HTML document will be saved by

string options = "{'rm_tabhdr':true}";
string folder = "TestFolder/Merge";  // setup folder where the HTML template is located in the storage    
string storage = null;               // default storage

string outPathLocal = @"d:\Out";
string outFile = Path.Combine(outPathLocal, $"{name}_merged.html");

public static void Main()
{
	try
	{
		AsposeResponse response = null;
		ITemplateMergeApi mergeApi = new HtmlApi(appKey, appSID, BasePath);
		using(Stream inStream = new FileStream(dataPathLocal, FileMode.Open, FileAccess.Read)
		{
		    var dataFile = Path.GetFileName(dataPathLocal);
			response = mergeApi.PostMergeHtmlTemplate(templateName, inStream, outPath, options, folder, storage);
		}
		
		if(response!= null && response.Status == "OK")
		{
			// result file is in the storage
		}
	}
	catch(Exception ex)
	{
		Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
	}
}

```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **templateName** | **String**| Template document name.  Template document is HTML or zipped HTML. Template location is /{folder}/{templateName}. |
 **inStream** | **Stream**| Data source stream. Supported data formats: XML, JSON  | 
 **outPath** | **String**| Result document path in the storage. |
 **options** | **String**| Template merge options: JSON list of name:value pairs| [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]
 
### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json
 
 
 <a name="PostMergeHtmlTemplate_1"></a>
#**PostMergeHtmlTemplate**
> AsposeResponse PostMergeHtmlTemplate(templateName, localDataFilePath, outPath, options, folder, storage)

Overloaded method. Populate HTML document template with data from the local file system. Result document will be saved to storage.

### Example
```csharp

using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

string appKey = "XXXXX";   // put here your app key
string appSID = "XXXXX";   // put here your app SID
string BasePath = "https://api.aspose.cloud";

string templateName = "test_template_1.html";                  // template file must be uploaded to storage by path /{folder}/{templateName}
string dataPathLocal = @"d:\testdata\templ_merge_data_1.xml";  // data file is located in local file system

string outPath = "/TestFolder/MergeResults/{templateName}_merged.html"; // storage path the result HTML document will be saved by

string options = "{'rm_tabhdr':true}";
string folder = "TestFolder/Merge";  // setup folder where the HTML template is located in the storage    
string storage = null;               // default storage

string outPathLocal = @"d:\Out";
string outFile = Path.Combine(outPathLocal, $"{name}_merged.html");

public static void Main()
{
	try
	{
		AsposeResponse response = null;
		ITemplateMergeApi mergeApi = new HtmlApi(appKey, appSID, BasePath);
		response = mergeApi.PostMergeHtmlTemplate(templateName, dataPathLocal, outPath, options, folder, storage);
		
		if(response!= null && response.Status == "OK")
		{
			// result file is in the storage
		}
	}
	catch(Exception ex)
	{
		Console.Out.WriteLine(string.Format("Error: {0}", ex.Message));
	}
}

```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **templateName** | **String**| Template document name.  Template document is HTML or zipped HTML. Template location is /{folder}/{templateName}. |
 **localDataFilePath** | **String**| Data source file path in the local file system. Supported data formats: XML, JSON. | 
 **outPath** | **String**| Result document path in the storage. |
 **options** | **String**| Template merge options: JSON list of name:value pairs| [optional]
 **folder** | **String**| The document folder. | [optional]
 **storage** | **String**| The document storage. | [optional]
 
### Return type

[**AsposeResponse**](AsposeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json
 