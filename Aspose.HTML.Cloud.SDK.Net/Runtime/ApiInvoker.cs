// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiInvoker.cs">
//   Copyright (c) 2022 Aspose.HTML Cloud
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
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Models;
using Aspose.HTML.Cloud.Sdk.Runtime.Authentication;

namespace Aspose.HTML.Cloud.Sdk.Runtime
{
    internal class ApiInvoker<TResult> : ApiInvoker
    {
        internal static ApiInvoker<TResult> New(Configuration config, IAuthenticator auth)
        {
            return new ApiInvoker<TResult>
            {
                Configuration = config
            }.WithAuthentication(auth);
        }

        internal static ApiInvoker<TResult> New(IAuthenticator auth)
        {
            return new ApiInvoker<TResult>()
                .WithAuthentication(auth);
        }

        internal static ApiInvoker<TResult> New(IAuthenticator auth, string apiBaseUrl)
        {
            return new ApiInvoker<TResult>()
                .WithApiBaseUrl(apiBaseUrl)
                .WithAuthentication(auth);
        }

        internal ApiInvoker<TResult> WithAuthentication(IAuthenticator auth)
        {
            Authenticator = auth;
            return this;
        }

        internal ApiInvoker<TResult> WithApiBaseUrl(string apiBaseUrl)
        {
            ApiBaseUrl = apiBaseUrl;
            return this;
        }

        internal async Task<TResult> CallGetAsync(RequestUrlBuilder urlBuilder)
        {
            return await CallGetAsync(urlBuilder.Build());
        }

        internal async Task<TResult> CallGetAsync(string url, Func<string, TResult> buildError = null)
        {
            var response = await CallGetImplAsync(url, HttpCompletionOption.ResponseContentRead);
            if (!response.IsSuccessStatusCode)
            {
                if (buildError != null)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    return buildError(message);
                }

                return default;
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<TResult>(responseContent);
            return responseDto;
        }

        internal async Task<StreamResponse> CallGetAsStreamAsync(RequestUrlBuilder urlBuilder)
        {
            return await CallGetAsStreamAsync(urlBuilder.Build());
        }

        internal async Task<StreamResponse> CallGetAsStreamAsync(string url,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            var response = await CallGetImplAsync(url, completionOption);
            return await StreamResponse.GetFromHttpResponseAsync(response);
        }

        internal async Task<byte[]> CallGetAsByteArrayAsync(RequestUrlBuilder urlBuilder)
        {
            return await CallGetAsByteArrayAsync(urlBuilder.Build());
        }

        internal async Task<byte[]> CallGetAsByteArrayAsync(string url)
        {
            var response = await CallGetImplAsync(url, HttpCompletionOption.ResponseContentRead);
            var responseContent = response.Content.ReadAsByteArrayAsync().Result;
            return responseContent;
        }

        internal async Task<TResult> CallPostAsync(RequestUrlBuilder urlBuilder, HttpContent content)
        {
            return await CallPostAsync(urlBuilder.Build(), content);
        }

        internal async Task<TResult> CallPostAsync(string url, HttpContent content)
        {
            var response = await CallPostImplAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<TResult>(responseContent);
            return responseDto;
        }

        internal async Task<TResult> CallPutAsync(RequestUrlBuilder urlBuilder, HttpContent content)
        {
            return await CallPutAsync(urlBuilder.Build(), content);
        }

        internal async Task<TResult> CallPutAsync(string url, HttpContent content)
        {
            var response = await CallPutImplAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<TResult>(responseContent);
            return responseDto;
        }

        internal async Task<TResult> CallDeleteAsync(RequestUrlBuilder urlBuilder)
        {
            return await CallDeleteAsync(urlBuilder.Build());
        }

        internal async Task<TResult> CallDeleteAsync(string url)
        {
            var response = await CallDeleteImplAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<TResult>(responseContent);
            return responseDto;
        }
    }

    internal class ApiInvoker
    {
        protected TaskFactory TaskFactory;
        protected readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        protected IAuthenticator Authenticator { get; set; }

        protected string ApiBaseUrl { get; set; }

        internal ApiInvoker()
        {
            TaskFactory = new TaskFactory(CancellationTokenSource.Token);
        }

        internal Configuration Configuration { get; set; }

        protected async Task<HttpResponseMessage> CallGetImplAsync(string url, HttpCompletionOption completionOption)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                return await AuthenticateAndInvokeAsync(request, completionOption);
            }
            catch (Exception ex)
            {
                throw new ApiException(500, ex.Message, ex);
            }
        }

        protected Task<HttpResponseMessage> CallGetAsyncImpl(string url, IObserver<object> observer = null)
        {
            // TO DO: common async operation logic
            TaskFactory.StartNew((() =>
            {

            }), CancellationTokenSource.Token);
            return null;
        }

        protected async Task<HttpResponseMessage> CallPostImplAsync(string url, HttpContent content)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = content;
                return await AuthenticateAndInvokeAsync(request);
            }
            catch (Exception ex)
            {
                throw new ApiException(500, ex.Message, ex);
            }
        }

        protected async Task<HttpResponseMessage> CallPutImplAsync(string url, HttpContent content)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Content = content;
                return await AuthenticateAndInvokeAsync(request);
            }
            catch (Exception ex)
            {
                throw new ApiException(500, ex.Message, ex);
            }
        }

        protected async Task<HttpResponseMessage> CallDeleteImplAsync(string url)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, url);
                return await AuthenticateAndInvokeAsync(request);
            }
            catch (Exception ex)
            {
                throw new ApiException(500, ex.Message, ex);
            }
        }

        private async Task<HttpResponseMessage> AuthenticateAndInvokeAsync(HttpRequestMessage request, HttpCompletionOption complOption = HttpCompletionOption.ResponseContentRead)
        {
            if (await Authenticator.AuthenticateAsync(request))
            {
                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        httpClient.BaseAddress = new Uri(Configuration.DEF_API_URL);
                        var response = await httpClient.SendAsync(request, complOption);
                        return response;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            throw new ApiException((int)HttpStatusCode.Unauthorized, "Authentication error", Authenticator.AuthError);
        }

    }
}
