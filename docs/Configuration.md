# Configuration

Configuration class for SDK API facade objects.

## Table of contents

>- [**Summary**](Configuration.md#Summary)
>- [**Namespace**](Configuration.md#Namespace)
>- [**Properties**](Configuration.md#Properties)
>  - [BaseUrl](Configuration.md#BaseUrl)
>  - [AuthUrl](Configuration.md#AuthUrl)
>  - [ClientId](Configuration.md#ClientId)
>  - [ClientSecret](Configuration.md#ClientSecret)
>  - [HttpClient](Configuration.md#HttpClient)
>  - [UseExternalAuthentication](Configuration.md#UseExternalAuthentication)
>- [**Public methods**](Configuration.md#Public_Methods)
>  - [New](Configuration.md#New)
>  - [NewDefault](Configuration.md#NewDefault)
>  - [WithClientId](Configuration.md#WithClientId)
>  - [WithClientSecret](Configuration.md#WithClientSecret)
>  - [WithTimeout](Configuration.md#WithTimeout)
>  - [WithExternalAuthentication](Configuration.md#WithExternalAuthentication)
>- [**Nested classes**](Configuration.md#Nested_class)
>   - [**ConfigurationBuilder**](Configuration.md#ConfigurationBuilder)
>      - [WithBaseUrl](Configuration.md#ConfigurationBuilder_WithBaseUrl)
>      - [WithAuthUrl](Configuration.md#ConfigurationBuilder_WithAuthUrl)
>      - [WithClientId](Configuration.md#ConfigurationBuilder_WithClientId)
>      - [WithClientSecret](Configuration.md#ConfigurationBuilder_WithClientSecret)
>      - [WithTimeout](Configuration.md#ConfigurationBuilder_WithTimeout)
>      - [WithExternalAuthentication](Configuration.md#ConfigurationBuilder_WithExternalAuthentication)
>- [Examples](Configuration.md#Examples)
>



<a name="Summary" />


## Summary

The configuration is a class that initializes API facade objects with needed settings, such as credentials, called REST API URL, timeout etc.
See [**HtmlApi**](HtmdApi.md) constructors with a Configuration parameter.

For additional information about Aspose.HTML Cloud REST API and SDKs, visit the [Aspose documentation site](https://docs.aspose.cloud/html/overview/).

<a name="Namespace" />

### Namespace 

Aspose.Html.Cloud.Sdk

<a name="Properties" />

## Properties

<a name="BaseUrl" />

#### BaseUrl

> ```
> string BaseUrl { get; set; }
> ```

A REST API service URL being called by SDK. Default value is https://api.aspose.cloud/v4/0/html

<a name="AuthUrl" />

#### AuthUrl

> ```
> string AuthUrl { get; set; }
> ```

An authentication service URL. Default value is https://api.aspose.cloud/connect/token

<a name="ClientId" />

#### ClientId 

> ```
> string ClientId { get; set; }
> ```

Client ID credential.

<a name="ClientSecret" />

#### ClientSecret

> ```
> string ClientSecret { get; set; }
> ```

Client secret credential.

<a name="HttpClient" />

#### HttpClient 

> ```
> HttpClient HttpClient { get; set; }
> ```

An HTTP client object with predefined properties (Used mainly for test purposes).

<a name="UseExternalAuthentication" />

#### UseExternalAuthentication 

> ```
> bool UseExternalAuthentication { get; }
> ```

Checks whether SDK uses an authentication token obtained from external provided (if true) or the SDK calls are authenticated internally (if false).



<a name="Public_Methods" />

## Public methods

<a name="New" />

#### New

> ```
> static Configuration New()
> ```

A fabric method. Initializes an empty Configuration instance; then all needed configuration values should be set up by public properties or builder-style methods below.

<a name="NewDefault" />

#### NewDefault

> ```
> static Configuration NewDefault()
> ```

A fabric method. Initializes an empty Configuration instance with default **BaseUrl** and **AuthUrl** values.

<a name="WithClientId" />

#### WithClientId

> ```
> Configuration WithClientId(string ClientId)
> ```

A builder-style method. Sets the user's client ID.

<a name="WithClientSecret" />

#### WithClientSecret

> ```
> Configuration WithClientSecret(string clientSecret)
> ```

A builder-style method. Sets the user's client secret.

<a name="WithTimeout" />

#### WithTimeout

> ```
> Configuration WithTimeout(TimeSpan timeout)
> ```

A builder-style method. Sets the HTTP connection timeout. 

<a name="WithExternalAuthentication" />

#### WithExternalAuthentication

> ```
> Configuration WithExternalAuthentication(string token)
> ```

A builder-style method. Sets a JWT authentication token obtained from external source. It also sets *UseExternalAuthentication*  property to *true*.



<a name="Nested_class" />

## Nested classes

<a name="ConfigurationBuilder" />

## ConfigurationBuilder

A builder class that is used to set up **Configuration** objects.

<a name="ConfigurationBuilder_PublicMethods" />

### Public methods

<a name="ConfigurationBuilder_WithBaseUrl" />

#### WithBaseUrl

> ```
> ConfigurationBuilder WithBaseUrl(string url)
> ```

Sets the API service URL.

<a name="ConfigurationBuilder_WithAuthUrl" />

#### WithAuthUrl

> ```
> ConfigurationBuilder WithAuthUrl(string url)
> ```

Sets the authentication service URL.

<a name="ConfigurationBuilder_WithClientId" />

#### WithClientId

> ```
> ConfigurationBuilder WithClientId(string appSid)
> ```

Sets the user's client ID.

<a name="ConfigurationBuilder_WithClientSecret" />

#### WithClientSecret

> ```
> ConfigurationBuilder WithClientSecret(string clientSecret)
> ```

Sets the user's client secret.

<a name="ConfigurationBuilder_WithTimeout" />

#### WithTimeout

> ```
> ConfigurationBuilder WithTimeout(TimeSpan timeout)
> ```

Sets the HTTP connection timeout.

<a name="ConfigurationBuilder_WithHttpClient" />

#### WithHttpClient

> ```
> ConfigurationBuilder WithHttpClient(HttpClient httpClient)
> ```

Assigns an HTTP client object with predefined properties for the **Configuration** (Used mainly for test purposes).

<a name="ConfigurationBuilder_WithExternalAuthentication" />

#### WithExternalAuthentication

> ```
> ConfigurationBuilder WithExternalAuthentication(string token)
> ```

Sets a JWT authentication token obtained from external source.

<a name="Examples" />

## Examples

Configure an **HtmlApi** object with default **Configuration**.

```
using(var api = new HtmlApi(Configuration.NewDefault()))
{
	// ... your code is here  
}
```



Configure an **HtmlApi** object with a **Configuration **object when parameters are explicitly set in a constructor. 

```c#
var AppSid = "clientid";
var AppKey = ""cXdD45HHTn&&-Bu^787;
var ApiServiceBaseUrl = "https://api.aspose.cloud";  //  /v4.0/html will be appended by default
var AuthServiceUrl = "https://api.aspose.cloud";     //  /connect/token will be appended by default

var config = new Configuration() {
                ClientId = clientId,
				ClientSecret = clientSecret,
				ApiBaseUrl = basePath,
				AuthUrl = authPath
            };			
			
using(var api = new HtmlApi(config))
{
	// ... your code is here     
}


```



Configure an **HtmlApi** object with the **ConfigurationBuilder**. 

```c#
var AppSid = "clientid";
var AppKey = ""cXdD45HHTn&&-Bu^787;
var ApiServiceBaseUrl = "https://api.aspose.cloud";   //  /v4.0/html will be appended by default 
var AuthServiceUrl = "https://api.aspose.cloud";      //  /connect/token will be appended by default

using(var api = new HtmlApi(cb => cb
                .WithClientId(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthUrl(AuthServiceUrl)
                .WithBaseUrl(ApiServiceBaseUrl)))
{
	// ... your code is here    
}
                
```



Configure an **HtmlApi** object with externally obtained authentication token.

```c#

string token;

// get the JWT token from some external source here
// ...............

var conf = Configuration.NewDefault()
			.WithExternalAuthentication(token);
using(var api = new HtmlApi(conf))
{
	// ... your code is here
}

```

