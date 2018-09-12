using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aspose.Storage.Cloud.Sdk;
using Aspose.Storage.Cloud.Sdk.Api;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;

namespace Aspose.HTML.Cloud.Examples.SDK
{
    public abstract class SdkBaseRunner
    {
 
        public static bool UploadToStorage(string storagePath, string srcDir = null)
        {
            var name = Path.GetFileName(storagePath);
            Configuration storageConf = new Storage.Cloud.Sdk.Configuration()
            {
                ApiBaseUrl = CommonSettings.BasePath,
                AppKey = CommonSettings.AppKey,
                AppSid = CommonSettings.AppSID
            };
            StorageApi storageApi = new StorageApi(storageConf);
            // Upload source file to aspose cloud storage
            var srcPath = Path.Combine(srcDir ?? CommonSettings.DataFolder, name);
            if (File.Exists(srcPath))
            {
                using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
                {
                    var reqCr = new PutCreateRequest(storagePath, fstr);
                    var respCr = storageApi.PutCreate(reqCr);
                    var reqExist = new GetIsExistRequest(storagePath);
                    var respExist = storageApi.GetIsExist(reqExist);

                    return (respExist.FileExist.IsExist.HasValue && respExist.FileExist.IsExist.Value);
                }
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", srcPath));
        }




    }
}
