using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

using RestSharp;

namespace Com.Aspose.Html.NativeClient
{
    public class NativeRestResponse
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
    }
}
