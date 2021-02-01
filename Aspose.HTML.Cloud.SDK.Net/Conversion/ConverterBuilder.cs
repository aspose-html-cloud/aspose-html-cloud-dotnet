// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ConverterBuilder.cs">
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
using System.Collections.Generic;
using System.IO;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    /// <summary>
    ///  Class that is used to build the conversion parameters.
    /// </summary>
    public class ConverterBuilder
    {
        /// <summary>
        /// Format of the conversion source file(s). Read-only property that is derived from the source .
        /// </summary>
        public InputFormats InputFormat { get; private set; }

        /// <summary>
        /// Conversion output format. 
        /// Read-only property that is set up by To method.
        /// </summary>
        public OutputFormats OutputFormat { get; private set; }

        /// <summary>
        /// List of one or more paths that specify the conversion source. 
        /// Read-only property that is set up by one of From methods.
        /// </summary>
        public List<string> InputPath { get; private set; }

        /// <summary>
        /// Path of the conversion result file.  
        /// Read-only property that is set up by one of SaveTo methods.
        /// </summary>
        public string OutputPath { get; private set; }

        /// <summary>
        /// Conversion options; object of one of ConversionOptions derived classes. 
        /// Read-only property that is set up by To method.
        /// </summary>
        public ConversionOptions Options { get; private set; }

        /// <summary>
        /// Sets up a conversion source as a file or files in a directory 
        /// with linked resources (css, image, etc.), located in a local file system.
        /// </summary>
        /// <param name="inPath">Source directory path.</param>
        /// <param name="startPoint">File name that is a root HTML document.</param>
        /// <param name="files">List of relative paths of resource files.</param>
        /// <returns></returns>
        public ConverterBuilder FromLocalDirectory(string inPath, string startPoint, params string[] files)
        {
            if (String.IsNullOrEmpty(inPath))
                throw new ArgumentNullException("inputPath");

            if (!Directory.Exists(inPath))
                throw new IOException("Directory not exists");

            InputPath = new List<string>() { "file://" + inPath, startPoint};

            foreach (var f in files) 
            {
                InputPath.Add(f);
            }

            return this;
        }

        /// <summary>
        /// Sets up a conversion source as a ZIP file with linked resources inside, located in a local file system.
        /// </summary>
        /// <param name="inPath">Source archive path.</param>
        /// <param name="startPoint">File name that is a root HTML document in the archive root.</param>
        /// <param name="files">List of relative paths of resource files withing the archive.</param>
        /// <returns></returns>
        public ConverterBuilder FromLocalArchive(string inPath, string startPoint, params string[] files)
        {
            if (String.IsNullOrEmpty(inPath))
                throw new ArgumentNullException("inputPath");

            if (!File.Exists(inPath))
                throw new IOException("Zip file not exists");

            if (!inPath.ToLower().EndsWith(".zip"))
                throw new ArgumentException("File must be a zip file.");

            InputPath = new List<string>() { "file://" + inPath, startPoint };

            foreach (var f in files)
            {
                InputPath.Add(f);
            }

            return this;
        }

        /// <summary>
        /// Sets up a conversion source as a ZIP file with linked resources inside, located in a cloud storage.
        /// </summary>
        /// <param name="inPath">Source archive path.</param>
        /// <param name="startPoint">File name that is a root HTML document in the archive root.</param>
        /// <param name="files">List of relative paths of resource files withing the archive.</param>
        /// <returns></returns>
        public ConverterBuilder FromStorageArchive(string inPath, string startPoint, params string[] files)
        {
            if (String.IsNullOrEmpty(inPath))
                throw new ArgumentNullException("inputPath");

            if (!inPath.ToLower().EndsWith(".zip"))
                throw new ArgumentException("File must be a zip file.");

            InputPath = new List<string>() { "storage://" + inPath, startPoint };

            foreach (var f in files)
            {
                InputPath.Add(f);
            }

            return this;
        }

        /// <summary>
        /// Sets up a conversion source as a file or files in a directory 
        /// with linked resources (css, image, etc.), located in a cloud storage.
        /// </summary>
        /// <param name="inPath">Source directory path.</param>
        /// <param name="startPoint">File name that is a root HTML document.</param>
        /// <param name="files">List of relative paths of resource files.</param>
        /// <returns></returns>
        public ConverterBuilder FromStorageDirectory(string inPath, string startPoint, params string[] files)
        {
            if (!inPath.EndsWith("/"))
                inPath += "/";
            if (!inPath.StartsWith("/"))
                inPath = inPath.Insert(0, "/");

            InputPath = new List<string>() { "file://" + inPath, startPoint };

            foreach (var f in files)
            {
                InputPath.Add(f);
            }

            return this;
        }

        /// <summary>
        /// Sets up a conversion source as a file, located in a local file system.
        /// </summary>
        /// <param name="inputPath">Source file path</param>
        /// <returns></returns>
        public ConverterBuilder FromLocalFile(string inputPath)
        {
            if (String.IsNullOrEmpty(inputPath))
                throw new ArgumentNullException("Input path is empty");

            inputPath = inputPath.Trim();

            if (!File.Exists(inputPath))
                throw new IOException("File not exists");

            InputPath = new List<string> { "file://" + inputPath };
            return this;
        }

        /// <summary>
        /// Sets up a conversion source as a file, located in a local file system.
        /// </summary>
        /// <param name="inPath">Source file path</param>
        /// <returns></returns>
        public ConverterBuilder FromStorageFile(string inPath)
        {
            if (String.IsNullOrEmpty(inPath))
                throw new ArgumentNullException("Input path is empty");

            if (!inPath.StartsWith("/"))
                inPath = inPath.Insert(0, "/");

            InputPath = new List<string>(){ "storage://" + inPath };
            return this;
        }

        /// <summary>
        /// Sets up the conversion source as a Web page by its URL.
        /// </summary>
        /// <param name="inPath">Source Web page URL</param>
        /// <returns></returns>
        public ConverterBuilder FromUrl(string inPath)
        {
            InputPath = new List<string>() { inPath };
            return this;
        }

        /// <summary>
        /// Sets up the conversion output format by using of an instance of 
        /// one of ConversionOptions derived classes, with some additional format specific conversion options.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public ConverterBuilder To(ConversionOptions options)
        {
            OutputFormat = options.Format;
            Options = options;
            return this;
        }

        /// <summary>
        /// Sets up the local file system directory where the conversion result will be saved to.
        /// </summary>
        /// <param name="outputDirectory">Local directory path to save to.</param>
        /// <returns></returns>
        public ConverterBuilder SaveToLocal(string outputDirectory)
        {
            if (String.IsNullOrEmpty(outputDirectory))
                throw new ArgumentNullException("Output path is empty");

            OutputPath = "file://" + outputDirectory.Trim();
            return this;
        }

        /// <summary>
        /// Sets up the cloud storage directory where the conversion result will be saved to.
        /// </summary>
        /// <param name="outputDirectory">Storage directory path to save to.</param>
        /// <returns></returns>
        public ConverterBuilder SaveToStorage(string outputDirectory)
        {
            if (String.IsNullOrEmpty(outputDirectory))
                throw new ArgumentNullException("Output path is empty");

            if (!outputDirectory.StartsWith("/"))
                outputDirectory = outputDirectory.Insert(0, "/");

            if (!outputDirectory.EndsWith("/"))
                outputDirectory += "/";

            OutputPath = "storage://" + outputDirectory.Trim();
            return this;
        }
    }
}
