using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Conversion.Results;
using Aspose.HTML.Cloud.Sdk.Services;

namespace Aspose.HTML.Cloud.Sdk
{
    public class ConvertApi
    {
        private readonly ConversionService conversionService;

        internal ConvertApi(Configuration config, StorageApi storageApi)
        {
            conversionService = new ConversionService(config, storageApi);
        }

        public async Task<ConvertResult> ConvertAsync(ConverterBuilder builder, IObserver<ConvertResult> observer = null)
        {
            return await conversionService.ConvertAsync(builder, observer);
        }

        public async Task<ConvertResultFile> ConvertAsync(string inputFilePath, string outputFilePath, ConversionOptions options = null, IObserver<ConvertResult> observer = null)
        {
            var builder = new ConverterBuilder()
                .FromLocalFile(inputFilePath)
                .ToLocalFile(outputFilePath)
                .UseOptions(options);
            return await ConvertAsync(builder, observer) as ConvertResultFile;
        }

        public async Task<ConvertResultFile> ConvertAsync(string inputFilePath, IList<string> resources, string outputFilePath, ConversionOptions options = null, IObserver<ConvertResult> observer = null)
        {
            var builder = new ConverterBuilder()
                .FromLocalFile(inputFilePath, resources)
                .ToLocalFile(outputFilePath)
                .UseOptions(options);
            return await ConvertAsync(builder, observer) as ConvertResultFile;
        }

        public async Task<ConvertResultFile> ConvertAsync(string inputFilePath, string resourcesDirectory, string outputFilePath, ConversionOptions options = null, IObserver<ConvertResult> observer = null)
        {
            var builder = new ConverterBuilder()
                .FromLocalFile(inputFilePath, resourcesDirectory)
                .ToLocalFile(outputFilePath)
                .UseOptions(options);
            return await ConvertAsync(builder, observer) as ConvertResultFile;
        }

        public async Task<ConvertResultFile> ConvertUrlAsync(string url, string outputFilePath, ConversionOptions options = null, IObserver<ConvertResult> observer = null)
        {
            return await ConvertAsync(new ConverterBuilder()
                .FromUrl(url)
                .ToLocalFile(outputFilePath)
                .UseOptions(options), observer) as ConvertResultFile;
        }
    }
}
