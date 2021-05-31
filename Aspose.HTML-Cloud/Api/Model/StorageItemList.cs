using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aspose.Html.Cloud.Sdk.Api.Model
{
    internal class StorageItemList
    {
        [JsonProperty(PropertyName = "value")]
        public List<StorageItem> ItemList { get; set; }
    }
}
