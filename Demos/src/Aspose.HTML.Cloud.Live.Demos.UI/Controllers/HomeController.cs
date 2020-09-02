using Aspose.HTML.Cloud.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspose.HTML.Cloud.Live.Demos.UI.Controllers
{
	public class HomeController : BaseController
	{
	
		public override string Product => (string)RouteData.Values["productname"];
		

		public ActionResult Default()
		{
			ViewBag.PageTitle = "HTML Renderer &amp; Converter REST API (C# &amp; .NET REST SDK)";
			ViewBag.MetaDescription = ".NET C# cloud SDK to turn (convert) HTML into PDF, XPS, JSON, Markdown, JPEG, PNG, ZIP (Images) and various other formats.";
			var model = new LandingPageModel(this);

			return View(model);
		}
	}
}
