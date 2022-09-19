using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    internal class ConversionRequestModel
    {
        public string InputPath { get; set; }
        public string StorageName { get; set; }
        public List<string> Resources { get; set; }
        public string OutputFile { get; set; }
        public ConversionOptions Options { get; set; }
    }
}
