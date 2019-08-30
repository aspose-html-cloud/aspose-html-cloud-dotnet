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
[**IConversionApi**](ConversionApi.md)
[**IImportApi**](ImportApi.md)
[**ITranslationApi**](TranslationApi.md)
[**ITemplateMergeApi**](TemplateMergeApi.md)
[**IOcrApi**](OcrApi.md)
[**ISummarizationApi**](SummarizationApi.md)

## Constructors

> HtmlApi ()

Default constructor. Initializes class instance allowing to get settings (user credentials, REST API service URL, authorization service URL) implicitly from configuration file of application that uses SDK, or from the environment variables, or predefined defaults.

If the HtmlApi instance is initialized with the constructor without parameters, the user credentials, REST API service URL and authorization service URL are evaluated in the following order:
* Trying to get settings from app.config file. A part of the config file may appear as follows:
```
    <appSettings>
      <add key="appSID" value="userid" />
      <add key="appKey" value="XXXXXX123445567890" />
      <add key="baseUrl" value="https://api-qa.aspose.cloud" />
      <add key="authUrl" value="https://api-qa.aspose.cloud" />
    </appSettings>
```
* If some or all settings are absent in the config file, trying to get them from environment variables the application was started with. For example:
```
C:\Users\Me> myapp.exe -e "appSID=userid" -e "appKey=XXXXXX1234567890" -e "baseUrl=https://api.aspose.cloud" -e "authUrl=https://api.aspose.cloud" 
```
(NOTE: alternative names of 'appSID' and 'appKey' environment variables are 'client_id' and 'client_secret' respectively)
* If 'baseUrl' or 'authUrl' are not found, they will be set to https://api.aspose.cloud by default.
* 'appSID' and 'appKey' are required; if at least one of them isn't found, an exception will be thrown.

> HtmlApi(timeout)

Initializes class instance as the default constructor does (see above) and sets the service connection timeout as a TimeSpan structure instance (default connection timeout is 5 min)

> HtmlApi (appSid, appKey, basePath, authPath, timeout)

Initializes class instance with user credentials, REST API service URL, authorization service URL and connection timeout

> HtmlApi (appSid, appKey, basePath, authPath)

Initializes class instance with user credentials, REST API service URL, authorization service URL 

> HtmlApi (appSid, appKey, basePath, timeout)

Initializes class instance with user credentials, REST API service URL and connection timeout (authorization service URL is the same as basePath)

> HtmlApi (appSid, appKey, basePath)

Initializes class instance with user credentials and REST API service URL

> HtmlApi (config)

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
var api = new HtmlApi(config);

```

> HtmlApi (instance)

Initializes class instance with existing ApiBase-inherited class instance (explicit type cast to ApiBase may be needed). It can be useful to share authorization status between two or more API facade classes.

#### Example

```csharp

var stApi = new StorageApi(appSid, appKey, basePath, authPath);
var htmlApi = new HtmlApi(stApi);

```

