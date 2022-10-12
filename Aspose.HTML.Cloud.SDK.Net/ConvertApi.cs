using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Conversion.Results;
using Aspose.HTML.Cloud.Sdk.Services;

namespace Aspose.HTML.Cloud.Sdk
{
    /// <summary>
    /// Conversion API
    /// </summary>
    public class ConvertApi
    {
        private readonly ConversionService conversionService;

        internal ConvertApi(Configuration config, StorageApi storageApi)
        {
            conversionService = new ConversionService(config, storageApi);
        }

        /// <summary>
        /// Conversion method
        /// </summary>
        /// <param name="builder">Builder to configure conversion</param>
        /// <param name="observer">Observer to watch current conversion status</param>
        /// <returns></returns>
        public async Task<ConvertResult> ConvertAsync(ConverterBuilder builder, IObserver<ConvertResult> observer = null)
        {
            return await conversionService.ConvertAsync(builder, observer);
        }

        /// <summary>
        /// Conversion method
        /// </summary>
        /// <param name="inputFilePath">Input path</param>
        /// <param name="outputFilePath">Output path</param>
        /// <param name="options">Conversion options</param>
        /// <param name="observer">Observer to watch current conversion status</param>
        /// <returns></returns>
        public async Task<ConvertResultFile> ConvertAsync(string inputFilePath, string outputFilePath, ConversionOptions options = null, IObserver<ConvertResult> observer = null)
        {
            var builder = new ConverterBuilder()
                .FromLocalFile(inputFilePath)
                .ToLocalFile(outputFilePath)
                .UseOptions(options);
            return await ConvertAsync(builder, observer) as ConvertResultFile;
        }

        /// <summary>
        /// Conversion method
        /// </summary>
        /// <param name="inputFilePath">Input path</param>
        /// <param name="resources">List of resources needed for conversion (css, images, etc)</param>
        /// <param name="outputFilePath">Output path</param>
        /// <param name="options">Conversion options</param>
        /// <param name="observer">Observer to watch current conversion status</param>
        /// <returns></returns>
        public async Task<ConvertResultFile> ConvertAsync(string inputFilePath, IList<string> resources, string outputFilePath, ConversionOptions options = null, IObserver<ConvertResult> observer = null)
        {
            var builder = new ConverterBuilder()
                .FromLocalFile(inputFilePath, resources)
                .ToLocalFile(outputFilePath)
                .UseOptions(options);
            return await ConvertAsync(builder, observer) as ConvertResultFile;
        }

        /// <summary>
        /// Conversion method
        /// </summary>
        /// <param name="inputFilePath">Input path</param>
        /// <param name="resourcesDirectory">Directory with resources needed for conversion (css, images, etc)</param>
        /// <param name="outputFilePath">Output path</param>
        /// <param name="options">Conversion options</param>
        /// <param name="observer">Observer to watch current conversion status</param>
        /// <returns></returns>
        public async Task<ConvertResultFile> ConvertAsync(string inputFilePath, string resourcesDirectory, string outputFilePath, ConversionOptions options = null, IObserver<ConvertResult> observer = null)
        {
            var builder = new ConverterBuilder()
                .FromLocalFile(inputFilePath, resourcesDirectory)
                .ToLocalFile(outputFilePath)
                .UseOptions(options);
            return await ConvertAsync(builder, observer) as ConvertResultFile;
        }

        /// <summary>
        /// Convert URL to file
        /// </summary>
        /// <param name="url">The URL to convert</param>
        /// <param name="outputFilePath">Output path</param>
        /// <param name="options">Conversion options</param>
        /// <param name="observer">Observer to watch current conversion status</param>
        /// <returns></returns>
        public async Task<ConvertResultFile> ConvertUrlAsync(string url, string outputFilePath, ConversionOptions options = null, IObserver<ConvertResult> observer = null)
        {
            return await ConvertAsync(new ConverterBuilder()
                .FromUrl(url)
                .ToLocalFile(outputFilePath)
                .UseOptions(options), observer) as ConvertResultFile;
        }
    }
}
