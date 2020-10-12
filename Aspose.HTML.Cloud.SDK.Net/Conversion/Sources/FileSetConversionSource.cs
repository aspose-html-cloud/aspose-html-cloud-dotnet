using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.Conversion.Sources
{
    public abstract class FileSetConversionSource : ConversionSource
    {
        protected FileSetConversionSource(List<string> paths)
            : base(paths)
        {
        }

        public FileSetConversionSource WithResource(string path)
        {
            return this;
        }

        public FileSetConversionSource WithResources(params string[] paths)
        {
            return this;
        }
    }
}