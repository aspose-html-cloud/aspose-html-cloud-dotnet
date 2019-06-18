// --------------------------------------------------------------------------------------------------------------------
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

namespace Aspose.Html.Cloud.Sdk.Api
{
    /// <summary>
    /// Facade class providing wrapper methods of Aspose.Html Cloud REST API
    /// </summary>
    public class HtmlApi : ApiBase,
        IDocumentApi,
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

        #endregion

        #region Public Constructors

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
        public AsposeStreamResponse GetDocumentByUrl(string sourceUrl)
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
        /// <returns>AsposeStreamResponse | Response object containing MemoryStream with the requested fragments</returns>
        public AsposeStreamResponse GetDocumentFragmentByCSSSelector(string name, string selector, string outFormat, string storage, string folder)
        {
            return DocumentApiImpl.GetDocumentFragmentByCSSSelector(name, selector, outFormat, storage, folder);
        }

        /// <summary>
        /// Returns list of HTML fragments  in the Web page by its URL matching the specified CSS selector.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <param name="selector">CSS selector string.</param>
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param>
        /// <returns>AsposeStreamResponse | Response object containing MemoryStream with the requested fragments</returns>
        public AsposeStreamResponse GetDocumentFragmentByCSSSelectorByUrl(string sourceUrl, string selector, string outFormat)
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
        /// <returns>AsposeStreamResponse | Stream containing the requested fragments</returns>
        public AsposeStreamResponse GetDocumentFragmentByXPath(string name, string xPath, string outFormat, string storage, string folder)
        {
            return DocumentApiImpl.GetDocumentFragmentByXPath(name, xPath, outFormat, storage, folder);
        }

        /// <summary>
        /// Returns list of HTML fragments in the Web page by its URL matching the specified XPath query.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <param name="xPath">XPath query string.</param>
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; ancontainingd &#39;json&#39;.</param>
        /// <returns>AsposeStreamResponse | Response object  MemoryStream with the requested fragments</returns>
        public AsposeStreamResponse GetDocumentFragmentByXPathByUrl(string sourceUrl, string xPath, string outFormat)
        {
            return DocumentApiImpl.GetDocumentFragmentByXPathByUrl(sourceUrl, xPath, outFormat);
        }

        /// <summary>
        /// Returns all images from the HTML document packaged as a ZIP archive. 
        /// </summary>
        /// <param name="name">The document name.</param>
        /// <param name="storage">The document storage.</param>
        /// <param name="folder">The document folder.</param>
        /// <returns>AsposeStreamResponse | Response object containing MemoryStream with the ZIP archive of all images.</returns>
        public AsposeStreamResponse GetDocumentImages(string name, string storage, string folder)
        {
            return DocumentApiImpl.GetDocumentImages(name, storage, folder);
        }

        /// <summary>
        /// Returns all HTML document images packaged as a ZIP archive by Web page URL.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <returns></returns>
        public AsposeStreamResponse GetDocumentImagesByUrl(string sourceUrl)
        {
            return DocumentApiImpl.GetDocumentImagesByUrl(sourceUrl);
        }
        #endregion

