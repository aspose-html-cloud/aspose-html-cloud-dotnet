using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Aspose.Html.Client;
using Com.Aspose.Html.NativeClient;

namespace Com.Aspose.Html.Api.Interfaces
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
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
        /// <param name="xResolution">Horizontal image resolution; 96 ppi by default.</param>
        /// <param name="yResolution">Vertical image resolution; 96 ppi by default.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetConvertDocumentToImage(
            string name, string outFormat,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? xResolution = null, int? yResolution = null,
            string folder = null, string storage = null);

        /// <summary>
        /// Convert the HTML document to the specified image format by URL. 
        /// </summary>
        /// <param name="sourceUrl">The source file name.</param>
        /// <param name="outFormat">Output image format.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="xResolution">Horizontal image resolution; 96 ppi by default.</param>
        /// <param name="yResolution">Vertical image resolution; 96 ppi by default.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetConvertDocumentToImageByUrl(
            string sourceUrl, string outFormat,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? xResolution = null, int? yResolution = null,
             string storage = null);

        /// <summary>
        /// Convert the HTML document to PDF. 
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetConvertDocumentToPdf(
             string name,
             int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
             int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null);

        /// <summary>
        /// Convert the HTML document to PDF by URL. 
        /// </summary>
        /// <param name="sourceUrl">The source file name.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetConvertDocumentToPdfByUrl(
            string sourceUrl,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        /// <summary>
        /// Convert the HTML document to XPS. 
        /// </summary>
        /// <param name="name">The source file name.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetConvertDocumentToXps(
             string name,
             int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
             int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null);

        /// <summary>
        /// Convert the HTML document to XPS by URL. 
        /// </summary>
        /// <param name="sourceUrl">The source file name.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream</returns>
        System.IO.Stream GetConvertDocumentToXpsByUrl(
            string sourceUrl,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);

        /// <summary>
        /// Convert the HTML document to the specified image format. 
        /// </summary>
        /// <param name="format">Output image format.</param>
        /// <param name="outPath">The path to resulting file; by default, exported document is returned in the HTTP response content stream.</param>
        /// <param name="width">Resulting image width. </param>
        /// <param name="height">Resulting image height. </param>
        /// <param name="leftMargin">Left image margin.</param>
        /// <param name="rightMargin">Right image margin.</param>
        /// <param name="topMargin">Top image margin.</param>
        /// <param name="bottomMargin">Bottom image margin.</param>
        /// <param name="xResolution">Horizontal image resolution; 96 ppi by default.</param>
        /// <param name="yResolution">Vertical image resolution; 96 ppi by default.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>System.IO.Stream</returns>
        NativeRestResponse PutConvertDocumentToImage(
            Stream inStream, string format, string outPath = null,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, int? xResolution = null, int? yResolution = null,
            string storage = null);

        /// <summary>
        /// Convert the HTML document to PDF. 
        /// </summary>
        /// <param name="outPath">The path to resulting file; by default, exported document is returned in the HTTP response content stream.</param>
        /// <param name="width">The page width of the resulting document. </param>
        /// <param name="height">The page height of the resulting document. </param>
        /// <param name="leftMargin">The left margin of the resulting document page.</param>
        /// <param name="rightMargin">The right margin of the resulting document page.</param>
        /// <param name="topMargin">The top margin of the resulting document page.</param>
        /// <param name="bottomMargin">The bottom margin of the resulting document page.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage. </param>
        /// <returns>System.IO.Stream</returns>
        NativeRestResponse PutConvertDocumentToPdf(
            Stream inStream, string outPath = null,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);
        /// <summary>
        /// Convert the HTML document to XPS. 
        /// </summary>
        /// <param name="outPath">The path to resulting file; by default, exported document is returned in the HTTP response content stream.</param>
        /// <param name="width">The page width of the resulting document. </param>
        /// <param name="height">The page height of the resulting document. </param>
        /// <param name="leftMargin">The left margin of the resulting document page.</param>
        /// <param name="rightMargin">The right margin of the resulting document page.</param>
        /// <param name="topMargin">The top margin of the resulting document page.</param>
        /// <param name="bottomMargin">The bottom margin of the resulting document page.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage. </param>
        /// <returns>System.IO.Stream</returns>
        NativeRestResponse PutConvertDocumentToXps(
            Stream inStream, string outPath = null,
            int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null,
            int? topMargin = null, int? bottomMargin = null, string storage = null);
    }
}
