using Haarlem_Festival.Models.Domain_Models.Food;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Domain_Models.General
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; }        

        public int InitialStock { get; set; } // Always the same amount
        public int CurrentStock { get; set; } // Gets less if a ticket is ordered; gives insight in the ticket sales
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual int RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }        

        // NOTE 1: It's better to include the price in the restaurant/venue table than here so we have less duplicate values
        // NOTE 2: When ready, add an optional VenueID (or however it's named) for each eventtype, so this table can be accessed on each page.
    }
}