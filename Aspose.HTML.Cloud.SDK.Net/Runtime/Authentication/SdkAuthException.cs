// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="SdkAuthException.cs">
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

namespace Aspose.HTML.Cloud.Sdk.Runtime.Authentication
{
    /// <summary>
    /// Authentication exception raised by SDK method.
    /// </summary>
    public class SdkAuthException : Exception
    {
        public enum Reason
        {
            Common,
            UnknownAuthMethod,
            TokenExpired,
            AuthServiceConnect
        }

        private Reason m_reason;
        private static Dictionary<Reason, string> dictDefaultReasonMsg;

        static SdkAuthException()
        {
            dictDefaultReasonMsg = new Dictionary<Reason, string>()
            {
                { Reason.Common, "Authorization failed by unknown reason" },
                { Reason.UnknownAuthMethod, "Unknown authorization method" },
                { Reason.AuthServiceConnect, "Authorization service is unavailable." },
                { Reason.TokenExpired, "Authorization token expired." }
            };
        }

        public SdkAuthException()
        {
            m_reason = Reason.Common;
        }

        public SdkAuthException(Reason reason)
        {
            m_reason = reason;
        }

        public SdkAuthException(Reason reason, string message) : base(message)
        {
            m_reason = reason;
        }

        public Reason ErrorReason => m_reason;

        public override string Message
        {
            get
            {
                if (base.Message == null)
                {
                    if (dictDefaultReasonMsg.ContainsKey(m_reason))
                        return dictDefaultReasonMsg[m_reason];
                }
                return base.Message;
            }
        }

    }
}
