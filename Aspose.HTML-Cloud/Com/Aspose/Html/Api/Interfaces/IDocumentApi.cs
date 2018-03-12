using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Aspose.Html.Client;
using Com.Aspose.Html.NativeClient;
using Com.Aspose.Html.Api.Interfaces;

namespace Com.Aspose.Html.Api.Interfaces
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDocumentApi
    {
        /// <summary>
        /// Return the HTML document by the name from default or specified storage. 
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="storage">The document folder</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetDocument(string name, string storage, string folder);
        /// <summary>
        /// Return list of HTML fragments matching the specified XPath query.  
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="xPath">XPath query string.</param>
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetDocumentFragmentByXPath(string name, string xPath, string outFormat, string storage, string folder);
        /// <summary>
        /// Return all HTML document images packaged as a ZIP archive. 
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetDocumentImages(string name, string storage, string folder);
    }

}
