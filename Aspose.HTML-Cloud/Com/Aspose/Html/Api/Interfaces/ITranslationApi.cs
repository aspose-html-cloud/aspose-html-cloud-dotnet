// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ITranslationApi.cs">
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
        /// <returns>Stream | Stream of resulting document.</returns>
        Stream GetTranslateDocument(string name, string srcLang, string resLang, string folder = null, string storage = null);
        
        /// <summary>
        /// Translate the HTML document specified by its URL. 
        /// </summary>
        /// <param name="sourceUrl">Source document URL.</param>
        /// <param name="srcLang">Source language.</param>
        /// <param name="resLang">Result language.</param>
        /// <returns>Stream | Stream of resulting document.</returns>
        Stream GetTranslateDocumentByUrl(string sourceUrl, string srcLang, string resLang);
       
    }

}
