// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="IOcrApi.cs">
//   Copyright (c) 2019 Aspose.HTML Cloud
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
    /// Represents a collection of functions to interact with the OCR to HTML API endpoints
    /// </summary>
    public interface IOcrApi
    {
        /// <summary>
        /// Recognizes text content from the source image file by its name from default or specified storage, and creates an HTML document.
        /// </summary>
        /// <param name="name">String | Document name.</param>
        /// <param name="engineLang">String | Optional. OCR engine language. </param>
        /// <param name="folder">String | Optional. The document folder.</param>
        /// <param name="storage">String | Optional. The document storage.</param>
        /// <returns>StreamResponse |  Stream of resulting document. </returns>
        StreamResponse GetRecognizeAndImportToHtml(string name, string engineLang = "en", string folder = null, string storage = null);

        /// <summary>
        /// Recognizes text content from the source image file by its name from default or specified storage, and creates an HTML document translated to the specified language.
        /// </summary>
        /// <param name="name">String | Document name.</param>
        /// <param name="srcLang">String | Source language (considered as OCR engine language too).</param>
        /// <param name="resLang">String | Result language.</param>
        /// <param name="folder">String | Optional. The document folder.</param>
        /// <param name="storage">String | Optional. The document storage.</param>
        /// <returns>StreamResponse |  Stream of resulting document.</returns>
        StreamResponse GetRecognizeAndTranslateToHtml(string name, string srcLang, string resLang, string folder = null, string storage = null);
    }
}
