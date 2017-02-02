using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalayer.Models
{
    public class Invite
    {
        public int InviteId { get; set; }
        public User InvitedUser { get; set; }
        public bool Accepted { get; set; }
        public DateTime AcceptedTime { get; set; }
    }
}
