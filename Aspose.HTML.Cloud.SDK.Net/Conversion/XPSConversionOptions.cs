namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class XPSConversionOptions : FixedLayoutConversionOptions
    {
        public XPSConversionOptions() : base(OutputFormats.XPS)
        {
        }

        public XPSConversionOptions setWidth(int width)
        {
            this.width = width;
            return this;
        }

        public XPSConversionOptions setHeight(int height)
        {
            this.height = height;
            return this;
        }

        public XPSConversionOptions setLeftMargin(int leftMargin)
        {
            this.leftMargin = leftMargin;
            return this;
        }

        public XPSConversionOptions setRightMargin(int rightMargin)
        {
            this.rightMargin = rightMargin;
            return this;
        }

        public XPSConversionOptions setTopMargin(int topMargin)
        {
            this.topMargin = topMargin;
            return this;
        }

        public XPSConversionOptions setBottomMargin(int bottomMargin)
        {
            this.bottomMargin = bottomMargin;
            return this;
        }
    }
}