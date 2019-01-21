using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Models.Domain_Models.Dance;
using Haarlem_Festival.Models.View_Models.Dance;

namespace Haarlem_Festival.Models.View_Models.Dance
{
    public class Ticketview
    {
        public List<TicketdayView> Friday { get; set; }
        public List<TicketdayView> Saturday { get; set; }
        public List<TicketdayView> Sunday { get; set; }

        public Ticketview DomainToView(IEnumerable<DanceEvent> danceEvents)
        {
            TicketdayView t = new TicketdayView();
            Friday = new List<TicketdayView>();
            Saturday = new List<TicketdayView>();
            Sunday = new List<TicketdayView>();
            foreach(DanceEvent d in danceEvents)
            {                
                if(d.StartTime.Day == 26)
                {
                    Friday.Add(t.DomainToView(d));
                }
                else if(d.StartTime.Day == 27)
                {
                    Saturday.Add(t.DomainToView(d));
                }
                else if(d.StartTime.Day == 28)
                {
                    Sunday.Add(t.DomainToView(d));
                }
                else
                {
                    Friday.Add(t.DomainToView(d));
                    Saturday.Add(t.DomainToView(d));
                    Sunday.Add(t.DomainToView(d));
                }
            }
            
            return this;
        }
    }

    
}