namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuget : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Shelfs_ShelId", "dbo.Shelves");
            DropIndex("dbo.Items", new[] { "Shelfs_ShelId" });
            DropColumn("dbo.Items", "Shelfs_ShelId");
            DropTable("dbo.Shelves");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Items", "Shelfs_ShelId", c => c.Int());
            CreateIndex("dbo.Items", "Shelfs_ShelId");
            AddForeignKey("dbo.Items", "Shelfs_ShelId", "dbo.Shelves", "ShelId");
        }
    }
}
