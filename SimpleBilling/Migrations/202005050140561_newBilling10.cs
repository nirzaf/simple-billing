namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBilling10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptHeaders", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceiptHeaders", "Remarks");
        }
    }
}
