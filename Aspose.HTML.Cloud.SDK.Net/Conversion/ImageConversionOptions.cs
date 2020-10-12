namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public abstract class ImageConversionOptions : FixedLayoutConversionOptions
    { 
        public int? resolution;
        
        protected ImageConversionOptions(OutputFormats format) 
            : base(format)
        {
        }

        public ImageConversionOptions setWidth(int width)
        {
            this.width = width;
            return this;
        }

        public ImageConversionOptions setHeight(int height)
        {
            this.height = height;
            return this;
        }

        public ImageConversionOptions setLeftMargin(int leftMargin)
        {
            this.leftMargin = leftMargin;
            return this;
        }

        public ImageConversionOptions setRightMargin(int rightMargin)
        {
            this.rightMargin = rightMargin;
            return this;
        }

        public ImageConversionOptions setTopMargin(int topMargin)
        {
            this.topMargin = topMargin;
            return this;
        }

        public ImageConversionOptions setBottomMargin(int bottomMargin)
        {
            this.bottomMargin = bottomMargin;
            return this;
        }

        public ImageConversionOptions setResolution(int resolution)
        {
            this.resolution = resolution;
            return this;
        }
    }
}