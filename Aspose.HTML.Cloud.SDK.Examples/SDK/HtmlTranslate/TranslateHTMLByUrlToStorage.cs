using System;
using System.IO;
using Com.Aspose.Storage.Api;
using Com.Aspose.Storage.Model;
using Com.Aspose.Html;
using Com.Aspose.Html.Api;
using Com.Aspose.Html.Api.Interfaces;
using Com.Aspose.Html.NativeClient;


namespace Aspose.HTML.Cloud.Examples.SDK.HtmlTranslate
{
    /// <summary>
    /// Aspose.HTML Cloud for .NET SDK - examples.
    /// =========================================
    /// Example that demonstrates how to translate the HTML page by its URL 
    /// and to save the result document to the cloud storage (default storage is AmazonS3).
    /// </summary>
    public class TranslateHTMLByUrlToStorage : ISdkRunner
    {
        string SrcLang { get; set; }
        string ResLang { get; set; }

        public TranslateHTMLByUrlToStorage(string srclang, string reslang)
        {
            SrcLang = srclang;
            ResLang = reslang;
        }

        public void Run()
        {
            string srcUrl = @"http://www.htmlhelp.com/reference/css/stylesheets-now.html";
            //string srcUrl = @"https://www.le.ac.uk/oerresources/bdra/html/page_01.htm";
            string folder = null;  // default folder is root
            string storage = null; // default storage is AmazonS3

            TranslationApi transApi = new TranslationApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
            NativeRestResponse resp = transApi.PutTranslateDocumentByUrl(srcUrl, SrcLang, ResLang, folder, storage);
            if(resp.ContentType == NativeRestResponse.RespContentType.FileName
                && resp.ContentName != null)
            {
                StorageApi storageApi = new StorageApi(CommonSettings.AppKey, CommonSettings.AppSID, CommonSettings.BasePath);
                var storagePath = !string.IsNullOrEmpty(folder)
                    ? string.Format("{0}/{1}", folder, resp.ContentName) : resp.ContentName;
                var stResp = storageApi.GetIsExist(storagePath, null, storage);
                if(stResp.FileExist.IsExist)
                {
                    Console.WriteLine(string.Format("\nFile '{0}' created in the cloud storage: folder = '{1}', storage = '{2}' ", 
                        resp.ContentName, folder ?? "", storage ?? "<default>"));
                    
                    ResponseMessage resp2 = storageApi.GetDownload(storagePath, null, storage);
                    using (MemoryStream resStream = new MemoryStream(resp2.ResponseStream))
                    {
                        var outPath = Path.Combine(CommonSettings.OutDirectory, resp.ContentName);
                        using (FileStream fstr = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                        {
                            resStream.Position = 0;
                            resStream.CopyTo(fstr);
                            fstr.Flush();
                            Console.WriteLine(string.Format("\nResult file downloaded to: {0}", outPath));
                        }
                    }
                }
            }
         }
    }
}
