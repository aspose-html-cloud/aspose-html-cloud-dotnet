// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="IStorageApi.cs">
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

using System.IO;
using System.Collections.Generic;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.Html.Cloud.Sdk.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStorageApi
    {
        /// <summary>
        /// Check if specified storage exists
        /// </summary>
        /// <param name="storage">Storage name.</param>
        /// <returns></returns>
        bool StorageExists(string storage);

        /// <summary>
        /// Check if specified file or folder exists
        /// </summary>
        /// <param name="path">Object path, e.g. /folder1/folder2/file.ext or /folder</param>
        /// <param name="storage">Storage name.</param>
        /// <param name="versionId">File version ID (ignored for folders)</param>
        /// <returns></returns>
        bool FileOrFolderExists(string path, string storage = null, string versionId = null);

        /// <summary>
        /// Returns the disc usage.
        /// </summary>
        /// <param name="storage">Storage name.</param>
        /// <returns></returns>
        DiscUsage GetDiscUsage(string storage = null);

        /// <summary>
        /// Returns list of specified file versions.
        /// </summary>
        /// <param name="path">File path, e.g. /folder/file.ext </param>
        /// <param name="storage">Storage name.</param>
        /// <returns></returns>
        List<StorageItemVersion> GetStorageItemVersions(string path, string storage = null);
    }
}
