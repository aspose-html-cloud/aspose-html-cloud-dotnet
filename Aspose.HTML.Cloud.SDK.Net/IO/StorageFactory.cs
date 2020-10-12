using System;
using Aspose.HTML.Cloud.Sdk.Runtime;
using Aspose.HTML.Cloud.Sdk.Runtime.Authentication;

namespace Aspose.HTML.Cloud.Sdk.IO
{
    class StorageFactory
    {
        public static readonly StorageFactory Instance = new StorageFactory();

        public StorageProvider CreateProvider(Configuration configuration, ApiInvokerFactory invokerFactory = null)
        {
            return new StorageProvider(configuration, this, invokerFactory);
        }

        public Uri GetStorageUri(string storageName = null)
        {
            return new Uri($"storage://{(!string.IsNullOrWhiteSpace(storageName) ? storageName : string.Empty)}/");
        }

        public Uri GetLocalUri(string resourceUri)
        {
            return new Uri($"app:///{Guid.NewGuid()}/{resourceUri}");
        }

        public Uri GetResourceUri(string resourceUri, string storageName = null)
        {
            return GetResourceUri(resourceUri, GetStorageUri(storageName));
        }

        public Uri GetResourceUri(string resourceUri, Uri storage)
        {
            return new Uri(storage, resourceUri);
        }

    }
}