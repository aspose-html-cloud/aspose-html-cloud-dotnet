// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ConverterBuilder.cs">
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
using System.IO;
using System.Linq;
using Aspose.HTML.Cloud.Sdk.Common.Extensions;
using Aspose.HTML.Cloud.Sdk.Conversion.Sources;
using static Aspose.HTML.Cloud.Sdk.Models.FilesUploadResult;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    /// <summary>
    /// Builder for conversion request
    /// </summary>
    public class ConverterBuilder
    {
        internal ConversionOptions Options { get; private set; }
        internal ConversionResultFormat ResultFormat { get; private set; }
        internal OutputFormats OutputFormat { get; private set; }
        internal InputFormats InputFormat { get; private set; }
        internal string OutputFilePath { get; private set; }
        internal string StorageName { get; set; }
        internal ConversionDataSource Source { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ConverterBuilder()
        {
            Source = new ConversionDataSource();
        }

        /// <summary>
        /// Define local file to convert
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="resources">List of resources if any. For example CSS and images files used in HTML</param>
        /// <returns></returns>
        public ConverterBuilder FromLocalFile(string filePath, IList<string> resources)
        {
            FromLocalFile(filePath);
            Source.Resources = resources;
            return this;
        }

        /// <summary>
        /// Define local file to convert
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="resourcesDirectory">Directory with resources. or example CSS and images files used in HTML</param>
        /// <returns></returns>
        public ConverterBuilder FromLocalFile(string filePath, string resourcesDirectory)
        {
            FromLocalFile(filePath);
            Source.ResourcesFolder = resourcesDirectory;
            return this;
        }

        /// <summary>
        /// Define local file to convert
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns></returns>
        public ConverterBuilder FromLocalFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            filePath = filePath.Trim();

            if (!File.Exists(filePath))
            {
                throw new IOException("File not found");
            }

            var inputFormat = filePath.GetFileFormatFromFile<InputFormats>();
            if (!inputFormat.HasValue)
            {
                throw new ArgumentException("Not supported output file extension");
            }

            InputFormat = inputFormat.Value;
            Source.FilePath = filePath;
            Source.IsLocal = true;
            return this;
        }

        /// <summary>
        /// Define remote file to convert
        /// </summary>
        /// <param name="filePath">Path to file in storage</param>
        /// <param name="storageName">Storage name</param>
        /// <returns></returns>
        public ConverterBuilder FromStorageFile(string filePath, string storageName)
        {
            if (!string.IsNullOrWhiteSpace(StorageName) &&
                !string.Equals(StorageName, storageName, StringComparison.OrdinalIgnoreCase))
            {
                throw new IOException("Only same storage conversion is allowed");
            }
            StorageName = storageName;
            return FromStorageFile(filePath);
        }

        /// <summary>
        /// Define remote file to convert
        /// </summary>
        /// <param name="filePath">Path to file in storage</param>
        /// <returns></returns>
        public ConverterBuilder FromStorageFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }
            var inputFormat = filePath.GetFileFormatFromFile<InputFormats>();
            if (!inputFormat.HasValue)
            {
                throw new ArgumentException("Not supported input file extension");
            }
            InputFormat = inputFormat.Value;
            Source.FilePath = filePath;
            Source.IsLocal = false;
            return this;
        }

        /// <summary>
        /// Define url to convert
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns></returns>
        public ConverterBuilder FromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            // Fallback to HTML since it is url
            var inputFormat = url.GetFileFormatFromFile<InputFormats>() ?? InputFormats.HTML;
            InputFormat = inputFormat;
            Source.FilePath = url;
            return this;
        }

        /// <summary>
        /// Define conversion output local path
        /// </summary>
        /// <param name="outputFilePath">Local path to output file</param>
        /// <returns></returns>
        public ConverterBuilder ToLocalFile(string outputFilePath)
        {
            if (string.IsNullOrWhiteSpace(outputFilePath))
            {
                throw new ArgumentNullException(nameof(outputFilePath));
            }

            var outputFormat = outputFilePath.GetFileFormatFromFile<OutputFormats>();
            if (!outputFormat.HasValue)
            {
                throw new ArgumentException("Not supported output file extension");
            }

            ResultFormat = ConversionResultFormat.LocalFile;
            OutputFormat = outputFormat.Value;
            OutputFilePath = outputFilePath;
            return this;
        }

        /// <summary>
        /// Define conversion output storage path
        /// </summary>
        /// <param name="outputFilePath">Storage path to output file</param>
        /// <param name="storageName">Storage name</param>
        /// <returns></returns>
        public ConverterBuilder ToStorageFile(string outputFilePath, string storageName)
        {
            if (!string.IsNullOrWhiteSpace(StorageName) &&
                !string.Equals(StorageName, storageName, StringComparison.OrdinalIgnoreCase))
            {
                throw new IOException("Only same storage conversion is allowed");
            }
            StorageName = storageName;
            return ToStorageFile(outputFilePath);
        }

        /// <summary>
        /// Define conversion output storage path
        /// </summary>
        /// <param name="outputFilePath">Storage path to output file</param>
        /// <returns></returns>
        public ConverterBuilder ToStorageFile(string outputFilePath)
        {
            if (string.IsNullOrWhiteSpace(outputFilePath))
            {
                throw new ArgumentNullException(nameof(outputFilePath));
            }

            var outputFormat = outputFilePath.GetFileFormatFromFile<OutputFormats>();
            if (!outputFormat.HasValue)
            {
                throw new ArgumentException("Not supported output file extension");
            }

            ResultFormat = ConversionResultFormat.StorageFile;
            OutputFormat = outputFormat.Value;
            OutputFilePath = $"{outputFilePath}";
            return this;
        }

        /// <summary>
        /// Define options used in conversion
        /// </summary>
        /// <param name="options">The options</param>
        /// <returns></returns>
        public ConverterBuilder UseOptions(ConversionOptions options)
        {
            if (options == null)
            {
                return this;
            }
            Options = options;
            return this;
        }

        /// <summary>
        /// Validate builder
        /// </summary>
        /// <exception cref="Exception">Exception if builder configuration is not valid</exception>
        public void Validate()
        {
            var errors = new List<string>();

            if (InputFormat == InputFormats.UNDEFINED)
            {
                errors.Add("Input format is not defined");
            }

            if (OutputFormat == OutputFormats.UNDEFINED)
            {
                errors.Add("Output format is not defined");
            }

            if (!FormatsValidation.IsSupportedConversion(InputFormat, OutputFormat))
            {
                var supportedFormats = FormatsValidation.GetSupportedOutputFormats(InputFormat);
                errors.Add($"Conversion from {InputFormat} to {OutputFormat} is not supported. {InputFormat} can be converted into {string.Join(", ", supportedFormats.Select(f=>f.ToString()))}");
            }

            if (errors.Any())
            {
                throw new Exception(string.Join("; ", errors));
            }

        }
    }
}
