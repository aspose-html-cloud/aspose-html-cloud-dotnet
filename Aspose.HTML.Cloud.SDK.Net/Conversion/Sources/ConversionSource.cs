using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.Conversion.Sources
{
    internal class ConversionDataSource
    {
        public string FilePath { get; set; }
        public IList<string> Resources { get; set; }
        public string ResourcesFolder { get; set; }
        public bool IsLocal { get; set; }
    }
}
