using Datalayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum2.Controllers
{
    [AllowAnonymous]
    public class FormalBlogController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        
        // GET: FormalBlog
        public ActionResult FormalBlog()
        {
            List<BlogEntry> items = (from entries in db.BlogEntries
                                     where entries.IsFormal == true
                                     select entries).ToList();

            return View(items);
        }
    }
}