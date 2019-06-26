// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="StreamResponse.cs">
//   Copyright (c) 2017 Aspose.HTML for Cloud
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
// --------------------------------------------------------------------------------------------------------------------using System;

using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Html.Cloud.Sdk.Api.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class StreamResponse : AsposeResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Stream ContentStream { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContentAsString
        {
            get
            {
                if(ContentStream != null && ContentStream.Length > 0)
                {
                    ContentStream.Position = 0;
                    using(StreamReader rdr = new StreamReader(ContentStream))
                    {
                        var stringContent = rdr.ReadToEnd();
                        return stringContent;
                    }
                }
                return string.Empty;
            }
        }
    }
}
