// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="Conversion.cs">
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
using System.Linq;
using Aspose.HTML.Cloud.Sdk.IO;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class Conversion
    {
        public const string UPLOADING = "uploading";
        public const string PENDING = "pending";
        public const string RUNNING = "running";
        public const string COMPLETED = "completed";
        public const string FAULTED = "faulted";
        public const string CANCELED = "canceled";

        public string Id { get; private set; }

        public string Status { get; private set; }

        public RemoteFile[] Files { get; private set; }

        internal void UpdateFrom(ConversionResult dto)
        {
            this.Id = dto.Id.ToString();
            this.Status = dto.Status;
            this.Files = dto.Files?.Select(x => new RemoteFile(new Uri(x), null)).ToArray();
        }

        internal Conversion WithStatus(string status)
        {
            this.Status = status;
            return this;
        }
    }
}