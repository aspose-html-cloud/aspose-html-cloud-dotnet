using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Aspose.HTML.Cloud.Sdk.Runtime;
using Aspose.HTML.Cloud.Sdk.DTO;
using Aspose.HTML.Cloud.Sdk.Runtime.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace Aspose.HTML.Cloud.Sdk.IO
{
    internal sealed class StorageProvider
    {
        private Configuration configuration;
        private StorageFactory factory;
        private TaskFactory taskFactory;
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private ApiInvokerFactory InvokerFactory { get; set; }

        const string STORAGE_URI = "/v4.0/html/storage";
        const string FILE_URI = "/v4.0/html/file";
        const string FOLDER_URI = "/v4.0/html/folder";

        internal StorageProvider(Configuration configuration, StorageFactory factory, ApiInvokerFactory invokerFactory = null)
        {
            this.configuration = configuration;
            this.factory = factory;
            this.taskFactory = new TaskFactory(cancellationTokenSource.Token);
            this.InvokerFactory = invokerFactory;
        }

        /// <summary>
        /// Checks if specified cloud storage exists or is available for the user
        /// </summary>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public bool Exists(string storageName)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = apiInvoker.CallGet(
                RequestUrlBuilder.GetBuilder($"{STORAGE_URI}/exist/storage")
                    .WithStorageName(storageName));

            return response.Exists;
        }

        /// <summary>
        /// Gets storage info by specified storage name, including total and used disc space 
        /// </summary>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public Storage GetStorage(string storageName)
        {
            var apiInvoker = InvokerFactory.GetInvoker<Storage>();
            var response = apiInvoker.CallGet(
                RequestUrlBuilder.GetBuilder($"{STORAGE_URI}/disc")
                    .WithStorageName(storageName));
            return new Storage(storageName, response.UsedSize, response.TotalSize);
        }


        #region Directory API

        /// <summary>
        /// Checks if a directory specified by the path exists in the specified or default storage
        /// </summary>
        /// <param name="directoryUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public bool DirectoryExists(string directoryUri, string storageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = apiInvoker.CallGet(
                RequestUrlBuilder.GetBuilder($"{STORAGE_URI}/exist")
                    .WithStorageName(storageName)
                    .WithPath(directoryUri));
            return response.IsFolder && response.Exists;
        }

        /// <summary>
        /// Overloaded method. Checks if a directory exists by the storage/folder path specified by RemoteDirectory object's Path property
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public bool DirectoryExists(RemoteDirectory dir)
        {
            var parsed = PathUtility.Parse(dir.Path, true);
            return DirectoryExists(parsed.Path, parsed.StorageName);
        }

        /// <summary>
        /// Gets a list of directorie that are direct children of the specified directory in the specified or default storage. 
        /// </summary>
        /// <param name="rootDirectoryUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public IReadOnlyList<RemoteDirectory> GetDirectories(string rootDirectoryUri, string storageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<FilesList>();
            var response = apiInvoker.CallGet(
                 RequestUrlBuilder.GetBuilder($"{FOLDER_URI}")
                     .WithStorageName(storageName)
                     .WithPath(rootDirectoryUri));

            var res = response.Value
                 .Where(f => f.IsFolder == true)
                 .Select(f => {
                     var dirUri = PathUtility.BuildPath("storage", storageName, f.Path);
                     return new RemoteDirectory(new Uri(dirUri), new RemoteFileSystemInfo(0, DateTime.MinValue));
                 }).ToImmutableList();
            return res;
        }

        /// <summary>
        /// Get a specified directory info, or null, if the directory doesn't exist.
        /// </summary>
        /// <param name="directoryUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public RemoteDirectory GetDirectory(string directoryUri, string storageName = null)
        {
            var rootDir = PathUtility.GetFolderPath(directoryUri);
            var dirs = GetDirectories(rootDir, storageName);
            var sel = dirs.Where(d => d.Name.Replace("/", "") == Path.GetFileName(directoryUri)).ToArray();
            return sel?.First();
        }

        /// <summary>
        /// Creates a directory in the specified or default storage; 
        /// all parent directories specified in the directoryUri path will be created too if they don't exist.  
        /// </summary>
        /// <param name="directoryUri"></param>
        /// <param name="storageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteDirectory CreateDirectory(string directoryUri, string storageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var exists = DirectoryExists(directoryUri, storageName);
            if (exists && option == NameCollisionOption.FailIfExists)
                throw new ApiException((int)HttpStatusCode.BadRequest, $"{directoryUri}: folder already exists");

            var apiInvoker = InvokerFactory.GetInvoker<RemoteDirectory>();
            var response = apiInvoker.CallPost(
                RequestUrlBuilder.GetBuilder($"{FOLDER_URI}")
                    .WithPath(directoryUri)
                    .WithStorageName(storageName), 
                new ByteArrayContent(new byte[] { }));
            
            return new RemoteDirectory(
                new Uri(PathUtility.BuildPath("storage", storageName, directoryUri)), 
                new RemoteFileSystemInfo(0L, DateTime.UtcNow));
        }

        /// <summary>
        /// Deletes a directory by the specified path from the specified or default storage.
        /// </summary>
        /// <param name="directoryUri"></param>
        /// <param name="storageName"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public bool DeleteDirectory(string directoryUri, string storageName = null, bool recursive = false)
        {
            string paramRecursive = recursive ? "true" : "";

            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = apiInvoker.CallDelete(
                 RequestUrlBuilder.GetBuilder($"{FOLDER_URI}")
                     .WithStorageName(storageName)
                     .WithPath(directoryUri)
                     .WithParameter("recursive", paramRecursive));
            //// TODO
            return true;
        }

        /// <summary>
        /// Overloaded method. Deletes a directory by the path specified by RemoteDirectory object.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public bool DeleteDirectory(RemoteDirectory directory, bool recursive = false)
        {
            var parsed = PathUtility.Parse(directory.Path, true);
            return DeleteDirectory(parsed.Path, parsed.StorageName, recursive);
        }

        /// <summary>
        /// Copies a directory.
        /// </summary>
        /// <param name="srcDirectoryUri"></param>
        /// <param name="destDirectoryUri"></param>
        /// <param name="srcStorageName"></param>
        /// <param name="destStorageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteDirectory CopyDirectory(string srcDirectoryUri, string destDirectoryUri, string srcStorageName = null, string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = apiInvoker.CallPut(
                 RequestUrlBuilder.GetBuilder($"{FOLDER_URI}/copy")
                     .WithSourcePath(srcDirectoryUri)
                     .WithDestinationPath(destDirectoryUri)
                     .WithSourceStorage(srcStorageName)
                     .WithDestinationStorage(destStorageName), new ByteArrayContent(new byte[] { }));

            //// TODO
            var pathString = PathUtility.BuildPath("storage", destStorageName, destDirectoryUri);
            return new RemoteDirectory(new Uri(pathString), new RemoteFileSystemInfo(0, DateTime.MinValue));
        }

        /// <summary>
        /// Copies a directory - overloaded method.
        /// </summary>
        /// <param name="srcDirectory"></param>
        /// <param name="destDirectoryUri"></param>
        /// <param name="destStorageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteDirectory CopyDirectory(RemoteDirectory srcDirectory, string destDirectoryUri, string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var parsed = PathUtility.Parse(srcDirectory.Path, true);
            return CopyDirectory(parsed.Path, destDirectoryUri, parsed.StorageName, destStorageName);
        }

        /// <summary>
        /// Copies a directory - overloaded method.
        /// </summary>
        /// <param name="srcDirectory"></param>
        /// <param name="destDirectory"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteDirectory CopyDirectory(RemoteDirectory srcDirectory, RemoteDirectory destDirectory, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var parsedSrc = PathUtility.Parse(srcDirectory.Path, true);
            var parsedDst = PathUtility.Parse(destDirectory.Path, true);
            return CopyDirectory(parsedSrc.Path, parsedDst.Path, parsedSrc.StorageName, parsedDst.StorageName);
        }

        /// <summary>
        /// Moves a directory.
        /// </summary>
        /// <param name="srcDirectoryUri"></param>
        /// <param name="destDirectoryUri"></param>
        /// <param name="srcStorageName"></param>
        /// <param name="destStorageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteDirectory MoveDirectory(string srcDirectoryUri, string destDirectoryUri, string srcStorageName = null, string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = apiInvoker.CallPut(
                 RequestUrlBuilder.GetBuilder($"{FOLDER_URI}/move")
                     .WithSourcePath(srcDirectoryUri)
                     .WithDestinationPath(destDirectoryUri)
                     .WithSourceStorage(srcStorageName)
                     .WithDestinationStorage(destStorageName), new ByteArrayContent(new byte[] { }));

            //// TODO
            var pathString = PathUtility.BuildPath("storage", destStorageName, destDirectoryUri);
            return new RemoteDirectory(new Uri(pathString), null);
        }

        /// <summary>
        /// Moves a directory - overloaded method.
        /// </summary>
        /// <param name="srcDirectory"></param>
        /// <param name="destDirectoryUri"></param>
        /// <param name="destStorageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteDirectory MoveDirectory(RemoteDirectory srcDirectory, string destDirectoryUri, string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var parsed = PathUtility.Parse(srcDirectory.Path, true);
            return MoveDirectory(parsed.Path, destDirectoryUri, parsed.StorageName, destStorageName);
        }

        /// <summary>
        /// Moves a directory - overloaded method.
        /// </summary>
        /// <param name="srcDirectory"></param>
        /// <param name="destDirectory"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteDirectory MoveDirectory(RemoteDirectory srcDirectory, RemoteDirectory destDirectory, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var parsedSrc = PathUtility.Parse(srcDirectory.Path, true);
            var parsedDst = PathUtility.Parse(destDirectory.Path, true);
            return MoveDirectory(parsedSrc.Path, parsedDst.Path, parsedSrc.StorageName, parsedDst.StorageName);
        }

        #endregion

        #region File API

        /// <summary>
        /// Checks if a file specified by the path exists in the specified or default storage
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public bool FileExists(string fileUri, string storageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = apiInvoker.CallGet(
                RequestUrlBuilder.GetBuilder($"{STORAGE_URI}/exist")
                    .WithStorageName(storageName)
                    .WithPath(fileUri));
            return !response.IsFolder && response.Exists;
        }

        /// <summary>
        /// Overloaded method. Checks if a file specified by the Path property of RemoteFile object exists.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns 
        public bool FileExists(RemoteFile file)
        {
            var parsed = PathUtility.Parse(file.Path);           
            return FileExists(parsed.Path, parsed.StorageName);
        }

        /// <summary>
        /// Gets a list of files by specified directory path in the specified or default storage.
        /// </summary>
        /// <param name="directoryUri"></param>
        /// <param name="storageName"></param>
        /// <returns></returns>
        public IReadOnlyList<RemoteFile> GetFiles(string directoryUri, string storageName = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<FilesList>();
            var response = apiInvoker.CallGet(
                 RequestUrlBuilder.GetBuilder($"{FOLDER_URI}")
                     .WithStorageName(storageName)
                     .WithPath(directoryUri));

            var res = response.Value
                        .Where(f => f.IsFolder == false)
                        .Select(f => {
                            var fileUri = PathUtility.BuildPath("storage", storageName, f.Path);
                            return new RemoteFile(
                                new Uri(fileUri), 
                                new RemoteFileSystemInfo(f.Size, f.ModifiedDate.GetValueOrDefault()));
                        }).ToImmutableList();
            return res;
        }

        /// <summary>
        /// Overloaded method. 
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public IReadOnlyList<RemoteFile> GetFiles(RemoteDirectory directory)
        {
            var parsed = PathUtility.Parse(directory.Path);
            return GetFiles(parsed.Path, parsed.StorageName);
        }

        public RemoteFile GetFileInfo(string fileUri, string storageName = null)
        {
            var dir = PathUtility.GetFolderPath(fileUri);
            var resList = GetFiles(dir, storageName);
            if(resList != null )
            {
                var selected = resList.Where(f => f.Name == Path.GetFileName(fileUri)).ToArray();
                if (selected.Length > 0)
                {
                    var resFile = selected.First();
                    return resFile;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the file info by its name in the directory specified by RemoteDirectory object
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public RemoteFile GetFileInfo(RemoteDirectory directory, string fileName)
        {
            var parsed = PathUtility.Parse(directory.Path, true);
            var filePath = $"{parsed.Path}{ (parsed.Path.EndsWith("/") ? "" : "/") }{fileName}";
            return GetFileInfo(filePath, parsed.StorageName);
        }

        /// <summary>
        /// Uploads a file synchronously by its local file system path to the specified storage.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="remoteFileUri"></param>
        /// <param name="storageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteFile UploadFile(string file, string remoteFileUri, string storageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var asyncRes = UploadFileAsync(file, remoteFileUri, storageName, option);
            asyncRes.AsyncWaitHandle.WaitOne();
            return asyncRes.Data; 
        }

        /// <summary>
        /// Starts asynchronous upload of a file by its local file system path to the specified storage.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="remoteFileUri"></param>
        /// <param name="storageName"></param>
        /// <param name="option"></param>
        /// <param name="progressCallback"></param>
        /// <returns></returns>
        public AsyncResult<RemoteFile> UploadFileAsync(string file, string remoteFileUri, string storageName = null, 
            NameCollisionOption option = NameCollisionOption.FailIfExists,
            IProgress<object> progressCallback = null)
        {
            AsyncResult<RemoteFile> res = new AsyncResult<RemoteFile>();

            var url = RequestUrlBuilder.GetBuilder(FILE_URI)
                .WithPath(file)
                .WithStorageName(storageName).Build();

            var content = new MultipartFormDataContent();
            var bytes = File.ReadAllBytes(file);
            content.Add(new ByteArrayContent(bytes), "file", Path.GetFileName(file));

            var uploadUri = factory.GetResourceUri(remoteFileUri, storageName).OriginalString;
            var uploadFileName = Path.GetFileName(uploadUri);
            var uploadDir = uploadUri.Substring(0, uploadUri.LastIndexOf(uploadFileName));

            taskFactory.StartNew(() =>
            {
                var apiInvoker = InvokerFactory.GetInvoker<FilesUploadResult>();
                var response = apiInvoker.CallPost(
                    RequestUrlBuilder.GetBuilder(FILE_URI)
                        .WithPath(uploadDir)
                        .WithStorageName(storageName), content);
                // TO DO: 
                var resfile = new RemoteFile(new Uri(response.Uploaded.First()), null);
                res.WithData(resfile);
                res.Complete();
                
            }, cancellationTokenSource.Token);

            return res;
        }

        /// <summary>
        /// Uploads a byte array as a file into storage synchronously.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteFile UploadData(byte[] data, string fileUri, string storageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var asyncRes = UploadDataAsync(data, fileUri, storageName, option);
            asyncRes.AsyncWaitHandle.WaitOne();
            return asyncRes.Data;
        }


        /// <summary>
        /// Starts asynchronous upload of a byte array as a file into storage.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <param name="option"></param>
        /// <param name="progressCallback"></param>
        /// <returns></returns>
        public AsyncResult<RemoteFile> UploadDataAsync(byte[] data, string fileUri, string storageName = null,
            NameCollisionOption option = NameCollisionOption.FailIfExists,
            IProgress<VoidResult> progressCallback = null)
        {
            AsyncResult<RemoteFile> res = new AsyncResult<RemoteFile>();
            var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(data), "file", Path.GetFileName(fileUri));

            var uploadUri = factory.GetResourceUri(fileUri, storageName).OriginalString;
            var uploadFileName = Path.GetFileName(uploadUri);
            var uploadDir = uploadUri.Substring(0, uploadUri.LastIndexOf(uploadFileName));

            taskFactory.StartNew(() => {
                var apiInvoker = InvokerFactory.GetInvoker<FilesUploadResultEx>();
                var response = apiInvoker.CallPost(
                    RequestUrlBuilder.GetBuilder(FILE_URI)
                        .WithPath(uploadDir)
                        .WithStorageName(storageName), content);

                var resFile = new RemoteFile(new Uri(response.Uploaded[0]),
                    new RemoteFileSystemInfo(
                        response.UploadedInfo[0].Size, 
                        response.UploadedInfo[0].ModifiedDate.Value));

                res.WithData(resFile);
                res.Complete();               
            }, cancellationTokenSource.Token);

            return res;
        }


        /// <summary>
        /// Downloads a storage file synchronously by its storage path and saves by a local file system path.
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="localFilePath"></param>
        /// <param name="storageName"></param>
        /// <param name="versionId"></param>
        public void DownloadFile(string fileUri, string localFilePath, string storageName = null, string versionId = null)
        {
            DownloadFileAsync(fileUri, localFilePath, storageName, versionId).AsyncWaitHandle.WaitOne();
        }

        /// <summary>
        /// Overloaded method. Downloads a storage file synchronously by its storage path from RemoteFile object and saves by a local file system path.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="localFilePath"></param>
        /// <param name="versionId"></param>
        public void DownloadFile(RemoteFile file, string localFilePath, string versionId = null)
        {
            var parsed = PathUtility.Parse(file.Path);
            //var fullPath = Path.Combine(localFilePath, parsed.FileName);
            DownloadFile(parsed.Url, localFilePath, parsed.StorageName, versionId);
        }

        /// <summary>
        /// Starts asynchronous dowmload of a storage file into a local file.
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="localFilePath"></param>
        /// <param name="storageName"></param>
        /// <param name="versionId"></param>
        /// <param name="progressCallback"></param>
        /// <returns></returns>
        public AsyncResult DownloadFileAsync(string fileUri, string localFilePath, 
            string storageName = null, string versionId = null, 
            IProgress<object> progressCallback = null)
        {
            AsyncResult res = new AsyncResult();

            var url = RequestUrlBuilder.GetBuilder(FILE_URI)
                .WithPath(fileUri)
                .WithStorageName(storageName).Build();

            var remotePath = PathUtility.BuildPath("storage", storageName, fileUri);

            taskFactory.StartNew(() => {

                var apiInvoker = InvokerFactory.GetInvoker<StreamResponse>();
                var response = apiInvoker.CallGetAsStream(url, HttpCompletionOption.ResponseHeadersRead);

                try
                {               
                    var dir = Path.GetDirectoryName(localFilePath);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    using (var outputStream = File.Create(localFilePath))
                    using (var wr = new BinaryWriter(outputStream))
                    using (var resourceStream = response.Stream)
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes = 0;
                        long totalBytes = response.StreamLength;
                        long totalRead = 0;

                        while ((readBytes = resourceStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            totalRead += readBytes;
                            // TODO: progress here
                            if (cancellationTokenSource.IsCancellationRequested)
                            {
                                // set Cancel status
                                //res.Status
                                break;
                            }

                            progressCallback?.Report(new ProgressData { ProcessedBytes = totalRead, TotalBytes = totalBytes });
                            wr.Write(buffer, 0, readBytes);
                        }
                        wr.Flush();
                        res.Complete();
                    }
                }
                catch(Exception ex)
                {
                    res.Complete();
                    throw ex;
                }
            }, cancellationTokenSource.Token);
            return res;
        }

        /// <summary>
        /// Overload method. Starts asynchronous dowmload of a storage file into a local file.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="localFilePath"></param>
        /// <param name="versionId"></param>
        /// <param name="progressCallback"></param>
        /// <returns></returns>
        public AsyncResult DownloadFileAsync(RemoteFile file, string localFilePath, string versionId = null, 
            IProgress<object> progressCallback = null)
        {
            var parsed = PathUtility.Parse(file.Path);
            return DownloadFileAsync(parsed.Path, localFilePath, parsed.StorageName, versionId, progressCallback);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="versionId"></param>
        /// <returns></returns>
        public byte[] DownloadData(RemoteFile file, string versionId = null)
        {
            var parsed = PathUtility.Parse(file.Path);
            return DownloadData(parsed.Path, parsed.StorageName, versionId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <param name="versionId"></param>
        /// <returns></returns>
        public byte[] DownloadData(string fileUri, string storageName = null, string versionId = null)
        {
            var res = DownloadDataAsync(fileUri, storageName, versionId);
            res.AsyncWaitHandle.WaitOne();
            return res.Data;
        }

        /// <summary>
        /// Starts asynchronous download of a storage file into the byte array.
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <param name="versionId"></param>
        /// <param name="progressCallback"></param>
        /// <returns></returns>
        public AsyncResult<byte[]> DownloadDataAsync(string fileUri, 
            string storageName = null, 
            string versionId = null,
            IProgress<ProgressData> progressCallback = null )
        {
            AsyncResult<byte[]> res = new AsyncResult<byte[]>();

            var url = RequestUrlBuilder.GetBuilder(FILE_URI)
                .WithPath(fileUri)
                .WithStorageName(storageName).Build();

            var remotePath = PathUtility.BuildPath("storage", storageName, fileUri);

            taskFactory.StartNew(() =>  {

                var apiInvoker = InvokerFactory.GetInvoker<StreamResponse>();
                var response = apiInvoker.CallGetAsStream(url, HttpCompletionOption.ResponseHeadersRead);
               
                using (var outputStream = new MemoryStream())
                using (var wr = new BinaryWriter(outputStream))
                using (var resourceStream = response.Stream)
                {
                    byte[] buffer = new byte[4096];
                    int readBytes = 0;
                    long totalBytes = response.StreamLength;
                    long totalRead = 0;

                    while ((readBytes = resourceStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        totalRead += readBytes;
                        // TODO: progress here
                        if (cancellationTokenSource.IsCancellationRequested)
                        {
                            res.Complete();
                            // set Cancel status
                            break;
                        }

                        progressCallback?.Report(new ProgressData { ProcessedBytes = totalRead, TotalBytes = totalBytes });
                        wr.Write(buffer, 0, readBytes);
                    }
                    wr.Flush();
                    res.WithData(outputStream.ToArray());
                    res.Complete();
                }
            }, cancellationTokenSource.Token);

            return res;
        }

        /// <summary>
        /// Overloaded method. Starts asynchronous download of a storage file into the byte array.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="versionId"></param>
        /// <param name="progressCallback"></param>
        /// <returns></returns>
        public AsyncResult<byte[]> DownloadDataAsync(RemoteFile file, string versionId = null, 
            IProgress < ProgressData > progressCallback = null)
        {
            var parsed = PathUtility.Parse(file.Path);
            return DownloadDataAsync(parsed.Path, parsed.StorageName, versionId, progressCallback);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <param name="versionId"></param>
        /// <returns></returns>
        public Stream OpenRead(string fileUri, string storageName = null, string versionId = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<Stream>();
            var url = RequestUrlBuilder.GetBuilder(FILE_URI)
                .WithPath(fileUri)
                .WithStorageName(storageName).Build();
            return apiInvoker.CallGetAsStream(url).Stream;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="versionId"></param>
        /// <returns></returns>
        public Stream OpenRead(RemoteFile file, string versionId = null)
        {
            var parsed = PathUtility.Parse(file.Path);
            return OpenRead(parsed.Path, parsed.StorageName, versionId);
        }

        /// <summary>
        /// Deletes a storage file by its path from the specified or default storage.
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="storageName"></param>
        /// <param name="versionId"></param>
        /// <returns></returns>
        public bool DeleteFile(string fileUri, string storageName = null, string versionId = null)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = apiInvoker.CallDelete(
                 RequestUrlBuilder.GetBuilder($"{FILE_URI}")
                     .WithStorageName(storageName)
                     .WithPath(fileUri));

            return !FileExists(fileUri, storageName);
        }

        /// <summary>
        /// Overloaded method. Deletes a storage file specified by RemoteFile object.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="versionId"></param>
        /// <returns></returns>
        public bool DeleteFile(RemoteFile file, string versionId = null)
        {
            var parsed = PathUtility.Parse(file.Path, true);
            return DeleteFile(parsed.Path, parsed.StorageName);
        }

        /// <summary>
        /// Copies a storage file.
        /// </summary>
        /// <param name="srcFileUri"></param>
        /// <param name="destFileUri"></param>
        /// <param name="srcStorageName"></param>
        /// <param name="destStorageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteFile CopyFile(string srcFileUri, string destFileUri, string srcStorageName = null, string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = apiInvoker.CallPut(
                 RequestUrlBuilder.GetBuilder($"{FILE_URI}/copy")
                     .WithSourcePath(srcFileUri)
                     .WithDestinationPath(destFileUri)
                     .WithSourceStorage(srcStorageName)
                     .WithDestinationStorage(destStorageName), new ByteArrayContent(new byte[] { }));

            var pathString = PathUtility.BuildPath("storage", destStorageName, destFileUri);
            return new RemoteFile(new Uri(pathString), null);
        }

        /// <summary>
        /// Overloaded method. Copies a storage file.
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="destFileUri"></param>
        /// <param name="destStorageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteFile CopyFile(RemoteFile srcFile, string destFileUri, string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var parsed = PathUtility.Parse(srcFile.Path);
            return CopyFile(parsed.Path, destFileUri, parsed.StorageName, destStorageName);
        }

        /// <summary>
        /// Overloaded method. Copies a storage file.
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="destFile"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteFile CopyFile(RemoteFile srcFile, RemoteFile destFile, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var parsedSrc = PathUtility.Parse(srcFile.Path, true);
            var parsedDst = PathUtility.Parse(destFile.Path, true);
            return CopyFile(parsedSrc.Path, parsedDst.Path, parsedSrc.StorageName, parsedDst.StorageName);
        }

        /// <summary>
        /// Moves a storage file to other storage location. 
        /// </summary>
        /// <param name="srcFileUri"></param>
        /// <param name="destFileUri"></param>
        /// <param name="srcStorageName"></param>
        /// <param name="destStorageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteFile MoveFile(string srcFileUri, string destFileUri, string srcStorageName = null, string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var apiInvoker = InvokerFactory.GetInvoker<ObjectExist>();
            var response = apiInvoker.CallPut(
                 RequestUrlBuilder.GetBuilder($"{FILE_URI}/move")
                     .WithSourcePath(srcFileUri)
                     .WithDestinationPath(destFileUri)
                     .WithSourceStorage(srcStorageName)
                     .WithDestinationStorage(destStorageName), new ByteArrayContent(new byte[] { }));

            var pathString = PathUtility.BuildPath("storage", destStorageName, destFileUri);
            return new RemoteFile(new Uri(pathString), null);
        }

        /// <summary>
        /// Overloaded method. Moves a storage file to other storage location. 
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="destFileUri"></param>
        /// <param name="destStorageName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteFile MoveFile(RemoteFile srcFile, string destFileUri, string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var parsed = PathUtility.Parse(srcFile.Path);
            return MoveFile(parsed.Path, destFileUri, parsed.StorageName, destStorageName);
        }


        /// <summary>
        /// Overloaded method. Moves a storage file to other storage location.
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="destFile"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public RemoteFile MoveFile(RemoteFile srcFile, RemoteFile destFile, NameCollisionOption option = NameCollisionOption.FailIfExists)
        {
            var parsedSrc = PathUtility.Parse(srcFile.Path, true);
            var parsedDst = PathUtility.Parse(destFile.Path, true);
            return MoveFile(parsedSrc.Path, parsedDst.Path, parsedSrc.StorageName, parsedDst.StorageName);
        }

        #endregion
    }
}
