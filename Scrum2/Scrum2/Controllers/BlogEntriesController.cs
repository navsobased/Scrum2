using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Datalayer.Models;

namespace Scrum2.Controllers
{
    public class BlogEntriesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: BlogEntries
        public ActionResult Index()
        {
            return View(db.BlogEntries.ToList());
        }

        // GET: BlogEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // GET: BlogEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "BlogEntryId,Title,Text,IsFormal,IsEducation,CreatedDate")] BlogEntry blogEntry, HttpPostedFileBase attachment)
        {
            if (ModelState.IsValid)
            {
                if (attachment != null && attachment.ContentLength > 0) //Checks if a file has been added
                {

                    byte[] fileUploaded = new byte[attachment.ContentLength];
                    attachment.InputStream.Read(fileUploaded, 0, attachment.ContentLength);

                    var uploadedAttachment = new File
                    {
                        FileName = System.IO.Path.GetFileName(attachment.FileName),
                        FileContent = fileUploaded
                    };
                    blogEntry.Attachment = uploadedAttachment;
                }
                blogEntry.CreatedDate = DateTime.Now;
                db.BlogEntries.Add(blogEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogEntry);
        }

        // GET: BlogEntries/CreateFormal
        public ActionResult CreateFormal()
        {
            Dictionary<bool, string> eduRes = new Dictionary<bool, string>();

            eduRes.Add(false, "Research");
            eduRes.Add(true, "Education");

            ViewBag.EduRes = eduRes;

            return View();
        }

        // GET: BlogEntries/CreateInformal
        public ActionResult CreateInformal()
        {
            return View();
        }

        //Return view of a single blog entry
        public ActionResult BlogEntry(int id)
        {
            var blogEntry = db.BlogEntries.Find(id);
            return View(blogEntry);
        }

        // GET: BlogEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // POST: BlogEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogEntryId,Title,Text,CreatedDate")] BlogEntry blogEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogEntry);
        }

        // GET: BlogEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return HttpNotFound();
            }
            return View(blogEntry);
        }

        // POST: BlogEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogEntry blogEntry = db.BlogEntries.Find(id);
            db.BlogEntries.Remove(blogEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
