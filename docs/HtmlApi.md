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
>   - [Convert](HtmlApi.md#Convert)
>   - [GetConversion](HtmlApi.md#GetConversion)
>   - [DeleteTask](HtmlApi.md#DeleteTask)
>   - [Convert ](HtmlApi.md#Convert_builder)
>   - [ConvertUrlAsync](HtmlApi.md#ConvertUrlAsync)
>   - [ConvertUrlAsync (overloaded)](HtmlApi.md#ConvertUrlAsync_1)
>   - [ConvertUrl](HtmlApi.md#ConvertUrl)
>   - [ConvertUrl (overloaded)](HtmlApi.md#ConvertUrl_1)
>   - [ConvertLocalFileAsync](HtmlApi.md#ConvertLocalFileAsync)
>   - [ConvertLocalFileAsync (overloaded)](HtmlApi.md#ConvertLocalFileAsync_1)
>   - [ConvertLocalFile](HtmlApi.md#ConvertLocalFile)
>   - [ConvertLocalFile (overloaded)](HtmlApi.md#ConvertLocalFile_1)
>   - [ConvertLocalDirectory](HtmlApi.md#ConvertLocalDirectory)
>   - [ConvertLocalDirectory (overloaded)](HtmlApi.md#ConvertLocalDirectory_1)
>   - [ConvertLocalArchive](HtmlApi.md#ConvertLocalArchive)
>   - [ConvertLocalArchive (overloaded)](HtmlApi.md#ConvertLocalArchive_1)
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



> **HtmlApi (String clientId, String clientSecret)**

Initializes a class instance with user credentials and default API server URL.

<a name="Constructors_Examples" />

#### Examples of constructor usage

Here are examples of various **HtmlApi** initialization ways. 

An example of initialization by the **Configuration** object:

```c#
var conf = Configuration.New(); 
conf.Timeout = TimeSpan.FromMinutes(5);

using(var api =  new HtmlApi(conf))
{
	// business code ....
}

```



An example of initialization by user credentials using the configuration builder: 

``` c#
var clientId = "clientid";
var clientSecret = ""cXdD45HHTn&&-Bu^787;

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

```c#

string token;

// get the JWT token from some external source here
// ...............

using(var api = new HtmlApi(cb => cb
            .WithExternalAuthentication(token)))
{
    // business code ...    
}
            


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
| startPoint          | When the conversion source is a directory or an archive that contain an HTML file with resources (see [ConvertLocalDirectory](HtmlApi.md#ConvertLocalDirectory) or [ConvertLocalArchive](HtmlApi.md#ConvertLocalArchive)), this parameter specifies a main document file (usually HTML) | string                                                       |          |
| options             | Specifies the conversion options, i.e. the resulting file format and other result parameters, such as page size and margins, image resolution etc. | [**ConversionOptions**](ConversionOptions.md)                |          |
| outputPath          | A storage path where the result file will be saved; by default, it is a system temporary storage path. | string                                                       | optional |
| outputPath          | An instance of one of PathParameter descendant classes; it represents a local or storage path where the result file will be saved. | **[PathParameter](ApiParameter.md)**                         |          |
| resources           | When the conversion source is an HTML file that contains relative links to local resources (images, CSS etc.), these resource paths can be specified by this parameter. | List<string>                                                 | optional |
| nameCollisionOption | How to handle a resulting file name collision. There are 3 options: *FailIfExists* (default), *GenerateUniqueName*, *ReplaceExisting.* | enum **NameCollisionOption**                                 | optional |
| observer            | Object that will get notifications on the conversion process state changes. It must implement the interface *IObserver<Conversion.Conversion>* | [IObserver](https://docs.microsoft.com/en-us/dotnet/api/system.iobserver-1?view=net-5.0)<[Conversion.Conversion]()> | optional |

**Note concerning `observer` parameter:**

Default implementation of [IObserver](https://docs.microsoft.com/en-us/dotnet/api/system.iobserver-1?view=net-5.0)<[Conversion.Conversion]()> interface is an internal class ConversionObserver. This implementation does nothing.

You are free to create your own implementation of [IObserver](https://docs.microsoft.com/en-us/dotnet/api/system.iobserver-1?view=net-5.0)<[Conversion.Conversion]()> interface and use its instance as `observer` parameter calling asynchronous conversion methods to receive notification on the process errors or work completion.



<a name="Convert_builder" />

### Convert

> ```
> Conversion.Conversion Convert(ConversionBuilder builder)
> ```

Runs synchronously a conversion with source, target and other parameters Converts synchronously a file (or files) Uses the builder style  setup of the conversion parameters using [ConversionBuilder](ConversionBuilder.md) class. 



The specialized versions of the conversion methods are described below.






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

<a name="ConvertUrlAsync" />

### ConvertUrlAsync

> ```
> AsyncResult<Conversion.Conversion> ConvertUrlAsync(
>             string url, 
>             ConversionOptions options,
>             PathParameter outputPath = null, 
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Starts asynchronously a long-time conversion operation of a web page specified by its URL (*address* parameter). 

<a name="ConvertUrlAsync_1" />

### ConvertUrlAsync

> ```
> AsyncResult<Conversion.Conversion> ConvertUrlAsync(
>          string url, 
>          ConversionOptions options,
>          string outputPath = null, 
>          NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>          IObserver<Conversion.Conversion> observer = null)
> ```

Overloaded method. Starts asynchronously a long-time conversion operation of a web page specified by its URL (*address* parameter). 

<a name="ConvertUrl" />

### ConvertUrl

> ```
> Conversion.Conversion ConvertWebSite(
>             string url,
>             ConversionOptions options,
>             PathParameter outputPath = null,
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Synchronous mode of the *ConvertUrlAsync* method. Converts a web page specified by its URL.

<a name="ConvertUrl_1" />

### ConvertUrl

> ```
> Conversion.Conversion ConvertWebSite(
>             string url,
>             ConversionOptions options,
>             string outputPath = null, 
>             NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>             IObserver<Conversion.Conversion> observer = null)
> ```

Overloaded method. Synchronous mode of the *ConvertUrlAsync* method. Converts a web page specified by its URL.



<a name="ConvertLocalFileAsync" />

### ConvertLocalFileAsync

> ```
> AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
>          string filePath,
>          ConversionOptions options,
>          PathParameter outputPath,
>          List<string> resources,
>          NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>          IObserver<Conversion.Conversion> observer = null)
> ```

Starts asynchronously a long-time conversion operation of a file specified by its local file system path.


<a name="ConvertLocalFileAsync_1" />
### ConvertLocalFileAsync

> ```
> AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
>          string filePath, 
>          ConversionOptions options,
>          string outputFilePath = null, 
>          List<string> resources = null,
>          NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>          IObserver<Conversion.Conversion> observer = null)
> ```

Overloaded method.  Starts asynchronously a long-time conversion operation of a file specified by its local file system path.

<a name="ConvertLocalFile" />

### ConvertLocalFile

> ```
> Conversion.Conversion ConvertLocalFile(
>          string filePath,
>          ConversionOptions options,
>          PathParameter outputPath,
>          List<string> resources = null,
>          NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>          IObserver<Conversion.Conversion> observer = null)
> ```

Synchronous mode of the *ConvertLocalFileAsync* method. Converts a file specified by its local file system path.


<a name="ConvertLocalFile_1" />
### ConvertLocalFile

> ```
> Conversion.Conversion ConvertLocalFile(
>          string filePath, 
>          ConversionOptions options,
>          string outputPath = null,
>          List<string> resources = null,
>          NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>          IObserver<Conversion.Conversion> observer = null)
> ```

Overloaded method. Synchronous mode of the *ConvertLocalFileAsync* method. Converts several files specified by a list of their local file system paths.

<a name="ConvertLocalDirectory" />

### ConvertLocalDirectory

> ```
> Conversion.Conversion ConvertLocalDirectory(
>          string directoryPath,
>          string startPoint,
>          ConversionOptions options,
>          PathParameter outputFilePath = null,
>          NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>          IObserver<Conversion.Conversion> observer = null)
> ```

Converts synchronously an HTML file located with its resource files in a local directory.

<a name="ConvertLocalDirectory_1" />

### ConvertLocalDirectory

> ```
> Conversion.Conversion ConvertLocalDirectory(
>          string directoryPath,
>          string startPoint,
>          ConversionOptions options,
>          string outputFilePath = null,
>          NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>          IObserver<Conversion.Conversion> observer = null)
> ```

Overload method. Converts synchronously an HTML file located with its resource files in a local directory.

<a name="ConvertLocalArchive" />

### ConvertLocalArchive

> ```
> Conversion.Conversion ConvertLocalDirectory(
>          string archivePath,
>          string startPoint,
>          ConversionOptions options,
>          PathParameter outputFilePath = null,
>          NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>          IObserver<Conversion.Conversion> observer = null)
> ```

Converts synchronously an HTML file located with its resource files in a ZIP archive.

<a name="ConvertLocalArchive_1" />

### ConvertLocalArchive

> ```
> Conversion.Conversion ConvertLocalDirectory(
>          string archivePath,
>          string startPoint,
>          ConversionOptions options,
>          string outputFilePath = null,
>          NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
>          IObserver<Conversion.Conversion> observer = null)
> ```

Overload method. Converts synchronously an HTML file located with its resource files in a ZIP archive.