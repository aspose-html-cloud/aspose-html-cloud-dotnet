using System;
using System.Collections.Generic;
using RestSharp;
using Com.Aspose.Html.Client;
using Com.Aspose.Html.Api.Interfaces;

namespace Com.Aspose.Html.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DocumentApi : IDocumentApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlDocumentApi"/> class.
        /// </summary>
		/// <param name="apiKey">The api key.</param>
		/// <param name="apiSid">The api sid.</param>
        /// <param name="basePath">The base path.</param>
        public DocumentApi(String apiKey, String apiSid, String basePath)
        {
            this.ApiClient = new ApiClient(apiKey, apiSid, basePath);
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
        /// Return the HTML document by the name from default or specified storage. 
        /// </summary>
        /// <param name="name">The document name.</param> 
        /// <param name="storage">The document folder</param> 
        /// <param name="folder">The document folder.</param> 
        /// <returns>System.IO.Stream</returns>            
        public System.IO.Stream GetDocument (string name, string storage, string folder)
        {
            
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetDocument");
            
    
            var path = "/html/{name}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClient.ParameterToString(name));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetDocument: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDocument: " + response.ErrorMessage, response.ErrorMessage);
    
            return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        }
    
        /// <summary>
        /// Return list of HTML fragments matching the specified XPath query.  
        /// </summary>
        /// <param name="name">The document name.</param> 
        /// <param name="xPath">XPath query string.</param> 
        /// <param name="outFormat">Output format. Possible values: &#39;plain&#39; and &#39;json&#39;.</param> 
        /// <param name="storage">The document storage.</param> 
        /// <param name="folder">The document folder.</param> 
        /// <returns>System.IO.Stream</returns>            
        public System.IO.Stream GetDocumentFragmentByXPath (string name, string xPath, string outFormat, string storage, string folder)
        {
            
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetDocumentFragmentByXPath");
            
            // verify the required parameter 'xPath' is set
            if (xPath == null) throw new ApiException(400, "Missing required parameter 'xPath' when calling GetDocumentFragmentByXPath");
            
            // verify the required parameter 'outFormat' is set
            if (outFormat == null) throw new ApiException(400, "Missing required parameter 'outFormat' when calling GetDocumentFragmentByXPath");
            
    
            var path = "/html/{name}/fragments/{outFormat}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClient.ParameterToString(name));
            path = path.Replace("{" + "outFormat" + "}", ApiClient.ParameterToString(outFormat));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (xPath != null) queryParams.Add("xPath", ApiClient.ParameterToString(xPath)); // query parameter
             if (storage != null) queryParams.Add("storage", ApiClient.ParameterToString(storage)); // query parameter
             if (folder != null) queryParams.Add("folder", ApiClient.ParameterToString(folder)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDocumentFragmentByXPath: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDocumentFragmentByXPath: " + response.ErrorMessage, response.ErrorMessage);
    
            return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        }
    
        /// <summary>
        /// Return all HTML document images packaged as a ZIP archive. 
        /// </summary>
        /// <param name="name">The document name.</param> 
        /// <param name="storage">The document storage.</param> 
        /// <param name="folder">The document folder.</param> 
        /// <returns>System.IO.Stream</returns>            
        public System.IO.Stream GetDocumentImages (string name, string storage, string folder)
        {
            
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling GetDocumentImages");
            
    
            var path = "/html/{name}/images/all";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "name" + "}", ApiClient.ParameterToString(name));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling GetDocumentImages: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDocumentImages: " + response.ErrorMessage, response.ErrorMessage);
    
            return (System.IO.Stream) ApiClient.Deserialize(response.Content, typeof(System.IO.Stream), response.Headers);
        }
    
    }
}
