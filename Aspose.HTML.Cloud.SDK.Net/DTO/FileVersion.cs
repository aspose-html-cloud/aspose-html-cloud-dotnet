using System;

namespace Aspose.HTML.Cloud.Sdk.DTO
{
    /// <summary>
    /// File Version
    /// </summary>
    public class FileVersion : StorageFile
    {
        /// <summary>
        /// File version info
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isFolder"></param>
        /// <param name="date"></param>
        /// <param name="size"></param>
        /// <param name="path"></param>
        /// <param name="versionId"></param>
        /// <param name="isLatest"></param>
        public FileVersion(string name, bool isFolder, DateTime? date, long size, string path, string versionId,
            bool isLatest)
            : base(name, isFolder, date, size, path)
        {
            VersionId = versionId;
            IsLatest = isLatest;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks>Needed for XML serialization.</remarks>
        public FileVersion()
        {
        }

        /// <summary>
        /// File Version ID.
        /// </summary>
        public string VersionId { get; set; }

        /// <summary>
        /// Specifies whether the file is (true) or is not (false) the latest version of an file.
        /// </summary>
        public bool IsLatest { get; set; }
    }
}