namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class PDFConversionOptions : FixedLayoutConversionOptions
    {
        public int? JpegQuality;

        public PDFConversionOptions() : base(OutputFormats.PDF)
        {
        }

        public PDFConversionOptions setWidth(int width)
        {
            this.width = width;
            return this;
        }

        public PDFConversionOptions setHeight(int height)
        {
            this.height = height;
            return this;
        }

        public PDFConversionOptions setLeftMargin(int leftMargin)
        {
            this.leftMargin = leftMargin;
            return this;
        }

        public PDFConversionOptions setRightMargin(int rightMargin)
        {
            this.rightMargin = rightMargin;
            return this;
        }

        public PDFConversionOptions setTopMargin(int topMargin)
        {
            this.topMargin = topMargin;
            return this;
        }

        public PDFConversionOptions setBottomMargin(int bottomMargin)
        {
            this.bottomMargin = bottomMargin;
            return this;
        }

        public PDFConversionOptions setQuality(int JpegQuality)
        {
            this.JpegQuality = JpegQuality;
            return this;
        }
    }
}