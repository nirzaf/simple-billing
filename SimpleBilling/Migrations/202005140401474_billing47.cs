namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing47 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNHeaders", "PaidAmount", c => c.Single(nullable: false));
            AddColumn("dbo.GRNHeaders", "PendingAmount", c => c.Single(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.GRNHeaders", "PendingAmount");
            DropColumn("dbo.GRNHeaders", "PaidAmount");
        }
    }
}