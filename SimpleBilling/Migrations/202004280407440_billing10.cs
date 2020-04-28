namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptBodies", "Is_Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReceiptHeaders", "Is_Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceiptHeaders", "Is_Deleted");
            DropColumn("dbo.ReceiptBodies", "Is_Deleted");
        }
    }
}
