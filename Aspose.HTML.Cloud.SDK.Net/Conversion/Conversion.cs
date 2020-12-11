using System;
using System.Linq;
using Aspose.HTML.Cloud.Sdk.IO;
using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class Conversion
    {
        public const string UPLOADING = "uploading";
        public const string PENDING = "pending";
        public const string RUNNING = "running";
        public const string COMPLETED = "completed";
        public const string FAULTED = "faulted";
        public const string CANCELED = "canceled";

        public string Id { get; private set; }

        public string Status { get; private set; }

        public RemoteFile[] Files { get; private set; }

        internal void UpdateFrom(ConversionResult dto)
        {
            this.Id = dto.Id.ToString();
            this.Status = dto.Status;
            this.Files = dto.Files?.Select(x => new RemoteFile(new Uri(x), null)).ToArray();
        }

        internal Conversion WithStatus(string status)
        {
            this.Status = status;
            return this;
        }
    }
}