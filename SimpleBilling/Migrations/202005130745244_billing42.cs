namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing42 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "ForeRed", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "ForeGreen", c => c.Int(nullable: false));
            AddColumn("dbo.Settings", "ForeBlue", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Settings", "ForeBlue");
            DropColumn("dbo.Settings", "ForeGreen");
            DropColumn("dbo.Settings", "ForeRed");
        }
    }
}