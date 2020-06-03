namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptBodies", "IsReturned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceiptBodies", "IsReturned");
        }
    }
}
