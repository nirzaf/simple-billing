namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptBodies", "ReceiptNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceiptBodies", "ReceiptNo");
        }
    }
}
