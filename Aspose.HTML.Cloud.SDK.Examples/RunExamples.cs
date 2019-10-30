using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Examples.SDK;

using Aspose.HTML.Cloud.Examples.SDK.HtmlDocument;
//using Aspose.HTML.Cloud.Examples.SDK.HtmlTranslate;
using Aspose.HTML.Cloud.Examples.SDK.HtmlConvert;
using Aspose.HTML.Cloud.Examples.SDK.HtmlImport;
//using Aspose.HTML.Cloud.SDK.Examples.SDK.HtmlOcr;
using Aspose.HTML.Cloud.Examples.SDK.HtmlTemplateMerge;
using Aspose.HTML.Cloud.Examples.SDK.Storage;
using Aspose.HTML.Cloud.Examples.SDK.StorageFile;
using Aspose.HTML.Cloud.Examples.SDK.StorageFolder;
using Aspose.HTML.Cloud.Examples.SDK.ExternalJwtAuth;


namespace Aspose.HTML.Cloud.Examples
{
    public class RunExamples
    {
        private static Dictionary<string, ISdkRunner> Runners = null;

        static RunExamples()
        {
            Runners = new Dictionary<string, ISdkRunner>();

            /// Storage API: Storage
            /// ---------------------------------------
            // == Example == check if file exists
            Runners.Add("CheckIfFileExists", new CheckIfFileExists());
            // == Example == check if file exists; default StorageApi constructor is used
            Runners.Add("CheckIfFileExists.DC", new CheckIfFileExists());
            // == Example == check if folder exists
            Runners.Add("CheckIfFolderExists", new CheckIfFolderExists());
            // == Example == get list of storage file versions
            Runners.Add("GetFileVersionsList", new GetFileVersionsList());
            /// Storage API: Folder
            /// ---------------------------------------
            // == Example == get list of storage folder items (files and subfolders)
            Runners.Add("GetFolderContent", new GetFolderContent());
            // == Example == create storage folder
            Runners.Add("CreateFolder", new CreateFolder());
            // == Example == copy storage folder to other folder with all files and subfolders
            Runners.Add("CopyFolder", new CopyFolder());
            // == Example == move storage folder to other folder with all files and subfolders
            Runners.Add("MoveFolder", new MoveFolder());
            // == Example == delete storage folder with all files and subfolders
            Runners.Add("DeleteFolder", new DeleteFolder());          
            /// Storage API: File
            /// ---------------------------------------
            Runners.Add("DownloadFile", new DownloadFile());
            // == Example == upload file to storage
            Runners.Add("UploadFileAsStream", new UploadFileAsStream());
            // == Example == upload file to storage - variant: by local path
            Runners.Add("UploadFileByLocalPath", new UploadFileByLocalPath());
            // == Example == copy storage file
            Runners.Add("CopyFile", new CopyFile());
            // == Example == copy storage file
            Runners.Add("MoveFile", new MoveFile());
            // == Example == delete storage file
            Runners.Add("DeleteFile", new DeleteFile());


            /// HTML API: Document
            /// ---------------------------------------
            // == Example == extract all images from HTML document from storage as an archive
            Runners.Add("ExtractHTMLImagesAll", new ExtractHTMLImagesAll());
            // == Example == extract all images from HTML document from storage as an archive - use default HtmlApi constructor
            Runners.Add("ExtractHTMLImagesAll.DC", new ExtractHTMLImagesAll_DC());
            // == Example == extract all images from HTML document from Web by URL as an archive
            Runners.Add("ExtractHTMLImagesAllByUrl", new ExtractHTMLImagesAllByUrl());
            // == Example == extract HTML fragments from storage by XPath query
            Runners.Add("ExtractHtmlFragmentsByXPath", new ExtractHtmlFragmentsByXPath());
            // == Example == extract HTML fragments from Web by URL by XPath query
            Runners.Add("ExtractHtmlFragmentsByXPathByUrl", new ExtractHtmlFragmentsByXPathByUrl());
            // == Example == extract HTML fragments from storage by CSS selector
            Runners.Add("ExtractHtmlFragmentsByCSSSelector", new ExtractHtmlFragmentsByCSSSelector());
            // == Example == extract HTML fragments from Web by URLby CSS selector
            Runners.Add("ExtractHtmlFragmentsByCSSSelectorByUrl", new ExtractHtmlFragmentsByCSSSelectorByUrl());

            /// HTML API: Conversion/Import
            /// ---------------------------------------
            // == Example == convert HTML document from URL to PDF
            Runners.Add("ConvertHTMLByUrl.PDF", new ConvertHTMLByUrl("pdf"));
            // == Example == convert HTML document from URL to XPS
            Runners.Add("ConvertHTMLByUrl.XPS", new ConvertHTMLByUrl("xps"));
            // == Example == convert HTML document from URL to JPEG
            Runners.Add("ConvertHTMLByUrl.JPEG", new ConvertHTMLByUrl("jpeg"));
            // == Example == convert HTML document from URL to MHTML
            Runners.Add("ConvertHTMLByUrl.MHTML", new ConvertHTMLByUrl("mhtml"));
            // == Example == convert HTML document from storage to PDF
            Runners.Add("ConvertHTMLByName.PDF", new ConvertHTMLByName("pdf"));
            // == Example == convert HTML document from storage to XPS
            Runners.Add("ConvertHTMLByName.XPS", new ConvertHTMLByName("xps"));
            // == Example == convert HTML document from storage to JPEG
            Runners.Add("ConvertHTMLByName.JPEG", new ConvertHTMLByName("jpeg"));
            // == Example == convert HTML document from storage to Markdown
            Runners.Add("ConvertHTMLByName.MD", new ConvertHTMLByName("md"));

            // == Example == convert HTML document from storage to PDF and save result to storage
            Runners.Add("ConvertHTMLByNameToStorage.PDF", new ConvertHTMLByNameToStorage("pdf"));
            // == Example == convert HTML document from local file system to PDF and save result to storage
            Runners.Add("ConvertHTMLLocalToStorage.PDF", new ConvertHTMLLocalToStorage("pdf"));

            // == Example == convert Markdown from storage to HTML document 
            Runners.Add("ImportHtmlFromMarkdownByName", new ImportHtmlFromMarkdownByName());
            // == Example == convert Markdown from storage to HTML document and save to storage 
            Runners.Add("ImportHtmlFromMarkdownByNameToStorage", new ImportHtmlFromMarkdownByNameToStorage());
            // == Example == convert Markdown from local file system to HTML document and save to storage
            Runners.Add("ImportHtmlFromMarkdownLocalToStorage", new ImportHtmlFromMarkdownLocalToStorage());


            /// HTML API: Conversion/Import (extension)
            /// ---------------------------------------
            // == Example == convert HTML document from local file system to PDF and download result 
            Runners.Add("ConvertHTMLLocalAndDownloadResult.PDF", new ConvertHTMLLocalAndDownloadResult("pdf"));
            // == Example == convert HTML document from local file system to XPS and download result 
            Runners.Add("ConvertHTMLLocalAndDownloadResult.XPS", new ConvertHTMLLocalAndDownloadResult("xps"));
            // == Example == convert HTML document from local file system to XPS and download result 
            Runners.Add("ConvertHTMLLocalAndDownloadResult.JPEG", new ConvertHTMLLocalAndDownloadResult("jpeg"));
            // == Example == convert HTML document from local file system to PDF and download result 
            Runners.Add("ConvertHTMLLocalAsFileAndDownloadResult.PDF", new ConvertHTMLLocalAsFileAndDownloadResult("pdf"));
            // == Example == convert HTML document from local file system to XPS and download result 
            Runners.Add("ConvertHTMLLocalAsFileAndDownloadResult.XPS", new ConvertHTMLLocalAsFileAndDownloadResult("xps"));
            // == Example == convert HTML document from local file system to XPS and download result 
            Runners.Add("ConvertHTMLLocalAsFileAndDownloadResult.JPEG", new ConvertHTMLLocalAsFileAndDownloadResult("jpeg"));


            // AR 25.10.2019 - : unavailable since 19.10
            ///// HTML API: Translate
            ///// ---------------------------------------
            //// == Example == translate HTML document in storage from English to French
            //Runners.Add("TranslateHTMLFromStorage", new TranslateHTMLFromStorage("en", "fr"));
            //// == Example == translate HTML document by URL from English to French
            //Runners.Add("TranslateHTMLByUrl", new TranslateHTMLByUrl("en", "fr"));

            /// HTML API: Template Merge
            /// ---------------------------------------
            // == Example == merge HTML template with data - both are in the storage
            Runners.Add("MergeHtmlTemplateWithData", new MergeHtmlTemplateWithData());
            // == Example == merge HTML template in the storage with data in the local file system
            Runners.Add("MergeHtmlTemplateWithLocalData", new MergeHtmlTemplateWithLocalData());


            // AR 25.10.2019 - : unavailable since 19.10
            ///// HTML API: OCR
            ///// ---------------------------------------
            //// == Example == Recognize text content from image and create HTML document with it
            //Runners.Add("RecognizeAndImportToHTML", new RecognizeAndImportToHTML());
            //// == Example == Recognize text content from image, create HTML and translate the text content
            //Runners.Add("RecognizeAndTranslateToHTML", new RecognizeAndTranslateToHTML("en", "fr"));

            /// HTML API: Summarization
            /// ---------------------------------------
            /// 


            /// HTML API: Authorization with an external token
            /// -----------------------------------------------
            /// == Example == extract all images from HTML document from storage as an archive 
            ///    - using a JWT token provided by SDK caller application 
            Runners.Add("ExtractHTMLImages_ExtJwtToken", new ExtractHTMLImages_ExtJwtToken());
            /// == Example == get list of storage folder items (files and subfolders) 
            ///    - using a JWT token provided by SDK caller application 
            Runners.Add("GetFolderContent_ExtJwtToken", new GetFolderContent_ExtJwtToken());

        }

        [STAThread]
        public static void Main(string[] args)
        {
            // setup example you want to try out
            string example = "ExtractHTMLImages_ExtJwtToken";
            ISdkRunner runner = (Runners.ContainsKey(example)) ? Runners[example] : null;

            //Console.WriteLine("\nPress any key to continue....");
            //Console.ReadKey();
            try
            {
                if (runner == null)
                {
                    Console.WriteLine("Open RunExamples.cs. \nIn Main() method setup the example that you want to run.");
                    Console.WriteLine("=====================================================");
                }
                else
                {
                    Console.WriteLine("RunExamples.cs. Starting...");
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("== Settings:");
                    Console.WriteLine($"AppSID = {CommonSettings.AppSID}");
                    Console.WriteLine($"AppKey = {CommonSettings.AppKey}");
                    Console.WriteLine($"BasePath = {CommonSettings.BasePath}");
                    Console.WriteLine($"AuthPath = {CommonSettings.AuthPath}");
                    Console.WriteLine("=====================================================");
                    Console.Out.Flush();
                    runner.Run();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError running an example: " + ex.Message);
            }
            Console.Out.Flush();
            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }
    }
}
