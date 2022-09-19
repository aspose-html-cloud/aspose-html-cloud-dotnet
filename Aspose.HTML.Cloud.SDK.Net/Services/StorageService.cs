// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="StorageProvider.cs">
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
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.IO;
using Aspose.HTML.Cloud.Sdk.Models;
using Aspose.HTML.Cloud.Sdk.Runtime;

namespace Aspose.HTML.Cloud.Sdk.Services
{
    internal sealed class StorageService
    {
        private readonly TaskFactory taskFactory;
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private ApiInvokerFactory InvokerFactory { get; }

        private const string STORAGE_URI = "/v4.0/html/storage";
        private const string FILE_URI = "/v4.0/html/file";
        private const string FOLDER_URI = "/v4.0/html/folder";

        internal StorageService(ApiInvokerFactory invokerFactory = null)
        {
            taskFactory = new TaskFactory(cancellationTokenSource.Token);
            InvokerFactory = invokerFactory;
        }

        internal async Task<bool> ExistsAsync(string storageName)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
                var response = await apiInvoker.CallGetAsync(
                    RequestUrlBuilder.GetBuilder($"{STORAGE_URI}/exist/storage")
                        .WithStorageName(storageName));

                return response.Exists;
        }

        internal async Task<Storage> GetStorageAsync(string storageName)
        {
            var apiInvoker = InvokerFactory.GetInvoker<Storage>();
            var response = await apiInvoker.CallGetAsync(
                RequestUrlBuilder.GetBuilder($"{STORAGE_URI}/disc/usage?storageName={storageName}"));
            if (response == null)
            {
                return null;
            }
            return new Storage(storageName, response.UsedSize, response.TotalSize);
        }


        #region Directory API

        public async Task<bool> DirectoryExistsAsync(string directoryUri, string storageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = await apiInvoker.CallGetAsync(
                RequestUrlBuilder.GetBuilder($"{STORAGE_URI}/exist")
                    .WithStorageName(storageName)
                    .WithPath(directoryUri));
            return response.IsFolder && response.Exists;
        }

        public async Task<IReadOnlyList<RemoteDirectory>> GetDirectoriesAsync(string rootDirectoryUri, string storageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<FilesList>();
            var response = await apiInvoker.CallGetAsync(
                 RequestUrlBuilder.GetBuilder($"{FOLDER_URI}")
                     .WithStorageName(storageName)
                     .WithPath(rootDirectoryUri));

            var res = response.Value
                 .Where(f => f.IsFolder)
                 .Select(f => new RemoteDirectory(f.Path, new RemoteFileSystemInfo(0, DateTime.MinValue))).ToImmutableList();
            return res;
        }

        public async Task<RemoteDirectory> GetDirectoryAsync(string directoryUri, string storageName = null)
        {
            var dirs = await GetDirectoriesAsync(directoryUri, storageName);
            var sel = dirs.Where(d => Path.GetFileName(d.Path).Replace("/", "") == Path.GetFileName(directoryUri)).ToArray();
            return sel.Length > 0 ? sel[0] : null;
        }

        public async Task<RemoteDirectory> CreateDirectoryAsync(string directoryUri, string storageName = null)
        {
            var exists = await DirectoryExistsAsync(directoryUri, storageName);
            if (exists)
            {
                return await GetDirectoryAsync(directoryUri, storageName);
            }

            var apiInvoker = InvokerFactory.GetInvoker<RemoteDirectory>();
            await apiInvoker.CallPostAsync(
                RequestUrlBuilder.GetBuilder($"{FOLDER_URI}")
                    .WithPath(directoryUri)
                    .WithStorageName(storageName),
                new ByteArrayContent(new byte[] { }));

            return new RemoteDirectory(
                directoryUri,
                new RemoteFileSystemInfo(0L, DateTime.UtcNow));
        }

        public async Task<bool> DeleteDirectoryAsync(string directoryUri, string storageName = null, bool recursive = false)
        {
            var paramRecursive = recursive ? "true" : "";

            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            await apiInvoker.CallDeleteAsync(
                 RequestUrlBuilder.GetBuilder($"{FOLDER_URI}")
                     .WithStorageName(storageName)
                     .WithPath(directoryUri)
                     .WithParameter("recursive", paramRecursive));
            return true;
        }

