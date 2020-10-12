using System;

namespace Aspose.HTML.Cloud.Sdk.DTO
{
    /// <summary>
    /// File or folder information
    /// </summary>
    public class StorageFile
    {
        #region Constructors Methods

        /// <summary>
        /// </summary>
        /// <param name="name">The file or folder name.</param>
        /// <param name="isFolder"><see cref="bool" />, true if it is a folder.</param>
        /// <param name="date"><see cref="DateTime" /> with the file/folder last modified date.</param>
        /// <param name="size">The file or folder size.</param>
        /// <param name="path">The file or folder path.</param>
        public StorageFile(string name, bool isFolder, DateTime? date, long size, string path)
        {
            Name = name;
            IsFolder = isFolder;
            ModifiedDate = date;
            Size = size;
            Path = path;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks>Needed for XML serialization.</remarks>
        public StorageFile()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// File or folder name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// True if it is a folder.
        /// </summary>
        public bool IsFolder { get; set; }

        /// <summary>
        /// File or folder last modified <see cref="DateTime" />.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// File or folder size.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// File or folder path.
        /// </summary>
        public string Path { get; set; }

        #endregion
    }
}