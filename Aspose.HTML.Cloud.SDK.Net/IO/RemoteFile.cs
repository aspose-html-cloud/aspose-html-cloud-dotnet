using System;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Aspose.HTML.Cloud.Sdk.Tests")]
[assembly: InternalsVisibleTo("Aspose.HTML.Cloud.Sdk.PackageTests")]
namespace Aspose.HTML.Cloud.Sdk.IO
{
    public class RemoteFile : RemoteFileSystem
    {
        internal RemoteFile(Uri uri, RemoteFileSystemInfo info) 
            : base(uri, info)
        {}
    }
}