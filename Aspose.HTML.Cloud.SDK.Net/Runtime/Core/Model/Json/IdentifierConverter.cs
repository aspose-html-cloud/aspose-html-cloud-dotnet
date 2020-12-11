using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Core.Model.Json
{
    public class IdentifierConverter : JsonConverter<Identifier>
    {
        public override void WriteJson(JsonWriter writer, Identifier value, JsonSerializer serializer)
        {
            JToken token = JToken.FromObject(value.ToString());
            token.WriteTo(writer);
        }

        public override Identifier ReadJson(JsonReader reader, Type objectType, Identifier existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            return Identifier.FromString(reader.Value.ToString());
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override bool CanRead
        {
            get { return true; }
        }
    }
}
