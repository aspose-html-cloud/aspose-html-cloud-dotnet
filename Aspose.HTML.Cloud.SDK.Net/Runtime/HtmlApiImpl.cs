// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="HtmlApiImpl.cs">
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
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.ApiParameters;
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Conversion.Sources;
using Aspose.HTML.Cloud.Sdk.IO;
using Aspose.HTML.Cloud.Sdk.Runtime;
using Aspose.HTML.Cloud.Sdk.Runtime.Authentication;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;
using Newtonsoft.Json;

namespace Aspose.HTML.Cloud.Sdk.Runtime
{
    /// <summary>
    /// Internal class that incapsulates implementation of SDK API public methods
    /// </summary>
    internal class HtmlApiImpl : IDisposable
    {
        private const string CONVERSION_URI = "/v4.0/html/conversion";
        private const int UPDATE_INTERVAL = 100;

        public const string ERRMSG_NO_USER_CREDS = "Authorization failed: Client ID and/or Client Secret were not specified. If you have no user credentials, please visit https://dashboard.aspose.cloud/#/ to create a free account.";
        public const string ERRMSG_INV_BLD_PARAMS = "Invalid ConversionBuilder parameters.";
        public const string ERRMSG_UNK_SRC = "Bad Request: Unknown source type.";

        private static readonly StorageFactory StorageFactory = StorageFactory.Instance;
        private HttpClient restClient;
        readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private TaskFactory taskFactory;

        private ApiInvokerFactory apiInvokerFactory;
        private IAuthenticator Authenticator { get; set; }

        internal StorageProvider Storage { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public HtmlApiImpl(Configuration configuration)
        {
            if (!configuration.UseExternalAuthentication &&
                (string.IsNullOrEmpty(configuration.ClientId) ||
                string.IsNullOrEmpty(configuration.ClientSecret)))
            {
                throw new ApiException(401, ERRMSG_NO_USER_CREDS);
            }
            restClient = configuration.HttpClient;
            taskFactory = new TaskFactory(cancellationTokenSource.Token);

            Authenticator = (new AuthenticationFactory()).CreateAuth(configuration);

            apiInvokerFactory = new ApiInvokerFactory(Authenticator, configuration);
            this.Storage = StorageFactory.CreateProvider(configuration, apiInvokerFactory);
        }

        internal Conversion.Conversion Convert(
            ConversionSource source,
            ConversionOptions options,
            PathParameter outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            var result = ConvertAsync(source, options, outputPath, nameCollisionOption, observer);
            result.AsyncWaitHandle.WaitOne();
            return result.Data;
        }

        internal AsyncResult<Conversion.Conversion> ConvertAsync(
            ConversionSource source,
            ConversionOptions options,
            PathParameter outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            observer = observer ?? ConversionObserver.Instance;

            var result = new AsyncResult<Conversion.Conversion>()
                .WithData(new Conversion.Conversion().WithStatus(Conversion.Conversion.UPLOADING));

            taskFactory.StartNew(() =>
            {
                try
                {
                    var name = typeof(ConversionRequest)
                        .GetProperty("InputUrls")
                        .GetCustomAttribute<JsonPropertyAttribute>()
                        .PropertyName;

                    var content = new StringContent(options.ToJson(),
                        Encoding.UTF8, "application/json");

                    var createModel = PrepareConversionRequest(source, options);
                    var query = CONVERSION_URI + $@"?{createModel.InputUrls.ToQueryString(name)}&outputFormat={createModel.OutputFileFormat}";

                    if (outputPath != null && !String.IsNullOrEmpty(outputPath.Path))
                    {
                        if (outputPath is RemoteDirectoryParameter)
                        {
                            var rpath = ((RemoteDirectoryParameter)outputPath).FullRemotePath;
                            query += $"&outputPath={Uri.EscapeDataString(rpath)}";
                        }
                    }
                    result.Data.WithStatus(Conversion.Conversion.RUNNING);

                    var apiInvoker = apiInvokerFactory.GetInvoker<ConversionResult>();
                    var resultDto = apiInvoker.CallPost(query, content);
                    result.Data.UpdateFrom(resultDto);

                    // Notify Conversion Scheduled
                    observer.OnNext(result.Data);

                    while (!cancellationTokenSource.IsCancellationRequested)
                    {
                        if (OperationResult.PENDING != result.Data.Status &&
                            OperationResult.RUNNING != result.Data.Status)
                        {
                            // Notify Conversion Completed
                            observer.OnCompleted();

                            if (outputPath != null && outputPath is LocalDirectoryParameter)
                            {
                                if (result.Data.Status == "completed")
                                {
                                    ConversionResult res = SaveToLocal(outputPath.Path, result.Data);

                                    PathUtility.ParseResult parsed = PathUtility.Parse(result.Data.Files[0].Path);
                                    // Clear directory in the server
                                    var dir = parsed.Folder; // result.Data.Files[0].Path;
                                    dir = dir.Substring(0, dir.LastIndexOf("/"));
                                    bool clear = Storage.DeleteDirectory(dir, parsed.StorageName, true);
                                }
                            }
                            result.Complete();
                            break;
                        }
                        Thread.Sleep(UPDATE_INTERVAL);

                        resultDto = apiInvoker.CallGet(resultDto.Links.Self);
                        result.Data.UpdateFrom(resultDto);
                    }
                }
                catch (Exception ex)
                {
                    result.Data.WithStatus(Conversion.Conversion.FAULTED);
                    result.WithError(ex);
                    observer.OnError(ex);
                    result.Complete();
                }

            }, cancellationTokenSource.Token);

            return result;
        }

        internal Conversion.Conversion ConvertLocalDirectoryImpl(
            string directoryPath,
            string startPoint,
            ConversionOptions options,
            PathParameter outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromLocalDirectory(new List<string>() { directoryPath, startPoint }),
                options, outputPath, nameCollisionOption, observer);
        }

