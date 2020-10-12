using System;
using System.Collections.Generic;
using System.IO;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class ConverterBuilder
    {
        public InputFormats inputFormat { get; private set; }
        public OutputFormats outputFormat { get; private set; }
        public List<string> inputPath { get; private set; }
        public string outputPath { get; private set; }
        public ConversionOptions options { get; private set; }

        public ConverterBuilder fromLocalDirectory(string inPath, string startPoint, params string[] files)
        {
            if (String.IsNullOrEmpty(inPath))
                throw new ArgumentNullException("inputPath");

            if (!Directory.Exists(inPath))
                throw new IOException("Directory not exists");

            this.inputPath = new List<string>() { "file://" + inPath, startPoint};

            foreach (var f in files) 
            {
                this.inputPath.Add(f);
            }

            return this;
        }
        public ConverterBuilder fromLocalArchive(string inPath, string startPoint, params string[] files)
        {
            if (String.IsNullOrEmpty(inPath))
                throw new ArgumentNullException("inputPath");

            if (!File.Exists(inPath))
                throw new IOException("Zip file not exists");

            if (!inPath.ToLower().EndsWith(".zip"))
                throw new ArgumentException("File must be a zip file.");

            this.inputPath = new List<string>() { "file://" + inPath, startPoint };

            foreach (var f in files)
            {
                this.inputPath.Add(f);
            }

            return this;
        }

        public ConverterBuilder fromStorageArchive(string inPath, string startPoint, params string[] files)
        {
            if (String.IsNullOrEmpty(inPath))
                throw new ArgumentNullException("inputPath");

            if (!inPath.ToLower().EndsWith(".zip"))
                throw new ArgumentException("File must be a zip file.");

            this.inputPath = new List<string>() { "storage://" + inPath, startPoint };

            foreach (var f in files)
            {
                this.inputPath.Add(f);
            }

            return this;
        }

        public ConverterBuilder fromStorageDirectory(string inPath, string startPoint, params string[] files)
        {
            if (!inPath.EndsWith("/"))
                inPath += "/";
            if (!inPath.StartsWith("/"))
                inPath = inPath.Insert(0, "/");

            this.inputPath = new List<string>() { "file://" + inPath, startPoint };

            foreach (var f in files)
            {
                this.inputPath.Add(f);
            }

            return this;
        }

        public ConverterBuilder fromLocalFile(string inputPath)
        {
            if (String.IsNullOrEmpty(inputPath))
                throw new ArgumentNullException("Input path is empty");

            inputPath = inputPath.Trim();

            if (!File.Exists(inputPath))
                throw new IOException("File not exists");

            this.inputPath = new List<string> { "file://" + inputPath };
            return this;
        }

        public ConverterBuilder fromStorageFile(string inPath)
        {
            if (String.IsNullOrEmpty(inPath))
                throw new ArgumentNullException("Input path is empty");

            if (!inPath.StartsWith("/"))
                inPath = inPath.Insert(0, "/");

            this.inputPath = new List<string>(){ "storage://" + inPath };
            return this;
        }

        public ConverterBuilder fromUrl(string inPath)
        {
            this.inputPath = new List<string>() { inPath };
            return this;
        }

        public ConverterBuilder fromStream(Stream stream, InputFormats format)
        {
            this.inputFormat = format;
            return this;
        }

        public ConverterBuilder to(ConversionOptions options)
        {
            this.outputFormat = options.Format;
            this.options = options;
            return this;
        }

        public ConverterBuilder SaveToLocal(string outputDirectory)
        {
            if (String.IsNullOrEmpty(outputDirectory))
                throw new ArgumentNullException("Output path is empty");

            this.outputPath = "file://" + outputDirectory.Trim();
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

            this.outputPath = "storage://" + outputDirectory.Trim();
            return this;
        }
    }
}
