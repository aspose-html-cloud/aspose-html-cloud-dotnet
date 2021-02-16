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

namespace Aspose.HTML.Cloud.Sdk
{
    /// <summary>
    /// Facade class that provides wrapper methods of Aspose.HTML Cloud REST API.
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
        /// <param name="configuration">Configuration instance with API parameters.</param>
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
        /// <param name="builder">Delegate that accepts ConfigurationBuilder as a parameter.</param>
        public HtmlApi(Action<Configuration.ConfigurationBuilder> builder)
            : this(new Configuration.ConfigurationBuilder(builder).Build())
        {
        }

        /// <summary>
        /// Constructor. Initializes a class instance with user credentials and default API service and authentication service  URL. 
        /// </summary>
        /// <param name="clientId">Client ID.</param>
        /// <param name="clientSecret">Client secret.</param>
        public HtmlApi(String clientId, String clientSecret)
            : this(clientId, clientSecret, 
                  Configuration.Default.BaseUrl, Configuration.Default.AuthUrl, Configuration.Default.Timeout)
        {
        }

        /// <summary>
        /// Constructor. Initializes a class instance with user credentials and explicit API server URL.
        /// </summary>
        /// <param name="clientId">Client ID.</param>
        /// <param name="clientSecret">Client secret.</param>
        /// <param name="baseUrl">API service URL.</param>
        /// <param name="authUrl">Authentication service URL.</param>
        internal HtmlApi(string clientId, string clientSecret, string baseUrl, string authUrl)
            : this(clientId, clientSecret, baseUrl, authUrl, Configuration.Default.Timeout)
        {
        }

        /// <summary>
        /// Constructor. Initializes a class instance with user credentials, explicit API server URL, explicit authentication server URL and HTTP(S) connection timeout.
        /// </summary>
        /// <param name="clientId">Client ID.</param>
        /// <param name="clientSecret">Client secret.</param>
        /// <param name="baseUrl">API service URL.</param>
        /// <param name="authUrl">Authentication service URL.</param>
        /// <param name="timeout">HTTP connection timeout as TimeSpan.</param>
        internal HtmlApi(String clientId, String clientSecret, String baseUrl, String authUrl, TimeSpan timeout)
            : this(cb => cb
                    .WithBaseUrl(baseUrl)
                    .WithClientId(clientId)
                    .WithClientSecret(clientSecret)
                    .WithTimeout(timeout))
        {
        }

        #region Public Properties
        /// <summary>
        /// Entry point to storage access API.
        /// </summary>
        public StorageProvider Storage { get; }

        #endregion


        #region Public API methods
        /// <summary>
        /// Starts a conversion synchronously using ConversionBuilder class to setup the conversion parameters. 
        /// </summary>
        /// <param name="builder">ConverterBuilder object that collects conversion parameters.</param>
        /// <returns>ConversionResult</returns>
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
                    var parsed = PathUtility.Parse(outputPath);
                    var pathParam = new RemoteDirectoryParameter(parsed.Folder, parsed.StorageName);
                    var result = (Directory.Exists(inputParams[0]))
                        ? ConvertLocalDirectory(inputParams[0], inputParams[1], builder.Options, pathParam)
                        : inputParams[0].ToLower().EndsWith(".zip")
                          ? ConvertLocalArchive(inputParams[0], inputParams[1], builder.Options, pathParam)
                          : ConvertLocalFile(inputParams[0], builder.Options, pathParam, inputParams.Skip<string>(1).ToList());

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
                        ? ConvertLocalDirectory(inputParams[0], inputParams[1], builder.Options, new RemoteDirectoryParameter(null))
                        : inputParams[0].ToLower().EndsWith(".zip")
                          ? ConvertLocalArchive(inputParams[0], inputParams[1], builder.Options, new RemoteDirectoryParameter(null))
                          : ConvertLocalFile(inputParams[0], builder.Options, new RemoteDirectoryParameter(null));

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
                    var result = Convert(inputParams, builder.Options, new RemoteDirectoryParameter(null));

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
                    PathUtility.ParseResult p = PathUtility.Parse(outputPath);
                    var result = Convert(inputParams, builder.Options,
                        new RemoteDirectoryParameter(p.Folder, p.StorageName));

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
                    PathUtility.ParseResult p = PathUtility.Parse(outputPath);
                    var result = Convert(inputParams, builder.Options, 
                        new RemoteDirectoryParameter(p.Folder, p.StorageName));

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

