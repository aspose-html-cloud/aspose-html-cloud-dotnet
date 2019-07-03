// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="IDocumentApi.cs">
//   Copyright (c) 2018 Aspose.HTML for Cloud
// </copyright>
// <summary>
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.Html.Cloud.Sdk.Api.Interfaces
{
    /// <summary>
    /// Represents a collection of functions to interact with the HTML document manipulation API endpoints
    /// </summary>
    public interface IDocumentApi
    {
        #region // AR 28.09.2018 - removed since wrapped API endpoint has been excluded
        ///// <summary>
        ///// Return the HTML document by the name from default or specified storage. 
        ///// </summary>
        ///// <param name="name">The document name.</param>
        ///// <param name="storage">The document folder</param>
        ///// <param name="folder">The document folder.</param>
        ///// <returns>System.IO.Stream | Stream containing the requested document</returns>
        //Stream GetDocument(string name, string storage, string folder);
        #endregion

        /// <summary>
        /// Returns list of HTML fragments in the document matching the specified XPath query.  
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="xPath">XPath query string.</param>
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>AsposeStreamResponse | Stream containing the requested fragments</returns>
        /// 
        StreamResponse GetDocumentFragmentByXPath(string name, string xPath, string outFormat, string storage, string folder);

        /// <summary>
        /// Returns list of HTML fragments in the document matching the specified CSS selector.  
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="selector">CSS selector string.</param>
        /// <param name="outFormat">Result format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>AsposeStreamResponse | Response object containing MemoryStream with the requested fragments</returns>
        StreamResponse GetDocumentFragmentByCSSSelector(string name, string selector, string outFormat, string storage, string folder);

        /// <summary>
        /// Returns all images from the HTML document packaged as a ZIP archive. 
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>AsposeStreamResponse | Response object containing MemoryStream with the ZIP archive of all images.</returns>
        StreamResponse GetDocumentImages(string name, string storage, string folder);

        /// <summary>
        /// Returns list of HTML fragments in the Web page by its URL matching the specified XPath query.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <param name="xPath">XPath query string.</param>
        /// <param name="outFormat">Result format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <returns>AsposeStreamResponse | Response object containing MemoryStream with the requested fragments</returns>
        StreamResponse GetDocumentFragmentByXPathByUrl(string sourceUrl, string xPath, string outFormat);

        /// <summary>
        /// Returns list of HTML fragments  in the Web page by its URL matching the specified CSS selector.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <param name="selector">CSS selector string.</param>
        /// <param name="outFormat">Result format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <returns>AsposeStreamResponse | Response object containing MemoryStream with the requested fragments</returns>
        StreamResponse GetDocumentFragmentByCSSSelectorByUrl(string sourceUrl, string selector, string outFormat);

        /// <summary>
        /// Returns all HTML document images packaged as a ZIP archive by Web page URL.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <returns></returns>
        StreamResponse GetDocumentImagesByUrl(string sourceUrl);

        /// <summary>
        /// Downloads HTML page with linked resources from Web by its URL and returns it as a ZIP archive.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <returns></returns>
        StreamResponse GetDocumentByUrl(string sourceUrl);
    }

}
