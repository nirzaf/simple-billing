namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shelves",
                c => new
                    {
                        ShelId = c.Int(nullable: false, identity: true),
                        ShelfName = c.String(nullable: false, maxLength: 150),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ShelId);
            
            AddColumn("dbo.Items", "Is_Service", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "Shelfs_ShelId", c => c.Int());
            CreateIndex("dbo.Items", "Shelfs_ShelId");
            AddForeignKey("dbo.Items", "Shelfs_ShelId", "dbo.Shelves", "ShelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Shelfs_ShelId", "dbo.Shelves");
            DropIndex("dbo.Items", new[] { "Shelfs_ShelId" });
            DropColumn("dbo.Items", "Shelfs_ShelId");
            DropColumn("dbo.Items", "Is_Service");
            DropTable("dbo.Shelves");
        }
    }
}
