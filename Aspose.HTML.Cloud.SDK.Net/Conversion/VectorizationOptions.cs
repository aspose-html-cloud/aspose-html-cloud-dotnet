using Newtonsoft.Json;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class VectorizationOptions : ConversionOptions
    {
        [JsonProperty("error_threshold")]
        public float? ErrorThreshold { get; set; }

        [JsonProperty("max_iterations")]
        public int? MaxIterations { get; set; }

        [JsonProperty("colors_limit")]
        public int? ColorLimit { get; set; }

        [JsonProperty("line_width")]
        public float? LineWidth { get; set; }
    }
}
