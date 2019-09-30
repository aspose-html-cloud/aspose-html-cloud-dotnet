// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="IImportApi.cs">
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
    /// Represents a collection of functions to interact with the HTML document import from external formats API endpoints
    /// </summary>
    public interface IImportApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="storage"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        StreamResponse GetImportMarkdownToHtml(string name, string folder = null, string storage = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="outPath"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        AsposeResponse PutImportMarkdownToHtml(string name, string outPath, string folder = null, string storage = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inStream"></param>
        /// <param name="outPath"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        AsposeResponse PostImportMarkdownToHtml(Stream inStream, string outPath, string storage = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localFilePath"></param>
        /// <param name="outPath"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        AsposeResponse PostImportMarkdownToHtml(string localFilePath, string outPath, string storage = null);
    }
}
