using System;
using System.IO;

using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;

namespace Aspose.HTML.Cloud.Examples.SDK.Storage
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to get the list of versions of a file in the cloud storage
    /// (result list is empty if the file doesn't exist).
    /// </summary>
    public class GetFileVersionsList : ISdkRunner
    {
            string name = "testpage7-ru.html";
            // setup a folder path where the file is located
            string folder = "/Html/TestData";
            // setup storage name (your default storage if null)
            string storage = null;
        public void Run()
        {
            // setup name of a storage file = null;
            var filePath = Path.Combine(folder, name).Replace('\\', '/');

            IStorageApi api = new StorageApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            var vlist = api.GetStorageItemVersions(filePath, storage);

            Console.Out.WriteLine($"Path: {filePath}");
            foreach(var v in vlist)
            {
                Console.Out.WriteLine($"versionId: {v.VersionId}; is last: {v.IsLatest} date: {v.ModifiedDateStr}");
            }
        }
    }
}
