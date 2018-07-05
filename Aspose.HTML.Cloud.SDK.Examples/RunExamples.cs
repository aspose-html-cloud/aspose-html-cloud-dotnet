using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Examples.SDK;
using Aspose.HTML.Cloud.Examples.SDK.HtmlDocument;
using Aspose.HTML.Cloud.Examples.SDK.HtmlTranslate;
using Aspose.HTML.Cloud.Examples.SDK.HtmlConvert;
using Aspose.HTML.Cloud.SDK.Examples.SDK.HtmlOcr;

namespace Aspose.HTML.Cloud.Examples
{
    public class RunExamples
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            ISdkRunner runner = null;

            // Uncomment the one you want to try out

            // == Example == extract HTML fragments by XPath query
            //runner = new ExtractHtmlFragmentsByXPath();

            // == Example == extract HTML fragments by XPath query
            //runner = new ExtractHtmlFragmentsByXPath();

            // == Example == extract all images from HTML document as an archive
            //runner = new ExtractHTMLImagesAll();


            // == Example == convert HTML document from URL to PDF
            //runner = new ConvertHTMLByUrl("pdf");

            // == Example == convert HTML document from URL to XPS
            //runner = new ConvertHTMLByUrl("xps");

            // == Example == convert HTML document from URL to JPEG
            //runner = new ConvertHTMLByUrl("jpeg");

            // == Example == convert HTML document from storage to PDF
            //runner = new ConvertHTMLByName("pdf");

            // == Example == convert HTML document from storage to XPS
            //runner = new ConvertHTMLByName("xps");

            // == Example == convert HTML document from storage to JPEG
            //runner = new ConvertHTMLByName("jpeg");

            // == Example == convert HTML document from storage to PDF and save result to storage
            //runner = new ConvertHTMLByNameToStorage("pdf");

            // == Example == convert HTML document from local file system to PDF and save result to storage
            //runner = new ConvertHTMLLocalToStorage("pdf");

            // == Example == translate HTML document from English to French
            //runner = new TranslateHTMLFromStorage("en", "fr");

            // == Example == translate HTML document from English to French
            //runner = new TranslateHTMLByUrl("en", "fr");


            // == Example == Recognize text content from image and create HTML document with it
            //runner = new RecognizeAndImportToHTML();

            // == Example == Recognize text content from image, create HTML and translate the text content
            runner = new RecognizeAndTranslateToHTML("en", "fr");

            //Console.WriteLine("\nPress any key to continue....");
            //Console.ReadKey();
            try
            {
                runner.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError running an example: " + ex.Message);
            }
            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }
    }
}
