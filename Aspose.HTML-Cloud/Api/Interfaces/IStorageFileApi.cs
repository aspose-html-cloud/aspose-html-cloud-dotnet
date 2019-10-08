// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="IStorageFileApi.cs">
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
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.Html.Cloud.Sdk.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStorageFileApi
    {
        /// <summary>
        /// Download file from storage.
        /// </summary>
        /// <param name="path">File path, e.g. /folder/filename.ext </param>
        /// <param name="storage">Storage name.</param>
        /// <param name="versionId">File version ID to download; the last version by default.</param>
        /// <returns></returns>
        StreamResponse DownloadFile(string path, string storage = null, string versionId = null);

        /// <summary>
        /// Upload stream to a storage file.
        /// </summary>
        /// <param name="stream">File stream to upload.</param>
        /// <param name="path">Storage path </param>
        /// <param name="storage">Storage name.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        AsposeResponse UploadFile(Stream stream, string path, string storage = null);

        /// <summary>
        /// Overridden. Upload file from the local file system to storage.
        /// </summary>
        /// <param name="localPath">Local file system path.</param>
        /// <param name="path">Path to upload, e.g. /folder/file.ext </param>
        /// <param name="storage">Storage name.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        AsposeResponse UploadFile(string localPath, string path, string storage = null);

        /// <summary>
        /// Delete file from storage.
        /// </summary>
        /// <param name="path">File path, e.g. /folder/file.ext </param>
        /// <param name="storage">Storage name.</param>
        /// <param name="versionId">File version ID to delete; the last version by default.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        AsposeResponse DeleteFile(string path, string storage = null, string versionId = null);

        /// <summary>
        /// Copy storage file.
        /// </summary>
        /// <param name="srcPath">Source file path.</param>
        /// <param name="destPath">Destination file path.</param>
        /// <param name="srcStorage">Source storage name.</param>
        /// <param name="destStorage">Destination storage name.</param>
        /// <param name="versionId">File version ID to copy; the last version by default.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        AsposeResponse CopyFile(string srcPath, string destPath, string srcStorage = null, string destStorage = null, string versionId = null);

        /// <summary>
        /// Move storage file.
        /// </summary>
        /// <param name="srcPath">Source file path.</param>
        /// <param name="destPath">Destination file path.</param>
        /// <param name="srcStorage">Source storage name.</param>
        /// <param name="destStorage">Destination storage name.</param>
        /// <param name="versionId">File version ID to copy; the last version by default.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        AsposeResponse MoveFile(string srcPath, string destPath, string srcStorage = null, string destStorage = null, string versionId = null);
    }
}
