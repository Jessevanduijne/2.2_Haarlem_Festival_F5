using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.View_Models.Dance
{
    public class TicketdayView
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Location { get; set; }
        public string Name { get; set; } // All Access or Artist
        public string Session { get; set; }
        public float Price { get; set; }

    }
}