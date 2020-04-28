namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing2 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Items", t => t.ItemId_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.ItemId_Id);
            
            AddColumn("dbo.Items", "SellingPrice_Id", c => c.Int());
            CreateIndex("dbo.Items", "SellingPrice_Id");
            AddForeignKey("dbo.Items", "SellingPrice_Id", "dbo.ItemSellingPrices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "SellingPrice_Id", "dbo.ItemSellingPrices");
            DropForeignKey("dbo.ItemSellingPrices", "ItemId_Id", "dbo.Items");
            DropForeignKey("dbo.ItemSellingPrices", "Item_Id", "dbo.Items");
            DropIndex("dbo.ItemSellingPrices", new[] { "ItemId_Id" });
            DropIndex("dbo.ItemSellingPrices", new[] { "Item_Id" });
            DropIndex("dbo.Items", new[] { "SellingPrice_Id" });
            DropColumn("dbo.Items", "SellingPrice_Id");
            DropTable("dbo.ItemSellingPrices");
        }
    }
}
