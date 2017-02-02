using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalayer.Models
{
    public class BlogEntryComment
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BlogEntryCommentId { get; set; }

        [Required]
        public string CommentText { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
