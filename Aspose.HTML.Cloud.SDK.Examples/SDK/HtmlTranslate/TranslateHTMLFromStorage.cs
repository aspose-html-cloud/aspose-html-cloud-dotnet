using System;
using System.IO;
using Com.Aspose.Storage.Api;
using Com.Aspose.Storage.Model;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;


namespace Aspose.HTML.Cloud.Examples.SDK.HtmlTranslate
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to translate the HTML document by its name in the cloud storage
    /// and to get tte result in the response stream.
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
            string name = "testpage1.html";
            string folder = null;
            string storage = null;

            string srcPath = Path.Combine(CommonSettings.DataFolder, name);
            if (File.Exists(srcPath))
            {
                var storagePath = !string.IsNullOrEmpty(folder)
                    ? string.Format("{0}/{1}", folder, name) : name;

                StorageApi storageApi = new StorageApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
                storageApi.PutCreate(storagePath, null, storage, File.ReadAllBytes(srcPath));
                var response = storageApi.GetIsExist(storagePath, null, storage);
                if(response.FileExist.IsExist)
                {
                    TranslationApi transApi = new TranslationApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
                    Stream stream = transApi.GetTranslateDocument(name, SrcLang, ResLang, folder, storage);

                    if (stream != null && stream.GetType() == typeof(FileStream))
                    {
                        string outName = ((FileStream)stream).Name;
                        string outPath = Path.Combine(CommonSettings.OutDirectory, Path.GetFileName(outName));
                        using (FileStream fstr = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                        {
                            stream.CopyTo(fstr);
                            fstr.Flush();
                            Console.WriteLine(string.Format("File '{0}' downloaded to: {1}", Path.GetFileName(outName), outPath));
                        }
                    }
                    stream.Close();
                    stream.Dispose();
                }
            }
            else
                throw new FileNotFoundException("File not found in the Data folder", name);

        }
    }
}
