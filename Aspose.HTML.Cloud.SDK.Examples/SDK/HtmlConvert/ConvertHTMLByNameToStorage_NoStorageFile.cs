using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.HTML.Cloud.Examples.SDK.HtmlConvert
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to convert HTML page in the local filesystem uploading it to Aspose cloud storage 
    /// and using its name and storage folder path; this example doesn't check
    /// the storage file existence, so REST API response has a NotFound response code and error description.
    /// </summary>
    public class ConvertHTMLByNameToStorage_NoStorageFile : ConvertHTMLByNameToStorage
    {

        public ConvertHTMLByNameToStorage_NoStorageFile(string format) : base(format)
        {
            FileName = "testpage_9999999.html";  // nonexisting storage source file setup
            CheckIfStorageFileExists = false;    // no source file check, to force API NotFound error generation and SDK exception
        }

    }
}
