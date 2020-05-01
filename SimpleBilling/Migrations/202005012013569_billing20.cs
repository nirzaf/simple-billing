namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessModels", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BusinessModels", "IsDeleted");
        }
    }
}