        internal Conversion.Conversion ConvertLocalFileImpl(
            string filePath,
            ConversionOptions options,
            PathParameter outputPath = null,
            List<string> resources = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            List<string> fileWithResources = new List<string>() { filePath };
            if (resources != null && resources.Count > 0)
                fileWithResources.AddRange(resources);
            return Convert(ConversionSource.FromLocalFile(fileWithResources), options, outputPath, nameCollisionOption, observer);
        }

        internal Conversion.Conversion ConvertLocalArchiveImpl(
            string archivePath,
            string startPoint,
            ConversionOptions options,
            PathParameter outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromLocalArchiveFile(new List<string>() { archivePath, startPoint }),
                options, outputPath, nameCollisionOption, observer);
        }

        internal ConversionResult Convert(ConverterBuilder builder)
        {
            string first = builder.InputPaths.First();

            var srcTrg = DefineConversionSourceAndTarget_(builder);
            if(srcTrg.Item1 == SourceType.Unknown || srcTrg.Item2 == TargetType.Unknown)
                throw new ApiException(400, ERRMSG_INV_BLD_PARAMS);

            List<string> inputParams = builder.InputPaths;
            var options = builder.Options;
            string outputPath = builder.OutputPath;

            Conversion.Conversion result = 
                new Conversion.Conversion().WithStatus(Conversion.Conversion.PENDING);

            switch (srcTrg.Item1)
            {
                case SourceType.Local:
                    inputParams[0] = first.Remove(0, 7);
                    if(srcTrg.Item2 == TargetType.Local)
                    {
                        string outPath = outputPath.Remove(0, 7);
                        result = ConvertLocalSource_(inputParams, options, null);
                        if (result.Status == Conversion.Conversion.COMPLETED)
                        {
                            ConversionResult res = SaveToLocal(outPath, result);

                            // Clear directory in the server
                            var dir = result.Files[0].Path;
                            var parsed = PathUtility.Parse(dir);
                            dir = dir.Substring(0, dir.LastIndexOf("/"));
                            bool clear = Storage.DeleteDirectory(dir, parsed.StorageName, true);

                            return res;
                        }
                        else
                        {
                            return new ConversionResult()
                            {
                                Status = result.Status,
                                Description = $"Conversion failed.",
                                Files = null
                            };
                        }
                    }
                    else // save remote
                    {
                        result = ConvertLocalSource_(inputParams, options, outputPath);
                        return HandleStorageConversionResult_(result);
                    }
                case SourceType.Remote:
                    inputParams[0] = first.Remove(0, 10);
                    if (!inputParams[0].StartsWith("/"))
                        inputParams[0] = inputParams[0].Insert(0, "/");

                    if (srcTrg.Item2 == TargetType.Local)
                    {
                        return ConvertAndSaveLocal_(result, inputParams, options, outputPath);
                    }
                    else // save remote
                    {
                        return ConvertAndSaveToStorage_(result, inputParams, options, outputPath);
                    }
                case SourceType.Url:
                    if (srcTrg.Item2 == TargetType.Local)
                    {
                        return ConvertAndSaveLocal_(result, inputParams, options, outputPath);
                    }
                    else // save remote
                    {
                        return ConvertAndSaveToStorage_(result, inputParams, options, outputPath);
                    }

            }
            throw new ApiException(400, ERRMSG_INV_BLD_PARAMS);
        }

        internal Conversion.Conversion Convert(
         LocalArchiveConversionSource source,
         ConversionOptions options,
         PathParameter outputPath = null,
         NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
         IObserver<Conversion.Conversion> observer = null)
        {
            var result = ConvertAsync(source, options, outputPath, nameCollisionOption, observer);
            result.AsyncWaitHandle.WaitOne();
            return result.Data;
        }

