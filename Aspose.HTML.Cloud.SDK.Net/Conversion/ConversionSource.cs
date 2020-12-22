// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ConversionSource.cs">
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

using Aspose.HTML.Cloud.Sdk.Conversion.Sources;
using Aspose.HTML.Cloud.Sdk.IO;
using System.Collections.Generic;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public abstract class ConversionSource
    {
        protected ConversionSource(List<string> paths)
        {
            this.Paths = paths;
        }

        public List<string> Paths { get; }
        public string Path { 
            get {
                return Paths[0];
            } 
        }

        public static ConversionSource FromRemoteFile(List<string> paths)
        {
            return new RemoteFileConversionSource(paths); 
        }

        public static ConversionSource FromRemoteFile(List<RemoteFile> files)
        {
            return new RemoteFileConversionSource(files);
        }

        public static PackageConversionSource FromRemoteArchiveFile(List<string> paths)
        {
            return new RemoteArchiveConversionSource(paths);
        }

        public static PackageConversionSource FromRemoteArchiveFile(List<RemoteFile> files)
        {
            return new RemoteArchiveConversionSource(files);
        }

        public static FileSetConversionSource FromLocalFile(List<string> paths)
        {
            return new LocalFileSetConversionSource(paths);
        }

        public static FileSetConversionSource FromLocalFile(string path)
        {
            return new LocalFileSetConversionSource(new List<string>() { path });
        }

        public static PackageConversionSource FromLocalArchiveFile(string path)
        {
            return new LocalArchiveConversionSource(new List<string>() { path });
        }

        public static PackageConversionSource FromLocalArchiveFile(List<string> paths)
        {
            return new LocalArchiveConversionSource(paths);
        }

        public static PackageConversionSource FromLocalDirectory(string path)
        {
            return new LocalDirectoryConversionSource(new List<string> { path });
        }

        public static PackageConversionSource FromLocalDirectory(List<string> paths)
        {
            return new LocalDirectoryConversionSource(paths);
        }
    }
}
