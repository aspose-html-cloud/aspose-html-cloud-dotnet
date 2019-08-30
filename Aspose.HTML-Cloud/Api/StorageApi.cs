// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="StorageApi.cs">
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Internal;
using Aspose.Html.Cloud.Sdk.Client;

namespace Aspose.Html.Cloud.Sdk.Api
{
    /// <summary>
    /// Facade class providing wrapper methods of Aspose.Storage Cloud REST API
    /// </summary>
    public class StorageApi : ApiBase, 
        IStorageFileApi, 
        IStorageFolderApi,
        IStorageApi
    {
        #region Private members

        private IStorageApi m_storageApiImpl;
        private IStorageFileApi m_storageFileApiImpl;
        private IStorageFolderApi m_storageFolderApiImpl;
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor. Initalizes a new instance of StorageApi class trying to get the user credentials
        /// (application SID and application key), REST API service URL and authentication service URL 
        /// from the application configuration file and then, if it don't succeed, from environment variables.
        /// If needed settings were not found both in the config file or in the environment variables, throws an exception.   
        /// </summary>
        public StorageApi() : base()
        { }

        /// <summary>
        /// Constructor. Initalizes a new instance StorageApi class as the default constructor does
        /// and sets the service connection timeout.
        /// </summary>
        /// <param name="timeout">Service connection timeout</param>
        public StorageApi(TimeSpan timeout) : base(timeout)
        { }

        /// <summary>
        /// Constructor. Initalizes a new instance of StorageApi class with specified user credentials (application SID and application key),
        /// and REST API service URL; by default, authentication service URL is the same.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        public StorageApi(string appSid, string appKey, string basePath) : base(appSid, appKey, basePath)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of StorageApi class with specified user credentials (application SID and application key),
        /// REST API service URL and authentication service URL.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="authPath">Authorization service URL</param>
        public StorageApi(string appSid, string appKey, string basePath, string authPath) : base(appSid, appKey, basePath, authPath)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of StorageApi class with specified user credentials (application SID and application key),
        /// REST API service URL and service connection timeout; by default, authentication service URL is the same.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="timeout">Connection timeout</param>
        public StorageApi(string appSid, string appKey, string basePath, TimeSpan timeout) : base(appSid, appKey, basePath, timeout)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of StorageApi class with specified user credentials (application SID and application key),
        /// REST API service URL, authentication service URL and service connection timeout.
        /// </summary>
        /// <param name="appSid">Application SID (client ID)</param>
        /// <param name="appKey">Application key (client secret)</param>
        /// <param name="basePath">REST API service URL</param>
        /// <param name="authPath">Authorization service URL</param>
        /// <param name="timeout">Connection timeout</param>
        public StorageApi(string appSid, string appKey, string basePath, string authPath, TimeSpan timeout) : base(appSid, appKey, basePath, authPath, timeout)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of StorageApi class with Configuration object.
        /// </summary>
        /// <param name="config">Configuration object</param>
        public StorageApi(Configuration config) : base(config)
        { }

        /// <summary>
        /// Constructor. Initalizes a new instance of StorageApi class inheriting ApiClient object
        /// of existing ApiBase descendant class instance, so authorization data become shared between both instances.
        /// </summary>
        /// <param name="instance">Existing ApiBase inherited class instance</param>
        public StorageApi(ApiBase instance) : base(instance)
        { }

        #endregion

        #region Private properties - API implementation accessors

        private IStorageApi StorageApiImpl
        {
            get
            {
                if(m_storageApiImpl == null)
                {
                    m_storageApiImpl = new StorageApiImpl(ApiClient);
                }
                return m_storageApiImpl;
            }
        }

        private IStorageFileApi StorageFileApiImpl
        {
            get
            {
                if(m_storageFileApiImpl == null)
                {
                    m_storageFileApiImpl = new StorageFileApiImpl(ApiClient);
                }
                return m_storageFileApiImpl;
            }
        }

        private IStorageFolderApi StorageFolderApiImpl
        {
            get
            {
                if(m_storageFolderApiImpl == null)
                {
                    m_storageFolderApiImpl = new StorageFolderApiImpl(ApiClient);
                }
                return m_storageFolderApiImpl;
            }
        }

        #endregion

        #region IStorageFile interface implementation

        /// <summary>
        /// Download file from storage.
        /// </summary>
        /// <param name="path">File path, e.g. /folder/filename.ext </param>
        /// <param name="storage">Storage name.</param>
        /// <param name="versionId">File version ID to download; the last version by default.</param>
        /// <returns>StreamResponse | File stream.</returns>
        public StreamResponse DownloadFile(string path, string storage = null, string versionId = null)
        {
            return StorageFileApiImpl.DownloadFile(path, storage, versionId);
        }

        /// <summary>
        /// Upload stream to a storage file.
        /// </summary>
        /// <param name="stream">File stream to upload.</param>
        /// <param name="path">Storage path </param>
        /// <param name="storage">Storage name.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        public AsposeResponse UploadFile(Stream stream, string path, string storage = null)
        {
            return StorageFileApiImpl.UploadFile(stream, path, storage);
        }

        /// <summary>
        /// Overridden. Upload file from the local file system to storage.
        /// </summary>
        /// <param name="localPath">Local file system path.</param>
        /// <param name="path">Path to upload, e.g. /folder/file.ext </param>
        /// <param name="storage">Storage name.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        public AsposeResponse UploadFile(string localPath, string path, string storage = null)
        {
            return StorageFileApiImpl.UploadFile(localPath, path, storage);
        }

        /// <summary>
        /// Delete file from storage.
        /// </summary>
        /// <param name="path">File path, e.g. /folder/file.ext </param>
        /// <param name="storage">Storage name.</param>
        /// <param name="versionId">File version ID to delete; the last version by default.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        public AsposeResponse DeleteFile(string path, string storage = null, string versionId = null)
        {
            return StorageFileApiImpl.DeleteFile(path, storage, versionId);
        }

        /// <summary>
        /// Copy storage file.
        /// </summary>
        /// <param name="srcPath">Source file path.</param>
        /// <param name="destPath">Destination file path.</param>
        /// <param name="srcStorage">Source storage name.</param>
        /// <param name="destStorage">Destination storage name.</param>
        /// <param name="versionId">File version ID to copy; the last version by default.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        public AsposeResponse CopyFile(string srcPath, string destPath, string srcStorage = null, string destStorage = null, string versionId = null)
        {
            return StorageFileApiImpl.CopyFile(srcPath, destPath, srcStorage, destStorage, versionId);
        }

        /// <summary>
        /// Move storage file
        /// </summary>
        /// <param name="srcPath">Source file path.</param>
        /// <param name="destPath">Destination file path.</param>
        /// <param name="srcStorage">Source storage name.</param>
        /// <param name="destStorage">Destination storage name.</param>
        /// <param name="versionId">File version ID to copy; the last version by default.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        public AsposeResponse MoveFile(string srcPath, string destPath, string srcStorage = null, string destStorage = null, string versionId = null)
        {
            return StorageFileApiImpl.MoveFile(srcPath, destPath, srcStorage, destStorage, versionId);
        }

        #endregion

        #region IStorageFolder interface implementation

        /// <summary>
        /// Get all files and folders within a specified folder.
        /// </summary>
        /// <param name="path">Folder path, e.g. /folder1/folder2</param>
        /// <param name="storage">Storage name.</param>
        /// <returns>StorageItemListResponse | List of items in the folder.</returns>
        public List<StorageItem> GetFolderContentList(string path, string storage = null)
        {
            return StorageFolderApiImpl.GetFolderContentList(path, storage);
        }

        /// <summary>
        /// Create folder.
        /// </summary>
        /// <param name="path">Folder path, e.g. /folder1/folder2 </param>
        /// <param name="storage">Storage name.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        public AsposeResponse CreateFolder(string path, string storage = null)
        {
            return StorageFolderApiImpl.CreateFolder(path, storage);
        }

        /// <summary>
        /// Delete folder.
        /// </summary>
        /// <param name="path">Folder path, e.g. /folder1/folder2 </param>
        /// <param name="storage">Storage name.</param>
        /// <param name="recursive">Enable to delete files and subfolders, if folder is not empty.</param>
        public AsposeResponse DeleteFolder(string path, string storage = null, bool recursive = false)
        {
            return StorageFolderApiImpl.DeleteFolder(path, storage, recursive);
        }

        /// <summary>
        /// Copy folder with files and subfolders.
        /// </summary>
        /// <param name="srcPath">Source folder path, e.g. /src </param>
        /// <param name="destPath">Destination folder path, e.g. /dst </param>
        /// <param name="srcStorage">Source storage name.</param>
        /// <param name="destStorage">Destination storage name.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        public AsposeResponse CopyFolder(string srcPath, string destPath, string srcStorage = null, string destStorage = null)
        {
            return StorageFolderApiImpl.CopyFolder(srcPath, destPath, srcStorage, destStorage);
        }

        /// <summary>
        /// Move folder with files and subfolders.
        /// </summary>
        /// <param name="srcPath">Source folder path, e.g. /src </param>
        /// <param name="destPath">Destination folder path, e.g. /dst </param>
        /// <param name="srcStorage">Source storage name.</param>
        /// <param name="destStorage">Destination storage name.</param>
        /// <returns>AsposeResponse | Operation status.</returns>
        public AsposeResponse MoveFolder(string srcPath, string destPath, string srcStorage = null, string destStorage = null)
        {
            return StorageFolderApiImpl.MoveFolder(srcPath, destPath, srcStorage, destStorage);
        }

        #endregion

        #region IStorage interface implementation 

        /// <summary>
        /// Check if specified storage exists
        /// </summary>
        /// <param name="storage">Storage name.</param>
        /// <returns></returns>
        public bool StorageExists(string storage)
        {
            return StorageApiImpl.StorageExists(storage);
        }

        /// <summary>
        /// Check if specified file or folder exists
        /// </summary>
        /// <param name="path">Object path, e.g. /folder1/folder2/file.ext or /folder</param>
        /// <param name="storage">Storage name.</param>
        /// <param name="versionId">File version ID (ignored for folders)</param>
        /// <returns></returns>
        public bool FileOrFolderExists(string path, string storage = null, string versionId = null)
        {
            return StorageApiImpl.FileOrFolderExists(path, storage, versionId);
        }

        /// <summary>
        /// Returns the disc usage.
        /// </summary>
        /// <param name="storage">Storage name.</param>
        /// <returns></returns>
        public DiscUsage GetDiscUsage(string storage = null)
        {
            return StorageApiImpl.GetDiscUsage(storage);
        }

        /// <summary>
        /// Returns list of specified file versions.
        /// </summary>
        /// <param name="path">File path, e.g. /folder/file.ext </param>
        /// <param name="storage">Storage name.</param>
        /// <returns></returns>
        public List<StorageItemVersion> GetStorageItemVersions(string path, string storage = null)
        {
            return StorageApiImpl.GetStorageItemVersions(path, storage);
        }

        #endregion
    }
}
