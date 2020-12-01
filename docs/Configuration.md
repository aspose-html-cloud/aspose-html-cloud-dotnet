# Configuration

Configuration class for SDK API facade objects.

[TOC]



## Summary

Class that initializes API facade objects with needed settings, such as credentials, called REST API URL, timeout etc. 
See [**HtmlApi**](HtmdApi.md), constructors with Configuration parameter.

### Namespace 

Aspose.Html.Cloud.Sdk


## Properties

#### BaseUrl

> ```
> string BaseUrl { get; set; }
> ```

REST API service URL being called by SDK.

#### AuthUrl

> ```
> string AuthUrl { get; set; }
> ```

Authentication service URL.

#### AppSid 

> ```
> string AppSid { get; set; }
> ```

Application SID (client ID)

#### AppKey

> ```
> string AppKey { get; set; }
> ```

Application key (client secret)

#### HttpClient 

> ```
> HttpClient HttpClient { get; set; }
> ```

HTTP client object with predefined properties (Used mainly for test purposes).



#### UseExternalAuthentication 

> ```
> bool UseExternalAuthentication { get; }
> ```

Checks whether SDK uses an authentication token obtained from external provided (if true) or the SDK calls are authenticated internally (if false).





## Public methods

#### New

> ```
> static Configuration New()
> ```

Fabric method. Initializes an empty Configuration instance; then all needed configuration values should be set up by public properties or builder-style methods below.

#### NewDefault

> ```
> static Configuration NewDefault()
> ```

Fabric method. Initializes an empty Configuration instance with default **BaseUrl** and **AuthUrl** values.



#### WithAppSid

> ```
> Configuration WithAppSid(string appSid)
> ```

Builder-style method. Sets the user's application SID (client ID).



#### WithAppKey

> ```
> Configuration WithAppKey(string appKey)
> ```

Builder-style method. Sets the user's application key (client secret).



#### WithTimeout

> ```
> Configuration WithTimeout(TimeSpan timeout)
> ```

Builder-style method. Sets the HTTP connection timeout. 



#### WithExternalAuthentication

> ```
> Configuration WithExternalAuthentication(string token)
> ```

Builder-style method. Sets a JWT authentication token obtained from external source. It also sets *UseExternalAuthentication*  property to *true*.



## Nested class

## ConfigurationBuilder

Builder class that is used to set up **Configuration** objects

### Public methods

#### WithBaseUrl

> ```
> ConfigurationBuilder WithBaseUrl(string url)
> ```

Sets the API service URL.

#### WithAuthUrl

> ```
> ConfigurationBuilder WithAuthUrl(string url)
> ```

Sets the authentication service URL.



#### WithAppSid

> ```
> ConfigurationBuilder WithAppSid(string appSid)
> ```

Sets the user's application SID (client ID).



#### WithAppKey

> ```
> ConfigurationBuilder WithAppKey(string appKey)
> ```

Sets the user's application key (client secret).



#### WithTimeout

> ```
> ConfigurationBuilder WithTimeout(TimeSpan timeout)
> ```

Sets the HTTP connection timeout.



#### WithHttpClient

> ```
> ConfigurationBuilder WithHttpClient(HttpClient httpClient)
> ```

Assigns HTTP client object with predefined properties for **Configuration** (Used mainly for test purposes).



#### WithExternalAuthentication

> ```
> ConfigurationBuilder WithExternalAuthentication(string token)
> ```

Sets a JWT authentication token obtained from external source.



## Examples

Configure **HtmlApi** object with default **Configuration**.

```
var api = new HtmlApi(Configuration.NewDefault());
```



Configure **HtmlApi** object with **Configuration **object when parameters are explicitly set in a constructor. 

```csharp
var AppSid = "clientid";
var AppKey = ""cXdD45HHTn&&-Bu^787;
var ApiServiceBaseUrl = "https://api.aspose.cloud";
var AuthServiceUrl = "https://api.aspose.cloud";

var config = new Configuration() {
                AppSid = appSid,
				AppKey = appKey,
				ApiBaseUrl = basePath,
				AuthUrl = authPath
            };			
			
var api = new HtmlApi(config);


```



Configure **HtmlApi** object with **ConfigurationBuilder** 

```
var AppSid = "clientid";
var AppKey = ""cXdD45HHTn&&-Bu^787;
var ApiServiceBaseUrl = "https://api.aspose.cloud";
var AuthServiceUrl = "https://api.aspose.cloud";

var api = new HtmlApi(cb => cb
                .WithAppSid(appSid)
                .WithAppKey(appKey)
                .WithAuthUrl(AuthServiceUrl)
                .WithBaseUrl(ApiServiceBaseUrl));
```



Configure **HtmlApi** object with externally obtained authentication token

 

```

string token;

// get the JWT token from some external source here
// ...............

var conf = Configuration.NewDefault()
			.WithExternalAuthentication(token);
var api = new HtmlApi(conf);

```

