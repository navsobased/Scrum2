using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrum2.Models
{
    public class BlogEntryCommentViewModel
    {
        public int BlogID { get; set; }

        public string CommentText { get; set; }

        public string Author { get; set; }
    }
}