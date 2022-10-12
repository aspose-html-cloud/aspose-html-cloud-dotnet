﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="FixedLayoutConversionOptions.cs">
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

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    /// <summary>
    /// Conversion options for files with fixed layout
    /// </summary>
    public abstract class FixedLayoutConversionOptions : ConversionOptions
    {
        /// <summary>
        /// Width
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Left Margin
        /// </summary>
        public int? LeftMargin { get; set; }

        /// <summary>
        /// Right Margin
        /// </summary>
        public int? RightMargin { get; set; }

        /// <summary>
        /// Top Margin
        /// </summary>
        public int? TopMargin { get; set; }

        /// <summary>
        /// Bottom Margin
        /// </summary>
        public int? BottomMargin { get; set; }

    }
}