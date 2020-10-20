using System.Drawing;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public abstract class FixedLayoutConversionOptions : ConversionOptions
    {
        public int? Width;
        public int? Height;
        public int? LeftMargin;
        public int? RightMargin;
        public int? TopMargin;
        public int? BottomMargin;

        protected FixedLayoutConversionOptions(OutputFormats format)
            : base(format) { }
    }
}