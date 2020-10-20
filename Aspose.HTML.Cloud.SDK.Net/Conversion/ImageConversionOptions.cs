namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public abstract class ImageConversionOptions : FixedLayoutConversionOptions
    { 
        public int? Resolution;
        
        protected ImageConversionOptions(OutputFormats format) 
            : base(format)
        {
        }

        public ImageConversionOptions SetWidth(int width)
        {
            Width = width;
            return this;
        }

        public ImageConversionOptions SetHeight(int height)
        {
            Height = height;
            return this;
        }

        public ImageConversionOptions SetLeftMargin(int leftMargin)
        {
            LeftMargin = leftMargin;
            return this;
        }

        public ImageConversionOptions SetRightMargin(int rightMargin)
        {
            RightMargin = rightMargin;
            return this;
        }

        public ImageConversionOptions SetTopMargin(int topMargin)
        {
            TopMargin = topMargin;
            return this;
        }

        public ImageConversionOptions SetBottomMargin(int bottomMargin)
        {
            BottomMargin = bottomMargin;
            return this;
        }

        public ImageConversionOptions SetResolution(int resolution)
        {
            Resolution = resolution;
            return this;
        }
    }
}