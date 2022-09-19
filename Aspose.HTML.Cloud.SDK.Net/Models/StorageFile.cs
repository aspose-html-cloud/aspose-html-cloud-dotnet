// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="StorageFile.cs">
//   Copyright (c) 2022 Aspose.HTML Cloud
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

namespace Aspose.HTML.Cloud.Sdk.Models
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