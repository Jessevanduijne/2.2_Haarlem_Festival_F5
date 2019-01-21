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
        public int SelectedEvent { get; set; }
        public IEnumerable<Event> Events { get; set; }

        // View-data:
        public string TourName { get; set; }

        // Input:
        public bool FamilyTicket { get; set; }
        public int RegularTickets { get; set; }

        // Post to data
        public int EventId { get; set; }
    }
}