using System.Threading.Tasks;
using System.IO;
using System.Web.Http;
using Aspose.HTML.Cloud.Live.Demos.UI.Models;
using System.Diagnostics;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk;
using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Newtonsoft.Json.Linq;

namespace Aspose.HTML.Cloud.Live.Demos.UI.Models
{
	///<Summary>
	/// Aspose.HTML Cloud API convert method to convert word document file to other format
	///</Summary>
	
	public class AsposeHTMLConversion : AsposeHTMLCloudBase
    {        
        
		///<Summary>
		/// Convert method to convert file to other format
		///</Summary>
		public Response Convert(string fileName, string folderName,   string outputType)
        {
			string fileNamewithOutExtension = Path.GetFileNameWithoutExtension(fileName);
			string outputFileName = fileNamewithOutExtension + "." + outputType;
			AsposeResponse response = null;
			bool foundSaveOption = true;
			
			if (outputType == "epub" || outputType == "svg" || outputType == "tiff" || outputType == "jpeg" || outputType == "png" || outputType == "bmp")
			{
				response = htmlApi.PutConvertDocumentToImage(fileName, outputType, outputFileName, null, null, null, null, null, null, null);
			}
			else
			{
				switch (outputType)
				{
					case "pdf":
						response = htmlApi.PutConvertDocumentToPdf(fileName, outputFileName, null, null, null, null, null, null, null);
						break;
					case "xps":
						response = htmlApi.PutConvertDocumentToXps(fileName, outputFileName, null, null, null, null, null, null, null);
						break;
					case "md":
						response = htmlApi.PutConvertDocumentToMarkdown(fileName, outputFileName, true, null, null);
						break;					
					default:
						foundSaveOption = false;
						break;
				}
			}

			if (htmlApi != null)
			{
				if (foundSaveOption)
				{

					return new Response
					{
						FileName = outputFileName,
						Status = "OK",
						StatusCode = 200,
					};
				}

				
			}
			return new Response
			{
				FileName = null,
				Status = "Output type not found",
				StatusCode = 500
			};

		}
		
    }
}
