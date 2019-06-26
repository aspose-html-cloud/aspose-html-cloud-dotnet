using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Client;


namespace Aspose.HTML.Cloud.Examples.SDK
{
    public abstract class SdkBaseRunner
    {
 
        public static bool UploadToStorage(string storagePath, string srcPath = null, string storage = null)
        {
            var name = Path.GetFileName(storagePath);
            Configuration storageConf = new Configuration()
            {
                ApiBaseUrl = CommonSettings.BasePath,
                AppKey = CommonSettings.AppKey,
                AppSid = CommonSettings.AppSID,
                AuthUrl = CommonSettings.AuthPath,
                ApiVersion = "3.0"
            };
            StorageApi storageApi = new StorageApi(storageConf);
            // Upload source file to aspose cloud storage
            if (File.Exists(srcPath))
            {
                var storageFolder = Path.GetDirectoryName(storagePath).Replace('\\', '/');
                // check if storagePath folder exists and create it if not
                if(!storageApi.FileOrFolderExists(storageFolder, storage))
                {
                    var resp = storageApi.CreateFolder(storageFolder, storage);
                    if(resp.Code == 200)
                    {
                        Console.Out.WriteLine($"Folder {storageFolder} successfully created.");
                    }
                }

                using (Stream fstr = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
                {
                    var response = storageApi.UploadFile(fstr, storagePath, storage);
                    if(response.Code == 200)
                    {
                        Console.Out.WriteLine($"File {name} successfully uploaded with path {storagePath} .");
                    }
                    return true;
                }
            }
            else
                throw new Exception(string.Format("Error: file {0} not found.", srcPath));
        }




    }
}
