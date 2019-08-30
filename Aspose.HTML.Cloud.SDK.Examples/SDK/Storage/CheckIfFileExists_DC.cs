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
    /// Example that demonstrates how to check if a file exists in the storage
    /// by specified name and folder path.
    /// In this example, the default StorageApi constructor is used, so appSid, appKey, baseUrl and authUrl values 
    /// should be prevoiusly specified in the config file or in the environment variables.
    /// </summary>
    public class CheckIfFileExists_DC : ISdkRunner
    {
        public void Run()
        {
            // setup name of a storage file
            string name = "testpage7-ru.html";
            // setup a folder path where the file is located
            string folder = "/Html/TestData";
            // setup storage name (null for default storage)
            string storage = null;

            var filePath = Path.Combine(folder, name).Replace('\\', '/');
            IStorageApi stApi = new StorageApi();
            // default constructor; appSid, appKey, basePath, authPath aren't specified explicitly
            // but obtained from config file or environment variables
            bool res = stApi.FileOrFolderExists(filePath, storage);
            Console.Out.WriteLine($"File: {filePath}; exists: {res}");
        }
    }
}
