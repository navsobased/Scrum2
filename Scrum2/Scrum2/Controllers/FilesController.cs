using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datalayer.Models;
using System.IO;

namespace Scrum2.Controllers
{
    public class FilesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Files
        public ActionResult GetFile(int id)
        {
            var retrievedFile = db.Files.Find(id);

            MemoryStream memoryStream = new MemoryStream(retrievedFile.FileContent, 0, 0, true, true);
            Response.AddHeader("content-disposition", "attachment;filename=" + retrievedFile.FileName);
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();
            return new FileStreamResult(Response.OutputStream, "File");
        }
    }
}