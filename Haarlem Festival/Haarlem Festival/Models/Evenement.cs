using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Naam { get; set; }
        public DateTime Start { get; set; }
        public DateTime Eind { get; set; }
        public int Beschikbaarheid { get; set; }
        public int LocatieId { get; set; }

    }
}