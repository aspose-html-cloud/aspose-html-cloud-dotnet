using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.Sdk.Conversion;
using Aspose.HTML.Cloud.Sdk.Conversion.Sources;
using Aspose.HTML.Cloud.Sdk.IO;
using Aspose.HTML.Cloud.Sdk.Runtime;
using Aspose.HTML.Cloud.Sdk.Runtime.Authentication;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;
using Newtonsoft.Json;

namespace Aspose.HTML.Cloud.Sdk
{
    public class HtmlApi : IDisposable
    {
        private const string CONVERSION_URI = "/v4.0/html/conversion";
        private const int UPDATE_INTERVAL = 100;


        private static readonly StorageFactory StorageFactory = StorageFactory.Instance;
        private HttpClient restClient;
        readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private TaskFactory taskFactory;

        private ApiInvokerFactory apiInvokerFactory;
        private IAuthenticator Authenticator { get; set; }
        
        public HtmlApi(Configuration configuration)
        {         
            restClient = configuration.HttpClient;
            taskFactory = new TaskFactory(cancellationTokenSource.Token);

            Authenticator = (new AuthenticationFactory()).CreateAuth(configuration);

            apiInvokerFactory = new ApiInvokerFactory(Authenticator, configuration);
            this.Storage = StorageFactory.CreateProvider(configuration, apiInvokerFactory);
        }

        public HtmlApi(Action<Configuration.ConfigurationBuilder> builder)
            : this(new Configuration.ConfigurationBuilder(builder).Build())
        {
        }

        public HtmlApi(String appSid, String appKey)
            : this(appSid, appKey, Configuration.Default.BaseUrl, Configuration.Default.Timeout)
        {
        }

        public HtmlApi(String appSid, String appKey, String baseUrl)
            : this(appSid, appKey, baseUrl, Configuration.Default.Timeout)
        {
        }

        public HtmlApi(String appSid, String appKey, String baseUrl, TimeSpan timeout)
            : this(new Configuration()
            {
                AppKey = appKey,
                AppSid = appSid,
                BaseUrl = baseUrl,
                Timeout = timeout
            })
        {
        }

        //public HtmlApi(string baseUrl, string externalJwtToken)
        //{

        //}

        internal StorageProvider Storage { get; }

