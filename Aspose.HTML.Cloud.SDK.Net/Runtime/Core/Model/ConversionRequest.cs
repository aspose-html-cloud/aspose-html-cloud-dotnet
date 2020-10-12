using Aspose.HTML.Cloud.Sdk.Conversion;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Core.Model
{
    public class ConversionRequest
    {
        [JsonProperty("inputPath")]
        public List<string> InputUrl { get; set; }
        
        [JsonProperty("outputPath")]
        public string OutputUrl { get; set; }

        [JsonProperty("inputFormat")]
        public InputFormats InputFileFormat { get; set; }

        [JsonProperty("outputFormat")]
        public OutputFormats OutputFileFormat { get; set; }
    }
}