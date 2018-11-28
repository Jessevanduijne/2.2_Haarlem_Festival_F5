using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Haarlem_Festival.Models.Domain_Models.General;

namespace Haarlem_Festival.Models.Domain_Models.Jazz
{
    public class JazzEvent : Event
    {
        // Properties:
        public string Artist { get; set; }

        // Foreign Key        
        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        
        // Navigation Properties:
        public Venue Venue { get; set; }
    }
}