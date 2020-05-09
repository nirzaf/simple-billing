namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptHeaders", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceiptHeaders", "CustomerId");
        }
    }
}
