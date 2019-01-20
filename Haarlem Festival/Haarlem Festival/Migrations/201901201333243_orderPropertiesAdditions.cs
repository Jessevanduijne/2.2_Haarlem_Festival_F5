namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderPropertiesAdditions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaymentMethod", c => c.String());
            AddColumn("dbo.Orders", "OrderPlaced", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderPlaced");
            DropColumn("dbo.Orders", "PaymentMethod");
        }
    }
}
