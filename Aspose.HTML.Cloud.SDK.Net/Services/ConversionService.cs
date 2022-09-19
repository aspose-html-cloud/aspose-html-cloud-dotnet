using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Common;
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Conversion.Results;
using Aspose.HTML.Cloud.Sdk.IO;
using Aspose.HTML.Cloud.Sdk.Runtime;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using Newtonsoft.Json;

namespace Aspose.HTML.Cloud.Sdk.Services
{
    internal class ConversionService : IDisposable
    {
        private const string CONVERSION_URI = "/v4.0/html/conversion";
        private const int UPDATE_INTERVAL = 100;

        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly TaskFactory taskFactory;
        private readonly StorageApi storageApi;
        private readonly ApiInvokerFactory apiInvokerFactory;
        private readonly Configuration configuration;

        internal ConversionService(Configuration configuration, StorageApi storageApi)
        {
            this.storageApi = storageApi;
            this.configuration = configuration;
            taskFactory = new TaskFactory(cancellationTokenSource.Token);
            apiInvokerFactory = new ApiInvokerFactory(configuration);
        }

        internal async Task<ConvertResult> ConvertAsync(ConverterBuilder builder, IObserver<ConvertResult> observer = null)
        {
            try
            {
                var result = await ExecuteConversionAsync(builder, observer);

                if (result.Status == ConvertResultStatus.Completed)
                {
                    switch (builder.ResultFormat)
                    {
                        case ConversionResultFormat.LocalFile:
                            {
                                await SaveToLocalAsync(builder.OutputFilePath, result, builder.StorageName);
                                await ClearServerDirectoryAsync(result, builder.StorageName);
                                return result;
                            }
                        case ConversionResultFormat.StorageFile:
                            {
                                if (result is ConvertResultFile fileResult)
                                {
                                    var output = fileResult.OutputFile.Replace(ConversionConstants.STORAGE_PROTOCOL, string.Empty).Trim();
                                    fileResult.OutputFile = output;
                                }

                                return result;
                            }
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                observer?.OnError(e);
                throw;
            }
        }

        internal async Task<bool> DeleteTaskAsync(string id)
        {
            var query = CONVERSION_URI + $@"/{id}";
            using (var restClient = new HttpClient())
            {
                restClient.BaseAddress = new Uri(configuration.BaseUrl);
                var response = await restClient.DeleteAsync(query);
                return response.IsSuccessStatusCode;
            }
        }

        private async Task ClearServerDirectoryAsync(ConvertResult result, string storageName)
        {
            var fileResult = result as ConvertResultFile;
            if (fileResult == null)
            {
                return;
            }

            var dir = Path.GetDirectoryName(fileResult.OutputFile);
            await storageApi.DeleteDirectoryAsync(dir, storageName, true);
        }

        private async Task SaveToLocalAsync(string outputPath, ConvertResult result, string storageName)
        {
            var fileResult = result as ConvertResultFile;
            if (fileResult == null)
            {
                return;
            }

            var directory = Path.GetDirectoryName(outputPath);

            if (!Directory.Exists(directory) && !string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            var outputDirectory = Path.GetDirectoryName(outputPath);
            var name = Path.GetFileName(fileResult.OutputFile);
            var outputFilePath = string.IsNullOrWhiteSpace(outputDirectory) ? name : Path.Combine(outputDirectory, name);
            await storageApi.DownloadFileAsync(fileResult.OutputFile, outputFilePath, storageName);
        }

        private async Task<ConvertResult> ExecuteConversionAsync(
            ConverterBuilder builder,
            IObserver<ConvertResult> observer)
        {

            // TODO: Refactor to byte[] option
            var convertResult = new ConvertResultFile
            {
                Status = ConvertResultStatus.Uploading
            };

            observer?.OnNext(convertResult);

            await await taskFactory.StartNew(async () =>
            {

                var query = CONVERSION_URI + $@"/{builder.InputFormat}-{builder.OutputFormat}";
                var request = await PrepareRequestBodyAsync(builder);
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                var payload = JsonConvert.SerializeObject(request, settings);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                var apiInvoker = apiInvokerFactory.GetInvoker<ConversionResult>();
                var resultDto = await apiInvoker.CallPostAsync(query, content);
                convertResult.Status = ConvertResultStatus.Running;
                observer?.OnNext(convertResult);

                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    if (convertResult.Status != ConvertResultStatus.Pending &&
                        convertResult.Status != ConvertResultStatus.Running && 
                        convertResult.Status != ConvertResultStatus.Uploading)
                    {
                        observer?.OnCompleted();
                        break;
                    }

                    Thread.Sleep(UPDATE_INTERVAL);
                    resultDto = await apiInvoker.CallGetAsync(resultDto.Links.Self, BuildFailedResult);
                    convertResult.UpdateFromResponse(resultDto);
                }

            }, cancellationTokenSource.Token);

            return convertResult;
        }

        private static ConversionResult BuildFailedResult(string message)
        {
            return new ConversionResult
            {
                Status = ConvertResultStatus.Failed.ToString(),
                Description = message
            };
        }

        private async Task<ConversionRequestModel> PrepareRequestBodyAsync(ConverterBuilder builder)
        {
            var createModel = new ConversionRequestModel
            {
                StorageName = builder.StorageName,
                Resources = new List<string>(),
                Options = builder.Options
            };

            if (builder.ResultFormat == ConversionResultFormat.LocalFile)
            {
                if (!string.IsNullOrWhiteSpace(builder.OutputFilePath))
                {
                    createModel.OutputFile = StorageUtils.GetLocalUri(Path.GetFileName(builder.OutputFilePath));
                }
            }

            if (builder.ResultFormat == ConversionResultFormat.StorageFile)
            {
                if (!string.IsNullOrWhiteSpace(builder.OutputFilePath))
                {
                    createModel.OutputFile = builder.OutputFilePath;
                }
            }

            var uploadFolder = Guid.NewGuid().ToString();
            if (builder.Source.IsLocal)
            {
                var uploadedFile = await UploadAsync(uploadFolder, null, builder.Source.FilePath);
                createModel.InputPath = uploadedFile[0].Path;

                if (builder.Source.Resources != null && builder.Source.Resources.Any())
                {
                    await UploadAsync(uploadFolder, null, builder.Source.Resources.ToArray());
                }

                if (!string.IsNullOrWhiteSpace(builder.Source.ResourcesFolder))
                {
                    var basePath = Path.GetDirectoryName(builder.Source.FilePath);
                    var files = Directory.EnumerateFiles(builder.Source.ResourcesFolder, "*.*", SearchOption.AllDirectories).ToArray();
                    await UploadAsync(uploadFolder, basePath, files);
                }
            }
            else
            {
                createModel.InputPath = builder.Source.FilePath;

                if (builder.Source.Resources != null && builder.Source.Resources.Any())
                {
                    createModel.Resources.AddRange(builder.Source.Resources);
                }

                if (!string.IsNullOrWhiteSpace(builder.Source.ResourcesFolder))
                {
                    createModel.Resources.Add(builder.Source.ResourcesFolder);
                }
            }

            return createModel;
        }

        private async Task<List<RemoteFile>> UploadAsync(string folder, string basePath, params string[] files)
        {
            var uploadedFiles = new List<RemoteFile>();
            foreach (var file in files)
            {
                var fileName = string.IsNullOrWhiteSpace(basePath)
                    ? Path.GetFileName(file)
                    : file.Replace(basePath, string.Empty).Replace("\\", "/");
                var uploadUri = StorageUtils.GetLocalUri(folder, fileName);
                var upload = await storageApi.UploadFileAsync(file, uploadUri);
                uploadedFiles.Add(upload);
            }

            return uploadedFiles;
        }

        public void Dispose()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
