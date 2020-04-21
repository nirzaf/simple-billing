namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ItemName = c.String(),
                        Unit = c.String(),
                        Barcode = c.String(),
                        Categories_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categories_CategoryId)
                .Index(t => t.Categories_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Categories_CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "Categories_CategoryId" });
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
