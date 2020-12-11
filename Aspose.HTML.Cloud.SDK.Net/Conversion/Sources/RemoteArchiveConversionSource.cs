using Aspose.HTML.Cloud.Sdk.IO;
using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.Conversion.Sources
{
    class RemoteArchiveConversionSource : PackageConversionSource
    {
        public RemoteArchiveConversionSource(List<string> paths)
            : base(paths)
        {
        }
        public RemoteArchiveConversionSource(List<RemoteFile> paths)
            : base( paths.ConvertAll<string>(p => p.Path))
        {
        }
    }
}