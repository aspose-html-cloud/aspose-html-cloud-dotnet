﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="HtmlApi.cs">
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Internal;
using Aspose.Html.Cloud.Sdk.Client;

namespace Aspose.Html.Cloud.Sdk.Api
{
    /// <summary>
    /// Facade class providing wrapper methods of Aspose.Html Cloud REST API
    /// </summary>
    public class HtmlApi : ApiBase,
        IHtmlApi,
        IDocumentApi,
        IImportApi,
        IConversionApi,
        ITranslationApi,
        IOcrApi,
        ITemplateMergeApi,
        ISummarizationApi
    {
        #region Private fields

        private IConversionApi m_conversionApiImpl = null;
        private IDocumentApi m_documentApiImpl = null;
        private IOcrApi m_ocrApiImpl = null;
        private ITranslationApi m_translationApiImpl = null;
        private ITemplateMergeApi m_templMergeApiImpl = null;
        private ISummarizationApi m_summApiImpl = null;
        private IImportApi m_importApiImpl = null;

        #endregion

        #region Public Constructors

        /// <summary>
        /// Default constructor. Initalizes a new instance of HtmlApi class trying to get the user credentials
        /// (application SID and application key), REST API service URL and authentication service URL 
        /// from the application configuration file and then, if it don't succeed, from environment variables.
        /// If needed settings were not found both in the config file or in the environment variables, throws an exception.   
        /// </summary>
        public HtmlApi() : base()
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance HtmlApi class as the default constructor does
        /// and sets the service connection timeout.
        /// </summary>
        /// <param name="timeout">Service connection timeout</param>
        public HtmlApi(TimeSpan timeout) : base(timeout)
        { }

        /// <summary>
        /// Constructor. Initalizes a new instance of HtmlApi class with specified user credentials (application SID and application key),
        /// and REST API service URL; by default, authentication service URL is the same.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        public HtmlApi(String appSid, String appKey, String basePath)
            : base(appSid, appKey, basePath)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of HtmlApi class with specified user credentials (application SID and application key),
        /// REST API service URL and authentication service URL.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="authPath">Authorization service URL</param>
        public HtmlApi(String appSid, String appKey, String basePath, string authPath)
            : base(appSid, appKey, basePath, authPath)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of HtmlApi class with specified user credentials (application SID and application key),
        /// REST API service URL and service connection timeout; by default, authentication service URL is the same.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="timeout">Connection timeout</param>
        public HtmlApi(String appSid, String appKey, String basePath, TimeSpan timeout)
            : base(appSid, appKey, basePath, timeout)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of HtmlApi class with specified user credentials (application SID and application key),
        /// REST API service URL, authentication service URL and service connection timeout.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="authPath">Authorization service URL</param>
        /// <param name="timeout">Connection timeout</param>
        public HtmlApi(String appSid, String appKey, String basePath, string authPath, TimeSpan timeout)
            : base(appSid, appKey, basePath, authPath, timeout)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of HtmlApi class with Configuration object.
        /// </summary>
        /// <param name="config">Configuration object</param>
        public HtmlApi(Configuration config) : base(config)
        { }

        /// <summary>
        /// Constructor. Initalizes a new instance of HtmlApi class inheriting ApiClient object
        /// of existing ApiBase descendant class instance, so authorization data become shared between both instances.
        /// </summary>
        /// <param name="instance">Existing ApiBase inherited class instance</param>
        public HtmlApi(ApiBase instance) : base(instance)
        {
        }

        #endregion


        #region Private properties - API implementation accessors

        private IConversionApi ConversionApiImpl
        {
            get
            {
                if (m_conversionApiImpl == null)
                {
                    m_conversionApiImpl = new ConversionApiImpl(ApiClient);
                }
                return m_conversionApiImpl;
            }
        }

        private IDocumentApi DocumentApiImpl
        {
            get
            {
                if (m_documentApiImpl == null)
                {
                    m_documentApiImpl = new DocumentApiImpl(ApiClient);
                }
                return m_documentApiImpl;
            }
        }

        private IImportApi ImportApiImpl
        {
            get
            {
                if(m_importApiImpl == null)
                {
                    m_importApiImpl = new ImportApiImpl(ApiClient);
                }
                return m_importApiImpl;
            }
        }

        private IOcrApi OcrApiImpl
        {
            get
            {
                if (m_ocrApiImpl == null)
                {
                    m_ocrApiImpl = new OcrApiImpl(ApiClient);
                }
                return m_ocrApiImpl;
            }
        }

        private ITranslationApi TranslationApiImpl
        {
            get
            {
                if (m_translationApiImpl == null)
                {
                    m_translationApiImpl = new TranslationApiImpl(ApiClient);
                }
                return m_translationApiImpl;
            }
        }

        private ITemplateMergeApi TemplateMergeImpl
        {
            get
            {
                if (m_templMergeApiImpl == null)
                {
                    m_templMergeApiImpl = new TemplateMergeApiImpl(ApiClient);
                }
                return m_templMergeApiImpl;
            }
        }

        private ISummarizationApi SummarizationApiImpl
        {
            get
            {
                if (m_summApiImpl == null)
                {
                    m_summApiImpl = new SummarizationApiImpl(ApiClient);
                }
                return m_summApiImpl;
            }

        }

        #endregion

        #region IDocumentApi interface implementation

        /// <summary>
        /// Downloads HTML page with linked resources from Web by its URL and returns it as a ZIP archive.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <returns></returns>
        public StreamResponse GetDocumentByUrl(string sourceUrl)
        {
            return DocumentApiImpl.GetDocumentByUrl(sourceUrl);
        }

        /// <summary>
        /// Returns list of HTML fragments in the document matching the specified CSS selector.  
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="selector">CSS selector string.</param>
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>StreamResponse | Response object containing MemoryStream with the requested fragments</returns>
        public StreamResponse GetDocumentFragmentByCSSSelector(string name, string selector, string outFormat, string storage, string folder)
        {
            return DocumentApiImpl.GetDocumentFragmentByCSSSelector(name, selector, outFormat, storage, folder);
        }

        /// <summary>
        /// Returns list of HTML fragments  in the Web page by its URL matching the specified CSS selector.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <param name="selector">CSS selector string.</param>
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <returns>StreamResponse | Response object containing MemoryStream with the requested fragments</returns>
        public StreamResponse GetDocumentFragmentByCSSSelectorByUrl(string sourceUrl, string selector, string outFormat)
        {
            return DocumentApiImpl.GetDocumentFragmentByCSSSelectorByUrl(sourceUrl, selector, outFormat);
        }

        /// <summary>
        /// Returns list of HTML fragments in the document matching the specified XPath query.  
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="xPath">XPath query string.</param>
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>StreamResponse | Stream containing the requested fragments</returns>
        public StreamResponse GetDocumentFragmentByXPath(string name, string xPath, string outFormat, string storage, string folder)
        {
            return DocumentApiImpl.GetDocumentFragmentByXPath(name, xPath, outFormat, storage, folder);
        }

        /// <summary>
        /// Returns list of HTML fragments in the Web page by its URL matching the specified XPath query.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <param name="xPath">XPath query string.</param>
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; ancontainingd &#39;json&#39;.</param>
        /// <returns>StreamResponse | Response object  MemoryStream with the requested fragments</returns>
        public StreamResponse GetDocumentFragmentByXPathByUrl(string sourceUrl, string xPath, string outFormat)
        {
            return DocumentApiImpl.GetDocumentFragmentByXPathByUrl(sourceUrl, xPath, outFormat);
        }

        /// <summary>
        /// Returns all images from the HTML document packaged as a ZIP archive. 
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>StreamResponse | Response object containing MemoryStream with the ZIP archive of all images.</returns>
        public StreamResponse GetDocumentImages(string name, string storage, string folder)
        {
            return DocumentApiImpl.GetDocumentImages(name, storage, folder);
        }

        /// <summary>
        /// Returns all HTML document images packaged as a ZIP archive by Web page URL.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <returns></returns>
        public StreamResponse GetDocumentImagesByUrl(string sourceUrl)
        {
            return DocumentApiImpl.GetDocumentImagesByUrl(sourceUrl);
        }
        #endregion

        #region IImportApi interface implementation

        public StreamResponse GetImportMarkdownToHtml(string name, string folder = null, string storage = null)
        {
            return ImportApiImpl.GetImportMarkdownToHtml(name, folder, storage);
        }

        public AsposeResponse PutImportMarkdownToHtml(string name, string outPath, string folder = null, string storage = null)
        {
            return ImportApiImpl.PutImportMarkdownToHtml(name, outPath, folder, storage);
        }

        public AsposeResponse PostImportMarkdownToHtml(Stream inStream, string outPath, string storage = null)
        {
            return ImportApiImpl.PostImportMarkdownToHtml(inStream, outPath, storage);
        }

        public AsposeResponse PostImportMarkdownToHtml(string localFilePath, string outPath, string storage = null)
        {
            return ImportApiImpl.PostImportMarkdownToHtml(localFilePath, outPath, storage);
        }

        #endregion

        #region IConversionApi interface implementation

        /// <summary>
        /// Converts the HTML document (located on storage) to the specified image format and returns resulting file in the response content.
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
        /// <returns>StreamResponse | Stream of the resulting image.</returns>
        public StreamResponse GetConvertDocumentToImage(string name, string outFormat, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.GetConvertDocumentToImage(name, outFormat, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, folder, storage);
        }

        /// <summary>
        /// Converts the HTML page (located in the Web by its URL) to the specified image format and returns resulting file in the response content.
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
        /// <returns>StreamResponse | Stream of the resulting image.</returns>
        public StreamResponse GetConvertDocumentToImageByUrl(string sourceUrl, string outFormat, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null)
        {
            return ConversionApiImpl.GetConvertDocumentToImageByUrl(sourceUrl, outFormat, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution);
        }

        /// <summary>
        /// Converts the HTML document (located on storage) to Markdown and returns resulting file in the response content.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="useGit">Use Git flavor of Markdown.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source document storage</param>
        /// <returns>StreamResponse | Stream of the resulting Markdown document.</returns>
        public StreamResponse GetConvertDocumentToMarkdown(string name, bool? useGit = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.GetConvertDocumentToMarkdown(name, useGit, folder, storage);
        }

        /// <summary>
        /// Converts the HTML page (located in the Web by its URL) to MHTML and returns resulting file in the response content. 
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <returns>StreamResponse | Stream of the resulting MHTML document.</returns>
        public StreamResponse GetConvertDocumentToMHTMLByUrl(string sourceUrl)
        {
            return ConversionApiImpl.GetConvertDocumentToMHTMLByUrl(sourceUrl);
        }

        /// <summary>
        /// Converts the HTML document (located on storage) to PDF and returns resulting file in the response content.
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
        /// <returns>StreamResponse | Stream of the resulting PDF document.</returns>
        public StreamResponse GetConvertDocumentToPdf(string name, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.GetConvertDocumentToPdf(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        }

        /// <summary>
        /// Converts the HTML page (located in the Web by its URL) to PDF and returns resulting file in the response content.
        /// </summary>
        /// <param name="sourceUrl">The source page URL.</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top image document page.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <returns>StreamResponse | Stream of the resulting PDF document.</returns>
        public StreamResponse GetConvertDocumentToPdfByUrl(string sourceUrl, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null)
        {
            return ConversionApiImpl.GetConvertDocumentToPdfByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin);
        }

        /// <summary>
        /// Converts the HTML document (located on storage) to XPS and returns resulting file in the response content.
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
        /// <returns>StreamResponse | Stream of the resulting XPS document.</returns>
        public StreamResponse GetConvertDocumentToXps(string name, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.GetConvertDocumentToXps(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        }

        /// <summary>
        /// Converts the HTML page (located in the Web by its URL) to XPS and returns resulting file in the response content. 
        /// </summary>
        /// <param name="sourceUrl">The source page URL.</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <returns>StreamResponse | Stream of the resulting XPS document.</returns>
        public StreamResponse GetConvertDocumentToXpsByUrl(string sourceUrl, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null)
        {
            return ConversionApiImpl.GetConvertDocumentToXpsByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin);
        }

        /// <summary>
        /// Converts the HTML document stream to the specified image format and uploads resulting file to the storage.
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
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PostConvertDocumentToImage(Stream inStream, string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToImage(inStream, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage);
        }

        /// <summary>
        ///  Converts the HTML document stream to Markdown and uploads resulting file to the storage.
        /// </summary>
        /// <param name="inStream">Source document stream.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.md</param>
        /// <param name="useGit">Use Git flavor of Markdown</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PostConvertDocumentToMarkdown(Stream inStream, string outPath, bool? useGit = false, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToMarkdown(inStream, outPath, useGit, storage);
        }

