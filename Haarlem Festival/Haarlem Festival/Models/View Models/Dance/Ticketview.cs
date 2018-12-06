using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.View_Models.Dance
{
    public class Ticketview
    {
        public List<TicketdayView> Friday { get; set; }
        public List<TicketdayView> Saturday { get; set; }
        public List<TicketdayView> Sunday { get; set; }
    }
}