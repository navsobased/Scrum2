using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Datalayer.Models
{
    public class BlogEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BlogEntryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool IsFormal { get; set; }
        public bool? IsEducation { get; set; }
        public virtual User Author { get; set; }
        public virtual File Attachment { get; set; }
        public virtual ICollection<BlogEntryComment> Comments { get; set; }
    }
}
