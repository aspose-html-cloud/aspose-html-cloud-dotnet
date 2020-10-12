using System.Drawing;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public abstract class FixedLayoutConversionOptions : ConversionOptions
    {
        public int? width;
        public int? height;
        public int? leftMargin;
        public int? rightMargin;
        public int? topMargin;
        public int? bottomMargin;

        protected FixedLayoutConversionOptions(OutputFormats format)
            : base(format) { }
    }
}