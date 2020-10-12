using System;
using System.Collections.Generic;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Utils
{
    public static class UrlUtils
    {
        public static string ToQueryString(this List<string> model, string name)
        {
            var result = model.Select((el) => name + "=" + Uri.EscapeDataString(el)).Aggregate((p1, p2) => p1 + "&" + p2);
            return result;
        }
    }
}
