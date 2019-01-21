namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JazzChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JazzEvents", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.JazzEvents", "PictureLocation", c => c.String());
            AddColumn("dbo.JazzEvents", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JazzEvents", "Description");
            DropColumn("dbo.JazzEvents", "PictureLocation");
            DropColumn("dbo.JazzEvents", "Price");
        }
    }
}
