// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="JwtAuth.cs">
//   Copyright (c) 2020 Aspose.HTML Cloud
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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Authentication
{
    internal class JwtAuth : AuthBase, IAuthenticator
    {

        class JwtData
        {
            const string CLAIM_NBF = "nbf";
            const string CLAIM_EXP = "exp";
            const string CLAIM_CLID = "client_id";

            public string ClientId { get; private set; }

            public string AccessToken { get; private set; }
            public string TokenType { get; private set; }
            public int ExpiresInSeconds { get; private set; }
            public DateTime IssuedOn { get; private set; }
            public DateTime ExpiresOn => IssuedOn.AddSeconds(ExpiresInSeconds);
            public bool IsAccessTokenExpired => DateTime.UtcNow > ExpiresOn;

            public string Error { get; private set; }
            public string ErrorDescription { get; private set; }

            public bool HasError => !string.IsNullOrEmpty(Error);

            public string Header
            {
                get
                {
                    if (!string.IsNullOrEmpty(AccessToken))
                    {
                        int pidx = AccessToken.IndexOf('.');
                        return AccessToken.Substring(0, pidx);
                    }
                    return "";
                }
            }
            public string Payload
            {
                get
                {
                    if (!string.IsNullOrEmpty(AccessToken))
                    {
                        int pidx = AccessToken.IndexOf('.'), lpidx = AccessToken.LastIndexOf('.');
                        return AccessToken.Substring(pidx + 1, lpidx - pidx - 1);
                    }
                    return "";
                }
            }
            public string Signature
            {
                get
                {
                    if (!string.IsNullOrEmpty(AccessToken))
                    {
                        int lpidx = AccessToken.LastIndexOf('.');
                        return AccessToken.Substring(lpidx + 1);
                    }
                    return "";
                }
            }

            public static JwtData Deserialize(string content)
            {
                var result = new JwtData();
                Dictionary<string, object> dict =
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                if (dict.ContainsKey("error"))
                {
                    result.Error = dict["error"].ToString();
                    result.ErrorDescription = dict.ContainsKey("error_description") ? dict["error_description"].ToString() : "";
                }
                if (dict.ContainsKey("access_token"))
                {
                    //result.ClientId = dict["client_id"].ToString();
                    result.AccessToken = dict["access_token"].ToString();
                    result.TokenType = dict["token_type"].ToString();
                    result.ExpiresInSeconds = Convert.ToInt32(dict["expires_in"]);
                    result.IssuedOn = DateTime.UtcNow;
                }
                return result;
            }

            public static JwtData InitByExternalToken(string token)
            {
                var result = new JwtData();
                result.AccessToken = token;
                result.TokenType = "Bearer";

                // TODO: manual JWT token parsing, 
                // to exclude System.IdentityModel.Tokens.Jwt dependency
                //
                //byte[] hdr_data = Convert.FromBase64String(result.Header);
                //byte[] pl_data = Convert.FromBase64String(result.Payload);
                //string hdr = Encoding.ASCII.GetString(hdr_data);
                //string pl = Encoding.ASCII.GetString(pl_data);
                //string sg = result.Signature;
                //result.ClientId =
                //    result.IssuedOn =
                //    result.ExpiresInSeconds =

                var jwtHandler = new JwtSecurityTokenHandler();
                if (jwtHandler.CanReadToken(token))
                {
                    var jwt_token = jwtHandler.ReadJwtToken(token);
                    var claimId = jwt_token?.Claims?.FirstOrDefault(_ => _.Type == CLAIM_CLID);
                    result.ClientId = claimId?.Value;

                    var claimIssued = jwt_token?.Claims?.FirstOrDefault(_ => _.Type == CLAIM_NBF);
                    double issued = double.Parse(claimIssued?.Value);
                    result.IssuedOn = ApiClientUtils.ConvertDateTimeFromUnixTimestamp(issued);

                    var claimExp = jwt_token?.Claims?.FirstOrDefault(_ => _.Type == CLAIM_EXP);
                    double expired = double.Parse(claimExp?.Value);
                    result.ExpiresInSeconds = (int)(expired - issued);
                }
                return result;
            }


            //private static string GetAppSidFromJwtToken(string token)
            //{
            //    const string claimType = "client_id";

            //    string appsid = null;
            //    var jwtHandler = new JwtSecurityTokenHandler();
            //    if (jwtHandler.CanReadToken(token))
            //    {
            //        var jwt_token = jwtHandler.ReadJwtToken(token);
            //        var clientIdClaim = jwt_token?.Claims?.FirstOrDefault(_ => _.Type == claimType);
            //        appsid = clientIdClaim?.Value;
            //    }
            //    return appsid;
            //}
        }

        private JwtData m_authData = null;

        public JwtAuth(string clientId, string clientSecret, string authUrl)
            : base(AuthType.Jwt, authUrl)
        {
            m_ClientId = clientId;
            m_ClientSecret = clientSecret;
            ExternalAuth = false;

            m_authFlow = AuthFlow.ObtainAccessTokenPending;
        }

        public JwtAuth(string token)
            : base(AuthType.Jwt, null)
        {
            m_authData = JwtData.InitByExternalToken(token);
            m_ClientId = m_authData.ClientId;
            m_ClientSecret = null;

            ExternalAuth = true;
            m_authFlow = AuthFlow.Obtained;
        }


        public bool Authenticate(HttpRequestMessage request)
        {
            bool res = AuthenticateImpl(request);
            if (!res)
            {
                if (m_authData != null && m_authData.HasError)
                {
                    ErrorImpl = new SdkAuthException(SdkAuthException.Reason.Common, $"{m_authData.Error}; \r\nDescription: {m_authData.ErrorDescription}");
                }
            }
            else
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", m_authData.AccessToken);
            }
            return res;
        }

        public void RetryAuthentication()
        {
            m_authFlow = AuthFlow.ObtainAccessTokenPending;
        }

        public bool UseExternalAuthentication => ExternalAuth;

        public SdkAuthException AuthError => ErrorImpl;


        protected override string GetAuthUriString(string host)
        {
            const string urlPath = "/connect/token";
            if (host.EndsWith(urlPath))
                return host; 

            return $"{host}{urlPath}";
        }

        protected override void AuthDataDeserializeImpl(string content)
        {
            m_authData = JwtData.Deserialize(content);
        }

        protected override List<KeyValuePair<string, string>> BuildAuthRequestContent()
        {
            List<KeyValuePair<string, string>> authReqContent = null;
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
                default:
                    throw new Exception($"Wrong JWT flow");
            }
            return authReqContent;
        }

        protected override bool IsAccessTokenExpired()
        {
            return m_authData.IsAccessTokenExpired;
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
    }
}
