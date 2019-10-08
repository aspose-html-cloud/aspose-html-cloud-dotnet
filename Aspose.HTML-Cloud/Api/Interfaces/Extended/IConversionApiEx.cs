// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="IConversionApiEx.cs">
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
using Aspose.Html.Cloud.Sdk.Api.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended
{
    /// <summary>
    /// Represents an extension of collection of functions to interact with the HTML conversion API endpoints
    /// </summary>
    public interface IConversionApiEx
    {

        /// <summary>
        /// Extension method. Converts the HTML document stream to the specified image format,
        /// saves resulting file to the storage and downloads the result as a stream. 
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outFormat">Output image format</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="storage">Resulting image storage</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting image.</returns>
        StreamResponse PostConvertDocumentToImageAndDownload(Stream inStream,
            string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null);


        /// <summary>
        /// Extension method. Converts the HTML document (located in the local file system) to the specified image format,
        /// saves resulting file to the storage and downloads the result as a stream. 
        /// </summary>
        /// <param name="localFilePath">The local file system path to source document.</param>
        /// <param name="outFormat">Output image format</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="storage">Resulting image storage</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting image.</returns>
        StreamResponse PostConvertDocumentToImageAndDownload(string localFilePath,
            string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null);

        /// <summary>
        /// Extension method. Converts the HTML document stream to PDF format,
        /// saves resulting file to the storage and downloads the result as a stream.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.pdf</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="storage">Resulting document storage</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting image.</returns>
        StreamResponse PostConvertDocumentToPdfAndDownload(Stream inStream,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localFilePath"></param>
        /// <param name="outPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="storage"></param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting image.</returns>
        StreamResponse PostConvertDocumentToPdfAndDownload(string localFilePath,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inStream"></param>
        /// <param name="outPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="storage"></param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting image.</returns>
        StreamResponse PostConvertDocumentToXpsAndDownload(Stream inStream,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localFilePath"></param>
        /// <param name="outPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="storage"></param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting image.</returns>
        StreamResponse PostConvertDocumentToXpsAndDownload(string localFilePath,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inStream"></param>
        /// <param name="outPath"></param>
        /// <param name="useGit"></param>
        /// <param name="storage"></param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting image.</returns>
        StreamResponse PostConvertDocumentToMarkdownAndDownload(Stream inStream, string outPath, bool? useGit = default(bool), string storage = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localFilePath">The local file system path to source document.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.md</param>
        /// <param name="useGit">Use Git flavor of Markdown</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting image.</returns>
        StreamResponse PostConvertDocumentToMarkdownAndDownload(string localFilePath, string outPath, bool? useGit = default(bool), string storage = null);
    }
}
