namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing12 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ReceiptBodies");
            AlterColumn("dbo.ReceiptBodies", "ReceiptId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ReceiptBodies", "ReceiptId");
            DropColumn("dbo.ReceiptBodies", "LineId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceiptBodies", "LineId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.ReceiptBodies");
            AlterColumn("dbo.ReceiptBodies", "ReceiptId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ReceiptBodies", new[] { "ReceiptId", "LineId" });
        }
    }
}
