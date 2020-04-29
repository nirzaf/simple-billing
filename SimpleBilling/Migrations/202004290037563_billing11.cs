namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ReceiptBodies", "ProductCode");
            DropColumn("dbo.ReceiptBodies", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceiptBodies", "ProductName", c => c.String(nullable: false));
            AddColumn("dbo.ReceiptBodies", "ProductCode", c => c.String(nullable: false));
        }
    }
}
