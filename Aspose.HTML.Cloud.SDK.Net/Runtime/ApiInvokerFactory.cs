﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ApiInvokerFactory.cs">
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

using Aspose.HTML.Cloud.Sdk.Runtime.Authentication;

namespace Aspose.HTML.Cloud.Sdk.Runtime
{
    internal class ApiInvokerFactory
    {
        private IAuthenticator Authenticator { get; }

        private Configuration Configuration { get; }

        internal ApiInvokerFactory(Configuration configuration)
        {
            Configuration = configuration;
            Authenticator = new AuthenticationFactory().CreateAuth(configuration);
        }

        internal ApiInvoker<TResult> GetInvoker<TResult>()
        {
            return ApiInvoker<TResult>.New(Authenticator, Configuration.BaseUrl);
        }
    }
}
