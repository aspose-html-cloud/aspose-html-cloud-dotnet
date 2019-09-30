// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="StorageFileApiImpl.cs">
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

        public StreamResponse DownloadFile(string path, string storage = null, string versionId = null)
        {
            var methodName = "DownloadFile";
            // verify the required parameter 'path' is set
            if (path == null) throw new ApiException(400, $"Missing required parameter 'path' when calling {methodName}");

            if (path.First<char>() == '/')
                path = path.Substring(1, path.Length - 1);
            var apiPath = $"/html/storage/file/{path}";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storageName", ApiClientUtils.ParameterToString(storage)); // query parameter
            if (versionId != null) queryParams.Add("versionId", ApiClientUtils.ParameterToString(versionId)); // query parameter
            
            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallGetApi(apiPath, queryParams, methodName);
            return response;
        }

        public AsposeResponse UploadFile(Stream stream, string path, string storage = null)
        {
            var methodName = "UploadFile";
            // verify the required parameter 'path' is set
            if (path == null) throw new ApiException(400, $"Missing required parameter 'path' when calling {methodName}");
            // verify the required parameter 'stream' is set
            if (stream == null) throw new ApiException(400, $"Missing required parameter 'stream' when calling {methodName}");

            if (path.First<char>() == '/')
                path = path.Substring(1, path.Length - 1);
            var apiPath = $"/html/storage/file/{path}";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            if (storage != null) queryParams.Add("storageName", ApiClientUtils.ParameterToString(storage)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(apiPath, queryParams, headerParams, stream, methodName);
            return response;
        }

        public AsposeResponse UploadFile(string localPath, string path, string storage = null)
        {
            var methodName = "UploadFile";
            // verify the required parameter 'localPath' is set
            if (localPath == null) throw new ApiException(400, $"Missing required parameter 'localPath' when calling {methodName}");
            if(!File.Exists(localPath))
                throw new ApiException(400, $"'{localPath}' file doesn't exist - error when calling {methodName}");

            using (Stream fstr = File.Open(localPath, FileMode.Open, FileAccess.Read))
            {
                MemoryStream mstr = new MemoryStream();
                fstr.CopyTo(mstr);
                mstr.Position = 0;
                return UploadFile(mstr, path, storage);
            }
        }
        public AsposeResponse CopyFile(string srcPath, string destPath, string srcStorage = null, string destStorage = null, string versionId = null)
        {
            var methodName = "CopyFile";
            // verify the required parameter 'srcPath' is set
            if (srcPath == null) throw new ApiException(400, $"Missing required parameter 'srcPath' when calling {methodName}");
            // verify the required parameter 'destPath' is set
            if (destPath == null) throw new ApiException(400, $"Missing required parameter 'destPath' when calling {methodName}");

            if (srcPath.First<char>() == '/')
                srcPath = srcPath.Substring(1, srcPath.Length - 1);
            var apiPath = $"/html/storage/file/copy/{srcPath}";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("destPath", ApiClientUtils.ParameterToString(destPath)); // query parameter
            if (srcStorage != null) queryParams.Add("srcStorageName", ApiClientUtils.ParameterToString(srcStorage)); // query parameter
            if (destStorage != null) queryParams.Add("destStorageName", ApiClientUtils.ParameterToString(destStorage)); // query parameter
            if (versionId != null) queryParams.Add("versionId", ApiClientUtils.ParameterToString(versionId)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(apiPath, queryParams, headerParams, null, methodName);
            return response;
        }

        public AsposeResponse DeleteFile(string path, string storage = null, string versionId = null)
        {
            var methodName = "DeleteFile";
            // verify the required parameter 'path' is set
            if (path == null) throw new ApiException(400, $"Missing required parameter 'path' when calling {methodName}");

            if (path.First<char>() == '/')
                path = path.Substring(1, path.Length - 1);
            var apiPath = $"/html/storage/file/{path}";

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            if (storage != null) queryParams.Add("storageName", ApiClientUtils.ParameterToString(storage)); // query parameter
            if (versionId != null) queryParams.Add("versionId", ApiClientUtils.ParameterToString(versionId)); // query parameter

            var response = CallDeleteApi(apiPath, queryParams, methodName);
            return response;
            throw new NotImplementedException();
        }



        public AsposeResponse MoveFile(string srcPath, string destPath, string srcStorage = null, string destStorage = null, string versionId = null)
        {
            var methodName = "MoveFile";
            // verify the required parameter 'srcPath' is set
            if (srcPath == null) throw new ApiException(400, $"Missing required parameter 'srcPath' when calling {methodName}");
            // verify the required parameter 'destPath' is set
            if (destPath == null) throw new ApiException(400, $"Missing required parameter 'destPath' when calling {methodName}");

            if (srcPath.First<char>() == '/')
                srcPath = srcPath.Substring(1, srcPath.Length - 1);
            var apiPath = $"/html/storage/file/move/{srcPath}";
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();

            queryParams.Add("destPath", ApiClientUtils.ParameterToString(destPath)); // query parameter
            if (srcStorage != null) queryParams.Add("srcStorageName", ApiClientUtils.ParameterToString(srcStorage)); // query parameter
            if (destStorage != null) queryParams.Add("destStorageName", ApiClientUtils.ParameterToString(destStorage)); // query parameter
            if (versionId != null) queryParams.Add("versionId", ApiClientUtils.ParameterToString(versionId)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            var response = CallPutApi(apiPath, queryParams, headerParams, null, methodName);
            return response;
        }


    }
}
