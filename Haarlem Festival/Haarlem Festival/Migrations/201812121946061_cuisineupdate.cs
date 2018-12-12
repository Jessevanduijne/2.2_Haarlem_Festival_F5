namespace Haarlem_Festival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cuisineupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        CuisineId = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.CuisineId);
            
            CreateTable(
                "dbo.RestaurantCuisines",
                c => new
                    {
                        Restaurant_RestaurantID = c.Int(nullable: false),
                        Cuisine_CuisineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Restaurant_RestaurantID, t.Cuisine_CuisineId })
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_RestaurantID, cascadeDelete: true)
                .ForeignKey("dbo.Cuisines", t => t.Cuisine_CuisineId, cascadeDelete: true)
                .Index(t => t.Restaurant_RestaurantID)
                .Index(t => t.Cuisine_CuisineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantCuisines", "Cuisine_CuisineId", "dbo.Cuisines");
            DropForeignKey("dbo.RestaurantCuisines", "Restaurant_RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.RestaurantCuisines", new[] { "Cuisine_CuisineId" });
            DropIndex("dbo.RestaurantCuisines", new[] { "Restaurant_RestaurantID" });
            DropTable("dbo.RestaurantCuisines");
            DropTable("dbo.Cuisines");
        }
    }
}
