using Haarlem_Festival.Models.Domain_Models.General;
using Haarlem_Festival.Models.Domain_Models.Food;
using Haarlem_Festival.Models.Domain_Models.Dance;
using Haarlem_Festival.Models.Domain_Models.Jazz;
using Haarlem_Festival.Models.Domain_Models.Historic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Database_Connection
{
    public class HFContext : DbContext
    {
        public HFContext() : base("name=HFContext") { }

        // General:
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }
 
        // Food:
        //public DbSet<FoodEvent> FoodEvents { get; set; }  <------ Removed, TPH to TPT
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }

        // Dance:
        public DbSet<DanceEvent> DanceEvents { get; set; }

        // Jazz:
        public DbSet<JazzEvent> JazzEvents { get; set; }

        // Historic:
        public DbSet<HistoricEvent> HistoricEvents { get; set; }
    }
}