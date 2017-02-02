using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datalayer.Models;

namespace Scrum2.Controllers
{
    public class BlogEntryCommentContoller : Controller
    {
        [HttpPost]
        public ActionResult saveComment(BlogEntryCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                BlogEntryComment comment = new BlogEntryComment(new { model.CommentText, model.Author });
                using(var db = new Datalayer.Models.DatabaseContext())
                {
                    db.BlogEntryComments.Add(model);
                    db.BlogEntries.BlogEntryComment.Comment.Add(model);
                    db.SaveChanges();
                }
            }         
        }
    }
}