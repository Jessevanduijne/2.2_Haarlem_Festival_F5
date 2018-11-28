namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newInitialDatabase : DbMigration
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
                        Artist = c.String(),
                        Session = c.String(),
                        VenueId = c.Int(),
                        RestaurantID = c.Int(),
                        Artist1 = c.String(),
                        VenueId1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenueId1, cascadeDelete: true)
                .Index(t => t.VenueId)
                .Index(t => t.RestaurantID)
                .Index(t => t.VenueId1);
            
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
            DropForeignKey("dbo.Events", "VenueId1", "dbo.Venues");
            DropForeignKey("dbo.Events", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Events", "VenueId", "dbo.Venues");
            DropIndex("dbo.Tickets", new[] { "Order_OrderID" });
            DropIndex("dbo.Tickets", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "VenueId1" });
            DropIndex("dbo.Events", new[] { "RestaurantID" });
            DropIndex("dbo.Events", new[] { "VenueId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Orders");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Venues");
            DropTable("dbo.Events");
        }
    }
}
