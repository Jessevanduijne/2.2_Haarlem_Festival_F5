namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class help : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        CuisineId = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.CuisineId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        Stars = c.Int(nullable: false),
                        Description = c.String(),
                        ImageLink = c.String(),
                        Address = c.String(),
                        RouteLink = c.String(),
                        WebsiteLink = c.String(),
                        PriceAdults = c.Single(nullable: false),
                        PriceChildren = c.Single(nullable: false),
                        GoogleReviewLink = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        MaxTickets = c.Int(nullable: false),
                        CurrentTickets = c.Int(nullable: false),
                        DanceArtist = c.String(),
                        Session = c.String(),
                        DanceVenueId = c.Int(),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Venues", t => t.DanceVenueId, cascadeDelete: true)
                .Index(t => t.DanceVenueId);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VenueLink = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.VenueId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Amount = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.RestaurantCuisines",
                c => new
                    {
                        Restaurant_RestaurantID = c.Int(nullable: false),
                        Cuisine_CuisineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurant_RestaurantID, t.Cuisine_CuisineId })
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_RestaurantID, cascadeDelete: true)
                .ForeignKey("dbo.Cuisines", t => t.Cuisine_CuisineId, cascadeDelete: true)
                .Index(t => t.Restaurant_RestaurantID)
                .Index(t => t.Cuisine_CuisineId);
            
            CreateTable(
                "dbo.JazzEvents",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        JazzArtist = c.String(),
                        JazzVenueId = c.Int(nullable: false),
                        Description = c.String(),
                        PictureLocation = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Events", t => t.EventId)
                .ForeignKey("dbo.Venues", t => t.JazzVenueId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.JazzVenueId);
            
            CreateTable(
                "dbo.FoodEvents",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Events", t => t.EventId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodEvents", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.FoodEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.JazzEvents", "JazzVenueId", "dbo.Venues");
            DropForeignKey("dbo.JazzEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.Tickets", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "DanceVenueId", "dbo.Venues");
            DropForeignKey("dbo.RestaurantCuisines", "Cuisine_CuisineId", "dbo.Cuisines");
            DropForeignKey("dbo.RestaurantCuisines", "Restaurant_RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.FoodEvents", new[] { "RestaurantID" });
            DropIndex("dbo.FoodEvents", new[] { "EventId" });
            DropIndex("dbo.JazzEvents", new[] { "JazzVenueId" });
            DropIndex("dbo.JazzEvents", new[] { "EventId" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Cuisine_CuisineId" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Restaurant_RestaurantID" });
            DropIndex("dbo.Tickets", new[] { "OrderId" });
            DropIndex("dbo.Tickets", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "DanceVenueId" });
            DropTable("dbo.FoodEvents");
            DropTable("dbo.JazzEvents");
            DropTable("dbo.RestaurantCuisines");
            DropTable("dbo.Tickets");
            DropTable("dbo.Orders");
            DropTable("dbo.Venues");
            DropTable("dbo.Events");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Cuisines");
        }
    }
}
