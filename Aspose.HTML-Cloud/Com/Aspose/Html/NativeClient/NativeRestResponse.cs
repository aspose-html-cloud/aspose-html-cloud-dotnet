using System;
using System.IO;
using System.Net;


namespace Com.Aspose.Html.NativeClient
{
    [Obsolete]
    internal class NativeRestResponse
    {
        public enum RespContentType
        {
            FileName,
            Stream,
            Json,
            String
        }

        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string MimeType { get; set; }
        public RespContentType ContentType { get; set; }
        public object Content { get; set; }
        public string ContentName { get; set; }

        public Stream GetContentAsStream()
        {
            if(StatusCode == HttpStatusCode.OK && ContentType == RespContentType.Stream)
            {
                Stream stream = Content as Stream;
                return stream;
            }
            return null;
        }

        public void SaveContentAsFile(string outDir)
        {
            if (StatusCode == HttpStatusCode.OK && ContentType == RespContentType.Stream)
            {

            }
        }
    }
}
