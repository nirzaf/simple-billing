namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemSellingPrices", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemSellingPrices", "ItemId_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "SellingPrice_Id", "dbo.ItemSellingPrices");
            DropIndex("dbo.Items", new[] { "SellingPrice_Id" });
            DropIndex("dbo.ItemSellingPrices", new[] { "Item_Id" });
            DropIndex("dbo.ItemSellingPrices", new[] { "ItemId_Id" });
            DropColumn("dbo.Items", "SellingPrice_Id");
            DropTable("dbo.ItemSellingPrices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ItemSellingPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Item_Id = c.Int(),
                        ItemId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Items", "SellingPrice_Id", c => c.Int());
            CreateIndex("dbo.ItemSellingPrices", "ItemId_Id");
            CreateIndex("dbo.ItemSellingPrices", "Item_Id");
            CreateIndex("dbo.Items", "SellingPrice_Id");
            AddForeignKey("dbo.Items", "SellingPrice_Id", "dbo.ItemSellingPrices", "Id");
            AddForeignKey("dbo.ItemSellingPrices", "ItemId_Id", "dbo.Items", "Id");
            AddForeignKey("dbo.ItemSellingPrices", "Item_Id", "dbo.Items", "Id");
        }
    }
}
