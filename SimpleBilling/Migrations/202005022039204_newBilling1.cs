namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBilling1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusinessModels", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BusinessModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Items", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Items", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Shelves", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Shelves", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GRNDetails", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GRNDetails", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GRNHeaders", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GRNHeaders", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Suppliers", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Suppliers", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceiptBodies", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceiptBodies", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceiptHeaders", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceiptHeaders", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UpdatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceiptHeaders", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceiptHeaders", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceiptBodies", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceiptBodies", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Suppliers", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Suppliers", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GRNHeaders", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GRNHeaders", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GRNDetails", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GRNDetails", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Shelves", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Shelves", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Items", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Items", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BusinessModels", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BusinessModels", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
