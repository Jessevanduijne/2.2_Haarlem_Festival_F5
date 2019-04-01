using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Models.Domain_Models.Dance;

namespace Haarlem_Festival.Models.View_Models.Dance
{
    public class DanceView
    {
        public List<TicketdayView> Friday { get; set; }
        public List<TicketdayView> Saturday { get; set; }
        public List<TicketdayView> Sunday { get; set; }
        public List<Artist> Artists { get; set; }
        public List<List<TicketdayView>> tabs { get; set; }
        
        public DanceView()
        {
            Friday = new List<TicketdayView>();
            Saturday = new List<TicketdayView>();
            Sunday = new List<TicketdayView>();
            tabs = new List<List<TicketdayView>>();

        }
    }
}