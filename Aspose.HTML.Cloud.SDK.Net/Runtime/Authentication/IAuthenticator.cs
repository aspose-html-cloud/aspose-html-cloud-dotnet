using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Authentication
{
    /// <summary>
    /// Internally used interface. Represents abstraction of the authentification functionality.
    /// </summary>
    public interface IAuthenticator
    {
        bool Authenticate(HttpRequestMessage request);
        void RetryAuthentication();

        bool UseExternalAuthentication { get; }

        SdkAuthException AuthError { get; }

    }
}