        /// <summary>
        /// Starts asynchronously a long-time conversion operation on the web page specified by its URL (address parameter). 
        /// Analog of ConvertAsync specialized for web pages.
        /// </summary>
        /// <param name="url">Source Web page URL.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion result format and other conversion options.</param>
        /// <param name="outputPath">PathParameter objects that specifies local or remote path where the conversion result will be saved.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns></returns>
        public AsyncResult<Conversion.Conversion> ConvertUrlAsync(
            string url,
            ConversionOptions options,
            PathParameter outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            List<string> singleAddress = new List<string>() { url };
            return ConvertAsync(ConversionSource.FromRemoteFile(singleAddress), options, outputPath, nameCollisionOption, observer);
        }

        /// <summary>
        /// Starts asynchronously a long-time conversion operation on the web page specified by its URL (address parameter). 
        /// Analog of ConvertAsync specialized for web pages.
        /// </summary>
        /// <param name="url">Source Web page URL.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion result format and other conversion options.</param>
        /// <param name="outputPath">Path string that by default specifies an output folder path in the default storage.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns></returns>
        public AsyncResult<Conversion.Conversion> ConvertUrlAsync(
            string url,
            ConversionOptions options,
            string outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertUrlAsync(url, options, 
                new RemoteDirectoryParameter(outputPath), nameCollisionOption, observer);
        }

        /// <summary>
        /// Converts synchronously the web page specified by its URL.
        /// </summary>
        /// <param name="url">Source Web page URL.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion result format and other conversion options.</param>
        /// <param name="outputPath">PathParameter objects that specifies local or remote path where the conversion result will be saved.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns>Conversion.Conversion</returns>
        public Conversion.Conversion ConvertUrl(
            string url,
            ConversionOptions options,
            PathParameter outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            List<string> singleAddress = new List<string>() { url };
            return Convert(ConversionSource.FromRemoteFile(singleAddress), options, outputPath, nameCollisionOption, observer);
        }

        /// <summary>
        /// Converts synchronously the web page specified by its URL. Overloaded.
        /// </summary>
        /// <param name="url">Source Web page URL.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion result format and other conversion options.</param>
        /// <param name="outputPath">Path string that by default specifies an output folder path in the default storage.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns>Conversion.Conversion</returns>
        public Conversion.Conversion ConvertUrl(
            string url,
            ConversionOptions options,
            string outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertUrl(url, options, new RemoteDirectoryParameter(outputPath), nameCollisionOption, observer);
        }

