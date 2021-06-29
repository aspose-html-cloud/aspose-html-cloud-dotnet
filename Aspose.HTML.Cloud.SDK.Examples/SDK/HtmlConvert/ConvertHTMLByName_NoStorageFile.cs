using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlConvert
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to convert HTML page in the local filesystem; this example doesn't check
    /// the storage file existence, so REST API response has a NotFound response code and error description. 
    /// </summary>
    public class ConvertHTMLByName_NoStorageFile : ConvertHTMLByName
    {
        public ConvertHTMLByName_NoStorageFile(string format) : base(format)
        {
            CheckIfStorageFileExists = false;  // no source file check, to force API NotFound error generation and SDK exception
            FileName = "testpage_9999.html";   // non-existing storage file name setup 
        }
    }
}
