namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDatabase : DbMigration
    {
        public override void Up()
        {
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
                        RestaurantID = c.Int(),
                        JazzArtist = c.String(),
                        JazzVenueId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Venues", t => t.DanceVenueId, cascadeDelete: false)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.JazzVenueId, cascadeDelete: false)
                .Index(t => t.DanceVenueId)
                .Index(t => t.RestaurantID)
                .Index(t => t.JazzVenueId);
            
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
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .Index(t => t.EventId)
                .Index(t => t.Order_OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "JazzVenueId", "dbo.Venues");
            DropForeignKey("dbo.Events", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Events", "DanceVenueId", "dbo.Venues");
            DropIndex("dbo.Tickets", new[] { "Order_OrderID" });
            DropIndex("dbo.Tickets", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "JazzVenueId" });
            DropIndex("dbo.Events", new[] { "RestaurantID" });
            DropIndex("dbo.Events", new[] { "DanceVenueId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Orders");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Venues");
            DropTable("dbo.Events");
        }
    }
}
