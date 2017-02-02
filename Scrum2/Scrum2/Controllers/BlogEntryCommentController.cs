using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datalayer.Models;
using Scrum2.Models;

namespace Scrum2.Controllers
{
    public class BlogEntryCommentContoller : Controller
    {
        [HttpPost]
        public ActionResult saveComment(BlogEntryCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                BlogEntryComment comment = new BlogEntryComment { CommentText = model.CommentText, Author = model.Author };
                using (var db = new Datalayer.Models.DatabaseContext())
                {
                    db.BlogEntryComments.Add(comment);
                    var blog = db.BlogEntries.Find(model.BlogID);
                    blog.Comments.Add(comment);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("BlogEntry", "BlogEntries");
        }
    }
}