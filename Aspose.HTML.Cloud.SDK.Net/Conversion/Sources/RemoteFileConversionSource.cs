using Aspose.HTML.Cloud.Sdk.IO;
using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.Conversion.Sources
{
    class RemoteFileConversionSource : PackageConversionSource
    {
        public RemoteFileConversionSource(List<string> paths)
            : base(paths)
        {
        }

        public RemoteFileConversionSource(List<RemoteFile> paths)
            : base(paths.ConvertAll<string>(p => p.Path))
        {
        }
    }
}