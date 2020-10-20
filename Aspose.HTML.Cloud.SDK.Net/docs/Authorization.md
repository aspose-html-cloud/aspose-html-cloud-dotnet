# Authorization Details

There are two ways to authorize Aspose.HTML Cloud REST API calls provided by SDK for .NET:

* by user credentials

The client application provides user credentials, i.e. appSid and appKey, and (optionally) an URL of authorization service that provides access tokens (all there parameters can be provided explicitly or implicitly, i.e. from config file or environment variables). Then SDK authorizes the REST API calls internally: it obtains an access token, uses it for API calls and handles the token expiration itself acquiring it again.  

#### Example

```csharp

string baseUrl = "https://api.aspose.cloud";
string authUrl = "https://api.aspose.cloud";

string appSid = "xxxxxxxxxxxxxxxxx";
string appKey = "xxxxxxxxxxxxxxxxx";

HtmlApi api = new HtmlApi(appSid, appKey, baseUrl, authUrl);
.....
// business code is here
.....

```


* by externally provided access token

The client application provides a token that it acquired itself or obtained from elsewhere, SDK only uses it for API calls. In this case, the client application is responsible for the handling of the token expiration. When the token is expired, SDK throws an exception that should be catched by client application, and it should refresh the token calling the authorization service or getting it from other external provider. 

#### Example

```csharp

string baseUrl = "https://api.aspose.cloud";

JwtToken tokenObj = new JwtToken() {
	Token = token,         // access token string
	IssuedOn = issued_on,  // token generation date
	ExpiresIn = expires_in // token expiration period in seconds
};

try
{
	HtmlApi api = new HtmlApi(tokenObj, baseUrl);
	.....
	// business code is here
	.....
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

Since v19.9.1, there is an option to use access token itself, without issued_on and expires_in parameters because they can be obtained from the token.

#### Example

```csharp

string baseUrl = "https://api.aspose.cloud";

string token = "..............."; // here is the access token string

try
{
	HtmlApi api = new HtmlApi(token, baseUrl);
	.....
	// business code is here
	.....
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