        public async Task<RemoteDirectory> CopyDirectoryAsync(string srcDirectoryUri, string destDirectoryUri, string srcStorageName = null, string destStorageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            await apiInvoker.CallPutAsync(
                 RequestUrlBuilder.GetBuilder($"{FOLDER_URI}/copy")
                     .WithSourcePath(srcDirectoryUri)
                     .WithDestinationPath(destDirectoryUri)
                     .WithSourceStorage(srcStorageName)
                     .WithDestinationStorage(destStorageName), new ByteArrayContent(new byte[] { }));

            return new RemoteDirectory(destDirectoryUri, new RemoteFileSystemInfo(0, DateTime.MinValue));
        }

        public async Task<RemoteDirectory> MoveDirectoryAsync(string srcDirectoryUri, string destDirectoryUri, string srcStorageName = null, string destStorageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            await apiInvoker.CallPutAsync(
                 RequestUrlBuilder.GetBuilder($"{FOLDER_URI}/move")
                     .WithSourcePath(srcDirectoryUri)
                     .WithDestinationPath(destDirectoryUri)
                     .WithSourceStorage(srcStorageName)
                     .WithDestinationStorage(destStorageName), new ByteArrayContent(new byte[] { }));

            return new RemoteDirectory(destDirectoryUri, null);
        }

        #endregion

        #region File API

        internal async Task<bool> FileExistsAsync(string fileUri, string storageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = await apiInvoker.CallGetAsync(
                RequestUrlBuilder.GetBuilder($"{STORAGE_URI}/exist")
                    .WithStorageName(storageName)
                    .WithPath(fileUri));
            return !response.IsFolder && response.Exists;
        }

        internal async Task<IReadOnlyList<RemoteFile>> GetFilesAsync(string directoryUri, string storageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<FilesList>();
            var response = await apiInvoker.CallGetAsync(
                 RequestUrlBuilder.GetBuilder($"{FOLDER_URI}")
                     .WithStorageName(storageName)
                     .WithPath(directoryUri));

            var res = response.Value
                        .Where(f => f.IsFolder == false)
                        .Select(f => new RemoteFile(f.Path,
                            new RemoteFileSystemInfo(f.Size, f.ModifiedDate.GetValueOrDefault()))).ToImmutableList();
            return res;
        }

        internal async Task<RemoteFile> GetFileInfoAsync(string fileUri, string storageName = null)
        {
            var dir = Path.GetDirectoryName(fileUri);
            var resList = await GetFilesAsync(dir, storageName);
            if (resList != null)
            {
                var selected = resList.Where(f => Path.GetFileName(f.Path) == Path.GetFileName(fileUri)).ToArray();
                if (selected.Length > 0)
                {
                    var resFile = selected.First();
                    return resFile;
                }
            }
            return null;
        }

        internal async Task<RemoteFile> UploadFileAsync(string file, string remoteFileUri, string storageName = null)
        {
            var content = new MultipartFormDataContent();
            var bytes = File.ReadAllBytes(file);
            var uploadFileName = Path.GetFileName(remoteFileUri);
            content.Add(new ByteArrayContent(bytes), "file", uploadFileName);

            
            var uploadDir = remoteFileUri.Substring(0, remoteFileUri.LastIndexOf(uploadFileName, StringComparison.OrdinalIgnoreCase));

            return await await taskFactory.StartNew(async () =>
            {
                var apiInvoker = InvokerFactory.GetInvoker<FilesUploadResult>();
                var response = await apiInvoker.CallPostAsync(
                    RequestUrlBuilder.GetBuilder(FILE_URI)
                        .WithPath(uploadDir)
                        .WithStorageName(storageName), content);
                return new RemoteFile(response.Uploaded.First(), null);
            }, cancellationTokenSource.Token);

        }

        internal async Task<RemoteFile> UploadDataAsync(byte[] data, string fileUri, string storageName = null)
        {
            var content = new MultipartFormDataContent();
            var fileName = Path.GetFileName(fileUri);
            content.Add(new ByteArrayContent(data), "file", fileName);

            var uploadUri = StorageUtils.GetResourceUri(fileUri, storageName);
            var uploadDir = uploadUri.Substring(0, uploadUri.LastIndexOf(fileName, StringComparison.OrdinalIgnoreCase));

            return await await taskFactory.StartNew(async () =>
            {
                var apiInvoker = InvokerFactory.GetInvoker<FilesUploadResultEx>();
                var response = await apiInvoker.CallPostAsync(
                    RequestUrlBuilder.GetBuilder(FILE_URI)
                        .WithPath(uploadDir)
                        .WithStorageName(storageName), content);

                return new RemoteFile(response.Uploaded[0],
                    new RemoteFileSystemInfo(
                        response.UploadedInfo[0].Size,
                        response.UploadedInfo[0].ModifiedDate ?? DateTime.Now));

            }, cancellationTokenSource.Token);
        }

