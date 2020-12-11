using Newtonsoft.Json;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Core.Model
{
    public class ConversionResult : OperationResult
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("files")]
        public string[] Files { get; set; }
    }
}