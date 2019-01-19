using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Models.Domain_Models.General;
using Haarlem_Festival.Models.Domain_Models.Historic;

namespace Haarlem_Festival.Models.View_Models.Historic
{
    public class TourBooking
    {
        // Dropdownlist:
        // SelectedEvent voor FamilyTickets.
        public int SelectedEvent { get; set; }
        public IEnumerable<Event> Events { get; set; }

        // View-data:
        //public string TimeAvailable { get; set; }
        public string TourName { get; set; }

        // Input:
        public int FamilyTickets { get; set; }
        public int RegularTickets { get; set; }

        // Post to data
        public int EventId { get; set; }

        public HistoricEvent HistoricEvent { get; set; }

    }
}