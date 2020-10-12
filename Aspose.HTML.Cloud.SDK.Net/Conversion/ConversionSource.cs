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
