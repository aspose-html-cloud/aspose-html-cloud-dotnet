// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ZipUtils.cs">
//   Copyright (c) 2022 Aspose.HTML Cloud
// </copyright>
// <summary>
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Utils
{
    /// <summary>
    /// TODO:To be used later
    /// </summary>
    internal static class ZipUtils
    {
        internal static void CreateEntryFromAny(this ZipArchive archive, string sourceName, string entryName = "")
        {
            var fileName = Path.GetFileName(sourceName);
            if (File.GetAttributes(sourceName).HasFlag(FileAttributes.Directory))
            {
                archive.CreateEntryFromDirectory(sourceName, Path.Combine(entryName, fileName));
            }
            else
            {
                archive.CreateEntryFromFile(sourceName, Path.Combine(entryName, fileName), CompressionLevel.Fastest);
            }
        }

        internal static void CreateEntryFromDirectory(this ZipArchive archive, string sourceDirName, string entryName = "")
        {
            var files = Directory.GetFiles(sourceDirName).Concat(Directory.GetDirectories(sourceDirName)).ToArray();

            foreach (var file in files)
            {
                archive.CreateEntryFromAny(file, entryName);
            }
        }

        internal static byte[] ZipFolder(string sourcePath)
        {
            byte[] result;

            using (var ms = new MemoryStream())
            {
                var files = Directory.GetFiles(sourcePath).Concat(Directory.GetDirectories(sourcePath)).ToArray();

                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        archive.CreateEntryFromAny(file, "");
                    }
                }
                result = ms.ToArray();
            }

            return result;
        }

        internal static byte[] ZipFiles(IList<string> files)
        {
            byte[] result;

            using (var ms = new MemoryStream())
            {
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        archive.CreateEntryFromAny(file, "");
                    }
                }
                result = ms.ToArray();
            }
            return result;
        }

    }
}
