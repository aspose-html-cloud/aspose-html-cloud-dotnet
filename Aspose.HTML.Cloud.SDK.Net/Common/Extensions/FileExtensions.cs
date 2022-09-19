using System;
using System.IO;

namespace Aspose.HTML.Cloud.Sdk.Common.Extensions
{
    internal static class FileExtensions
    {
        internal static T? GetFileFormatFromFile<T>(this string path) where T : struct
        {
            var extension = Path.GetExtension(path)?
                .Replace(".", string.Empty)
                .Trim()
                .ToUpper();

            if (extension == null)
            {
                return null;
            }

            // if this is URL and the URL contains parameters
            if (extension.IndexOf("?", StringComparison.OrdinalIgnoreCase) > -1)
            {
                extension = extension.Split('?')[0].Trim();
            }

            if (Enum.TryParse<T>(extension, out var value))
            {
                return value;
            }

            return null;
        }
    }
}
