// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ImageConversionOptions.cs">
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
    /// Options to convert to image
    /// </summary>
    public class ImageConversionOptions : FixedLayoutConversionOptions
    {
        /// <summary>
        /// Setter of image width.
        /// </summary>
        /// <param name="width">Image width in pixels</param>
        /// <returns>ImageConversionOptions</returns>
        public ImageConversionOptions SetWidth(int width)
        {
            Width = width;
            return this;
        }

        /// <summary>
        /// Setter of image height.
        /// </summary>
        /// <param name="height">Image height in pixels</param>
        /// <returns>ImageConversionOptions</returns>
        public ImageConversionOptions SetHeight(int height)
        {
            Height = height;
            return this;
        }

        /// <summary>
        /// Setter of left margin of image.
        /// </summary>
        /// <param name="leftMargin">Left margin in pixels</param>
        /// <returns>ImageConversionOptions</returns>
        public ImageConversionOptions SetLeftMargin(int leftMargin)
        {
            LeftMargin = leftMargin;
            return this;
        }

        /// <summary>
        /// Setter of right margin of image.
        /// </summary>
        /// <param name="rightMargin">Right margin in pixels</param>
        /// <returns>ImageConversionOptions</returns>
        public ImageConversionOptions SetRightMargin(int rightMargin)
        {
            RightMargin = rightMargin;
            return this;
        }

        /// <summary>
        /// Setter of top margin of image.
        /// </summary>
        /// <param name="topMargin">Top margin in pixels</param>
        /// <returns>ImageConversionOptions</returns>
        public ImageConversionOptions SetTopMargin(int topMargin)
        {
            TopMargin = topMargin;
            return this;
        }

        /// <summary>
        /// Setter of bottom margin of image.
        /// </summary>
        /// <param name="bottomMargin">Bottom margin in pixels</param>
        /// <returns>ImageConversionOptions</returns>
        public ImageConversionOptions SetBottomMargin(int bottomMargin)
        {
            BottomMargin = bottomMargin;
            return this;
        }
    }
}