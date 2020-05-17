namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing60 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "SetMinValue", c => c.Int(nullable: false));
            DropColumn("dbo.Settings", "Red");
            DropColumn("dbo.Settings", "Green");
            DropColumn("dbo.Settings", "Blue");
            DropColumn("dbo.Settings", "ForeRed");
            DropColumn("dbo.Settings", "ForeGreen");
            DropColumn("dbo.Settings", "ForeBlue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "ForeBlue", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "ForeGreen", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "ForeRed", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "Blue", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "Green", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "Red", c => c.Int(nullable: false));
            DropColumn("dbo.Settings", "SetMinValue");
        }
    }
}
