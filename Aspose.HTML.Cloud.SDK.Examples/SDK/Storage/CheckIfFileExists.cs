using System;
using System.IO;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;

namespace Aspose.HTML.Cloud.Examples.SDK.Storage
{
    /// <summary>
    /// 
    /// </summary>
    class CheckIfFileExists : ISdkRunner
    {
        /// <summary>
        /// Aspose.HTML Cloud for .NET SDK - examples.
        /// =========================================
        /// Example that demonstrates how to check if a file exists in the storage
        /// by specified name and folder path.
        /// </summary>
        public void Run()
        {
            // setup name of a storage file
            string name = "testpage7-ru.html";
            // setup a folder path where the file is located
            string folder = "/Html/TestData";
            // setup storage name (null for default storage)
            string storage = null;

            var filePath = Path.Combine(folder, name).Replace('\\', '/');
            IStorageApi stApi = new StorageApi(CommonSettings.ClientId, CommonSettings.ClientSecret, CommonSettings.BasePath);
            bool res = stApi.FileOrFolderExists(filePath, storage);
            Console.Out.WriteLine($"File: {filePath}; exists: {res}");
        }
    }
}
