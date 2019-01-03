namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class googleVarNameEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "GooglePlacesID", c => c.String());
            DropColumn("dbo.Restaurants", "GoogleReviewLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "GoogleReviewLink", c => c.String());
            DropColumn("dbo.Restaurants", "GooglePlacesID");
        }
    }
}
