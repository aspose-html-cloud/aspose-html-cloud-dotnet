using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Html.Cloud.Sdk.Api.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class MimeHelper
    {
        #region Static members

        private static readonly Dictionary<string, Tuple<string, string>> s_mimeTypes = new Dictionary<string, Tuple<string, string>>();

        private static readonly Dictionary<string, string> m_extToTypeMap = new Dictionary<string, string>();

        static MimeHelper()
        {
            s_mimeTypes.Add("pdf", new Tuple<string, string>("application/pdf", "pdf"));
            s_mimeTypes.Add("xps", new Tuple<string, string>("application/vnd.ms-xpsdocument", "xps"));
            s_mimeTypes.Add("jpeg", new Tuple<string, string>("image/jpeg", "jpg"));
            s_mimeTypes.Add("bmp", new Tuple<string, string>("image/bmp", "bmp"));
            s_mimeTypes.Add("png", new Tuple<string, string>("image/png", "png"));
            s_mimeTypes.Add("gif", new Tuple<string, string>("image/gif", "gif"));
            s_mimeTypes.Add("tiff", new Tuple<string, string>("image/tiff", "tif"));
            s_mimeTypes.Add("md", new Tuple<string, string>("text/markdown", "md"));
            s_mimeTypes.Add("mhtml", new Tuple<string, string>("multipart/related", "mht"));

            s_mimeTypes.Add("zip", new Tuple<string, string>("application/zip", "zip"));
            s_mimeTypes.Add("html", new Tuple<string, string>("text/html", "html"));
            s_mimeTypes.Add("epub", new Tuple<string, string>("application/epub+zip", "epub"));
            s_mimeTypes.Add("svg", new Tuple<string, string>("image/svg+xml", "svg"));

            s_mimeTypes.Add("xml", new Tuple<string, string>("application/xml", "xml"));
            s_mimeTypes.Add("json", new Tuple<string, string>("application/json", "json"));


            m_extToTypeMap.Add("pdf", "pdf");
            m_extToTypeMap.Add("xps", "xps");
            m_extToTypeMap.Add("jpeg", "jpeg");
            m_extToTypeMap.Add("jpg", "jpeg");
            m_extToTypeMap.Add("tiff", "tiff");
            m_extToTypeMap.Add("tif", "tiff");
            m_extToTypeMap.Add("gif", "gif");

            m_extToTypeMap.Add("html", "html");
            m_extToTypeMap.Add("htm", "html");
            m_extToTypeMap.Add("mht", "mhtml");
            m_extToTypeMap.Add("mhtml", "mhtml");

            m_extToTypeMap.Add("zip", "zip");
            m_extToTypeMap.Add("json", "json");
            m_extToTypeMap.Add("xml", "xml");
            m_extToTypeMap.Add("epub", "epub");
            m_extToTypeMap.Add("md", "md");
            m_extToTypeMap.Add("svg", "svg");
        }

        /// <summary>
        /// Returns MIME type corresponding to specified data format
        /// </summary>
        /// <param name="format">Data format</param>
        /// <returns>MIME type or null for unknown format</returns>
        public static string GetMimeType(string format)
        {
            if (s_mimeTypes.ContainsKey(format.ToLowerInvariant()))
                return s_mimeTypes[format.ToLowerInvariant()].Item1;
            else
                return null;
        }

        /// <summary>
        /// Returns file extension corresponding to specified data format 
        /// </summary>
        /// <param name="format">Data format</param>
        /// <returns>Extension or null for unknown format</returns>
        public static string GetExtension(string format)
        {
            if (s_mimeTypes.ContainsKey(format.ToLowerInvariant()))
                return s_mimeTypes[format.ToLowerInvariant()].Item2;
            else
                return null;
        }

        /// <summary>
        /// Returns file format by its extension.
        /// </summary>
        /// <param name="extension">File format or null for unknown extension.</param>
        /// <returns></returns>
        public static string GetFormatByExtension(string extension)
        {
            if (m_extToTypeMap.ContainsKey(extension.ToLowerInvariant()))
                return m_extToTypeMap[extension.ToLowerInvariant()];

            return null;
        }

        #endregion
    }
}
