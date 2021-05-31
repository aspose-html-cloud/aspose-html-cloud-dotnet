// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="StorageItem.cs">
//   Copyright (c) 2018 Aspose.HTML for Cloud
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aspose.Html.Cloud.Sdk.Api.Model
{
    /// <summary>
    /// Class representing a storage object (file or folder).
    /// </summary>
    /// 
    [JsonObject()]
    public class StorageItem
    {
        /// <summary>
        /// Object (file or folder) name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// Object path in the storage.
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }
        /// <summary>
        /// True if folder, false if file.
        /// </summary>
        [JsonProperty(PropertyName = "isFolder")]
        public bool IsFolder { get; set; }
        /// <summary>
        /// File size; always 0 for folder.
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public long Size { get; set; }
        /// <summary>
        /// Last modification date.
        /// </summary>
        [JsonProperty(PropertyName = "modifiedDate")]
        public string ModifiedDateStr { get; set; }

        public DateTime ModifiedDate
        {
            get {
                if (string.IsNullOrEmpty(ModifiedDateStr))
                    return DateTime.MinValue;

                return DateTime.Parse(ModifiedDateStr);
            }
        }
    }
}
