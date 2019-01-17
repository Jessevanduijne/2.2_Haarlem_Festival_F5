namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllToTPT : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Events", newName: "DanceEvents");
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropForeignKey("dbo.FoodEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.JazzEvents", "EventId", "dbo.Events");
            DropIndex("dbo.DanceEvents", new[] { "DanceVenueId" });
            DropPrimaryKey("dbo.DanceEvents");
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
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Guides",
                c => new
                    {
                        GuideID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.GuideID);
            
            CreateTable(
                "dbo.HistoricEvents",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        GuideID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Events", t => t.EventId)
                .ForeignKey("dbo.Guides", t => t.GuideID, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.GuideID);
            
            AddColumn("dbo.Artists", "Name", c => c.String());
            AddColumn("dbo.Artists", "Description", c => c.String());
            AddColumn("dbo.Artists", "ImgUrl", c => c.String());
            AddColumn("dbo.DanceEvents", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.DanceEvents", "EventId", c => c.Int(nullable: false));
            AlterColumn("dbo.DanceEvents", "DanceVenueId", c => c.Int(nullable: true));
            AddPrimaryKey("dbo.DanceEvents", "EventId");
            CreateIndex("dbo.DanceEvents", "EventId");
            CreateIndex("dbo.DanceEvents", "DanceVenueId");
            AddForeignKey("dbo.DanceEvents", "EventId", "dbo.Events", "EventId");
            DropColumn("dbo.DanceEvents", "EventName");
            DropColumn("dbo.DanceEvents", "StartTime");
            DropColumn("dbo.DanceEvents", "EndTime");
            DropColumn("dbo.DanceEvents", "MaxTickets");
            DropColumn("dbo.DanceEvents", "CurrentTickets");
            DropColumn("dbo.DanceEvents", "Discriminator");
            DropTable("dbo.Tours");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        TourId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TourId);
            
            AddColumn("dbo.DanceEvents", "Discriminator", c => c.String(maxLength: 128));
            AddColumn("dbo.DanceEvents", "CurrentTickets", c => c.Int(nullable: false));
            AddColumn("dbo.DanceEvents", "MaxTickets", c => c.Int(nullable: false));
            AddColumn("dbo.DanceEvents", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.DanceEvents", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.DanceEvents", "EventName", c => c.String());
            DropForeignKey("dbo.DanceEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.HistoricEvents", "GuideID", "dbo.Guides");
            DropForeignKey("dbo.HistoricEvents", "EventId", "dbo.Events");
            DropIndex("dbo.DanceEvents", new[] { "DanceVenueId" });
            DropIndex("dbo.DanceEvents", new[] { "EventId" });
            DropIndex("dbo.HistoricEvents", new[] { "GuideID" });
            DropIndex("dbo.HistoricEvents", new[] { "EventId" });
            DropPrimaryKey("dbo.DanceEvents");
            AlterColumn("dbo.DanceEvents", "DanceVenueId", c => c.Int());
            AlterColumn("dbo.DanceEvents", "EventId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.DanceEvents", "Price");
            DropColumn("dbo.Artists", "ImgUrl");
            DropColumn("dbo.Artists", "Description");
            DropColumn("dbo.Artists", "Name");
            DropTable("dbo.HistoricEvents");
            DropTable("dbo.Guides");
            DropTable("dbo.Events");
            AddPrimaryKey("dbo.DanceEvents", "EventId");
            CreateIndex("dbo.DanceEvents", "DanceVenueId");
            AddForeignKey("dbo.JazzEvents", "EventId", "dbo.Events", "EventId");
            AddForeignKey("dbo.FoodEvents", "EventId", "dbo.Events", "EventId");
            AddForeignKey("dbo.Tickets", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
            RenameTable(name: "dbo.DanceEvents", newName: "Events");
        }
    }
}
