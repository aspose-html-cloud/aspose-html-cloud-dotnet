namespace Aspose.HTML.Cloud.Sdk.IO
{
    public class Storage
    {
        public Storage(string name, long usedSize, long totalSize)
        {
            Name = name;
            UsedSize = usedSize;
            TotalSize = totalSize;
        }

        public string Name { get; }
        public long UsedSize { get; }
        public long TotalSize { get; }
    }
}