using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Haarlem_Festival.Models.Domain_Models.General;

namespace Haarlem_Festival.Models.Domain_Models.Jazz
{
    // Table per type
    [Table("JazzEvents")]
    public class JazzEvent : Event
    {
        // Properties:
        public string JazzArtist { get; set; }

        // Foreign Key        
        [ForeignKey("JazzVenue")]
        public int JazzVenueId { get; set; }
        
        // Navigation Properties:
        public Venue JazzVenue { get; set; }
        public double Price { get; set; }
        public string PictureLocation { get; set; }
        public string Description { get; set; }
    }
}