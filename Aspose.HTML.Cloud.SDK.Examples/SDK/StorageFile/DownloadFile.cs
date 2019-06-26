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
    /// Example that demonstrates how to download a file from the storage 
    /// and save it to local file system.
    /// </summary>
    public class DownloadFile : ISdkRunner
    {
        public void Run()
        {
            // setup the file name to copy
            string name = "testpage1.html";
            // setup the folder where is the file to copy
            string folder = "/Html/TestData";
            // setup storage name (default storage if null, source and target storages may be different)
            string storage = null;
            // setup file version to download (the latest version if null)
            string versionId = null;

            // setup local directory to save downloaded file.
            string destDir = @"d:\testout";

            var srcPath = Path.Combine(folder, name).Replace('\\', '/');
            var destPath = Path.Combine(destDir, name);

            IStorageFileApi stApi = new StorageApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
            var response = stApi.DownloadFile(srcPath, storage, versionId);
            if(response.Code == 200)
            {
                Console.Out.WriteLine($"File {srcPath} downloaded from storage");
                Stream respStream = response.ContentStream;
                respStream.Position = 0;
                using (Stream fstr = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                {
                    respStream.CopyTo(fstr);
                    fstr.Flush();
                    Console.Out.WriteLine($"Saved as {destDir}");
                }
            }
        }
    }
}
