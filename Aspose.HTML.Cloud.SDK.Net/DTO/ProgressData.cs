using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.HTML.Cloud.Sdk.DTO
{
    public class ProgressData
    {
        public long ProcessedBytes { get; set; }
        public long TotalBytes { get; set; }

        public double Percent { get { return ProcessedBytes / TotalBytes;  } }
    }
}
