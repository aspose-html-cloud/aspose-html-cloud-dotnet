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
    /// Example that demonstrates how to delete a file in the storage .
    /// </summary>
    public class DeleteFile : ISdkRunner
    {
        public void Run()
        {
            // setup name of a storage file
            string name = "testpage1_copy.html";
            // setup a folder path where is the file
            string folder = "/Html/Testout";
            // setup storage name (your default storage if null)
            string storage = null;
            // setup file version ID to delete; null to delete all versions
            string versionId = null;
            var filePath = Path.Combine(folder, name).Replace('\\', '/');

            IStorageFileApi stApi = new StorageApi(CommonSettings.ClientId, CommonSettings.ClientSecret, CommonSettings.BasePath);
            var response = stApi.DeleteFile(filePath, storage, versionId);
            if(response.Code == 200)
            {
                Console.Out.WriteLine($"File {filePath} has been successfully deleted.");
            }

        }
    }
}
