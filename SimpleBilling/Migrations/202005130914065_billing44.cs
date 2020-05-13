namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing44 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MileageTrackings", "NextServiceDue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MileageTrackings", "NextServiceDue");
        }
    }
}
