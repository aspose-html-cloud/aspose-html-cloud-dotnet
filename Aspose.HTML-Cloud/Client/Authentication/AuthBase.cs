// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="AuthBase.cs">
//   Copyright (c) 2019 Aspose.HTML for Cloud
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
    internal abstract class AuthBase
    {
        public enum AuthFlow
        {
            ObtainAccessTokenPending,
            RefreshAccessTokenPending,
            Obtained
        }

        public enum AuthType
        {
            Unknown = 0, OAuth2, Jwt
        }

        protected static Dictionary<AuthType, string> DictAuthTypes = new Dictionary<AuthType, string>();

        protected string m_ClientId;
        protected string m_ClientSecret;
        protected AuthFlow m_authFlow;

        protected readonly string m_authPath;
        protected readonly AuthType m_AuthType;

        static AuthBase()
        {
            DictAuthTypes.Add(AuthType.OAuth2, "OAuth 2.0");
            DictAuthTypes.Add(AuthType.Jwt, "JWT");
        }

        protected AuthBase(AuthType type, string authPath)
        {
            m_AuthType = type;
            m_authPath = authPath;
        }

        public static IAuthenticator GetAuthenticator(AuthType type, string clientId, string clientSecret, string baseUri)
        {
            switch(type)
            {
                case AuthType.OAuth2:
                    return new OAuth2(clientId, clientSecret, baseUri);
                case AuthType.Jwt:
                    return new JwtAuth(clientId, clientSecret, baseUri);
                default:
                    throw new Exception("Unknown authentication method");
            }
        }

        protected static string GetHost(string url)
        {
            return new Uri(url).GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped);
        }

        protected bool AuthenticateImpl(HttpRequestMessage request)
        {
            if (m_authFlow != AuthFlow.Obtained)
            {
                var host = m_authPath; //GetHost(request.RequestUri.AbsoluteUri);
                var authUriString = GetAuthUriString(host);
                HttpClient authClient = new HttpClient();
                HttpRequestMessage authReq = new HttpRequestMessage()
                {
                    RequestUri = new Uri(authUriString),
                    Method = HttpMethod.Post
                };
                authReq.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                List<KeyValuePair<string, string>> authReqContent = BuildAuthRequestContent();
                authReq.Content = new FormUrlEncodedContent(authReqContent);
                authReq.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                var authResponse = authClient.SendAsync(authReq).Result;
                if (authResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = authResponse.Content.ReadAsStringAsync().Result;
                    AuthDataDeserializeImpl(content);
                    m_authFlow = AuthFlow.Obtained;
                }
                else
                {
                    m_authFlow = AuthFlow.ObtainAccessTokenPending;
                    return false;
                }
            }
            else
            {
                if(IsAccessTokenExpired())
                {
                    m_authFlow = AuthFlow.ObtainAccessTokenPending;
                    return false;
                }
            }
            return true;
        }

        protected abstract string GetAuthUriString(string host);

        protected abstract List<KeyValuePair<string, string>> BuildAuthRequestContent();

        protected abstract void AuthDataDeserializeImpl(string content);

        protected abstract bool IsAccessTokenExpired();

    }
}
