namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Is_Deleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Is_Deleted", c => c.Boolean(nullable: false));
        }
    }
}
