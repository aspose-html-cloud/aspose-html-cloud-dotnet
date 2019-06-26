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
    /// Example that demonstrates how to get a list of files and subfolders in the storage folder.
    /// </summary>
    class GetFolderContent : ISdkRunner
    {
        public void Run()
        {
            // setup folder path
            string folder = "/Html/TestData";
            // setup storage name (default storage if null)
            string storage = null;

            IStorageFolderApi fApi = new StorageApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            var resp = fApi.GetFolderContentList(folder, storage);
            if(resp != null)
            {
                if (resp.Count == 0)
                    Console.WriteLine($"Folder {folder} is empty!");
                else
                {
                    Console.WriteLine($"Folder {folder} content:");
                    Console.WriteLine($"-------------------------------------");
                    foreach (var item in resp)
                    {
                        Console.WriteLine($"Name: {item.Name}; IsFolder: {item.IsFolder}; Path: {item.Path}; Size: {item.Size}; Modified: {item.ModifiedDateStr}");
                    }
                }
            }
        }
    }
}
