namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extratables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        TourId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TourId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tours");
            DropTable("dbo.Artists");
        }
    }
}
