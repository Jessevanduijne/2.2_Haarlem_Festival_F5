using Haarlem_Festival.Models.Domain_Models.General;
using Haarlem_Festival.Models.Domain_Models.Food;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Database_Connection
{
    public class HFContext : DbContext
    {
        public HFContext() : base("name=HFContext")
        {

        }

        // General:
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        // Food:
        public DbSet<FoodTicket> FoodTickets { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; } 
    }
}