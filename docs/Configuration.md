# Configuration

Configuration class for SDK API facade objects.

[TOC]



## Summary

The configuration is a class that initializes API facade objects with needed settings, such as credentials, called REST API URL, timeout etc.
See [**HtmlApi**](HtmdApi.md) constructors with a Configuration parameter.

### Namespace 

Aspose.Html.Cloud.Sdk


## Properties

#### BaseUrl

> ```
> string BaseUrl { get; set; }
> ```

A REST API service URL being called by SDK.

#### AuthUrl

> ```
> string AuthUrl { get; set; }
> ```

An authentication service URL.

#### AppSid 

> ```
> string AppSid { get; set; }
> ```

An application SID (client ID).

#### AppKey

> ```
> string AppKey { get; set; }
> ```

An application key (client secret).

#### HttpClient 

> ```
> HttpClient HttpClient { get; set; }
> ```

An HTTP client object with predefined properties (Used mainly for test purposes).



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

A fabric method. Initializes an empty Configuration instance; then all needed configuration values should be set up by public properties or builder-style methods below.

#### NewDefault

> ```
> static Configuration NewDefault()
> ```

A fabric method. Initializes an empty Configuration instance with default **BaseUrl** and **AuthUrl** values.



#### WithAppSid

> ```
> Configuration WithAppSid(string appSid)
> ```

A builder-style method. Sets the user's application SID (client ID).



#### WithAppKey

> ```
> Configuration WithAppKey(string appKey)
> ```

A builder-style method. Sets the user's application key (client secret).



#### WithTimeout

> ```
> Configuration WithTimeout(TimeSpan timeout)
> ```

A builder-style method. Sets the HTTP connection timeout. 



#### WithExternalAuthentication

> ```
> Configuration WithExternalAuthentication(string token)
> ```

A builder-style method. Sets a JWT authentication token obtained from external source. It also sets *UseExternalAuthentication*  property to *true*.



## Nested class

## ConfigurationBuilder

A builder class that is used to set up **Configuration** objects.

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

Assigns an HTTP client object with predefined properties for the **Configuration** (Used mainly for test purposes).



#### WithExternalAuthenticationS

> ```
> ConfigurationBuilder WithExternalAuthentication(string token)
> ```

Sets a JWT authentication token obtained from external source.



## Examples

Configure an **HtmlApi** object with default **Configuration**.

```
var api = new HtmlApi(Configuration.NewDefault());
```



Configure an **HtmlApi** object with a **Configuration **object when parameters are explicitly set in a constructor. 

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



Configure an **HtmlApi** object with the **ConfigurationBuilder**. 

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



Configure an **HtmlApi** object with externally obtained authentication token.

 

```

string token;

// get the JWT token from some external source here
// ...............

var conf = Configuration.NewDefault()
			.WithExternalAuthentication(token);
var api = new HtmlApi(conf);

```

