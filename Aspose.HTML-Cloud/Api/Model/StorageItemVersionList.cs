using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aspose.Html.Cloud.Sdk.Api.Model
{
    internal class StorageItemVersionList
    {
        [JsonProperty(PropertyName = "value")]
        public List<StorageItemVersion> VersionList { get; set; }
    }
}
