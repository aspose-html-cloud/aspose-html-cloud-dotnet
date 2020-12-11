using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Authentication
{
    internal class DummyAuth : AuthBase, IAuthenticator
    {
        public DummyAuth() : base(AuthType.NoAuth, null)
        {
            m_authFlow = AuthFlow.Obtained;
        }

        public bool UseExternalAuthentication => false;

        public SdkAuthException AuthError => throw new NotImplementedException();

        public bool Authenticate(HttpRequestMessage request)
        {
            return true;
        }

        public void RetryAuthentication()
        {
        }

        protected override void AuthDataDeserializeImpl(string content)
        {
            throw new NotImplementedException();
        }

        protected override List<KeyValuePair<string, string>> BuildAuthRequestContent()
        {
            throw new NotImplementedException();
        }

        protected override string GetAuthUriString(string host)
        {
            return null;
        }

        protected override bool IsAccessTokenExpired()
        {
            return false;
        }
    }
}
