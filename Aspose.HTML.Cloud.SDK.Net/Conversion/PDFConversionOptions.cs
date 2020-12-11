namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class PDFConversionOptions : FixedLayoutConversionOptions
    {
        public int? JpegQuality;

        public PDFConversionOptions() : base(OutputFormats.PDF)
        {
        }

        public PDFConversionOptions SetWidth(int width)
        {
            Width = width;
            return this;
        }

        public PDFConversionOptions SetHeight(int height)
        {
            Height = height;
            return this;
        }

        public PDFConversionOptions SetLeftMargin(int leftMargin)
        {
            LeftMargin = leftMargin;
            return this;
        }

        public PDFConversionOptions SetRightMargin(int rightMargin)
        {
            RightMargin = rightMargin;
            return this;
        }

        public PDFConversionOptions SetTopMargin(int topMargin)
        {
            TopMargin = topMargin;
            return this;
        }

        public PDFConversionOptions SetBottomMargin(int bottomMargin)
        {
            BottomMargin = bottomMargin;
            return this;
        }

        public PDFConversionOptions SetQuality(int jpegQuality)
        {
            JpegQuality = jpegQuality;
            return this;
        }
    }
}