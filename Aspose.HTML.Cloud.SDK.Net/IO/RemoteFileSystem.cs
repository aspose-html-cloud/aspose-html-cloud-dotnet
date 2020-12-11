using System;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.IO
{
    public class RemoteFileSystem
    {
        private readonly Uri uri;

        protected RemoteFileSystem(Uri uri, RemoteFileSystemInfo info)
        {
            this.uri = uri;
            this.Info = info;
        }

        public string Path => uri.OriginalString;

        public string Name => uri.Segments.Last();

        public RemoteFileSystemInfo Info { get; }
    }
}