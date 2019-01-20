namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderId_nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "OrderId", "dbo.Orders");
            DropIndex("dbo.Tickets", new[] { "OrderId" });
            AlterColumn("dbo.Tickets", "OrderId", c => c.Int());
            CreateIndex("dbo.Tickets", "OrderId");
            AddForeignKey("dbo.Tickets", "OrderId", "dbo.Orders", "OrderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "OrderId", "dbo.Orders");
            DropIndex("dbo.Tickets", new[] { "OrderId" });
            AlterColumn("dbo.Tickets", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "OrderId");
            AddForeignKey("dbo.Tickets", "OrderId", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
    }
}
