namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptHeaders", "VehicleNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceiptHeaders", "VehicleNumber");
        }
    }
}
