using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Examples.SDK;
using Aspose.HTML.Cloud.Examples.SDK.HtmlDocument;
using Aspose.HTML.Cloud.Examples.SDK.HtmlTranslate;
using Aspose.HTML.Cloud.Examples.SDK.HtmlConvert;

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

            // == Example #1 == extract HTML fragments by XPath query
            //runner = new ExtractHtmlFragmentsByXPath();

            // == Example #2 == extract HTML fragments by XPath query
            //runner = new ExtractHtmlFragmentsByXPath();

            // == Example #3 == extract all images from HTML document as an archive
            //runner = new ExtractHTMLImagesAll();

            // == Example #4 == convert HTML document from URL to PDF
            runner = new ConvertHTMLByUrl("pdf");

            // == Example #5 == convert HTML document from URL to XPS
            //runner = new ConvertHTMLByUrl("xps");

            // == Example #6 == convert HTML document from URL to JPEG
            //runner = new ConvertHTMLByUrl("jpeg");

            // == Example #7 == convert HTML document from local filesystem to PDF
            //runner = new ConvertHTMLLocal("pdf");

            // == Example #8 == translate HTML document from English to French
            //runner = new TranslateHTMLFromStorage("en", "fr");

            // == Example #10 == translate HTML document from English to French
            //runner = new TranslateHTMLByUrl("en", "fr");

            // == Example #11 == translate HTML document from English to French and save to storage
            //runner = new TranslateHTMLByUrlToStorage("en", "fr");


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
