// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ZipUtils.cs">
//   Copyright (c) 2020 Aspose.HTML Cloud
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


using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aspose.HTML.Cloud.Sdk.Runtime.Utils
{
    internal static class ZipUtils
    {
        public static void CreateEntryFromAny(this ZipArchive archive, String sourceName, String entryName = "")
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

        public static void CreateEntryFromDirectory(this ZipArchive archive, String sourceDirName, String entryName = "")
        {
            string[] files = Directory.GetFiles(sourceDirName).Concat(Directory.GetDirectories(sourceDirName)).ToArray();

            foreach (var file in files)
            {
                archive.CreateEntryFromAny(file, entryName);
            }
        }

        public static byte[] ZipFolder(string sourcePath)
        {
            byte[] result;

            using (var ms = new MemoryStream())
            {
                string[] files = Directory.GetFiles(sourcePath).Concat(Directory.GetDirectories(sourcePath)).ToArray();

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


        public static byte[] ZipFileList(string entryPoint, List<string> files)
        {
            byte[] result;

            using (var ms = new MemoryStream())
            {
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    var entryDir = Path.GetDirectoryName(entryPoint);

                    foreach (var file in files)
                    {
                        var fileRelPath = Path.GetDirectoryName(file).Replace(entryDir, "");
                        var fileName = Path.GetFileName(file);
                        archive.CreateEntryFromAny(file, fileRelPath);
                    }
                }
                result = ms.ToArray();
            }
            return result;
        }

        public static void ZipFolder(string inDir, string outFile)
        {
            if (!Directory.Exists(inDir))
            {
                throw new ArgumentException("Directory not exists.");
            }

            if (inDir.EndsWith("/"))
            {
                inDir = inDir.TrimEnd('/');
            }

            if (Directory.Exists(outFile))
            {
                Directory.Delete(outFile, true);
            }

            if (File.Exists(outFile))
            {
                File.Delete(outFile);
            }

            ZipFile.CreateFromDirectory(inDir, outFile, CompressionLevel.Fastest, false);
        }

        public static string ZipFolderToTempDir(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            
            if (!dirInfo.Exists)
            {
                throw new ArgumentException("Parameter must be directory.");
            }

            string outputZip = Path.Combine(Path.GetTempPath(), dirInfo.Name);
            outputZip += ".zip";

            ZipFolder(path, outputZip);
            
            return outputZip;
        }


        public static void UnzipFolder(string zipPath, string outputFolder)
        {
            FileInfo zipFileInfo = new FileInfo(zipPath);

            if (!zipFileInfo.Exists)
            {
                throw new ArgumentException("File not exists.");
            }

            string dirName = zipFileInfo.Name.Substring(0, zipFileInfo.Name.LastIndexOf("."));

            string resultDir = Path.Combine(outputFolder, dirName);


            if (Directory.Exists(resultDir))
            {
                Directory.Delete(resultDir, true);
            }

            if (File.Exists(resultDir))
            {
                File.Delete(resultDir);
            }

            ZipFile.ExtractToDirectory(zipPath, outputFolder);
        }

        public static string UnzipFolderToTempDir(string zipPath)
        {
            FileInfo fileInfo = new FileInfo(zipPath);

            if (!fileInfo.Exists)
            {
                throw new ArgumentException("File not exists.");
            }

            string outputZip = Path.Combine(Path.GetTempPath(), fileInfo.Name);

            if (Directory.Exists(outputZip))
            {
                Directory.Delete(outputZip, true);
            }

            if (File.Exists(outputZip))
            {
                File.Delete(outputZip);
            }

            ZipFile.ExtractToDirectory(zipPath, outputZip);
            return outputZip;
        }

        public static long GetDirSize(string path)
        {
            long totalSize = 0;
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            Parallel.For(0, files.Length,
                index =>
                {
                    FileInfo fi = new FileInfo(files[index]);
                    long size = fi.Length;
                    Interlocked.Add(ref totalSize, size);
                });
            return totalSize;
        }
    }
}
