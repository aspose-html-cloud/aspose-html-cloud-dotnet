// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ISeoApi.cs">
//   Copyright (c) 2019 Aspose.HTML Cloud
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
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.Html.Cloud.Sdk.Api.Interfaces
{
    public interface ISeoApi
    {
        /// <summary>
        /// Analyze Web page by provided URL and return a list of SEO warnings. 
        /// The source page is checked for following points:
        /// - detection of broken links;
        /// - e-mail links validation;
        /// - checking for presence of ALT attribute in the IMG elements
        /// - checking for duplicated H1 elements.
        /// </summary>
        /// <param name="sourceUrl">Source page URL</param>
        /// <returns><see cref="StreamResponse"/> | Stream containing JSON list of links and detected warnings. </returns>
        StreamResponse GetWebPageSEOWarnings(string sourceUrl);
    }
}
