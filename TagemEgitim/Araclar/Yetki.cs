using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagemEgitim.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;

namespace TagemEgitim.Araclar
{
	public class YetkiAttribute : ActionFilterAttribute
	{
		public string controllerRole { get; set; }
		public YetkiAttribute(string controllerRole) => this.controllerRole = controllerRole;

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			string kulrol = context.HttpContext.Session.GetString("kulrol");
			if (kulrol == "admin")
				return;
			else if (kulrol == "user" & controllerRole == "user")
				return;
			Yetkisiz(context);
		}

		private void Yetkisiz(ActionExecutingContext context)
		{
			context.Result =
				new RedirectToRouteResult(
				new RouteValueDictionary {
								{ "Controller", "Hesaplar" },
								{ "Area", null },
								{ "Action", "Index" }});
		}
	}

	public class KurulumYetkiAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (context.HttpContext.Session.GetString("kurulum") != "ok")
				context.Result = new RedirectToActionResult("Index", "Kurulum", new { area = "Admin" });
				
		}
	}
}
