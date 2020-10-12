using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.Conversion.Sources
{
    public abstract class PackageConversionSource : ConversionSource
    {
        public List<string> StartPoints { get; private set; }

        protected PackageConversionSource(List<string> path) 
            : base(path)
        {
            StartPoints = new List<string>();
        }

        public PackageConversionSource StartingPoint(string file)
        {
            StartPoints.Add(file);
            return this;
        }
    }
}