// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="AuthenticationFactory.cs">
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


namespace Aspose.HTML.Cloud.Sdk.Runtime.Authentication
{
    class AuthenticationFactory
    {

        public IAuthenticator CreateAuth(Configuration configuration)
        {
            var conf = configuration ?? Configuration.New();

            if(conf.UseExternalAuthentication)
            {
                return new JwtAuth(conf.ExternalAuthToken);
            }

            if (!string.IsNullOrEmpty(conf.ClientId)
                    && !string.IsNullOrEmpty(conf.ClientSecret))
            {
                var authUrl = conf.AuthUrl;
                return new JwtAuth(conf.ClientId, conf.ClientSecret, conf.AuthUrl);
            }
            else
                return new DummyAuth();
        }


        //public IAuthenticator CreateJwtAuth(Configuration configuration)
        //{
        //    return new JwtAuth(configuration?.AppSid, configuration?.AppKey, configuration?.AuthUrl);
        //}

        //IAuthenticator CreateJwtAuth(string token)
        //{
        //    return null; // not implemented
        //}

        //public IAuthenticator CreateDummyAuth()
        //{
        //    return new DummyAuth();
        //}
    }
}
