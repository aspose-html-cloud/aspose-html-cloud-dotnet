// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ConversionRequest.cs">
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

using Aspose.HTML.Cloud.Sdk.Conversion;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Core.Model
{
    internal class ConversionRequest
    {
        [JsonProperty("inputPath")]
        public List<string> InputUrl { get; set; }
        
        [JsonProperty("outputPath")]
        public string OutputUrl { get; set; }

        [JsonProperty("inputFormat")]
        public InputFormats InputFileFormat { get; set; }

        [JsonProperty("outputFormat")]
        public OutputFormats OutputFileFormat { get; set; }
    }
}