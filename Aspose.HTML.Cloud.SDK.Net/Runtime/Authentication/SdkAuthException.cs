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
    /// <summary>
    /// SDK exception
    /// </summary>
    public class SdkAuthException : Exception
    {
        /// <summary>
        /// Exception Reasons options
        /// </summary>
        public enum Reason
        {
            /// <summary>
            /// Common exception
            /// </summary>
            Common,

            /// <summary>
            ///Unknown authentication exception
            /// </summary>
            UnknownAuthMethod,

            /// <summary>
            /// Token expired exception
            /// </summary>
            TokenExpired,

            /// <summary>
            /// Authentication service error
            /// </summary>
            AuthServiceConnect
        }

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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason">Error reason</param>
        /// <param name="message">Error message</param>
        public SdkAuthException(Reason reason, string message) : base(message)
        {
            ErrorReason = reason;
        }

        /// <summary>
        /// Error reason
        /// </summary>
        public Reason ErrorReason { get; }

        /// <summary>
        /// Error message
        /// </summary>
        public override string Message
        {
            get
            {
                if (base.Message != null)
                {
                    return base.Message;
                }
                return DictDefaultReasonMsg.ContainsKey(ErrorReason) 
                    ? DictDefaultReasonMsg[ErrorReason] 
                    : base.Message;
            }
        }

    }
}
