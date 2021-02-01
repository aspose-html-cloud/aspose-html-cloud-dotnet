// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="HtmlApi.cs">
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
    /// <summary>
    /// A facade class that provides wrapper methods of Aspose.HTML Cloud REST API.
    /// </summary>
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

        /// <summary>
        /// Constructor. Initializes a class instance with API parameters provided by specified Configuration object.
        /// </summary>
        /// <param name="configuration"></param>
        public HtmlApi(Configuration configuration)
        {
            restClient = configuration.HttpClient;
            taskFactory = new TaskFactory(cancellationTokenSource.Token);

            Authenticator = (new AuthenticationFactory()).CreateAuth(configuration);

            apiInvokerFactory = new ApiInvokerFactory(Authenticator, configuration);
            this.Storage = StorageFactory.CreateProvider(configuration, apiInvokerFactory);
        }

        /// <summary>
        /// Constructor. Initializes a class instance with API parameters using a configuration builder.
        /// </summary>
        /// <param name="builder"></param>
        public HtmlApi(Action<Configuration.ConfigurationBuilder> builder)
            : this(new Configuration.ConfigurationBuilder(builder).Build())
        {
        }

        /// <summary>
        /// Constructor. Initializes a class instance with user credentials and default API server URL. 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        public HtmlApi(String clientId, String clientSecret)
            : this(clientId, clientSecret, Configuration.Default.BaseUrl, Configuration.Default.Timeout)
        {
        }

        /// <summary>
        /// Constructor. Initializes a class instance with user credentials and explicit API server URL.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="baseUrl"></param>
        public HtmlApi(String clientId, String clientSecret, String baseUrl)
            : this(clientId, clientSecret, baseUrl, Configuration.Default.Timeout)
        {
        }

        /// <summary>
        /// Constructor. Initializes a class instance with user credentials, explicit API server URL and HTTP(S) connection timeout.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="baseUrl"></param>
        /// <param name="timeout"></param>
        public HtmlApi(String clientId, String clientSecret, String baseUrl, TimeSpan timeout)
            : this(new Configuration()
            {
                ClientSecret = clientSecret,
                ClientId = clientId,
                BaseUrl = baseUrl,
                Timeout = timeout
            })
        {
        }

        /// <summary>
        /// Entry point to storage access API.
        /// </summary>
        public StorageProvider Storage { get; }

        /// <summary>
        /// Starts a conversion synchronously using ConversionBuilder class to setup the conversion parameters. 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts synchronously a file (or files) specified by source parameter. 
        /// This method is a synchronous mode of the ConvertAsync. 
        /// Returns the Conversion.Conversion object with a list of conversion results.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts synchronously a file (or files) specified by source parameter. 
        /// This method is a synchronous mode of the ConvertAsync. 
        /// Returns the Conversion.Conversion object with a list of conversion results.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Starts asynchronously a long-time conversion operation on the source files specified by source parameter and 
        /// returns an object that allows to check the aynchronous operation status.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public AsyncResult<Conversion.Conversion> ConvertAsync(
            ConversionSource source,
            ConversionOptions options,
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            observer = observer ?? ConversionObserver.Instance;

            var result = new AsyncResult<Conversion.Conversion>()
                .WithData(new Conversion.Conversion().WithStatus(Conversion.Conversion.UPLOADING));
            
            taskFactory.StartNew(() =>
            {
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

        /// <summary>
        /// Converts synchronously a file (or files) specified by source parameter. 
        /// This method is a synchronous mode of the ConvertAsync. 
        /// Returns the Conversion.Conversion object with a list of conversion results.
        /// </summary>
        /// <param name="files"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public Conversion.Conversion Convert(
            List<RemoteFile> files, 
            ConversionOptions options, string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromRemoteFile(files), options, outputFilePath, nameCollisionOption, observer);
        }

        /// <summary>
        /// Starts asynchronously a long-time conversion operation of a source file (or files) 
        /// specified by source parameter and returns an AsyncResult object that allows watching for the current asynchronous operation status. 
        /// </summary>
        /// <param name="files"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public AsyncResult<Conversion.Conversion> ConvertAsync(
            List<RemoteFile> files, 
            ConversionOptions options,
            string outputFilePath = null, 
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertAsync(ConversionSource.FromRemoteFile(files), options, outputFilePath, nameCollisionOption, observer);
        }

        /// <summary>
        /// Converts synchronously a file specified by filePath parameter. 
        /// This method is a synchronous mode of the ConvertAsync. 
        /// Returns the Conversion.Conversion object with a list of conversion results.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="storageName"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        private Conversion.Conversion Convert(
            string filePath,
            ConversionOptions options, string outputFilePath = null, string storageName = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromRemoteFile(new List<string>() { filePath }), options, outputFilePath, nameCollisionOption, observer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePaths"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="storageName"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        private Conversion.Conversion Convert(
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

        /// <summary>
        /// Overloaded method. Synchronous mode of method *ConvertWebSiteAsync*. Converts several web pages specified the list of their URLs.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public Conversion.Conversion ConvertWebSite(
            List<string> address, 
            ConversionOptions options,
            string outputFilePath = null, 
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromRemoteFile(address), options, outputFilePath, nameCollisionOption, observer);
        }

        /// <summary>
        /// Synchronous mode of method *ConvertWebSiteAsync*. Converts the web page specified by its URL.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Starts asynchronously a long-time conversion operation on the web page specified by its URL (address parameter). 
        /// Analog of *ConvertAsync* specialized for web pages
        /// </summary>
        /// <param name="address"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public Conversion.Conversion ConvertLocalFile(
            List<string> filePath, 
            ConversionOptions options,
            string outputFilePath = null, 
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromLocalFile(filePath), options, outputFilePath, nameCollisionOption, observer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public Conversion.Conversion ConvertLocalArchive(
            List<string> filePath,
            ConversionOptions options,
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromLocalArchiveFile(filePath), options, outputFilePath, nameCollisionOption, observer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public Conversion.Conversion ConvertLocalDirectory(
            List<string> paths,
            ConversionOptions options,
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return Convert(ConversionSource.FromLocalDirectory(paths), options, outputFilePath, nameCollisionOption, observer);
        }

        /// <summary>
        /// Starts asynchronously a long-time conversion operation of the file in the local file system.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Starts asynchronously a long-time conversion operation on the list of files in the local file system. 
        /// </summary>
        /// <param name="filePaths"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        public AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
            List<string> filePaths, 
            ConversionOptions options,
            string outputFilePath = null, 
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertAsync(ConversionSource.FromLocalFile(filePaths), options, outputFilePath, nameCollisionOption, observer);
        }

        /// <summary>
        /// Gets a current status of long-time conversion operation started previously by ConvertAsync method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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