#StorageItemVersion

Class representing a storage file version.

### Summary

Class that provides information about a version of storage file.

### Namespace 

Aspose.Html.Cloud.Sdk.Api.Model

### Base class

**StorageItem**

### Properties

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
**Name** | **String** | File name | (Inherited from *StorageItem*)
**Path** | **String** | File path, e.g. /folder/folder2/file.ext | (Inherited from *StorageItem*)
**IsFolder** | **Boolean** | Always False |(Inherited from *StorageItem*)
**Size** | **Long** | File size in bytes | (Inherited from *StorageItem*)
**ModifiedDate** | **DateTime** | Last object modification timestamp | (Inherited from *StorageItem*)
**ModifiedDateStr** | **String** | Generic string presentation of the last modification timestamp | (Inherited from *StorageItem*)
**VersionId** | **String** | File version ID |
**IsLatest** | **Boolean** | True if it's the latest version |