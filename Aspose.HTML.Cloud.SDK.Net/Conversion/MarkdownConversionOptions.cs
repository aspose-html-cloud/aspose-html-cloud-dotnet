using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class MarkdownConversionOptions : ConversionOptions
    {
        bool? useGit;

        public MarkdownConversionOptions() : base(OutputFormats.MD)
        { 
        }

        public MarkdownConversionOptions setUseGit(bool useGit)
        {
            this.useGit = useGit;
            return this;
        }
    }
}
