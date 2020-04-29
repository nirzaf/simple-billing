namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing15 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ReceiptBodies");
            DropPrimaryKey("dbo.ReceiptHeaders");
            AlterColumn("dbo.ReceiptBodies", "ReceiptNo", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ReceiptBodies", new[] { "ReceiptNo", "ProductId" });
            AddPrimaryKey("dbo.ReceiptHeaders", "ReceiptNo");
            DropColumn("dbo.ReceiptHeaders", "ReceiptId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceiptHeaders", "ReceiptId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ReceiptHeaders");
            DropPrimaryKey("dbo.ReceiptBodies");
            AlterColumn("dbo.ReceiptBodies", "ReceiptNo", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ReceiptHeaders", "ReceiptId");
            AddPrimaryKey("dbo.ReceiptBodies", new[] { "ReceiptNo", "ProductId" });
        }
    }
}
