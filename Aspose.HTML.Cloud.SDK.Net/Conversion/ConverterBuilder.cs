﻿// --------------------------------------------------------------------------------------------------------------------
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
    public class ConverterBuilder
    {
        public InputFormats InputFormat { get; private set; }
        public OutputFormats OutputFormat { get; private set; }
        public List<string> InputPath { get; private set; }
        public string OutputPath { get; private set; }
        public ConversionOptions Options { get; private set; }

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

        public ConverterBuilder FromStorageFile(string inPath)
        {
            if (String.IsNullOrEmpty(inPath))
                throw new ArgumentNullException("Input path is empty");

            if (!inPath.StartsWith("/"))
                inPath = inPath.Insert(0, "/");

            InputPath = new List<string>(){ "storage://" + inPath };
            return this;
        }

        public ConverterBuilder FromUrl(string inPath)
        {
            InputPath = new List<string>() { inPath };
            return this;
        }

        public ConverterBuilder To(ConversionOptions options)
        {
            OutputFormat = options.Format;
            Options = options;
            return this;
        }

        public ConverterBuilder SaveToLocal(string outputDirectory)
        {
            if (String.IsNullOrEmpty(outputDirectory))
                throw new ArgumentNullException("Output path is empty");

            OutputPath = "file://" + outputDirectory.Trim();
            return this;
        }

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
