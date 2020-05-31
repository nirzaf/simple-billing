namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "PendingAmount", c => c.Single(nullable: false));
            DropColumn("dbo.Suppliers", "CodeNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "CodeNumber", c => c.String());
            DropColumn("dbo.Suppliers", "PendingAmount");
        }
    }
}
