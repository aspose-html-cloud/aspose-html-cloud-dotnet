// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="SdkAuthException.cs">
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

namespace Aspose.HTML.Cloud.Sdk.Runtime.Authentication
{
    public class SdkAuthException : Exception
    {
        public enum Reason
        {
            Common,
            UnknownAuthMethod,
            TokenExpired,
            AuthServiceConnect
        }

        private readonly Reason mReason;
        private static readonly Dictionary<Reason, string> DictDefaultReasonMsg;

        static SdkAuthException()
        {
            DictDefaultReasonMsg = new Dictionary<Reason, string>
            {
                { Reason.Common, "Authorization failed by unknown reason" },
                { Reason.UnknownAuthMethod, "Unknown authorization method" },
                { Reason.AuthServiceConnect, "Authorization service is unavailable." },
                { Reason.TokenExpired, "Authorization token expired." }
            };
        }

        public SdkAuthException(Reason reason, string message) : base(message)
        {
            mReason = reason;
        }

        public Reason ErrorReason => mReason;

        public override string Message
        {
            get
            {
                if (base.Message == null)
                {
                    if (DictDefaultReasonMsg.ContainsKey(mReason))
                        return DictDefaultReasonMsg[mReason];
                }
                return base.Message;
            }
        }

    }
}