        internal AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
            List<string> filePaths,
            ConversionOptions options,
            PathParameter outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertAsync(ConversionSource.FromLocalFile(filePaths), options, outputPath, nameCollisionOption, observer);
        }

        internal AsyncResult<Conversion.Conversion> GetConversion(string id)
        {
            var result = new AsyncResult<Conversion.Conversion>()
                .WithData(new Conversion.Conversion().WithStatus(Conversion.Conversion.COMPLETED));

            string query = CONVERSION_URI + $"/{id}";
            var response = restClient.GetAsync(query).Result;
            response.EnsureSuccessStatusCode();
            // Get the last Conversion Operation Result object
            var responseContent = response.Content.ReadAsStringAsync().Result;

            var resultDto = JsonConvert.DeserializeObject<ConversionResult>(responseContent);
            result.Data.UpdateFrom(resultDto);
            var observer = ConversionObserver.Instance;
            observer.OnNext(result.Data);

            taskFactory.StartNew(() =>
            {
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    if (OperationResult.PENDING != result.Data.Status &&
                        OperationResult.RUNNING != result.Data.Status)
                    {
                        // Notify Conversion Completed
                        observer.OnCompleted();
                        result.Complete();
                        break;
                    }

                    Thread.Sleep(UPDATE_INTERVAL);

                    response = restClient.GetAsync(query).Result;
                    response.EnsureSuccessStatusCode();

                    responseContent = response.Content.ReadAsStringAsync().Result;
                    resultDto = JsonConvert.DeserializeObject<ConversionResult>(responseContent);
                    result.Data.UpdateFrom(resultDto);
                }

            }, cancellationTokenSource.Token);
            return result;
        }

        private Conversion.Conversion Convert(
            string filePath,
            ConversionOptions options,
            PathParameter outputPath,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromRemoteFile(new List<string>() { filePath }), options, outputPath, nameCollisionOption, observer);
        }

        private Conversion.Conversion Convert(
            List<string> filePaths,
            ConversionOptions options,
            PathParameter outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromRemoteFile(filePaths), options, outputPath, nameCollisionOption, observer);
        }

        /// <summary>
        /// Cancels long-time asynchronous operation started previously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal bool DeleteTask(string id)
        {
            var query = CONVERSION_URI + $@"/{id}";

            var response = this.restClient.DeleteAsync(query).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        private ConversionResult SaveToLocal(string outputPath, Conversion.Conversion result)
        {
            if (result.Status != "completed")
                throw new ApiException(500, $"SDK runtime error: result status is {result.Status}");

            List<string> files = new List<string>();

            // AR 12-01-2021: bugfix - dir path treated as file
            if (!Directory.Exists(outputPath))
            {
                if (File.Exists(outputPath))
                    File.Delete(outputPath);
                Directory.CreateDirectory(outputPath);
            }

            foreach (var f in result.Files)
            {
                var targetPath = Path.Combine(outputPath, Path.GetFileName(f.Name));
                Storage.DownloadFile(f, targetPath);
                //Storage.DownloadFile(f, outputPath);
                files.Add(f.Name);
            }

            return new ConversionResult()
            {
                Status = "success",
                Description = $"All converted files in {outputPath}",
                Files = files.ToArray()
            };
        }


        private ConversionRequest PrepareConversionRequest(ConversionSource source, ConversionOptions options)
        {
            var createModel = new ConversionRequest
            {
                OutputFileFormat = options.Format
            };
            switch (source)
            {
                case LocalFileSetConversionSource local:
                    {
                        var ext = Path.GetExtension(local.Path).ToLowerInvariant();
                        var uploadUri = StorageFactory.GetLocalUri(Path.GetFileName(local.Path));
                        if (local.Paths.Count == 1 ||
                            !(ext == ".html" || ext == ".xhtml" || ext == ".htm"))
                        {
                            var upload = Storage.UploadFile(local.Path, uploadUri.OriginalString);
                            createModel.InputUrls = new List<string> { upload.Path };
                        }
                        else // with resources - valid for HTML/XHTML source files only
                        {
                            byte[] sourceArr = ZipUtils.ZipFileList(local.Path, local.Paths);
                            var upload = Storage.UploadData(sourceArr, uploadUri.OriginalString + ".zip");
                            createModel.InputUrls = new List<string> { upload.Path, Path.GetFileName(local.Paths[0]) };
                        }
                        break;
                    }
                case LocalArchiveConversionSource arch:
                    {
                        var uploadUri = StorageFactory.GetLocalUri(Path.GetFileName(arch.Path));
                        var upload = Storage.UploadFile(arch.Path, uploadUri.OriginalString);
                        createModel.InputUrls = arch.Paths;
                        createModel.InputUrls[0] = upload.Path;
                        break;
                    }
                case LocalDirectoryConversionSource localDir:
                    {
                        var uploadUri = StorageFactory.GetLocalUri(Path.GetFileName(localDir.Path));
                        byte[] sourceArr = ZipUtils.ZipFolder(localDir.Path);
                        var upload = Storage.UploadData(sourceArr, uploadUri.OriginalString + ".zip");
                        createModel.InputUrls = new List<string> { upload.Path, Path.GetFileName(localDir.Paths[1]) };
                        //createModel.InputUrl[0] = upload.Path;
                        break;
                    }
                case RemoteFileConversionSource remote:
                    {
                        createModel.InputUrls = remote.Paths;
                        break;
                    }
                default:
                    {
                        throw new ApiException(400, ERRMSG_UNK_SRC);
                    }
            }
            return createModel;
        }

        private Tuple<SourceType, TargetType> DefineConversionSourceAndTarget_(ConverterBuilder builder)
        {
            string first = builder.InputPaths.First();
            List<string> inputParams = builder.InputPaths;
            string outputPath = builder.OutputPath;

            SourceType src = first.StartsWith("file://") ? SourceType.Local
                : (first.StartsWith("storage://") ? SourceType.Remote :
                (first.StartsWith("https://") || first.StartsWith("http://"))
                    ? SourceType.Url : SourceType.Unknown);

            TargetType trg = outputPath.StartsWith("file://") ? TargetType.Local
                : (outputPath.StartsWith("storage://") ? TargetType.Remote : TargetType.Unknown);

            return new Tuple<SourceType, TargetType>(src, trg);
        }


        private ConversionResult ConvertAndSaveLocal_(Conversion.Conversion result,
            List<string> inputParams, ConversionOptions options, string outputPath)
        {
            result = Convert(inputParams, options, new RemoteDirectoryParameter(null));

            string outPath = outputPath.Remove(0, 7);
            ConversionResult res = SaveToLocal(outPath, result);

            // Clear directory in the server
            var dir = result.Files[0].Path;
            var parsed = PathUtility.Parse(dir);
            var storageName = parsed.StorageName;

            dir = dir.Substring(0, dir.LastIndexOf("/"));
            bool clear = Storage.DeleteDirectory(dir, storageName, true);
            return res;
        }

        private ConversionResult ConvertAndSaveToStorage_(Conversion.Conversion result,
            List<string> inputParams, ConversionOptions options, string outputPath)
        {
            PathUtility.ParseResult p = PathUtility.Parse(outputPath);
            result = Convert(inputParams, options,
                new RemoteDirectoryParameter(p.Folder, p.StorageName));

            return HandleStorageConversionResult_(result);
        }


        private Conversion.Conversion ConvertLocalSource_(
            List<string> inputParams, ConversionOptions options, string outputPath)
        {
            Conversion.Conversion result;
            var pathParam = new RemoteDirectoryParameter(null);
                
            if(!string.IsNullOrEmpty(outputPath))
            {
                var parsed = PathUtility.Parse(outputPath);
                pathParam = new RemoteDirectoryParameter(parsed.Folder, parsed.StorageName);
            }

            result = (Directory.Exists(inputParams[0]))
                ? ConvertLocalDirectoryImpl(inputParams[0], inputParams[1], options, pathParam)
                : inputParams[0].ToLower().EndsWith(".zip")
                  ? ConvertLocalArchiveImpl(inputParams[0], inputParams[1], options, pathParam)
                  : ConvertLocalFileImpl(inputParams[0], options, pathParam, inputParams.Skip<string>(1).ToList());
            return result;
        }

        private ConversionResult HandleStorageConversionResult_(Conversion.Conversion result)
        {
            if (result.Status == "completed")
            {
                List<string> files = new List<string>();

                foreach (var f in result.Files)
                {
                    files.Add(f.Name);
                }

                string dir = result.Files[0].Path;

                dir = dir.Substring(0, dir.LastIndexOf("/")).Remove(0, 10);

                return new ConversionResult()
                {
                    Status = "success",
                    Description = $"All converted files saved in the storage in {dir} folder.",
                    Files = files.ToArray()
                };
            }
            else
            {
                return new ConversionResult()
                {
                    Status = result.Status,
                    Description = $"Conversion failed.",
                    Files = null
                };
            }
        }

        public void Dispose()
        {
            cancellationTokenSource.Cancel();
            restClient?.Dispose();
        }

        internal class ConversionObserver : IObserver<Conversion.Conversion>
        {
            public static readonly IObserver<Conversion.Conversion> Instance = new ConversionObserver();

            public void OnCompleted()
            {

            }

            public void OnError(Exception error)
            {

            }

            public void OnNext(Conversion.Conversion value)
            {

            }
        }
    }
}
