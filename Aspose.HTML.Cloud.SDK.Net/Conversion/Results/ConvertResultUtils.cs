using System;
using System.Linq;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;

namespace Aspose.HTML.Cloud.Sdk.Conversion.Results
{
    internal static class ConvertResultUtils
    {
        internal static void UpdateFromResponse(this ConvertResultFile convertResult, ConversionResult response)
        {
            convertResult.OutputFile = response.File;
            convertResult.Status = ParseStatus(response.Status) ?? convertResult.Status;
        }

        internal static ConvertResultStatus? ParseStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return null;
            }

            if (status.Equals("faulted"))
            {
                return ConvertResultStatus.Failed;
            }

            var statuses = new[]
            {
                ConvertResultStatus.Uploading,
                ConvertResultStatus.Pending,
                ConvertResultStatus.Running,
                ConvertResultStatus.Completed,
                ConvertResultStatus.Failed,
                ConvertResultStatus.Canceled
            };

            return statuses.FirstOrDefault(s=>s.ToString().Equals(status.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }
}
