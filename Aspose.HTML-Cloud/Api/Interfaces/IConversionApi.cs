// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="IConversionApi.cs">
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

namespace Aspose.Html.Cloud.Sdk.Api.Interfaces
{
    /// <summary>
    /// Represents a collection of functions to interact with the HTML conversion API endpoints
    /// </summary>
    public interface IConversionApi
    {
        #region Conversion to image
        /// <summary>
        /// Converts the HTML document (located on storage) to the specified image format and returns resulting file in the response content.
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="outFormat">Output image format.</param>
        /// <param name="width">Resulting image width (in 1/96 inch). </param>
        /// <param name="height">Resulting image height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left image margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right image margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top image margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom image margin (in 1/96 inch).</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="folder">The source document folder.</param>
        /// <param name="storage">The source document storage.</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting image.</returns>
        StreamResponse GetConvertDocumentToImage(
            string name, string outFormat,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null, 
            string folder = null, string storage = null);

        /// <summary>
        /// Converts the HTML page (located in the Web by its URL) to the specified image format and returns resulting file in the response content.
        /// </summary>
        /// <param name="sourceUrl">The source page URL.</param>
        /// <param name="outFormat">Output image format.</param>
        /// <param name="width">Resulting image width (in 1/96 inch). </param>
        /// <param name="height">Resulting image height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left image margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right image margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top image margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom image margin (in 1/96 inch).</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting image.</returns>
        StreamResponse GetConvertDocumentToImageByUrl(
            string sourceUrl, string outFormat,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null);

        /// <summary>
        /// Converts the HTML document (located on storage) to the specified image format and uploads resulting file to the storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outFormat">Output image format</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg</param>
        /// <param name="width">Resulting image width (in 1/96 inch). </param>
        /// <param name="height">Resulting image height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left image margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right image margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top image margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom image margin (in 1/96 inch).</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PutConvertDocumentToImage(string name,
            string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null, string folder = null, string storage = null);

