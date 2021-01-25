# Authorization Details

There are two ways to authorize Aspose.HTML Cloud REST API calls provided by SDK for .NET:

* by user credentials

The client application provides user credentials, i.e. `clientId` and `clientSecret`, and (optionally) an URL of authorization service that provides access tokens (all their parameters can be provided explicitly or implicitly, i.e. from a config file or environment variables). Then SDK authorizes the REST API calls internally: it obtains an access token, uses it for API calls and handles the token expiration itself acquiring it again.   

#### Example

```c#

string baseUrl = "https://api.aspose.cloud";  //  /v4.0/html will be appended by default
string authUrl = "https://api.aspose.cloud";  //  /connect/token will be appended

string clientId = "xxxxxxxxxxxxxxxxx";
string clientSecret = "xxxxxxxxxxxxxxxxx";

HtmlApi api = new HtmlApi(clientId, clientSecret, baseUrl, authUrl);
.....
// business code is here
.....

```


* by externally provided access token

The client application provides a token that is acquired by itself or obtained from elsewhere, SDK only uses it for API calls. In this case, the client application is responsible for the handling of the token expiration. When the token is expired, SDK throws an exception that should be caught by the client application, and it should refresh the token calling the authorization service or getting it from another external provider. 

#### Example

```c#

string baseUrl = "https://api.aspose.cloud";   //  /v4.0/html will be appended by default

string token = "..............."; // here is the access token string

try
{
    using(HtmlApi api = new HtmlApi(cb => cb.WithExternalAuthentication(token)))
    {
        // .....
        // business code is here
        // .....
    }
}
catch(Exception ex)
{
	if(ex is SdkAuthException 
		&& ((SdkAuthException)ex).ErrorReason == SdkAuthException.Reason.TokenExpired )
	{
		// handle here by re-creating HtmlApi instance with a new token
		.... 
	}
}

```



For additional information about Aspose.HTML Cloud REST API and SDKs, visit the [Aspose documentation site](https://docs.aspose.cloud/html/overview/).

