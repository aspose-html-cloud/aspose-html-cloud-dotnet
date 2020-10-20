using Newtonsoft.Json;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public abstract class ConversionOptions
    {
        protected ConversionOptions(OutputFormats format)
        {
            this.Format = format;
        }

        [JsonIgnore]
        public OutputFormats Format { get; }

        public string ToJson()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
