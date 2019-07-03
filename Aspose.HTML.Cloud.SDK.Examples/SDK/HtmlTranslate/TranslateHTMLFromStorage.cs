using System;
using System.IO;

using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;


namespace Aspose.HTML.Cloud.Examples.SDK.HtmlTranslate
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to translate the HTML document by its name in the cloud storage
    /// and to get result as the response stream.
    /// </summary>
    public class TranslateHTMLFromStorage : ISdkRunner
    {
        string SrcLang { get; set; }
        string ResLang { get; set; }

        public TranslateHTMLFromStorage(string srclang, string reslang)
        {
            SrcLang = srclang;
            ResLang = reslang;
        }

        public void Run()
        {
            // setup source HTML document name
            string name = "testpage1.html";
            // setup storage folder path
            string folder = CommonSettings.StorageDataFolder;
            // setup storage name (null for default storage)
            string storage = null;

            string srcPath = Path.Combine(CommonSettings.LocalDataFolder, name);
            string storagePath = Path.Combine(folder, name).Replace('\\', '/');
            if (File.Exists(srcPath))
            {
                bool uploaded = SdkBaseRunner.UploadToStorage(storagePath, srcPath);
                if(uploaded)
                {
                    ITranslationApi transApi = new HtmlApi(CommonSettings.AppSID, CommonSettings.AppKey, CommonSettings.BasePath);
                    var response = transApi.GetTranslateDocument(name, SrcLang, ResLang, folder, storage);

                    if (response != null && response.ContentStream != null && response.Status == "OK")
                    {
                        Stream stream = response.ContentStream;
                        string outName = response.FileName;
                        string outPath = Path.Combine(CommonSettings.OutDirectory, Path.GetFileName(outName));
                        using (FileStream fstr = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                        {
                            stream.CopyTo(fstr);
                            fstr.Flush();
                            Console.WriteLine(string.Format("File '{0}' downloaded to: {1}", Path.GetFileName(outName), outPath));
                        }
                    }
                }
            }
            else
                throw new FileNotFoundException("File not found in the Data folder", name);

        }
    }
}