        /// <summary>
        /// Converts synchronously a file located in the local file system and specified by filePath parameter. 
        /// </summary>
        /// <param name="filePath">Source file path in the local file system.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion result format and other conversion options.</param>
        /// <param name="outputPath">PathParameter objects that specifies local or remote path where the conversion result will be saved.</param>
        /// <param name="resources">List of path of HTML resource files; it has sense if filePath specified file is HTML.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns></returns>
        public Conversion.Conversion ConvertLocalFile(
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

        /// <summary>
        /// Converts synchronously a file located in the local file system and specified by filePath parameter. 
        /// </summary>
        /// <param name="filePath">Source file path in the local file system.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion output format and, optionally, some format-specific parameters.</param>
        /// <param name="outputPath">Path string that by default specifies an output folder path in the default storage.</param>
        /// <param name="resources">List of path of HTML resource files; it has sense if filePath specified file is HTML.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns>Conversion.Conversion</returns>
        public Conversion.Conversion ConvertLocalFile(
            string filePath,
            ConversionOptions options,
            string outputPath = null,
            List<string> resources = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertLocalFile(filePath, options, new RemoteDirectoryParameter(outputPath),
                resources, nameCollisionOption, observer);
        }

        /// <summary>
        /// Starts asynchronously a long-time conversion operation of the file in the local file system.
        /// </summary>
        /// <param name="filePath">Source file path in the local file system.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion output format and, optionally, some format-specific parameters.</param>
        /// <param name="outputPath">PathParameter objects that specifies local or remote path where the conversion result will be saved.</param>
        /// <param name="resources">List of path of HTML resource files; it has sense if filePath specified file is HTML.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns></returns>
        public AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
            string filePath,
            ConversionOptions options,
            PathParameter outputPath,
            List<string> resources = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            List<string> fileList = new List<string>() { filePath };
            if (resources != null && resources.Count > 0)
            {
                fileList.AddRange(resources);
            }
            return ConvertAsync(ConversionSource.FromLocalFile(fileList), options, outputPath, nameCollisionOption, observer);
        }

