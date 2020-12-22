

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Newtonsoft.Json;


namespace Aspose.HTML.Cloud.Sdk.Runtime.Utils
{
    public class PathUtility
    {
        public class ParseResult
        {
            [JsonProperty("protocol")]
            public string Protocol { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("storage_name")]
            public string StorageName { get; set; }

            [JsonProperty("folder")]
            public string Folder { get; set; }

            [JsonProperty("file_name")]
            public string FileName { get; set; }

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
