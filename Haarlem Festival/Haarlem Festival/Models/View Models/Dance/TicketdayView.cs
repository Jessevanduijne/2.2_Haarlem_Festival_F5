using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Models.Domain_Models.Dance;

namespace Haarlem_Festival.Models.View_Models.Dance
{
    public class TicketdayView
    {
        public Nullable<DateTime> Start { get; set; }
        public string Location { get; set; }
        public string Name { get; set; } // All Access or Artist
        public string Session { get; set; }
        public float Price { get; set; }

        public TicketdayView DomainToView(DanceEvent d)
        {
            if (d.EventName.Contains("ALL-ACCESS") && (d.Price == 125.00))
            {
                Start = null;
                Location = null;
                Name = "All access for this day";
                Session = null;
                Price = d.Price;
                return this;
            }
            else if (d.EventName.Contains("ALL-ACCESS") && (d.Price == 250.00))
            {
                Start = null;
                Location = null;
                Name = "All access for July 27, 28 and 29";
                Session = null;
                Price = d.Price;
                return this;
            }
            else
            {
                Start = d.StartTime;
                Location = d.DanceVenue.Name;
                Name = d.EventName;
                Session = d.Session;
                Price = d.Price;
                return this;
            }
        }
    }
}