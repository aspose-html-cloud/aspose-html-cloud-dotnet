
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
    public class StorageApi : ApiBase, IStorageFileApi, IStorageFolderApi
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSid"></param>
        /// <param name="appKey"></param>
        /// <param name="basePath"></param>
        public StorageApi(string appSid, string appKey, string basePath) : base(appSid, appKey, basePath)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSid"></param>
        /// <param name="appKey"></param>
        /// <param name="basePath"></param>
        /// <param name="authPath"></param>
        public StorageApi(string appSid, string appKey, string basePath, string authPath) : base(appSid, appKey, basePath, authPath)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSid"></param>
        /// <param name="appKey"></param>
        /// <param name="basePath"></param>
        /// <param name="timeout"></param>
        public StorageApi(string appSid, string appKey, string basePath, TimeSpan timeout) : base(appSid, appKey, basePath, timeout)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSid"></param>
        /// <param name="appKey"></param>
        /// <param name="basePath"></param>
        /// <param name="authPath"></param>
        /// <param name="timeout"></param>
        public StorageApi(string appSid, string appKey, string basePath, string authPath, TimeSpan timeout) : base(appSid, appKey, basePath, authPath, timeout)
        {
        }

        /// <summary>
        /// Constructor. Initalizes a new instance of StorageApi class with Configuration object.
        /// </summary>
        /// <param name="config"></param>
        public StorageApi(Configuration config) : base(config)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public StorageApi(ApiBase instance) : base(instance)
        { }

        #endregion

        #region IStorageFile interface implementation


        public AsposeStreamResponse DownloadFile(string path, string storage = null, string versionId = null)
        {
            throw new NotImplementedException();
        }

        public AsposeResponse UploadFile(Stream stream, string path, string storage = null)
        {
            throw new NotImplementedException();
        }

        public AsposeResponse UploadFile(string localPath, string path, string storage = null)
        {
            throw new NotImplementedException();
        }

        public AsposeResponse DeleteFile(string path, string storage = null, string versionId = null)
        {
            throw new NotImplementedException();
        }

        public AsposeResponse CopyFile(string srcPath, string destPath, string srcStorage = null, string destStorage = null, string versionId = null)
        {
            throw new NotImplementedException();
        }

        public AsposeResponse MoveFile(string srcPath, string destPath, string srcStorage = null, string destStorage = null, string versionId = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IStorageFolder interface implementation

        public AsposeResponse GetFolderList(string path, string storage = null)
        {
            throw new NotImplementedException();
        }

        public AsposeResponse CreateFolder(string path, string storage = null)
        {
            throw new NotImplementedException();
        }

        public AsposeResponse DeleteFolder(string path, string storage = null, bool recursive = false)
        {
            throw new NotImplementedException();
        }

        public AsposeResponse CopyFolder(string srcPath, string destPath, string srcStorage = null, string destStorage = null)
        {
            throw new NotImplementedException();
        }

        public AsposeResponse MoveFolder(string srcPath, string destPath, string srcStorage = null, string destStorage = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IStorage interface implementation 

        #endregion
    }
}
