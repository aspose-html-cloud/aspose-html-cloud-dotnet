using System;
using System.Text;
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
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TranslationApi : ITranslationApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlDocumentTranslationApi"/> class.
        /// </summary>
		/// <param name="apiKey">The api key.</param>
		/// <param name="apiSid">The api sid.</param>
        /// <param name="basePath">The base path.</param>
        public TranslationApi(String apiKey, String apiSid, String basePath)
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
        public ApiClient ApiClient {get; set;}

        /// <summary>
        /// Gets or sets the API client for PUTs - workaround
        /// </summary>
        public NativeApiClient NativeApiClient { get; set; }

        /// <summary>
        /// Translate the HTML document specified by the name from default or specified storage. 
        /// </summary>
        /// <param name="name">Document name.</param> 
        /// <param name="srcLang">Source language.</param> 
        /// <param name="resLang">Result language.</param> 
        /// <param name="storage">The document storage.</param> 
        /// <param name="folder">The document folder.</param> 
        /// <returns>System.IO.Stream</returns>            
        public System.IO.Stream GetTranslateDocument (string name, string srcLang, string resLang, string folder = null, string storage = null)
        {
            
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetTranslateDocument");
            
            // verify the required parameter 'srcLang' is set
            if (srcLang == null) throw new ApiException(400, "Missing required parameter 'srcLang' when calling GetTranslateDocument");
            
            // verify the required parameter 'resLang' is set
            if (resLang == null) throw new ApiException(400, "Missing required parameter 'resLang' when calling GetTranslateDocument");
            
    
            var path = "/html/{name}/translate/{srcLang}/{resLang}";
            path = path.Replace("{format}", "json");
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
            String[] authSettings = new String[] {  };

             // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTranslateDocument: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTranslateDocument: " + response.ErrorMessage, response.ErrorMessage);

            return (System.IO.Stream)ApiClient.Deserialize(response, typeof(System.IO.Stream));
            //return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        }
    
        /// <summary>
        /// Translate the HTML document specified by its URL. 
        /// </summary>
        /// <param name="sourceUrl">Source document URL.</param> 
        /// <param name="srcLang">Source language.</param> 
        /// <param name="resLang">Result language.</param> 
        /// <returns>System.IO.Stream</returns>            
        public System.IO.Stream GetTranslateDocumentByUrl (string sourceUrl, string srcLang, string resLang)
        {
            
            // verify the required parameter 'sourceUrl' is set
            if (sourceUrl == null) throw new ApiException(400, "Missing required parameter 'sourceUrl' when calling GetTranslateDocumentByUrl");
            
            // verify the required parameter 'srcLang' is set
            if (srcLang == null) throw new ApiException(400, "Missing required parameter 'srcLang' when calling GetTranslateDocumentByUrl");
            
            // verify the required parameter 'resLang' is set
            if (resLang == null) throw new ApiException(400, "Missing required parameter 'resLang' when calling GetTranslateDocumentByUrl");
            
    
            var path = "/html/translate/{srcLang}/{resLang}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "srcLang" + "}", ApiClient.ParameterToString(srcLang));
            path = path.Replace("{" + "resLang" + "}", ApiClient.ParameterToString(resLang));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (sourceUrl != null) queryParams.Add("sourceUrl", ApiClient.ParameterToString(sourceUrl)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTranslateDocumentByUrl: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetTranslateDocumentByUrl: " + response.ErrorMessage, response.ErrorMessage);

            return (System.IO.Stream)ApiClient.Deserialize(response, typeof(System.IO.Stream));
            //return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        }

        #region REM
        ///// <summary>
        ///// Return the list of language pairs supported by the translator.  
        ///// </summary>
        ///// <returns>System.IO.Stream</returns>            
        //public System.IO.Stream HtmlDocumentTranslationGetTranslationSupportedLanguagePairs ()
        //{
        //    var path = "/html/translate/langpairs";
        //    path = path.Replace("{format}", "json");

        //    var queryParams = new Dictionary<String, String>();
        //    var headerParams = new Dictionary<String, String>();
        //    var formParams = new Dictionary<String, String>();
        //    var fileParams = new Dictionary<String, FileParameter>();
        //    String postBody = null;


        //    // authentication setting, if any
        //    String[] authSettings = new String[] {  };

        //    // make the HTTP request
        //    IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

        //    if (((int)response.StatusCode) >= 400)
        //        throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentTranslationGetTranslationSupportedLanguagePairs: " + response.Content, response.Content);
        //    else if (((int)response.StatusCode) == 0)
        //        throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentTranslationGetTranslationSupportedLanguagePairs: " + response.ErrorMessage, response.ErrorMessage);

        //    return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        //}
        #endregion

        /// <summary>
        /// Translate the HTML document specified by the name from default or specified storage. 
        /// </summary>
        /// <param name="name">Document name.</param> 
        /// <param name="srcLang">Source language.</param> 
        /// <param name="resLang">Result language.</param> 
        /// <param name="storage">The document storage.</param> 
        /// <param name="folder">The document folder.</param> 
        /// <returns>System.IO.Stream</returns>            
        public NativeRestResponse PutTranslateDocument (string name, string srcLang, string resLang, string folder = null, string storage = null)
        {
            
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling PutTranslateDocument");
            
            // verify the required parameter 'srcLang' is set
            if (srcLang == null) throw new ApiException(400, "Missing required parameter 'srcLang' when calling PutTranslateDocument");
            
            // verify the required parameter 'resLang' is set
            if (resLang == null) throw new ApiException(400, "Missing required parameter 'resLang' when calling PutTranslateDocument");
            
    
            var path = "/html/{name}/translate/{srcLang}/{resLang}";
            path = path.Replace("{format}", "json");
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
            String[] authSettings = new String[] {  };

            // make the HTTP request
            //IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            HttpResponseMessage resp = NativeApiClient.CallPut(path, queryParams);

            if (((int)resp.StatusCode) >= 400)
                throw new ApiException ((int)resp.StatusCode,
                    "Error calling PutTranslateDocument: " + resp.ReasonPhrase, resp.ReasonPhrase);
            else if (((int)resp.StatusCode) == 0)
                throw new ApiException ((int)resp.StatusCode,
                    "Error calling PutTranslateDocument: " + resp.ReasonPhrase, resp.ReasonPhrase);

            NativeRestResponse response = new NativeRestResponse()
            {
                StatusCode = resp.StatusCode,
                ContentType = NativeRestResponse.RespContentType.FileName,
                MimeType = (name.EndsWith(".zip") ? "application/zip"
                            : (name.EndsWith(".html") ? "text/html" : ""))
            };

            var hdrs = resp.Headers;
            if(hdrs.Contains("X_ResultFileName"))
            {
                IEnumerator<string> en = hdrs.GetValues("X_ResultFileName").GetEnumerator();
                if(en.MoveNext())
                {
                    var fileName = en.Current;
                    response.Content = "storage";
                    response.ContentName = fileName;
                }
            }
            return response;
            //return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        }
    
        /// <summary>
        /// Translate the HTML document specified by its URL. 
        /// </summary>
        /// <param name="sourceUrl">Source document URL.</param> 
        /// <param name="srcLang">Source language.</param> 
        /// <param name="resLang">Result language.</param> 
        /// <param name="folder">The result document folder</param> 
        /// <param name="storage">The result document storage</param> 
        /// <returns>System.IO.Stream</returns>            
        public NativeRestResponse PutTranslateDocumentByUrl (string sourceUrl, string srcLang, string resLang, string folder = null, string storage = null)
        {
            
            // verify the required parameter 'sourceUrl' is set
            if (sourceUrl == null) throw new ApiException(400, "Missing required parameter 'sourceUrl' when calling PutTranslateDocumentByUrl");
            
            // verify the required parameter 'srcLang' is set
            if (srcLang == null) throw new ApiException(400, "Missing required parameter 'srcLang' when calling PutTranslateDocumentByUrl");
            
            // verify the required parameter 'resLang' is set
            if (resLang == null) throw new ApiException(400, "Missing required parameter 'resLang' when calling PutTranslateDocumentByUrl");
            
    
            var path = "/html/translate/{srcLang}/{resLang}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "srcLang" + "}", ApiClient.ParameterToString(srcLang));
            path = path.Replace("{" + "resLang" + "}", ApiClient.ParameterToString(resLang));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (sourceUrl != null)
            {
                var paramSrcUrl = ApiClient.ParameterToString(sourceUrl);
                if (Uri.IsWellFormedUriString(paramSrcUrl, UriKind.Absolute))
                {
                    queryParams.Add("sourceUrl", paramSrcUrl);
                    //queryParams.Add("sourceUrl", HttpUtility.UrlEncode(paramSrcUrl)); // query parameter
                }
                else
                    throw new ArgumentException("Malformed URL passed as sourceUrl parameter");
            }
            if (folder != null) queryParams.Add("folder", ApiClient.ParameterToString(folder)); // query parameter
            if (storage != null) queryParams.Add("storage", ApiClient.ParameterToString(storage)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            HttpResponseMessage resp = NativeApiClient.CallPut(path, queryParams);

            if (((int)resp.StatusCode) >= 400)
                throw new ApiException((int)resp.StatusCode,
                    "Error calling PutTranslateDocumentByUrl: " + resp.ReasonPhrase, resp.ReasonPhrase);
            else if (((int)resp.StatusCode) == 0)
                throw new ApiException((int)resp.StatusCode,
                    "Error calling PutTranslateDocumentByUrl: " + resp.ReasonPhrase, resp.ReasonPhrase);

            NativeRestResponse response = new NativeRestResponse()
            {
                StatusCode = resp.StatusCode,
                ContentType = NativeRestResponse.RespContentType.FileName,
                MimeType = "application/zip"

            };

            var hdrs = resp.Headers;
            if (hdrs.Contains("X_ResultFileName"))
            {
                IEnumerator<string> en = hdrs.GetValues("X_ResultFileName").GetEnumerator();
                if (en.MoveNext())
                {
                    var fileName = en.Current;
                    response.Content = "storage";
                    response.ContentName = fileName;
                }
            }
            return response;
            //// make the HTTP request
            //IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            //if (((int)response.StatusCode) >= 400)
            //    throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentTranslationPutTranslateDocumentByUrl: " + response.Content, response.Content);
            //else if (((int)response.StatusCode) == 0)
            //    throw new ApiException ((int)response.StatusCode, "Error calling HtmlDocumentTranslationPutTranslateDocumentByUrl: " + response.ErrorMessage, response.ErrorMessage);

            //return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        }
    
    }
}
