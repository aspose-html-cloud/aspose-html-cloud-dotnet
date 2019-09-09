# JwtToken

Helper class that is used to pass a JWT access token with its generation date/time and expiration time to SDK API facade constructors. 

## Summary

This class is a container of JWT access token, its generation date and expiration time. Its instance should be passed to [**HtmlApi**](HtmlApi.md) or [**StorageApi**](StorageApi.md) constructors when the client uses SDK authorization with an externally provided token.


## Namespace 

Aspose.Html.Cloud.Sdk.Client.Authentication


### Properties

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**Token** | **String** | JWT access token |
**IssuedOn** | **DateTime** | Date when the token has been generated | Use UTC time
**ExpiresIn** | **int** | Time period in seconds 