        /// <summary>
        /// Starts asynchronously a long-time conversion operation of the file in the local file system. Overloaded
        /// </summary>
        /// <param name="filePath">Source file path in the local file system.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion output format and, optionally, some format-specific parameters.</param>
        /// <param name="outputPath">Path string that by default specifies an output folder path in the default storage.</param>
        /// <param name="resources">List of path of HTML resource files; it has sense if filePath specified file is HTML.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns></returns>
        public AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
            string filePath,
            ConversionOptions options,
            string outputPath = null,
            List<string> resources = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            List<string> fileList = new List<string>() { filePath };
            if (resources != null && resources.Count > 0)
            {
                fileList.AddRange(resources);
            }
            return ConvertLocalFileAsync(filePath, options, new RemoteDirectoryParameter(outputPath), 
                resources, nameCollisionOption, observer);
        }

        /// <summary>
        /// Converts synchronously an HTML document in the ZIP archive located in the local file system 
        /// and specified by archive and startPoint parameters.
        /// </summary>
        /// <param name="archivePath">Source archive file path.</param>
        /// <param name="startPoint">File name in the archive root directory to be converted.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion output format and, optionally, some format-specific parameters.</param>
        /// <param name="outputPath">PathParameter objects that specifies local or remote path where the conversion result will be saved.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns>Conversion.Conversion</returns>
        public Conversion.Conversion ConvertLocalArchive(
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

        /// <summary>
        /// Converts synchronously an HTML document in the ZIP archive located in the local file system 
        /// and specified by archive and startPoint parameters. Overloaded.
        /// </summary>
        /// <param name="archivePath">Source archive file path.</param>
        /// <param name="startPoint">File name in the archive root directory to be converted.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion output format and, optionally, some format-specific parameters.</param>
        /// <param name="outputPath">Path string that by default specifies an output folder path in the default storage.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns>Conversion.Conversion</returns>
        public Conversion.Conversion ConvertLocalArchive(
            string archivePath,
            string startPoint,
            ConversionOptions options,
            string outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertLocalArchive(archivePath, startPoint, options, 
                new  RemoteDirectoryParameter(outputPath), nameCollisionOption, observer);
        }

        /// <summary>
        /// Converts synchronously a directory located in the local file system and specified by filePath parameter.
        /// </summary>
        /// <param name="directoryPath">Source directory path.</param>
        /// <param name="startPoint">File name in the directory to be converted.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion output format and, optionally, some format-specific parameters.</param>
        /// <param name="outputPath">PathParameter objects that specifies local or remote path where the conversion result will be saved.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns>Conversion.Conversion</returns>
        public Conversion.Conversion ConvertLocalDirectory(
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

        /// <summary>
        /// Converts synchronously a directory located in the local file system and specified by filePath parameter. Overloaded.
        /// </summary>
        /// <param name="directoryPath">Source directory path.</param>
        /// <param name="startPoint">File name in the directory to be converted.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion output format and, optionally, some format-specific parameters.</param>
        /// <param name="outputPath">Path string that by default specifies an output folder path in the default storage.</param>
        /// <param name="nameCollisionOption">Specifies how to handle the result file name collision.</param>
        /// <param name="observer">Object of a class that implements IObserver interface; it can receive notifications on a conversion process events.</param>
        /// <returns>Conversion.Conversion</returns>
        public Conversion.Conversion ConvertLocalDirectory(
            string directoryPath,
            string startPoint,
            ConversionOptions options,
            string outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertLocalDirectory( directoryPath, startPoint, options,
                new RemoteDirectoryParameter(outputPath), nameCollisionOption, observer);
        }




        /// <summary>
        /// Gets a current status of long-time conversion operation started previously by ConvertAsync method.
        /// </summary>
        /// <param name="id">Long-time conversion operation ID.</param>
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

        /// <summary>
        /// Cancels long-time asynchronous operation started previously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        #endregion

        #region Private/internal methods

        /// <summary>
        /// Converts synchronously a file (or files) specified by source parameter. 
        /// This method is a synchronous mode of the ConvertAsync. 
        /// Returns the Conversion.Conversion object with a list of conversion results.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <param name="outputPath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts synchronously a file (or files) specified by source parameter. 
        /// This method is a synchronous mode of the ConvertAsync. 
        /// Returns the Conversion.Conversion object with a list of conversion results.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <param name="outputPath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Starts asynchronously a long-time conversion operation on the source files specified by source parameter and 
        /// returns an object that allows to check the aynchronous operation status.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <param name="outputPath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
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
                var createModel = new ConversionRequest
                {
                    OutputFileFormat = options.Format
                };

                var content = new StringContent(options.ToJson(),
                    Encoding.UTF8, "application/json");

                try
                {


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
                                    createModel.InputUrl = new List<string> { upload.Path };
                                }
                                else // with resources - valid for HTML/XHTML source files only
                                {
                                    byte[] sourceArr = ZipUtils.ZipFileList(local.Path, local.Paths);
                                    var upload = Storage.UploadData(sourceArr, uploadUri.OriginalString + ".zip");
                                    createModel.InputUrl = new List<string> { upload.Path, Path.GetFileName(local.Paths[0]) }; 
                                }
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
                                createModel.InputUrl = new List<string> { upload.Path, Path.GetFileName(localDir.Paths[1]) };
                                //createModel.InputUrl[0] = upload.Path;
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
                catch(Exception ex)
                {
                    result.Data.WithStatus(Conversion.Conversion.FAULTED);
                    observer.OnError(ex);
                    result.Complete();
                }

            }, cancellationTokenSource.Token);

            return result;
        }



        /// <summary>
        /// TEMPORARY MARKED AS INTERNAL
        /// </summary>
        /// <param name="filePaths"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns></returns>
        internal AsyncResult<Conversion.Conversion> ConvertLocalFileAsync(
            List<string> filePaths,
            ConversionOptions options,
            PathParameter outputPath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return ConvertAsync(ConversionSource.FromLocalFile(filePaths), options, outputPath, nameCollisionOption, observer);
        }

        /// <summary>
        /// TEMPORARY MARKED AS INTERNAL
        /// Converts synchronously a file (or files) specified by source parameter. 
        /// This method is a synchronous mode of the ConvertAsync. 
        /// Returns the Conversion.Conversion object with a list of conversion results.
        /// </summary>
        /// <param name="files"></param>
        /// <param name="options"></param>
        /// <param name="outputFilePath"></param>
        /// <param name="nameCollisionOption"></param>
        /// <param name="observer"></param>
        /// <returns>Conversion.Conversion</returns>
        internal Conversion.Conversion Convert(
            List<RemoteFile> files,
            ConversionOptions options,
            string outputFilePath = null,
            NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
            IObserver<Conversion.Conversion> observer = null)
        {
            return null;
            //return Convert(ConversionSource.FromRemoteFile(files), options, outputFilePath, nameCollisionOption, observer);
        }

        #region REM - not used internal
        ///// <summary>
        ///// TEMPORARY MARKED AS INTERNAL
        ///// called from Convert(ConverterBuilder builder)
        ///// </summary>
        ///// <param name="filePath"></param>
        ///// <param name="options"></param>
        ///// <param name="outputFilePath"></param>
        ///// <param name="nameCollisionOption"></param>
        ///// <param name="observer"></param>
        ///// <returns></returns>
        //internal Conversion.Conversion ConvertLocalFile(
        //    List<string> filePath,
        //    ConversionOptions options,
        //    string outputFilePath = null,
        //    NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
        //    IObserver<Conversion.Conversion> observer = null)
        //{
        //    return Convert(ConversionSource.FromLocalFile(filePath), options, outputFilePath, nameCollisionOption, observer);
        //}
        ///// <summary>
        ///// TEMPORARY MARKED AS INTERNAL
        ///// Overloaded method. Synchronous mode of method *ConvertWebSiteAsync*. 
        ///// Converts several web pages specified by the list of their URLs.
        ///// </summary>
        ///// <param name="url"></param>
        ///// <param name="options"></param>
        ///// <param name="outputFilePath"></param>
        ///// <param name="nameCollisionOption"></param>
        ///// <param name="observer"></param>
        ///// <returns>Conversion.Conversion</returns>
        //internal Conversion.Conversion ConvertWebSite(
        //    List<string> url,
        //    ConversionOptions options,
        //    string outputFilePath = null,
        //    NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
        //    IObserver<Conversion.Conversion> observer = null)
        //{
        //    return Convert(ConversionSource.FromRemoteFile(url), options, outputFilePath, nameCollisionOption, observer);
        //}

        ///// <summary>
        ///// TEMPORARY MARKED AS INTERNAL
        ///// Starts asynchronously a long-time conversion operation of a source file (or files) 
        ///// specified by source parameter and returns an AsyncResult object that allows watching for the current asynchronous operation status. 
        ///// </summary>
        ///// <param name="files"></param>
        ///// <param name="options"></param>
        ///// <param name="outputPath"></param>
        ///// <param name="nameCollisionOption"></param>
        ///// <param name="observer"></param>
        ///// <returns></returns>
        //internal AsyncResult<Conversion.Conversion> ConvertAsync(
        //    List<RemoteFile> files,
        //    ConversionOptions options,
        //    PathParameter outputPath = null,
        //    NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
        //    IObserver<Conversion.Conversion> observer = null)
        //{
        //    return ConvertAsync(ConversionSource.FromRemoteFile(files), options, outputPath, nameCollisionOption, observer);
        //}

        ///// <summary>
        ///// TEMPORARY MARKED AS INTERNAL
        ///// Starts asynchronously a long-time conversion operation of a source file (or files) 
        ///// specified by *filePaths* parameter and returns an AsyncResult object that allows 
        ///// watching for the current asynchronous operation status. 
        ///// </summary>
        ///// <param name="filePaths"></param>
        ///// <param name="options"></param>
        ///// <param name="storageName"></param>
        ///// <param name="outputFilePath"></param>
        ///// <param name="nameCollisionOption"></param>
        ///// <param name="observer"></param>
        ///// <returns></returns>
        //internal AsyncResult<Conversion.Conversion> ConvertAsync(
        //    List<string> filePaths,
        //    ConversionOptions options,
        //    string storageName = null,
        //    PathParameter outputPath = null,
        //    NameCollisionOption nameCollisionOption = NameCollisionOption.FailIfExists,
        //    IObserver<Conversion.Conversion> observer = null)
        //{
        //    return ConvertAsync(ConversionSource.FromRemoteFile(filePaths), options, outputPath, nameCollisionOption, observer);
        //}

        #endregion

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

        #endregion

        #region IDisposable implementation
        public void Dispose()
        {
            cancellationTokenSource.Cancel();
        }

        #endregion

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