        public async Task DownloadFileAsync(string fileUri, string localFilePath,
            string storageName = null, IProgress<object> progressCallback = null)
        {
            var url = RequestUrlBuilder.GetBuilder(FILE_URI)
                .WithPath(fileUri)
                .WithStorageName(storageName).Build();

            await await taskFactory.StartNew(async () =>
            {

                var apiInvoker = InvokerFactory.GetInvoker<StreamResponse>();
                var response = await apiInvoker.CallGetAsStreamAsync(url, HttpCompletionOption.ResponseHeadersRead);

                try
                {
                    using (var outputStream = File.Create(localFilePath))
                    using (var wr = new BinaryWriter(outputStream))
                    using (var resourceStream = response.Stream)
                    {
                        var buffer = new byte[4096];
                        int readBytes;
                        var totalBytes = response.StreamLength;
                        long totalRead = 0;

                        while ((readBytes = await resourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                        {
                            totalRead += readBytes;
                            if (cancellationTokenSource.IsCancellationRequested)
                            {
                                // set Cancel status
                                //res.Status
                                break;
                            }

                            progressCallback?.Report(new ProgressData { ProcessedBytes = totalRead, TotalBytes = totalBytes });
                            wr.Write(buffer, 0, readBytes);
                        }
                        wr.Flush();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }, cancellationTokenSource.Token);
        }

        internal async Task<byte[]> DownloadDataAsync(string fileUri,
            string storageName = null,
            IProgress<ProgressData> progressCallback = null)
        {

            var url = RequestUrlBuilder.GetBuilder(FILE_URI)
                .WithPath(fileUri)
                .WithStorageName(storageName).Build();

            return await await taskFactory.StartNew(async () =>
            {

                var apiInvoker = InvokerFactory.GetInvoker<StreamResponse>();
                var response = await apiInvoker.CallGetAsStreamAsync(url, HttpCompletionOption.ResponseHeadersRead);

                using (var outputStream = new MemoryStream())
                using (var wr = new BinaryWriter(outputStream))
                using (var resourceStream = response.Stream)
                {
                    var buffer = new byte[4096];
                    int readBytes;
                    var totalBytes = response.StreamLength;
                    long totalRead = 0;

                    while ((readBytes = await resourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        totalRead += readBytes;
                        if (cancellationTokenSource.IsCancellationRequested)
                        {
                            break;
                        }

                        progressCallback?.Report(new ProgressData { ProcessedBytes = totalRead, TotalBytes = totalBytes });
                        wr.Write(buffer, 0, readBytes);
                    }
                    wr.Flush();
                    return outputStream.ToArray();
                }
            }, cancellationTokenSource.Token);
        }

        internal async Task<Stream> OpenReadAsync(string fileUri, string storageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<Stream>();
            var url = RequestUrlBuilder.GetBuilder(FILE_URI)
                .WithPath(fileUri)
                .WithStorageName(storageName).Build();
            return (await apiInvoker.CallGetAsStreamAsync(url)).Stream;
        }

        internal async Task<bool> DeleteFileAsync(string fileUri, string storageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            await apiInvoker.CallDeleteAsync(
                 RequestUrlBuilder.GetBuilder($"{FILE_URI}")
                     .WithStorageName(storageName)
                     .WithPath(fileUri));

            return !await FileExistsAsync(fileUri, storageName);
        }

        internal async Task<RemoteFile> CopyFileAsync(string srcFileUri, string destFileUri, string srcStorageName = null, string destStorageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            await apiInvoker.CallPutAsync(
                 RequestUrlBuilder.GetBuilder($"{FILE_URI}/copy")
                     .WithSourcePath(srcFileUri)
                     .WithDestinationPath(destFileUri)
                     .WithSourceStorage(srcStorageName)
                     .WithDestinationStorage(destStorageName), new ByteArrayContent(new byte[] { }));
            return new RemoteFile(destFileUri, null);
        }

        internal async Task<RemoteFile> MoveFileAsync(string srcFileUri, string destFileUri, string srcStorageName = null, string destStorageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            await apiInvoker.CallPutAsync(
                 RequestUrlBuilder.GetBuilder($"{FILE_URI}/move")
                     .WithSourcePath(srcFileUri)
                     .WithDestinationPath(destFileUri)
                     .WithSourceStorage(srcStorageName)
                     .WithDestinationStorage(destStorageName), new ByteArrayContent(new byte[] { }));

            return new RemoteFile(destFileUri, null);
        }

        #endregion
    }
}
