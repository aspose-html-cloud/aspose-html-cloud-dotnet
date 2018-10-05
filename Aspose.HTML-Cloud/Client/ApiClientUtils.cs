// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiClientUtils.cs">
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
//using Com.Aspose.Html.Client;


namespace Aspose.Html.Cloud.Sdk.Client
{
    public static class ApiClientUtils
    {
        private static Dictionary<string, string> s_mimeTypes = new Dictionary<string, string>();

        /// <summary>
        /// Static constructor
        /// </summary>
        static ApiClientUtils()
        {
            s_mimeTypes.Add("pdf", "application/pdf");
            s_mimeTypes.Add("xps", "application/vnd.ms-xpsdocument");
            s_mimeTypes.Add("jpeg", "image/jpeg");
            s_mimeTypes.Add("bmp", "image/bmp");
            s_mimeTypes.Add("png", "image/png");
            s_mimeTypes.Add("tiff", "image/tiff");
            //
            s_mimeTypes.Add("zip", "application/zip");
            s_mimeTypes.Add("json", "application/json");
        }


        public static string GetMimeType(string format)
        {
            if (s_mimeTypes.ContainsKey(format.ToLowerInvariant()))
                return s_mimeTypes[format.ToLowerInvariant()];
            else
                return null;
        }

        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with Configuration.DateTime.
        /// If parameter is a list of string, join the list with ",".
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public static string ParameterToString(object obj)
        {
            if (obj is DateTime)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTime)obj).ToString(Configuration.DateTimeFormat);
            else if (obj is List<string>)
                return String.Join(",", (obj as List<string>).ToArray());
            else
                return Convert.ToString(obj);
        }


        public static string GetTempDirectory(string basePath = null)
        {
            if(basePath == null)
            {
                basePath = Path.GetTempPath();
            }
            DateTime dt = DateTime.Now;
            string subDir = string.Format("{0}.{1}.{2}_{3}:{4}:{5}", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            string path = Path.Combine(basePath, subDir);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
    }
}
