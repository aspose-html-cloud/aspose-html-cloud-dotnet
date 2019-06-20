using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;


namespace Aspose.Html.Cloud.Sdk.Api.Internal
{
    internal class StorageFileApiImpl : ApiImplBase, IStorageFileApi
    {
        public StorageFileApiImpl(ApiClient apiClient) : base(apiClient)
        {
        }

        public AsposeStreamResponse DownloadFile(string path, string storage = null, string versionId = null)
        {
            var methodName = "DownloadFile";
            throw new NotImplementedException();
        }

        public AsposeResponse UploadFile(Stream stream, string path, string storage = null)
        {
            var methodName = "UploadFile";
            throw new NotImplementedException();
        }

        public AsposeResponse UploadFile(string localPath, string path, string storage = null)
        {
            var methodName = "UploadFile";
            throw new NotImplementedException();
        }

        public AsposeResponse CopyFile(string srcPath, string destPath, string srcStorage = null, string destStorage = null, string versionId = null)
        {
            var methodName = "CopyFile";
            throw new NotImplementedException();
        }

        public AsposeResponse DeleteFile(string path, string storage = null, string versionId = null)
        {
            var methodName = "DeleteFile";
            throw new NotImplementedException();
        }



        public AsposeResponse MoveFile(string srcPath, string destPath, string srcStorage = null, string destStorage = null, string versionId = null)
        {
            var methodName = "MoveFile";
            throw new NotImplementedException();
        }


    }
}
