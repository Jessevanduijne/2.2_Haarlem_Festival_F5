namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jazz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Price", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Price");
        }
    }
}
