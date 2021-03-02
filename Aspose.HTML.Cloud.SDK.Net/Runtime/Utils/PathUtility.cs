// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="PathUtility.cs">
//   Copyright (c) 2020 Aspose.HTML Cloud
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
using System.Linq;
using System.IO;
using System.Text;
using Newtonsoft.Json;


namespace Aspose.HTML.Cloud.Sdk.Runtime.Utils
{
    /// <summary>
    /// Utility class that is used to build and parse file or directory paths.
    /// </summary>
    public class PathUtility
    {
        /// <summary>
        /// Path parsing result.
        /// </summary>
        public class ParseResult
        {
            /// <summary>
            /// Protocol path prefix. Allowed values are: http, https, storage, app, or empty.
            /// </summary>
            [JsonProperty("protocol")]
            public string Protocol { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// Storage name is Protocol=storage
            /// </summary>
            [JsonProperty("storage_name")]
            public string StorageName { get; set; }

            /// <summary>
            /// Folder path in the storage, or URL path if Protocol is http or https.
            /// </summary>
            [JsonProperty("folder")]
            public string Folder { get; set; }

            /// <summary>
            /// File name, if the path has been parsed as file path.
            /// </summary>
            [JsonProperty("file_name")]
            public string FileName { get; set; }

            /// <summary>
            /// File format, if the path has been parsed as file path.
            /// </summary>
            [JsonProperty("file_format")]
            public string FileFormat { get; set; }

            [JsonProperty("path")]
            public string Path { get; set; }
        }


        private const string PR_HTTP = "http";
        private const string PR_HTTPS = "https";
        private const string PR_STORAGE = "storage";
        private const string PR_APP = "app";

        private static string[] Protocols = new string[] { PR_HTTP, PR_HTTPS, PR_STORAGE, PR_APP };

        /// <summary>
        /// Parses a path to elements.
        /// </summary>
        /// <param name="path">Path to be parsed.</param>
        /// <param name="asFolder">Treat as a folder path if true. Default is to consider a path as a file path.</param>
        /// <returns>ParseResult object. Represents the path elements.</returns>
        public static ParseResult Parse(string path, bool asFolder = false)
        {
            try
            {
                ParseResult res;
                Uri uri = new Uri(path);
                if(uri.IsAbsoluteUri)
                {
                    var fileName = asFolder ? "" : uri.Segments.Last();
                    var fileFormat = asFolder ? "" : Path.GetExtension(fileName).Replace(".", "");
                    var folder = asFolder ? uri.AbsolutePath : 
                        (uri.Segments.Length <= 2 ? "/" : string.Join("/", uri.Segments, 1, uri.Segments.Length - 2));
                    
                    var protocol = uri.Scheme.ToLowerInvariant().Replace(":", "");
                    if(Protocols.Contains(protocol))
                    {
                        switch (protocol)
                        {
                            case PR_STORAGE:
                            case PR_APP:
                                return new ParseResult() {
                                    Protocol = protocol,
                                    Url = uri.OriginalString,
                                    StorageName = uri.Host,
                                    Path = uri.AbsolutePath,
                                    Folder = folder,
                                    FileName = fileName,
                                    FileFormat = fileFormat
                                };
                            case PR_HTTP:
                            case PR_HTTPS:
                                return new ParseResult() {
                                    Protocol = protocol,
                                    Url = uri.OriginalString,
                                    StorageName = "",
                                    FileName = fileName,
                                    FileFormat = fileFormat
                                };
                            default:
                                break;
                        }
                    }
                    else
                    {
                        return new ParseResult() {
                            Protocol = "storage",
                            StorageName = "",
                            Path = uri.AbsolutePath,
                            Folder = folder,
                            FileName = fileName,
                            FileFormat = fileFormat
                        };
                    }

                }
            }
            catch(Exception ex)
            {
                throw new ApiException(500, "Error trying to parse a path string", ex);
            }
            return null;
        }

        /// <summary>
        /// Builds a full path with path elements.
        /// </summary>
        /// <param name="protocol">Protocol. Allowed values are: http, https, storage, app</param>
        /// <param name="host">If protocol is http or https, should be Web resource host. If protocol is storage, specifies a storage name, can be empty for default storage. If protocol is app, must be empty. </param>
        /// <param name="folder">Folder path, or web resource path after the host.</param>
        /// <param name="filename">File name. Optional.</param>
        /// <returns></returns>
        public static string BuildPath(string protocol, string host, string folder, string filename = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{protocol}://");
            sb.Append(host);

            if (!folder.StartsWith("/"))
                sb.Append("/");
            sb.Append(folder);
            if (!string.IsNullOrEmpty(filename))
                sb.Append(filename);

            return sb.ToString();
        }

        /// <summary>
        /// Gets folder path from the file path.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFolderPath(string filePath)
        {
            Uri uri;
            if(!Uri.TryCreate(filePath, UriKind.Absolute, out uri))
            {
                var fname = Path.GetFileName(filePath);
                var pos = filePath.LastIndexOf(fname);
                var dirPath = filePath.Substring(0, pos);
                if (dirPath == "/")
                    return dirPath;
                else if (dirPath.LastIndexOf('/') == dirPath.Length - 1)
                    dirPath = dirPath.Substring(0, dirPath.Length - 1);

                return dirPath;
            }
            var folder = uri.Segments.Length <= 2 
                ? "/" 
                : string.Join("/", uri.Segments, 1, uri.Segments.Length - 2);

            return folder;
        }

    }
}
