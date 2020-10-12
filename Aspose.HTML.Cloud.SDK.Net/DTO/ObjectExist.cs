using System;

namespace Aspose.HTML.Cloud.Sdk.DTO
{
    /// <summary>
    /// Object exists
    /// </summary>
    public class ObjectExist
    {
        #region Constructors Methods

        /// <summary>
        /// Creates a new instance of <see cref="ObjectExist" /> class.
        /// </summary>
        /// <param name="exists"><see cref="Boolean" /> true if the file exists.</param>
        /// <param name="isFolder"><see cref="Boolean" /> true if it is a folder.</param>
        public ObjectExist(bool exists, bool isFolder)
        {
            Exists = exists;
            IsFolder = isFolder;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks>Needs for XML serialization.</remarks>
        public ObjectExist()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Indicates that the file or folder exists.
        /// </summary>
        public bool Exists { get; set; }

        /// <summary>
        /// True if it is a folder, false if it is a file.
        /// </summary>
        public bool IsFolder { get; set; }

        #endregion
    }

    /// <summary>
    /// File information extensions.
    /// </summary>
    public static class ObjectExistsExtensions
    {
        /// <summary>
        ///     Whether it exists or not (or is null).
        /// </summary>
        /// <param name="exists"></param>
        private static bool Exists(this ObjectExist exists)
        {
            return exists != null && exists.Exists;
        }

        /// <summary>
        ///     Whether the item exists and is a file.
        /// </summary>
        public static bool ExistsAndIsFile(this ObjectExist exists)
        {
            return exists.Exists() && !exists.IsFolder;
        }

        /// <summary>
        ///     Whether the item exists and is a file.
        /// </summary>
        public static bool ExistsAndIsFolder(this ObjectExist exists)
        {
            return exists.Exists() && exists.IsFolder;
        }
    }
}
