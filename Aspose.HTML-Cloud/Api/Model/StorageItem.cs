using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Html.Cloud.Sdk.Api.Model
{
    public class StorageItem
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsFolder { get; set; }

        public long Size { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
