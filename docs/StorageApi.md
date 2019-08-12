# StorageApi

Facade class providing wrapper methods of Aspose.Storage Cloud REST API

## Summary

Class that is a common SDK facade of all storage access functionality. 
SDK methods can be called directly from the HtmlApi class instance or using interfaces.

## Namespace 

Aspose.Html.Cloud.Sdk.Api

## Base class

**ApiBase**


## Interfaces

Class implements following interfaces:

[**IStorageFileApi**](IStorageFileApi.md)
[**IStorageFolderApi**](IStorageFolderApi.md)
[**IStorageApi**](IStorageApi.md)

## Constructors

> StorageApi (appSid, appKey, basePath, authPath, timeout)

Initializes class instance with user credentials, REST API service URL, authorization service URL and connection timeout

> StorageApi (appSid, appKey, basePath, authPath)

Initializes class instance with user credentials, REST API service URL, authorization service URL (default connection timeout is 5 min)

> StorageApi (appSid, appKey, basePath, timeout)

Initializes class instance with user credentials, REST API service URL and connection timeout (authorization service URL is the same as basePath)

> StorageApi (appSid, appKey, basePath)

Initializes class instance with user credentials and REST API service URL

> StorageApi (config)

Initializes class instance with Configuration object that should be previously created and initialized with with user credentials, REST API service URL, authorization service URL and connection timeout values.

#### Example

```csharp

var config = new Configuration() {
                AppSid = appSid,
				AppKey = appKey,
				ApiBaseUrl = basePath,
				AuthUrl = authPath,
				ApiVersion = "3.0"
            };
var api = new StorageApi(config);

```

> StorageApi (instance)

Initializes class instance with existing ApiBase-inherited class instance (explicit type cast may be needed). It can be usable to share authorization status between two or more API facade classes.

#### Example

```csharp

var stApi = new HtmlApi(appSid, appKey, basePath, authPath);
var htmlApi = new StorageApi(stApi);

```
