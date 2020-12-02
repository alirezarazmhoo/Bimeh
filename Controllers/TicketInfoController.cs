using Bimeh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bimeh.Controllers
{


    public class TicketInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? id)
        {
            var issuances = db.Issuances.Include(i => i.ServiceProviderCenter.Insurance).Where(s=>s.Id == id).FirstOrDefault();

            return View(issuances);
        }

        [Authorize]
        public ActionResult SaveRequest(int? id)
        {
            Requests requests = new Requests();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = UserManager.FindById(User.Identity.GetUserId());
            requests.ApplicationUserId = user.Id;
            requests.Date = DateTime.Now;
            requests.IssuanceId = id.Value;
            requests.Status = status.Waiting;
            db.Requests.Add(requests);
            db.SaveChanges();
            return RedirectToAction(nameof(Success));
        }
        public ActionResult Success()
        {
            return View();
        }
        public JsonResult GetMessages()
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var chats = db.Chats.Where(s => s.CustomerId == user.Id).ToList();
            return Json(new { success = true, listitems = chats }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]

        public ActionResult AddMessage(Chats chats)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = UserManager.FindById(User.Identity.GetUserId());
            chats.Time = DateTime.Now;
            chats.Type = 1;
            chats.CustomerId = user.Id;
            db.Chats.Add(chats);
            db.SaveChanges();
            return RedirectToAction("../Home/Index");
        }

    }
}