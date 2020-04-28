namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemSellingPrices", "ItemId_Id", "dbo.Items");
            DropIndex("dbo.ItemSellingPrices", new[] { "ItemId_Id" });
            AddColumn("dbo.Items", "SellingPrice", c => c.Single(nullable: false));
            DropTable("dbo.ItemSellingPrices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ItemSellingPrices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        ItemId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PriceId);
            
            DropColumn("dbo.Items", "SellingPrice");
            CreateIndex("dbo.ItemSellingPrices", "ItemId_Id");
            AddForeignKey("dbo.ItemSellingPrices", "ItemId_Id", "dbo.Items", "Id");
        }
    }
}
