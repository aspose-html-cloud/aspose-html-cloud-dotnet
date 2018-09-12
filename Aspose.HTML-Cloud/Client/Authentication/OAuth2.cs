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
using Newtonsoft.Json;


namespace Aspose.Html.Cloud.Sdk.Client.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    class OAuth2 : IAuthenticator
    {
        public enum AuthFlow
        {
            ObtainAccessTokenPending,
            RefreshAccessTokenPending,
            Obtained
        }

        class OAuthData
        {
            public string ClientId { get; private set; }

            public string AccessToken { get; private set; }
            public string TokenType { get; private set; }
            public int ExpiresInSeconds { get; private set; }
            public DateTime IssuedOn { get; private set; }
            public DateTime ExpiresOn => IssuedOn.AddSeconds(ExpiresInSeconds);
            public bool IsAccessTokenExpired => DateTime.UtcNow > ExpiresOn;

            public string RefreshToken { get; private set; }
            public int RefreshTokenLifeTimeInMinutes { get; private set; }
            public DateTime RefreshTokenExpiresOn => IssuedOn.AddMinutes(RefreshTokenLifeTimeInMinutes);
            public bool IsRefreshTokenExpired => DateTime.UtcNow > RefreshTokenExpiresOn;

            public string Error { get; private set; }
            public string ErrorDescription { get; private set; }

            public bool HasError => !string.IsNullOrEmpty(Error);

            public static OAuthData Deserialize(string content)
            {
                var result = new OAuthData();
                Dictionary<string, object> dict =
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                if (dict.ContainsKey("error"))
                {
                    result.Error = dict["error"].ToString();
                    result.ErrorDescription = dict.ContainsKey("error_description") ? dict["error_description"].ToString() : "";
                }
                if (dict.ContainsKey("access_token"))
                {
                    result.AccessToken = dict["access_token"].ToString();
                    result.TokenType = dict["token_type"].ToString();
                    result.ExpiresInSeconds = Convert.ToInt32(dict["expires_in"]);
                    result.RefreshToken = dict["refresh_token"].ToString();
                    result.ClientId = dict["client_id"].ToString();
                    result.RefreshTokenLifeTimeInMinutes =
                        Convert.ToInt32(dict["clientRefreshTokenLifeTimeInMinutes"]);
                    result.IssuedOn = DateTime.Now;
                }

                return result;
            }
        }

        private string m_ClientId;
        private string m_ClientSecret;
        private AuthFlow m_authFlow;

        private OAuthData m_authData = null;

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
                authReq.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
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

                        if(m_authData == null)
                            throw new Exception($"Wrong OAuth2 flow");

                        authReqContent = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("grant_type", "refresh_token"),
                            new KeyValuePair<string, string>("refresh_token", m_authData.RefreshToken)
                        };
                        break;
                    default:
                        throw new Exception($"Wrong OAuth2 flow");
                }
                authReq.Content = new FormUrlEncodedContent(authReqContent);

                var authResponse = authClient.SendAsync(authReq).Result;
                if(authResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = authResponse.Content.ReadAsStringAsync().Result;
                    m_authData = OAuthData.Deserialize(content);
                    m_authFlow = AuthFlow.Obtained;
                }
            }

            if(m_authData != null)
            {
                if(m_authData.HasError)
                    throw new Exception($"OAuth 2.0: Authentication error: {m_authData.Error}", new Exception(m_authData.ErrorDescription));
                request.Headers.Add("Authorization", AuthorizationHeaderValue);
            }
            return true;
        }

        private string AuthorizationHeaderValue
        {
            get
            {
                if (string.IsNullOrEmpty(m_authData?.TokenType))
                    return string.Empty;

                char[] tokenType = m_authData?.TokenType.ToCharArray();
                tokenType[0] = char.ToUpper(tokenType[0]);
                return $"{new String(tokenType)} {m_authData?.AccessToken}";
            }
        }

        private string GetHost(string url)
        {
            return new Uri(url).GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped);
        }

        public void RetryAuthentication()
        {
            m_authFlow = AuthFlow.RefreshAccessTokenPending;
        }

    }
}
