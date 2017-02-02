using Datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum2.Controllers
{
    [AllowAnonymous]
    public class InFormalBlogController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: InFormalBlog
        public ActionResult InFormalBlog()
        {
            List<BlogEntry> items = (from entries in db.BlogEntries
                                     where entries.IsFormal == false
                                     select entries).ToList();

            return View(items);
        }
    }
}