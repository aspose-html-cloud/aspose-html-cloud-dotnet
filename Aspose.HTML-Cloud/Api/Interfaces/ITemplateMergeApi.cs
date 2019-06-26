// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ITemplateMergeApi.cs">
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
using Aspose.Html.Cloud.Sdk.Api.Model.Requests;

namespace Aspose.Html.Cloud.Sdk.Api.Interfaces
{
    /// <summary>
    /// Represents a collection of functions to interact with the HTML conversion API endpoints
    /// </summary>
    public interface ITemplateMergeApi
    {
        /// <summary>
        /// Populates HTML document template with data located as a file in the storage.
        /// </summary>
        /// <param name="templateName">Template document name. Template document is HTML or zipped HTML. Template location is /{folder}/{templateName}.</param>
        /// <param name="dataPath">Data source file path in the storage. Supported data format: XML.</param>
        /// <param name="options">Template merge options: reserved for further implementation.</param>
        /// <param name="folder">The template document folder.</param>
        /// <param name="storage">The template document and data source storage.</param>
        /// <returns>StreamResponse | Stream containing the generated document.</returns>
        StreamResponse GetMergeHtmlTemplate(string templateName, string dataPath, string options = null, string folder = null, string storage = null);

        /// <summary>
        /// Populates HTML document template with data from the stream. Result document will be saved to storage.
        /// </summary>
        /// <param name="templateName">Template document name. Template document is HTML or zipped HTML. Template location is /{folder}/{templateName}.</param>
        /// <param name="inStream">Data source stream. Supported data format: XML.</param>
        /// <param name="dataType">Source stream data type. Supported values are 'xml' and 'json'</param>
        /// <param name="outPath">Result document path in the storage.</param>
        /// <param name="options">Template merge options: reserved for further implementation.</param>
        /// <param name="folder">The template document folder.</param>
        /// <param name="storage">Optional. The template document and data source storage.</param>
        /// <returns>AsposeResponse | Response status.</returns>
        AsposeResponse PostMergeHtmlTemplate(string templateName, Stream inStream, string dataType, string outPath, string options = null, string folder = null, string storage = null);
    }
}
