using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Datalayer.Models;

namespace Scrum2.api
{
    public class CommentApi : ApiController
    {
        private DatabaseContext context = new DatabaseContext();

        // POST /api/WebApi
        //Save comment to database
        [HttpPost]
        public IHttpActionResult Post([FromBody]BlogEntryComment model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.BlogEntryComments.Add(model);
            context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = model.BlogEntryCommentId }, model);
        }
    }
}