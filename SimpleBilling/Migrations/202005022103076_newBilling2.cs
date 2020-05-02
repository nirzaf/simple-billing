namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBilling2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.GRNHeaders", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Suppliers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReceiptBodies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReceiptHeaders", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceiptHeaders", "IsDeleted");
            DropColumn("dbo.ReceiptBodies", "IsDeleted");
            DropColumn("dbo.Suppliers", "IsDeleted");
            DropColumn("dbo.GRNHeaders", "IsDeleted");
            DropColumn("dbo.Employees", "IsDeleted");
            DropColumn("dbo.Customers", "IsDeleted");
            DropColumn("dbo.Categories", "IsDeleted");
        }
    }
}
