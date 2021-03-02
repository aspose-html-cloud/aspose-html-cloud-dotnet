# ConverterBuilder

A class that is used to build the conversion parameters.

## Table of contents

> - [**Summary**](ConversionBuilder.md#Summary)
> - [**Example**](ConversionBuilder.md#Example)
> - [**Properties**](ConversionBuilder.md#Properties)
>   - [InputFormat](ConversionBuilder.md#InputFormat)
>   - [OutputFormat](ConversionBuilder.md#OutputFormat)
>   - [InputPath](ConversionBuilder.md#InputPath)
>   - [OutputPath](ConversionBuilder.md#OutputPath)
>   - [Options](ConversionBuilder.md#Options)
> - [**Public methods**](ConversionBuilder.md#Public_methods)
>   - [FromLocalFile](ConversionBuilder.md#FromLocalFile)
>   - [FromLocalDirectory](ConversionBuilder.md#FromLocalDirectory)
>   - [FromLocalArchive](ConversionBuilder.md#FromLocalArchive)
>   - [FromStorageFile](ConversionBuilder.md#FromStorageFile)
>   - [FromStorageDirectory](ConversionBuilder.md#FromStorageDirectory)
>   - [FromStorageArchive](ConversionBuilder.md#FromStorageArchive)
>   - [FromUrl](ConversionBuilder.md#FromUrl)
>   - [To](ConversionBuilder.md#To)
>   - [SaveToLocal](ConversionBuilder.md#SaveToLocal)
>   - [SaveToStorage](ConversionBuilder.md#SaveToStorage)



<a name="Summary" />

## Summary

**ConverterBuilder** class provides a convenient, compact and elegant way to specify parameters of conversion.

For additional information about Aspose.HTML Cloud REST API and SDKs, visit the [Aspose documentation site](https://docs.aspose.cloud/html/overview/).



<a name="Example" />

## Example

This example explains how to use ConversionBuilder to set up the conversion parameters.

```c#
string sourceFile = Path.Combine(projPath, "TestSource", "test.html");

using(var api = new HtmlApi(clientId : clientId, clientSecret : ClientSecret))
{
    // Create converter by ConverterBuilder
    ConverterBuilder convHtmlPdf = new ConverterBuilder()
        .FromLocalFile(sourceFile)
        .To(new PDFConversionOptions())
        .SaveToLocal("d:\\TestResultDirectory");  
    
    // Convert html page to pdf
    ConversionResult result = api.Convert(convHtmlPdf);
}

```

<a name="Properties" />

## Properties

<a name="InputFormat" />

### InputFormat

> ```c#
> InputFormats InputFormat { get; private set; }
> ```

Format of the conversion source file(s). Read-only property that is derived from the source .

<a name="OutputFormat" />

### OutputFormat

> ```c#
> OutputFormats OutputFormat { get; private set; }
> ```

Conversion output format. Read-only property that is set up by [To]([](ConversionBuilder.md#)) method.

<a name="InputPath" />

### InputPaths

> ```c#
> List<string> InputPaths { get; private set; }
> ```

List of one or more paths that specify the conversion source. Read-only property that is set up by one of From methods.

<a name="OutputPath" />

### OutputPath

> ```c#
> string OutputPath { get; private set; }
> ```

Path of the conversion result file.  Read-only property that is set up by one of SaveTo methods.

<a name="Options" />

### Options

> ```c#
> ConversionOptions Options { get; private set; }
> ```

Conversion options; object of one of [ConversionOptions](ConversionOptions.md) derived classes. Read-only property that is set up by [To]([](ConversionBuilder.md#)) method.



<a name="Public_methods" />

## Public methods

All builder methods are divided into 3 groups:

- "From" methods; they specify a conversion source of various types;
- To method that specifies a conversion result format and some options specified for concrete output format;
- "SaveTo" methods;  they specify a destination where the conversion result will be saved.

### From...

Specifies input data for conversion.

Possible conversions:

 - HTML -> PDF, XPS, JPEG, PNG, BMP, GIF, TIFF, DOCX, MHTML, MD

 - XHTML -> PDF, XPS, JPEG, PNG, BMP, GIF, TIFF, DOCX, MHTML, MD

 - MHTML -> HTML, PDF, XPS, JPEG, PNG, BMP, DOCX, GIF, TIFF

 - EPUB -> PDF, XPS, JPEG, PNG, BMP, GIF, TIFF, DOCX

   

One of From methods, To method and one of SaveTo methods are required to be called with **ConversionBuilder** instance.

<a name="FromLocalFile" />

### FromLocalFile

> ```c#
> ConverterBuilder FromLocalFile(string inputPath)
> ```

Sets up a conversion source as a file, located in a local file system.

<a name="FromLocalDirectory" />

### FromLocalDirectory

> ```c#
> ConverterBuilder FromLocalDirectory(string inPath, string startPoint, params string[] files)
> ```

Sets up a conversion source as a file or files in a directory with linked resources (css, image, etc.), located in a local file system.

**Parameters**

- `inputDir` - path to the local directory
- `startPoint` - name of the file for conversion
- `files` - other files in the directory for conversion (optional)

<a name="FromLocalArchive" />

### FromLocalArchive

> ```c#
> ConverterBuilder FromLocalArchive(string inPath, string startPoint, params string[] files)
> ```

Sets up a conversion source as a ZIP file with linked resources inside, located in a local file system.

**Parameters**

- `inputPath` - path to a zip archive
- `startPoint` - file in the archive for conversion
- `files` - other files in the archive for conversion (optional)

<a name="FromStorageFile" />

### FromStorageFile

> ```c#
> ConverterBuilder FromStorageFile(string inPath)
> ```

Sets up a conversion source as a file, located in a cloud storage.

<a name="FromStorageDirectory" />

### FromStorageDirectory

> ```c#
> ConverterBuilder FromStorageDirectory(string inPath, string startPoint, params string[] files)
> ```

Sets up a conversion source as a file or files in a directory with linked resources (css, image, etc.), located in a cloud storage.

**Parameters**

- `inputDir` - path to the storage directory
- `startPoint` - name of the file for conversion
- `files` - other files in the directory for conversion (optional)

<a name="FromStorageArchive" />

### FromStorageArchive

> ```c#
> ConverterBuilder FromStorageArchive(string inPath, string startPoint, params string[] files)
> ```

Sets up a conversion source as a ZIP file with linked resources inside, located in a cloud storage.

**Parameters**

- `inputPath` - path to a zip archive
- `startPoint` - file in the archive for conversion
- `files` - other files in the archive for conversion (optional)

<a name="FromUrl" />

### FromUrl

> ```c#
> ConverterBuilder FromUrl(string inPath)
> ```

Sets up the conversion source as a Web page by its URL.



<a name="To" />

### To

> ```c#
> ConverterBuilder To(ConversionOptions options)
> ```

Sets up the conversion output format by using of an instance of one of [ConversionOptions](ConversionOptions.md) derived classes, with some additional format specific conversion options.



<a name="SaveToLocal" />

### SaveToLocal

> ```c#
> ConverterBuilder SaveToLocal(string outputDirectory)
> ```

Sets up the local file system directory where the conversion result will be saved to.



<a name="SaveToStorage" />

### SaveToStorage

> ```c#
> ConverterBuilder SaveToStorage(string outputDirectory)
> ```

Sets up the cloud storage directory where the conversion result will be saved to.