namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemSellingPrices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        ItemId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PriceId)
                .ForeignKey("dbo.Items", t => t.ItemId_Id)
                .Index(t => t.ItemId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemSellingPrices", "ItemId_Id", "dbo.Items");
            DropIndex("dbo.ItemSellingPrices", new[] { "ItemId_Id" });
            DropTable("dbo.ItemSellingPrices");
        }
    }
}
