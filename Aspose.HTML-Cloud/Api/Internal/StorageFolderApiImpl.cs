using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Newtonsoft.Json;

namespace Aspose.Html.Cloud.Sdk.Api.Internal
{
    internal class StorageFolderApiImpl : ApiImplBase, IStorageFolderApi
    {
        public StorageFolderApiImpl(ApiClient apiClient) : base(apiClient)
        {
        }

        public List<StorageItem> GetFolderContentList(string path, string storage = null)
        {
            var methodName = "GetFolderList";
            // verify the required parameter 'path' is set
            if (path == null) throw new ApiException(400, $"Missing required parameter 'path' when calling {methodName}");

            if (path.First<char>() == '/')
                path = path.Substring(1, path.Length - 1);
            var apiPath = $"/html/storage/folder/{path}";

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(apiPath, queryParams, methodName);
            string content = null;
            using (StreamReader rdr = new StreamReader(response.ContentStream))
            {
                content = rdr.ReadToEnd();
            }
            var listResp = JsonConvert.DeserializeObject<StorageItemList>(content);          
            return listResp.ItemList;
        } 

        public AsposeResponse CreateFolder(string path, string storage = null)
        {
            var methodName = "CreateFolder";
            // verify the required parameter 'path' is set
            if (path == null) throw new ApiException(400, $"Missing required parameter 'path' when calling {methodName}");

            if (path.First<char>() == '/')
                path = path.Substring(1, path.Length - 1);
            var apiPath = $"/html/storage/folder/{path}";

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter
            headerParams.Add("Content-Length", "0");

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(apiPath, queryParams, headerParams, null, methodName);
            return response;
        }


        public AsposeResponse CopyFolder(string srcPath, string destPath, string srcStorage = null, string destStorage = null)
        {
            var methodName = "CopyFolder";
            // verify the required parameter 'srcPath' is set
            if (srcPath == null) throw new ApiException(400, $"Missing required parameter 'srcPath' when calling {methodName}");
            // verify the required parameter 'destPath' is set
            if (destPath == null) throw new ApiException(400, $"Missing required parameter 'destPath' when calling {methodName}");

            if (srcPath.First<char>() == '/')
                srcPath = srcPath.Substring(1, srcPath.Length - 1);
            var apiPath = $"/html/storage/folder/copy/{srcPath}";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("destPath", ApiClientUtils.ParameterToString(destPath)); // query parameter
            if (srcStorage != null) queryParams.Add("srcStorageName", ApiClientUtils.ParameterToString(srcStorage)); // query parameter
            if (destStorage != null) queryParams.Add("destStorageName", ApiClientUtils.ParameterToString(destStorage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(apiPath, queryParams, headerParams, null, methodName);
            return response;
        }

        public AsposeResponse DeleteFolder(string path, string storage = null, bool recursive = false)
        {
            var methodName = "DeleteFolder";
            // verify the required parameter 'path' is set
            if (path == null) throw new ApiException(400, $"Missing required parameter 'path' when calling {methodName}");

            if (path.First<char>() == '/')
                path = path.Substring(1, path.Length - 1);
            var apiPath = $"/html/storage/folder/{path}";

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storage", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallDeleteApi(apiPath, queryParams, methodName);
            return response;
        }

        public AsposeResponse MoveFolder(string srcPath, string destPath, string srcStorage = null, string destStorage = null)
        {
            var methodName = "MoveFolder";
            // verify the required parameter 'srcPath' is set
            if (srcPath == null) throw new ApiException(400, $"Missing required parameter 'srcPath' when calling {methodName}");
            // verify the required parameter 'destPath' is set
            if (destPath == null) throw new ApiException(400, $"Missing required parameter 'destPath' when calling {methodName}");

            if (srcPath.First<char>() == '/')
                srcPath = srcPath.Substring(1, srcPath.Length - 1);
            var apiPath = $"/html/storage/folder/move/{srcPath}";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("destPath", ApiClientUtils.ParameterToString(destPath)); // query parameter
            if (srcStorage != null) queryParams.Add("srcStorageName", ApiClientUtils.ParameterToString(srcStorage)); // query parameter
            if (destStorage != null) queryParams.Add("destStorageName", ApiClientUtils.ParameterToString(destStorage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(apiPath, queryParams, headerParams, null, methodName);
            return response;
        }
    }
}
