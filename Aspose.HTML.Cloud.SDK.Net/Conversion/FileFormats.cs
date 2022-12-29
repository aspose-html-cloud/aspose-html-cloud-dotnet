// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="FileFormats.cs">
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
using System.Collections.Generic;
using System.Linq;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    /// <summary>
    /// Formats of the input files.
    /// </summary>
    internal enum InputFormats
    {
        UNDEFINED, 
        HTML, 
        XHTML,
        MHTML,
        EPUB, 
        SVG, 
        MD,
        JPEG,
        PNG,
        BMP,
        GIF,
        TIFF
    }

    /// <summary>
    /// Formats of the output files.
    /// </summary>
    public enum OutputFormats
    {
        UNDEFINED,
        JPEG = 1, 
        PNG, 
        BMP, 
        GIF, 
        TIFF,
        MD, 
        MHTML,
        HTML,
        PDF, 
        XPS, 
        DOC, 
        DOCX,
        SVG
    }

    internal static class FormatsValidation
    {
        private static readonly Dictionary<InputFormats, OutputFormats[]> SupportedFormats =
            new Dictionary<InputFormats, OutputFormats[]>
            {
                {
                    InputFormats.HTML,
                    new[]
                    {
                        OutputFormats.PDF, OutputFormats.XPS, OutputFormats.DOC, OutputFormats.DOCX,
                        OutputFormats.JPEG, OutputFormats.PNG, OutputFormats.BMP, OutputFormats.GIF, OutputFormats.TIFF,
                        OutputFormats.MHTML, OutputFormats.MD
                    }
                },
                {
                    InputFormats.XHTML,
                    new[]
                    {
                        OutputFormats.PDF, OutputFormats.XPS, OutputFormats.DOC, OutputFormats.DOCX,
                        OutputFormats.JPEG, OutputFormats.PNG, OutputFormats.BMP, OutputFormats.GIF, OutputFormats.TIFF,
                        OutputFormats.MHTML, OutputFormats.MD
                    }
                },
                {
                    InputFormats.MHTML,
                    new[]
                    {
                        OutputFormats.HTML,
                        OutputFormats.PDF, OutputFormats.XPS, OutputFormats.DOC, OutputFormats.DOCX,
                        OutputFormats.JPEG, OutputFormats.PNG, OutputFormats.BMP, OutputFormats.GIF, OutputFormats.TIFF
                    }
                },
                {
                    InputFormats.EPUB,
                    new[]
                    {
                        OutputFormats.PDF, OutputFormats.XPS, OutputFormats.DOC, OutputFormats.DOCX,
                        OutputFormats.JPEG, OutputFormats.PNG, OutputFormats.BMP, OutputFormats.GIF, OutputFormats.TIFF
                    }
                },
                {
                    InputFormats.SVG,
                    new[]
                    {
                        OutputFormats.PDF, OutputFormats.XPS,
                        OutputFormats.JPEG, OutputFormats.PNG, OutputFormats.BMP, OutputFormats.GIF, OutputFormats.TIFF
                    }
                },
                {
                    InputFormats.MD,
                    new[]
                    {
                        OutputFormats.HTML, OutputFormats.MHTML,
                        OutputFormats.PDF, OutputFormats.XPS, OutputFormats.DOC, OutputFormats.DOCX,
                        OutputFormats.JPEG, OutputFormats.PNG, OutputFormats.BMP, OutputFormats.GIF, OutputFormats.TIFF
                    }
                },
                {
                    InputFormats.PNG, new[] { OutputFormats.SVG }
                },
                {
                    InputFormats.JPEG, new[] { OutputFormats.SVG }
                },
                {
                    InputFormats.GIF, new[] { OutputFormats.SVG }
                },
                {
                    InputFormats.BMP, new[] { OutputFormats.SVG }
                },
                {
                    InputFormats.TIFF, new[] { OutputFormats.SVG }
                }
            };

        internal static bool IsSupportedConversion(InputFormats inputFormat, OutputFormats output)
        {
            return SupportedFormats.ContainsKey(inputFormat) && SupportedFormats[inputFormat].Any(f => f == output);
        }

        internal static OutputFormats[] GetSupportedOutputFormats(InputFormats inputFormat)
        {
            return SupportedFormats.ContainsKey(inputFormat)
                ? SupportedFormats[inputFormat]
                : Array.Empty<OutputFormats>();
        }
    }
}
