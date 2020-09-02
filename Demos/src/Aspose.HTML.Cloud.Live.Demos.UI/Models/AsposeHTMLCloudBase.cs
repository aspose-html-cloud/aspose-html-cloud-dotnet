using System;
using System.IO;
using System.Web.Http;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api;

namespace  Aspose.HTML.Cloud.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposeHTMLCloudBase class to have base methods
	///</Summary>

	public abstract class AsposeHTMLCloudBase : ApiController
    {
		protected HtmlApi htmlApi = new HtmlApi(Config.Configuration.AppSID, Config.Configuration.AppKey, Config.Configuration.BaseProductURI);
		///<Summary>
		/// Get File extension
		///</Summary>
		protected string GetoutFileExtension(string fileName, string folderName)
        {
			string sourceFolder = Config.Configuration.WorkingDirectory + folderName;
            fileName = sourceFolder + "\\" + fileName;
            return Path.GetExtension(fileName);
        }      
		
    }
}
