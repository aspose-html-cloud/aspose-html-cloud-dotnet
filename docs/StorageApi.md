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

> StorageApi ()

Default constructor. Allows to get settings (user credentials, REST API service URL, authorization service URL) implicitly from configuration file of application that uses SDK, or from the environment variables, or predefined defaults.

If the StorageApi instance is initialized with the constructor without parameters, the user credentials, REST API service URL and authorization service URL are evaluated in the following order:
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

> HtmlApi(*int* timeout)

Initializes class instance as the default constructor does (see above) and sets the service connection timeout as a TimeSpan structure instance (default connection timeout is 5 min)

> StorageApi (*string* appSid, *string* appKey, *string* basePath, *string* authPath, *int* timeout)

Initializes class instance with user credentials, REST API service URL, authorization service URL and connection timeout

> StorageApi (*string* appSid, *string* appKey, *string* basePath, *string* authPath)

Initializes class instance with user credentials, REST API service URL, authorization service URL

> StorageApi (*string* appSid, *string* appKey, *string* basePath, *int* timeout)

Initializes class instance with user credentials, REST API service URL and connection timeout (authorization service URL is the same as basePath)

> StorageApi (*string* appSid, *string* appKey, *string* basePath)

Initializes class instance with user credentials and REST API service URL

> StorageApi (*Configuration* config)

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

> StorageApi (*ApiBase* instance)

Initializes class instance with existing ApiBase-inherited class instance (explicit type cast may be needed). It can be usable to share authorization status between two or more API facade classes.

#### Example

```csharp

var stApi = new HtmlApi(appSid, appKey, basePath, authPath);
var htmlApi = new StorageApi(stApi);

```

###### Next constructor provides ability for the SDK client to use authorization with externally provided token.

> StorageApi(*JwtToken* token, *string* basePath = null)

Initializes class instance with an object that contains a JWT access token obtained by the client application with its generation date and expiration time in seconds (see [*JwtToken*](docs/JwtToken.md) class description for details) and the REST API service URL (optional, default is https://api.aspose.cloud ). 

#### Example

```csharp

var tokenObj = new JwtToken() { 
      Token = "xxxxxxxxxxxxxxxxxxxxxxxx",
	  IssuedOn = DateTime.UtcNow,
	  ExpiresIn = 86400 };
	  
var stApi = new StorageApi(tokenObj, basePath);

```
