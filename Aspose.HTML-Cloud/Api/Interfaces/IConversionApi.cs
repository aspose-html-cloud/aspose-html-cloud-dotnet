// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="IConversionApi.cs">
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
    public interface IConversionApi
    {
        /// <summary>
        /// Convert the HTML document to the specified image format. 
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="outFormat">Output image format.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="folder">The source document folder.</param>
        /// <param name="storage">The source document storage.</param>
        /// <returns>System.IO.Stream | Stream of the resulting image.</returns>
        Stream GetConvertDocumentToImage(
            string name, string outFormat,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null, 
            string folder = null, string storage = null);

        /// <summary>
        /// Convert the HTML document to the specified image format by URL. 
        /// </summary>
        /// <param name="sourceUrl">The source page URL.</param>
        /// <param name="outFormat">Output image format.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <returns>System.IO.Stream | Stream of the resulting image.</returns>
        Stream GetConvertDocumentToImageByUrl(
            string sourceUrl, string outFormat,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null);

        /// <summary>
        /// Convert the HTML document to PDF. 
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="folder">The source document folder.</param>
        /// <param name="storage">The source document storage.</param>
        /// <returns>System.IO.Stream | Stream of the resulting PDF document.</returns>
        Stream GetConvertDocumentToPdf(
             string name,
             int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
             int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null);

        /// <summary>
        /// Convert the HTML document to PDF by URL. 
        /// </summary>
        /// <param name="sourceUrl">The source page URL.</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top image document page.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <returns>System.IO.Stream | Stream of the resulting PDF document.</returns>
        Stream GetConvertDocumentToPdfByUrl(
            string sourceUrl,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null);

        /// <summary>
        /// Convert the HTML document to XPS. 
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top image document page.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream | Stream of the resulting XPS document.</returns>
        Stream GetConvertDocumentToXps(
             string name,
             int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
             int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null);

        /// <summary>
        /// Convert the HTML document to XPS by URL. 
        /// </summary>
        /// <param name="sourceUrl">The source page URL.</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <returns>System.IO.Stream | Stream of the resulting XPS document.</returns>
        Stream GetConvertDocumentToXpsByUrl(
            string sourceUrl,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null);

        /// <summary>
        /// Convert the HTML document to the specified image format and save to storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outFormat">Output image format</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.jpg</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="resolution">Image resolution; 96 ppi by default.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns></returns>
        AsposeResponse PutConvertDocumentToImage(string name, 
            string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null, string folder = null, string storage = null);

        /// <summary>
        /// Convert the HTML document stream to the specified image format and save to storage.
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
        /// <returns></returns>
        AsposeResponse PutConvertDocumentToImage(Stream inStream,
            string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null);

        /// <summary>
        /// Convert the HTML document to PDF and save to storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.pdf</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns></returns>
        AsposeResponse PutConvertDocumentToPdf(string name,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null);

        /// <summary>
        /// Convert the HTML document stream to PDF and save to storage.
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
        /// <returns></returns>
        AsposeResponse PutConvertDocumentToPdf(Stream inStream,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        /// <summary>
        /// Convert the HTML document to XPS and save to storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.xps</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns></returns>
        AsposeResponse PutConvertDocumentToXps(string name,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null);

        /// <summary>
        /// Convert the HTML document stream to XPS and save to storage.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.xps</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="storage">Resulting document storage</param>
        /// <returns></returns>
        AsposeResponse PutConvertDocumentToXps(Stream inStream,
            string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);


    }
}
