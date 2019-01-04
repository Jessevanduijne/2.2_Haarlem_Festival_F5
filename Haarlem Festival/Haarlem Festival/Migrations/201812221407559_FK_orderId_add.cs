namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK_orderId_add : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.Tickets", new[] { "Order_OrderID" });
            RenameColumn(table: "dbo.Tickets", name: "Order_OrderID", newName: "OrderId");
            AlterColumn("dbo.Tickets", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "OrderId");
            AddForeignKey("dbo.Tickets", "OrderId", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "OrderId", "dbo.Orders");
            DropIndex("dbo.Tickets", new[] { "OrderId" });
            AlterColumn("dbo.Tickets", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.Tickets", name: "OrderId", newName: "Order_OrderID");
            CreateIndex("dbo.Tickets", "Order_OrderID");
            AddForeignKey("dbo.Tickets", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
