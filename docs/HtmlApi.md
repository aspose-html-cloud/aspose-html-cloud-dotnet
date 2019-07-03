# HtmlApi

Facade class providing wrapper methods of Aspose.HTML Cloud REST API

## Summary

Class that is a common SDK facade of all HTML functionality. 
SDK methods can be called directly from the HtmlApi class instance or using interfaces.

## Namespace 

Aspose.Html.Cloud.Sdk.Api

## Base class

**ApiBase**

## Interfaces

Class implements following interfaces:

[**IDocumentApi**](DocumentApi.md)
[**IConvrsionApi**](ConversionApi.md)
[**ITranslationApi**](TranslationApi.md)
[**ITemplateMergeApi**](TemplateMergeApi.md)
[**IOcrApi**] (OcrApi.md)
[**ISummarizationApi**](SummarizationApi.md)

## Constructors

> HtmlApi (appSid, appKey, basePath, authPath, timeout)

Initializes class instance with user credentials, REST API service URL, authorization service URL and connection timeout

> HtmlApi (appSid, appKey, basePath, authPath)

Initializes class instance with user credentials, REST API service URL, authorization service URL (default connection timeout is 5 min)

> HtmlApi (appSid, appKey, basePath, timeout)

Initializes class instance with user credentials, REST API service URL and connection timeout (authorization service URL is the same as basePath)

> HtmlApi (appSid, appKey, basePath)

Initializes class instance with user credentials and REST API service URL

> HtmlApi (config)

Initializes class instance with Configuration object that should be previously created and initialized with with user credentials, REST API service URL, authorization service URL and connection timeout values.

####Example

```csharp

var config = new Configuration() {
                AppSid = appSid,
				AppKey = appKey,
				ApiBaseUrl = basePath,
				AuthUrl = authPath,
				ApiVersion = "3.0"
            };
var api = new HtmlApi(config);

```

> HtmlApi (instance)

Initializes class instance with existing ApiBase-inherited class instance (explicit type cast may be needed). It can be usable to share authorization status between two or more API facade classes.

####Example

```csharp

var stApi = new StorageApi(appSid, appKey, basePath, authPath);
var htmlApi = new HtmlApi(stApi);

```


