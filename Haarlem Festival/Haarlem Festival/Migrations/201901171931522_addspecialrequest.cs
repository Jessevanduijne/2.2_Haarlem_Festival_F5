namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addspecialrequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "SpecialRequest", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "SpecialRequest");
        }
    }
}
