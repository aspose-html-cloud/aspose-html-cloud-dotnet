// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="OAuth2.cs">
//   Copyright (c) 2018 Aspose.HTML for Cloud
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
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Com.Aspose.Html.NativeClient.Authentication
{
    class OAuth2 : IAuthenticator
    {
        public enum AuthFlow
        {
            ObtainAccessTokenPending,
            RefreshAccessTokenPending,
            Obtained
        }

        private string m_ClientId;
        private string m_ClientSecret;
        private AuthFlow m_authFlow;

        public OAuth2(string clientId, string clientSecret, string baseUrl)
        {
            m_ClientId = clientId;
            m_ClientSecret = clientSecret;

            m_authFlow = AuthFlow.ObtainAccessTokenPending;
        }

        public bool Authenticate(HttpRequestMessage request)
        {
            if(m_authFlow != AuthFlow.Obtained)
            {
                var host = GetHost(request.RequestUri.AbsoluteUri);
                var authUriString = $"{host}/oauth2/token";
                HttpClient authClient = new HttpClient();
                HttpRequestMessage authReq = new HttpRequestMessage()
                {
                    RequestUri = new Uri(authUriString),
                    Method = HttpMethod.Post
                };
                authReq.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                authReq.Headers.Add("ContentType", "application/x-www-form-urlencoded");
                List<KeyValuePair<string, string>> authReqContent;
                switch (m_authFlow)
                {
                    case AuthFlow.ObtainAccessTokenPending:
                        authReqContent = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("grant_type", "client_credentials"),
                            new KeyValuePair<string, string>("client_id", m_ClientId),
                            new KeyValuePair<string, string>("client_secret", m_ClientSecret)
                        };
 
                        break;
                    case AuthFlow.RefreshAccessTokenPending:

                        var refreshToken = "";

                        authReqContent = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("grant_type", "refresh_token"),
                            new KeyValuePair<string, string>("refresh_token", refreshToken)
                        };
                        break;
                    default:
                        throw new Exception($"Wrong OAuth2 flow");
                }
                authReq.Content = new FormUrlEncodedContent(authReqContent);

                var authResponse = authClient.SendAsync(authReq).Result;
                if(authResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    m_authFlow = AuthFlow.Obtained;
                }

            }
            string hdrValue = string.Format("Bearer {0}", "");
            if(!request.Headers.Contains("Authorization"))
                request.Headers.Add("Authorization", hdrValue);

            return true;
        }

        private string GetHost(string url)
        {
            return new Uri(url).GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped);
        }

        private dynamic AcquireOAuth2TokensByClientCreds(string url)
        {
            var content = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", m_ClientId),
                new KeyValuePair<string, string>("client_secret", m_ClientSecret)
            };

            var client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Post
            };

            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("ContentType", "application/x-www-form-urlencoded");
            request.Content = new FormUrlEncodedContent(content);

            var response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();

            dynamic ticket = null; // await response.Content.ReadAsAsync<dynamic>();
            return ticket;
        }
    }
}
