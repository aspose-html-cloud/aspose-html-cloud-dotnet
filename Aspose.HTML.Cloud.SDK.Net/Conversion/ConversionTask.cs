using Aspose.HTML.Cloud.Sdk.Runtime.Core.Model;

namespace Aspose.HTML.Cloud.Sdk.Conversion
{
    public class ConversionTask
    {
        private string id;

        public string getId()
        {
            return id;
        }
        public string getStatus()
        {
            return "success";
        }

        ConversionResult WaitForResult()
        {
            return null;
        }
    }
}
