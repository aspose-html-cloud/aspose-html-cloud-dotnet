// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ObjectExist.cs">
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
