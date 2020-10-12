using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Aspose.HTML.Cloud.Sdk.Runtime
{
    public class RequestUrlBuilder
    {
        private Dictionary<string, string> queryParams = new Dictionary<string, string>();


        private string UrlPath { get; set; }

        RequestUrlBuilder()
        {
        }

        public static RequestUrlBuilder GetBuilder(string urlPath)
        {
            return new RequestUrlBuilder() { UrlPath = urlPath };
        }

        public static RequestUrlBuilder GetBuilder(Uri urlPath)
        {
            return new RequestUrlBuilder() { UrlPath = urlPath.OriginalString };
        }


        public RequestUrlBuilder WithPath(string path)
        {
            return WithParameter("path", path, true);
        }

        public RequestUrlBuilder WithStorageName(string storageName)
        {
            return WithParameter("storageName", storageName, true);
        }

        public RequestUrlBuilder WithSourcePath(string srcPath)
        {
            return WithParameter("srcPath", srcPath, true);
        }

        public RequestUrlBuilder WithDestinationPath(string destPath)
        {
            return WithParameter("destPath", destPath, true);
        }

        public RequestUrlBuilder WithSourceStorage(string srcStorageName)
        {
            return WithParameter("srcStorageName", srcStorageName, true);
        }

        public RequestUrlBuilder WithDestinationStorage(string destStorageName)
        {
            return WithParameter("destStorageName", destStorageName, true);
        }



        public RequestUrlBuilder WithParameter(string paramName, string paramValue, bool urlEncode = false)
        {
            if (string.IsNullOrEmpty(paramValue))
                return this; 

            var value = !urlEncode ? paramValue : WebUtility.UrlEncode(paramValue);
            if (queryParams.ContainsKey(paramName))
                queryParams[paramName] = value;
            else
                queryParams.Add(paramName, value);

            return this;
        }

        public RequestUrlBuilder WithParameter(string paramName, int paramValue)
        {
            return WithParameter(paramName, paramValue.ToString(), false);
        }

        public RequestUrlBuilder WithParameter(string paramName, Guid paramValue, string guidFormat = "D")
        {
            return WithParameter(paramName, paramValue.ToString(guidFormat), false);
        }

        public RequestUrlBuilder WithParameter(string paramName, DateTime paramValue, string timeFormat = "o")
        {
            return WithParameter(paramName, paramValue.ToString(timeFormat), true);
        }

        public string Build()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(UrlPath);

            if (queryParams.Count > 0)
            {
                int i = 0;
                foreach (var key in queryParams.Keys)
                {
                    sb.Append(i++ == 0 ? "?" : "&");
                    sb.Append($"{key}={queryParams[key]}");
                }
            }
            return sb.ToString();
        }


    }
}
