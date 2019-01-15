using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Haarlem_Festival.Models.Domain_Models.General;

namespace Haarlem_Festival.Models.Domain_Models.Dance
{
    [Table("DanceEvents")]
    public class DanceEvent : Event
    {
        // Properties:
        public string DanceArtist { get; set; } // DJ
        public string Session { get; set; }
        public float Price { get; set; }

        // Foreign Key        
        [ForeignKey("DanceVenue")]
        public int DanceVenueId { get; set; }

        // Navigation Properties:
        public Venue DanceVenue { get; set; }
    }
}
