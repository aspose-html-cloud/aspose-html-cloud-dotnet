using Aspose.HTML.Cloud.Live.Demos.UI.Config;
using Aspose.HTML.Cloud.Live.Demos.UI.Models;
using Aspose.HTML.Cloud.Live.Demos.UI.Services;
using Aspose.HTML.Cloud.Live.Demos.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Aspose.Html.Cloud.Sdk;
using Aspose.Html.Cloud.Sdk.Api;
using Aspose.Html.Cloud.Sdk.Client;

namespace Aspose.HTML.Cloud.Live.Demos.UI.Controllers
{
	public abstract class BaseController : Controller
	{
	
		protected HtmlApi htmlApi = new HtmlApi(Config.Configuration.AppSID, Config.Configuration.AppKey, Config.Configuration.BaseProductURI);
		/// <summary>
		/// Response when uploaded files exceed the limits
		/// </summary>
		protected Response BadDocumentResponse = new Response()
		{
			Status = "Some of your documents are corrupted",
			StatusCode = 500
		};
		

		public abstract string Product { get; }

		protected override void OnActionExecuted(ActionExecutedContext ctx)
		{
			base.OnActionExecuted(ctx);			
			ViewBag.Title = ViewBag.Title ?? Resources["ApplicationTitle"];
			ViewBag.MetaDescription = ViewBag.MetaDescription ?? "Save time and software maintenance costs by running single instance of software, but serving multiple tenants/websites. Customization available for Joomla, Wordpress, Discourse, Confluence and other popular applications.";
		}

		private AsposeHTMLCloudContext _atcContext;
		

		/// <summary>
		/// Main context object to access all the dcContent specific context info
		/// </summary>
		public AsposeHTMLCloudContext AsposeHTMLCloudContext
		{
			get
			{
				if (_atcContext == null) _atcContext = new AsposeHTMLCloudContext(HttpContext.ApplicationInstance.Context);
				return _atcContext;
			}
		}

		private Dictionary<string, string> _resources;

		/// <summary>
		/// key/value pair containing all the error messages defined in resources.xml file
		/// </summary>
		public Dictionary<string, string> Resources
		{
			get
			{
				if (_resources == null) _resources = AsposeHTMLCloudContext.Resources;
				return _resources;
			}
		}

		

		
	}
}
