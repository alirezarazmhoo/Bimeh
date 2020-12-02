using Bimeh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace Bimeh.Controllers
{
	public class HomeController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public ActionResult Index()
		{

			var issuances = db.Issuances.Include(i => i.ServiceProviderCenter.Insurance).ToList();

			return View(issuances);
		}
	}
}