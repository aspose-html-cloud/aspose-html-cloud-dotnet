using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.Conversion.Sources
{
    internal abstract class FileSetConversionSource : ConversionSource
    {
        protected FileSetConversionSource(List<string> paths)
            : base(paths)
        {
        }

        public FileSetConversionSource WithResource(string path)
        {
            Paths.Add(path);
            return this;
        }

        public FileSetConversionSource WithResources(params string[] paths)
        {
            Paths.AddRange(paths);
            return this;
        }
    }
}