using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.StorageFile
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to upload a file to the storage as a stream
    /// and check if file has been uploaded successfully.
    /// </summary>
    class UploadFileAsStream : ISdkRunner
    {
        public void Run()
        {
            // setup a file to upload
            string name = "testpage3_embcss.html";
            // setup a local file system directory where is the source file
            string srcLocalDir = CommonSettings.LocalDataFolder;
            // setup a folder path where the file will be uploaded
            string folder = CommonSettings.StorageDataFolder;
            // setup storage name (your default storage if null)
            string storage = null;

            string suffix = "new";
            var newName = $"{Path.GetFileNameWithoutExtension(name)}_{suffix}{Path.GetExtension(name)}";
            var srcPath = Path.Combine(srcLocalDir, name);
            var dstPath = Path.Combine(folder, newName).Replace('\\', '/');

            IStorageFileApi fApi = new StorageApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            IStorageApi stApi = (IStorageApi)fApi;
            CheckIfFolderExistsAndCreate(stApi, folder, storage);
            
            using (Stream fstr = File.Open(srcPath, FileMode.Open, FileAccess.Read))
            {
                var response = fApi.UploadFile(fstr, dstPath, storage);
                if(response.Code == 200)
                {
                    bool exists = stApi.FileOrFolderExists(dstPath);
                    if (exists)
                        Console.WriteLine($"File uploaded by path: {dstPath}");
                    else
                        Console.WriteLine($"Something went wrong: file not found by path {dstPath}");
                }
            }
        }

        private void CheckIfFolderExistsAndCreate(IStorageApi api, string folderPath, string storage)
        {
            if (!api.FileOrFolderExists(folderPath, storage))
            {
                IStorageFolderApi fApi = (IStorageFolderApi)api;
                fApi.CreateFolder(folderPath, storage);
            }
        }

    }
}
