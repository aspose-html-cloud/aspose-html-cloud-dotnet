namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class XPSConversionOptions : FixedLayoutConversionOptions
    {
        public XPSConversionOptions() : base(OutputFormats.XPS)
        {
        }

        public XPSConversionOptions SetWidth(int width)
        {
            Width = width;
            return this;
        }

        public XPSConversionOptions SetHeight(int height)
        {
            Height = height;
            return this;
        }

        public XPSConversionOptions SetLeftMargin(int leftMargin)
        {
            LeftMargin = leftMargin;
            return this;
        }

        public XPSConversionOptions SetRightMargin(int rightMargin)
        {
            RightMargin = rightMargin;
            return this;
        }

        public XPSConversionOptions SetTopMargin(int topMargin)
        {
            TopMargin = topMargin;
            return this;
        }

        public XPSConversionOptions SetBottomMargin(int bottomMargin)
        {
            BottomMargin = bottomMargin;
            return this;
        }
    }
}