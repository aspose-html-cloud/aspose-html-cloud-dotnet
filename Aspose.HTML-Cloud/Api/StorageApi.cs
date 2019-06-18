
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Internal;

namespace Aspose.Html.Cloud.Sdk.Api
{
    /// <summary>
    /// Facade class providing wrapper methods of Aspose.Storage Cloud REST API
    /// </summary>
    public class StorageApi : ApiBase
    {
        public StorageApi(string appSid, string appKey, string basePath) : base(appSid, appKey, basePath)
        {
        }

        public StorageApi(string appSid, string appKey, string basePath, string authPath) : base(appSid, appKey, basePath, authPath)
        {
        }

        public StorageApi(string appSid, string appKey, string basePath, TimeSpan timeout) : base(appSid, appKey, basePath, timeout)
        {
        }

        public StorageApi(string appSid, string appKey, string basePath, string authPath, TimeSpan timeout) : base(appSid, appKey, basePath, authPath, timeout)
        {
        }
    }
}
