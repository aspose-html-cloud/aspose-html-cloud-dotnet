# StorageProvider

Class providing methods of cloud storage access.



## Table of Contents

> - [**Summary**](StorageProvider.md#Summary)
>
> - [**Namespace**](StorageProvider.md#Namespace)
>
> - [**Public methods**](StorageProvider.md#Public_Methods)
>
>   - [**Storage API**](StorageProvider.md#Storage_API)
>
>     - [*Exists*](StorageProvider.md#Storage_Exists)
>     - [*GetStorage*](StorageProvider.md#Storage_GetStorage)
>
>   - [**Directory API**](StorageProvider.md#Directory_API)
>
>     - [*DirectoryExists*](StorageProvider.md#Dir_DirectoryExists)
>     - [*DirectoryExists (overloaded)*](StorageProvider.md#Dir_DirectoryExists)
>     - [*GetDirectories*](StorageProvider.md#Dir_GetDirectories)
>     - [*GetDirectory*]()
>     - [*CreateDirectory*](StorageProvider.md#Dir_CreateDirectory)
>     - [*DeleteDirectory*](StorageProvider.md#Dir_DeleteDirectory)
>     - [*DeleteDirectory (overloaded)*](StorageProvider.md#Dir_DeleteDirectory_1)
>     - [*CopyDirectory*](StorageProvider.md#Dir_CopyDirectory)
>     - [*CopyDirectory (overloaded)*](StorageProvider.md#Dir_CopyDirectory_1)
>     - [*CopyDirectory (overloaded)*](StorageProvider.md#Dir_CopyDirectory_2)
>     - [*MoveDirectory*](StorageProvider.md#Dir_MoveDirectory)
>     - [*MoveDirectory (overloaded)*](StorageProvider.md#Dir_MoveDirectory_1)
>     - [*MoveDirectory (overloaded)*](StorageProvider.md#Dir_MoveDirectory_2)
>
>   - [**File API**](StorageProvider.md#File_API)
>
>     - [*FileExists*](StorageProvider.md#File_Exists)
>     - [*FileExists (overloaded)*](StorageProvider.md#File_Exists_1)
>     - [*GetFiles*](StorageProvider.md#File_GetFiles)
>     - [*GetFiles (overloaded)*](StorageProvider.md#File_GetFiles_1)
>     - [*UploadFile*](StorageProvider.md#File_UploadFile)
>     - [*UploadFileAsync*](StorageProvider.md#File_UploadFileAsync)
>     - [*UploadData*](StorageProvider.md#File_UploadData)
>     - [*UploadDataAsync*](StorageProvider.md#File_UploadDataAsync)
>     - [*DownloadFile*](StorageProvider.md#File_DownloadFile)
>     - [*DownloadFile (overloaded)*](StorageProvider.md#File_DownloadFile_1)
>     - [*DownloadFileAsync*](StorageProvider.md#File_DownloadFileAsync)
>     - [*DownloadFileAsync (overloaded)*](StorageProvider.md#File_DownloadFileAsync_1)
>
>     



<a name="Summary"/>

## Summary

This class that is a common SDK facade of cloud storage access. 

All storage access methods are divided to 3 groups:

 - storage information methods;
 - directory manipulation methods;
 - file manipulation methods.



<a name="Namespace"/>

## Namespace

Aspose.HTML.Cloud.Sdk.IO



<a name="Public_Methods" />

## Public methods



<a name="Storage_API"></a>

### *Storage API*

<a name="Storage_Exists"></a>

#### **Exists**
> ```
> bool Exists(string storageName)
> ```

Checks if specified cloud storage exists or is available for the user



<a name="Storage_GetStorage"></a>

#### **GetStorage**
> ```
> Storage GetStorage(string storageName)
> ```

Gets storage info by specified storage name, including total and used disc space

<br>



<a name="Directory_API"></a>


### *Directory API*

<a name="Dir_DirectoryExists"></a>

#### **DirectoryExists**
> ```
> bool DirectoryExists(string directoryUri, string storageName = null)
> ```

Checks if a directory specified by the path exists in the specified or default storage




<a name="Dir_DirectoryExists_1"></a>
#### **DirectoryExists**
> ```
> bool DirectoryExists(RemoteDirectory dir)
> ```

Overloaded method. Checks if a directory exists by the storage/folder path specified by [**RemoteDirectory**](RemoteDirectory.md) object's *Path* property



<a name="Dir_GetDirectories"></a>

#### **GetDirectories**
> ```
> IReadOnlyList<RemoteDirectory> GetDirectories(string rootDirectoryUri, string storageName = null)
> ```

Gets a list of directories that are direct children of the specified directory in the specified or default storage. 



<a name="Dir_GetDirectory"></a>
#### **GetDirectory**
> ```
> RemoteDirectory GetDirectory(string directoryUri, string storageName = null)
> ```

Get a specified directory info, or null, if the directory doesn't exist.



<a name="Dir_CreateDirectory"></a>

#### **CreateDirectory**
> ```
> RemoteDirectory CreateDirectory(string directoryUri, string storageName = null, 
> 					NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Creates a directory in the specified or default storage; all parent directories specified in the directoryUri path will be created too if they don't exist.  



<a name="Dir_DeleteDirectory"></a>

#### **DeleteDirectory**
> ```
> bool DeleteDirectory(string directoryUri, string storageName = null, bool recursive = false)
> ```

Deletes a directory by the specified path from the specified or default storage.



<a name="Dir_DeleteDirectory_1"></a>
#### **DeleteDirectory**
> ```
> bool DeleteDirectory(RemoteDirectory directory, bool recursive = false)
> ```

Overloaded method. Deletes a directory by the path specified by RemoteDirectory object.



<a name="Dir_CopyDirectory"></a>

#### **CopyDirectory**
> ```
> RemoteDirectory CopyDirectory(string srcDirectoryUri, string destDirectoryUri, string srcStorageName = null, 
>                            string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Copies a directory.



<a name="Dir_CopyDirectory_1"></a>
#### **CopyDirectory**
> ```
> RemoteDirectory CopyDirectory(RemoteDirectory srcDirectory, string destDirectoryUri, 
>                            string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Copies a directory - overloaded method.



<a name="Dir_CopyDirectory_2"></a>
#### **CopyDirectory**
> ```
> RemoteDirectory CopyDirectory(RemoteDirectory srcDirectory, RemoteDirectory destDirectory, 
> 							  NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Copies a directory - overloaded method.



<a name="Dir_MoveDirectory"></a>

#### **MoveDirectory**
> ```
> RemoteDirectory MoveDirectory(string srcDirectoryUri, string destDirectoryUri, string srcStorageName = null, 
>                            string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Moves a directory.



<a name="Dir_MoveDirectory_1"></a>

#### **MoveDirectory**
> ```
> RemoteDirectory MoveDirectory(RemoteDirectory srcDirectory, string destDirectoryUri, 
>                            string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Moves a directory - overloaded method.



<a name="Dir_MoveDirectory_2"></a>
#### **MoveDirectory**
> ```
> RemoteDirectory MoveDirectory(RemoteDirectory srcDirectory, RemoteDirectory destDirectory, 
> 							  NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Moves a directory - overloaded method.



<br>

<a name="File_API"></a>

### *File API*

<a name="File_Exists"></a>

#### **FileExists**
> ```
> FileExists(string fileUri, string storageName = null)
> ```

Checks if a file specified by the path exists in the specified or default storage



<a name="File_Exists_1"></a>
#### **FileExists**
> ```
> bool FileExists(RemoteFile file)
> ```

Overloaded method. Checks if a file specified by the Path property of RemoteFile object exists.



<a name="File_GetFiles"></a>

#### **GetFiles**
> ```
> IReadOnlyList<RemoteFile> GetFiles(string directoryUri, string storageName = null)
> ```

Gets a list of files by specified directory path in the specified or default storage.



<a name="File_GetFiles_1"></a>
#### **GetFiles**
> ```
> IReadOnlyList<RemoteFile> GetFiles(RemoteDirectory directory)
> ```

Overloaded method. Gets a list of files in the directory specified by RemoteDirectory object.



<a name="File_UploadFile"></a>

#### **UploadFile**
> ```
> RemoteFile UploadFile(string file, string remoteFileUri, string storageName = null, 
> 				NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Uploads a file synchronously by its local file system path to the specified storage.



<a name="File_UploadFileAsync"></a>
#### **UploadFileAsync**
> ```
> AsyncResult<RemoteFile> UploadFileAsync(string file, string remoteFileUri, string storageName = null, 
>         NameCollisionOption option = NameCollisionOption.FailIfExists,
>        IProgress<object> progressCallback = null)
> ```

Starts asynchronous upload of a file by its local file system path to the specified storage.



<a name="File_UploadData"></a>

#### **UploadData**
> ```
> RemoteFile UploadData(byte[] data, string fileUri, string storageName = null, 
> 					NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Uploads a byte array as a file into storage synchronously.

<a name="File_UploadDataAsync"></a>
#### **UploadDataAsync**
> ```
> AsyncResult<RemoteFile> UploadDataAsync(byte[] data, string fileUri, string storageName = null,
>         NameCollisionOption option = NameCollisionOption.FailIfExists,
>         IProgress<VoidResult> progressCallback = null)
> ```

Starts asynchronous upload of a byte array as a file into storage.



<a name="File_DownloadFile"></a>

#### **DownloadFile**
> ```
> void DownloadFile(string fileUri, string localFilePath, string storageName = null, string versionId = null)
> ```

Downloads a storage file synchronously by its storage path and saves by a local file system path.



<a name="File_DownloadFile_1"></a>
#### **DownloadFile**
> ```
> void DownloadFile(RemoteFile file, string localFilePath, string versionId = null)
> ```

Overloaded method. Downloads a storage file synchronously by its storage path from RemoteFile object and saves by a local file system path.



<a name="File_DownloadFileAsync"></a>
#### **DownloadFileAsync**
> ```
> AsyncResult DownloadFileAsync(string fileUri, string localFilePath, 
>         string storageName = null, string versionId = null, 
>         IProgress<object> progressCallback = null)
> ```

Starts asynchronous download of a storage file into a local file.




<a name="File_DownloadFileAsync_1"></a>
#### **DownloadFileAsync**
> ```
> AsyncResult DownloadFileAsync(RemoteFile file, string localFilePath, string versionId = null, 
>        IProgress<object> progressCallback = null)
> ```

Overload method. Starts asynchronous download of a storage file into a local file.




<a name="File_DownloadData"></a>
#### **DownloadData**
> ```
> byte[] DownloadData(string fileUri, string storageName = null, string versionId = null)
> ```

Downloads a storage file into a byte array synchronously by its storage path and saves by a local file system path.




<a name="File_DownloadData_1"></a>
#### **DownloadData**
> ```
> byte[] DownloadData(RemoteFile file, string versionId = null)
> ```

Overloaded method. Downloads a storage file into a byte array synchronously by RemoteFile object.




<a name="File_DownloadDataAsync"></a>
#### **DownloadDataAsync**
> ```
> AsyncResult<byte[]> DownloadDataAsync(string fileUri, 
>         string storageName = null, 
>         string versionId = null,
>         IProgress<ProgressData> progressCallback = null )
> ```

Starts asynchronous download of a storage file into a byte array.




<a name="File_DownloadDataAsync_1"></a>
#### **DownloadDataAsync**
> ```
> AsyncResult<byte[]> DownloadDataAsync(RemoteFile file, string versionId = null, 
>         IProgress < ProgressData > progressCallback = null)
> ```

Overloaded method. Starts asynchronous download of a storage file into the byte array.




<a name="File_OpenRead"></a>
#### **OpenRead**
> ```
> Stream OpenRead(string fileUri, string storageName = null, string versionId = null)
> ```

Opens to read a stream associated with a storage file specified by its path in the specified or default storage.



<a name="File_OpenRead_1"></a>
#### **OpenRead**
> ```
> Stream OpenRead(RemoteFile file, string versionId = null)
> ```

Overloaded method. Opens to read a stream associated with a storage file specified by RemoteFile object.




<a name="File_DeleteFile"></a>
#### **DeleteFile**
> ```
> bool DeleteFile(string fileUri, string storageName = null, string versionId = null)
> ```

Deletes a storage file by its path from the specified or default storage.



<a name="File_DeleteFile_1"></a>
#### **DeleteFile**
> ```
> bool DeleteFile(RemoteFile file, string versionId = null)
> ```

Overloaded method. Deletes a storage file specified by RemoteFile object.




<a name="File_CopyFile"></a>
#### **CopyFile**
> ```
> RemoteFile CopyFile(string srcFileUri, string destFileUri, string srcStorageName = null, 
>      string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Copies a storage file.




<a name="File_CopyFile_1"></a>
#### **CopyFile**
> ```
> RemoteFile CopyFile(RemoteFile srcFile, string destFileUri, string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Overloaded method. Copies a storage file.



<a name="File_CopyFile_2"></a>
#### **CopyFile**
> ```
> RemoteFile CopyFile(RemoteFile srcFile, RemoteFile destFile, NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Overloaded method. Copies a storage file.




<a name="File_MoveFile"></a>
#### **MoveFile**
> ```
> RemoteFile MoveFile(string srcFileUri, string destFileUri, string srcStorageName = null, 
>      		string destStorageName = null, NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Moves a storage file to other storage location.



<a name="File_MoveFile_1"></a>
#### **MoveFile**
> ```
> RemoteFile MoveFile(RemoteFile srcFile, string destFileUri, string destStorageName = null, 
> 				NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Overloaded method. Moves a storage file to other storage location. 



<a name="File_MoveFile_2"></a>
#### **MoveFile**
> ```
> RemoteFile MoveFile(RemoteFile srcFile, RemoteFile destFile, NameCollisionOption option = NameCollisionOption.FailIfExists)
> ```

Overloaded method. Moves a storage file to other storage location.
