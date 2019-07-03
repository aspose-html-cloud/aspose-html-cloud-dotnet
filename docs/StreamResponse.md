#StreamResponse

SDK stream response class. 

### Summary

Response class that incapsulates the SDK result data as a stream.
SDK methods should use this class as a return type if it's necessary to return the output data stream.
   

### Base class

AsposeResponse 

### Namespace 

Aspose.Html.Cloud.Sdk.Api.Model

### Properties

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**FileName** | **String**| The file name to save the content stream. |
**ContentStream** | **Stream**| The response content stream. |
**ContentStreamAsString** | **String**| The response content representation as a string. |