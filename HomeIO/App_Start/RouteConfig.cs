using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeIO
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "List",
				url: "{controller}/List",
				defaults: new { controller = "Record", action = "List" }
			);

			routes.MapRoute(
				name: "ListWithFilter",
				url: "{controller}/List/{id}",
				defaults: new { controller = "Record", action = "ListById", id = "(\\d+)" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
