using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.Storage
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to check if a specified folder exists in the storage.
    /// </summary>
    class CheckIfFolderExists : ISdkRunner
    {
        public void Run()
        {
            // setup storage folder
            string folder = "/Html/TestData";
            // setup storage name; null for default storage
            string storage = null;

            IStorageApi stApi = new StorageApi(CommonSettings.ClientId, CommonSettings.ClientSecret, CommonSettings.BasePath);
            bool res = stApi.FileOrFolderExists(folder, storage);
            Console.Out.WriteLine($"Folder: {folder}; exists: {res}");
        }
    }
}
