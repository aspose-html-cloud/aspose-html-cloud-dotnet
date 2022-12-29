using System;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Conversion.Results;
using Aspose.HTML.Cloud.Sdk.Services;

namespace Aspose.HTML.Cloud.Sdk
{
    /// <summary>
    /// Conversion API
    /// </summary>
    public class VectorizationApi
    {
        private readonly ConversionService conversionService;

        internal VectorizationApi(Configuration config, StorageApi storageApi)
        {
            conversionService = new ConversionService(config, storageApi);
        }

        /// <summary>
        /// Vectorize method
        /// </summary>
        /// <param name="builder">Builder to configure vectorization</param>
        /// <param name="observer">Observer to watch current conversion status</param>
        /// <returns></returns>
        public async Task<ConvertResult> VectorizeAsync(ConverterBuilder builder, IObserver<ConvertResult> observer = null)
        {
            return await conversionService.ConvertAsync(builder, observer);
        }

        /// <summary>
        /// Vectorize method
        /// </summary>
        /// <param name="inputFilePath">Input path</param>
        /// <param name="outputFilePath">Output path</param>
        /// <param name="options">Conversion options</param>
        /// <param name="observer">Observer to watch current conversion status</param>
        /// <returns></returns>
        public async Task<ConvertResultFile> VectorizeAsync(string inputFilePath, string outputFilePath, VectorizationOptions options = null, IObserver<ConvertResult> observer = null)
        {
            var builder = new ConverterBuilder()
                .FromLocalFile(inputFilePath)
                .ToLocalFile(outputFilePath)
                .UseOptions(options);
            return await VectorizeAsync(builder, observer) as ConvertResultFile;
        }


        /// <summary>
        /// Vectorize image from URL to SVG file
        /// </summary>
        /// <param name="url">The URL to convert</param>
        /// <param name="outputFilePath">Output path</param>
        /// <param name="options">Conversion options</param>
        /// <param name="observer">Observer to watch current conversion status</param>
        /// <returns></returns>
        public async Task<ConvertResultFile> VectorizeUrlAsync(string url, string outputFilePath, VectorizationOptions options = null, IObserver<ConvertResult> observer = null)
        {
            return await VectorizeAsync(new ConverterBuilder()
                .FromUrl(url)
                .ToLocalFile(outputFilePath)
                .UseOptions(options), observer) as ConvertResultFile;
        }
    }
}
