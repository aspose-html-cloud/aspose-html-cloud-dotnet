using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using RestSharp;
using Com.Aspose.Html.Client;
using Com.Aspose.Html.NativeClient;
using Com.Aspose.Html.Api.Interfaces;

namespace Com.Aspose.Html.Api
{
    public class OcrApi : IOcrApi
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionApi"/> class.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="apiSid">The api sid.</param>
        /// <param name="basePath">The base path.</param>
        public OcrApi(String apiKey, String apiSid, String basePath)
        {
            this.ApiClient = new ApiClient(apiKey, apiSid, basePath);
            this.NativeApiClient = new NativeApiClient(apiKey, apiSid, basePath);
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Gets or sets the API client for PUTs - workaround
        /// </summary>
        public NativeApiClient NativeApiClient { get; set; }

        #region IOcrApi implementation

        public Stream GetRecognizeAndImportToHtml(string name, string engineLang = "en", string folder = null, string storage = null)
        {
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetRecognizeAndImportToHtml");

            var path = "/html/{name}/ocr/import";
            path = path.Replace("{" + "name" + "}", ApiClient.ParameterToString(name));

            if (string.IsNullOrEmpty(engineLang)) engineLang = "en";

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (storage != null) queryParams.Add("storage", ApiClient.ParameterToString(storage)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClient.ParameterToString(folder)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling GetTranslateDocument: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling GetTranslateDocument: " + response.ErrorMessage, response.ErrorMessage);

            return (System.IO.Stream)ApiClient.Deserialize(response, typeof(System.IO.Stream));
            //return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);

        }

        public Stream GetRecognizeAndTranslateToHtml(string name, string srcLang, string resLang, string folder = null, string storage = null)
        {
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetRecognizeAndTranslateToHtml");
            // verify the required parameter 'srcLang' is set
            if (srcLang == null) throw new ApiException(400, "Missing required parameter 'srcLang' when calling GetRecognizeAndTranslateToHtml");

            // verify the required parameter 'resLang' is set
            if (resLang == null) throw new ApiException(400, "Missing required parameter 'resLang' when calling GetRecognizeAndTranslateToHtml");

            var path = "/html/{name}/ocr/translate/{srcLang}/{resLang}";
            path = path.Replace("{" + "name" + "}", ApiClient.ParameterToString(name));
            path = path.Replace("{" + "srcLang" + "}", ApiClient.ParameterToString(srcLang));
            path = path.Replace("{" + "resLang" + "}", ApiClient.ParameterToString(resLang));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (storage != null) queryParams.Add("storage", ApiClient.ParameterToString(storage)); // query parameter
            if (folder != null) queryParams.Add("folder", ApiClient.ParameterToString(folder)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling GetTranslateDocument: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling GetTranslateDocument: " + response.ErrorMessage, response.ErrorMessage);

            return (System.IO.Stream)ApiClient.Deserialize(response, typeof(System.IO.Stream));
            //return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        }

        #endregion
    }
}
