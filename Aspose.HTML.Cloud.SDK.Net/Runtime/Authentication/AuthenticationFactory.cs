using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Authentication
{
    class AuthenticationFactory
    {

        public IAuthenticator CreateAuth(Configuration configuration)
        {
            var conf = configuration ?? Configuration.NewDefault();

            if(conf.UseExternalAuthentication)
            {
                return new JwtAuth(conf.ExternalAuthToken);
            }

            if (!string.IsNullOrEmpty(conf.AppSid)
                    && !string.IsNullOrEmpty(conf.AppKey)
                    && !string.IsNullOrEmpty(conf.AuthUrl))
            {
                return new JwtAuth(conf.AppSid, conf.AppKey, conf.AuthUrl);
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
