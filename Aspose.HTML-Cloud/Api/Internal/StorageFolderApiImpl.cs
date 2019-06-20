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
    internal class StorageFolderApiImpl : ApiImplBase, IStorageFolderApi
    {
        public StorageFolderApiImpl(ApiClient apiClient) : base(apiClient)
        {
        }

        public AsposeResponse GetFolderList(string path, string storage = null)
        {
            var methodName = "GetFolderList";
            // verify the required parameter 'name' is set
            if (path == null) throw new ApiException(400, $"Missing required parameter 'name' when calling {methodName}");

            var urlPath = $"/html/storage/folder/{ApiClientUtils.ParameterToString(path)}";

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(path, queryParams, methodName);
            return response;
        }

        public AsposeResponse CreateFolder(string path, string storage = null)
        {
            var methodName = "CreateFolder";
            throw new NotImplementedException();
        }


        public AsposeResponse CopyFolder(string srcPath, string destPath, string srcStorage = null, string destStorage = null)
        {
            var methodName = "CopyFolder";
            throw new NotImplementedException();
        }

        public AsposeResponse DeleteFolder(string path, string storage = null, bool recursive = false)
        {
            var methodName = "DeleteFolder";
            throw new NotImplementedException();
        }

        public AsposeResponse MoveFolder(string srcPath, string destPath, string srcStorage = null, string destStorage = null)
        {
            var methodName = "MoveFolder";
            throw new NotImplementedException();
        }
    }
}
