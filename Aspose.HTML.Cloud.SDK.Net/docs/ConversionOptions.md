## Conversion options

<a name="PDFConversionOptions"></a>
### PDFConversionOptions
```code
ConversionOptions pdfOpts = new PDFConversionOptions()
    .setHeight(800)
    .setWidth(1000)
    .setLeftMargin(10)
    .setRightMargin(10)
    .setBottomMargin(10)
    .setTopMargin(10)
    .setQuality(95);
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **width** | **Number**| Resulting document page width in points (1/96 inch). | [optional] 
 **height** | **Number**| Resulting document page height in points (1/96 inch). | [optional] 
 **leftMargin** | **Number**| Left resulting document page margin in points (1/96 inch). | [optional] 
 **rightMargin** | **Number**| Right resulting document page margin in points (1/96 inch). | [optional] 
 **topMargin** | **Number**| Top resulting document page margin in points (1/96 inch). | [optional] 
 **bottomMargin** | **Number**| Bottom resulting document page margin in points (1/96 inch). | [optional] 
 **JpegQuality** | **Number**| Quality of jpeg compression in percent. | [optional]

<a name="XPSConversionOptions"></a>
### XPSConversionOptions
```code
ConversionOptions xpsOpts = new XPSConversionOptions()
    .setHeight(800)
    .setWidth(1000)
    .setLeftMargin(10)
    .setRightMargin(10)
    .setBottomMargin(10)
    .setTopMargin(10);
```
Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **width** | **Number**| Resulting document page width in points (1/96 inch). | [optional] 
 **height** | **Number**| Resulting document page height in points (1/96 inch). | [optional] 
 **leftMargin** | **Number**| Left resulting document page margin in points (1/96 inch). | [optional] 
 **rightMargin** | **Number**| Right resulting document page margin in points (1/96 inch). | [optional] 
 **topMargin** | **Number**| Top resulting document page margin in points (1/96 inch). | [optional] 
 **bottomMargin** | **Number**| Bottom resulting document page margin in points (1/96 inch). | [optional] 

<a name="JPEGConversionOptions"></a>
### JPEGConversionOptions
```code
ConversionOptions jpgOpts = new JPEGConversionOptions()
    .setHeight(800)
    .setWidth(1000)
    .setLeftMargin(10)
    .setRightMargin(10)
    .setBottomMargin(10)
    .setTopMargin(10)
    .setResolution(300);
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **width** | **Number**| Resulting document page width in points (1/96 inch). | [optional] 
 **height** | **Number**| Resulting document page height in points (1/96 inch). | [optional] 
 **leftMargin** | **Number**| Left resulting document page margin in points (1/96 inch). | [optional] 
 **rightMargin** | **Number**| Right resulting document page margin in points (1/96 inch). | [optional] 
 **topMargin** | **Number**| Top resulting document page margin in points (1/96 inch). | [optional] 
 **bottomMargin** | **Number**| Bottom resulting document page margin in points (1/96 inch). | [optional]
 **resolution** | **Number**| Resolution of resulting image. Default is 96 dpi. | [optional]

<a name="PNGConversionOptions"></a> 
### PNGConversionOptions
```code
ConversionOptions pngOpts = new PNGConversionOptions()
    .setHeight(800)
    .setWidth(1000)
    .setLeftMargin(10)
    .setRightMargin(10)
    .setBottomMargin(10)
    .setTopMargin(10)
    .setResolution(300);
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **width** | **Number**| Resulting document page width in points (1/96 inch). | [optional] 
 **height** | **Number**| Resulting document page height in points (1/96 inch). | [optional] 
 **leftMargin** | **Number**| Left resulting document page margin in points (1/96 inch). | [optional] 
 **rightMargin** | **Number**| Right resulting document page margin in points (1/96 inch). | [optional] 
 **topMargin** | **Number**| Top resulting document page margin in points (1/96 inch). | [optional] 
 **bottomMargin** | **Number**| Bottom resulting document page margin in points (1/96 inch). | [optional]
 **resolution** | **Number**| Resolution of resulting image. Default is 96 dpi. | [optional]

<a name="BMPConversionOptions"></a>
### BMPConversionOptions
```code
ConversionOptions bmpOpts = new BMPConversionOptions()
    .setHeight(800)
    .setWidth(1000)
    .setLeftMargin(10)
    .setRightMargin(10)
    .setBottomMargin(10)
    .setTopMargin(10)
    .setResolution(300);
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **width** | **Number**| Resulting document page width in points (1/96 inch). | [optional] 
 **height** | **Number**| Resulting document page height in points (1/96 inch). | [optional] 
 **leftMargin** | **Number**| Left resulting document page margin in points (1/96 inch). | [optional] 
 **rightMargin** | **Number**| Right resulting document page margin in points (1/96 inch). | [optional] 
 **topMargin** | **Number**| Top resulting document page margin in points (1/96 inch). | [optional] 
 **bottomMargin** | **Number**| Bottom resulting document page margin in points (1/96 inch). | [optional]
 **resolution** | **Number**| Resolution of resulting image. Default is 96 dpi. | [optional]

<a name="GIFConversionOptions"></a>
### GIFConversionOptions
```code
ConversionOptions gifOpts = new GIFConversionOptions()
    .setHeight(800)
    .setWidth(1000)
    .setLeftMargin(10)
    .setRightMargin(10)
    .setBottomMargin(10)
    .setTopMargin(10)
    .setResolution(300);
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **width** | **Number**| Resulting document page width in points (1/96 inch). | [optional] 
 **height** | **Number**| Resulting document page height in points (1/96 inch). | [optional] 
 **leftMargin** | **Number**| Left resulting document page margin in points (1/96 inch). | [optional] 
 **rightMargin** | **Number**| Right resulting document page margin in points (1/96 inch). | [optional] 
 **topMargin** | **Number**| Top resulting document page margin in points (1/96 inch). | [optional] 
 **bottomMargin** | **Number**| Bottom resulting document page margin in points (1/96 inch). | [optional]
 **resolution** | **Number**| Resolution of resulting image. Default is 96 dpi. | [optional]

<a name="TIFFConversionOptions"></a>
### TIFFConversionOptions
```code
ConversionOptions tiffOpts = new TIFFConversionOptions()
    .setHeight(800)
    .setWidth(1000)
    .setLeftMargin(10)
    .setRightMargin(10)
    .setBottomMargin(10)
    .setTopMargin(10)
    .setResolution(300);
```

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **width** | **Number**| Resulting document page width in points (1/96 inch). | [optional] 
 **height** | **Number**| Resulting document page height in points (1/96 inch). | [optional] 
 **leftMargin** | **Number**| Left resulting document page margin in points (1/96 inch). | [optional] 
 **rightMargin** | **Number**| Right resulting document page margin in points (1/96 inch). | [optional] 
 **topMargin** | **Number**| Top resulting document page margin in points (1/96 inch). | [optional] 
 **bottomMargin** | **Number**| Bottom resulting document page margin in points (1/96 inch). | [optional]
 **resolution** | **Number**| Resolution of resulting image. Default is 96 dpi. | [optional]

<a name="MarkdownConversionOptions"></a>
### MarkdownConversionOptions
```code
ConversionOptions mdOpts = new MarkdownConversionOptions()
    .setUseGit(true);
```
Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **useGit** | **Boolean**| Use [Git Markdown flavor](https://github.github.com/gfm/) to save. | [optional] [default to false]

<a name="MHTMLConversionOptions"></a>
### MHTMLConversionOptions
```code
ConversionOptions mdOpts = new MHTMLConversionOptions();
```