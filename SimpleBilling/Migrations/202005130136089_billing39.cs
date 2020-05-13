namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing39 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNHeaders", "Returns", c => c.Single(nullable: false));
            DropColumn("dbo.GRNDetails", "Returns");
        }

        public override void Down()
        {
            AddColumn("dbo.GRNDetails", "Returns", c => c.Single(nullable: false));
            DropColumn("dbo.GRNHeaders", "Returns");
        }
    }
}