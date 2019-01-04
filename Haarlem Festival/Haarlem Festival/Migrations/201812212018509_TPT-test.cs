namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPTtest : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Events", new[] { "RestaurantID" });
            CreateTable(
                "dbo.FoodEvents",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Events", t => t.EventId)
                .Index(t => t.EventId)
                .Index(t => t.RestaurantID);
            
            AlterColumn("dbo.Events", "Discriminator", c => c.String(maxLength: 128));
            DropColumn("dbo.Events", "RestaurantID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "RestaurantID", c => c.Int());
            DropForeignKey("dbo.FoodEvents", "EventId", "dbo.Events");
            DropIndex("dbo.FoodEvents", new[] { "RestaurantID" });
            DropIndex("dbo.FoodEvents", new[] { "EventId" });
            AlterColumn("dbo.Events", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.FoodEvents");
            CreateIndex("dbo.Events", "RestaurantID");
        }
    }
}
