# HtmlApi

A facade class that provides wrapper methods of Aspose.HTML Cloud REST API.

## Table of contents

> - [**Summary**](HtmlApi.md#Summary)
> - [**Namespace**](HtmlApi.md#Namespace)
> - [**Constructors**](HtmlApi.md#Constructors)
>   - [Examples of constructor usage](HtmlApi.md#Constructors_Examples)
> - [**Properties**](HtmlApi.md#Properties)
>   - [Storage](HtmlApi.md#Properties_Storage)
> - [**Public methods**](HtmlApi.md#Public_Methods)
>   - [ConvertAsync](HtmlApi.md#ConvertAsync)
>   - [ConvertAsync (overloaded)](HtmlApi.md#ConvertAsync_1)
>   - [GetConversion](HtmlApi.md#GetConversion)
>   - [DeleteTask](HtmlApi.md#DeleteTask)
>   - [Convert](HtmlApi.md#Convert)
>   - [Convert (overloaded)](HtmlApi.md#Convert_1)
>   - [Convert (overloaded, builder-style)](HtmlApi.md#Convert_builder)
>   - [ConvertWebSiteAsync](HtmlApi.md#ConvertWebSiteAsync)
>   - [ConvertWebSite](HtmlApi.md#ConvertWebSite)
>   - [ConvertWebSite (overloaded)](HtmlApi.md#ConvertWebSite_1)
>   - [ConvertLocalFileAsync](HtmlApi.md#ConvertLocalFileAsync)
>   - [ConvertLocalFileAsync (overloaded)](HtmlApi.md#ConvertLocalFileAsync_1)
>   - [ConvertLocalFile](HtmlApi.md#ConvertLocalFile)
>   - [ConvertLocalFile (overloaded)](HtmlApi.md#ConvertLocalFile_1)
>   - [ConvertLocalDirectory](HtmlApi.md#ConvertLocalDirectory)
>



<a name="Summary" />

## Summary

An HtmlApi class is a common SDK facade of all HTML functionality. 

In the current version, it provides:

- a group of constructors that provide various ways of API setup concerning user credentials, API services (if they are different from default) and some other parameters, such as HTTP connection timeout.
- a group of synchronous and asynchronous conversion methods that work with various data sources, such as local files, files in the cloud storage, web pages. The supported source file types are: HTML (including HTML pages with local resources in ZIP archive), MHTML, ePub, Markdown. The supported output formats the source files can be converted to are: PDF, XPS, JPEG, BMP, PNG, GIF, TIFF. 
- an entry point of the cloud storage access API.

For additional information about Aspose.HTML Cloud REST API and SDKs, visit the [Aspose documentation site](https://docs.aspose.cloud/html/overview/).



<a name="Namespace" />

## Namespace 

Aspose.HTML.Cloud.Sdk

<br>

<a name="Constructors" />

## Constructors

> **HtmlApi  (Configuration configuration)**

 Initializes a class instance with API parameters provided by specified Configuration object.



> **HtmlApi  (Action<Configuration.ConfigurationBuilder> builder)**

Initializes a class instance with API parameters using a configuration builder.



> **HtmlApi (String appSid, String appKey)**

Initializes a class instance with user credentials and default API server URL.



> **HtmlApi (String appSid, String appKey, String baseUrl)**

Initializes a class instance with user credentials and explicit API server URL.



> **HtmlApi (String appSid, String appKey, String baseUrl, TimeSpan timeout)**

Initializes a class instance with user credentials, explicit API server URL and HTTP(S) connection timeout.


<a name="Constructors_Examples" />
#### Examples of constructor usage

Here are examples of various **HtmlApi** initialization ways. 

An example of initialization by the **Configuration** object:

```
var conf = Configuration.NewDefault(); 
conf.Timeout = TimeSpan.FromMinutes(5);

using(var api =  new HtmlApi(conf))
{
	// business code ....
}

```


An example of initialization by user credentials with explicit authentication service and HTML API service URLs using the configuration builder: 

```c#
var clientId = "clientid";
var clientSecret = ""cXdD45HHTn&&-Bu^787;
var ApiServiceBaseUrl = "https://api.aspose.cloud";
var AuthServiceUrl = "https://api.aspose.cloud";

using( var api =  new HtmlApi(cb => cb
                .WithClientId(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthUrl(AuthServiceUrl)
                .WithBaseUrl(ApiServiceBaseUrl)))
{
    // business code ...
}
```



An example of initialization by user credentials using the configuration builder: 

``` c#
var AppSid = "clientid";
var AppKey = ""cXdD45HHTn&&-Bu^787;

    // URLs of authentication and HTML API services aren't specified explicitly
    // default values are assumed ( 
    // https://api.aspose.cloud/connect/token and https://api.aspose.cloud/v4.0/html respectively )
using(var api = new HtmlApi(cb => cb
                .WithClientId(clientId)
                .WithClientSecret(clientSecret)))
{
    // business code ...
}

      
                
```



An example of initialization by externally obtained authentication token using the configuration builder: 

```code

string token;

// get the JWT token from some external source here
// ...............

var api = new HtmlApi(cb => cb
            .WithBaseUrl(ApiBaseUrl)
            .WithExternalAuthentication(token));


```

<br/>

<a name="Properties" />

## Properties

<a name="Properties_Storage" />

### **Storage**

> ```
> StorageProvider  Storage { get; }
> ```

An entry point to storage access API.

See [**StorageProvider**](StorageProvider.md) for detailed specification of Storage API v4.0

<br>



<a name="Public_Methods" />

## Public Methods

#### *Common parameters*

The list of parameters that are used by most of methods:

| Name                | Description                                                  | Type                                                         | Note     |
| ------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | -------- |
| source              | A source file (or files).                                    | [**ConversionSource**](ConversionSource.md)                  |          |
| options             | Specifies the conversion options, i.e. the resulting file format and other result parameters, such as page size and margins, image resolution etc. | [**ConversionOptions**](ConversionOptions.md)                |          |
| outputFilePath      | A storage path where the result file will be saved; by default, it is a system temporary storage path. | string                                                       | optional |
| nameCollisionOption | How to handle a resulting file name collision. There are 3 options: *FailIfExists* (default), *GenerateUniqueName*, *ReplaceExisting.* | enum **NameCollisionOption**                                 | optional |
| observer            | Object that will get notifications on the conversion process state changes. It must implement the interface *IObserver<Conversion.Conversion>* | [IObserver](https://docs.microsoft.com/en-us/dotnet/api/system.iobserver-1?view=net-5.0)<[Conversion.Conversion]()> | optional |

**Note concerning `observer` parameter:**

Default implementation of [IObserver](https://docs.microsoft.com/en-us/dotnet/api/system.iobserver-1?view=net-5.0)<[Conversion.Conversion]()> interface is an internal class ConversionObserver. This implementation does nothing.

You are free to create your own implementation of [IObserver](https://docs.microsoft.com/en-us/dotnet/api/system.iobserver-1?view=net-5.0)<[Conversion.Conversion]()> interface and use its instance as `observer` parameter calling asynchronous conversion methods to receive notification on the process errors or work completion.



<a name="ConvertAsync" />

### ConvertAsync

> ```
> AsyncResult<Conversion.Conversion> ConvertAsync(
>             ConversionSource source,
>             ConversionOptions options,
>             string outputFilePath = null,
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Starts asynchronously a long-time conversion operation of a source file (or files) specified by *source* parameter and returns an **AsyncResult** object that allows watching for the current asynchronous operation status. 


<a name="ConvertAsync_1" />
### ConvertAsync

> ```
> AsyncResult<Conversion.Conversion> ConvertAsync(
>             List<RemoteFile> files,
>             ConversionOptions options,
>             string outputFilePath = null,
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Overloaded method.  Starts asynchronously a long-time conversion operation of a list of storage files.


<a name="GetConversion" />
### GetConversion

> ```
> AsyncResult<Conversion.Conversion> GetConversion(string id)
> ```

Gets a current status of long-time conversion operation started previously by the *ConvertAsync* method.


<a name="DeleteTask" />
### DeleteTask

> ```
> bool DeleteTask(string id)
> ```

Cancels a long-time conversion operation started previously by the *ConvertAsync* method.

<a name="Convert" />

### Convert

> ```
> Conversion.Conversion Convert(
>          ConversionSource source,
>          ConversionOptions options,
>          string outputFilePath = null,
>          NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>          IObserver<Conversion.Conversion> observer = null)
> ```

Converts synchronously a file (or files) specified by  *source* parameter. This method is a synchronous mode of the *ConvertAsync*. Returns the Conversion.Conversion object with a list of conversion results.

<a name="Convert_1" />

### Convert

> ```
> Conversion.Conversion Convert(
>             List<RemoteFile> files, 
>             ConversionOptions options, string outputFilePath = null,
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Overloaded method. Converts synchronously a list of storage files. This method is a synchronous mode of the *ConvertAsync* (overloaded).

<a name="Convert_builder" />

### Convert

> ```
> Conversion.Conversion Convert(ConversionBuilder builder)
> ```

Overloaded method. Uses the builder style  setup of the conversion parameters using [ConversionBuilder](ConversionBuilder.md) class. 



The specialized versions of the conversion methods are described below.

<a name="ConvertWebSiteAsync" />

### ConvertWebSiteAsync

> ```
> AsyncResult<Conversion.Conversion> ConvertWebSiteAsync(
>             string address, 
>             ConversionOptions options,
>             string outputFilePath = null, 
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Starts asynchronously a long-time conversion operation of a web page specified by its URL (*address* parameter). This method is an analog of the *ConvertAsync* specialized for web pages.


<a name="ConvertWebSite" />
### ConvertWebSite

> ```
> Conversion.Conversion ConvertWebSite(
>             string address,
>             ConversionOptions options,
>             string outputFilePath = null,
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Synchronous mode of the *ConvertWebSiteAsync* method. Converts a web page specified by its URL.


<a name="ConvertWebSite_1" />
### ConvertWebSite

> ```
> Conversion.Conversion ConvertWebSite(
>             List<string> address, 
>             ConversionOptions options,
>             string outputFilePath = null, 
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Overloaded method. Synchronous mode of the *ConvertWebSiteAsync* method. Converts several web pages specified the list of their URLs.

<a name="ConvertLocalFileAsync" />

### ConvertLocalFileAsync

> ```
> AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
>             string filePath,
>             ConversionOptions options,
>             string outputFilePath = null,
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Starts asynchronously a long-time conversion operation of a file specified by its local file system path.


<a name="ConvertLocalFileAsync_1" />
### ConvertLocalFileAsync

> ```
> AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
>             List<string> filePaths, 
>             ConversionOptions options,
>             string outputFilePath = null, 
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Overloaded method.  Starts asynchronously a long-time conversion operation of several files specified by a list of their local file system paths.

<a name="ConvertLocalFile" />

### ConvertLocalFile

> ```
> Conversion.Conversion ConvertLocalFile(
>             string filePath,
>             ConversionOptions options,
>             string outputFilePath = null,
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Synchronous mode of the *ConvertLocalFileAsync* method. Converts a file specified by its local file system path.


<a name="ConvertLocalFile_1" />
### ConvertLocalFile

> ```
> Conversion.Conversion ConvertLocalFile(
>             List<string> filePath, 
>             ConversionOptions options,
>             string outputFilePath = null, 
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Overloaded method. Synchronous mode of the *ConvertLocalFileAsync* method. Converts several files specified by a list of their local file system paths.

<a name="ConvertLocalDirectory" />

### ConvertLocalDirectory

> ```
> Conversion.Conversion ConvertLocalDirectory(
>             List<string> paths,
>             ConversionOptions options,
>             string outputFilePath = null,
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Converts synchronously files in a list of local directories.