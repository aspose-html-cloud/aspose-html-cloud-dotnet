using System;
using System.IO;
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
    /// Example that demonstrates how to move a file to other file in the storage 
    /// and check if move operation succeeded.
    /// </summary>
    public class MoveFile : ISdkRunner
    {
        public void Run()
        {
            // setup the file name to copy
            string name = "testpage1.html";
            // setup the folder where is the file to copy
            string srcFolder = "/Html/TestData";
            // setup the folder where the file will be copied to
            string destFolder = "/Html/Testout";
            // setup the file name the source file will be copied to 
            string newName = "testpage1_copy.html";
            // setup storage name (default storage if null, source and target storages may be different)
            string storage = null;
            // setup file version to copy (the latest version if null)
            string versionId = null;

            var srcPath = Path.Combine(srcFolder, name).Replace('\\', '/');
            var destPath = Path.Combine(destFolder, newName ?? name).Replace('\\', '/');

            IStorageFileApi fileApi = new StorageApi(CommonSettings.ClientId, CommonSettings.ClientSecret, CommonSettings.BasePath);
            var response = fileApi.MoveFile(srcPath, destPath, storage, storage, versionId);
            if (response.Code == 200)
            {
                Console.Out.WriteLine($"File {srcPath} copied to {destPath}");
                IStorageApi stApi = (IStorageApi)fileApi;
                bool exists = stApi.FileOrFolderExists(destPath);
                Console.Out.WriteLine($"New file {destPath} exists: {exists}");
            }
        }
    }
}
