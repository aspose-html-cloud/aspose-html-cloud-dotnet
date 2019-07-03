using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.StorageFolder
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to move a storage folder with all files and subfolders
    /// to other folder in the storage.
    /// </summary>
    public class MoveFolder : ISdkRunner
    {
        public void Run()
        {
            // base storage folder
            string folder = CommonSettings.StorageDataFolder;
            // setup source folder name to move
            string srcFolder = "Folder1";
            // setup source storage name; null if default storage
            string srcStorage = null;
            // setup target folder path 
            string destFolder = "CopyFolder1";
            // setup target storage name; null if default storage
            string destStorage = null;

            var srcPath = Path.Combine(folder, srcFolder).Replace('\\', '/');
            var destPath = Path.Combine(folder, destFolder).Replace('\\', '/');

            IStorageFolderApi fApi = new StorageApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            var response = fApi.MoveFolder(srcPath, destPath, srcStorage, destStorage);
            if (response.Code == 200)
            {
                Console.Out.WriteLine($"Folder {srcPath} moved to {destPath}");
                IStorageApi stApi = (IStorageApi)fApi;
                bool exists = stApi.FileOrFolderExists(destPath);
                Console.Out.WriteLine($"New folder {destPath} exists: {exists}");
            }
        }
    }
}