        /// <summary>
        /// Converts the HTML document stream to the specified image format and uploads resulting file to the storage.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outFormat">Output image format</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg</param>
        /// <param name="width">Resulting image width (in 1/96 inch). </param>
        /// <param name="height">Resulting image height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left image margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right image margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top image margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom image margin (in 1/96 inch).</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="storage">Resulting image storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PostConvertDocumentToImage(Stream inStream, 
            string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null);

        /// <summary>
        /// Converts the HTML document (located in the local file system) to specified output format and uploads resulting file to the storage.
        /// </summary>
        /// <param name="localFilePath">The local file system path to source document.</param>
        /// <param name="outFormat">Output image format</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg</param>
        /// <param name="width">Resulting image width (in 1/96 inch). </param>
        /// <param name="height">Resulting image height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left image margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right image margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top image margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom image margin (in 1/96 inch).</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="storage">Resulting image storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PostConvertDocumentToImage(string localFilePath,
            string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null);

        #endregion // Conversion to image

        #region Conversion to PDF
        /// <summary>
        /// Converts the HTML document (located on storage) to PDF and returns resulting file in the response content.
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="width">Resulting document page width (in 1/96 inch). </param>
        /// <param name="height">Resulting document page height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left document page margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right document page margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top document page margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom document page margin (in 1/96 inch).</param>
        /// <param name="folder">The source document folder.</param>
        /// <param name="storage">The source document storage.</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting PDF document.</returns>
        StreamResponse GetConvertDocumentToPdf(
             string name,
             int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
             int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null);

        /// <summary>
        /// Converts the HTML page (located in the Web by its URL) to PDF and returns resulting file in the response content.
        /// </summary>
        /// <param name="sourceUrl">The source page URL.</param>
        /// <param name="width">Resulting document page width (in 1/96 inch). </param>
        /// <param name="height">Resulting document page height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left document page margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right document page margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top image document page margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom document page margin (in 1/96 inch).</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting PDF document.</returns>
        StreamResponse GetConvertDocumentToPdfByUrl(
            string sourceUrl,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null);


        /// <summary>
        /// Converts the HTML document (located on storage) to PDF and uploads resulting file to the storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.pdf</param>
        /// <param name="width">Resulting document page width (in 1/96 inch). </param>
        /// <param name="height">Resulting document page height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left document page margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right document page margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top document page margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom document page margin (in 1/96 inch).</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PutConvertDocumentToPdf(string name,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null);

        /// <summary>
        /// Converts the HTML document stream to PDF and uploads resulting file to the storage.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.pdf</param>
        /// <param name="width">Resulting document page width (in 1/96 inch). </param>
        /// <param name="height">Resulting document page height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left document page margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right document page margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top document page margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom document page margin (in 1/96 inch).</param>
        /// <param name="storage">Resulting document storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PostConvertDocumentToPdf(Stream inStream, 
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        /// <summary>
        /// Converts the HTML document (located in the local file system) to PDF and uploads resulting file to the storage.
        /// </summary>
        /// <param name="localFilePath">The local file system path to source document.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.pdf</param>
        /// <param name="width">Resulting document page width (in 1/96 inch). </param>
        /// <param name="height">Resulting document page height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left document page margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right document page margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top document page margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom document page margin (in 1/96 inch).</param>
        /// <param name="storage">Resulting document storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        /// <returns></returns>
        AsposeResponse PostConvertDocumentToPdf(string localFilePath,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        #endregion // Conversion to PDF

        #region Conversion to XPS

        /// <summary>
        /// Converts the HTML document (located on storage) to XPS and returns resulting file in the response content.
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="width">Resulting document page width (in 1/96 inch). </param>
        /// <param name="height">Resulting document page height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left document page margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right document page margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top image document page (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom document page margin (in 1/96 inch).</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting XPS document.</returns>
        StreamResponse GetConvertDocumentToXps(
             string name,
             int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
             int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null);

        /// <summary>
        /// Converts the HTML page (located in the Web by its URL) to XPS and returns resulting file in the response content. 
        /// </summary>
        /// <param name="sourceUrl">The source page URL.</param>
        /// <param name="width">Resulting document page width (in 1/96 inch). </param>
        /// <param name="height">Resulting document page height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left document page margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right document page margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top document page margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom document page margin (in 1/96 inch).</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting XPS document.</returns>
        StreamResponse GetConvertDocumentToXpsByUrl(
            string sourceUrl,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null);

        /// <summary>
        /// Converts the HTML document (located on storage) to XPS and uploads resulting file to the storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.xps</param>
        /// <param name="width">Resulting document page width (in 1/96 inch). </param>
        /// <param name="height">Resulting document page height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left document page margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right document page margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top document page margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom document page margin (in 1/96 inch).</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PutConvertDocumentToXps(string name,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null);

        /// <summary>
        /// Converts the HTML document stream to XPS and uploads resulting file to the storage.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.xps</param>
        /// <param name="width">Resulting document page width (in 1/96 inch). </param>
        /// <param name="height">Resulting document page height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left document page margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right document page margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top document page margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom document page margin (in 1/96 inch).</param>
        /// <param name="storage">Resulting document storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PostConvertDocumentToXps(Stream inStream,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        /// <summary>
        /// Converts the HTML document (located in the local file system) to XPS and uploads resulting file to the storage.
        /// </summary>
        /// <param name="localFilePath">The local file system path to source document.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.xps</param>
        /// <param name="width">Resulting document page width (in 1/96 inch). </param>
        /// <param name="height">Resulting document page height (in 1/96 inch). </param>
        /// <param name="leftMargin">Left document page margin (in 1/96 inch).</param>
        /// <param name="rightMargin">Right document page margin (in 1/96 inch).</param>
        /// <param name="topMargin">Top document page margin (in 1/96 inch).</param>
        /// <param name="bottomMargin">Bottom document page margin (in 1/96 inch).</param>
        /// <param name="storage">Resulting document storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PostConvertDocumentToXps(string localFilePath,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        #endregion // Conversion to XPS

        #region Conversion to Markdown

        /// <summary>
        /// Converts the HTML document (located on storage) to Markdown and returns resulting file in the response content.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="useGit">Use Git flavor of Markdown.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source document storage</param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting Markdown document.</returns>
        StreamResponse GetConvertDocumentToMarkdown(string name, bool? useGit = null, string folder = null, string storage = null);

        /// <summary>
        /// Converts the HTML document (located on storage) to Markdown and uploads resulting file to the storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.md</param>
        /// <param name="useGit">Use Git flavor of Markdown.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PutConvertDocumentToMarkdown(string name, string outPath,
            bool? useGit = default(bool), string folder = null, string storage = null);

        /// <summary>
        ///  Converts the HTML document stream to Markdown and uploads resulting file to the storage.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.md</param>
        /// <param name="useGit">Use Git flavor of Markdown</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PostConvertDocumentToMarkdown(Stream inStream, string outPath, bool? useGit = default(bool), string storage = null);

        /// <summary>
        /// Converts the HTML document (located in the local file system) to PDF and uploads resulting file to the storage.
        /// </summary>
        /// <param name="localFilePath">The local file system path to source document.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.md</param>
        /// <param name="useGit">Use Git flavor of Markdown</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns><see cref="AsposeResponse"/> | Response status.</returns>
        AsposeResponse PostConvertDocumentToMarkdown(string localFilePath, string outPath, bool? useGit = default(bool), string storage = null);

        #endregion // Conversion to Markdown

        /// <summary>
        /// Converts the HTML page (located in the Web by its URL) to MHTML and returns resulting file in the response content. 
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <returns><see cref="StreamResponse"/> | Stream of the resulting MHTML document.</returns>
        StreamResponse GetConvertDocumentToMHTMLByUrl(string sourceUrl);

        #region excluded API wrappers
        //StreamResponse GetConvertDocumentToMHTML(string name,
        //    int? maxDepth = null, ResourceHandling? javaScript = null, UrlRestriction? urlRestrict = null, ResourceHandling? defaults = null,
        //    string folder = null, string storage = null);

        //AsposeResponse PutConvertDocumentToMHTML(string name, string outPath,
        //            int? maxDepth = null, ResourceHandling? javaScript = null, UrlRestriction? urlRestrict = null, ResourceHandling? defaults = null,
        //    string folder = null, string storage = null);

        //AsposeResponse PutConvertDocumentToMHTML(Stream inStream, string outPath,
        //            int? maxDepth = null, ResourceHandling? javaScript = null, UrlRestriction? urlRestrict = null, ResourceHandling? defaults = null);
        #endregion
    }



}
