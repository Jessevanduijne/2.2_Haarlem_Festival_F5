using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Models.Domain_Models.Dance;

namespace Haarlem_Festival.Models.View_Models.Dance
{
    public class TicketdayView
    {
        public int EventId { get; set; }
        public Nullable<DateTime> Start { get; set; }
        public string Location { get; set; }
        public string Name { get; set; } // All Access or Artist
        public string Session { get; set; }
        public float Price { get; set; }

        public TicketdayView DomainToView(DanceEvent d)
        {
            if (d.EventName.Contains("ALL-ACCESS") && (d.Price == 125.00))
            {
                TicketdayView a = new TicketdayView();
                a.EventId = d.EventId;
                a.Start = null;
                a.Location = "";
                a.Name = "All access for this day";
                a.Session = null;
                a.Price = d.Price;
                return a;
            }
            else if (d.EventName.Contains("ALL-ACCESS") && (d.Price == 250.00))
            {
                TicketdayView b = new TicketdayView();
                b.EventId = d.EventId;
                b.Start = null;
                b.Location = "";
                b.Name = "All access for July 27, 28 and 29";
                b.Session = null;
                b.Price = d.Price;
                return b;
            }
            else
            {
                TicketdayView c = new TicketdayView();
                c.EventId = d.EventId;
                c.Start = d.StartTime;
                c.Location = d.DanceVenue.Name;
                c.Name = d.EventName;
                c.Session = d.Session;
                c.Price = d.Price;
                return c;
            }
        }
    }
}