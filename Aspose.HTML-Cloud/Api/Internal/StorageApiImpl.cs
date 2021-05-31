using System;
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
    class StorageApiImpl : ApiImplBase, IStorageApi
    {
        public StorageApiImpl(ApiClient apiClient) : base(apiClient)
        {
        }

        public bool StorageExists(string storage)
        {
            var methodName = "StorageExists";
            // verify the required parameter 'storage' is set
            if (storage == null) throw new ApiException(400, $"Missing required parameter 'storage' when calling {methodName}");

            var apiPath = $"/html/storage/{storage}/exist";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var response = CallGetApi(apiPath, queryParams, methodName);
            var strContent = response.ContentAsString;
            if (!string.IsNullOrEmpty(strContent))
            {
                var dictResp = JsonConvert.DeserializeObject<Dictionary<string, object>>(strContent);
                if (dictResp.ContainsKey("exists"))
                    return bool.Parse(dictResp["exists"].ToString());
            }
            return false;
        }

        public bool FileOrFolderExists(string path, string storage = null, string versionId = null)
        {
            var methodName = "FileOrFolderExists";
            // verify the required parameter 'path' is set
            if (path == null) throw new ApiException(400, $"Missing required parameter 'path' when calling {methodName}");

            if (path.First<char>() == '/')
                path = path.Substring(1, path.Length - 1);
            var apiPath = $"/html/storage/exist/{path}";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storageName", ApiClientUtils.ParameterToString(storage)); // query parameter
            if (versionId != null) queryParams.Add("versionId", ApiClientUtils.ParameterToString(versionId)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(apiPath, queryParams, methodName);
            var strContent = response.ContentAsString;
            if(!string.IsNullOrEmpty(strContent))
            {
                var dictResp = JsonConvert.DeserializeObject<Dictionary<string, object>>(strContent);
                if (dictResp.ContainsKey("exists"))
                    return bool.Parse(dictResp["exists"].ToString());
            }
            return false;
        }

        public DiscUsage GetDiscUsage(string storage = null)
        {
            var methodName = "GetDiscUsage";
            // verify the required parameter 'path' is set
            if (storage == null) throw new ApiException(400, $"Missing required parameter 'storage' when calling {methodName}");

            var apiPath = $"/html/storage/disc";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storageName", ApiClientUtils.ParameterToString(storage)); // query parameter
                     
            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(apiPath, queryParams, methodName);
            var jsonContent = response.ContentAsString;
            if(jsonContent != null)
            {
                DiscUsage res = JsonConvert.DeserializeObject<DiscUsage>(jsonContent);
                return res;
            }
            return null;
        }

        public List<StorageItemVersion> GetStorageItemVersions(string path, string storage = null)
        {
            var methodName = "GetStorageItemVersions";
            // verify the required parameter 'path' is set
            if (path == null) throw new ApiException(400, $"Missing required parameter 'path' when calling {methodName}");

            if (path.First<char>() == '/')
                path = path.Substring(1, path.Length - 1);
            var apiPath = $"/html/storage/version/{path}";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            var response = CallGetApi(apiPath, queryParams, methodName);
            var jsonContent = response.ContentAsString;
            if (!string.IsNullOrEmpty(jsonContent))
            {
                var list = JsonConvert.DeserializeObject<StorageItemVersionList>(jsonContent);
                return list.VersionList;
            }
            return null;
        }
    }
}
