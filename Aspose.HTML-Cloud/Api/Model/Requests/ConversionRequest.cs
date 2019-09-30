// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ConversionRequest.cs">
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
// ----

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aspose.Html.Cloud.Sdk.Client;

namespace Aspose.Html.Cloud.Sdk.Api.Model.Requests
{
    /// <summary>
    /// Class of request parameters; TODO: left for further development 
    /// </summary>
    internal class ConversionRequest
    {
        public class PageMargin
        {
            public int? Top { get; set; }
            public int? Bottom { get; set; }
            public int? Left { get; set; }
            public int? Right { get; set; }
        }

        public class PageSetup
        {
            public int? Width { get; set; }
            public int? Height { get; set; }

            public PageMargin Margin { get; set; }
        }

        public ConversionRequest(string format)
        {
            OutFormat = format;
        }

        public string OutFormat { get; protected set; } 
        public string Name { get; set; }
        public string Folder { get; set; }
        public string SourceUrl { get; set; }

        public PageSetup Page { get; set; }
        public int? Resolution { get; set; }

        public int? Width { get { return Page?.Width;  } }
        public int? Height { get { return Page?.Height; } }

        public virtual Dictionary<string, string> ToQueryParamList()
        {
            var queryParams = new Dictionary<string, string>();

            if (SourceUrl != null)
                queryParams.Add("sourceUrl", ApiClientUtils.ParameterToString(SourceUrl));

            if (Page != null)
            {
                if(Width != null)
                    queryParams.Add("width", ApiClientUtils.ParameterToString(Width));
                if(Height != null)
                    queryParams.Add("height", ApiClientUtils.ParameterToString(Height));
                if(Page.Margin != null)
                {
                    if (Page.Margin.Top != null)
                        queryParams.Add("topMargin", ApiClientUtils.ParameterToString(Page.Margin.Top));
                    if (Page.Margin.Left != null)
                        queryParams.Add("leftMargin", ApiClientUtils.ParameterToString(Page.Margin.Left));
                    if (Page.Margin.Right != null)
                        queryParams.Add("rightMargin", ApiClientUtils.ParameterToString(Page.Margin.Right));
                    if (Page.Margin.Bottom != null)
                        queryParams.Add("bottomMargin", ApiClientUtils.ParameterToString(Page.Margin.Bottom));
                }
            }

            if (Resolution != null)
                queryParams.Add("resolution", ApiClientUtils.ParameterToString(Resolution));
            if(Folder != null)
                queryParams.Add("folder", ApiClientUtils.ParameterToString(Folder));

            return queryParams;
        }
    }
}