        /// <summary>
        /// Converts the HTML document stream to PDF and uploads resulting file to the storage.
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
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PostConvertDocumentToPdf(Stream inStream, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToPdf(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
        }

        /// <summary>
        /// Converts the HTML document stream to XPS and uploads resulting file to the storage.
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
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PostConvertDocumentToXps(Stream inStream, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToXps(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
        }

        /// <summary>
        /// Converts the HTML document (located in the local file system) to specified output format and uploads resulting file to the storage.
        /// </summary>
        /// <param name="localFilePath"></param>
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
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PostConvertDocumentToImage(string localFilePath, string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToImage(localFilePath, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage); 
        }

        /// <summary>
        /// Converts the HTML document (located in the local file system) to PDF and uploads resulting file to the storage.
        /// </summary>
        /// <param name="localFilePath">The local file system path to source document.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.pdf</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="storage">Resulting document storage</param>
        /// <returns>AsposeResponse | Response status.</returns>
        /// <returns></returns>
        public AsposeResponse PostConvertDocumentToPdf(string localFilePath, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToPdf(localFilePath, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage); 
        }

        /// <summary>
        /// Converts the HTML document (located in the local file system) to XPS and uploads resulting file to the storage.
        /// </summary>
        /// <param name="localFilePath">The local file system path to source document.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.xps</param>
        /// <param name="width">Resulting document page width. </param>
        /// <param name="height">Resulting document page height. </param>
        /// <param name="leftMargin">Left document page margin.</param>
        /// <param name="rightMargin">Right document page margin.</param>
        /// <param name="topMargin">Top document page margin.</param>
        /// <param name="bottomMargin">Bottom document page margin.</param>
        /// <param name="storage">Resulting document storage</param>
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PostConvertDocumentToXps(string localFilePath, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToXps(localFilePath, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
        }

        /// <summary>
        /// Converts the HTML document (located in the local file system) to PDF and uploads resulting file to the storage.
        /// </summary>
        /// <param name="localFilePath">The local file system path to source document.</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.md</param>
        /// <param name="useGit">Use Git flavor of Markdown</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PostConvertDocumentToMarkdown(string localFilePath, string outPath, bool? useGit = false, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToMarkdown(localFilePath, outPath, useGit, storage);
        }

        /// <summary>
        /// Converts the HTML document (located on storage) to the specified image format and uploads resulting file to the storage.
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
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PutConvertDocumentToImage(string name, string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.PutConvertDocumentToImage(name, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, folder, storage);
        }

        /// <summary>
        /// Converts the HTML document (located on storage) to Markdown and uploads resulting file to the storage.
        /// </summary>
        /// <param name="name">The source file name</param>
        /// <param name="outPath">The path to resulting file; like this: [/Folder1][/Folder2]/Filename.md</param>
        /// <param name="useGit">Use Git flavor of Markdown.</param>
        /// <param name="folder">Source document folder</param>
        /// <param name="storage">Source and resulting document storage</param>
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PutConvertDocumentToMarkdown(string name, string outPath, bool? useGit = false, string folder = null, string storage = null)
        {
            return ConversionApiImpl.PutConvertDocumentToMarkdown(name, outPath, useGit, folder, storage);
        }

        /// <summary>
        /// Converts the HTML document (located on storage) to PDF and uploads resulting file to the storage.
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
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PutConvertDocumentToPdf(string name, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.PutConvertDocumentToPdf(name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        }

        /// <summary>
        /// Converts the HTML document (located on storage) to XPS and uploads resulting file to the storage.
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
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PutConvertDocumentToXps(string name, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.PutConvertDocumentToXps(name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        }

        #endregion

        #region IOcrApi interface implementation

        /// <summary>
        /// Recognizes text content from the source image file by its name from default or specified storage, and creates an HTML document.
        /// </summary>
        /// <param name="name">String | Document name.</param>
        /// <param name="engineLang">String | Optional. OCR engine language. </param>
        /// <param name="folder">String | Optional. The document folder.</param>
        /// <param name="storage">String | Optional. The document storage.</param>
        /// <returns>StreamResponse |  Stream of resulting document. </returns>
        public StreamResponse GetRecognizeAndImportToHtml(string name, string engineLang = "en", string folder = null, string storage = null)
        {
            return OcrApiImpl.GetRecognizeAndImportToHtml(name, engineLang, folder, storage);
        }

        /// <summary>
        /// Recognizes text content from the source image file by its name from default or specified storage, and creates an HTML document translated to the specified language.
        /// </summary>
        /// <param name="name">String | Document name.</param>
        /// <param name="srcLang">String | Source language (considered as OCR engine language too).</param>
        /// <param name="resLang">String | Result language.</param>
        /// <param name="folder">String | Optional. The document folder.</param>
        /// <param name="storage">String | Optional. The document storage.</param>
        /// <returns>StreamResponse |  Stream of resulting document.</returns>
        public StreamResponse GetRecognizeAndTranslateToHtml(string name, string srcLang, string resLang, string folder = null, string storage = null)
        {
            return OcrApiImpl.GetRecognizeAndTranslateToHtml(name, srcLang, resLang, folder, storage);
        }
        #endregion

        #region ITranslationApi interface implementation

        /// <summary>
        /// Translates the HTML document specified by the name from default or specified storage. 
        /// </summary>
        /// <param name="name">Document name.</param>
        /// <param name="srcLang">Source language.</param>
        /// <param name="resLang">Result language.</param>
        /// <param name="folder">The document folder.</param>
        /// <param name="storage">The document storage.</param>
        /// <returns>AsposeStreamResponse | Stream of resulting document.</returns>
        public StreamResponse GetTranslateDocument(string name, string srcLang, string resLang, string folder = null, string storage = null)
        {
            return TranslationApiImpl.GetTranslateDocument(name, srcLang, resLang, folder, storage);
        }

        /// <summary>
        /// Translates the HTML document specified by its URL. 
        /// </summary>
        /// <param name="sourceUrl">Source document URL.</param>
        /// <param name="srcLang">Source language.</param>
        /// <param name="resLang">Result language.</param>
        /// <returns>AsposeStreamResponse | Stream of resulting document.</returns>
        public StreamResponse GetTranslateDocumentByUrl(string sourceUrl, string srcLang, string resLang)
        {
            return TranslationApiImpl.GetTranslateDocumentByUrl(sourceUrl, srcLang, resLang);
        }

        #endregion


        #region ITemplateMergeApi interface implementation
        /// <summary>
        /// Populates HTML document template with data located as a file in the storage.
        /// </summary>
        /// <param name="templateName">Template document name. Template document is HTML or zipped HTML. Template location is /{folder}/{templateName}.</param>
        /// <param name="dataPath">Data source file path in the storage. Supported data format: XML.</param>
        /// <param name="options">Template merge options: reserved for further implementation.</param>
        /// <param name="folder">The template document folder.</param>
        /// <param name="storage">The template document and data source storage.</param>
        /// <returns>StreamResponse | Stream containing the generated document.</returns>
        public StreamResponse GetMergeHtmlTemplate(string templateName, string dataPath, string options = null, string folder = null, string storage = null)
        {
            return TemplateMergeImpl.GetMergeHtmlTemplate(templateName, dataPath, options, folder, storage);
        }

        /// <summary>
        /// Populates HTML document template with data from the stream. Result document will be saved to storage.
        /// </summary>
        /// <param name="templateName">Template document name. Template document is HTML or zipped HTML. Template location is /{folder}/{templateName}.</param>
        /// <param name="inStream">Data source stream. Supported data format: XML.</param>
        /// <param name="outPath">Result document path in the storage.</param>
        /// <param name="options">Template merge options: reserved for further implementation.</param>
        /// <param name="folder">The template document folder.</param>
        /// <param name="storage">Optional. The template document and data source storage.</param>
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PostMergeHtmlTemplate(string templateName, Stream inStream, string outPath, string options = null, string folder = null, string storage = null)
        {
            return TemplateMergeImpl.PostMergeHtmlTemplate(templateName, inStream, outPath, options, folder, storage);
        }

        /// <summary>
        /// Populates HTML document template with data from the local file system. Result document will be saved to storage.
        /// </summary>
        /// <param name="templateName">Template document name. Template document is HTML or zipped HTML. Template location is /{folder}/{templateName}.</param>
        /// <param name="localDataFilePath">The local file system path to data file.</param>
        /// <param name="outPath">Result document path in the storage.</param>
        /// <param name="options">Template merge options: reserved for further implementation.</param>
        /// <param name="folder">The template document folder.</param>
        /// <param name="storage">Optional. The template document and data source storage.</param>
        /// <returns>AsposeResponse | Response status.</returns>
        public AsposeResponse PostMergeHtmlTemplate(string templateName, string localDataFilePath, string outPath, string options = null, string folder = null, string storage = null)
        {
            return TemplateMergeImpl.PostMergeHtmlTemplate(templateName, localDataFilePath, outPath, options, folder, storage);
        }

        #endregion

        #region ISummarizationApi interface implementation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public StreamResponse GetDetectHtmlKeywords(string name, string folder = null, string storage = null)
        {
            return SummarizationApiImpl.GetDetectHtmlKeywords(name, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <returns></returns>
        public StreamResponse GetDetectHtmlKeywordsByUrl(string sourceUrl)
        {
            return SummarizationApiImpl.GetDetectHtmlKeywordsByUrl(sourceUrl);
        }

        #endregion
    }
}
