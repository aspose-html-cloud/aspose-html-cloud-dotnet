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
        /// Conversion output format. 
        /// Read-only property that is set up by To method.
        /// </summary>
        public OutputFormats OutputFormat { get; private set; }

        /// <summary>
        /// List of one or more paths that specify the conversion source. 
        /// Read-only property that is set up by one of From methods.
        /// </summary>
        public List<string> InputPaths { get; private set; }

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
        /// <param name="inputPath">Source directory path.</param>
        /// <param name="startPoint">File name that is a root HTML document.</param>
        /// <returns></returns>
        public ConverterBuilder FromLocalDirectory(string inputPath, string startPoint = null)
        {
            if (String.IsNullOrEmpty(inputPath))
                throw new ArgumentNullException("inputPath");

            if (!Directory.Exists(inputPath))
                throw new IOException("Directory not exists");

            InputPaths = new List<string>() { "file://" + inputPath, startPoint};
            return this;
        }

        /// <summary>
        /// Sets up a conversion source as a ZIP file with linked resources inside, located in a local file system.
        /// </summary>
        /// <param name="archivePath">Source archive path.</param>
        /// <param name="startPoint">File name that is a root HTML document in the archive root.</param>
        /// <returns></returns>
        public ConverterBuilder FromLocalArchive(string archivePath, string startPoint)
        {
            if (String.IsNullOrEmpty(archivePath))
                throw new ArgumentNullException("inputPath");

            if (!File.Exists(archivePath))
                throw new IOException("Zip file not exists");

            if (!archivePath.ToLower().EndsWith(".zip"))
                throw new ArgumentException("File must be a zip file.");

            InputPaths = new List<string>() { "file://" + archivePath, startPoint };
            return this;
        }

        /// <summary>
        /// Sets up a conversion source as a ZIP file with linked resources inside, located in a cloud storage.
        /// </summary>
        /// <param name="archivePath">Source archive path.</param>
        /// <param name="startPoint">File name that is a root HTML document in the archive root.</param>
        /// <returns></returns>
        public ConverterBuilder FromStorageArchive(string archivePath, string startPoint)
        {
            if (String.IsNullOrEmpty(archivePath))
                throw new ArgumentNullException("inputPath");

            if (!archivePath.ToLower().EndsWith(".zip"))
                throw new ArgumentException("File must be a zip file.");

            InputPaths = new List<string>() { "storage://" + archivePath, startPoint };
            return this;
        }

        /// <summary>
        /// Sets up a conversion source as a file or files in a directory 
        /// with linked resources (css, image, etc.), located in a cloud storage.
        /// </summary>
        /// <param name="inPath">Source directory path.</param>
        /// <param name="startPoint">File name that is a root HTML document.</param>
        /// <returns></returns>
        public ConverterBuilder FromStorageDirectory(string inPath, string startPoint)
        {
            if (!inPath.EndsWith("/"))
                inPath += "/";
            if (!inPath.StartsWith("/"))
                inPath = inPath.Insert(0, "/");

            InputPaths = new List<string>() { "storage://" + inPath, startPoint };
            return this;
        }

        /// <summary>
        /// Sets up a conversion source as a file, located in a local file system.
        /// </summary>
        /// <param name="filePath">Source file path</param>
        /// <param name="resources">List of relative paths of resource files (optional).</param>
        /// <returns></returns>
        public ConverterBuilder FromLocalFile(string filePath, params string[] resources)
        {
            if (String.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("Input path is empty");

            filePath = filePath.Trim();

            if (!File.Exists(filePath))
                throw new IOException("File not exists");

            InputPaths = new List<string> { "file://" + filePath };

            foreach (var f in resources)
            {
                InputPaths.Add(f);
            }

            return this;
        }

        /// <summary>
        /// Sets up a conversion source as a file, located in a local file system.
        /// </summary>
        /// <param name="filePath">Source file path</param>
        /// <param name="resources">List of relative paths of resource files (optional).</param>
        /// <returns></returns>
        public ConverterBuilder FromStorageFile(string filePath, params string[] resources)
        {
            if (String.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("Input path is empty");

            if (!filePath.StartsWith("/"))
                filePath = filePath.Insert(0, "/");

            InputPaths = new List<string>(){ "storage://" + filePath };

            foreach (var f in resources)
            {
                InputPaths.Add(f);
            }
            return this;
        }

        /// <summary>
        /// Sets up the conversion source as a Web page by its URL.
        /// </summary>
        /// <param name="url">Source Web page URL</param>
        /// <returns></returns>
        public ConverterBuilder FromUrl(string url)
        {
            InputPaths = new List<string>() { url };
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
        public ConverterBuilder SaveToLocalDirectory(string outputDirectory)   /* filePath=  c:\word\out.jpg; out.jpg*/
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
        public ConverterBuilder SaveToStorageDirectory(string outputDirectory)
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