        public ConversionResult Convert(ConverterBuilder builder)
        {
            string first = builder.InputPath.First();
            List<string> inputParams = builder.InputPath;
            string outputPath = builder.OutputPath;

            string storageName = ""; // TODO: get storage name from path

            //From local
            if (first.StartsWith("file://"))
            {
                inputParams[0] = first.Remove(0, 7);

                //To storage
                if (outputPath.StartsWith("storage://"))
                {
                    var result = (Directory.Exists(inputParams[0])) 
                        ? ConvertLocalDirectory(inputParams, builder.Options, outputPath)
                        : inputParams[0].ToLower().EndsWith(".zip")
                          ? ConvertLocalArchive(inputParams, builder.Options, outputPath)
                          : ConvertLocalFile(inputParams, builder.Options, outputPath);

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
                            Description = $"Conversion falied.",
                            Files = null
                        };
                    }
                }
                // To local
                else if (outputPath.StartsWith("file://"))
                {
                    string outPath = outputPath.Remove(0, 7);

                    var result = (Directory.Exists(inputParams[0]))
                        ? ConvertLocalDirectory(inputParams, builder.Options)
                        : inputParams[0].ToLower().EndsWith(".zip")
                          ? ConvertLocalArchive(inputParams, builder.Options)
                          : ConvertLocalFile(inputParams, builder.Options);

                    ConversionResult res = SaveToLocal(outPath, result);

                    // Clear directory in the server
                    var dir = result.Files[0].Path;
                    dir = dir.Substring(0, dir.LastIndexOf("/"));
                    bool clear = Storage.DeleteDirectory(dir, storageName, true);

                    return res;
                }
            }
            //From storage
            else if (first.StartsWith("storage://"))
            {
                inputParams[0] = first.Remove(0, 10);

                if (!inputParams[0].StartsWith("/"))
                    inputParams[0] = inputParams[0].Insert(0, "/");

                //To local
                if (outputPath.StartsWith("file://"))
                {
                    var result = Convert(inputParams, builder.Options);

                    string outPath = outputPath.Remove(0, 7);
                    ConversionResult res = SaveToLocal(outPath, result);

                    // Clear directory in the server
                    var dir = result.Files[0].Path;
                    dir = dir.Substring(0, dir.LastIndexOf("/"));
                    bool clear = Storage.DeleteDirectory(dir, storageName, true);
                    return res;
                }
                // To storage
                else if (outputPath.StartsWith("storage://"))
                {
                    var result = Convert(inputParams, builder.Options, outputPath);

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
                        throw new Exception("Handler error status");
                    }
                }
            }
            else if (first.StartsWith("https://") || first.StartsWith("http://"))
            {
                //To local
                if (outputPath.StartsWith("file://"))
                {
                    var result = Convert(inputParams, builder.Options);

                    string outPath = outputPath.Remove(0, 7);
                    ConversionResult res = SaveToLocal(outPath, result);

                    // Clear directory in the server
                    var dir = result.Files[0].Path;
                    dir = dir.Substring(0, dir.LastIndexOf("/"));
                    bool clear = Storage.DeleteDirectory(dir, storageName, true);
                    return res;
                }
                // To storage
                else if (outputPath.StartsWith("storage://"))
                {
                    var result = Convert(inputParams, builder.Options, outputPath);

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
                        throw new Exception("Handler error status");
                    }
                }
            }
            throw new NotImplementedException();
        }

        private ConversionResult SaveToLocal(string outputPath, Conversion.Conversion result)
        {
            if (result.Status != "completed")
                throw new NotImplementedException("handler for errors");

            List<string> files = new List<string>();

            foreach (var f in result.Files)
            {
                Storage.DownloadFile(f, outputPath);
                files.Add(f.Name);
            }

            return new ConversionResult()
            {
                Status = "success",
                Description = $"All converded files in {outputPath}",
                Files = files.ToArray()
            };
        }

        public Conversion.Conversion Convert(
            ConversionSource source, 
            ConversionOptions options,
            string outputFilePath = null, 
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            var result = ConvertAsync(source, options, outputFilePath, nameCollisionOption, observer);
            result.AsyncWaitHandle.WaitOne();
            return result.Data;
        }

        public Conversion.Conversion Convert(
         LocalArchiveConversionSource source,
         ConversionOptions options,
         string outputFilePath = null,
         NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
         IObserver<Conversion.Conversion> observer = null)
        {
            var result = ConvertAsync(source, options, outputFilePath, nameCollisionOption, observer);
            result.AsyncWaitHandle.WaitOne();
            return result.Data;
        }

        public AsyncResult<Conversion.Conversion> ConvertAsync(
            ConversionSource source,
            ConversionOptions options,
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            observer = observer ?? ConversionObserver.Instance;

            var result = new AsyncResult<Conversion.Conversion>()
            .WithData(new Conversion.Conversion().WithStatus(Conversion.Conversion.COMPLETED));

            var createModel = new ConversionRequest
            {
                OutputFileFormat = options.Format
            };

            var content = new StringContent(options.ToJson(),
                Encoding.UTF8, "application/json");

            switch (source)
            {
                case LocalFileSetConversionSource local:
                {
                    var uploadUri = StorageFactory.GetLocalUri(Path.GetFileName(local.Path));
                    var upload = Storage.UploadFile(local.Path, uploadUri.OriginalString);

                    createModel.InputUrl = new List<string> { upload.Path };
                    break;
                }
                case LocalArchiveConversionSource arch:
                {
                    var uploadUri = StorageFactory.GetLocalUri(Path.GetFileName(arch.Path));
                    var upload = Storage.UploadFile(arch.Path, uploadUri.OriginalString);
                    createModel.InputUrl = arch.Paths;
                    createModel.InputUrl[0] = upload.Path;
                    break;
                }
                case LocalDirectoryConversionSource localDir:
                {
                    var uploadUri = StorageFactory.GetLocalUri(Path.GetFileName(localDir.Path));
                    byte[] sourceArr = ZipUtils.ZipFolder(localDir.Path);
                    var upload = Storage.UploadData(sourceArr, uploadUri.OriginalString + ".zip");
                    createModel.InputUrl = localDir.Paths;
                    createModel.InputUrl[0] = upload.Path;
                    break;
                }
                case RemoteFileConversionSource remote:
                {
                        createModel.InputUrl = remote.Paths;
                        break;
                }
                default: 
                {
                    throw new NotImplementedException();
                }
            }

            var name = typeof(ConversionRequest)
                .GetProperty("InputUrl")
                .GetCustomAttribute<JsonPropertyAttribute>()
                .PropertyName;

            var query = CONVERSION_URI + $@"?{createModel.InputUrl.ToQueryString(name)}&outputFormat={createModel.OutputFileFormat}";

            if (!String.IsNullOrEmpty(outputFilePath))
            {
                query += $"&outputPath={Uri.EscapeDataString(outputFilePath)}";
            }

            var apiInvoker = apiInvokerFactory.GetInvoker<ConversionResult>();
            var resultDto = apiInvoker.CallPost(query, content);
            result.Data.UpdateFrom(resultDto);

            // Notify Conversion Scheduled
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

                    resultDto = apiInvoker.CallGet(resultDto.Links.Self);
                    result.Data.UpdateFrom(resultDto);
                }

            }, cancellationTokenSource.Token);

            return result;
        }

        public Conversion.Conversion Convert(
            List<RemoteFile> files, 
            ConversionOptions options, string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromRemoteFile(files), options, outputFilePath, nameCollisionOption, observer);
        }

        public AsyncResult<Conversion.Conversion> ConvertAsync(
            List<RemoteFile> files, 
            ConversionOptions options,
            string outputFilePath = null, 
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertAsync(ConversionSource.FromRemoteFile(files), options, outputFilePath, nameCollisionOption, observer);
        }

        public Conversion.Conversion Convert(
            string filePath,
            ConversionOptions options, string outputFilePath = null, string storageName = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromRemoteFile(new List<string>() { filePath }), options, outputFilePath, nameCollisionOption, observer);
        }

        public Conversion.Conversion Convert(
            List<string> filePaths, 
            ConversionOptions options, string outputFilePath = null, string storageName = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromRemoteFile(filePaths), options, outputFilePath, nameCollisionOption, observer);
        }

        public AsyncResult<Conversion.Conversion> ConvertAsync(
            List<string> filePaths, 
            ConversionOptions options,
            string storageName = null, 
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertAsync(ConversionSource.FromRemoteFile(filePaths), options, outputFilePath, nameCollisionOption, observer);
        }

        public Conversion.Conversion ConvertWebSite(
            List<string> address, 
            ConversionOptions options,
            string outputFilePath = null, 
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromRemoteFile(address), options, outputFilePath, nameCollisionOption, observer);
        }

        public Conversion.Conversion ConvertWebSite(
            string address,
            ConversionOptions options,
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            List<string> singleAddress = new List<string>() { address };
            return Convert(ConversionSource.FromRemoteFile(singleAddress), options, outputFilePath, nameCollisionOption, observer);
        }

        public AsyncResult<Conversion.Conversion> ConvertWebSiteAsync(
            string address, 
            ConversionOptions options,
            string outputFilePath = null, 
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            List<string> singleAddress = new List<string>() { address };
            return ConvertAsync(ConversionSource.FromRemoteFile(singleAddress), options, outputFilePath, nameCollisionOption, observer);
        }

        public Conversion.Conversion ConvertLocalFile(
            string filePath,
            ConversionOptions options,
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            List<string> singleFile = new List<string>() { filePath};
            return Convert(ConversionSource.FromLocalFile(singleFile), options, outputFilePath, nameCollisionOption, observer);
        }

        public Conversion.Conversion ConvertLocalFile(
            List<string> filePath, 
            ConversionOptions options,
            string outputFilePath = null, 
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromLocalFile(filePath), options, outputFilePath, nameCollisionOption, observer);
        }

        public Conversion.Conversion ConvertLocalArchive(
            List<string> filePath,
            ConversionOptions options,
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromLocalArchiveFile(filePath), options, outputFilePath, nameCollisionOption, observer);
        }

        public Conversion.Conversion ConvertLocalDirectory(
            List<string> paths,
            ConversionOptions options,
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromLocalDirectory(paths), options, outputFilePath, nameCollisionOption, observer);
        }

        public AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
            string filePath,
            ConversionOptions options,
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            List<string> singleFile = new List<string>() { filePath };
            return ConvertAsync(ConversionSource.FromLocalFile(singleFile), options, outputFilePath, nameCollisionOption, observer);
        }

        public AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
            List<string> filePaths, 
            ConversionOptions options,
            string outputFilePath = null, 
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertAsync(ConversionSource.FromLocalFile(filePaths), options, outputFilePath, nameCollisionOption, observer);
        }

        public AsyncResult<Conversion.Conversion> GetConversion(string id)
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

        public bool DeleteTask(string id)
        {
            var query = CONVERSION_URI + $@"/{id}";

            var response = this.restClient.DeleteAsync(query).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            cancellationTokenSource.Cancel();
        }

        class ConversionObserver : IObserver<Conversion.Conversion>
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