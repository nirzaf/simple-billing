namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Categories_CategoryId", c => c.Int());
            CreateIndex("dbo.Items", "Categories_CategoryId");
            AddForeignKey("dbo.Items", "Categories_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Categories_CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "Categories_CategoryId" });
            DropColumn("dbo.Items", "Categories_CategoryId");
        }
    }
}
