using Haarlem_Festival.Models.Domain_Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.View_Models
{
    public class RestaurantBooking
    {
        public int SelectedEvent { get; set; }
        public IEnumerable<FoodEvent> Events { get; set; }

        public int AdultTickets { get; set; }
        public int ChildTickets { get; set; }

        public string SpecialRequest { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}