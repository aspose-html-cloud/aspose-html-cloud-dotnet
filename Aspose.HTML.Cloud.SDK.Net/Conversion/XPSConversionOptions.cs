// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="XPSConversionOptions.cs">
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
    public class XPSConversionOptions : FixedLayoutConversionOptions
    {
        /// <summary>
        /// Setter of XPS width.
        /// </summary>
        /// <param name="width">XPS width in inches</param>
        /// <returns>XPSConversionOptions</returns>
        public XPSConversionOptions SetWidth(int width)
        {
            Width = width;
            return this;
        }

        /// <summary>
        /// Setter of XPS height.
        /// </summary>
        /// <param name="height">XPS height in inches</param>
        /// <returns>XPSConversionOptions</returns>
        public XPSConversionOptions SetHeight(int height)
        {
            Height = height;
            return this;
        }

        /// <summary>
        /// Setter of XPS left margin.
        /// </summary>
        /// <param name="leftMargin">XPS left margin in inches</param>
        /// <returns>XPSConversionOptions</returns>
        public XPSConversionOptions SetLeftMargin(int leftMargin)
        {
            LeftMargin = leftMargin;
            return this;
        }

        /// <summary>
        /// Setter of XPS right margin.
        /// </summary>
        /// <param name="rightMargin">XPS right margin in inches</param>
        /// <returns>XPSConversionOptions</returns>
        public XPSConversionOptions SetRightMargin(int rightMargin)
        {
            RightMargin = rightMargin;
            return this;
        }

        /// <summary>
        /// Setter of XPS top margin.
        /// </summary>
        /// <param name="topMargin">XPS top margin in inches</param>
        /// <returns>XPSConversionOptions</returns>
        public XPSConversionOptions SetTopMargin(int topMargin)
        {
            TopMargin = topMargin;
            return this;
        }

        /// <summary>
        /// Setter of XPS bottom margin.
        /// </summary>
        /// <param name="bottomMargin">XPS bottom margin in inches</param>
        /// <returns>XPSConversionOptions</returns>
        public XPSConversionOptions SetBottomMargin(int bottomMargin)
        {
            BottomMargin = bottomMargin;
            return this;
        }
    }
}