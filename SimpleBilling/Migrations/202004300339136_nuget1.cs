namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuget1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shelves",
                c => new
                    {
                        ShelfId = c.Int(nullable: false, identity: true),
                        ShelfName = c.String(nullable: false, maxLength: 150),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ShelfId);
            
            AddColumn("dbo.Items", "Shelfs_ShelfId", c => c.Int());
            CreateIndex("dbo.Items", "Shelfs_ShelfId");
            AddForeignKey("dbo.Items", "Shelfs_ShelfId", "dbo.Shelves", "ShelfId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Shelfs_ShelfId", "dbo.Shelves");
            DropIndex("dbo.Items", new[] { "Shelfs_ShelfId" });
            DropColumn("dbo.Items", "Shelfs_ShelfId");
            DropTable("dbo.Shelves");
        }
    }
}
