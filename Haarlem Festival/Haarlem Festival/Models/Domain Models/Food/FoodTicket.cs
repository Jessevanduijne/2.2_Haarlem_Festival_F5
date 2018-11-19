using Haarlem_Festival.Models.Domain_Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Domain_Models.Food
{
    public class FoodTicket : Ticket
    {        
        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public int AdultTicketAmount { get; set; }
        public int ChildTicketAmount { get; set; }

        // Optional: (virtual makes it optional)
        public virtual string SpecialRequests { get; set;  }
    }
}