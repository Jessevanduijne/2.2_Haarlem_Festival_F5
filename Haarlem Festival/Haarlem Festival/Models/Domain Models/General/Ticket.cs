using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Domain_Models.General
{
    public abstract class Ticket
    {
        [Key]
        public int TicketID { get; set; }

        // Properties:
        public string EventName { get; set; }
    }
}