using Haarlem_Festival.Models.Domain_Models.Food;
using Haarlem_Festival.Models.Domain_Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haarlem_Festival.Models.View_Models.Food
{
    public class RestaurantBooking
    {        
        // Dropdownlist:
        public int SelectedEvent { get; set; }
        public IEnumerable<Event> Events { get; set; }
        
        // View-data:
        public string TimeAvailable { get; set; }
        public string RestaurantName { get; set; }

        // Input:
        [Required, Range(1, 10, ErrorMessage = "At least one adult has to be in your party")]
        public int AdultTickets { get; set; }

        [Range(0, 10, ErrorMessage = "You can't book more than 10 children in your party")]
        public int ChildTickets { get; set; }

        public string SpecialRequest { get; set; }

        // Pass data to post:
        public int RestaurantId { get; set; }
        
    }
}