namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleterestaurantdescription : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurants", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Description", c => c.String());
        }
    }
}
