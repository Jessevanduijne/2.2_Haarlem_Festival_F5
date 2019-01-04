using Haarlem_Festival.Models.Domain_Models.Food;
using Haarlem_Festival.Models.Domain_Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.View_Models.Food
{
    public class RestaurantBooking
    {
        public int SelectedEvent { get; set; }
        public IEnumerable<Event> Events { get; set; }
        
        public string TimeAvailable { get; set; }

        public int AdultTickets { get; set; }
        public int ChildTickets { get; set; }

        public string SpecialRequest { get; set; }

        public string RestaurantName { get; set; }


        // Test: Pass some data
        public int RestaurantId { get; set; }
        
    }
}