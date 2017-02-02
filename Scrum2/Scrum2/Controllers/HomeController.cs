using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datalayer.Models;

namespace Scrum2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        DatabaseContext context = new DatabaseContext();

        public ActionResult Index()
        {
            //TODO: testkod, ta bort senare:
            //User enUser = new User { Signature = "hej" };
            //context.Users.Add(enUser);
            //context.SaveChanges();
            //User hamtadUser = context.Users.First();
            //ViewBag.userSig = hamtadUser.Signature;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}