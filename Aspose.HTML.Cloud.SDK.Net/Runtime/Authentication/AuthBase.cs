﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="AuthBase.cs">
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
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Aspose.HTML.Cloud.Sdk.Runtime.Authentication
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
            Unknown = 0, 
            NoAuth = 1, 
            OAuth2, 
            Jwt
        }

        protected static Dictionary<AuthType, string> DictAuthTypes = new Dictionary<AuthType, string>();
        protected string MClientId;
        protected string MClientSecret;
        protected AuthFlow MAuthFlow;
        protected readonly string MAuthPath;
        protected readonly AuthType MAuthType;

        protected bool ExternalAuth { get; set; }

        protected SdkAuthException ErrorImpl { get; set; }

        static AuthBase()
        {
            DictAuthTypes.Add(AuthType.OAuth2, "OAuth 2.0");
            DictAuthTypes.Add(AuthType.Jwt, "JWT");
            DictAuthTypes.Add(AuthType.NoAuth, "NoAuth");
        }

        protected AuthBase(AuthType type, string authPath)
        {
            MAuthType = type;
            MAuthPath = authPath;
        }

        protected async Task<bool> AuthenticateImplAsync(HttpRequestMessage request)
        {
            if (MAuthFlow != AuthFlow.Obtained)
            {
                if (!ExternalAuth)
                {
                    var host = MAuthPath;
                    var authUriString = GetAuthUriString(host);
                    using (var authClient = new HttpClient())
                    {
                        var authReq = new HttpRequestMessage
                        {
                            RequestUri = new Uri(authUriString),
                            Method = HttpMethod.Post
                        };
                        authReq.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var authReqContent = BuildAuthRequestContent();
                        authReq.Content = new FormUrlEncodedContent(authReqContent);
                        authReq.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                        using (var authResponse = await authClient.SendAsync(authReq))
                        {
                            if (authResponse.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var content = await authResponse.Content.ReadAsStringAsync();
                                AuthDataDeserializeImpl(content);
                                MAuthFlow = AuthFlow.Obtained;
                            }
                            else
                            {
                                var reason = SdkAuthException.Reason.Common;
                                ErrorImpl = new SdkAuthException(reason, authResponse.ReasonPhrase);
                                MAuthFlow = AuthFlow.ObtainAccessTokenPending;
                                return false;
                            }
                        }

                    }


                }
                else
                {
                    MAuthFlow = AuthFlow.ObtainAccessTokenPending;
                    return false;
                }
            }
            else
            {
                if (IsAccessTokenExpired())
                {
                    if (ExternalAuth)
                        ErrorImpl = new SdkAuthException(SdkAuthException.Reason.TokenExpired, "Externally provided authorization token expired.");

                    MAuthFlow = AuthFlow.ObtainAccessTokenPending;
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
