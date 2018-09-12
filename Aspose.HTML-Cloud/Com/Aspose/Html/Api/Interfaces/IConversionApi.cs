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
using System;
using System.IO;

namespace Com.Aspose.Html.Api.Interfaces
{
    /// <summary>
    /// Represents a collection of functions to interact with the HTML conversion API endpoints
    /// </summary>
    /// 
    [Obsolete]
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
        /// <param name="xResolution">Horizontal image resolution; 96 ppi by default.</param>
        /// <param name="yResolution">Vertical image resolution; 96 ppi by default.</param>
        /// <param name="folder">The source document folder.</param>
        /// <param name="storage">The source document storage.</param>
        /// <returns>System.IO.Stream | Stream of the resulting image.</returns>
        Stream GetConvertDocumentToImage(
            string name, string outFormat,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? xResolution = null, int? yResolution = null,
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
        /// <param name="xResolution">Horizontal image resolution; 96 ppi by default.</param>
        /// <param name="yResolution">Vertical image resolution; 96 ppi by default.</param>
        /// <param name="storage">The source document storage.</param>
        /// <returns>System.IO.Stream | Stream of the resulting image.</returns>
        Stream GetConvertDocumentToImageByUrl(
            string sourceUrl, string outFormat,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? xResolution = null, int? yResolution = null,
             string storage = null);

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
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream | Stream of the resulting PDF document.</returns>
        Stream GetConvertDocumentToPdfByUrl(
            string sourceUrl,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

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
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream | Stream of the resulting XPS document.</returns>
        Stream GetConvertDocumentToXpsByUrl(
            string sourceUrl,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        ///// <summary>
        ///// Convert the HTML document to the specified image format. 
        ///// </summary>
        ///// <param name="format">Output image format.</param>
        ///// <param name="outPath">The path to resulting file; by default, exported document is returned in the HTTP response content stream.</param>
        ///// <param name="width">Resulting image width. </param>
        ///// <param name="height">Resulting image height. </param>
        ///// <param name="leftMargin">Left image margin.</param>
        ///// <param name="rightMargin">Right image margin.</param>
        ///// <param name="topMargin">Top image margin.</param>
        ///// <param name="bottomMargin">Bottom image margin.</param>
        ///// <param name="xResolution">Horizontal image resolution; 96 ppi by default.</param>
        ///// <param name="yResolution">Vertical image resolution; 96 ppi by default.</param>
        ///// <param name="folder">The document folder.</param>
        ///// <param name="storage">The document storage.</param>
        ///// <returns>System.IO.Stream</returns>
        //NativeRestResponse PutConvertDocumentToImage(
        //    Stream inStream, string format, string outPath = null,
        //    int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
        //    int? topMargin = null, int? bottomMargin = null, int? xResolution = null, int? yResolution = null,
        //    string storage = null);

        ///// <summary>
        ///// Convert the HTML document to PDF. 
        ///// </summary>
        ///// <param name="outPath">The path to resulting file; by default, exported document is returned in the HTTP response content stream.</param>
        ///// <param name="width">The page width of the resulting document. </param>
        ///// <param name="height">The page height of the resulting document. </param>
        ///// <param name="leftMargin">The left margin of the resulting document page.</param>
        ///// <param name="rightMargin">The right margin of the resulting document page.</param>
        ///// <param name="topMargin">The top margin of the resulting document page.</param>
        ///// <param name="bottomMargin">The bottom margin of the resulting document page.</param>
        ///// <param name="folder">The document folder.</param>
        ///// <param name="storage">The document storage. </param>
        ///// <returns>System.IO.Stream</returns>
        //NativeRestResponse PutConvertDocumentToPdf(
        //    Stream inStream, string outPath = null,
        //    int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
        //    int? topMargin = null, int? bottomMargin = null, string storage = null);
        ///// <summary>
        ///// Convert the HTML document to XPS. 
        ///// </summary>
        ///// <param name="outPath">The path to resulting file; by default, exported document is returned in the HTTP response content stream.</param>
        ///// <param name="width">The page width of the resulting document. </param>
        ///// <param name="height">The page height of the resulting document. </param>
        ///// <param name="leftMargin">The left margin of the resulting document page.</param>
        ///// <param name="rightMargin">The right margin of the resulting document page.</param>
        ///// <param name="topMargin">The top margin of the resulting document page.</param>
        ///// <param name="bottomMargin">The bottom margin of the resulting document page.</param>
        ///// <param name="folder">The document folder.</param>
        ///// <param name="storage">The document storage. </param>
        ///// <returns>System.IO.Stream</returns>
        //NativeRestResponse PutConvertDocumentToXps(
        //    Stream inStream, string outPath = null,
        //    int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
        //    int? topMargin = null, int? bottomMargin = null, string storage = null);
    }
}
