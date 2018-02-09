using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Aspose.Storage;
using Com.Aspose.Storage.Api;

namespace Aspose.HTML.Cloud.Examples.SDK
{
    public abstract class SdkBaseRunner
    {
 
        protected static void uploadToStorage(string name, string srcDir = null)
        {
            StorageApi storageApi = new StorageApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
            // Upload source file to aspose cloud storage
            var srcPath = Path.Combine(srcDir ?? CommonSettings.DataFolder, name);
            if (File.Exists(srcPath))
                storageApi.PutCreate(name, "", "", File.ReadAllBytes(srcPath));
            else
                throw new Exception(string.Format("Error: file {0} not found.", srcPath));
        }




    }
}
