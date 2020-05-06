namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MileageTrackings", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.MileageTrackings", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.MileageTrackings", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MileageTrackings", "IsDeleted");
            DropColumn("dbo.MileageTrackings", "UpdatedDate");
            DropColumn("dbo.MileageTrackings", "CreatedDate");
        }
    }
}