        #region IConversionApi interface implementation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="outFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="resolution"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetConvertDocumentToImage(string name, string outFormat, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.GetConvertDocumentToImage(name, outFormat, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <param name="outFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="resolution"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetConvertDocumentToImageByUrl(string sourceUrl, string outFormat, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null)
        {
            return ConversionApiImpl.GetConvertDocumentToImageByUrl(sourceUrl, outFormat, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="useGit"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetConvertDocumentToMarkdown(string name, bool? useGit = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.GetConvertDocumentToMarkdown(name, useGit, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetConvertDocumentToMHTMLByUrl(string sourceUrl)
        {
            return ConversionApiImpl.GetConvertDocumentToMHTMLByUrl(sourceUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetConvertDocumentToPdf(string name, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.GetConvertDocumentToPdf(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetConvertDocumentToPdfByUrl(string sourceUrl, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null)
        {
            return ConversionApiImpl.GetConvertDocumentToPdfByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetConvertDocumentToXps(string name, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.GetConvertDocumentToXps(name, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetConvertDocumentToXpsByUrl(string sourceUrl, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null)
        {
            return ConversionApiImpl.GetConvertDocumentToXpsByUrl(sourceUrl, width, height, leftMargin, rightMargin, topMargin, bottomMargin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inStream"></param>
        /// <param name="outFormat"></param>
        /// <param name="outPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="resolution"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeResponse PostConvertDocumentToImage(Stream inStream, string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToImage(inStream, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inStream"></param>
        /// <param name="outPath"></param>
        /// <param name="useGit"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeResponse PostConvertDocumentToMarkdown(Stream inStream, string outPath, bool? useGit = false, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToMarkdown(inStream, outPath, useGit, storage);
        }

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
        /// <returns></returns>
        public AsposeResponse PostConvertDocumentToPdf(Stream inStream, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToPdf(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
        }

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
        /// <returns></returns>
        public AsposeResponse PostConvertDocumentToXps(Stream inStream, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            return ConversionApiImpl.PostConvertDocumentToXps(inStream, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="outFormat"></param>
        /// <param name="outPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="resolution"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeResponse PutConvertDocumentToImage(string name, string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.PutConvertDocumentToImage(name, outFormat, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, resolution, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="outPath"></param>
        /// <param name="useGit"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeResponse PutConvertDocumentToMarkdown(string name, string outPath, bool? useGit = false, string folder = null, string storage = null)
        {
            return ConversionApiImpl.PutConvertDocumentToMarkdown(name, outPath, useGit, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="outPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeResponse PutConvertDocumentToPdf(string name, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.PutConvertDocumentToPdf(name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="outPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="leftMargin"></param>
        /// <param name="rightMargin"></param>
        /// <param name="topMargin"></param>
        /// <param name="bottomMargin"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeResponse PutConvertDocumentToXps(string name, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string folder = null, string storage = null)
        {
            return ConversionApiImpl.PutConvertDocumentToXps(name, outPath, width, height, leftMargin, rightMargin, topMargin, bottomMargin, folder, storage);
        }

        #endregion

        #region IOcrApi interface implementation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="engineLang"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetRecognizeAndImportToHtml(string name, string engineLang = "en", string folder = null, string storage = null)
        {
            return OcrApiImpl.GetRecognizeAndImportToHtml(name, engineLang, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="srcLang"></param>
        /// <param name="resLang"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetRecognizeAndTranslateToHtml(string name, string srcLang, string resLang, string folder = null, string storage = null)
        {
            return OcrApiImpl.GetRecognizeAndTranslateToHtml(name, srcLang, resLang, folder, storage);
        }
        #endregion

        #region ITranslationApi interface implementation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="srcLang"></param>
        /// <param name="resLang"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetTranslateDocument(string name, string srcLang, string resLang, string folder = null, string storage = null)
        {
            return TranslationApiImpl.GetTranslateDocument(name, srcLang, resLang, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <param name="srcLang"></param>
        /// <param name="resLang"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetTranslateDocumentByUrl(string sourceUrl, string srcLang, string resLang)
        {
            return TranslationApiImpl.GetTranslateDocumentByUrl(sourceUrl, srcLang, resLang);
        }

        #endregion


        #region ITemplateMergeApi interface implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="dataPath"></param>
        /// <param name="options"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetMergeHtmlTemplate(string templateName, string dataPath, string options = null, string folder = null, string storage = null)
        {
            return TemplateMergeImpl.GetMergeHtmlTemplate(templateName, dataPath, options, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="inStream"></param>
        /// <param name="outPath"></param>
        /// <param name="options"></param>
        /// <param name="folder"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public AsposeResponse PostMergeHtmlTemplate(string templateName, Stream inStream, string outPath, string options = null, string folder = null, string storage = null)
        {
            return TemplateMergeImpl.PostMergeHtmlTemplate(templateName, inStream, outPath, options, folder, storage);
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
        public AsposeStreamResponse GetDetectHtmlKeywords(string name, string folder = null, string storage = null)
        {
            return SummarizationApiImpl.GetDetectHtmlKeywords(name, folder, storage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <returns></returns>
        public AsposeStreamResponse GetDetectHtmlKeywordsByUrl(string sourceUrl)
        {
            return SummarizationApiImpl.GetDetectHtmlKeywordsByUrl(sourceUrl);
        }
        #endregion
    }
}
