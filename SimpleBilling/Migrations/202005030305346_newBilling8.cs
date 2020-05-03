namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBilling8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptHeaders", "IsQuotation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceiptHeaders", "IsQuotation");
        }
    }
}
