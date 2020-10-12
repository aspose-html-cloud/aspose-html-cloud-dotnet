# Configuration

Configuration class for SDK API facade objects.

## Summary

Class that initializes API facade objects with needed settings, such as credentials, called REST API URL, timeout etc. 
See [**HtmlApi**](HtmdApi.md) and [**StorageApi**](StorageApi.md), constructors with Configuration parameter.

### Namespace 

Aspose.Html.Cloud.Sdk.Client


## Properties

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**AppSid** | **String** |  Application SID (client ID)      | 
**AppKey** | **String** |  Application key (client secret)  | 
**ApiBaseUrl** | **String**  |   REST API service URL to call by SDK. | 
**AuthUrl** | **String** |   Authentication service URL. | 
**ApiVersion** | **String** |  REST API version. | 
**DefaultHeaders**   | **Dictionary<string, string>** |  List of default HTTP request headers that are currently set. | GET only


## Public methods

<a name="AddDefaultHeader"></a>
# **AddDefaultHeader**
> void AddDefaultHeader(key, value)

Sets default HTTP request headers that will be applied on each API call by HtmlApi or StorageApi objects created with this Configuration.



#### Example

```csharp

var config = new Configuration() {
                AppSid = appSid,
				AppKey = appKey,
				ApiBaseUrl = basePath,
				AuthUrl = authPath,
				ApiVersion = "3.0"
            };
			
config.AddDefaultHeader("x_my_header", myHeaderVal);		
			
var api = new HtmlApi(config);


```

