namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBilling9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ReceiptBodies", "Is_Deleted");
            DropColumn("dbo.ReceiptHeaders", "Is_Deleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceiptHeaders", "Is_Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReceiptBodies", "Is_Deleted", c => c.Boolean(nullable: false));
        }
    }
}
