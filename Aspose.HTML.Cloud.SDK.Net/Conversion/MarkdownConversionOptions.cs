using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class MarkdownConversionOptions : ConversionOptions
    {
        bool? UseGit;

        public MarkdownConversionOptions() : base(OutputFormats.MD)
        { 
        }

        public MarkdownConversionOptions SetUseGit(bool useGit)
        {
            this.UseGit = useGit;
            return this;
        }
    }
}
