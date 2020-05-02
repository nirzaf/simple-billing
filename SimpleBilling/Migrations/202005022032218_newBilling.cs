namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBilling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessModels", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BusinessModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Shelves", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Shelves", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GRNDetails", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GRNDetails", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GRNHeaders", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GRNHeaders", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Suppliers", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Suppliers", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceiptBodies", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceiptBodies", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceiptHeaders", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceiptHeaders", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UpdatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UpdatedDate");
            DropColumn("dbo.Users", "CreatedDate");
            DropColumn("dbo.ReceiptHeaders", "UpdatedDate");
            DropColumn("dbo.ReceiptHeaders", "CreatedDate");
            DropColumn("dbo.ReceiptBodies", "UpdatedDate");
            DropColumn("dbo.ReceiptBodies", "CreatedDate");
            DropColumn("dbo.Suppliers", "UpdatedDate");
            DropColumn("dbo.Suppliers", "CreatedDate");
            DropColumn("dbo.GRNHeaders", "UpdatedDate");
            DropColumn("dbo.GRNHeaders", "CreatedDate");
            DropColumn("dbo.GRNDetails", "UpdatedDate");
            DropColumn("dbo.GRNDetails", "CreatedDate");
            DropColumn("dbo.Employees", "UpdatedDate");
            DropColumn("dbo.Employees", "CreatedDate");
            DropColumn("dbo.Customers", "UpdatedDate");
            DropColumn("dbo.Customers", "CreatedDate");
            DropColumn("dbo.Shelves", "UpdatedDate");
            DropColumn("dbo.Shelves", "CreatedDate");
            DropColumn("dbo.Items", "UpdatedDate");
            DropColumn("dbo.Items", "CreatedDate");
            DropColumn("dbo.Categories", "UpdatedDate");
            DropColumn("dbo.Categories", "CreatedDate");
            DropColumn("dbo.BusinessModels", "UpdatedDate");
            DropColumn("dbo.BusinessModels", "CreatedDate");
        }
    }
}
