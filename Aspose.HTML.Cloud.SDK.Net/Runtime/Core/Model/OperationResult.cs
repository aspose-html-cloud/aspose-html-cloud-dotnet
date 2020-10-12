namespace Aspose.HTML.Cloud.Sdk.Runtime.Core.Model
{
    public class OperationResult
    {
        public const string PENDING = "pending";
        public const string RUNNING = "running";
        public const string COMPLETED = "completed";
        public const string FAULTED = "faulted";
        public const string CANCELED = "canceled";


        public int Code { get; set; }

        public Identifier Id { get; set; }

        public string Status { get; set; }

        public Links Links { get; set; }
    }
}