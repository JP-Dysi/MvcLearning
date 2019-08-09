using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLearning.Controllers
{
	public class HelloWorldController : Controller
	{
		// GET: /HelloWorld
		// "Index" = default, plain old "/HelloWorld"
		// anything else requires a "/HelloWorld/OTHER_THING"
		// general http request routing is: /controller/action/parameters(?querystring=blah)
		// these defaults set in app_start/routeconfig.cs
		public ActionResult Index()
		{
			return View();
		}

		// GET: /HelloWorld/Welcome
		// query strings for method params: url?paramName=paramVal&paramName2=paramVal2...
		public ActionResult Welcome(string name="default_name", int count = 1)
		{
			ViewBag.Message = $"Welcome, {name}";
			ViewBag.Count = count;

			return View();
		}

		// GET: /HelloWorld/Details
		// GET: /HelloWorld/Details/ID?name=blah
		// ID is allowed to be part of the url because of route registered in app_start/routeconfig.cs
		public string Details(string name, int id = 1)
		{
			return HttpUtility.HtmlEncode("Details:\nname-" + name + " ID-" + id);
		}


		// GET: /HelloWorld/Details/ID/Stat
		public string Stats(int id, string stat)
		{
			return $"ID: {id} has some amount of {stat}";
		}

    }
}