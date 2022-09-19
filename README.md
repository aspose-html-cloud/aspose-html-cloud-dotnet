![](https://img.shields.io/badge/api-v4.0-lightgrey)  ![Nuget](https://img.shields.io/nuget/v/Aspose.html-Cloud) ![Nuget](https://img.shields.io/nuget/dt/Aspose.html-Cloud) [![GitHub license](https://img.shields.io/github/license/aspose-html-cloud/aspose-html-cloud-dotnet)](https://github.com/aspose-html-cloud/aspose-html-cloud-dotnet/blob/master/LICENSE)
# Aspose.HTML Cloud SDK for .NET
Aspose.HTML Cloud for .NET is a programming SDK that allows software developers convertint HTML documents to PDF, Image, XPS, DOCX.

## Convert HTML to
- Fixed Layout: PDF, XPS, DOCX
- Images: TIFF, JPEG, PNG, BMP, GIF
- Other: MD, MHTML

## Read HTML Formats
*eBook*: EPUB
*Other*: XML, SVG


## How to use the SDK?

The complete source code is available in this repository folder. You can either use it directly in your project via source code or get [NuGet distribution](https://www.nuget.org/packages/Aspose.HTML-Cloud/) (recommended).
For more details, please visit our [documentation website](https://docs.aspose.cloud/display/htmlcloud/Available+SDKs#AvailableSDKs-.NET).

<a name="HowTo-prerequisites"></a>
### Prerequisites

To use Aspose HTML for Cloud .NET SDK register an account with [Aspose Cloud](https://www.aspose.cloud/) and lookup/create `Client ID` and `Client Secret` at [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps). There is free quota available. For more details, see [Aspose Cloud Pricing](https://purchase.aspose.cloud/pricing).

<a name="HowTo-installation"></a>

### Installation

Get the ready package from [NuGet](https://www.nuget.org/packages/Aspose.HTML-Cloud/) or build from source available in this repository folder Aspose.HTML-Cloud.

<a name="HowTo-install-nuget"></a>

#### Install Aspose.HTML-Cloud via NuGet


From the command line:

    nuget install Aspose.HTML-Cloud

From Package Manager:

    PM> Install-Package Aspose.HTML-Cloud


<a name="HowTo-RunTestsExamples"></a>

### Run tests and examples

To run tests, firstly modify the Settings\servercreds.json file setting up your `Client ID` & `Client Secret` that you have obtained before (see Prerequisites) and basePath if it differs from http://api.aspose.cloud.

To run examples, modify the Aspose.HTML.Cloud.SDK.Examples\App.config file setting up **ClientID**, **ClientSecret**, and optionally DataPath.

<a name="CodeExample"></a>
### Usage sample

The example below demonstrates how you can use the proposed SDK functionality in your application.
In this example, the HTML document located by local path is converted to another format, e.g. PDF using Aspose.HTML-Cloud library.

**How to try this code sample**:

 1. Open Visual Studio and create an empty solution.
 2. In the solution, create a  C# console application project.
 3. In the console project, install the last version of Aspose.HTML-Cloud package from NuGet  ( see [Install Aspose.HTML-Cloud via NuGet](README.md#HowTo-install-nuget) above ).
 4. Copy the code snippet below and replace Program.cs file content.
 5. Replace `ClientSecret` and `ClientId` variable values in the code with respective values from your account ( see [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps) page ).
 6. Run the application and check a result by the path displayed in the console output.

For more buildable and executable examples, refer the [**Documentation for API Endpoints**](README.md#Doc_API) chapter.

## Basic example - convert local HTML file to required format
```csharp
// Init client
var client = new HtmlApi("client_id", "client_secret").ConvertApi;

// Just provide path to source file and path to output file
// Convert HTML to PDF
await client.ConvertAsync("test.html", "test.pdf");

// Convert HTML to PNG
await client.ConvertAsync("test.html", "test.png");

// Convert HTML to DOC
await client.ConvertAsync("test.html", "test.doc");

// Convert HTML to XPS
await client.ConvertAsync("test.html", "test.xps");

```

## Basic example - convert url to required format
```csharp
// Init client
var client = new HtmlApi("client_id", "client_secret").ConvertApi;

// Just provide path to source file and path to output file
// Convert HTML to PDF
await client.ConvertUrlAsync("https://test.html", "test.pdf");

// Convert HTML to PNG
await client.ConvertUrlAsync("https://test.html", "test.png");

// Convert HTML to DOC
await client.ConvertUrlAsync("https://test.html", "test.doc");

// Convert HTML to XPS
await client.ConvertUrlAsync("https://test.html", "test.xps");

```

<a name="Dependencies"></a>
## Dependencies

- .NET Standard 2.0 or later
- Newtonsoft.Json 12.0.2 or later


<br>
<a name="Resources"></a>

## Aspose.HTML Cloud SDKs in Popular Languages

| .NET                                                                    | Java                                                                                                              | PHP                                                                     | Python                                                                  | Ruby                                                                  | Node.js                                                                 | Android                                                                                                           | Swift                                                                  | C++                                                                  |                                                                   |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | --------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------- | -------------------------------------------------------------------- | ------------------------------------------------------------------- |
| [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-dotnet) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-java)                                             | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-php)    | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-python) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-ruby) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-nodejs) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-android)                                          | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-swift) | [GitHub](https://github.com/aspose-html-cloud/aspose-html-cloud-cpp)  |
| [NuGet](https://www.nuget.org/packages/Aspose.html-Cloud/)              | [Maven](https://repository.aspose.cloud/webapp/#/artifacts/browse/tree/General/repo/com/aspose/aspose-html-cloud) | [Composer](https://packagist.org/packages/aspose/aspose-html-cloud-php) | [PIP](https://pypi.org/project/asposehtmlcloud/)                        | [GEM](https://rubygems.org/gems/aspose_html_cloud)                    | [NPM](https://www.npmjs.com/package/@asposecloud/aspose-html-cloud)     | [Maven](https://repository.aspose.cloud/webapp/#/artifacts/browse/tree/General/repo/com/aspose/aspose-html-cloud) | [Cocoapods](https://cocoapods.org/pods/AsposeHtmlCloud)                | [NuGet](https://www.nuget.org/packages/Aspose.Html-Cloud.Cpp/)                                                               |

[Product Page](https://products.aspose.cloud/html/net) | [Documentation](https://docs.aspose.cloud/display/htmlcloud/Home) | [Code Samples](https://github.com/aspose-html-cloud/aspose-html-cloud-dotnet) | [Blog](https://blog.aspose.cloud/category/html/) | [Free Support](https://forum.aspose.cloud/c/html) | [Free Trial](https://dashboard.aspose.cloud/#/apps)
