using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using DHTMLX.Scheduler;
namespace Datalayer.Models
{
    /**
     * Ett Meeting är en faktisk mötesbokning, som ska visas i kalendern.
     */
    public class Meeting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DHXJson(Alias = "id")]
        public int MeetingId { get; set; }
        [DHXJson(Alias = "start_date")]
        public DateTime StartTime { get; set; }
        [DHXJson(Alias = "end_date")]
        public DateTime EndTime { get; set; }
        [DHXJson(Alias = "text")]
        public string Description { get; set; }

        public virtual User Organizer { get; set; }
        public virtual HashSet<Invite> Invited { get; set; }

    }
}
