using System;

namespace Aspose.HTML.Cloud.Sdk.IO
{
    public class RemoteFileSystemInfo
    {
        public RemoteFileSystemInfo(/*RemoteFileSystem @object,*/ long size, DateTime time, VersionInfo versions = null)
        {
            //ParentObject = @object;
            Size = size;
            LastModifiedDate = time;
            Versions = versions;
        }

        //private RemoteFileSystem ParentObject { get; set; }

        public long Size { get; protected set; }

        public DateTime LastModifiedDate { get; protected set; }

        public VersionInfo Versions { get; protected set; }
    }
}