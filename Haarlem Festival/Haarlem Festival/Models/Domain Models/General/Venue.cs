using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haarlem_Festival.Models.Domain_Models.General
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }

        // Properties
        public string Name { get; set; } // EG: Patronaat - Main hall
        public string VenueLink { get; set; } // Google maps link
        public string Address { get; set; }
    }
}