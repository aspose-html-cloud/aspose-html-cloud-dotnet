using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Aspose.Html.Api.Interfaces
{
    interface IOcrApi
    {
        Stream GetRecognizeAndImportToHtml(string name, string engineLang = "en", string folder = null, string storage = null);

        Stream GetRecognizeAndTranslateToHtml(string name, string srcLang, string resLang, string folder = null, string storage = null);
    }
}
