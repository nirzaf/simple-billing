namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBilling5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "OwnerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "OwnerId", c => c.Int());
        }
    }
}
