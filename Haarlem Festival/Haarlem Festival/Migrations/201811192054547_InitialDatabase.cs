namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        RestaurantID = c.Int(nullable: false),
                        AdultTicketAmount = c.Int(),
                        ChildTicketAmount = c.Int(),
                        SpecialRequests = c.String(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
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
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        TicketID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketID, cascadeDelete: true)
                .Index(t => t.TicketID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        GrandTotal = c.Int(nullable: false),
                        GrandAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockID = c.Int(nullable: false, identity: true),
                        InitialStock = c.Int(nullable: false),
                        CurrentStock = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StockID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.OrderItems", "TicketID", "dbo.Tickets");
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Tickets", "RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.Stocks", new[] { "RestaurantID" });
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropIndex("dbo.OrderItems", new[] { "TicketID" });
            DropIndex("dbo.Tickets", new[] { "RestaurantID" });
            DropTable("dbo.Stocks");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Tickets");
        }
    }
}
