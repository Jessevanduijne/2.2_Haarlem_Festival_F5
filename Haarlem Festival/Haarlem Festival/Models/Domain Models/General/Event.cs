using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Domain_Models.General
{
    [Table("Events")]
    public abstract class Event
    {
        [Key]
        public int EventId { get; set; }

        // Properties:
        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaxTickets { get; set; }
        public int CurrentTickets { get; set; }
    }
}