namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "UnitCost", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "UnitCost");
        }
    }
}
