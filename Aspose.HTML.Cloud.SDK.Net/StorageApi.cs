using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.IO;
using Aspose.HTML.Cloud.Sdk.Models;
using Aspose.HTML.Cloud.Sdk.Runtime;
using Aspose.HTML.Cloud.Sdk.Services;

namespace Aspose.HTML.Cloud.Sdk
{
    /// <summary>
    /// API for manipulations with files and directories
    /// </summary>
    public class StorageApi
    {
        private readonly StorageService storageService;

        internal StorageApi(Configuration config)
        {
            storageService = new StorageService(new ApiInvokerFactory(config));
        }

        /// <summary>
        /// Checks if specified cloud storage exists or is available for the user
        /// </summary>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(string storageName)
        {
            return await storageService.ExistsAsync(storageName);
        }

        /// <summary>
        /// Gets storage info by specified storage name, including total and used disc space 
        /// </summary>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<Storage> GetStorageAsync(string storageName)
        {
            return await storageService.GetStorageAsync(storageName);
        }


        #region Directory API

        /// <summary>
        /// Checks if a directory specified by the path exists in the specified or default storage
        /// </summary>
        /// <param name="directoryUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<bool> DirectoryExistsAsync(string directoryUri, string storageName = null)
        {
            return await storageService.DirectoryExistsAsync(directoryUri, storageName);
        }


        /// <summary>
        /// Gets a list of directories that are direct children of the specified directory in the specified or default storage. 
        /// </summary>
        /// <param name="rootDirectoryUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<RemoteDirectory>> GetDirectoriesAsync(string rootDirectoryUri, string storageName = null)
        {
            return await storageService.GetDirectoriesAsync(rootDirectoryUri, storageName);
        }

        /// <summary>
        /// Get a specified directory info, or null, if the directory doesn't exist.
        /// </summary>
        /// <param name="directoryUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<RemoteDirectory> GetDirectoryAsync(string directoryUri, string storageName = null)
        {
            return await storageService.GetDirectoryAsync(directoryUri, storageName);
        }

        /// <summary>
        /// Creates a directory in the specified or default storage; 
        /// all parent directories specified in the directoryUri path will be created too if they don't exist.  
        /// </summary>
        /// <param name="directoryUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<RemoteDirectory> CreateDirectoryAsync(string directoryUri, string storageName = null)
        {
            return await storageService.CreateDirectoryAsync(directoryUri, storageName);
        }

        /// <summary>
        /// Deletes a directory by the specified path from the specified or default storage.
        /// </summary>
        /// <param name="directoryUri"></param>
        /// <param name="storageName"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDirectoryAsync(string directoryUri, string storageName = null, bool recursive = false)
        {
            return await storageService.DeleteDirectoryAsync(directoryUri, storageName, recursive);
        }

        /// <summary>
        /// Copies a directory.
        /// </summary>
        /// <param name="srcDirectoryUri"></param>
        /// <param name="destDirectoryUri"></param>
        /// <param name="srcStorageName"></param>
        /// <param name="destStorageName"></param>
        /// <returns></returns>
        public async Task<RemoteDirectory> CopyDirectoryAsync(string srcDirectoryUri, string destDirectoryUri, string srcStorageName = null, string destStorageName = null)
        {
            return await storageService.CopyDirectoryAsync(srcDirectoryUri, destDirectoryUri, srcStorageName, destStorageName);
        }

        /// <summary>
        /// Moves a directory.
        /// </summary>
        /// <param name="srcDirectoryUri"></param>
        /// <param name="destDirectoryUri"></param>
        /// <param name="srcStorageName"></param>
        /// <param name="destStorageName"></param>
        /// <returns></returns>
        public async Task<RemoteDirectory> MoveDirectoryAsync(string srcDirectoryUri, string destDirectoryUri, string srcStorageName = null, string destStorageName = null)
        {
            return await storageService.MoveDirectoryAsync(srcDirectoryUri, destDirectoryUri, srcStorageName, destStorageName);
        }

        #endregion

        #region File API

        /// <summary>
        /// Checks if a file specified by the path exists in the specified or default storage
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<bool> FileExistsAsync(string fileUri, string storageName = null)
        {
            return await storageService.FileExistsAsync(fileUri, storageName);
        }


        /// <summary>
        /// Gets a list of files by specified directory path in the specified or default storage.
        /// </summary>
        /// <param name="directoryUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<RemoteFile>> GetFilesAsync(string directoryUri, string storageName = null)
        {
            return await storageService.GetFilesAsync(directoryUri, storageName);
        }

        /// <summary>
        /// Gets the file info by its path in the specified or default storage. 
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<RemoteFile> GetFileInfoAsync(string fileUri, string storageName = null)
        {
            return await storageService.GetFileInfoAsync(fileUri, storageName);
        }

        /// <summary>
        /// Starts asynchronous upload of a file by its local file system path to the specified storage.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="remoteFileUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<RemoteFile> UploadFileAsync(string file, string remoteFileUri, string storageName = null)
        {
            return await storageService.UploadFileAsync(file, remoteFileUri, storageName);
        }


        /// <summary>
        /// Starts asynchronous upload of a byte array as a file into storage.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<RemoteFile> UploadDataAsync(byte[] data, string fileUri, string storageName = null)
        {
            return await storageService.UploadDataAsync(data, fileUri, storageName);
        }

        /// <summary>
        /// Starts asynchronous download of a storage file into a local file.
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="localFilePath"></param>
        /// <param name="storageName"></param>
        /// <param name="progressCallback"></param>
        /// <returns></returns>
        public async Task DownloadFileAsync(string fileUri, string localFilePath,
            string storageName = null, IProgress<object> progressCallback = null)
        {
            await storageService.DownloadFileAsync(fileUri, localFilePath, storageName, progressCallback);
        }

        /// <summary>
        /// Starts asynchronous download of a storage file into a byte array.
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <param name="progressCallback"></param>
        /// <returns></returns>
        public async Task<byte[]> DownloadDataAsync(string fileUri,
            string storageName = null,
            IProgress<ProgressData> progressCallback = null)
        {
            return await storageService.DownloadDataAsync(fileUri, storageName, progressCallback);
        }

        /// <summary>
        /// Opens to read a stream associated with a storage file specified by its path in the specified or default storage.
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<Stream> OpenReadAsync(string fileUri, string storageName = null)
        {
            return await storageService.OpenReadAsync(fileUri, storageName);
        }

        /// <summary>
        /// Deletes a storage file by its path from the specified or default storage.
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public async Task<bool> DeleteFileAsync(string fileUri, string storageName = null)
        {
            return await storageService.DeleteFileAsync(fileUri, storageName);
        }

        #endregion
    }
}
