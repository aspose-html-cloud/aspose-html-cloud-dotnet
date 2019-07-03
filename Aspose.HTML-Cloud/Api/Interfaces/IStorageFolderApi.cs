// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="IStorageFolderApi.cs">
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


using System.IO;
using System.Collections.Generic;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.Html.Cloud.Sdk.Api.Interfaces
{
    public interface IStorageFolderApi
    {
        /// <summary>
        /// Get all files and folders within a specified folder.
        /// </summary>
        /// <param name="path">Folder path, e.g. /folder1/folder2</param>
        /// <param name="storage">Storage name.</param>
        /// <returns>StorageItemListResponse | List of items in the folder.</returns>
        List<StorageItem> GetFolderContentList(string path, string storage = null);

        /// <summary>
        /// Create folder.
        /// </summary>
        /// <param name="path">Folder path, e.g. /folder1/folder2 </param>
        /// <param name="storage">Storage name.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        AsposeResponse CreateFolder(string path, string storage = null);

        /// <summary>
        /// Delete folder.
        /// </summary>
        /// <param name="path">Folder path, e.g. /folder1/folder2 </param>
        /// <param name="storage">Storage name.</param>
        /// <param name="recursive">Enable to delete files and subfolders, if folder is not empty.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        AsposeResponse DeleteFolder(string path, string storage = null, bool recursive = false);

        /// <summary>
        /// Copy folder with files and subfolders.
        /// </summary>
        /// <param name="srcPath">Source folder path, e.g. /src </param>
        /// <param name="destPath">Destination folder path, e.g. /dst </param>
        /// <param name="srcStorage">Source storage name.</param>
        /// <param name="destStorage">Destination storage name.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        AsposeResponse CopyFolder(string srcPath, string destPath, string srcStorage = null, string destStorage = null);

        /// <summary>
        /// Move folder with files and subfolders.
        /// </summary>
        /// <param name="srcPath">Source folder path, e.g. /src </param>
        /// <param name="destPath">Destination folder path, e.g. /dst </param>
        /// <param name="srcStorage">Source storage name.</param>
        /// <param name="destStorage">Destination storage name.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        AsposeResponse MoveFolder(string srcPath, string destPath, string srcStorage = null, string destStorage = null);
    }
}
