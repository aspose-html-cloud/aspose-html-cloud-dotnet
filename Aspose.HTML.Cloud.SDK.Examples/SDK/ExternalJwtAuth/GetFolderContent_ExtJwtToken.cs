using System;
using System.IO;

using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Client.Authentication;


namespace Aspose.HTML.Cloud.Examples.SDK.ExternalJwtAuth
{
    public class GetFolderContent_ExtJwtToken : ExternalJwtAuthExampleBase, ISdkRunner
    {
        public void Run()
        {
            // setup folder path
            string folder = "/Html/TestData";
            // setup storage name (default storage if null)
            string storage = null;

            // here the JWT token is acquired with its issue date and expiration period 
            JwtToken token = GetAuthToken();
            // 14.10.2019 * changed to constructor accepting token as a string
            IStorageFolderApi fApi = new StorageApi(token.Token, CommonSettings.BasePath);
            var resp = fApi.GetFolderContentList(folder, storage);
            if (resp != null)
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
