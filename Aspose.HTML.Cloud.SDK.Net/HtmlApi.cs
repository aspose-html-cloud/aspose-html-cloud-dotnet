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
        public const string ERRMSG_NO_USER_CREDS = "Authorization failed: Client ID and/or Client Secret were not specified. If you have no user credentials, please visit https://dashboard.aspose.cloud/#/ to create a free account.";
       
        private HtmlApiImpl ApiImplInstance; 

        /// <summary>
        /// Constructor. Initializes a class instance with API parameters provided by specified Configuration object.
        /// </summary>
        /// <param name="configuration">Configuration instance with API parameters.</param>
        public HtmlApi(Configuration configuration)
        {
            ApiImplInstance = new HtmlApiImpl(configuration);
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
        public StorageProvider Storage { 
            get 
            {
                return ApiImplInstance.Storage;
            } 
        }

        #endregion


        #region Public API methods

        /// <summary>
        /// Starts a conversion synchronously using ConversionBuilder class to setup the conversion parameters. 
        /// </summary>
        /// <param name="builder">ConverterBuilder object that collects conversion parameters.</param>
        /// <returns>ConversionResult</returns>
        public ConversionResult Convert(ConverterBuilder builder)
        {
            return ApiImplInstance.Convert(builder);
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
            return ApiImplInstance.ConvertAsync(ConversionSource.FromRemoteFile(singleAddress), options, outputPath, nameCollisionOption, observer);
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
            return ApiImplInstance.Convert(ConversionSource.FromRemoteFile(singleAddress), options, outputPath, nameCollisionOption, observer);
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
            return ApiImplInstance.Convert(ConversionSource.FromLocalFile(fileWithResources), options, outputPath, nameCollisionOption, observer);
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
            return ApiImplInstance.ConvertAsync(ConversionSource.FromLocalFile(fileList), options, outputPath, nameCollisionOption, observer);
        }

        /// <summary>
        /// Starts asynchronously a long-time conversion operation of the file in the local file system. Overloaded
        /// </summary>
        /// <param name="filePath">Source file path in the local file system.</param>
        /// <param name="options">ConversionOptions object that specifies a conversion output format and, optionally, some format-specific parameters.</param>
        /// <param name="outputPath">Path string that by default specifies an output folder path in the default remote storage.</param>
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
            return ApiImplInstance.Convert(ConversionSource.FromLocalArchiveFile(new List<string>() { archivePath, startPoint }), 
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
            return ApiImplInstance.Convert(ConversionSource.FromLocalDirectory(new List<string>() { directoryPath, startPoint }), 
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

        #endregion


        #region IDisposable implementation
        public void Dispose()
        {
            ApiImplInstance?.Dispose();
        }

        #endregion

    }
}