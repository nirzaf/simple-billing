namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBilling3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "IsDeleted", c => c.Int(nullable: false));
        }
    }
}
