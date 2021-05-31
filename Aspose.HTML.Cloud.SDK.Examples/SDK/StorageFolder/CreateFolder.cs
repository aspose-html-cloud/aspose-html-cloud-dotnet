using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.StorageFolder
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to create a folder in the storage.
    /// </summary>
    public class CreateFolder : ISdkRunner
    {
        public void Run()
        {
            string folder = CommonSettings.StorageDataFolder;
            // setup folder path to create
            string newFolder = Path.Combine(folder, "NewFolder").Replace('\\', '/'); ;
            // setup storage name (your default storage if null)
            string storage = null;

            IStorageFolderApi api = new StorageApi(CommonSettings.ClientId, CommonSettings.ClientSecret, CommonSettings.BasePath);
            var response = api.CreateFolder(newFolder, storage);
            if (response.Code == 200)
            {
                IStorageApi stApi = (IStorageApi)api;
                stApi.FileOrFolderExists(newFolder, storage);
                Console.Write($"Folder {newFolder} successfully created");
            }
        }
    }
}
