using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.HTML.Cloud.SDK.Examples.Utils
{
    /// <summary>
    /// This class contains helper methods for working with directories
    /// </summary>
    public static class DirectoryHelper
    {
        /// <summary>
        /// Returns path to folder with test data
        /// </summary>
        /// <param name="parentDir">parent directory</param>
        /// <returns>path to test data folder</returns>
        public static string GetRootSdkFolder(string parentDir = null)
        {
            var info = Directory.GetParent(parentDir ?? Directory.GetCurrentDirectory());
            if (info != null)
            {
                var dataFolderExists = info.GetDirectories("Settings");
                if (dataFolderExists.Any())
                {
                    return info.FullName;
                }

                return GetRootSdkFolder(info.FullName);
            }

            throw new ArgumentException("Unexpected folder structure");
        }

        /// <summary>
        /// The get path to sever creds.
        /// </summary>
        /// <param name="searchDir">directory we search for.</param>
        /// <param name="searchFile">file we search for.</param>
        /// <param name="parentDir">parent directory</param>
        /// <returns>The <see cref="string"/> path
        /// </returns>
        public static string GetPath(string searchDir, string searchFile, string parentDir = null)
        {
            var curDir = parentDir ?? Directory.GetCurrentDirectory();
            if (Directory.GetDirectories(curDir).Contains(Path.Combine(curDir, searchDir)))
            {
                return Path.Combine(curDir, searchDir, searchFile);
            }

            var parDir = Directory.GetParent(curDir);
            return GetPath(searchDir, searchFile, parDir.FullName);
        }

        /// <summary>
        /// Get Files with specified extension
        /// </summary>
        /// <param name="directoryPath">folder</param>
        /// <param name="extension">extension</param>
        /// <param name="searchOption">option</param>
        /// <returns>list of files names</returns>
        public static IEnumerable<string> GetFilesByExtension(string directoryPath, string extension, SearchOption searchOption)
        {
            return
                Directory.EnumerateFiles(directoryPath, "*" + extension, searchOption).OrderBy(x => x)
                    .Where(x => string.Equals(Path.GetExtension(x), extension, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
