namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing14 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ReceiptBodies");
            AddPrimaryKey("dbo.ReceiptBodies", new[] { "ReceiptNo", "ProductId" });
            DropColumn("dbo.ReceiptBodies", "ReceiptId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceiptBodies", "ReceiptId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ReceiptBodies");
            AddPrimaryKey("dbo.ReceiptBodies", "ReceiptId");
        }
    }
}
