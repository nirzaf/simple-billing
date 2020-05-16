namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing57 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNHeaders", "Remarks", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.GRNHeaders", "Remarks");
        }
    }
}
