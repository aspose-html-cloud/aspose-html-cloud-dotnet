using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.HTML.Cloud.Sdk.DTO;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils; 

using Aspose.HTML.Cloud.Sdk.Runtime.Authentication;

namespace Aspose.HTML.Cloud.Sdk.Runtime
{
    internal class ApiInvoker<TResult> : ApiInvoker
    {
        public static ApiInvoker<TResult> New(Configuration config, IAuthenticator auth)
        {
            return new ApiInvoker<TResult>() { 
                Configuration = config 
            }.WithAuthentication(auth);
        }

        public static ApiInvoker<TResult> New(IAuthenticator auth, HttpClient client)
        {
            return new ApiInvoker<TResult>()
                .WithHttpClient(client)
                .WithAuthentication(auth);
        }

        public static ApiInvoker<TResult> New(IAuthenticator auth, HttpClient client, string apiBaseUrl = null)
        {
            return new ApiInvoker<TResult>()
                .WithApiBaseUrl(apiBaseUrl)
                .WithHttpClient(client)
                .WithAuthentication(auth);
        }

        internal ApiInvoker<TResult> WithAuthentication(IAuthenticator auth)
        {
            Authenticator = auth;
            return this;
        }

        internal ApiInvoker<TResult> WithHttpClient(HttpClient client)
        {
            HttpClient = client;
            return this;
        }

        internal ApiInvoker<TResult> WithApiBaseUrl (string apiBaseUrl)
        {
            ApiBaseUrl = apiBaseUrl;
            return this;
        }


        public TResult CallGet(RequestUrlBuilder urlBuilder)
        {
            return CallGet(urlBuilder.Build());
        }

        public TResult CallGet(string url)
        {
            // updateHeaders() ------ auth
            var response = CallGetImpl(url, HttpCompletionOption.ResponseContentRead);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseDTO = JsonConvert.DeserializeObject<TResult>(responseContent);
            return responseDTO;
        }

        //public Task<TResult> CallGetAsync(string url, Func<TResult> onCompleted)
        //{

        //}


        public StreamResponse CallGetAsStream(RequestUrlBuilder urlBuilder)
        {
            return CallGetAsStream(urlBuilder.Build());
        }

        public StreamResponse CallGetAsStream(string url, 
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            var response = CallGetImpl(url, completionOption);
            return StreamResponse.GetFromHttpResponse(response);
            //var responseContent = response.Content.ReadAsStreamAsync().Result;
            //return responseContent;
        }

        public byte[] CallGetAsByteArray(RequestUrlBuilder urlBuilder)
        {
            return CallGetAsByteArray(urlBuilder.Build());
        }

        public byte[] CallGetAsByteArray(string url)
        {
            var response = CallGetImpl(url, HttpCompletionOption.ResponseContentRead);
            var responseContent = response.Content.ReadAsByteArrayAsync().Result;
            return responseContent;
        }

        public TResult CallPost(RequestUrlBuilder urlBuilder, HttpContent content)
        {
            return CallPost(urlBuilder.Build(), content);
        }

        public TResult CallPost(string url, HttpContent content)
        {
            var response = CallPostImpl(url, content);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseDTO = JsonConvert.DeserializeObject<TResult>(responseContent);
            return responseDTO;
        }
        

        public TResult CallPut(RequestUrlBuilder urlBuilder, HttpContent content)
        {
            return CallPut(urlBuilder.Build(), content);
        }

        public TResult CallPut(string url, HttpContent content)
        {
            var response = CallPutImpl(url, content);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseDTO = JsonConvert.DeserializeObject<TResult>(responseContent);
            return responseDTO;
        }

        public TResult CallDelete(RequestUrlBuilder urlBuilder)
        {
            return CallDelete(urlBuilder.Build());
        }

        public TResult CallDelete(string url)
        {
            var response = CallDeleteImpl(url);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseDTO = JsonConvert.DeserializeObject<TResult>(responseContent);
            return responseDTO;
        }


    }

    internal class ApiInvoker
    {
        protected TaskFactory taskFactory;
        protected readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        protected IAuthenticator Authenticator { get; set; }
        protected HttpClient HttpClient { get; set; }

        protected string ApiBaseUrl { get; set; }

        internal ApiInvoker()
        {
            taskFactory = new TaskFactory(cancellationTokenSource.Token);
        }

        public Configuration Configuration { get; set; }

        protected HttpResponseMessage CallGetImpl(string url, HttpCompletionOption completionOption)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, GetFinalUrlToInvoke(url));
                return AuthenticateAndInvokeSync(request, completionOption);
            }
            catch(Exception ex)
            {
                throw new ApiException(500, ex.Message, ex);
            }
        }

        protected Task<HttpResponseMessage> CallGetAsyncImpl(string url, IObserver<object> observer = null)
        {
            // TO DO: common async operation logic
            taskFactory.StartNew((() => {

            }), cancellationTokenSource.Token);
            return null;
        }


        protected HttpResponseMessage CallPostImpl(string url, HttpContent content)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, GetFinalUrlToInvoke(url));
                request.Content = content;
                return AuthenticateAndInvokeSync(request);
            }
            catch (Exception ex)
            {
                throw new ApiException(500, ex.Message, ex);
            }
        }


        protected HttpResponseMessage CallPutImpl(string url, HttpContent content)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, GetFinalUrlToInvoke(url));
                request.Content = content;
                return AuthenticateAndInvokeSync(request);
            }
            catch (Exception ex)
            {
                throw new ApiException(500, ex.Message, ex);
            }
        }

        protected HttpResponseMessage CallDeleteImpl(string url)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, GetFinalUrlToInvoke(url));
                return AuthenticateAndInvokeSync(request);
            }
            catch (Exception ex)
            {
                throw new ApiException(500, ex.Message, ex);
            }
        }

        protected string GetFinalUrlToInvoke(string url)
        {
            if (!string.IsNullOrEmpty(ApiBaseUrl))
            {
                var urlPath = url;
                if(urlPath.StartsWith("/v4.0/html"))
                {
                    urlPath = url.Replace("/v4.0/html", "");
                }
                //var delim = ApiBaseUrl.EndsWith("/") ? "" : "/";
                return $"{ApiBaseUrl}{urlPath}";
            }
            return url;
        }

        private HttpResponseMessage AuthenticateAndInvokeSync(
            HttpRequestMessage request,
            HttpCompletionOption complOption = HttpCompletionOption.ResponseContentRead)
        {
            if (Authenticator.Authenticate(request))
            {
                var httpClient = HttpClient ?? new HttpClient();
                
                var response = httpClient.SendAsync(request, complOption,
                    cancellationTokenSource.Token).Result;
                response.EnsureSuccessStatusCode();
                return response;
            }
            else
            {
                throw new ApiException((int)HttpStatusCode.Unauthorized, "Authentication error", Authenticator.AuthError);
            }
        }

    }
}
