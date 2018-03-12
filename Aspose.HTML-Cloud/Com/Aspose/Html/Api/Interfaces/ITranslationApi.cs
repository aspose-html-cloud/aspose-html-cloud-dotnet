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
    public interface ITranslationApi
    {
        /// <summary>
        /// Translate the HTML document specified by the name from default or specified storage. 
        /// </summary>
        /// <param name="name">Document name.</param>
        /// <param name="srcLang">Source language.</param>
        /// <param name="resLang">Result language.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetTranslateDocument(string name, string srcLang, string resLang, string folder = null, string storage = null);
        /// <summary>
        /// Translate the HTML document specified by its URL. 
        /// </summary>
        /// <param name="sourceUrl">Source document URL.</param>
        /// <param name="srcLang">Source language.</param>
        /// <param name="resLang">Result language.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetTranslateDocumentByUrl(string sourceUrl, string srcLang, string resLang);
        /// <summary>
        /// Return the list of language pairs supported by the translator.  
        /// </summary>
        /// <returns>System.IO.Stream</returns>
        //System.IO.Stream HtmlDocumentTranslationGetTranslationSupportedLanguagePairs ();
        /// <summary>
        /// Translate the HTML document specified by the name from default or specified storage. 
        /// </summary>
        /// <param name="name">Document name.</param>
        /// <param name="srcLang">Source language.</param>
        /// <param name="resLang">Result language.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>NativeRestResponse</returns>
        NativeRestResponse PutTranslateDocument(string name, string srcLang, string resLang, string folder = null, string storage = null);
        /// <summary>
        /// Translate the HTML document specified by its URL. 
        /// </summary>
        /// <param name="sourceUrl">Source document URL.</param>
        /// <param name="srcLang">Source language.</param>
        /// <param name="resLang">Result language.</param>
        /// <param name="folder">The result document folder</param>
        /// <param name="storage">The result document storage</param>
        /// <returns>NativeRestResponse</returns>
        NativeRestResponse PutTranslateDocumentByUrl(string sourceUrl, string srcLang, string resLang, string folder = null, string storage = null);
    }

}
